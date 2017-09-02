using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NH.Web.Controls
{
    public partial class ShenShiXian : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(ddlBranchOne.SelectedValue);
        }

        public int BranchOneId
        {
            get
            {
                return int.Parse(hiddenBranchOne.Value.ToString());
            }
        }

        public int BranchTwoId
        {
            get
            {
                return int.Parse(hiddenBranchTwo.Value.ToString());
            }
        }

        public int BranchThirdId
        {
            get
            {
                return int.Parse(hiddenBranchThird.Value.ToString());
            }
        }
    }
}