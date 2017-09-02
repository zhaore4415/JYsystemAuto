using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Maticsoft.Common;

namespace NH.Web.adm.Ajax
{
    /// <summary>
    /// Summary description for List
    /// </summary>
    public class List : IHttpHandler
    {
        HttpRequest Request = HttpContext.Current.Request;
        HttpResponse Response = HttpContext.Current.Response;
        public void ProcessRequest(HttpContext context)
        {
            int pagerows = 0;//每页显示数量
            int pageindex = 1;//页码
            string cols = Request.Form["columns"];//要查询的列名 
            string keys = Request.Form["keys"];//查询参数
            if (!string.IsNullOrEmpty(Request.Form["rows"]))
            {
                if (!int.TryParse(Request.Form["rows"], out pagerows))
                {
                    pagerows = 15;
                }
            }
            else
            {
                pagerows = 15;
            }
            if (!string.IsNullOrEmpty(Request.Form["page"]))
            {
                if (!int.TryParse(Request.Form["page"], out pageindex))
                {
                    pageindex = 1;
                }
            }
            if (string.IsNullOrEmpty(cols))
            {
                cols = "*";
            }
            else if (!Core.Utility.ProcessSqlStr(cols))
            {
                return;
            }
            if (!string.IsNullOrEmpty(keys))
            {
                if (!Core.Utility.ProcessSqlStr(keys))
                {
                    return;
                }
            }
            string strSqlWhere = Core.Utility.DecodeParamsToSql(keys);//将查询参数转成sql
            switch (Request.QueryString["action"])
            {
                case "AUser":
                    Response.Write(DataUtility.GetListToJson("AUser u(nolock) left join UserRole ur(nolock) on ur.UserId=u.Id left join Role r(nolock) on ur.RoleId=r.Id", cols, pagerows, pageindex, "u.Id", strSqlWhere, "", true));
                    break;
                case "Fun":
                    Response.Write(DataUtility.GetListToJson("FunCode fc(nolock) left join FunGroup fg(nolock) on fc.GroupId=fg.Id", cols, pagerows, pageindex, "fc.Id", strSqlWhere, "order by GroupId", true));
                    break;
                case "FunGroup":
                    Response.Write(DataUtility.GetListToJson("FunGroup", cols, pagerows, pageindex, "Id", strSqlWhere, "", true));
                    break;


            }
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