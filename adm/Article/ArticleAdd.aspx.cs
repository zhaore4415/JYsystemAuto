using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Article
{
    public partial class ArticleAdd : WebBase.Free //WebBase.Edit
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

                BindCategory();

            }
        }

        private void BindCategory()
        {
            ddlCategory.DataSource = BLL.ArticleCategory.GetList(0,"Type=3","Sort");
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("选择分类","0"));
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
            model.AddUserId = UserBase.CurAdmin.Id;

            if (BLL.Article.Add(model) > 0)
            {
                MessageBox.ShowAndRedirect("添加成功", ListUrl);
            }
            else
            {
                MessageBox.Show("添加失败");
            }

        }
    }
}
