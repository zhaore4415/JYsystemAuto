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

public partial class Handler_GetBranchTwo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null)
        {
            int id = int.Parse(Request["id"].ToString());
            string result = GetBranchTwo(id);
            Response.Write(result);
        }
        else { Response.Write("-1"); }

    }

    private string GetBranchTwo(int id)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        DataSet branchTwos = NH.BLL.Shi.GetList("fk_id=" + id);
        if (branchTwos.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < branchTwos.Tables[0].Rows.Count; i++)
            {
                string json = "{" + string.Format("id:'{0}',name:'{1}'", branchTwos.Tables[0].Rows[i]["sk_id"].ToString(), branchTwos.Tables[0].Rows[i]["Second_kind_name"].ToString()) + "}";
                sb.Append(json);
                if (i != branchTwos.Tables[0].Rows.Count - 1) sb.Append(",");
            }
        }
        else
        {
            string json = "{" + string.Format("id:'{0}',name:'{1}'", "-1", "请选择") + "}";
            sb.Append(json);
        }

        return "[" + sb.ToString() + "]";
    }
}
