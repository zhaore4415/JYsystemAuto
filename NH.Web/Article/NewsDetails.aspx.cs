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
    public partial class NewsDetails : System.Web.UI.Page
    {
        public int id;
        public Model.ArticleCategory categoryModel = null;
        protected Model.Article model = null;
        protected string _prev = null;
        protected string _next = null;
        protected string _categorypath = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show();
            }
        }
        private void Show()
        {
            
            int page = RequestHelper.GetPageIndex();
            
            if (string.IsNullOrEmpty(Request.QueryString["nid"])) Response.Redirect("index.aspx");
            //model = Lib.Article.GetModel(int.Parse(Request.QueryString["nid"]));
             model = BLL.Article.GetModel(int.Parse(Request.QueryString["nid"]));
            if (model == null) Response.Redirect("index.aspx");
            id = model.CategoryID;
            Model.ArticleCategory category = BLL.ArticleCategory.GetModel(model.CategoryID);
            //categoryModel = BLL.ArticleCategory.GetModel(category.ParentID.Value);

            //if (category != null)
            //{
            //    _categorypath = string.Format("<a href='{0}'>{1}</a>", Urls.News(category.Id), category.Name);
            //    //NewsCategory.SelectedCid = category.Id;
            //}
            //model.ViewCount = model.ViewCount.Value + 1;
            //BLL.Article.Update(model);

            //rptList1.DataSource = BLL.ArticleCategory.GetList(0, "IsShow=True and ParentID=" + categoryModel.Id + " and Lan=" + Lan.GetLangID(), "Sort").Tables[0];
            //rptList1.DataBind();
            //上一个，下一个
            DataTable dtPrev = BLL.Article.GetPrev(model.Id);
            DataTable dtNext = BLL.Article.GetNext(model.Id);

            if (dtPrev.Rows.Count > 0)
            {
                _prev = string.Format("<a href=\"{0}\">{1}</a>", Urls.NewsDetails(dtPrev.Rows[0]["Id"].ToString()), dtPrev.Rows[0]["Title"].ToString());
            }
            if (dtNext.Rows.Count > 0)
            {
                _next = string.Format("<a href=\"{0}\">{1}</a>", Urls.NewsDetails(dtNext.Rows[0]["Id"].ToString()), dtNext.Rows[0]["Title"].ToString());
            }
        }

     
    }
}