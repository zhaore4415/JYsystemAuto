using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.Text.RegularExpressions;

namespace NH.Web.Cssao
{
    public partial class Registered1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string phone = Request.Form["Phone"];
            string password = Request.Form["Password"];


            string email = Request.Form["zcEmail"];

            //string address = txtAddress.Text.Trim();
            string Code = "";
            if (Request.Form["Code"] != null)
            {
                Code = Request.Form["Code"];
            }

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("请填写用户名"); return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("请填写密码"); return;
            }

            if (BLL.User.Exists(new Model.User() { Phone = phone }))
            {
                MessageBox.Show("此手机已被注册！"); return;
            }

            Model.User model = new Model.User();
            model.Phone = phone;
            model.Password = DESEncrypt.Encrypt(password);
            model.Status = 1;   //状态
            model.AddTime = DateTime.Now;

            if (BLL.User.Add(model) > 0)
            {

                MessageBox.ShowAndRedirect("注册成功！", "index.aspx");
            }
        }
    }
}