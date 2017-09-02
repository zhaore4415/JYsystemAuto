using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Maticsoft.Common;
using System.Collections;
using System.IO;
using System.Drawing;


namespace NH.Web.adm
{
    public partial class Default : WebBase.List
    {
        protected Model.AUser model;
        protected string SerialNumber;
        protected int RoleType = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindList();
            }
        }

        private void BindList()
        {
            model = BLL.AUser.GetModel(UserBase.CurAdmin.Id);
            if (model == null) Response.Redirect(ListUrl);
            SerialNumber = model.SerialNumber.ToString();
            lbName.Text = model.LoginName;
            txtLoginName.Text = model.LoginName;
            //txtzcSource.Text = model.Source;
            rblSex.SelectedValue = model.Sex.ToString();
            txtEmail.Text = model.Email;
            txtPhone.Text = model.ShouJi;
            //txtQQWeiXin.Text = model.QQWeiXin;
            //txtCompany.Text = model.CompanyName;

            //txtShouJi.Text = model.ShouJi;
            ddlBranchOne.SelectedValue = model.fk_id.ToString();
            ddlBranchTwo.SelectedValue = model.sk_id.ToString();
            ddlBranchThird.SelectedValue = model.tk_id.ToString();
            txtJiaTingAddress.Text = model.JiaTingAddress;

            txtShenFengZheng.Text = model.ShenFengZheng;
            txtOpenbank.Text = model.Openbank;
            txtOpenbankCard.Text = model.OpenbankCard;
            txtOpenCity.Text = model.OpenCity;
            hlimg1.NavigateUrl = "";
            hlimg2.NavigateUrl = "";
            RoleType = model.RoleType;
            if (model.RoleType == 2 || model.RoleType == 1)
            { Panel1.Visible = true; }
            else
            {
                Panel1.Visible = false;
            }
            img.ImageUrl = "/Upload/AUserFile/" + model.Pic;
            //Model.RecommendCode mod = BLL.RecommendCode.GetModel(new Model.RecommendCode { U_ID = UserBase.CurAdmin.Id, Status = 1 });
            //if (mod != null)
            //{
            //    txtTJCode.Text = mod.TJCode;
            //    if (mod.Status == 1)
            //    {
            //        lbstatus.Text = "有效";
            //        lbstatus.ForeColor = Color.Green;

            //    }
            //    else
            //    { lbstatus.Text = "已失效"; lbstatus.ForeColor = Color.Red; }
            //}

        }

        protected void btnName_Click(object sender, EventArgs e)
        {
            Model.AUser model = new Model.AUser();
            model.LoginName = txtLoginName.Text.Trim();

            model.Id = UserBase.CurAdmin.Id;
            if (BLL.AUser.Update(model))
            {
                MessageBox.Show("修改成功"); BindList();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }
        protected void btnImg_Click(object sender, EventArgs e)
        {
            bool isupdate = false;
            string pic = null;
            string smallpic = null;
            if (FilePic1.HasFile)
            {
                if (!ImageHelper.IsWebImage(FilePic1.PostedFile.ContentType))
                {
                    MessageBox.Show("产品图片格式错误"); return;
                }
                pic = DateTime.Now.ToString("yyyyMMddHHmmssf") + Path.GetExtension(FilePic1.PostedFile.FileName);
                smallpic = "s_" + pic;
                isupdate = true;
            }
            //else
            //{
            //    pic = "nopic.gif";
            //}
            model = new Model.AUser();
            model.Pic = smallpic;
            model.Id = UserBase.CurAdmin.Id;
            if (isupdate && BLL.AUser.Update(model))
            {
                #region 图片处理开始
                string folder = Server.MapPath("/Upload/AUserFile/");
                if (FilePic1.HasFile)
                {
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    FilePic1.SaveAs(folder + pic);
                    if (!img.ImageUrl.ToLower().EndsWith("nopic.gif"))
                    {
                        FileHelper.DeleteFile(img.ImageUrl);

                    }
                    //保存缩略图
                    ImageHelper.ZoomAuto(folder + pic, folder + smallpic, 150, 150, "", "");
                    MessageBox.ShowAndRedirect("修改成功", Request.RawUrl); return;
                }
                #endregion 图片处理结束
            }
            else { MessageBox.Show("修改失败"); return; }
        }
        //修改密码
        protected void btnPwd_Click(object sender, EventArgs e)
        {
            string oldpassword = txtOldPassword.Text.Trim();
            string password1 = txtPassword1.Text.Trim();

            if (oldpassword == "")
            {
                MessageBox.Show("请输入旧密码"); return;
            }
            if (password1 == "")
            {
                MessageBox.Show("请输入新密码"); return;
            }

            model = new Model.AUser();
            model.Id = UserBase.CurAdmin.Id;
            model.Password = DESEncrypt.Encrypt(oldpassword);
            if (!BLL.AUser.Exists(model))
            {
                MessageBox.Show("旧密码错误"); return;
            }
            model.Password = DESEncrypt.Encrypt(password1);
            if (BLL.AUser.Update(model))
            {
                MessageBox.Show("密码修改成功"); BindList();
            }
            else
            {
                MessageBox.Show("密码修改失败");
            }
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            model = new Model.AUser();
            //model.CompanyName = txtCompany.Text.Trim();
            //model.LoginName = txtLoginName.Text.Trim();
            //model.Source = txtzcSource.Text;
            model.Sex = int.Parse(rblSex.SelectedValue);
            model.ShouJi = txtPhone.Text.Trim();
            model.Email = txtEmail.Text.Trim();
            //model.QQWeiXin = txtQQWeiXin.Text.Trim();
            model.JiaTingAddress = txtJiaTingAddress.Text.Trim();

            model.fk_id = int.Parse(Request.Form.Get("ddlBranchOne"));
            model.sk_id = int.Parse(Request.Form.Get("ddlBranchTwo"));
            model.tk_id = int.Parse(Request.Form.Get("ddlBranchThird"));

            model.ShenFengZheng = txtShenFengZheng.Text.Trim();
            model.Openbank = txtOpenbank.Text.Trim();
            model.OpenbankCard = txtOpenbankCard.Text.Trim();
            model.OpenCity = txtOpenCity.Text.Trim();
         
            model.Id = UserBase.CurAdmin.Id;
            if (BLL.AUser.Update(model))
            {
                MessageBox.Show("修改成功"); BindList();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        //protected void btnTJcode_Click(object sender, EventArgs e)
        //{
        //    Model.RecommendCode mod = BLL.RecommendCode.GetModel(new Model.RecommendCode { U_ID = UserBase.CurAdmin.Id, Status = 1 });
        //    if (mod != null)
        //    {

        //        txtTJCode.Text = mod.TJCode;
        //    }
        //    else
        //    {
        //        string[] guid = Guid.NewGuid().ToString().Split('-');
        //        string sum = "";
        //        for (int i = 0; i < guid.Length; i++)
        //        {
        //            sum += guid[i].Trim();
        //        }

        //        txtTJCode.Text = sum;

        //        BLL.RecommendCode.Add(new Model.RecommendCode { U_ID = UserBase.CurAdmin.Id, TJCode = txtTJCode.Text, AddTime = DateTime.Now, Status = 1 });

        //    }
        //    BindList();
        //}

        //protected void btnCopy_Click(object sender, EventArgs e)
        //{
        //     string values = txtTJCode.Text;
        //    //Clipboard
        //  //ClientScript.RegisterStartupScript(this.GetType(), "copy", "window.clipboardData.setData('text','" + values + "')",true);
        //  BindList();
        //}
    }
}