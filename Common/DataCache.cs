using System;
using System.Web;
using System.IO;

namespace Maticsoft.Common
{
	/// <summary>
	/// 缓存相关的操作类
    /// Copyright (C) Maticsoft
	/// </summary>
	public class DataCache
	{
		/// <summary>
		/// 获取当前应用程序指定CacheKey的Cache值
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <returns></returns>
		public static object GetCache(string CacheKey)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			return objCache[CacheKey];
		}

		/// <summary>
		/// 设置当前应用程序指定CacheKey的Cache值
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
		public static void SetCache(string CacheKey, object objObject)
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			objCache.Insert(CacheKey, objObject);
		}

		/// <summary>
		/// 设置当前应用程序指定CacheKey的Cache值
		/// </summary>
		/// <param name="CacheKey"></param>
		/// <param name="objObject"></param>
		public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration,TimeSpan slidingExpiration )
		{
			System.Web.Caching.Cache objCache = HttpRuntime.Cache;
			objCache.Insert(CacheKey, objObject,null,absoluteExpiration,slidingExpiration);
		}

        /// <summary>
        /// 添加文件依赖缓存
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="ObjObject"></param>
        public static void SetCacheByDependency(string CacheKey, object ObjObject)
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory + "/upload/cache";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filepath = folder + "/" + CacheKey + ".txt";
            StreamWriter sw = new StreamWriter(filepath, false);
            sw.Write(DateTime.Now);
            sw.Close();
            System.Web.Caching.CacheDependency d = new System.Web.Caching.CacheDependency(filepath);
            HttpRuntime.Cache.Insert(CacheKey, ObjObject, d);
        }

        public static void RemoveDependencyFile(string cacheKey)
        {
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "/upload/cache/" + cacheKey + ".txt";
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }
	}
}
