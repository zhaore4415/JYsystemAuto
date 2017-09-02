using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ECP.Web.Ajax.file
{
    /// <summary>
    /// Open_File_json 的摘要说明   读取指定文件
    /// </summary>
    public class Open_File_json : IHttpHandler
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

            context.Response.ContentType = "text";

            string filePath = context.Request.Params["filePath"];
            if (filePath!=null)
            {
                StreamReader read = File.OpenText(context.Server.MapPath(filePath));
                string value = read.ReadToEnd();
                read.Close();

               // context.Response.Write("{\"result\":\"" + value + "\"}");
                context.Response.Write(value);
            }
            else 
            {
                context.Response.Write("");
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