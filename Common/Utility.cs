using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Common
{
    public class Utility
    {
        /// <summary>
        /// 对验证码进行加密
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string EncryptValidateCode(string code)
        {
            return MD5Encrypt.Encrypt(code.ToLower() + "xxyy");
        }
    }
}
