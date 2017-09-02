using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

public partial class Handler_GetBranchOne : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string result = GetBranchOneJson();
        Response.Write(result);
    }

    private string GetBranchOneJson()
    {
        DataSet branchones = NH.BLL.Shen.GetList(0,"","fk_id desc");
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < branchones.Tables[0].Rows.Count; i++)
        {
            string json = "{" + string.Format("id:'{0}',name:'{1}'", branchones.Tables[0].Rows[i]["fk_id"].ToString(), branchones.Tables[0].Rows[i]["First_kind_name"].ToString()) + "}";
            sb.Append(json);
            if (i != branchones.Tables[0].Rows.Count - 1) sb.Append(",");
        }
        return "[" + sb.ToString() + "]";
    }
}
