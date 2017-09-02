using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace Maticsoft.Common
{
    public static class Log
    {
        static string path = System.Web.HttpContext.Current.Server.MapPath("/log/");

        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="ex"></param>
        public static void Write(Exception ex)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(path + DateTime.Now.ToString("yyyyMMddHH") + ".txt", true);
                sw.WriteLine(DateTime.Now.ToString());
                sw.WriteLine(ex.ToString());
                sw.Write(sw.NewLine);
                sw.Close();
                sw.Dispose();
            }
            catch
            {}
        }

        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="ex"></param>
        public static void Write(Exception ex, string _path)
        {
            try
            {
                if (!Directory.Exists(_path))
                {
                    Directory.CreateDirectory(_path);
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(_path + DateTime.Now.ToString("yyyyMMdd") + ".txt", true);
                sw.WriteLine(DateTime.Now.ToString());
                sw.WriteLine(ex.ToString());
                sw.Write(sw.NewLine);
                sw.Close();
                sw.Dispose();
            }
            catch
            { }
        }

        /// <summary>
        /// 记录调试信息
        /// </summary>
        /// <param name="ex"></param>
        public static void Write(string msg, string _path)
        {
            _path = HttpContext.Current.Server.MapPath(_path);
            try
            {
                if (!Directory.Exists(_path))
                {
                    Directory.CreateDirectory(_path);
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(_path + "debug_" + DateTime.Now.ToString("yyyyMMdd") + ".txt", true);
                sw.WriteLine(DateTime.Now.ToString());
                sw.WriteLine(msg);
                sw.Write(sw.NewLine);
                sw.Close();
                sw.Dispose();
            }
            catch
            { }
        }

    }
}
