using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace NH.Web.Handler
{
    /// <summary>
    /// GetBranchThird 的摘要说明
    /// </summary>
    public class GetBranchThird : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            if (context.Request["id"] != null)
            {
                int id = int.Parse(context.Request["id"].ToString());
                string result = GetBranchThirdJson(id);
                context.Response.Write(result);
            }
        }
        private string GetBranchThirdJson(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //IList<Config_file_third_kind> branchThirds = BLL.Config_file_third_kindManager.GetConfig_file_third_kindByBranchTwoId(id);
            DataSet branchThirds = NH.BLL.area.GetList("cityId=" + id);
            if (branchThirds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < branchThirds.Tables[0].Rows.Count; i++)
                {
                    string json = "{" + string.Format("id:'{0}',name:'{1}'", branchThirds.Tables[0].Rows[i]["code"].ToString(), branchThirds.Tables[0].Rows[i]["name"].ToString()) + "}";
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}