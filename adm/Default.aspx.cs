using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NH.Web.adm
{
    public partial class Default : WebBase.Index
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["action"]) 
            {
                case "GetMsg":
                    GetMsg();
                    break;
            }
            BindAdType();
        }

        private void BindAdType()
        {
            rptAdType.DataSource = BLL.AdType.GetList(0, "IsShow=1 and AdType=1", "Sort").Tables[0];
            rptAdType.DataBind();
        }


        private void GetMsg()
        {
            string fmt = "{{\"pnv\":\"{0}\",\"cnv\":\"{1}\"}}";

            int pvn = BLL.Member.GetVerifyCount();
            int cvn = BLL.Company.GetVerifyCount();

            string result = string.Format(fmt, pvn,cvn);

            Response.Write(result);
            Response.End();
        }
    }
}