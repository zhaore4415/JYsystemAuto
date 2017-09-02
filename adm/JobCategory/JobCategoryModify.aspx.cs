using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.JobCategory
{
    public partial class JobCategoryModify : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show();
            }
        }

        private void Show()
        {
            BindCategory();

            Model.JobCategory model = BLL.JobCategory.GetModel(Id);
            if (model == null) Response.Redirect(ListUrl);

            txtName.Text = model.Name;
            txtSort.Text = model.Sort.ToString();
            rblStatus.SelectedValue = model.Status.ToString();
            try
            {
                ddlCategory.SelectedValue = model.ParentNo;
            }
            catch
            { }
            //if (model.ParentNo == "1")
            //{
                ddlCategory.Enabled = false;
            //}
        }

        private void BindCategory()
        {
            ddlCategory.DataSource = BLL.JobCategory.GetList(0, "ParentNo=1", "Sort").Tables[0];
            ddlCategory.DataValueField = "CategoryNo";
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("选择上级类别", "1"));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请填写类别名称"); return;
            }
            string parentNo = ddlCategory.SelectedValue;
            int sort = 0;
            try
            {
                sort = int.Parse(txtSort.Text);
            }
            catch
            {
                MessageBox.Show("排序值不正确"); return;
            }
            Model.JobCategory model = new Model.JobCategory();
            model.Name = txtName.Text.Trim();
            model.ParentNo = parentNo;
            model.Sort = sort;
            model.Status = int.Parse(rblStatus.SelectedValue);

            model.Id = Id;

            if (BLL.JobCategory.Update(model))
            {
                DataCache.RemoveDependencyFile("JobCategory");
                MessageBox.ShowAndRedirect("修改成功", ListUrl);
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }
    }
}