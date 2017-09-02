using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Config
    /// </summary>
    public partial class Config
    {
        public static Model.Config GetModelByCache()
        {
            string cacheKey = "Config";
            object obj = DataCache.GetCache(cacheKey);
            if (obj == null)
            {
                Model.Config model = BLL.Config.GetModel(1);
                obj = model;
                DataCache.SetCacheByDependency(cacheKey, obj);
            }
            return (Model.Config)obj;
        }
    }
}