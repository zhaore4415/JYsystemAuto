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
    public partial class PersonFaceForVerify : WebBase.List
    {
        protected string originalfolder = "/Upload/PersonFace/Original/";
        protected string smallfolder = "/Upload/PersonFace/Small/";

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

            Response.Write(DataUtility.GetListToJson("[User] u(nolock) join Member m(nolock) on u.Id=m.Id", "u.Id,u.LoginName,u.Photo,u.PhotoOriginal,u.PhotoNew,u.UpdateTime,m.Realname,m.Sex", pagesize, pageindex, "u.Id", strWhere, "order by u.UpdateTime", true));
            Response.End();
        }

    }
}