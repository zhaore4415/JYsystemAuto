using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.ReceiveRecord
{
    public partial class ReceiveRecord : WebBase.List
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["action"])
            {
                case "GetList":
                    GetList();
                    break;
            }
        }

        private void GetList()
        {
            #region
            int pagesize = EasyUI.GetPageSize();//每页显示数量
            int pageindex = EasyUI.GetPageIndex();//页码
            #endregion
            string strWhere = "and rr.Status<>-1 and AddType=1";
            string loginname = Request.Form["loginname"];
            string companyname = Request.Form["companyname"];
            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];
            //string expiredate1 = Request.Form["expiredate1"];
            //string expiredate2 = Request.Form["expiredate2"];
            //string level = Request.Form["level"];
            //string area = Request.Form["area"];

            #region
            if (!string.IsNullOrEmpty(loginname))
            {
                strWhere += " and u.LoginName like '%" + loginname.Trim().Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(companyname))
            {
                strWhere += " and c.CompanyName like '%" + companyname.Trim().Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(starttime))
            {
                try
                {
                    strWhere += " and rr.EndDate >= '" + DateTime.Parse(starttime) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(endtime))
            {
                try
                {
                    strWhere += " and rr.EndDate < '" + DateTime.Parse(endtime).AddDays(1) + "'";
                }
                catch { }
            }
            
            #endregion
            #region
            #endregion
            Response.Write(
                DataUtility.GetListToJson(
                "ReceiveRecord rr(nolock) left join Company c(nolock) on rr.CompanyId=c.Id left join [User] u(nolock) on c.Id=u.Id"
                , "u.Id,u.LoginName,u.Status,c.CompanyName,rr.EndDate,rr.AddTime,rr.Times"
                , pagesize
                , pageindex
                , "u.Id"
                , strWhere
                , "order by rr.EndDate desc"
                , true)
                );
            Response.End();
        }
    }
}