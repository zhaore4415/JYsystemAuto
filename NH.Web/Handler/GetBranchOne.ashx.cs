using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace NH.Web.Handler
{
    /// <summary>
    /// GetBranchOne 的摘要说明
    /// </summary>
    public class GetBranchOne : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string result = GetBranchOneJson();
            context.Response.Write(result);
        }

        private string GetBranchOneJson()
        {
            DataSet branchones = NH.BLL.province.GetList(0, "", "[code] desc");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < branchones.Tables[0].Rows.Count; i++)
            {
                string json = "{" + string.Format("id:'{0}',name:'{1}'", branchones.Tables[0].Rows[i]["code"].ToString(), branchones.Tables[0].Rows[i]["name"].ToString()) + "}";
                sb.Append(json);
                if (i != branchones.Tables[0].Rows.Count - 1) sb.Append(",");
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