using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.FriendLink
{
    public partial class FriendLinkAdd : WebBase.Free //WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("InfomationManage");
            if (!IsPostBack)
            {
                txtSort.Text = BLL.FriendLink.GetMaxSort().ToString();
            }
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

            if (BLL.FriendLink.Add(model)>0)
            {
                DataCache.RemoveDependencyFile("FriendLink");
                MessageBox.ShowAndRedirect("添加成功",ListUrl);
            }
            else
            {
                MessageBox.Show("添加失败");
            }

        }
    }
}