using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NH.Web.adm
{
    public static class EasyUI
    {
        /// <summary>
        /// 获取每页显示数量
        /// </summary>
        /// <returns></returns>
        public static int GetPageSize()
        {
            int pagesize = 10;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["rows"]))
            {
                if (!int.TryParse(HttpContext.Current.Request.Form["rows"], out pagesize))
                {
                    pagesize = 10;
                }
            }
            return pagesize;
        }

        /// <summary>
        /// 获取页码
        /// </summary>
        /// <returns></returns>
        public static int GetPageIndex()
        {
            int pageindex = 1;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["page"]))
            {
                if (!int.TryParse(HttpContext.Current.Request.Form["page"], out pageindex))
                {
                    pageindex = 1;
                }
            }
            return pageindex;
        }
    }
}