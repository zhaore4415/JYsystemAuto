using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NH.Web.adm.Company
{
    public partial class CompanyReceiveAdd : WebBase.Edit
    {
        public Model.ReceiveRecord model;
        public int maxtimes = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] == "Update")
            {
                model = BLL.ReceiveRecord.GetModel(Id);
                maxtimes = model.Times;
            }
            else
            {
                maxtimes = BLL.ReceiveRecord.GetMaxTimes(int.Parse(Request.QueryString["companyid"]));
            }
        }
    }
}