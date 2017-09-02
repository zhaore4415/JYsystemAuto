using System;
using System.Web;
using System.Text;
using System.Data;
using NH.Web.adm;

namespace NH.Web.Handler
{
    public class ResultOrderStatus : IHttpHandler
    {
        public long OrderSN = 0;
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["OrderSN"] != null)
            {
                OrderSN = long.Parse(context.Request.QueryString["OrderSN"]);
                context.Response.ContentType = "text/plain";


                NH.Model.Queryorder model = new NH.Model.Queryorder();
                model.OrderNumber = OrderSN;
                model = NH.BLL.Queryorder.GetModel(model);
                //string jsonStr = GetJson(dt);

                //dt.Rows[0]["Status"].ToString();
                context.Response.Write(model.Status);
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