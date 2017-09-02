using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ECP.Web.Ajax.file
{
    /// <summary>
    /// Oper_File_Write_Read_json 的摘要说明   没用过
    /// </summary>
    public class Oper_File_Write_Read_json : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            context.Response.ContentType = "text/plain";
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";

            context.Response.ContentType = "text/json";
            try
            {
                string action = context.Request.Params["action"];
                if (action == "write")
                {
                    string code = context.Request.Params["code"];
                    string filePath = context.Request.Params["filePath"];
                    StreamWriter sw = new StreamWriter(context.Server.MapPath(filePath));

                    sw.Write(code);
                    sw.Close();

                    context.Response.Write("{\"result\":\"1\"}");

                }
            }catch(Exception ex)
            {
                context.Response.Write("{\"result\":\"0\"}"); 
            }
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