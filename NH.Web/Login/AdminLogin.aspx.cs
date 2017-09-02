using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.Login
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string returnUrl = Request.QueryString["ReturnUrl"];
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string loginname = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string code = txtCode.Text.Trim().ToLower();
            HttpCookie hc = Request.Cookies["vcadm"];
            if (loginname == "")
            {
                MessageBox.Show("请输入用户名"); return;
            }
            if (password == "")
            {
                MessageBox.Show("请输入密码"); return;
            }

            if (hc == null || Utility.EncryptValidateCode(code) != hc.Value)
            {
                MessageBox.Show("验证码不正确"); return;
            }
                        
            if (UserBase.AdminLogin(loginname, password))
            {
                Model.AUser model = new Model.AUser();
                model.Id = UserBase.CurAdmin.Id;
                model.LastIP = UserBase.CurAdmin.LoginIP;
                model.LastAddress = UserBase.CurAdmin.LoginAddress;
                model.LastLoginTime = UserBase.CurAdmin.LoginTime;
                model.LoginIP = RequestHelper.GetIP();
                model.LoginAddress = new IPScanner(model.LoginIP).IPLocation();
                model.LoginTime = DateTime.Now;
                model.LoginCount = UserBase.CurAdmin.LoginCount + 1;

                BLL.AUser.Update(model);

                Response.Redirect(AUrls.Default());
            }
            else
            {
                MessageBox.Show("登录失败"); return;
            }
        }
    }
}