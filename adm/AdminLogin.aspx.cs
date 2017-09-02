using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(DESEncrypt.Decrypt("EA0C4DEFB944E285793116F109B203CE"));//12345678
            //Response.Write(DESEncrypt.Decrypt("22A8A9D408CA8AF6"));//person
            //Response.Write(DESEncrypt.Decrypt("AE21E15825BCFEF16393C70628AE7B62"));//
            
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