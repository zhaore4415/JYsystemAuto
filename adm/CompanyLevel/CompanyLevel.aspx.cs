using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NH.Web.adm.CompanyLevel
{
    public partial class CompanyLevel : WebBase.List
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
            rptList.DataSource = BLL.CompanyLevel.GetList("Id>1").Tables[0];
            rptList.DataBind();


        }
    }
}