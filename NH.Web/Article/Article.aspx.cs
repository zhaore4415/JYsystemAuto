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
    public partial class Article : WebBase.Edit //WebBase.List
    {
        protected string _pager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("InfomationManage");
            if (!IsPostBack)
            {
                BindCategory();
                BindList();
            }
        }
        private void BindCategory()
        {
            ddlCategory.DataSource = BLL.ArticleCategory.GetList(0, "Type=3", "Sort");
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("选择分类", "0"));
        }

        private void BindList()
        {
            string strWhere = " and ac.Type=3";
            string key = Request.QueryString["key"];
            string categoryId = Request.QueryString["cid"];
            if (!string.IsNullOrEmpty(key))
            {
                strWhere += " and Title like '%" + key.Trim().Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(categoryId) && PageValidate.IsNumber(categoryId) && categoryId != "0")
            {
                strWhere += " and CategoryID=" + categoryId;
            }

            int pagesize = 10;
            int page = RequestHelper.GetPageIndex();

            DataSet ds = BLL.Article.GetList(pagesize, page, strWhere, "order by a.Id desc");
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
            int count = (int)ds.Tables[1].Rows[0][0];

            _pager = new Pager(pagesize, count).Create();

            txtKey.Text = Request.QueryString["key"];
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = ListUrl + "?key=" + txtKey.Text.Trim() + "&cid=" + ddlCategory.SelectedValue;
            Response.Redirect(url);
            //BindList();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //if (!IsDeletePower)
            //{
            //    MessageBox.Show("没有删除权限"); return;
            //}
            string strids = Request.Form["chkItem"];
            if (!string.IsNullOrEmpty(strids))
            {
                BLL.Article.DeleteList(strids);
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}