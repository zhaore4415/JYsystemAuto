using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.OnlineService
{
    public partial class Contact : WebBase.Edit
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
            Model.Config model = BLL.Config.GetModel(1);
            txtServiceTel1.Text = model.ServiceTel1;
            txtServiceTel2.Text = model.ServiceTel2;
            txtFriendLinkContact.Text = model.FriendLinkContact;
            ckContact.Text = model.ContactDesc;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.Config model = new Model.Config();
            model.Id = 1;
            model.ServiceTel1 = txtServiceTel1.Text;
            model.ServiceTel2 = txtServiceTel2.Text;
            model.FriendLinkContact = txtFriendLinkContact.Text;
            model.ContactDesc = ckContact.Text;

            if (BLL.Config.Update(model))
            {
                DataCache.RemoveDependencyFile("Config");
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }
    }
}