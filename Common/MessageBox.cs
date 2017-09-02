using System;
using System.Text;
namespace Maticsoft.Common
{
	/// <summary>
	/// 显示消息提示对话框。
    /// Copyright (C) Maticsoft
	/// </summary>
	public class MessageBox
	{		
		private  MessageBox()
		{			
		}

		/// <summary>
		/// 显示消息提示对话框
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		public static void  Show(string msg)
		{
            System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script type=\"text/javascript\">alert(\"" + msg.Replace("\"", "\\\"") + "\");</script>");
		}

        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        public static void CloseWindow()
        {
            System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script type=\"text/javascript\">window.self.close();</script>"); 
        }
        

        /// <summary>
		/// 打开新窗口
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="url">跳转的目标URL</param>
		public static void ShowNewsWin(string url)
        {
            System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script type=\"text/javascript\">javascript:openwindowa(\"" + url + "\");</script>");


		}
        /// <summary>
        /// 单击指定页面的按钮。
        /// </summary>
        /// <param name="objPage">对话框的所在页面ID</param>
        /// window.opener.form1.btngc.click();刷新父页面 btngc 按钮
        public static void Alert_CloseFormshaoma(System.Web.UI.Page objPage)
        {
            objPage.ClientScript.RegisterStartupScript(objPage.GetType(), "alert", "<script language=javascript>window.opener.formshaoma.Button1.click();</script>");
        }
		/// <summary>
		/// 控件点击 消息确认提示框
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		public static void  ShowConfirm(System.Web.UI.WebControls.WebControl Control,string msg)
		{
            Control.Attributes.Add("onclick", "if (!window.confirm('" + msg + "')){return false;}");
            //Control.Attributes.Add("onclick", "javascript:if(confirm('确定要删除吗?')){}else{return false;}");
		}

		/// <summary>
		/// 显示消息提示对话框，并进行页面跳转
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		/// <param name="url">跳转的目标URL</param>
		public static void ShowAndRedirect(string msg,string url)
        {
            System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script type=\"text/javascript\">alert(\"" + msg.Replace("\"", "\\\"") + "\");window.location=\"" + url + "\"</script>");


		}
        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirects(string msg, string url)
        {
            System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script type=\"text/javascript\">");
            Builder.AppendFormat("alert(\"{0}\");", msg.Replace("\"", "\\\""));
            Builder.AppendFormat("top.location.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }
        /// <summary>
        /// 在客户端弹出对话框,单击确定后并关闭自身。
        /// </summary>
        /// <param name="MsgStr">对话框的文本信息</param>
        /// <param name="objPage">对话框的所在页面ID</param>
        /// window.opener.form1.btngc.click();刷新父页面 btngc 按钮
        public static void Alert_CloseSelf(string MsgStr, System.Web.UI.Page objPage)
        {
            objPage.ClientScript.RegisterStartupScript(objPage.GetType(), "alert", "<script language=javascript>alert('" + MsgStr.ToString().Replace("'", "").Replace("\r\n", "") + "');window.opener.form1.btngc.click();</script>");
        }

        /// <summary>
        /// 在客户端弹出对话框,单击确定后并关闭自身。
        /// </summary>
        /// <param name="MsgStr">对话框的文本信息</param>
        /// <param name="objPage">对话框的所在页面ID</param>
        /// window.opener.location.reload()刷新父页面
        public static void Alert_ClosePage(string MsgStr, System.Web.UI.Page objPage)
        {
            objPage.ClientScript.RegisterStartupScript(objPage.GetType(), "alert", "<script language=javascript>alert('" + MsgStr.ToString().Replace("'", "").Replace("\r\n", "") + "');window.self.close();window.opener.location.reload();</script>");
        }

        /// <summary>
        /// 在客户端弹出对话框,单击确定后不关闭自身。
        /// </summary>
        /// <param name="MsgStr">对话框的文本信息</param>
        /// <param name="objPage">对话框的所在页面ID</param>
        /// window.opener.location.reload()刷新父页面
        public static void Alert_HoldingPage(string MsgStr, System.Web.UI.Page objPage)
        {
            objPage.ClientScript.RegisterStartupScript(objPage.GetType(), "alert", "<script language=javascript>alert('" + MsgStr.ToString().Replace("'", "").Replace("\r\n", "") + "');window.opener.location.reload();</script>");
        }
        /// <summary>
        /// 在客户端弹出对话框,单击确定后并关闭自身(div)。
        /// </summary>
        /// <param name="MsgStr">对话框的文本信息</param>
        /// <param name="objPage">对话框的所在页面ID</param>
        /// window.opener.location.reload()刷新父页面
        public static void Alert_Closediv(string MsgStr, System.Web.UI.Page objPage)
        {
            objPage.ClientScript.RegisterStartupScript(objPage.GetType(), "alert", "<script language=javascript>alert('" + MsgStr.ToString().Replace("'", "").Replace("\r\n", "") + "');document.getElementById('shoufei').style.display='none';window.opener.location.reload();</script>");
        }
        //document.getElementById('shoufei').style.display='none'
		/// <summary>
		/// 输出自定义脚本信息
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="script">输出脚本</param>
		public static void ResponseScript(System.Web.UI.Page page,string script)
		{
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script type=\"text/javascript\">" + script + "</script>");
             
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="js"></param>
        /// <returns></returns>
        public static string WriteJs(string js)
        {
            return "<script language=javascript>" + js + "</script>";
        }

        /// <summary>
        /// 返回跳转到当前地址 window.location.href = window.location.href
        /// </summary>
        public static string jsRedirectSelf = "window.location.href = window.location.href";

        public static void JAlert(string msg,string jsCode)
        {
            System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script type=\"text/javascript\">$(document).ready(function () {jAlert(\"" + msg.Replace("\"", "\\\"") + "\",\"\",function(){" + jsCode + "});})</script>");
        }
      
        public static void JAlertOk(string msg, string jsCode)
        {
            System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script type=\"text/javascript\">$(document).ready(function () {jAlertOk(\"" + msg.Replace("\"", "\\\"") + "\",\"\",function(){" + jsCode + "});})</script>");
        }

        public static void JAlertError(string msg, string jsCode)
        {
            System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script type=\"text/javascript\">$(document).ready(function () {jAlertError(\"" + msg.Replace("\"", "\\\"") + "\",\"\",function(){" + jsCode + "});})</script>");
        }
	}
}
