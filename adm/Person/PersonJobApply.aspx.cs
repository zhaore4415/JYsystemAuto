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
    public partial class PersonJobApply : WebBase.List
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }

        }

        private void BindList()
        {
            int pagesize = 10;
            int page = RequestHelper.GetPageIndex();

            DataSet ds = DataUtility.GetList("JobApply ja(nolock) join Job j(nolock) on ja.JobID=j.Id left join JobCategory jc(nolock) on j.CategoryNo=jc.CategoryNo left join Company c(nolock) on ja.CompanyID=c.Id", "c.CompanyName,ja.Id,ja.CompanyID,ja.AddTime,ja.ReadStatus,ja.IsInvite,j.Id JobId,j.CategoryNo,jc.Name JobCategoryName", pagesize, page, "ja.Id", "and ja.MemberID=" + Id, "order by ja.Id desc", false);
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
        }
    }
}