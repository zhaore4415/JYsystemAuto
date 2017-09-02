using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Maticsoft.Common
{
    public static class FileHelper
    {
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filepath">路径 如：/upload/ad/abc.gif</param>
        public static void DeleteFile(string filepath)
        {
            if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(filepath)))
                File.Delete(System.Web.HttpContext.Current.Server.MapPath(filepath));
        }
    }
}
