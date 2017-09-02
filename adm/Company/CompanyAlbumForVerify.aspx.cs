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
    public partial class CompanyAlbumForVerify : WebBase.List
    {
        protected string originalfolder = "/Upload/CompanyAlbum/Original/";
        protected string smallfolder = "/Upload/CompanyAlbum/Small/";
        protected string bigfolder = "/Upload/CompanyAlbum/Big/";

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
            string strWhere = "and a.Status=0";
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
                    strWhere += " and a.AddTime >= '" + DateTime.Parse(starttime) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(endtime))
            {
                try
                {
                    strWhere += " and a.AddTime < '" + DateTime.Parse(endtime).AddDays(1) + "'";
                }
                catch { }
            }


            Response.Write(DataUtility.GetListToJson("CompanyAlbum a(nolock) join Company c(nolock) on a.CompanyID=c.Id join [User] u(nolock) on c.Id=u.Id", "a.Id,a.Title,a.ImgSmall,a.ImgBig,a.ImgOriginal,a.AddTime,c.CompanyName,u.LoginName", pagesize, pageindex, "a.Id", strWhere, "order by a.Id", true));
            Response.End();
        }
    }
}