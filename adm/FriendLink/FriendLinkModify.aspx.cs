using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.FriendLink
{
    public partial class FriendLinkModify : WebBase.Free //WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("InfomationManage");
            if (!IsPostBack)
            {
                Show();
            }
        }
        private void Show()
        {
            Model.FriendLink model = BLL.FriendLink.GetModel(Id);
            if (model == null) Response.Redirect(ListUrl);
            txtName.Text = model.Name;
            txtUrl.Text = model.Url;
            txtSort.Text = model.Sort.ToString();
            txtContact.Text = model.Contact;
            txtPhone.Text = model.Phone;
            rblStatus.SelectedValue = model.IsShow.Value ? "1" : "0";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.FriendLink model = new Model.FriendLink();
            string name = txtName.Text.Trim();
            string url = txtUrl.Text.Trim();
            if (name == "") { MessageBox.Show("请填写网站名称"); return; }
            if (url == "") { MessageBox.Show("请填写网址"); return; }
            if (!url.ToLower().StartsWith("http://")) { MessageBox.Show("网址必须以http://开头"); return; };
            int sort = 0;
            try
            {
                sort = int.Parse(txtSort.Text.Trim());
            }
            catch
            {
                MessageBox.Show("排序值不正确"); return;
            }
            string contact = txtContact.Text.Trim();
            string phone = txtPhone.Text.Trim();
            bool isShow = rblStatus.SelectedValue == "1";

            model.Name = name;
            model.Url = url;
            model.Sort = sort;
            model.Contact = contact;
            model.Phone = phone;
            model.IsShow = isShow;

            model.Id = Id;
            if (BLL.FriendLink.Update(model))
            {
                DataCache.RemoveDependencyFile("FriendLink");
                MessageBox.ShowAndRedirect("修改成功", ListUrl);
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }
    }
}