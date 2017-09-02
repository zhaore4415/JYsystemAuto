using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// OnLineService
    /// </summary>
    public partial class OnLineService
    {
        /// <summary>
        /// 获取最大排序值
        /// </summary>
        /// <returns></returns>
        public static int GetMaxSort()
        {
            return DAL.OnLineService.GetMaxSort();
        }


        public static DataTable GetQQByCache()
        {
            string cacheKey = "OnLineService_QQ";
            object obj = DataCache.GetCache(cacheKey);
            if (obj == null)
            {
                DataTable dt = BLL.OnLineService.GetList(0, "AccountType=1", "Sort").Tables[0];
                obj = dt;
                DataCache.SetCacheByDependency(cacheKey, obj);
            }
            return (DataTable)obj;
        }
    }
}