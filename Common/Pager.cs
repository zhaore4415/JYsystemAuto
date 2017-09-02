using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace Maticsoft.Common
{
    public class Pager
    {
        public int _page = 1;//当前页
        public int _pagesize = 20;//每页显示数量
        public int _totalcount = 0;//总记录数
        private string _html = "<div class='pages'>{0}</div>";
        private string _htmla = "<a href='{0}' class='normal'><span>{1}</span></a>";
        private string _htmlselected = "<a class='selectedpage'><span>{0}</span></a>";
        private string _htmlPrev = "<a href='{0}' class='prevpage'><span>上一页</span></a>";
        private string _htmlNext = "<a href='{0}' class='nextpage'><span>下一页</span></a>";
        private string _htmlPrevDisabled = "<a class='prevpage disabled'><span>上一页</span></a>";
        private string _htmlNextDisabled = "<a class='nextpage disabled'><span>下一页</span></a>";
        private string _htmlFirst = "<a href='{0}' class='firstpage'><span>首页</span></a>";
        private string _htmlLast = "<a href='{0}' class='lastpage'><span>尾页</span></a>";
        private string _htmlFirstDisabled = "<a class='firstpage disabled'><span>首页</span></a>";
        private string _htmlLastDisabled = "<a class='lastpage disabled'><span>尾页</span></a>";
        
        private string _url = null;
        HttpRequest request = HttpContext.Current.Request;

        public Pager(int pagesize, int totalcount, string url)
        {
            if (!string.IsNullOrEmpty(request.QueryString["page"]))
            {
                try
                {
                    this._page = int.Parse(request.QueryString["page"]);
                }
                catch { }
            }
            this._pagesize = pagesize;
            this._totalcount = totalcount;
            this._url = url;
        }

        public Pager(int pagesize, int totalcount)
            : this(pagesize, totalcount, null)
        {
        }

        public Pager()
        { }

        public string GetUrl()
        {
            string baseUrl = null;
            if (!string.IsNullOrEmpty(_url))
            {
                baseUrl = _url;
            }
            else
            {
                baseUrl = request.Url.ToString();
                Regex regex = new Regex(@"[\?&]page=\d*", RegexOptions.IgnoreCase);
                if (regex.IsMatch(baseUrl))
                {
                    baseUrl = regex.Replace(baseUrl, new MatchEvaluator(ReplacePage));
                }
                else
                {
                    baseUrl += (string.IsNullOrEmpty(request.Url.Query) ? "?" : "&") + "page={0}";
                }
            }
            return baseUrl;
        }

        public string Create()
        {
            int totalPage = (int)Math.Ceiling((decimal)this._totalcount / (decimal)this._pagesize);
            if (totalPage == 0) totalPage = 1;
            if (this._page <= 0) this._page = 1;
            string baseUrl = this.GetUrl();
            if (this._page > totalPage)
            {
                HttpContext.Current.Response.Redirect(string.Format(baseUrl, totalPage), false);
            }
            StringBuilder sb = new StringBuilder();
            //首页、上一页
            if (this._page > 1)
            {
                sb.Append(string.Format(_htmlFirst, string.Format(baseUrl, 1)));
                sb.Append(string.Format(_htmlPrev, string.Format(baseUrl, this._page - 1)));
            }
            else
            {
                sb.Append(_htmlFirstDisabled);
                sb.Append(_htmlPrevDisabled);
            }
            //循环
            for (int i = 1; i <= totalPage; i++)
            {
                if (this._page != i)
                {
                    if (this._page >= i - 5 && this._page <= i + 5)
                    {
                        sb.Append(string.Format(_htmla, string.Format(baseUrl, i), i));
                    }
                }
                else
                {
                    sb.Append(string.Format(_htmlselected, i));
                }
            }
            //下一页、尾页
            if (this._page < totalPage)
            {
                sb.Append(string.Format(_htmlNext, string.Format(baseUrl, this._page + 1)));
                sb.Append(string.Format(_htmlLast, string.Format(baseUrl, totalPage)));
            }
            else
            {
                sb.Append(_htmlNextDisabled);
                sb.Append(_htmlLastDisabled);
            }

            //每页显示个数
            sb.Append(" 每页 " + this._pagesize + " 条");
            return string.Format(_html, sb.ToString());
        }
        private string ReplacePage(Match m)
        {
            if (m.ToString().StartsWith("?"))
            {
                return "?page={0}";
            }
            else
            {
                return "&page={0}";
            }
        }
    }

    public class Pager3
    {
        public int _page = 1;//当前页
        public int _pagesize = 20;//每页显示数量
        public int _totalcount = 0;//总记录数
        private string _html = "<div class='pages'>{0}</div>";
        private string _htmla = "<a href='{0}' class='normal'><span>{1}</span></a>";
        private string _htmlselected = "<a class='selectedpage'><span>{0}</span></a>";
        private string _htmlPrev = "<a href='{0}' class='prevpage'><span>Prev</span></a>";
        private string _htmlNext = "<a href='{0}' class='nextpage'><span>Next</span></a>";
        private string _htmlPrevDisabled = "<a class='prevpage disabled'><span>Prev</span></a>";
        private string _htmlNextDisabled = "<a class='nextpage disabled'><span>Next</span></a>";
        private string _htmlFirst = "<a href='{0}' class='firstpage'><span>First</span></a>";
        private string _htmlLast = "<a href='{0}' class='lastpage'><span>End</span></a>";
        private string _htmlFirstDisabled = "<a class='firstpage disabled'><span>First</span></a>";
        private string _htmlLastDisabled = "<a class='lastpage disabled'><span>End</span></a>";
        private string _url = null;
        HttpRequest request = HttpContext.Current.Request;

        public Pager3(int pagesize, int totalcount, string url)
        {
            if (!string.IsNullOrEmpty(request.QueryString["page"]))
            {
                try
                {
                    this._page = int.Parse(request.QueryString["page"]);
                }
                catch { }
            }
            this._pagesize = pagesize;
            this._totalcount = totalcount;
            this._url = url;
        }

        public Pager3(int pagesize, int totalcount)
            : this(pagesize, totalcount, null)
        {
        }

        public Pager3()
        { }

        public string GetUrl()
        {
            string baseUrl = null;
            if (!string.IsNullOrEmpty(_url))
            {
                baseUrl = _url;
            }
            else
            {
                baseUrl = request.Url.ToString();
                Regex regex = new Regex(@"[\?&]page=\d*", RegexOptions.IgnoreCase);
                if (regex.IsMatch(baseUrl))
                {
                    baseUrl = regex.Replace(baseUrl, new MatchEvaluator(ReplacePage));
                }
                else
                {
                    baseUrl += (string.IsNullOrEmpty(request.Url.Query) ? "?" : "&") + "page={0}";
                }
            }
            return baseUrl;
        }

        public string Create()
        {
            int totalPage = (int)Math.Ceiling((decimal)this._totalcount / (decimal)this._pagesize);
            if (totalPage == 0) totalPage = 1;
            if (this._page <= 0) this._page = 1;
            string baseUrl = this.GetUrl();
            if (this._page > totalPage)
            {
                HttpContext.Current.Response.Redirect(string.Format(baseUrl, totalPage), false);
            }
            StringBuilder sb = new StringBuilder();
            //首页、上一页
            if (this._page > 1)
            {
                sb.Append(string.Format(_htmlFirst, string.Format(baseUrl, 1)));
                sb.Append(string.Format(_htmlPrev, string.Format(baseUrl, this._page - 1)));
            }
            else
            {
                sb.Append(_htmlFirstDisabled);
                sb.Append(_htmlPrevDisabled);
            }
            //循环
            for (int i = 1; i <= totalPage; i++)
            {
                if (this._page != i)
                {
                    if (this._page >= i - 5 && this._page <= i + 5)
                    {
                        sb.Append(string.Format(_htmla, string.Format(baseUrl, i), i));
                    }
                }
                else
                {
                    sb.Append(string.Format(_htmlselected, i));
                }
            }
            //下一页、尾页
            if (this._page < totalPage)
            {
                sb.Append(string.Format(_htmlNext, string.Format(baseUrl, this._page + 1)));
                sb.Append(string.Format(_htmlLast, string.Format(baseUrl, totalPage)));
            }
            else
            {
                sb.Append(_htmlNextDisabled);
                sb.Append(_htmlLastDisabled);
            }
            return string.Format(_html, sb.ToString());
        }
        private string ReplacePage(Match m)
        {
            if (m.ToString().StartsWith("?"))
            {
                return "?page={0}";
            }
            else
            {
                return "&page={0}";
            }
        }
    }
}
