using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NH.Web.Admin_cssao.Controls
{
    public partial class left : System.Web.UI.UserControl
    {
        protected int isPayment;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserBase.RefreshCurAdmin();
            isPayment = UserBase.CurAdmin.IsPayment;
            if (UserBase.CurAdmin.RoleType == 1)
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
            else
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
        }
    }
}