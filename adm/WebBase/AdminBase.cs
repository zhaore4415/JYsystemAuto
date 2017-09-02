using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Maticsoft.Common;

namespace NH.Web
{
    public class AdminBase:System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            if (!User.IsInRole("Admin"))
            {
                if (Request.QueryString["ajax"] == "1")
                {
                    Ajax.WriteNologin("请登录");
                }
                else
                {
                    //Response.Redirect("/adm/template/Loginredirect.aspx?ReturnUrl=" + Request.RawUrl);
                    Server.Transfer("/adm/template/Loginredirect.aspx?ReturnUrl=" + Request.RawUrl);
                }
            }
            base.OnPreInit(e);
        }

        protected static string HtmlEncode(string str)
        {
            return str == null ? null : HttpUtility.HtmlEncode(str);
        }

        private string _cssAndScript;
        protected string CssAndScript
        {
            set { _cssAndScript = value; }
            get 
            {
                return _cssAndScript;
            }
        }

        protected static string ListScript
        {
            get 
            {
                return @"<script src=""/adm/Script/list.js"" type=""text/javascript""></script>";
            }
        }

        protected static string JsTextBoxClass
        {
            get
            {
                return @"<script type=""text/javascript"">$(document).ready(function () { $('input[type=text],input[type=password],textarea').addClass('txtCls'); })</script>";
            }
        }

        protected static string EasyUI_CssAndScript
        {
            get 
            {
                return 
@"<script src=""/adm/Script/easyui/jquery.easyui.min.js"" type=""text/javascript""></script>
<link href=""/adm/Script/easyui/themes/default/easyui.css"" rel=""stylesheet"" type=""text/css"" />
<link href=""/adm/Script/easyui/themes/icon.css"" rel=""stylesheet"" type=""text/css"" />
<script src=""/adm/Script/easyui/locale/easyui-lang-zh_CN.js"" type=""text/javascript""></script>";
            }
        }

        /*
        protected static string AjaxConfig
        {
            get
            {
                return @"
<script type=""text/javascript"">
        $(document).ajaxStart(function () {
            //$.blockUI({ css: { padding: 20, width: 300 }, message: '正在提交...' });
        }).ajaxSend(function (e, jqxhr, settings) {
            if (/(\?|&)ajax=/.test(settings.url) == false) {
                if (settings.url.indexOf('?') == -1) {
                    settings.url += '?ajax=1';
                } else {
                    settings.url += '&ajax=1';
                }
            };
        });
        $.ajaxSetup({ type:'post',dataType: 'json' });
</script>";
            }
        }
        */

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

        /// <summary>
        /// List页面名称，不带后缀
        /// </summary>
        protected string ListName
        {
            get
            {
                return System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Path).Replace("Add.aspx", "").Replace("Modify.aspx", "").Replace(".aspx",""); 
            }
        }

        /// <summary>
        /// List页面url,带后缀
        /// </summary>
        protected string ListUrl
        {
            get 
            {
                return ListName + ".aspx";
            }
        }

        protected int Id
        {
            get
            {
                return int.Parse(Request.QueryString["id"]);
            }
        }

        /// <summary>
        /// 检测权限
        /// </summary>
        /// <param name="funCode">功能码</param>
        /// <returns></returns>
        protected bool IsPower(string funCode)
        {
            if (UserBase.CurAdmin.RoleType == 1) return true;

            bool result = false;
            DataTable dtUserFunCode = BLL.AUser.GetUserFunCode(UserBase.CurAdmin.Id);
            foreach (DataRow row in dtUserFunCode.Rows)
            {
                if (row["Code"].ToString().ToLower() == funCode.ToLower())
                {
                    result = true;
                }
            }
            return result;
        }

        protected void CheckPowerAndRedirect(string funCode)
        {
            if (!IsPower(funCode))
            {
                if (Request.QueryString["ajax"] == "1")
                {
                    Ajax.WriteNoPower("没有此操作权限");
                }
                else
                {
                    Response.Redirect("/adm/template/NoPower.aspx");
                }
            }
        }

    }
}