using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Company
{
    public partial class CompanyJobSignUpRemark : WebBase.Free
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request["action"])
            {
                case "GetList":
                    GetList();
                    break;
                case "Add":
                    Add();
                    break;
                //case "Update":
                //    Update();
                //    break;
                //case "Delete":
                //    Delete();
                //    break;
                //case "SwitchReceiveFunction":
                //    SwitchReceiveFunction();
                //    break;
                default:
                    break;
            }

        }

        private void GetList()
        {
            #region
            int pagesize = EasyUI.GetPageSize();//每页显示数量
            int pageindex = EasyUI.GetPageIndex();//页码
            #endregion

            string strWhere = "and r.SignUpID=" + Request.QueryString["SignUpID"].Replace("'","''");//"and SuCId=" + Id; // "and CompanyID=" + Id.ToString();

            Response.Write(DataUtility.GetListToJson("SignUpRemark r(nolock) left join SignUp2Company suc(nolock) on r.SuCId=suc.Id", "r.Id,r.IsIntent,r.UserStatus,r.IsReIntroduce,r.ContactTime,r.Remark,r.AddUserName,suc.CompanyName,suc.JobTitle", pagesize, pageindex, "r.Id", strWhere, "order by r.Id desc", true));
            Response.End();
        }

        private void Add()
        {
            int sucId = int.Parse(Request.Form["SuCId"]);
            int SignUpID = int.Parse(Request.Form["SignUpID"]);

            string contacttime = Request.Form["contacttime"];
            bool IsIntent = Request.Form["ddlIsIntent"] == "1";
            bool IsReIntroduce = Request.Form["ddlIsReIntroduce"] == "1";
            int Status = int.Parse(Request.Form["ddlStatus"]);
            string Remark = Request.Form["Remark"];

            try
            {
                DateTime.Parse(contacttime);
            }
            catch
            {
                Maticsoft.Common.Ajax.WriteError("请填写正确的联系时间");
            }

            Model.SignUpRemark model = new Model.SignUpRemark();
            model.SuCId = sucId;
            model.SignUpID = SignUpID;
            model.ContactTime = DateTime.Parse(contacttime);
            model.IsIntent = IsIntent;
            model.UserStatus = Status;
            model.IsReIntroduce = IsReIntroduce;
            model.AddUserID = UserBase.CurAdmin.Id;
            model.AddUserName = UserBase.CurAdmin.Realname;
            model.Remark = Remark;

            BLL.SignUpRemark.Add(model);

            //更新状态
            Model.SignUp2Company suc = BLL.SignUp2Company.GetModel(sucId);
            if (!suc.IsContacted.Value)
            {
                suc.IsContacted = true;
                suc.FirstContactTime = DateTime.Now;//第一次联系
                suc.BelongUserId = UserBase.CurAdmin.Id;
                suc.BelongUserName = UserBase.CurAdmin.Realname;
            }

            suc.IsIntent = IsIntent;
            suc.UserStatus = Status;
            suc.IsReIntroduce = IsReIntroduce;
            suc.LatestContactTime = DateTime.Now;
            suc.Remark = Remark;

            BLL.SignUp2Company.Update(suc);

            Maticsoft.Common.Ajax.WriteOk("添加成功");
        }
    }
}