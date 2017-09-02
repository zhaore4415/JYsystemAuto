using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.system
{
    public partial class EmailConfigModify : WebBase.Edit
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
            Model.EmailConfig model = BLL.EmailConfig.GetModel(Id);
            if (model == null)
            {
                Response.Redirect(ListUrl);
            }
            txtServer.Text = model.Server;
            txtAccount.Text = model.Account;
            //txtPassword.Text = DESEncrypt.Decrypt(model.Password);
            txtPort.Text = model.Port;
            txtSender.Text = model.Sender;
            rblAuthentication.SelectedValue = model.Authentication.Value ? "1" : "0";
            rblSSL.SelectedValue = model.EnableSsl.Value ? "1" : "0";
            rblIsShow.SelectedValue = model.IsShow.Value ? "1" : "0";

            txtAccount.Attributes.Add("autocomplete", "off");
            txtPassword.Attributes.Add("autocomplete", "off");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string server = txtServer.Text.Trim();
            string account = txtAccount.Text.Trim();
            string password = txtPassword.Text.Trim();
            string port = txtPort.Text.Trim();
            string Sender = txtSender.Text.Trim();
            bool isauthentication = rblAuthentication.SelectedValue == "1";
            bool isSSL = rblSSL.SelectedValue == "1";
            bool isShow = rblIsShow.SelectedValue == "1";

            if (server == "")
            {
                MessageBox.Show("请填写SMTP服务器名称"); return;
            }
            if (account == "")
            {
                MessageBox.Show("请填写邮箱账号"); return;
            }
            //if (password == "")
            //{
            //    MessageBox.Show("请填写邮箱密码"); return;
            //}
            if (port == "")
            {
                MessageBox.Show("请填写端口号"); return;
            }

            Model.EmailConfig model = new Model.EmailConfig();
            model.Server = server;
            model.Account = account;
            if (password != "")
            {
                model.Password = DESEncrypt.Encrypt(password);
            }
            model.Port = port;
            model.Sender = Sender;
            model.Authentication = isauthentication;
            model.EnableSsl = isSSL;
            model.IsShow = isShow;

            model.Id = Id;

            if (BLL.EmailConfig.Update(model))
            {
                DataCache.RemoveDependencyFile("EmailConfig");
                MailSender.ClearEmailList();
                MessageBox.Show("修改成功"); return;
            }
            else
            {
                MessageBox.Show("修改失败"); return;
            }
        }

    }
}