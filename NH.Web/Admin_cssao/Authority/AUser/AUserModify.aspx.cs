using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;
using System.IO;

namespace NH.Web.adm.Authority.AUser
{
    public partial class AUserModify : WebBase.List
    {
        protected Model.AUser model;
        //string folder = "/Upload/AUserFile/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show();
            }
        }

        private void Show()
        {
            model = BLL.AUser.GetModel(Id);
            if (model == null) Response.Redirect(ListUrl);
            txtLoginName.Text = model.LoginName;
            txtPassword1.Text = DESEncrypt.Decrypt(model.Password);
            //txtLoginName.AutoCompleteType
            //txtLoginName.Enabled = false;
            //txtLoginName.ReadOnly = true;
            txtRealname.Text = model.Realname;
            txtJeFen.Text = model.JeFen.ToString();
            try
            {
                rblRoleType.SelectedValue = model.RoleType.ToString();
            }
            catch { }


            Sex.SelectedValue = model.Sex == 0 ? "0" : "1";
            RbnIsPayment.SelectedValue = model.IsPayment == 0 ? "0" : "1";
            RbnStatus.SelectedValue = model.Status == 0 ? "0" : "1";
            switch (model.VerifyStatus)
            {
                case 0:
                    { RbnVerifyStatus.SelectedValue = "0"; break; }
                case 1:
                    { RbnVerifyStatus.SelectedValue = "1"; break; }
                case -1:
                    { RbnVerifyStatus.SelectedValue = "-1"; break; }
            }
            switch (model.IsCheckType)
            {
                case 1: lbListType.SelectedValue = "1"; break;
                case 2: lbListType.SelectedValue = "2"; break;
                case 3: lbListType.SelectedValue = "3"; break;
                case 4: lbListType.SelectedValue = "4"; break;
                default: lbListType.SelectedValue = "1"; break;
            }
            Wdate.Value = model.Born;
            txtEmail.Text = model.Email;
            txtShouJi.Text = model.ShouJi;
            zcSource.Text = model.Source;
            zcQQWinXin.Text = model.QQWeiXin;
            zcCompany.Text = model.CompanyName;

            ddlBranchOne.SelectedValue = model.fk_id.ToString();
            ddlBranchTwo.SelectedValue = model.sk_id.ToString();
            ddlBranchThird.SelectedValue = model.tk_id.ToString();
            txtJiaTingAddress.Text = model.JiaTingAddress;

            txtNotes.Text = model.Notes;
            txtZheKou.Text = model.ZheKou.ToString();
            txtTJZheKou.Text = model.TJZheKou.ToString();
            if (model.LoginName == "admin")
            {
                rblRoleType.Enabled = false;

                if (UserBase.CurAdmin.LoginName != "admin")
                {
                    txtPassword1.Enabled = false;
                    txtPassword1.ReadOnly = false;
                }
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
                MessageBox.Show("请填写登录名"); return;
            }
            //if (password1 != password2)
            //{
            //    MessageBox.Show("两次输入的密码不一致"); return;
            //}

            Model.AUser model = new Model.AUser();
            if (password1 != "")
            {
                //密码不为空则修改密码
                model.Password = DESEncrypt.Encrypt(password1);
            }
            if (zhekou == "") { zhekou = "1"; }
            else { zhekou = txtZheKou.Text.Trim(); }

            if (tjzhekou == "") { tjzhekou = "1"; }
            else { tjzhekou = txtTJZheKou.Text.Trim(); }

            model.LoginName = loginame;
            model.Realname = realname;
            model.JeFen = int.Parse(txtJeFen.Text);
            model.RoleType = int.Parse(rblRoleType.SelectedValue);
            model.UpdateTime = DateTime.Now;


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
                    { model.VerifyStatus = -1; model.IsCheck =0; break; }
            }
            switch (lbListType.SelectedValue)
            {
                case "1": model.IsCheckType = 1; break;
                case "2": model.IsCheckType = 2; break;
                case "3": model.IsCheckType = 3; break;
                case "4": model.IsCheckType = 4; break;
                default: model.IsCheckType = 1; break;
            }
            model.Id = Id;
            if (BLL.AUser.Update(model))
            {
                //写系统日志
                Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
                MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
                MyRiZhi.DoSomething = "修改用户信息(" + loginame + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                BLL.ERPRiZhi.Add(MyRiZhi);
                BLL.UserRole.DeleteByUserId(Id);
                Show();
            }

            MessageBox.ShowAndRedirect("修改成功", ListUrl);
        }
    }
}