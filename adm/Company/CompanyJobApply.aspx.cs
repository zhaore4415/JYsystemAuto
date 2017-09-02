using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Company
{
    public partial class CompanyJobApply : WebBase.List
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

            string strWhere = "and ja.CompanyID=" + Id.ToString();

            if (!string.IsNullOrEmpty(starttime))
            {
                try
                {
                    strWhere += " and ja.AddTime >= '" + DateTime.Parse(starttime) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(endtime))
            {
                try
                {
                    strWhere += " and ja.AddTime < '" + DateTime.Parse(endtime).AddDays(1) + "'";
                }
                catch { }
            }

            Response.Write(DataUtility.GetListToJson("JobApply ja(nolock) left join Job j(nolock) on ja.JobID=j.Id left join JobCategory jc(nolock) on j.CategoryNo=jc.CategoryNo left join Member m(nolock) on ja.MemberID=m.Id", "m.Realname,ja.Id,ja.MemberID,ja.AddTime,ja.ReadStatus,ja.IsInvite,j.Id JobId,j.CategoryNo,jc.Name JobCategoryName", pagesize, pageindex, "ja.Id", strWhere, "order by ja.Id desc", true));
            Response.End();
        }
    }
}