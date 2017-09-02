using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common
{
    public class Js
    {
        /// <summary>
        /// Alert
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string ShowMsg(string msg)
        {
            //返回javascript字符串，其中“\“起到转义字符的作用
            return "<script language=javascript>alert(\"" + msg.Replace("\"", "\\\"") + "\");</script>";
        }

        /// <summary>
        /// 重导向窗口
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Redirect(string url)
        {
            return "<script language=javascript>this.location = \"" + url + "\";</script>";
        }

        public static string ShowAndRedirect(string msg,string url)
        {
            return "<script language=javascript>alert(\"" + msg.Replace("\"", "\\\"") + "\");this.location = \"" + url + "\";</script>";
        }

        public static string WriteJs(string js)
        {
            return "<script language=javascript>" + js + "</script>";
        }
    }
}
