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
    public partial class AUserModify : WebBase.Edit
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
            Model.AUser model = BLL.AUser.GetModel(Id);
            if (model == null) Response.Redirect(ListUrl);
            txtLoginName.Text = model.LoginName;
            txtLoginName.Enabled = false;
            txtLoginName.ReadOnly = true;
            txtRealname.Text = model.Realname;
            try
            {
                rblRoleType.SelectedValue = model.RoleType.ToString();
            }
            catch { }
            BindRoles();

            List<Model.UserRole> userRoleList = BLL.UserRole.GetModelList("UserId=" + Id.ToString());
            foreach (Model.UserRole userRole in userRoleList)
            {
                foreach (ListItem item in chkRoles.Items)
                {
                    if (item.Value == userRole.RoleId.ToString())
                    {
                        item.Selected = true;
                    }
                }
            }

            if (model.LoginName == "admin")
            {
                rblRoleType.Enabled = false;

                if (UserBase.CurAdmin.LoginName != "admin")
                {
                    txtPassword1.Enabled = txtPassword2.Enabled = false;
                    txtPassword1.ReadOnly = txtPassword2.ReadOnly = false;
                }
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
            if (password1 != password2)
            {
                MessageBox.Show("两次输入的密码不一致"); return;
            }

            Model.AUser model = new Model.AUser();
            if (password1 != "")
            {
                //密码不为空则修改密码
                model.Password = DESEncrypt.Encrypt(password1);
            }
            model.Realname = realname;
            model.RoleType = int.Parse(rblRoleType.SelectedValue);
            model.UpdateTime = DateTime.Now;

            model.Id = Id;
            if (BLL.AUser.Update(model))
            {
                BLL.UserRole.DeleteByUserId(Id);

                if (model.RoleType == 0)
                {
                    //添加用户角色
                    for (int i = 0; i < chkRoles.Items.Count; i++)
                    {
                        if (chkRoles.Items[i].Selected)
                        {
                            Model.UserRole userRole = new Model.UserRole();
                            userRole.UserId = Id;
                            userRole.RoleId = int.Parse(chkRoles.Items[i].Value);

                            BLL.UserRole.Add(userRole);
                        }
                    }

                }
            }

            MessageBox.ShowAndRedirect("修改成功", ListUrl);
        }
    }
}