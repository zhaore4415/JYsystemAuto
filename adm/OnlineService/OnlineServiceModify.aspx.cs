using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.OnlineService
{
    public partial class OnlineServiceModify : WebBase.Edit
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
            Model.OnLineService model = BLL.OnLineService.GetModel(Id);
            if (model == null) Response.Redirect(ListUrl);
            txtTitle.Text = model.Title;
            txtAccount.Text = model.Account;
            txtSort.Text = model.Sort.ToString();
            rblStatus.SelectedValue = model.IsShow.Value ? "1" : "0";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string account = txtAccount.Text.Trim();
            if (title == "") { MessageBox.Show("请填写名称"); return; }
            if (account == "") { MessageBox.Show("请填写账号"); return; }
            int sort = 0;
            try
            {
                sort = int.Parse(txtSort.Text.Trim());
            }
            catch
            {
                MessageBox.Show("排序值不正确"); return;
            }

            Model.OnLineService model = new Model.OnLineService();
            model.Title = title;
            model.Account = account;
            model.Sort = sort;
            model.IsShow = rblStatus.SelectedValue == "1";

            model.Id = Id;

            if (BLL.OnLineService.Update(model))
            {
                MessageBox.ShowAndRedirect("修改成功", ListUrl);
                DataCache.RemoveDependencyFile("OnLineService_QQ");
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }
    }
}