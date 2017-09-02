using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Article
{
    public partial class SolutionCategory : WebBase.Edit
    {
        protected string _pager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("InfomationManage");
            if (!IsPostBack)
            {
                BindList();
            }
        }

        private void BindList()
        {
            int pagesize = 10;
            int page = RequestHelper.GetPageIndex();

            DataSet ds = BLL.ArticleCategory.GetList(pagesize, page, "and Type=6", "order by ac.Sort asc");
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
            int count = (int)ds.Tables[1].Rows[0][0];

            _pager = new Pager(pagesize, count).Create();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string strids = Request.Form["chkItem"];
            if (!string.IsNullOrEmpty(strids))
            {
                BLL.ArticleCategory.DeleteList(strids);
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}