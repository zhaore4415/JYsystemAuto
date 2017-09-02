using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NH.Web.Controls
{
    public partial class Search : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
                ////职位
                //this.ltrJobCategory_search.Text = BLL.JobCategory.BuildOptions("," + Request.QueryString["cid"] + ",");
                //地区
                this.ltrJobAddress_search.Text = BLL.Area.BuildFullAreaOption("," + Request.QueryString["area"] + ",");
                //薪水
                this.ltrSalary.Text = BLL.Salary.BuildOptions(Request.QueryString["salary"]);
            }
        }

        private void BindList()
        {
            //rptList.DataSource = BLL.SearchKey.GetTopSearchKeyByCache();
            //rptList.DataBind();
        }
    }
}