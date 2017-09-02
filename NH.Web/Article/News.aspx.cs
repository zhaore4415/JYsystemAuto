using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Article
{
    public partial class News : System.Web.UI.Page
    {
        public int id;
        public Model.ArticleCategory categoryModel = null;
        protected string _pager;
        protected string _categorypath;
        protected string _category;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        private void BindList()
        {


            int pagesize = 15;
            int page = RequestHelper.GetPageIndex();
            string strWhere = " ";

            int cid = 0;
            int pid = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["cid"]) && PageValidate.IsNumber(Request.QueryString["cid"]))
            {
                id = cid = int.Parse(Request.QueryString["cid"]);
            }
            //if (cid > 0)
            //{
            //    strWhere += " and a.CategoryPath like '%," + cid.ToString() + ",%'";
            //    Model.ArticleCategory category = BLL.ArticleCategory.GetModel(cid);
            //    //pid = category.ParentID.Value;
            //    if (category != null)
            //    {
            //        _categorypath = string.Format("<span>-></span><a href='{0}'>{1}</a>", Urls.News(category.Id), category.Name);
            //        _category = string.Format("{1}", Urls.News(category.Id), category.Name);
            //    }
            //    //NewsCategory.SelectedCid = cid;
            //}
            //else if (!string.IsNullOrEmpty(Request.QueryString["pid"]) && PageValidate.IsNumber(Request.QueryString["pid"]))
            //{
            //    pid = int.Parse(Request.QueryString["pid"]);
            //}
            categoryModel = BLL.ArticleCategory.GetModel(pid);
            //strWhere += " and a.CategoryPath like '%," + pid.ToString() + ",%'";
            DataSet ds = DataUtility.GetList("Article a left join ArticleCategory ac on a.CategoryID=ac.Id", "a.Id,a.Title,a.AddTime,a.UpdateTime,a.Description", pagesize, page, "a.Id", strWhere, "order by a.UpdateTime desc,a.Id desc", true);
                                        
            rptList2.DataSource = ds.Tables[0];
            rptList2.DataBind();
            int count = (int)ds.Tables[1].Rows[0][0];
            string url = null;
            //if (Urls.IsHtml)
            //    url = "/news-" + cid + "-{0}.html";
            _pager = new Pager(pagesize, count, url).Create();
        }
    }
}