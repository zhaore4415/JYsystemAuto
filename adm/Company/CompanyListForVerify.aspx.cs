using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.IO;

namespace NH.Web.adm.Company
{
    public partial class CompanyListForVerify : WebBase.List
    {
        protected string _levels = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["action"])
            {
                case "GetList":
                    GetList();
                    break;
                default:
                    Show();
                    break;
            }
        }

        private void Show()
        {
            _levels = BLL.CompanyLevel.BuildLevelOption();
        }

        private void GetList()
        {
            #region
            int pagesize = EasyUI.GetPageSize();//每页显示数量
            int pageindex = EasyUI.GetPageIndex();//页码
            #endregion
            string strWhere = "and (IsVerify=1 or VerifyStatus=0) and u.Status<>-1 ";
            string loginname = Request.Form["loginname"];
            string companyname = Request.Form["companyname"];
            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];
            //string expiredate1 = Request.Form["expiredate1"];
            //string expiredate2 = Request.Form["expiredate2"];
            string level = Request.Form["level"];
            string area = Request.Form["area"];

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
            #region
            //if (!string.IsNullOrEmpty(expiredate1))
            //{
            //    try
            //    {
            //        strWhere += " and c.ExpireDate >= '" + DateTime.Parse(expiredate1) + "'";
            //    }
            //    catch { }
            //}
            //if (!string.IsNullOrEmpty(expiredate2))
            //{
            //    try
            //    {
            //        strWhere += " and c.ExpireDate < '" + DateTime.Parse(expiredate2).AddDays(1) + "'";
            //    }
            //    catch { }
            //}
            #endregion
            if (!string.IsNullOrEmpty(level) && PageValidate.IsNumber(level) && level != "0")
            {
                strWhere += " and c.LevelID=" + level;
            }
            if (!string.IsNullOrEmpty(area) && area != "0")
            {
                strWhere += "and c.AreaID like '" + area.Replace("'", "''") + "%'";
            }
            #endregion

            #region
            /*
            Response.Write(
                DataUtility.GetListToJson(
                "Company c(nolock) join [User] u(nolock) on c.Id=u.Id left join CompanyLevel cl(nolock) on c.LevelID=cl.Id left join CompanyTag ct1(nolock) on ct1.CompanyId=c.Id and ct1.TypeId=1 and ct1.Status=1 left join CompanyTag ct2(nolock) on ct2.CompanyId=c.Id and ct2.TypeId=2 and ct2.Status=1 left join CompanyTag ct3(nolock) on ct3.CompanyId=c.Id and ct3.TypeId=3 and ct3.Status=1 left join CompanyNewInfo n(nolock) on n.Id=c.Id and n.Status=0"
                , "u.Id,u.LoginName,u.AddTime,u.Status,c.CompanyName,c.Contact,c.Area,c.Phone,c.ExpireDate,cl.LevelName,c.VerifyStatus,ct1.Id JinJi,ct2.Id VIP,ct3.Id PinPai,n.Id as nid"
                , pagesize
                , pageindex
                , "u.Id"
                , strWhere
                , "order by u.Id desc"
                , true)
                );
             */
            #endregion

            Response.Write(
                DataUtility.GetListToJson(
                "Company c(nolock) join [User] u(nolock) on c.Id=u.Id left join CompanyLevel cl(nolock) on c.LevelID=cl.Id"
                , "u.Id,u.LoginName,u.AddTime,u.Status,c.CompanyName,c.Contact,c.Area,c.Phone,c.Email,c.ExpireDate,cl.LevelName,c.VerifyStatus,c.IsVerify"
                , pagesize
                , pageindex
                , "u.Id"
                , strWhere
                , "order by u.UpdateTime desc"//"order by u.Id desc"
                , true)
                );
            Response.End();
        }

    }
}