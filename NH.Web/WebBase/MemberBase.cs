using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.Common;

namespace NH.Web
{
    public class MemberBase:System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {

            if (!User.IsInRole("Member"))
            {
                if (Request.QueryString["ajax"] == "1")
                {
                    Maticsoft.Common.Ajax.WriteNologin("请登录");
                }
                else
                {
                    Response.Redirect("/template/LoginMemberRedirect.aspx?ReturnUrl=" + Request.RawUrl);
                    //Server.Transfer("/template/Loginredirect.aspx?ReturnUrl=" + Request.RawUrl);
                }
            }
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

        /// <summary>
        /// 获取页面名(不带后缀)
        /// </summary>
        /// <returns></returns>
        protected string PageName
        {
            get
            {
                return System.IO.Path.GetFileNameWithoutExtension(System.Web.HttpContext.Current.Request.Path);
            }
        }

        ///// <summary>
        ///// 检测访问权限
        ///// </summary>
        ///// <returns></returns>
        //protected bool CheckPower()
        //{
        //    return UserBase.CurMember.MemberLevel.AccessModule.ToLower().Contains("," + PageName.ToLower() + ",");
        //}
    }
}