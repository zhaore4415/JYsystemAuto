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
    public partial class Registered2 : MemberBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                show();
        }
        private void show()
        {
            if (Session["CurrentUser"] != null) 
            {
                txtLoginName.Value = UserBase.Current.LoginName;
                txtPhone.Value = UserBase.Current.Phone;
                if (UserBase.Current.Sex == 1)
                    txtSex1.Checked = true;
                else
                    txtSex2.Checked = true;

                txtEmail.Value= UserBase.Current.Email;
                txtAddress.Value= UserBase.Current.Address;

                txtIdNumber.Value = UserBase.Current.IdNumber;
                txtOpenbank.Value = UserBase.Current.Openbank;
                txtOpenbankCard.Value = UserBase.Current.OpenbankCard;
                txtOpenCity.Value = UserBase.Current.OpenCity;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string LoginName = txtLoginName.Value;

            string password = Request.Form["zcPassWord"];
            string password2 = Request.Form["zcRPassWord"];
            //string source = Request.Form["zcSource"];
            Match m;
            string phone = Request.Form["zcPhone"];
            //PageValidate.IsStr(phone,delegate(string phone1){
            //    m = new Regex("^[0-9]+[-]?[0-9]+[-]?[0-9]$").Match(phone);
            //    return m.Success;
            //});
            //string qqweixin = Request.Form["zcQQWinXin"];
            //string companyname = Request.Form["zcCompany"];
            string email = Request.Form["zcEmail"];

            //string address = txtAddress.Text.Trim();
            string tjCode = "";
            if (Request.Form["TJCode"] != null)
            {
                tjCode = Request.Form["TJCode"];
            }

            //if (string.IsNullOrEmpty(username))
            //{
            //    MessageBox.Show("请填写用户名"); return;
            //}
            //if (string.IsNullOrEmpty(password))
            //{
            //    MessageBox.Show("请填写密码"); return;
            //}
            //if (password != password2)
            //{
            //    MessageBox.Show("两次输入的密码不一致"); return;
            //}

            if (BLL.User.Exists(new Model.User() { LoginName = LoginName }))
            {
                MessageBox.Show("此用户名已被注册"); return;
            }

            int d_id = 0;
          

            Model.User model = new Model.User();
            model.LoginName = LoginName;
            model.Password = DESEncrypt.Encrypt(password);
            //model.Source = source;
            //model.CompanyName = companyname;
          
            model.Email = email;
            //model.QQWeiXin = qqweixin;
      
            Model.User modsj = BLL.User.GetModel(d_id);
          
            model.Status = 1;   //状态
        
            model.AddTime = DateTime.Now;
            BLL.User.Add(model);
            //int userId = BLL.AUser.Add(model);

            //if (userId > 0 && model.RoleType == 0)
            //{
            //    //添加用户角色

            //    //Model.UserRole userRole = new Model.UserRole();
            //    //userRole.UserId = userId;
            //    //userRole.RoleId = 35;

            //    //BLL.UserRole.Add(userRole);

            //}
            MessageBox.ShowAndRedirect("注册成功！", "AdminLogin.aspx");

        }
    }
}