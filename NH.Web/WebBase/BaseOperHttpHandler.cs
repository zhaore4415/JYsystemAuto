
using NH.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace NH.Web.adm.WebBase
{
    [Obsolete(message: "此类已停止使用，请改用TBaseOperHttpHandler<M>泛型基类！")] 
    public abstract class BaseOperHttpHandler : IHttpHandler, IRequiresSessionState
    {
        protected HttpContext _context;
        protected log4net.ILog log_ = log4net.LogManager.GetLogger(typeof(BaseOperHttpHandler));
        protected Type logInitType
        {
            set
            {
                this.log_ = log4net.LogManager.GetLogger(value);
            }
        }


        protected JavaScriptSerializer serializer = new JavaScriptSerializer();
    
        protected AUser currentUser;
     
        public void ProcessRequest(HttpContext context)
        {
            this._context = context;
            context.Response.ContentType = "text/plain";
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";

            AjaxJsonModel ajaxJson=  null;
            if (context.User.IsInRole("Admin"))
            {
                currentUser = (AUser)context.Session["Admin"];
             
                ajaxJson=  HandlerMethod(context); 
            }
            else
            {
                //3401 - 登录态失效，请重新登陆！
                ajaxJson = new AjaxJsonModel(ResSataus.LoginLose, "3401");
            }

            if (ajaxJson == null)
                ajaxJson = new AjaxJsonModel(ResSataus.Error, "3402");  //参数错误  

            context.Response.Write(serializer.Serialize(ajaxJson));
        }

        /// <summary>
        /// 子类中实现
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected abstract AjaxJsonModel HandlerMethod(HttpContext context);


        public virtual AjaxJsonModel AddMethod()
        {
            return null;
        }
        public virtual AjaxJsonModel UpdateMethod()
        {
            return null;
        }
        public virtual AjaxJsonModel DeleteMethod()
        { 
            return null; 
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