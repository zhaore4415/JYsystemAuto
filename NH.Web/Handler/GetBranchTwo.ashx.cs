using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace NH.Web.Handler
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            if (context.Request["id"] != null)
            {
                int id = int.Parse(context.Request["id"].ToString());
                string result = GetBranchTwo(id);
                context.Response.Write(result);
            }
            else { context.Response.Write("-1"); }
        }
        private string GetBranchTwo(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            DataSet branchTwos = NH.BLL.city.GetList("provinceId=" + id);
            if (branchTwos.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < branchTwos.Tables[0].Rows.Count; i++)
                {
                    string json = "{" + string.Format("id:'{0}',name:'{1}'", branchTwos.Tables[0].Rows[i]["code"].ToString(), branchTwos.Tables[0].Rows[i]["name"].ToString()) + "}";
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}