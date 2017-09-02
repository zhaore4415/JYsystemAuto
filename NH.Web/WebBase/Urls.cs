using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NH.Web
{
    public static class Urls
    {
        #region 公共部分
        public static string BaseUrl()
        {
            return "http://" + HttpContext.Current.Request.Url.ToString().Replace("http://", "").Split('/')[0];
        }

        /// <summary>
        /// /Default.aspx
        /// </summary>
        /// <returns></returns>
        public static string Default()
        {
            return "/Index.aspx";
        }

        /// <summary>
        /// /Reg/RegProtocol.aspx
        /// </summary>
        /// <returns></returns>
        public static string RegProtocol()
        {
            return "/Reg/RegProtocol.aspx";
        }

        /// <summary>
        /// /Login/Login.aspx
        /// </summary>
        /// <returns></returns>
        public static string Login()
        {
            return "/Login.aspx";
        }

        /// <summary>
        /// /Login/Login.aspx?ReturnUrl=
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public static string Login(string returnUrl)
        {
            return "/Login.aspx?ReturnUrl=" + returnUrl;
        }

        /// <summary>
        /// /Login/LogOut.aspx
        /// </summary>
        /// <returns></returns>
        public static string LogOut(string type)
        {
            if (!string.IsNullOrEmpty(type))
                return "/LogOut.aspx?type=" + type;
            else
                return "/LogOut.aspx";
        }

        /// <summary>
        /// SmsCode.ashx?ajax=1
        /// </summary>
        /// <returns></returns>
        public static string SmsCode()
        {
            return "/Common/SmsCode.ashx?ajax=1";
        }

        /// <summary>
        /// /Common/Ajax.ashx?action=
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string Ajax(string action)
        {
            return "/Common/Ajax.ashx?action=" + action;
        }

        /// <summary>
        /// /VCode.ashx?type=
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string VCode(string type)
        {
            return "/Common/VCode.ashx?type=" + type;
        }

        /// <summary>
        /// /Rencai/PerInfo.aspx?mid=
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static string PerInfo(int mid)
        {
            return "/Rencai/PerInfo.aspx?mid=" + mid.ToString();
        }

        /// <summary>
        /// /Rencai/PerInfo.aspx?mid=1&aid=2
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="aid"></param>
        /// <returns></returns>
        public static string PerInfo(string mid, string aid)
        {
            return "/Rencai/PerInfo.aspx?mid=" + mid + "&aid=" + aid;
        }

        /// <summary>
        /// /Contact.aspx
        /// </summary>
        /// <returns></returns>
        public static string Contact()
        {
            return "/Contact.aspx";
        }

        /// <summary>
        /// /Payment/alipay/alipay.aspx
        /// </summary>
        /// <returns></returns>
        public static string Alipay()
        {
            return "/Payment/alipay/alipay.aspx";
        }

        /// <summary>
        /// /Real.aspx
        /// </summary>
        /// <returns></returns>
        public static string Real()
        {
            return "/Real.aspx";
        }


        #endregion

        /// <summary>
        /// /VipPrice.aspx
        /// </summary>
        /// <returns></returns>
        public static string VipPrice()
        {
            return "/VipPrice.aspx";
        }

        /// <summary>
        /// /Help/HelpList.aspx?cid=
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public static string HelpList(int cid)
        {
            return "/Help/HelpList.aspx?cid=" + cid;
        }

        /// <summary>
        /// /Help/HelpDetails.aspx?hid=
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string HelpDetails(int id)
        {
            return "/Help/HelpDetails.aspx?hid=" + id;
        }


        /// <summary>
        /// /Article/Article.aspx
        /// </summary>
        /// <returns></returns>
        public static string Article()
        {
            return "/Article/Article.aspx";
        }

        /// <summary>
        /// /Article/ArticleList.aspx?cid=
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public static string ArticleList(int cid)
        {
            return "/Article/ArticleList.aspx?cid=" + cid;
        }

        /// <summary>
        /// /Article/ArticleDetails.aspx?aid=
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string ArticleDetails(int id)
        {
            return "/Article/ArticleDetails.aspx?aid=" + id;
        }
        public static string News()
        {
            return "/Article/news.aspx";
        }
        public static string News(int categoryId)
        {
            return "/Article/news.aspx?cid=" + categoryId.ToString();
        }
        public static string NewsDetails(string id)
        {
            return "/Article/newsdetails.aspx?nid=" + id;
        }


        #region 前台会员中心
        /// <summary>
        /// /Login/Login.aspx
        /// </summary>
        /// <returns></returns>
        public static string MemberIndex()
        {
            return "/Member/MemberIndex.aspx";
        }
        #endregion
    }
}