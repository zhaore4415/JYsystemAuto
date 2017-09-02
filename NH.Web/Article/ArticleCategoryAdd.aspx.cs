using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Article
{
    public partial class ArticleCategoryAdd : WebBase.Edit
    {
        int type = 3;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("InfomationManage");
            if (!IsPostBack)
            {
                {
                    Show();
                }
            }
        }

        private void Show()
        {
            if (Request.QueryString["id"] != null)
            {
                Model.ArticleCategory model = BLL.ArticleCategory.GetModel(int.Parse(Request.QueryString["id"]));
                if (model == null)
                {
                    Response.Redirect("ArticleCategory.aspx");
                }
                txtName.Text = model.Name;
                txtSort.Text = model.Sort.ToString();
                rblStatus.SelectedValue = model.Status.ToString();
                ddlCanDelete.SelectedValue = model.CanDelete.Value ? "1" : "0";
            }
            else
            {
                txtSort.Text = BLL.ArticleCategory.GetMaxSort(type).ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请填写分类名称");
                return;
            }
            if (!PageValidate.IsNumber(txtSort.Text.Trim()))
            {
                MessageBox.Show("排序值只能为数字"); return;
            }

            Model.ArticleCategory model = new Model.ArticleCategory();
            model.Name = txtName.Text.Trim();
            model.Status = int.Parse(rblStatus.SelectedValue);
            model.Sort = int.Parse(txtSort.Text);
            model.CanDelete = ddlCanDelete.SelectedValue=="1";
            model.Type = type;

            if (Request.QueryString["id"] == null)
            {
                if (BLL.ArticleCategory.Add(model) > 0)
                {
                    MessageBox.ShowAndRedirect("添加成功", "ArticleCategory.aspx");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            else
            {
                model.Id = int.Parse(Request.QueryString["id"]);
                if (BLL.ArticleCategory.Update(model))
                {
                    MessageBox.ShowAndRedirect("修改成功", "ArticleCategory.aspx");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
        }
    }
}