using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.JobCategory
{
    public partial class JobCategoryAdd : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategory();
            }
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
            Model.JobCategory model = new Model.JobCategory();
            model.Name = txtName.Text.Trim();
            model.CategoryNo = BLL.JobCategory.GetMaxCategoryNo(parentNo);
            model.ParentNo = parentNo;
            model.Sort = BLL.JobCategory.GetMaxSort(parentNo);
            model.Status = int.Parse(rblStatus.SelectedValue);

            if (BLL.JobCategory.Add(model) > 0)
            {
                DataCache.RemoveDependencyFile("JobCategory");
                MessageBox.ShowAndRedirect("添加成功", ListUrl);
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }
    }
}