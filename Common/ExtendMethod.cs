using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Common
{
    public static class ExtendMethod
    {
        /// <summary>
        /// 统一ToString调用方法 
        /// </summary>
        /// <param name="obj">需要转换为字符串的参数</param>
        /// <returns>""或转化结果</returns>
        public static string DBToString(this object obj)
        {
            if (obj is DBNull || obj == null)
                return "";
            else
                return obj.ToString();
        }
 
        /// <summary>
        /// 将DateTime? 按指定格式进行转换
        /// </summary>
        /// <param name="dt">DateTime？值</param>
        /// <param name="format">格式化格式，默认：yyyy-MM-dd</param>
        /// <returns>""或格式化后的结果值</returns>
        public static string DTimeToString(this DateTime? dt,string format="yyyy-MM-dd")
        {
            if (dt.DBToString() == "")
                return "";
            else
                return Convert.ToDateTime(dt).ToString(format);
        }
    }
}
