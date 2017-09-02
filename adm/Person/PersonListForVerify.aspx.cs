using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Person
{
    public partial class PersonListForVerify : WebBase.List
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
            int pagesize = EasyUI.GetPageSize();//每页显示数量
            int pageindex = EasyUI.GetPageIndex();//页码
            #endregion
            string strWhere = "and (IsVerify = 1 or VerifyStatus=0) and u.Status<>-1";
            string loginname = Request.Form["loginname"];
            string realname = Request.Form["realname"];
            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];

            if (!string.IsNullOrEmpty(loginname))
            {
                strWhere += " and u.LoginName like '%" + loginname.Trim().Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(realname))
            {
                strWhere += " and m.Realname like '%" + realname.Trim().Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(starttime))
            {
                try
                {
                    strWhere += " and u.AddTime >= '" + DateTime.Parse(starttime) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(endtime))
            {
                try
                {
                    strWhere += " and u.AddTime < '" + DateTime.Parse(endtime).AddDays(1) + "'";
                }
                catch { }
            }


            Response.Write(DataUtility.GetListToJson(
                "Member m(nolock) left join [User] u(nolock) on m.Id=u.Id"
                , "u.Id,u.LoginName,u.AddTime,u.Status,m.Realname,m.Mobile,m.Phone,m.Email,m.JobCategoryName,m.CurAddr"
                , pagesize
                , pageindex
                , "u.Id"
                , strWhere
                , "order by u.UpdateTime desc" //"order by u.Id desc"
                , true)
                );
            Response.End();
        }
    }
}