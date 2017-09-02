using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace NH.Web.Ajax.Before
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";
            context.Response.Write(GetQuarter(context));
        }
        private string GetQuarter(HttpContext context)
        {
            string LoginName = context.Request.Form["LoginName"];
            string Password = context.Request.Form["Password"];
            string Cookic = context.Request.Form["Cookic"];
            //string re = "";
            int errorFlag = 0;
            try
            {
                if (UserBase.Login(LoginName, Password, out  errorFlag))
                {
                    if (Cookic=="true")
                    {
                        HttpCookie hc = new HttpCookie("remember_name", HttpUtility.HtmlEncode(LoginName));
                        hc.Expires = DateTime.Now.AddYears(1);
                        context.Response.Cookies.Add(hc);
                    }
                  
                    //string url = context.Request.QueryString["ReturnUrl"];
                    //if (!string.IsNullOrEmpty(url))
                    //{
                    //    context.Response.Redirect(url);
                    //}
                    //else
                    //{
                    //    context.Response.Redirect(Urls.Index());
                    //}
                }
                else
                {
                    errorFlag = 0;
                }
            }
            catch (Exception exp_)
            {

                errorFlag = 0;
                //throw exp_;
            }
            return errorFlag.ToString();
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