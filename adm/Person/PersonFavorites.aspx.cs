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
    public partial class PersonFavorites : WebBase.List
    {
        protected string _pager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        private void BindList()
        {
            int pagesize = 0;
            int page = RequestHelper.GetPageIndex();
            DataSet ds = DataUtility.GetList("MemberFavorite f(nolock) join Job j(nolock) on f.JobID=j.Id join JobCategory jc(nolock) on j.CategoryNo=jc.CategoryNo join Company c(nolock) on j.CompanyID=c.Id", "f.*,jc.Name JobCategoryName,c.CompanyName", pagesize, page, "j.Id", "and f.MemberID=" + Id, "order by f.Id desc", false);
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
        }
    }
}