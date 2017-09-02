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
    public partial class CompanyJobsForVerify : WebBase.List
    {
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
            string companyname = Request.Form["companyname"];
            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];

            string strWhere = "and j.Status<>-1 and Verified=0";
            if (!string.IsNullOrEmpty(companyname))
            {
                strWhere += " and c.CompanyName like '%" + companyname.Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(starttime))
            {
                try
                {
                    strWhere += " and j.UpdateTime >= '" + DateTime.Parse(starttime) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(endtime))
            {
                try
                {
                    strWhere += " and j.UpdateTime < '" + DateTime.Parse(endtime).AddDays(1) + "'";
                }
                catch { }
            }

            Response.Write(DataUtility.GetListToJson("Job j(nolock) left join JobCategory jc(nolock) on j.CategoryNo=jc.CategoryNo left join Company c(nolock) on c.Id=j.CompanyID", "j.Id,j.UpdateTime,j.RefreshTime,j.AddTime,j.Verified,jc.Name JobCategoryName,c.CompanyName", pagesize, pageindex, "j.Id", strWhere, "order by j.UpdateTime", true));
            Response.End();
        }
    }
}