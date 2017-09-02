using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Article
{
    public partial class ArticleModify : WebBase.Edit //WebBase.Edit
    {
        protected string _type = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("InfomationManage");
            if (!IsPostBack)
            {
                //int categoryId = int.Parse(Request.QueryString["cid"]);
                //Model.ArticleCategory category = BLL.ArticleCategory.GetModel(categoryId);
                //lbCategoryName.Text = category.Name;

                Show();

            }
        }

        private void Show()
        {
            Model.Article model = BLL.Article.GetModel(Id);
            if (model == null) Response.Redirect(ListUrl);

            txtTitle.Text = model.Title;
            txtUrl.Text = model.Url;
            ckContent.Text = model.Description;
            rblStatus.SelectedValue = model.Status.ToString();

            BindCategory();

            try
            {
                ddlCategory.SelectedValue = model.CategoryID.ToString();
            }
            catch
            { }
        }

        private void BindCategory()
        {
            ddlCategory.DataSource = BLL.ArticleCategory.GetList(0, "Type=3", "Sort");
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("选择分类", "0"));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string url = txtUrl.Text.Trim();
            string description = ckContent.Text;
            int status = int.Parse(rblStatus.SelectedValue);
            int categoryId = int.Parse(ddlCategory.SelectedValue);
            if (categoryId == 0)
            {
                MessageBox.Show("请选择所属分类"); return;
            }

            Model.Article model = new Model.Article();
            model.Title = title;
            model.Url = url;
            model.Description = description;
            model.Status = status;
            model.CategoryID = int.Parse(ddlCategory.SelectedValue);
            model.IsHilight = chkHilight.Checked;
            model.UpdateTime = DateTime.Now;

            model.Id = Id;
            if (BLL.Article.Update(model))
            {
                MessageBox.ShowAndRedirect("修改成功", ListUrl);
            }
            else
            {
                MessageBox.Show("修改失败");
            }

        }
    }
}