using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NH.Web.Handler
{
    /// <summary>
    /// OrderCancel 的摘要说明
    /// </summary>
    public class OrderCancel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //把订单状态改为2
            if (context.Request.QueryString["OrderSN"] != null)
            {
                if (NH.BLL.Queryorder.UpdateOrder(new NH.Model.Queryorder { OrderNumber = long.Parse(context.Request.QueryString["OrderSN"]), Status = "2" })) {
                    context.Response.Write("<script>alert('取消订单成功');window.location=\"../Member/Queryorder.aspx\"</script>");
                  
                    //MessageBox.ShowAndRedirect("取消订单成功", "Queryorder.aspx");
                }
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