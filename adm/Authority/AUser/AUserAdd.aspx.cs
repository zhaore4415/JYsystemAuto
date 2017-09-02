using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Authority.AUser
{
    public partial class AUserAdd : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRoles();
            }
        }

        private void BindRoles()
        {
            chkRoles.DataSource = BLL.Role.GetAllList().Tables[0];
            chkRoles.DataValueField = "Id";
            chkRoles.DataTextField = "RoleName";
            chkRoles.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string loginame = txtLoginName.Text.Trim();
            string password1 = txtPassword1.Text.Trim();
            string password2 = txtPassword2.Text.Trim();
            string realname = txtRealname.Text.Trim();

            if (loginame == "")
            {
                MessageBox.Show("请填写登录名"); return;
            }
            Model.AUser u = new Model.AUser() { LoginName = loginame };
            u = BLL.AUser.GetModel(u);
            if (u != null && u.Status != (int)WebBase.ModelEnum.AUserStatus.Delete)
            {
                MessageBox.Show("登录名已存在"); return;
            }
            if (password1 != password2)
            {
                MessageBox.Show("两次输入的密码不一致"); return;
            }

            Model.AUser model = new Model.AUser();
            model.LoginName = loginame;
            model.Password = DESEncrypt.Encrypt(password1);
            model.Realname = realname;
            model.RoleType = int.Parse(rblRoleType.SelectedValue);

            int userId = BLL.AUser.Add(model);

            if (userId > 0 && model.RoleType == 0)
            {
                //添加用户角色
                for (int i = 0; i < chkRoles.Items.Count; i++)
                {
                    if (chkRoles.Items[i].Selected)
                    {
                        Model.UserRole userRole = new Model.UserRole();
                        userRole.UserId = userId;
                        userRole.RoleId = int.Parse(chkRoles.Items[i].Value);

                        BLL.UserRole.Add(userRole);
                    }
                }
                
            }
            MessageBox.ShowAndRedirect("添加成功",ListUrl);
        }
    }
}