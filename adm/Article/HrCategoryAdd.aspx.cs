using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Article
{
    public partial class HrCategoryAdd : WebBase.Free //WebBase.Edit
    {
        int type = 5;
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
                    Response.Redirect("HrCategory.aspx");
                }
                txtName.Text = model.Name;
                txtSort.Text = model.Sort.ToString();
                rblStatus.SelectedValue = model.Status.ToString();
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
            model.CanDelete = true;
            model.Type = type;

            if (Request.QueryString["id"] == null)
            {
                if (BLL.ArticleCategory.Add(model) > 0)
                {
                    MessageBox.ShowAndRedirect("添加成功", "HrCategory.aspx");
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
                    MessageBox.ShowAndRedirect("修改成功", "HrCategory.aspx");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
        }
    }
}