using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Person
{
    public partial class PersonReg : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }

      
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string Source = txtSource.Text.Trim();
            string LoginName = txtLoginName.Text.Trim();

            if (LoginName == "")
            {
                Maticsoft.Common.Ajax.WriteError("请填写联系人！");
            }
         
            Model.User tempUser = new Model.User();
            tempUser.LoginName = LoginName;
          
            string Text1 = Request.Form["txtText1"].Trim();
            string Environment = Request.Form["txtEnvironment"].Trim();
            //手机
            string phone = txtMobile.Text.Trim();
            if (phone == "")
            {
                Maticsoft.Common.Ajax.WriteError("请填写手机号！");
            }

            //if (phone != "")
            //{
            //    Model.User tempMember = new Model.User();
            //    tempMember.Phone = phone;
            //    if (BLL.User.Exists(tempMember))
            //    {
            //        Maticsoft.Common.Ajax.WriteError("此手机号已被使用！");
            //    }
            //}

            //性别
            int sex = int.Parse(rblSex.SelectedValue);
          
            //qq
            string qq = Request.Form["txtQQ"].Trim();
          
            //email
            string email = Request.Form["txtEmail"].Trim();
            //if (email == "") { Maticsoft.Common.Ajax.WriteError("请填写邮箱"); }
            //if (!PageValidate.IsEmail(email)) { Maticsoft.Common.Ajax.WriteError("邮箱格式不正确"); }
            //联系地址
            string address = Request.Form["txtAddress"].Trim();

            Model.User user = new Model.User();
            user.LoginName = LoginName;
            user.Text1 = Text1;//微信 
            user.Environment = Environment;
            user.Source = Source;
            user.LoginIP = RequestHelper.GetIP();
            user.LoginAddress = new IPScanner(user.LoginIP).IPLocation();
            user.UserType = 1;
            user.Sex = sex;
            user.Address = address;
            user.Phone = phone;
            user.QQ = qq;
            user.Email = email;
            
            //user.IsVerify = false;
            //user.VerifyStatus = 1;

            int roleId = BLL.User.Add(user);

            if (roleId > 0)
            {//写系统日志
                Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
                MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
                MyRiZhi.DoSomething = "添加客户(" + LoginName + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                BLL.ERPRiZhi.Add(MyRiZhi);
                Maticsoft.Common.Ajax.WriteOk("保存成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("保存失败");
            }
        }
        private string ReplaceBlankChar(string str)
        {
            return str.Replace("\n", "").Replace("\r", "").Replace(" ", "").Replace("　", "");
        }
    }
}