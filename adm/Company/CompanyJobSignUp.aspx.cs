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
    public partial class CompanyJobSignUp : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request["action"])
            {
                case "GetList":
                    GetList();
                    break;
                //case "Add":
                //    AddReceive();
                //    break;
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

            string strWhere = "and CompanyID=" + Id.ToString();

            string name = Request.Form["name"];
            string mobile = Request.Form["mobile"];
            string iscontacted = Request.Form["iscontacted"];
            string isintent = Request.Form["isintent"];
            string status = Request.Form["status"];
            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];

            if (!string.IsNullOrEmpty(name))
            {
                strWhere += " and su.Name = '" + name.Trim().Replace("'","''") + "'";
            }
            if (!string.IsNullOrEmpty(mobile))
            {
                strWhere += " and su.Mobile = '" + mobile.Trim().Replace("'", "''") + "'";
            }
            if (!string.IsNullOrEmpty(iscontacted))
            {
                strWhere += " and suc.IsContacted=" + iscontacted.Replace("'","''");
            }
            if (isintent == "1")
            {
                strWhere += " and suc.IsIntent=1";
            }
            if (!string.IsNullOrEmpty(status))
            {
                strWhere += " and suc.UserStatus=" + status.Replace("'","''");
            }
            if (!string.IsNullOrEmpty(starttime) && Maticsoft.Common.PageValidate.IsDateTime(starttime))
            {
                strWhere += " and suc.AddTime >= '" + starttime + "'";
            }
            if (!string.IsNullOrEmpty(endtime) && Maticsoft.Common.PageValidate.IsDateTime(endtime))
            {
                strWhere += " and suc.AddTime <= '" + DateTime.Parse(endtime).AddDays(1).ToString("yyyy-MM-dd") + "'";
            }

            Response.Write(DataUtility.GetListToJson("SignUp2Company suc(nolock) left join SignUp su(nolock) on suc.SignUpID=su.Id", "suc.Id,suc.IsContacted,suc.IsIntent,suc.UserStatus,suc.IsReIntroduce,suc.AddTime,suc.SignUpID,suc.BelongUserName,su.Mobile,su.Name,su.Sex,su.Born,su.DegreeName", pagesize, pageindex, "suc.Id", strWhere, "order by suc.Id desc", true));
            Response.End();
        }
    }
}