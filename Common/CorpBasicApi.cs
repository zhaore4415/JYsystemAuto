using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Web;


namespace Maticsoft.Common
{
    /// <summary>
    /// 企业号基础操作API实现
    /// </summary>
    public class CorpBasicApi
    {
        /// <summary>
        /// 验证企业号签名
        /// </summary>
        /// <param name="token">企业号配置的Token</param>
        /// <param name="signature">签名内容</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">nonce参数</param>
        /// <param name="corpId">企业号ID标识</param>
        /// <param name="encodingAESKey">加密键</param>
        /// <param name="echostr">内容字符串</param>
        /// <param name="retEchostr">返回的字符串</param>
        /// <returns></returns>
        public bool CheckSignature(string token, string signature, string timestamp, string nonce, string corpId, string encodingAESKey, string echostr, ref string retEchostr)
        {
            WXBizMsgCrypt wxcpt = new WXBizMsgCrypt(token, encodingAESKey, corpId);
            int result = wxcpt.VerifyURL(signature, timestamp, nonce, echostr, ref retEchostr);
            if (result != 0)
            {
                LogTextHelper.Error("ERR: VerifyURL fail, ret: " + result);
                return false;
            }

            return true;

            //ret==0表示验证成功，retEchostr参数表示明文，用户需要将retEchostr作为get请求的返回参数，返回给企业号。
            // HttpUtils.SetResponse(retEchostr);
        }
        /// <summary>
        /// 获取每次操作微信API的Token访问令牌         /// </summary>
        /// <param name="corpid">企业Id</param>
        /// <param name="corpsecret">管理组的凭证密钥</param>
        /// <returns></returns>
        //public string GetAccessTokenNoCache(string corpid, string corpsecret)
        //{
            //var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}", corpid, corpsecret);
            //HttpHelper helper = new HttpHelper();
            //string result = url;
            //string regex = "\"access_token\":\"(?<token>.*?)\"";
            //string token = GetText(result, regex, "token");
       
            //return token;

            //var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}",
            //                      corpid, corpsecret);

            //HttpHelper helper = new HttpHelper();
            //string result = helper.GetHtml(url);
            //string regex = "\"access_token\":\"(?<token>.*?)\"";

            //string token = CRegex.GetText(result, regex, "token");
            //return token;
        //}
        //private string GetText(string result, string regex, string token)
        //{
        //    string str = null;
        //    str = result + regex + token;
        //    return str;
        //}
        /// <summary>
        /// 创建部门的返回结果     /// </summary>
        public class CorpDeptCreateJson : DataToJson
        {         /// <summary>
            /// 返回的错误消息         /// </summary>
            //public CorpReturnCode errcode { get; set; }          /// <summary>
            /// 对返回码的文本描述内容         /// </summary>
            public string errmsg { get; set; }          /// <summary>
            /// 创建的部门id。         /// </summary>
            public int id { get; set; }
        }

     
        ///// <summary>
        ///// 创建部门。         /// 管理员须拥有“操作通讯录”的接口权限，以及父部门的管理权限。         /// </summary>
        //public string CreateDept(string accessToken, string name, string parentId)
        //{
        //    ////string result;
        //    //string urlFormat = "https://qyapi.weixin.qq.com/cgi-bin/department/create?access_token={0}";
        //    ////https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=wxf4fe26173d8c7d61&corpsecret=u1p7IlzXgWafCjsi6Rdd-EKYyhXtpt5KE1KgNPzucU8oYQ_VA0XqtCPxybQEZFlQ   //获取accessToken值
          
        //    //var url = string.Format(urlFormat, accessToken);

        //    ////result = url + "&" + name + "&" + parentId;
        //    ////CorpDeptCreateJson result = CorpJsonHelper<CorpDeptCreateJson>.ConvertJson(url, data);
        //    //return url;
        //    //DataTable dt = DataToJson.ToJson();
        //    string urlFormat = "https://qyapi.weixin.qq.com/cgi-bin/department/create?access_token={0}"; 
        //    var data = new { name = name, parentId = parentId }; 
        //    var url = string.Format(urlFormat, accessToken); 
        //    var postData = data.ToJson(); 
        //    CorpDeptCreateJson result = CorpJsonHelper<CorpDeptCreateJson>.ConvertJson(url, postData);
        //    return result;   
        //}
    
    }
}
