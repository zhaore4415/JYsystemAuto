using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// EmailConfig
    /// </summary>
    public partial class EmailConfig
    {
        public static DataTable GetListByCache()
        {
            string cacheKey = "EmailConfig";
            object obj = DataCache.GetCache(cacheKey);
            if (obj == null)
            {
                DataTable dt = BLL.EmailConfig.GetList("IsShow=1").Tables[0];
                obj = dt;
                DataCache.SetCacheByDependency(cacheKey, obj);
            }
            return (DataTable)obj;
        }
    }
}