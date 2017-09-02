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
    public partial class CompanyFaceForVerify : WebBase.List
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
            int pagesize = EasyUI.GetPageSize();//每页显示数量
            int pageindex = EasyUI.GetPageIndex();//页码

            string strWhere = "and u.PhotoVerifyStatus=0 and PhotoNew is not null and PhotoNew <> ''";
            string loginname = Request.Form["loginname"];
            string realname = Request.Form["realname"];

            if (!string.IsNullOrEmpty(loginname))
            {
                strWhere += " and u.LoginName = '" + loginname.Replace("'", "''") + "'";
            }
            if (!string.IsNullOrEmpty(realname))
            {
                strWhere += " and m.Realname = '" + realname.Replace("'", "''") + "'";
            }

            Response.Write(DataUtility.GetListToJson("[User] u(nolock) join Company c(nolock) on u.Id=c.Id", "u.Id,u.LoginName,u.Photo,u.PhotoOriginal,u.PhotoNew,u.UpdateTime,c.CompanyName", pagesize, pageindex, "u.Id", strWhere, "order by u.UpdateTime", true));
            Response.End();
        }
    }
}