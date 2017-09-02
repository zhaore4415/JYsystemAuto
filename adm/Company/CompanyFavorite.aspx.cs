using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Company
{
    public partial class CompanyFavorite : WebBase.List
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

            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];

            string strWhere = "and cf.CompanyID=" + Id.ToString();

            if (!string.IsNullOrEmpty(starttime))
            {
                try
                {
                    strWhere += " and cf.AddTime >= '" + DateTime.Parse(starttime) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(endtime))
            {
                try
                {
                    strWhere += " and cf.AddTime < '" + DateTime.Parse(endtime).AddDays(1) + "'";
                }
                catch { }
            }

            Response.Write(DataUtility.GetListToJson("CompanyFavorite cf(nolock) join Member m(nolock) on cf.MemberID=m.Id", "cf.*,m.Realname,m.JobCategoryName,m.SalaryName,m.JobAddr", pagesize, pageindex, "cf.Id", strWhere, "order by cf.Id desc", true));
            Response.End();
        }
    }
}