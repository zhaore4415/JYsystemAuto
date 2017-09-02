using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// AdType
    /// </summary>
    public partial class AdType
    {

        /// <summary>
        /// 从缓存中取，文件依赖缓存
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Model.AdType GetModelByCache2(int id)
        {
            string cacheKey = "Model-AdType-" + id.ToString();
            object obj = DataCache.GetCache(cacheKey);
            if (obj == null)
            {
                Model.AdType model = GetModel(id);
                obj = model;
                DataCache.SetCacheByDependency(cacheKey, obj);
            }
            return (Model.AdType)obj;
        }
    }
}