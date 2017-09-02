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
    public partial class AUserAdd : WebBase.List
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string loginame = txtLoginName.Text.Trim();
            string password1 = txtPassword1.Text.Trim();
            //string password2 = txtPassword2.Text.Trim();
            string realname = txtRealname.Text.Trim();
            string zhekou = txtZheKou.Text.Trim();
            string tjzhekou = txtTJZheKou.Text.Trim();
            if (loginame == "")
            {
                MessageBox.Show("请填写用户帐号"); return;
            }
            Model.AUser u = new Model.AUser() { LoginName = loginame };
            u = BLL.AUser.GetModel(u);
            if (u != null && u.Status != (int)WebBase.ModelEnum.AUserStatus.Delete)
            {
                MessageBox.Show("用户帐号已存在"); return;
            }
            if (zhekou == "") { zhekou = "1"; }
            else { zhekou = txtZheKou.Text.Trim(); }
            if (tjzhekou == "") { tjzhekou = "1"; }
            else { tjzhekou = txtTJZheKou.Text.Trim(); }
            //if (password1 != password2)
            //{
            //    MessageBox.Show("两次输入的密码不一致"); return;
            //}

            Model.AUser model = new Model.AUser();
            model.LoginName = loginame;
            model.Password = DESEncrypt.Encrypt(password1);
            model.Realname = realname;
            model.JeFen = int.Parse(txtJeFen.Text);
            model.RoleType = int.Parse(rblRoleType.SelectedValue);
            //model.Department = bumen.SelectedValue;

            model.Sex = Sex.SelectedValue == "男" ? 0 : 1;

            //个人信息
            model.Born = Request.Form["Wdate"].Trim();

            model.Email = txtEmail.Text.Trim();
            model.ShouJi = txtShouJi.Text.Trim();
            model.Source = zcSource.Text.Trim();
            model.QQWeiXin = zcQQWinXin.Text.Trim();
            model.CompanyName = zcCompany.Text.Trim();
            model.fk_id = int.Parse(Request.Form.Get("ddlBranchOne"));
            model.sk_id = int.Parse(Request.Form.Get("ddlBranchTwo"));
            model.tk_id = int.Parse(Request.Form.Get("ddlBranchThird"));
            model.JiaTingAddress = txtJiaTingAddress.Text.Trim();

            model.Notes = txtNotes.Text.Trim();
            model.ZheKou = decimal.Parse(zhekou);
            model.TJZheKou = decimal.Parse(tjzhekou);
            model.IsPayment = RbnIsPayment.SelectedValue == "0" ? 0 : 1;
            model.Status = RbnStatus.SelectedValue == "0" ? 0 : 1;
            switch (RbnVerifyStatus.SelectedValue)
            {
                case "0":
                    { model.VerifyStatus = 0; model.IsCheck = 0; break; }
                case "1":
                    { model.VerifyStatus = 1; model.IsCheck = 2; break; }
                case "-1":
                    { model.VerifyStatus = -1; model.IsCheck = 0; break; }
            } 
            switch (lbListType.SelectedValue)
            {
                case "1": model.IsCheckType = 1; break;
                case "2": model.IsCheckType = 2; break;
                case "3": model.IsCheckType = 3; break;
                case "4": model.IsCheckType = 4; break;
                default: model.IsCheckType = 1; break;
            }

            int userId = BLL.AUser.Add(model);
            //写系统日志
            Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
            MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
            MyRiZhi.DoSomething = "添加用户信息(" + loginame + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            BLL.ERPRiZhi.Add(MyRiZhi);
            //if (userId > 0 && model.RoleType == 0)
            //{
            //    //添加用户角色
            //    for (int i = 0; i < chkRoles.Items.Count; i++)
            //    {
            //        if (chkRoles.Items[i].Selected)
            //        {
            //            Model.UserRole userRole = new Model.UserRole();
            //            userRole.UserId = userId;
            //            userRole.RoleId = int.Parse(chkRoles.Items[i].Value);

            //            BLL.UserRole.Add(userRole);
            //        }
            //    }

            //}
            MessageBox.ShowAndRedirect("添加成功", ListUrl);
        }

    }
}