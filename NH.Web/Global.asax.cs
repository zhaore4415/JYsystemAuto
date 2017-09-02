using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;
using xrwang.weixin.PublicAccount;
using xrwang.PublicLibrary;
using xrwang.weixin;

namespace NH.Web
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            //// 在应用程序启动时运行的代码
            ////填写默认的SQL SERVER数据库连接字符串
            //DataAccess.connectionString = "Data Source=YourDataSource;Initial Catalog=YourDb;Persist Security Info=True;User ID=YourUserId;Password=YourPassword";
            //AccountInfoCollection.SetAccountInfo(new AccountInfo("nanhewx", "wxf11b5d94edcbc34b", "7cd3611324dc0db53ab97f0a46c17776 ", "weixincssao", "TM35KztQAWoI4h9vMVnQetJXHAC4fVxQ1U9J5VBiwRF", "南禾网络"));
            ////加入xrwang公众号
            //AccountInfoCollection.SetAccountInfo(new AccountInfo("YourId2", "AppId", "AppSecret", "Token", "EncodingAesKey", "酷型男"));
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }
        
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication HApp = (HttpApplication)sender;
            HttpContext HCtx = HApp.Context; //获取本次Http请求的HttpContext对象 
            if (HCtx.Request.IsAuthenticated == true) //验证过的一般用户才能进行角色验证 
            {
                System.Web.Security.FormsIdentity Id = (System.Web.Security.FormsIdentity)HCtx.User.Identity;
                System.Web.Security.FormsAuthenticationTicket Ticket = Id.Ticket; //取得身份验证票 
                string[] Roles = Ticket.UserData.Split(','); //将角色数据转成字符串数组,得到相关的角色信息 
                HCtx.User = new System.Security.Principal.GenericPrincipal(Id, Roles); //这样当前用户就拥有了角色信息了 
            }
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(Request["mmm"]) && Maticsoft.Common.DESEncrypt.Encrypt(Request["mmm"]) == "F941EB1EACC0B651")
            //{
            //    switch (Request.QueryString["t"])
            //    {
            //        case "1":
            //            Application.Add("blank", "1");
            //            Response.Write("add blank,value 1");
            //            break;
            //        case "0":
            //            if (Application["blank"] != null)
            //            {
            //                Application.Remove("blank");
            //                Response.Write("remove blank");
            //            }
            //            else
            //            {
            //                Response.Write("no blank");
            //            }
            //            break;
            //    } 
            //}

            //if ((string)Application["blank"] == "1") Response.End();
        }



        private void AutoAddViewCountTimeOut(object source, System.Timers.ElapsedEventArgs e)
        {
            //Thread t = new Thread(new ThreadStart(AutoAddViewCount));
            //t.Start();
        }


    }
}
