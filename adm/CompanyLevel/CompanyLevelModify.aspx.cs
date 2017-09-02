using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.CompanyLevel
{
    public partial class CompanyLevelModify : WebBase.Edit
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
            Model.CompanyLevel model = BLL.CompanyLevel.GetModel(Id);
            if (model == null) Response.Redirect(ListUrl);
            txtName.Text = model.LevelName;
            txtPrice.Text = model.Price.ToString();
            txtDesc.Text = model.Description;
            txtDesc2.Text = model.Description2;
            if (model.Id == 6)
            {
                phDesc2.Visible = true;
            }
            else
            {
                phDesc2.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string levelname = txtName.Text.Trim();
            string description = txtDesc.Text;
            decimal price = 0;
            if (levelname == "")
            {
                MessageBox.Show("请填写等级名称"); return;
            }
            try
            {
                price = decimal.Parse(txtPrice.Text.Trim());
            }
            catch
            {
                MessageBox.Show("价格不正确"); return;
            }

            Model.CompanyLevel model = new Model.CompanyLevel();
            model.LevelName = levelname;
            model.Price = price;
            model.Description = description;
            model.Description2 = txtDesc2.Text;

            model.Id = Id;
            if (BLL.CompanyLevel.Update(model))
            {
                DataCache.RemoveDependencyFile("AllCompanyLevels");
                MessageBox.ShowAndRedirect("修改成功", ListUrl);
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

    }
}