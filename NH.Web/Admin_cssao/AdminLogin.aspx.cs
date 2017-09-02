using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.Admin_cssao
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //地区
                //this.ltrJobAddress_search.Text = BLL.Area.BuildFullAreaOption("," + Request.QueryString["area"] + ",");
                HttpCookie hc1 = Request.Cookies["remember_name"];
                if (hc1 != null && !string.IsNullOrEmpty(hc1.Value))
                {
                    txtUsername.Text = HttpUtility.HtmlDecode(hc1.Value);
                }
            }
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string loginname = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            //string code = txtCode.Text.Trim().ToLower();
            //HttpCookie hc = Request.Cookies["vcadm"];
            if (loginname == "")
            {
                MessageBox.Show("请输入用户名"); return;
            }
          
              //if (NH.BLL.AUser.Exists())
            if (password == "")
            {
                MessageBox.Show("请输入密码"); return;
            }

            //if (hc == null || Utility.EncryptValidateCode(code) != hc.Value)
            //{
            //    MessageBox.Show("验证码不正确"); return;
            //}
          
                if (UserBase.AdminLogin(loginname, password))//检测账号密码是否正确
                {
                    if (Request.Form["cbRemeber"] == "1")
                    {
                        HttpCookie hc = new HttpCookie("remember_name", HttpUtility.HtmlEncode(loginname));
                        hc.Expires = DateTime.Now.AddYears(1);
                        Response.Cookies.Add(hc);
                    }
                    else
                    {
                        HttpCookie hc = new HttpCookie("remember_name");
                        hc.Expires = DateTime.Now.AddYears(-1);
                        Response.Cookies.Add(hc);
                    }
                    Model.AUser model = new Model.AUser();
                    
                    model.Id = UserBase.CurAdmin.Id;
                    model.LastIP = UserBase.CurAdmin.LoginIP;
                    //model.VerifyStatus = UserBase.CurAdmin.VerifyStatus;

                    //if (UserBase.CurAdmin.VerifyStatus == 0) { MessageBox.Show("等待审核"); }//是否审核
                    //else if (UserBase.CurAdmin.VerifyStatus == -1) { MessageBox.Show("审核不通过"); return; }

                    if (UserBase.CurAdmin.Status == 0) //状态
                    {
                        MessageBox.Show("用户已禁用，请联系客服！"); return; 
                    }
                    //model.LastArea = UserBase.CurAdmin.LoginArea;
                    model.LastLoginTime = UserBase.CurAdmin.LoginTime;
                    model.LoginIP = RequestHelper.GetIP();
                    //model.LoginArea = new IPScanner(model.LoginIP).IPLocation();
                    model.LoginTime = DateTime.Now;
                    model.LoginCount = UserBase.CurAdmin.LoginCount + 1;

                    BLL.AUser.Update(model);
                    //写系统日志
                    Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
                    MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
                    MyRiZhi.DoSomething = "(" + UserBase.CurAdmin.LoginName + ") 登录系统";
                    MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                    BLL.ERPRiZhi.Add(MyRiZhi);


                    Response.Redirect("Default.aspx");
                }
                else
                {
                    MessageBox.Show("登录失败"); return;
                }
        }

     
    }
}