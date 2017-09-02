using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.Common;

namespace NH.Web
{
    /// <summary>
    /// Summary description for VCode
    /// </summary>
    public class VCode : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Maticsoft.Common.ValidateCode.ValidateCodeType s1 = new Maticsoft.Common.ValidateCode.ValidateCode_Style2();
            string code = "6666";
            byte[] bytes = s1.CreateImage(out code);

            HttpCookie cookie = new HttpCookie("vc"+context.Request.QueryString["type"]);
            cookie.Value = Utility.EncryptValidateCode(code.ToLower());

            context.Response.Cookies.Add(cookie);

            context.Response.ContentType = "image/gif";
            context.Response.BinaryWrite(bytes);

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