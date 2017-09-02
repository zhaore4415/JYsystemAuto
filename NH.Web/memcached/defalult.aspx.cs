using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Memcached.ClientLibrary;
using System.Text;
using System.Collections;

namespace NH.Web.memcached
{
    public partial class defalult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                if (Request["action"] == "clear")
                    this.clear();
                else
                    this.test();
            }
        }
        /// <summary>
        /// 清空缓存
        /// </summary>
        public void clear()
        {
            //string[] servers = { "172.10.1.97:11211", "172.10.1.236:11211" };
            string[] servers = { "115.28.1.223:11211","219.234.6.97:11211" };
            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(servers);
            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 5;
            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;
            pool.MaintenanceSleep = 30;
            pool.Failover = true;
            pool.Nagle = false;
            pool.Initialize();
            MemcachedClient mc = new Memcached.ClientLibrary.MemcachedClient();
            mc.EnableCompression = false;
            mc.Delete("cache");
            mc.Delete("endCache");
            Response.Write("清空缓存成功");
        }
        /// <summary>
        /// 测试缓存
        /// </summary>
        public void test()
        {
            //分布Memcachedf服务IP 端口
            //string[] servers = { "172.10.1.97:11211","172.10.1.236:11211" };
            string[] servers = { "115.28.1.223:11211","219.234.6.97:11211" };
            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            //设置服务器列表
            pool.SetServers(servers);
            //pool.SetWeights这里的1跟10意思是，负载均衡比例，假如11000条数据，大致数据分布为：172.18.5.66分布1000条数据左右。另外一台为10000条左右
            pool.SetWeights(new int[] { 1, 10 });
            //初始化时创建连接数
            pool.InitConnections = 3;
            //最小连接数
            pool.MinConnections = 3;
            //最大连接数
            pool.MaxConnections = 5;
            //socket连接的超时时间，下面设置表示不超时（单位ms），即一直保持链接状态
            pool.SocketConnectTimeout = 1000;
            //通讯的超时时间，下面设置为3秒（单位ms），.Net版本没有实现
            pool.SocketTimeout = 3000;
            //维护线程的间隔激活时间，下面设置为30秒（单位s），设置为0时表示不启用维护线程
            pool.MaintenanceSleep = 30;
            //设置SocktIO池的故障标志
            pool.Failover = true;
            //是否对TCP/IP通讯使用nalgle算法，.net版本没有实现
            pool.Nagle = false;
            //socket单次任务的最大时间（单位ms），超过这个时间socket会被强行中端掉，当前任务失败。
            pool.MaxBusy = 1000 * 10;
            // 初始化一些值并与MemcachedServer段建立连接
            pool.Initialize();
         
            //客户端实例
            MemcachedClient mc = new Memcached.ClientLibrary.MemcachedClient();
            //是否启用压缩数据：如果启用了压缩，数据压缩长于门槛的数据将被储存在压缩的形式
            mc.EnableCompression = false;
            StringBuilder sb = new StringBuilder();
            //写入缓存
            sb.AppendLine("写入缓存测试：");
            sb.AppendLine("<br>_______________________________________<br>");
            if (mc.KeyExists("cache"))
            {
                sb.AppendLine("缓存cache已存在");
            }
            else
            {
                mc.Set("cache", "写入缓存时间：" + DateTime.Now.ToString());
                sb.AppendLine("缓存已成功写入到cache");
            }
            sb.AppendLine("<br>_______________________________________<br>");
            sb.AppendLine("读取缓存内容如下：<br>");
            sb.AppendLine(mc.Get("cache").ToString());
            //测试缓存过期
            sb.AppendLine("<br>_______________________________________<br>");
            if (mc.KeyExists("endCache"))
            {
                sb.AppendLine("缓存endCache已存在，过期时间为：" + mc.Get("endCache").ToString());
            }
            else
            {
                mc.Set("endCache", DateTime.Now.AddMinutes(1).ToString(), DateTime.Now.AddMinutes(1));
                sb.AppendLine("缓存已更新写入到endCache，写入时间：" + DateTime.Now.ToString() + " 过期时间：" + DateTime.Now.AddMinutes(1).ToString());
            }
            //分析缓存状态
            Hashtable ht = mc.Stats();
            sb.AppendLine("<br>_______________________________________<br>");
            sb.AppendLine("Memcached Stats:");
            sb.AppendLine("<br>_______________________________________<br>");
            foreach (DictionaryEntry de in ht)
            {
                Hashtable info = (Hashtable)de.Value;
                foreach (DictionaryEntry de2 in info)
                {
                    sb.AppendLine(de2.Key.ToString() + ":&nbsp;&nbsp;&nbsp;&nbsp;" + de2.Value.ToString() + "<br>");
                }
            }
            Response.Write(sb.ToString());
        }
    }
}