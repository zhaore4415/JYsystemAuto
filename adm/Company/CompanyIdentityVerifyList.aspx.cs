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
    public partial class CompanyIdentityVerifyList : WebBase.List
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["action"])
            {
                case "GetList":
                    GetList();
                    break;
                default:
                    break;
            }
        }

        private void GetList()
        {
            #region
            int pagesize = 0;//每页显示数量
            int pageindex = 1;//页码
            if (!string.IsNullOrEmpty(Request.Form["rows"]))
            {
                if (!int.TryParse(Request.Form["rows"], out pagesize))
                {
                    pagesize = 10;
                }
            }
            else
            {
                pagesize = 10;
            }
            if (!string.IsNullOrEmpty(Request.Form["page"]))
            {
                if (!int.TryParse(Request.Form["page"], out pageindex))
                {
                    pageindex = 1;
                }
            }
            #endregion
            string strWhere = "and v.Status=0";
            string loginname = Request.Form["loginname"];
            string realname = Request.Form["realname"];
            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];

            if (!string.IsNullOrEmpty(loginname))
            {
                strWhere += " and u.LoginName = '" + loginname.Replace("'", "''") + "'";
            }
            if (!string.IsNullOrEmpty(realname))
            {
                strWhere += " and c.CompanyName like '%" + realname.Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(starttime))
            {
                try
                {
                    strWhere += " and v.AddTime >= '" + DateTime.Parse(starttime) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(endtime))
            {
                try
                {
                    strWhere += " and v.AddTime < '" + DateTime.Parse(endtime).AddDays(1) + "'";
                }
                catch { }
            }


            Response.Write(DataUtility.GetListToJson("CompanyVerify v(nolock) join Company c(nolock) on v.CompanyID=c.Id join [User] u(nolock) on c.Id=u.Id", "v.Id,v.LicenceNo,v.ExpireDate,v.Contact,v.Tel,v.AddTime,c.CompanyName,u.LoginName,u.Id as CompanyID", pagesize, pageindex, "v.Id", strWhere, "order by v.Id", true));
            Response.End();
        }
    }
}