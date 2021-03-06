﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Person
{
    public partial class PersonWorksForCommend : WebBase.List
    {
        protected string originalfolder = "/Upload/PersonWorks/Original/";
        protected string smallfolder = "/Upload/PersonWorks/Small/";
        protected string bigfolder = "/Upload/PersonWorks/Big/";

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
            string strWhere = "and w.IsCommend=1";
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
                    strWhere += " and w.AddTime >= '" + DateTime.Parse(starttime) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(endtime))
            {
                try
                {
                    strWhere += " and w.AddTime < '" + DateTime.Parse(endtime).AddDays(1) + "'";
                }
                catch { }
            }


            Response.Write(DataUtility.GetListToJson("MemberWorks w(nolock) join Member m(nolock) on w.MemberID=m.Id join [User] u(nolock) on m.Id=u.Id", "w.Id,w.Title,w.ImgSmall,w.ImgBig,w.ImgOriginal,w.AddTime,w.Status,m.Realname,u.LoginName", pagesize, pageindex, "w.Id", strWhere, "order by w.Id", true));
            Response.End();
        }
    }
}