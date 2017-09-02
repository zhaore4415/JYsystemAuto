using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Common
{
    public class MD5Encrypt
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string Encrypt(string inputString)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = md5.ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(inputString));
            string result = "";
            for (int i = 0; i < data.Length; i++)
            {
                result += data[i].ToString("X");
            }
            return result.Substring(8, 16);
        }
    }
}
