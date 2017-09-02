using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Script.Serialization;
using Maticsoft.Common;

namespace NH.Web.Ajax.Bill
{
    /// <summary>
    /// BillAdd 的摘要说明
    /// </summary>
    public class BillAdd : IHttpHandler
    {

        JavaScriptSerializer serializer = new JavaScriptSerializer();
        public static string str0 = "";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";

            context.Response.Write(GetQuarter(context));
        }
        private string GetQuarter(HttpContext context)
        {
            string action = context.Request["action"];
            string type = context.Request["type"];

            string re = "";
            //json 反序列化


            if (!context.User.IsInRole("Admin"))
            {
                if (context.Request.QueryString["ajax"] == "1")
                {
                    Maticsoft.Common.Ajax.WriteNologin("请登录");
                }
                else
                {
                    context.Response.Redirect("/template/Loginredirect.aspx?ReturnUrl=" + context.Request.RawUrl);
                    //Server.Transfer("/template/Loginredirect.aspx?ReturnUrl=" + Request.RawUrl);
                }
            }
            else
            {


            }
            try
            {
                //BLL.Queryorder bll = new BLL.Queryorder();
                //if (action == "orderNumber")
                //{
                //    int Id = Convert.ToInt32(context.Request.Params["Id"]);
                //    int orderNumber = BLL.User.queryOrderNumber(Id);
                //    if(orderNumber>0)
                //        return orderNumber.ToString();



                //}
                //else if (action == "delete")
                //{
                //    string ids = context.Request.Params["ids"].TrimEnd(',');
                //    if (BLL.Queryorder.DeleteList(ids))
                //    {
                //        re = "1";
                //    }
                //    else
                //    {
                //        re = "0";
                //    }
                //}

            }
            catch (Exception exp_)
            {

                re = "0";
                //throw exp_;
            }
            return re;

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