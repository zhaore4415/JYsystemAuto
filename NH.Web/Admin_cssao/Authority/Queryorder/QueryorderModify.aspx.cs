using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NH.Web.Authority.Queryorder
{
    public partial class QueryorderModify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(Request.QueryString["ids"]);
            //string s = Request.QueryString["ids"];// hidids.Value;
            //if (!IsPostBack)
                show();
        }

        private void show()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ids"]))
            {
                int id = Convert.ToInt32(Request.QueryString["ids"]);
                hid_ID.Value = Request.QueryString["ids"];
                Model.Queryorder mod = BLL.Queryorder.GetModel(id);

                Model.User user = BLL.User.GetModel(mod.U_ID.Value);
                txtLoginName.Value = user.LoginName;
                txtOrderNumber.Value = mod.OrderNumber.ToString();
                txtProducts.Value= mod.Products;
                txtBabynumbers.Value = mod.Babynumbers;
                txtAmounts.Value = mod.Amounts;
                txtDeliveryTime.Value = mod.DeliveryTime.ToString();
            }
        }
    }
}