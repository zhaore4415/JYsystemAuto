using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Common
{
    //public class replyset
    //{
    //    public string hostUrl = "http://" + HttpContext.Current.Request.Url.Authority;          //域名
    //    public string upfileurl = "http://file.api.weixin.qq.com/cgi-bin/media/upload";
    //    public string baiduImg = "http://api.map.baidu.com/staticimage?center={0},{1}&width=700&height=300&zoom=11";
    //    public string User_ID = "";
    //    public string WeChat_ID = "";
    //    public string WeChat_Type = "";
    //    public string WeChat_Name = "";



    //    w_caidan_dal caidandal = new w_caidan_dal();
    //    w_reply_dal replydal = new w_reply_dal();
    //    w_article_dal articledal = new w_article_dal();
    //    w_keyword_dal keyworddal = new w_keyword_dal();
    //    w_vlimg_dal vlimgdal = new w_vlimg_dal();
    //    w_vlimg_model vlimgmodel = new w_vlimg_model();
    //    w_images_dal imagesdal = new w_images_dal();

    //    common wxCommand = new common();
    //    JsonOperate JsonOperate = new JsonOperate();
    //    JavaScriptSerializer Jss = new JavaScriptSerializer();

    //    public replyset()
    //    { }

    //    #region 关注回复
    //     <summary>
    //     关注的时候回复
    //     </summary>
    //     <param name="FromUserName"></param>
    //     <param name="ToUserName"></param>
    //     <returns></returns>
    //    public string GetSubscribe(string FromUserName, string ToUserName)
    //    {
    //        string resXml = "";
    //        string sqlWhere = !string.IsNullOrEmpty(WeChat_ID) ? "WeChat_ID=" + WeChat_ID + " and reply_fangshi=2" : "";

    //        DataTable dtSubscribe = replydal.GetRandomList(sqlWhere, "1").Tables[0];

    //        if (dtSubscribe.Rows.Count > 0)
    //        {
    //            string article_id = dtSubscribe.Rows[0]["article_id"].ToString();
    //            string reply_type = dtSubscribe.Rows[0]["reply_type"].ToString();
    //            string reply_text = dtSubscribe.Rows[0]["reply_text"].ToString();

    //            if (reply_type == "text")
    //            {
    //                resXml = "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + reply_text + "]]></Content><FuncFlag>0</FuncFlag></xml>";
    //            }
    //            else
    //            {
    //                resXml = GetArticle(FromUserName, ToUserName, article_id, User_ID);
    //            }
    //        }

    //        return resXml;
    //    }
    //    #endregion 关注回复

    //    #region 自动回复
    //     <summary>
    //     自动默认回复
    //     </summary>
    //     <param name="FromUserName"></param>
    //     <param name="ToUserName"></param>
    //     <param name="WeChat_ID"></param>
    //     <param name="User_ID"></param>
    //     <returns></returns>
    //    public string GetDefault(string FromUserName, string ToUserName, string WeChat_ID, string User_ID)
    //    {
    //        string resXml = "";
    //        string sqlWhere = !string.IsNullOrEmpty(WeChat_ID) ? "WeChat_ID=" + WeChat_ID + " and reply_fangshi=1" : "";
    //        获取保存的默认回复设置信息
    //        DataTable dtDefault = replydal.GetRandomList(sqlWhere, "1").Tables[0];

    //        if (dtDefault.Rows.Count > 0)
    //        {
    //            string article_id = dtDefault.Rows[0]["article_id"].ToString();
    //            string reply_type = dtDefault.Rows[0]["reply_type"].ToString();
    //            string reply_text = dtDefault.Rows[0]["reply_text"].ToString();
    //            如果选择的是文本
    //            if (reply_type == "text")
    //            {
    //                resXml = "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + reply_text + "]]></Content><FuncFlag>0</FuncFlag></xml>";
    //            }
    //            else
    //            {
    //                返回素材（图文列表）
    //                resXml = GetArticle(FromUserName, ToUserName, article_id, User_ID);
    //            }
    //        }

    //        return resXml;
    //    }
    //    #endregion 默认回复


    //    #region 关键字回复
    //     <summary>
    //     关键字回复
    //     </summary>
    //     <param name="FromUserName"></param>
    //     <param name="ToUserName"></param>
    //     <param name="Content"></param>
    //     <returns></returns>
    //    public string GetKeyword(string FromUserName, string ToUserName, string Content)
    //    {
    //        string resXml = "";
    //        string sqlWhere = "wechat_id=" + WeChat_ID + " and keyword_name='" + Content + "'";

    //        DataTable dtKeyword = keyworddal.GetList(sqlWhere).Tables[0];

    //        if (dtKeyword.Rows.Count > 0)
    //        {
    //            dtKeyword = keyworddal.GetRandomList(sqlWhere, "1").Tables[0];

    //            if (dtKeyword.Rows.Count > 0)
    //            {
    //                string article_id = dtKeyword.Rows[0]["article_id"].ToString();
    //                string keyword_type = dtKeyword.Rows[0]["keyword_type"].ToString();
    //                string keyword_text = dtKeyword.Rows[0]["keyword_text"].ToString();

    //                switch (keyword_type)
    //                {
    //                    case "text":
    //                        resXml = "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + keyword_text + "]]></Content><FuncFlag>0</FuncFlag></xml>";
    //                        break;
    //                    case "news":
    //                        resXml = GetArticle(FromUserName, ToUserName, article_id, User_ID);
    //                        break;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            resXml = GetDefault(FromUserName, ToUserName, WeChat_ID, User_ID);
    //        }

    //        return resXml;
    //    }
    //    #endregion 关键字回复

    //    #region 菜单单击
    //     <summary>
    //     菜单点击事件回复信息
    //     </summary>
    //     <param name="FromUserName"></param>
    //     <param name="ToUserName"></param>
    //     <param name="EventKey"></param>
    //     <returns></returns>
    //    public string GetMenuClick(string FromUserName, string ToUserName, string EventKey)
    //    {
    //        string resXml = "";
    //        string sqlWhere = "wechat_id=" + WeChat_ID + " and caidan_key='" + EventKey + "'";

    //        WriteTxt(sqlWhere);
    //        try
    //        {

    //            DataTable dtMenu = caidandal.GetList(sqlWhere).Tables[0];

    //            if (dtMenu.Rows.Count > 0)
    //            {
    //                string article_id = dtMenu.Rows[0]["article_id"].ToString();
    //                string caidan_retype = dtMenu.Rows[0]["caidan_retype"].ToString();
    //                string caidan_retext = dtMenu.Rows[0]["caidan_retext"].ToString();


    //                switch (caidan_retype)
    //                {
    //                    case "text":
    //                        resXml = "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + caidan_retext + "]]></Content><FuncFlag>0</FuncFlag></xml>";
    //                        break;
    //                    case "news":
    //                        resXml = GetArticle(FromUserName, ToUserName, article_id, User_ID);
    //                        break;
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            WriteTxt("异常：" + ex.Message + "Struck:" + ex.StackTrace.ToString());
    //        }

    //        return resXml;
    //    }
    //    #endregion 菜单单击

    //    #region 获取素材
    //     <summary>
    //     获取素材
    //     </summary>
    //     <param name="FromUserName"></param>
    //     <param name="ToUserName"></param>
    //     <param name="Article_ID"></param>
    //     <param name="User_ID"></param>
    //     <returns></returns>
    //    public string GetArticle(string FromUserName, string ToUserName, string Article_ID, string User_ID)
    //    {
    //        string resXml = "";

    //        DataTable dtArticle = articledal.GetList("article_id=" + Article_ID + " OR article_layid=" + Article_ID).Tables[0];

    //        if (dtArticle.Rows.Count > 0)
    //        {
    //            resXml = "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + ToUserName + "]]></FromUserName><CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[news]]></MsgType><Content><![CDATA[]]></Content><ArticleCount>" + dtArticle.Rows.Count + "</ArticleCount><Articles>";

    //            foreach (DataRow Row in dtArticle.Rows)
    //            {
    //                string article_title = Row["article_title"].ToString();
    //                string article_description = Row["article_description"].ToString();
    //                string article_picurl = Row["article_picurl"].ToString();
    //                string article_url = Row["article_url"].ToString();
    //                string article_type = Row["article_type"].ToString();

    //                switch (article_type)
    //                {
    //                    case "Content":
    //                        article_url = hostUrl + "/web/wechat/api/article.aspx?aid=" + Row["Article_ID"].ToString();
    //                        break;
    //                    case "Href":
    //                        article_url = Row["article_url"].ToString();
    //                        break;
    //                }

    //                if (string.IsNullOrEmpty(article_url))
    //                {
    //                    article_url = hostUrl + "/web/wechat/api/article.aspx?aid=" + Row["Article_ID"].ToString();
    //                }

    //                article_url += (article_url.IndexOf("uid=") > -1 ? "" : (article_url.IndexOf("?") > -1 ? "&" : "?") + "uid=" + User_ID);
    //                article_url += (article_url.IndexOf("wxid=") > -1 ? "" : (article_url.IndexOf("?") > -1 ? "&" : "?") + "wxid=" + FromUserName);
    //                article_url += (article_url.IndexOf("wxref=") > -1 ? "" : (article_url.IndexOf("?") > -1 ? "&" : "?") + "wxref=mp.weixin.qq.com");

    //                resXml += "<item><Title><![CDATA[" + article_title + "]]></Title><Description><![CDATA[" + article_description + "]]></Description><PicUrl><![CDATA[" + article_picurl + "]]></PicUrl><Url><![CDATA[" + article_url + "]]></Url></item>";
    //            }

    //            resXml += "</Articles><FuncFlag>1</FuncFlag></xml>";
    //        }

    //        return resXml;
    //    }
    //    #endregion 获取图文列表



    //    #region 通用方法
    //     <summary>
    //     unix时间转换为datetime
    //     </summary>
    //     <param name="timeStamp"></param>
    //     <returns></returns>
    //    private DateTime UnixTimeToTime(string timeStamp)
    //    {
    //        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
    //        long lTime = long.Parse(timeStamp + "0000000");
    //        TimeSpan toNow = new TimeSpan(lTime);
    //        return dtStart.Add(toNow);
    //    }

    //     <summary>
    //     datetime转换为unixtime
    //     </summary>
    //     <param name="time"></param>
    //     <returns></returns>
    //    private int ConvertDateTimeInt(System.DateTime time)
    //    {
    //        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
    //        return (int)(time - startTime).TotalSeconds;
    //    }

    //     <summary>
    //     记录bug，以便调试
    //     </summary>
    //     <returns></returns>
    //    public bool WriteTxt(string str)
    //    {
    //        try
    //        {
    //            FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("Log/wxbugLog.txt"), FileMode.Append);
    //            StreamWriter sw = new StreamWriter(fs);
    //            开始写入
    //            sw.WriteLine(str);
    //            清空缓冲区
    //            sw.Flush();
    //            关闭流
    //            sw.Close();
    //            fs.Close();
    //        }
    //        catch (Exception)
    //        {
    //            return false;
    //        }
    //        return true;
    //    }
    //    #endregion 通用方法
    //}
}
