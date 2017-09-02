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
    public partial class SolutionList : WebBase.Free
    {
        protected string _pager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("InfomationManage");
            if (!IsPostBack)
            {
                BindCategory();
                BindList();
                txtKey.Text = Request.QueryString["key"];
            }
        }

        private void BindCategory()
        {
            DataTable dt = BLL.ArticleCategory.GetList(0, "Type=6", "Sort asc").Tables[0];
            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("请选择分类", "0"));

            try
            {
                ddlCategory.SelectedValue = Request.QueryString["cid"];
            }
            catch
            { }
        }


        private void BindList()
        {
            int pagesize = 10;
            int page = RequestHelper.GetPageIndex();
            string strWhere = "and ac.Type=6";
            if (!string.IsNullOrEmpty(Request.QueryString["key"]))
            {
                strWhere += " and Title like '%" + Request.QueryString["key"].Trim().Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(Request.QueryString["cid"]) && PageValidate.IsNumber(Request.QueryString["cid"]))
            {
                if (Request.QueryString["cid"] != "0")
                {
                    strWhere += " and CategoryID=" + Request.QueryString["cid"];
                }
            }
            DataSet ds = BLL.Article.GetList(pagesize, page, strWhere, "order by a.Id desc");
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
            int count = (int)ds.Tables[1].Rows[0][0];

            _pager = new Pager(pagesize, count).Create();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("SolutionList.aspx?key=" + txtKey.Text.Trim() + "&cid=" + ddlCategory.SelectedValue);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string strids = Request.Form["chkItem"];
            if (!string.IsNullOrEmpty(strids))
            {
                string[] ids = strids.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    Model.Article model = BLL.Article.GetModel(int.Parse(ids[i]));
                    if (model != null)
                    {
                        BLL.Article.Delete(model.Id);
                        System.IO.File.Delete(Server.MapPath("/Upload/Solution/") + model.Files);
                    }
                }
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}