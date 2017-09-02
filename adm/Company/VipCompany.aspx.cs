using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Company
{
    public partial class VipCompany : WebBase.List
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
            _levels = BLL.CompanyLevel.BuildVipLevelOption();
        }

        private void GetList()
        {
            #region
            int pagesize = EasyUI.GetPageSize();//每页显示数量
            int pageindex = EasyUI.GetPageIndex();//页码
            #endregion
            string strWhere = "and LevelID>1 and datediff(day,getdate(),ExpireDate)>=0 and u.Status<>-1";
            string loginname = Request.Form["loginname"];
            string companyname = Request.Form["companyname"];
            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];
            string expiredate1 = Request.Form["expiredate1"];
            string expiredate2 = Request.Form["expiredate2"];
            string level = Request.Form["level"];
            string opentype = Request.Form["opentype"];
            string area = Request.Form["area"];

            #region
            if (!string.IsNullOrEmpty(loginname))
            {
                strWhere += " and u.LoginName = '" + loginname.Replace("'", "''") + "'";
            }
            if (!string.IsNullOrEmpty(companyname))
            {
                strWhere += " and c.CompanyName like '%" + companyname.Replace("'", "''") + "%'";
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
            if (!string.IsNullOrEmpty(expiredate1))
            {
                try
                {
                    strWhere += " and c.ExpireDate >= '" + DateTime.Parse(expiredate1) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(expiredate2))
            {
                try
                {
                    strWhere += " and c.ExpireDate < '" + DateTime.Parse(expiredate2).AddDays(1) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(level) && PageValidate.IsNumber(level) && level != "0")
            {
                strWhere += " and c.LevelID=" + level;
            }
            if (!string.IsNullOrEmpty(opentype) && PageValidate.IsNumber(opentype) && opentype != "0")
            {
                strWhere += " and c.VipOpenType=" + opentype;
            }
            if (!string.IsNullOrEmpty(area) && area != "0")
            {
                strWhere += "and c.AreaID like '" + area.Replace("'", "''") + "%'";
            }
            #endregion


            Response.Write(
                DataUtility.GetListToJson(
                "Company c(nolock) join [User] u(nolock) on c.Id=u.Id left join CompanyLevel cl(nolock) on c.LevelID=cl.Id"
                , "u.Id,u.LoginName,u.AddTime,u.Status,c.CompanyName,c.Contact,c.Area,c.Phone,c.Email,c.ExpireDate,cl.LevelName,c.VerifyStatus"
                , pagesize
                , pageindex
                , "u.Id"
                , strWhere
                , "order by u.Id desc"
                , true)
                );
            Response.End();
        }
    }
}