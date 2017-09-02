using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// SearchKey
    /// </summary>
    public partial class SearchKey
    {
        /// <summary>
        /// 获取最大排序值
        /// </summary>
        /// <returns></returns>
        public static int GetMaxSort(int type)
        {
            return DAL.SearchKey.GetMaxSort(type);
        }

        public static DataTable GetTopSearchKeyByCache()
        {
            string cacheKey = "TopSearchKey";
            object obj = DataCache.GetCache(cacheKey);
            if (obj == null)
            {
                DataTable dt = BLL.SearchKey.GetList(0, "Type=1 and IsShow=1", "Sort").Tables[0];
                obj = dt;
                DataCache.SetCacheByDependency(cacheKey, obj);
            }
            return (DataTable)obj;
        }

        public static DataTable GetHotSearchKeyByCache()
        {
            string cacheKey = "HotSearchKey";
            object obj = DataCache.GetCache(cacheKey);
            if (obj == null)
            {
                DataTable dt = BLL.SearchKey.GetList(0, "Type=2", "Sort").Tables[0];
                obj = dt;
                DataCache.SetCacheByDependency(cacheKey, obj);
            }
            return (DataTable)obj;
        }
    }
}