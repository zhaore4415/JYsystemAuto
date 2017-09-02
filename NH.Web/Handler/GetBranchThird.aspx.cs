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

public partial class Handler_GetBranchThird : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null)
        {
            int id = int.Parse(Request["id"].ToString());
            string result = GetBranchThird(id);
            Response.Write(result);
        }
    }

    private string GetBranchThird(int id)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //IList<Config_file_third_kind> branchThirds = BLL.Config_file_third_kindManager.GetConfig_file_third_kindByBranchTwoId(id);
        DataSet branchThirds = NH.BLL.Xian.GetList("sk_id=" + id);
        if (branchThirds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < branchThirds.Tables[0].Rows.Count; i++)
            {
                string json = "{" + string.Format("id:'{0}',name:'{1}'", branchThirds.Tables[0].Rows[i]["tk_id"].ToString(), branchThirds.Tables[0].Rows[i]["Third_kind_name"].ToString()) + "}";
                sb.Append(json);
                if (i != branchThirds.Tables[0].Rows.Count - 1) sb.Append(",");
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
