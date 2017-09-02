using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Memcached.ClientLibrary;
using System.Collections;

namespace NH.Web.WebBase
{
    public abstract class MemberHelper
    { 
        #region 创建Memcache服务
        /// <summary>
        /// 创建Memcache服务
        /// </summary>
        /// <param name="serverlist">IP端口列表</param>
        /// <param name="poolName">Socket连接池名称</param>
        /// <returns>Memcache客户端代理类</returns>
        public static MemcachedClient CreateServer(ArrayList serverlist, string poolName)
        {
            //初始化memcache服务器池
            SockIOPool pool = SockIOPool.GetInstance(poolName);
            //设置Memcache池连接点服务器端。
            pool.SetServers(serverlist);
            pool.SetWeights(new int[] { 1, 10 });
            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 5;
            pool.SocketConnectTimeout = 1000;//socket连接的超时时间必须设置
            pool.SocketTimeout = 3000;
            pool.MaintenanceSleep = 30;
            pool.Failover = true;
            //是否对TCP/IP通讯使用nalgle算法，.net版本没有实现
            pool.Nagle = false;
            //socket单次任务的最大时间（单位ms），超过这个时间socket会被强行中端掉，当前任务失败。
            pool.MaxBusy = 1000 * 10;
            pool.Initialize();
            //其他参数根据需要进行配置 

            //创建了一个Memcache客户端的代理类。
            MemcachedClient mc = new Memcached.ClientLibrary.MemcachedClient();
            //MemcachedClient mc = new MemcachedClient();
            mc.PoolName = poolName;
            mc.EnableCompression = false;//是否压缩 

            return mc;
        }
        #endregion

        #region 缓存是否存在
        /// <summary>
        /// 缓存是否存在
        /// </summary>
        /// <param name="serverlist">IP端口列表</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static bool CacheIsExists(ArrayList serverlist, string poolName, string key)
        {
            MemcachedClient mc = CreateServer(serverlist, poolName);

            if (mc.KeyExists(key))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region 添加缓存

        #region 添加缓存(键不存在则添加,键存在则不能添加)
        /// <summary>
        /// 添加缓存(键不存在则添加,键存在则不能添加)
        /// </summary>
        /// <param name="serverlist">IP端口列表</param>
        /// <param name="poolName">连接池名称</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="minutes">过期分钟数</param>
        /// <returns></returns>
        public static bool AddCache(ArrayList serverlist, string poolName, string key, string value, int minutes)
        {
            MemcachedClient mc = CreateServer(serverlist, poolName);
            return mc.Add(key, value, DateTime.Now.AddMinutes(minutes));
        }
        #endregion

        #region 添加缓存(键不存在则添加,键存在则覆盖)
        /// <summary>
        /// 添加缓存(键不存在则添加,键存在则覆盖)
        /// </summary>
        /// <param name="serverlist">IP端口列表</param>
        /// <param name="poolName">连接池名称</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="minutes">过期分钟数</param>
        /// <returns></returns>
        public static bool SetCache(ArrayList serverlist, string poolName, string key, string value, int minutes)
        {
            MemcachedClient mc = CreateServer(serverlist, poolName);
            return mc.Set(key, value, DateTime.Now.AddMinutes(minutes));
        }
        #endregion

        #endregion

        #region 替换缓存

        #region 替换缓存(键存在的才能替换,不存在则不替换)
        /// <summary>
        /// 替换缓存(键存在的才能替换,不存在则不替换)
        /// </summary>
        /// <param name="serverlist">IP端口列表</param>
        /// <param name="poolName">连接池名称</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="minutes">过期分钟数</param>
        /// <returns></returns>
        public static bool ReplaceCache(ArrayList serverlist, string poolName, string key, string value, int minutes)
        {
            MemcachedClient mc = CreateServer(serverlist, poolName);
            return mc.Replace(key, value, DateTime.Now.AddMinutes(minutes));
        }
        #endregion

        #endregion

        #region 获取缓存

        #region 获取单个键对应的缓存
        /// <summary>
        /// 获取单个键对应的缓存
        /// </summary>
        /// <param name="serverlist">IP端口列表</param>
        /// <param name="poolName">连接池名称</param>
        /// <param name="key">键</param> 
        /// <returns></returns>
        public static object GetCache(ArrayList serverlist, string poolName, string key)
        {
            MemcachedClient mc = CreateServer(serverlist, poolName);
            if (mc.KeyExists(key))
            {
                return mc.Get(key);
            }
            else
            {
                
                return "";
            }
        }
        #endregion

        #region 获取键数组对应的值
        /// <summary>
        /// 获取键数组对应的值
        /// </summary>
        /// <param name="serverlist">IP端口列表</param>
        /// <param name="poolName">连接池名称</param>
        /// <param name="keys">键列表</param>
        /// <returns>Hashtable键值对</returns>
        public static Hashtable GetCacheHt(ArrayList serverlist, string poolName, string[] keys)
        {
            MemcachedClient mc = CreateServer(serverlist, poolName);
            return mc.GetMultiple(keys);
        }
        #endregion

        #region 获取键数组对应的值
        /// <summary>
        /// 获取键数组对应的值
        /// </summary>
        /// <param name="serverlist">IP端口列表</param>
        /// <param name="poolName">连接池名称</param>
        /// <param name="keys">键列表</param>
        /// <returns>值的数组(不包含键)</returns>
        public static object[] GetCacheList(ArrayList serverlist, string poolName, string[] keys)
        {
            MemcachedClient mc = CreateServer(serverlist, poolName);
            object[] list = mc.GetMultipleArray(keys);
            ArrayList returnList = new ArrayList();
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != null)
                {
                    returnList.Add(list[i]);
                }
            }
            return returnList.ToArray();
        }
        #endregion

        #endregion

        #region 删除缓存
        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="serverlist">IP端口列表</param>
        /// <param name="poolName">连接池名称</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static bool DelCache(ArrayList serverlist, string poolName, string key)
        {
            MemcachedClient mc = CreateServer(serverlist, poolName);
            return mc.Delete(key);
        }
        #endregion

        #region 清空所有缓存
        /// <summary>
        /// 清空所有缓存
        /// </summary>
        /// <param name="serverlist">IP端口列表</param>
        /// <param name="poolName">连接池名称</param>
        /// <returns></returns>
        public static bool FlushAll(ArrayList serverlist, string poolName)
        {
            MemcachedClient mc = CreateServer(serverlist, poolName);
            return mc.FlushAll();
        }
        #endregion
    }
}