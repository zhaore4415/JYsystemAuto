using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;


namespace Maticsoft.Common
{
   public class AdminUtil
   {
    
        #region 获取access_token
        /// <summary>
        /// 获取access_token
        /// </summary>
       public static string GetAccessToken()
       {
           //NH.BLL.SWX_Config configswx = new NH.BLL.SWX_Config();
           NH.Model.SWX_Config modelswx = new NH.Model.SWX_Config();
           string access_token = string.Empty;
           DataSet ds = NH.BLL.SWX_Config.GetAllList();
           //DataSet dss=new 
           modelswx.access_token = ds.Tables[0].Rows[0]["access_token"].ToString();
           modelswx.CorpId = ds.Tables[0].Rows[0]["CorpId"].ToString();
           modelswx.Secret = ds.Tables[0].Rows[0]["Secret"].ToString();
           //NH.BLL.SWX_Config configswx = NH.BLL.SWX_Config.GetAllList();

           //UserInfo user = GetLoginUser(page);
           if (ds != null)
           {
               if (NH.BLL.SWX_Config.Existss(modelswx.access_token)) //尚未保存过access_token
               {
                   access_token = Cryptography.GetToken(ConfigurationManager.AppSettings["CorpId"], ConfigurationManager.AppSettings["Secret"]);
               }
               else
               {
                   if (Cryptography.TokenExpired(modelswx.access_token)) //access_token过期
                   {
                       access_token = Cryptography.GetToken(ConfigurationManager.AppSettings["CorpId"], ConfigurationManager.AppSettings["Secret"]);
                   }
                   else
                   {
                       return modelswx.access_token;
                   }
               }

               NH.BLL.SWX_Config.Update(modelswx);
               //.ExecuteSql(string.Format("update SWX_Config set access_token='{0}' where UserName='{1}'", access_token, user.UserName));
           }

           return access_token;
       }
        #endregion
    }
}
