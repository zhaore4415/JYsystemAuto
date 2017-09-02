using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Ad
{
    public partial class AdTypeModify : WebBase.Free //WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("AdManage");
            if (!IsPostBack)
            {
                Show();
            }
        }

        private void Show()
        {
            Model.AdType model = BLL.AdType.GetModel(Id);
            if (model == null) Response.Redirect(ListUrl);

            txtName.Text = model.TypeName;
            txtRemark.Text = model.Remark;
            txtShowCount.Text = model.ShowCount.ToString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请填写名称"); return;
            }
            if (!PageValidate.IsNumber(txtShowCount.Text.Trim()))
            {
                MessageBox.Show("广告显示数量不正确"); return;
            }
            Model.AdType model = new Model.AdType();
            model.TypeName = txtName.Text.Trim();
            model.Remark = txtRemark.Text;
            model.ShowCount = int.Parse(txtShowCount.Text.Trim());
            model.Id = Id;
            if (BLL.AdType.Update(model))
            {
                DataCache.RemoveDependencyFile("Model-AdType-" + Id);
                MessageBox.ShowAndRedirect("修改成功", ListUrl);
            }
            else
            {
                MessageBox.Show("修改失败");
            }

        }
    }
}