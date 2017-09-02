using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NH.Web
{
    public static class AUrls
    {
        /// <summary>
        /// /Login/AdminLogin.aspx?ReturnUrl=
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public static string AdminLogin(string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return "/Admin_cssao/AdminLogin.aspx?ReturnUrl=" + returnUrl;
            }
            else
            {
                return "/Admin_cssao/AdminLogin.aspx";
            }
        }

        /// <summary>
        /// Default.aspx
        /// </summary>
        /// <returns></returns>
        public static string Default()
        {
            return "Default.aspx";
        }

        /// <summary>
        /// Main.aspx
        /// </summary>
        /// <returns></returns>
        public static string MainPage()
        {
            return "Main.aspx";
        }

        /// <summary>
        /// ChangePwd.aspx
        /// </summary>
        /// <returns></returns>
        public static string ChangePwd()
        {
            return "system/ChangePwd.aspx";
        }
    }
}