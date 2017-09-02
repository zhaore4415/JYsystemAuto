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
    public partial class PersonAlbumForVerify : WebBase.List
    {
        protected string originalfolder = "/Upload/PersonAlbum/Original/";
        protected string smallfolder = "/Upload/PersonAlbum/Small/";
        protected string bigfolder = "/Upload/PersonAlbum/Big/";
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
                strWhere += " and m.Realname = '" + realname.Replace("'", "''") + "'";
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


            Response.Write(DataUtility.GetListToJson("MemberAlbum a(nolock) join Member m(nolock) on a.MemberID=m.Id join [User] u(nolock) on m.Id=u.Id", "a.Id,a.Title,a.ImgSmall,a.ImgBig,a.ImgOriginal,a.AddTime,m.Realname,u.LoginName", pagesize, pageindex, "a.Id", strWhere, "order by a.Id", true));
            Response.End();
        }
    }
}