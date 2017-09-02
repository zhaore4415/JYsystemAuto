using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NH.Web.adm
{
    public partial class MainPage : WebBase.Index
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show();
            }
        }

        private void Show()
        {
            DataSet ds = BLL.Common.GetAdminDefaultMsg();
            lbNewPerson.Text = ds.Tables[0].Rows[0][0].ToString();
            lbNewCompany.Text = ds.Tables[1].Rows[0][0].ToString();
        }

    }
}