using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.Common;

namespace NH.Web
{
    public class PersonBase : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
          

            /*
            if (!UserBase.IsUserOnline)
            {
                Response.Redirect(Urls.LogOutTip());
            }*/

            UserBase.RefreshCurMember();
            //if (!UserBase.CurMember.IsBaseInfoOk)
            //{
            //    Response.Redirect(Urls.PersonReg2());
            //}
            base.OnPreInit(e);
        }

        protected static string HtmlEncode(string str)
        {
            return str == null ? null : HttpUtility.HtmlEncode(str);
        }

        protected static string ListScript
        {
            get
            {
                return @"<script src=""/Scripts/list.js"" type=""text/javascript""></script>";
            }
        }
    }
}