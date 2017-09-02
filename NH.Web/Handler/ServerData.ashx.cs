using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;//注意添加引用
using System.Web.Script.Serialization;//注意添加引用
using System.Configuration;

namespace AutoComplete
{
    /// <summary>
    /// ServerData 的摘要说明
    /// 功能:返回JSON数据给前台调用
    /// Author:LuckyHu
    /// Data:2012-03-31
    /// </summary>
    public class ServerData : IHttpHandler
    {
        //设置几个全局变量
        string connStr = ConfigurationManager.AppSettings["ConnectionString"];
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;

        //作为主函数使用
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
           // context.Response.Write("Hello World");
            string keyword = context.Request.QueryString["keyword"]; 
            if (keyword != null)
            {           
                JavaScriptSerializer serializer = new JavaScriptSerializer(); // 通过JavaScriptSerializer对象的Serialize序列化为["value1","value2",...]的字符串 
                string jsonString = serializer.Serialize(GetFilteredList(keyword));
                context.Response.Write(jsonString); // 返回客户端json格式数据
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 根据关键字过滤数据
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>过滤数据</returns>
        private string[] GetFilteredList(string keyword)
        {
            sdr = GetData(keyword);
            List<string> nameList = new List<string>();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                int x = 10;     //前台模糊查询最大显示数据个数
                while (sdr.Read()&&x-->0)
                {
                    string name = sdr["Name"].ToString();
                    name = name.Trim();
                    nameList.Add(name);
                }
            }
            catch (SqlException ex)
            {
                Console.Write(ex.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return nameList.ToArray();
        }


        /// <summary>
        ///  构造测试数据
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetData(string key)
        {
            conn = new SqlConnection(connStr);
            string sql = "select [Name] from ProjectManager where [Name] like ('" + key + "%')";
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                cmd = new SqlCommand(sql, conn);
                sdr = cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                Console.Write(ex.ToString());
            }
            return sdr;
        }
    }
}