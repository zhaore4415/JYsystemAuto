using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Maticsoft.Common;

namespace NH.Web
{
    public class AdminBase : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            if (!User.IsInRole("Admin"))
            {
                if (Request.QueryString["ajax"] == "1")
                {
                    Maticsoft.Common.Ajax.WriteNologin("请登录");
                }
                else
                {
                    Response.Redirect("/template/Loginredirect.aspx?ReturnUrl=" + Request.RawUrl);
                    //Server.Transfer("/template/Loginredirect.aspx?ReturnUrl=" + Request.RawUrl);
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
                return @"<script src=""Script/list.js"" type=""text/javascript""></script>";
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
@"<script src=""Script/easyui/jquery.easyui.min.js"" type=""text/javascript""></script>
<link href=""Script/easyui/themes/default/easyui.css"" rel=""stylesheet"" type=""text/css"" />
<link href=""Script/easyui/themes/icon.css"" rel=""stylesheet"" type=""text/css"" />
<script src=""Script/easyui/locale/easyui-lang-zh_CN.js"" type=""text/javascript""></script>";
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
                return System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Path).Replace("View.aspx", "").Replace("Add.aspx", "").Replace("Modify.aspx", "").Replace(".aspx", "");
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
                //if (Request.QueryString["ajax"] == "1")
                //{
                //    Ajax.WriteNoPower("没有此操作权限");
                //}
                //else
                //{
                //    Response.Redirect("template/NoPower.aspx");
                //}
            }
        }
        /// <summary>
        /// 会员等级
        /// </summary>
        /// <param name="RoleType">1为超级管理员，2为一级会员，3为二级会员</param>
        /// <returns></returns>
        protected static string GetVipName(int RoleType)
        {
            //string result = string.Empty;
            if (RoleType == 1)
            { return "超级管理员"; }
            else if (RoleType == 2)
            { return "一级会员"; }
            else if (RoleType == 3)
            { return "二级会员"; }
            else
            {
                return "无";
            }
        }
        /// <summary>
        /// 是否付了定金
        /// </summary>
        /// <param name="RoleType">1已付，0为未付</param>
        /// <returns></returns>
        protected static string GetIsPayment(int IsPayment)
        {
            //string result = string.Empty;
            if (IsPayment == 1)
            { 
                return "已付";
            }
            else if (IsPayment == 0)
            {
                return "<font color='Red'>未付</font>";
            }
            else
            {
                return "未知";
            }
        }
        /// <summary>
        /// 会员等级
        /// </summary>
        /// <param name="RoleType">1为超级管理员，2为一级会员，3为二级会员</param>
        /// <returns></returns>
        protected static string GetShenFenType(int ShenFenType)
        {
            //string result = string.Empty;
            if (ShenFenType == 1)
            { return "微商"; }
            else if (ShenFenType == 2)
            { return "淘宝"; }
            else if (ShenFenType == 3)
            { return "商户"; }
            else if (ShenFenType == 4)
            { return "个体"; }
            else
            {
                return "无";
            }
        }
    }
}