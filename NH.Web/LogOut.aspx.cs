using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NH.Web.Login
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserBase.LogOut();
            string url = null;
            switch(Request.QueryString["type"])
            {
                case "adm":
                    url = AUrls.AdminLogin(null);
                    break;
                default :
                    url = Urls.Default();
                    break;
            }
            Response.Redirect(url);
        }
    }
}