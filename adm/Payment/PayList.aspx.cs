using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Payment
{
    public partial class PayList : WebBase.List
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
            string strWhere = "and o.[Status]=1";
            string loginname = Request.Form["loginname"];
            string companyname = Request.Form["companyname"];
            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];
            string level = Request.Form["level"];

            #region
            if (!string.IsNullOrEmpty(loginname))
            {
                strWhere += " and o.LoginName = '" + loginname.Replace("'", "''") + "'";
            }
            if (!string.IsNullOrEmpty(companyname))
            {
                strWhere += " and c.CompanyName like '%" + companyname.Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(starttime))
            {
                try
                {
                    strWhere += " and o.TradeTime >= '" + DateTime.Parse(starttime) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(endtime))
            {
                try
                {
                    strWhere += " and o.TradeTime < '" + DateTime.Parse(endtime).AddDays(1) + "'";
                }
                catch { }
            }

            if (!string.IsNullOrEmpty(level) && PageValidate.IsNumber(level) && level != "0")
            {
                strWhere += " and o.LevelID=" + level;
            }

            #endregion


            Response.Write(
                DataUtility.GetListToJson(
                "OnlinePayOrder o(nolock) left join Company c(nolock) on o.CompanyID=c.Id"
                , "c.CompanyName,o.LoginName,o.TradeNo,o.TradeTime,o.OrderDesc"
                , pagesize
                , pageindex
                , "o.Id"
                , strWhere
                , "order by o.TradeTime desc"
                , true)
                );
            Response.End();
        }

    }
}