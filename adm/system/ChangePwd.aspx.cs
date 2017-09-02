using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm
{
    public partial class ChangePwd : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string oldpassword = txtOldPassword.Text.Trim();
            string password1 = txtPassword1.Text.Trim();
            string password2 = txtPassword2.Text.Trim();
            if (oldpassword == "") 
            {
                MessageBox.Show("请输入旧密码"); return;
            }
            if (password1 == "")
            {
                MessageBox.Show("请输入新密码"); return;
            }
            if (password1 != password2)
            {
                MessageBox.Show("两次输入的新密码不一致，请重新输入"); return; 
            }
            Model.AUser model = new Model.AUser();
            model.Id = UserBase.CurAdmin.Id;
            model.Password = DESEncrypt.Encrypt(oldpassword);
            if (!BLL.AUser.Exists(model))
            {
                MessageBox.Show("旧密码错误"); return;
            }
            model.Password = DESEncrypt.Encrypt(password1);
            if (BLL.AUser.Update(model))
            {
                MessageBox.Show("密码修改成功");
            }
            else
            {
                MessageBox.Show("密码修改失败");
            }
        }
    }
}