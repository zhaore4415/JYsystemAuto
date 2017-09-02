using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NH.Web
{
    public static class Site
    {
        public static Model.Config Config
        {
            get
            {
                return BLL.Config.GetModelByCache();
            }
        }
        /// <summary>
        /// 公共css和javascript
        /// </summary>
        public static string CommonCssAndScript
        {
            get
            {

                return @"
<link href=""/Scripts/jquery-ui-1.8.23/themes/start/jquery-ui-1.8.23.custom.css"" rel=""stylesheet"" type=""text/css"" />
<link href=""/styles/common.css"" type=""text/css"" rel=""stylesheet"" media=""screen"" />
<link href=""/styles/style.css"" type=""text/css"" rel=""stylesheet"" media=""screen"" />
<script src=""/Scripts/jquery-1.6.4.min.js"" type=""text/javascript""></script>
<script src=""/Scripts/jquery-ui-1.8.23/js/jquery-ui-1.8.23.custom.min.js"" type=""text/javascript""></script>
<script src=""/Scripts/jAreaSelect.js"" type=""text/javascript""></script>
<script src=""/Scripts/jJobSelect.js"" type=""text/javascript""></script>
<script src=""/Scripts/Common.js"" type=""text/javascript""></script>
<script src=""/Scripts/jquery.tinywatermark-3.1.0.min.js"" type=""text/javascript""></script>
<link href=""/Scripts/fancybox/jquery.fancybox.css"" rel=""stylesheet"" type=""text/css"" />
<script src=""/Scripts/fancybox/jquery.fancybox.pack.js"" type=""text/javascript""></script>
<script src=""/Scripts/jQueryAlertDialogs/jquery.alerts.js"" type=""text/javascript""></script>
<link href=""/Scripts/jQueryAlertDialogs/jquery.alerts.css"" rel=""stylesheet"" type=""text/css"" />";
            }
        }

        public static string GetShortProvince(string area)
        {
            return area.Split(' ')[0].TrimEnd('省', '市');
        }

        /// <summary>
        /// 获取省Id
        /// </summary>
        /// <param name="areano"></param>
        /// <returns></returns>
        public static string GetProvinceId(string areano)
        {
            if (!string.IsNullOrEmpty(areano))
            {
                if (areano.Length >= 4)
                {
                    return areano.Substring(0, 4);
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取市Id
        /// </summary>
        /// <param name="areano"></param>
        /// <returns></returns>
        public static string GetCityId(string areano)
        {
            if (!string.IsNullOrEmpty(areano))
            {
                if (areano.Length > 4)
                {
                    return areano;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 判断地区编号是省还是市 true为市
        /// </summary>
        /// <param name="areano"></param>
        /// <returns></returns>
        public static bool GetIsCityId(string areano)
        {
            if (string.IsNullOrEmpty(areano)) return false;
            if (areano.Length > 4) { return true; } else { return false; }
        }

        public static int GetAge(DateTime birthday)
        {
            return (DateTime.Now.Year - birthday.Year);
        }

        public static string GetSex(int sex)
        {
            string result = null;
            switch (sex)
            {
                case 1:
                    result = "男";
                    break;
                case 0:
                    result = "女";
                    break;
                case -1:
                    result = "保密";
                    break;
            }
            return result;
        }

        public static string GetJobSex(int sex)
        {
            string result = null;
            switch (sex)
            {
                case 1:
                    result = "男";
                    break;
                case 0:
                    result = "女";
                    break;
                case -1:
                    result = "不限";
                    break;
            }
            return result;
        }

        public static string HtmlEncode(string str)
        {
            return str == null ? null : System.Web.HttpUtility.HtmlEncode(str);
        }

        public static string ScriptToTop()
        {
            return @"
<script type=""text/javascript"">
    document.write('<a style=""display: none;"" onclick=""window.scrollTo(0,0);return false"" title=""返回顶部"" id=""toTop"" target=""_self"" href=""#""></a>');
    function toTopHide() {document.documentElement.scrollTop + document.body.scrollTop > 80 ? $(""#toTop"").show('slow') : $(""#toTop"").hide('slow')}; $(window).scroll(function () { toTopHide(); }).scroll();
</script>
<!--[if lte IE 6]>
<script type=""text/javascript"">
    function topFixed() {document.documentElement.scrollTop > 80 ? $(""#toTop"").show('slow') : $(""#toTop"").hide('slow');document.getElementById(""toTop"").style.top = document.documentElement.clientHeight + document.documentElement.scrollTop - document.getElementById(""toTop"").clientHeight - 45 + ""px"";} window.onscroll = topFixed;topFixed();
</script>
<![endif]-->
";
        }

        #region 广告
        public static void BindAD(System.Web.UI.WebControls.Repeater rptList, int adType)
        {
            //Model.AdType model = BLL.AdType.GetModelByCache2(adType);
            //if (model == null) System.Web.HttpContext.Current.Response.Write("广告位ID不存在");
            //int num = model.ShowCount > 0 ? model.ShowCount : 0;
            //rptList.DataSource = BLL.Ad.GetList(num, "IsShow=1 and (StartDate is null or StartDate < getdate()) and (EndDate is null or DATEDIFF(DAY,getdate(),EndDate)>=0) and AdType = " + adType.ToString(), "Sort").Tables[0];
            //rptList.DataBind();
            BindAD(rptList, adType, null);
        }

        public static void BindAD(System.Web.UI.WebControls.Repeater rptList, int adType, string areano)
        {
            Model.AdType model = BLL.AdType.GetModelByCache2(adType);
            if (model == null) System.Web.HttpContext.Current.Response.Write("广告位ID不存在");
            int num = model.ShowCount > 0 ? model.ShowCount : 0;
            string strWhere = "IsShow=1 and (StartDate is null or StartDate < getdate()) and (EndDate is null or DATEDIFF(DAY,getdate(),EndDate)>=0) and AdType = " + adType.ToString();
            if (!string.IsNullOrEmpty(areano))
            {
                strWhere += " and AreaNo like '" + areano.Replace("'", "''") + "%'";
            }
            rptList.DataSource = BLL.Ad.GetList(num, strWhere, "Sort").Tables[0];
            rptList.DataBind();
        }
        #endregion

        public static void BindArticles(System.Web.UI.WebControls.Repeater rptList,int cid,int num)
        {
            rptList.DataSource = BLL.Article.GetList(num, "Status=1 and CategoryID=" + cid, "Id desc");
            rptList.DataBind();
        }

        public static string GetJobStatus(int status, int Verified)
        {
            string result = null;
            switch (Verified)
            {
                case -1:
                    result = "<span class='deleted'>不通过</span>";
                    break;
                case 0:
                    result = "<span class='deleted'>待审核</span>";
                    break;
                case 1:
                    switch (status)
                    {
                        case -1:
                            result = "<span class='deleted'>已删除</span>";
                            break;
                        case 0:
                            result = "<span class='hidden'>已隐藏</span>";
                            break;
                        case 1:
                            result = "<span class='published'>已发布</span>";
                            break;
                    }
                    break;
            }
            return result;
        }

        /// <summary>
        /// 将查询字符串进行HtmlEncode处理
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetQueryString(string name)
        {
            return HtmlEncode(HttpContext.Current.Request.QueryString[name]);
        }

        /// <summary>
        /// 将表单内容进行HtmlEncode处理
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetFormValue(string name)
        {
            return HtmlEncode(HttpContext.Current.Request.Form[name]);
        }
    }
}