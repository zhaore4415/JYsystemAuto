using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Common
{
    public static class Ajax
    {
        public static void WriteNologin(string msg) 
        {
            WriteStatusMsg("nologin",!string.IsNullOrEmpty(msg) ? msg : "请登录");
        }
        public static void WriteNoPower(string msg)
        {
            WriteStatusMsg("nopower", !string.IsNullOrEmpty(msg) ? msg : "没有访问权限");
        }

        public static void WriteError(string msg)
        {
            WriteStatusMsg("error", msg);
        }

        public static void WriteOk(string msg)
        {
            WriteStatusMsg("ok", msg);
        }

        public static void WriteOkAndJsonData(string msg,string jsonData)
        {
            WriteStatusMsgAndJsonData("ok", msg,jsonData);
        }
        public static void WriteStatusMsg(string statusCode, string msg)
        {
            WriteAndEnd("{\"status\":\"" + statusCode + "\",\"msg\":\"" + msg.Replace("\"","\\\"") + "\"}");
        }

        public static void WriteStatusMsgAndJsonData(string statusCode, string msg,string jsonData)
        {
            WriteAndEnd("{\"status\":\"" + statusCode + "\",\"msg\":\"" + msg.Replace("\"", "\\\"") + "\",\"data\":" + jsonData + "}");
        }
        public static void WriteAndEnd(string content)
        {
            Write(content,true);
        }

        public static void Write(string content,bool isEnd)
        {
            System.Web.HttpContext.Current.Response.Write(content);
            if (isEnd)
            {
                System.Web.HttpContext.Current.Response.End();
            }
        }
    }
}
