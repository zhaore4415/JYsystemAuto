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
    public partial class CompanyReceive : WebBase.Edit
    {
        protected bool isreceive = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            switch (Request["action"])
            {
                case "GetList":
                    GetList();
                    break;
                case "Add":
                    AddReceive();
                    break;
                case "Update":
                    Update();
                    break;
                case "Delete":
                    Delete();
                    break;
                case "SwitchReceiveFunction":
                    SwitchReceiveFunction();
                    break;
                default:
                    break;
            }

            isreceive = BLL.Company.GetModel(Id).IsReceive.Value;
        }


        private void GetList()
        {
            #region
            int pagesize = EasyUI.GetPageSize();//每页显示数量
            int pageindex = EasyUI.GetPageIndex();//页码
            #endregion

            string strWhere = "and AddType=1 and Status<>-1 and CompanyID=" + Id.ToString();

            Response.Write(DataUtility.GetListToJson("ReceiveRecord (nolock)", "*,DATEDIFF(day,getdate(),EndDate) as SignUpStatus", pagesize, pageindex, "Id", strWhere, "order by Id desc", true));
            Response.End();
        }

        private void AddReceive()
        {
            int companyId = int.Parse(Request.Form["companyid"]);

            string enddate = Request.Form["receiveEndDate"];
            string address = Request.Form["receiveAddress"];

            if (string.IsNullOrEmpty(enddate))
            {
                Maticsoft.Common.Ajax.WriteError("请填写接站日期");
            }
            if (string.IsNullOrEmpty(address))
            {
                Maticsoft.Common.Ajax.WriteError("请填写接站地点");
            }

            Model.ReceiveRecord model = new Model.ReceiveRecord();
            model.CompanyId = int.Parse(Request.Form["companyid"]);
            model.StartTime = DateTime.Now;
            model.EndDate = DateTime.Parse(Request.Form["receiveEndDate"]);
            model.Address = Request.Form["receiveAddress"];
            model.AddType = 1;
            model.Times = int.Parse(Request.Form["receiveTimes"]);

            //查询最近的一次添加类型，如果上一次是求职者选择报名下一批，系统会自动添加，这次添加只需更新记录。
            DataTable dt = BLL.ReceiveRecord.GetLastRecord(companyId);
            if (dt.Rows.Count > 0)
            {
                if ((int)dt.Rows[0]["AddType"] == 2)
                {
                    //下一批已自动生成
                    model.Id = (int)dt.Rows[0]["Id"];
                    BLL.ReceiveRecord.Update(model);
                }
                //else if ((DateTime.Parse(dt.Rows[0]["EndDate"].ToString()) - DateTime.Now).Days > 0)
                //{
                //    Maticsoft.Common.Ajax.WriteError("当前报名批次未结束，不能添加新批次");
                //}
                else
                {
                    BLL.ReceiveRecord.AddAndUpdateCount(model);
                }
            }
            else
            {
                BLL.ReceiveRecord.AddAndUpdateCount(model);
            }

            Model.Company company = new Model.Company();
            company.Id = model.CompanyId;
            company.ReceiveEndTime = model.EndDate;
            company.ReceiveAddress = model.Address;
            company.CurSignUp = 0;
            company.ReceiveTimes = BLL.ReceiveRecord.GetList("CompanyID=" + model.CompanyId + " and Status=1 and AddType=1").Tables[0].Rows.Count-1;

            BLL.Company.Update(company);

            Maticsoft.Common.Ajax.WriteOk("操作成功");
        }


        private void Update()
        {
            string enddate = Request.Form["receiveEndDate"];
            string address = Request.Form["receiveAddress"];


            Model.ReceiveRecord model = new Model.ReceiveRecord();
            model.Id = int.Parse(Request.Form["id"]);
            model.EndDate = DateTime.Parse(Request.Form["receiveEndDate"]);
            model.Address = Request.Form["receiveAddress"];

            if (BLL.ReceiveRecord.Update(model))
            {
                Model.Company company = new Model.Company();
                company.Id = int.Parse(Request.Form["companyid"]);
                company.ReceiveEndTime = model.EndDate;
                company.ReceiveAddress = model.Address;

                BLL.Company.Update(company);

                Maticsoft.Common.Ajax.WriteOk("操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
            
        }

        private void Delete()
        {
            Model.ReceiveRecord model = new Model.ReceiveRecord();
            model.Id = Id;
            model.Status = -1;
            BLL.ReceiveRecord.Update(model);
            Maticsoft.Common.Ajax.WriteOk("操作成功");

        }

        private void SwitchReceiveFunction()
        {
            int status = int.Parse(Request.Form["status"]);
            Model.Company company = new Model.Company();
            company.Id = Id;
            company.IsReceive = status == 1;

            BLL.Company.Update(company);

            Maticsoft.Common.Ajax.WriteOk("操作成功");
        }
    }
}