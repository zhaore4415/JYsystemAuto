using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NH.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("AccountNumber"));
                dt.Columns.Add(new DataColumn("AccountName"));
                dt.Columns.Add(new DataColumn("City"));
                dt.Columns.Add(new DataColumn("Country"));
                DataRow dr = dt.NewRow();
                dr["AccountName"] = "Test1";
                dr["AccountNumber"] = "001";
                dr["Country"] = "China";
                dr["City"] = "Beijing";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["AccountName"] = "Test2";
                dr["AccountNumber"] = "002";
                dr["Country"] = "China";
                dr["City"] = "Shanghai";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["AccountName"] = "Test3";
                dr["AccountNumber"] = "003";
                dr["Country"] = "the Nederlands";
                dr["City"] = "Amsterdam";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["AccountName"] = "Test4";
                dr["AccountNumber"] = "004";
                dr["Country"] = "France";
                dr["City"] = "Paris";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["AccountName"] = "Test5";
                dr["AccountNumber"] = "005";
                dr["Country"] = "Spain";
                dr["City"] = "Barcelona";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["AccountName"] = "Test6";
                dr["AccountNumber"] = "006";
                dr["Country"] = "China";
                dr["City"] = "Shanghai";
                dt.Rows.Add(dr);
                Reapeter1.DataSource = dt;
                Reapeter1.DataBind();
            }
        }
    }
}