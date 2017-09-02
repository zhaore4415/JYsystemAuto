using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Maticsoft.Common;

namespace NH.Web.adm.Company
{
    public partial class CompanyVerify : WebBase.Edit
    {
        protected string smallfolder = "/Upload/CompanyFace/Small/";
        protected int _verifyStatus = 0;
        protected int _newinfoVerifyStatus = 1;
        protected int _identitystatus = 0;
        protected bool _hasPhoto = false;
        protected int _photoVerifyStatus = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request["action"])
            {
                case "verify":
                    Verify();
                    break;
                default:
                    Show();
                    break;
            }
        }


        private void Show()
        {
            #region 资料
            Model.User user = BLL.User.GetModel(Id);
            if (user == null || (Model.Enums.UserType)user.UserType != Model.Enums.UserType.Company) return;

            Model.Company company = BLL.Company.GetModel(user.Id);
            if (company == null) return;

            SetLableText(lbLoginName, user.LoginName);
            SetLableText(lbCompanyName, company.CompanyName);
            SetLableText(lbContact, company.Contact);
            SetLableText(lbEmail, company.Email);
            SetLableText(lbQQ, company.QQ);
            SetLableText(lbPhone, company.Phone);
            SetLableText(lbOtherPhone, company.OtherPhone);
            SetLableText(lbAddress, company.Address);
            //SetLableText(lbHomePage, company.HomePage);
            //SetLableText(lbSpace, company.Space);
            //SetLableText(lbEmployeeQty, company.EmployeeQty);
            //SetLableText(lbCamera, company.Camera);
            //SetLableText(lbStudio, company.Studio);
            SetLableText(lbDescription, company.Description);

            lbArea.Text = company.Area;

            //状态
            _verifyStatus = company.VerifyStatus;
            //lbVerifyStatus.Text = WebBase.ModelEnum.VerifyStatusDesc((WebBase.ModelEnum.VerifyStatus)company.VerifyStatus);
            #endregion

            #region 头像
            _photoVerifyStatus = user.PhotoVerifyStatus;
            if (user.PhotoVerifyStatus == 1)
            {
                imgFace.ImageUrl = smallfolder + user.Photo;
                imgFace.Visible = true;
                _hasPhoto = true;
            }
            else
            {
                if (File.Exists(Server.MapPath(smallfolder + user.PhotoNew)))
                {
                    imgFace.ImageUrl = smallfolder + user.PhotoNew;
                    imgFace.Visible = true;
                    _hasPhoto = true;
                }
            }
            #endregion

            #region 实名认证
            BindIdentity();
            #endregion

            #region 企业新资料
            if (company.VerifyStatus == 0)
            {
                _newinfoVerifyStatus = 0;
            }
            else
            {
                BindNewInfo();
            }
            #endregion

            #region 企业相册
            BindAlbum();
            #endregion

            #region 职位
            BindJobs();
            #endregion

            #region
            /*
            _loginStatus = user.Status;
            switch (user.Status)
            {
                case 1:
                    lbStatus.Text = "正常";
                    break;
                case 0:
                    lbStatus.Text = "禁用";
                    break;
                case -1:
                    lbStatus.Text = "已删除";
                    break;
            }
            */
            #endregion
        }

        #region
        private void SetLableText(Label obj, string text)
        {
            if (text.Trim() != "")
                obj.Text = HtmlEncode(text).Replace("\n", "<br/>");
        }
        private void SetLableText2(Label obj, string text)
        {
            if (text.Trim() != "")
                obj.Text = "【新内容】<br/>" + HtmlEncode(text).Replace("\n", "<br/>");//text.Replace("\n", "<br/>");// + HtmlEncode(text.Replace("\n","<br/>"));
        }
        #endregion

        #region 绑定实名认证
        private void BindIdentity()
        {
            Model.CompanyVerify model = new Model.CompanyVerify() { CompanyID = Id };
            model = BLL.CompanyVerify.GetModel(model);
            if (model != null)
            {
                lbIdentityStatus.Text = WebBase.ModelEnum.VerifyStatusDesc((WebBase.ModelEnum.VerifyStatus)model.Status);
                lbIdentityLicenceNo.Text = model.LicenceNo;
                lbIdentityExpireDate.Text = model.ExpireDate.ToString("yyyy-MM-dd");
                lbIdentityContact.Text = model.Contact;
                lbIdentityTel.Text = model.Tel;
                lbIdentityQQ.Text = model.QQ;
                string filepath = "/Upload/CompanyLicence/" + model.LicenceImg;
                if (File.Exists(Server.MapPath(filepath)))
                {
                    imgIdentity.ImageUrl = filepath;
                    imgIdentity.Visible = true;
                }
                _identitystatus = model.Status;

                phContent.Visible = true;
            }
            else
            {
                phContent.Visible = false;
            }
        }
        #endregion

        #region 绑定新资料
        private void BindNewInfo()
        {
            Model.CompanyNewInfo model = new Model.CompanyNewInfo();
            model.Id = Id;
            model.Status = 0;

            model = BLL.CompanyNewInfo.GetModel(model);

            if (model != null)
            {
                _newinfoVerifyStatus = model.Status;
                SetLableText2(lbCompanyName_new, model.CompanyName);
                SetLableText2(lbContact_new, model.Contact);
                SetLableText2(lbEmail_new, model.Email);
                SetLableText2(lbQQ_new, model.QQ);
                SetLableText2(lbPhone_new, model.Phone);
                SetLableText2(lbOtherPhone_new, model.OtherPhone);
                SetLableText2(lbAddress_new, model.Address);
                //SetLableText2(lbHomepage_new, model.HomePage);
                //SetLableText2(lbSpace_new, model.Space);
                //SetLableText2(lbEmployeeQty_new, model.EmployeeQty);
                //SetLableText2(lbCamera_new, model.Camera);
                //SetLableText2(lbStudio_new, model.Studio);
                SetLableText2(lbDescription_new, model.Description);

            }
            else
            {
                _newinfoVerifyStatus = 1;
            }
        }
        #endregion


        #region 绑定相册
        private void BindAlbum()
        {
            rptAlbums.DataSource = BLL.CompanyAlbum.GetList(0, "CompanyID=" + Id.ToString(), "Status,Sort asc");
            rptAlbums.DataBind();
        }
        #endregion

        #region 绑定职位
        private void BindJobs()
        {
            rptJobList.DataSource = DataUtility.GetList(
                "Job j(nolock) left join JobCategory jc(nolock) on j.CategoryNo=jc.CategoryNo",
                "j.Id,j.CategoryNo,j.Status,j.ViewCount,j.UpdateTime,j.RefreshTime,j.AddTime,j.Verified,jc.Name JobCategoryName",
                0,
                1,
                "j.Id",
                "and j.Status<>-1 and CompanyID=" + Id.ToString(),
                "order by j.Status",
                false);

            rptJobList.DataBind();
        }
        #endregion

        private void Verify()
        {
            VerifyPhoto();
            VerifyNewInfo();
            VerifyJob();
            VerifyAlbum();
            VerifyIdentity();

            BLL.Company.UpdateComplete(Id);
            BLL.Company.UpdateCompanyIsVerify(Id);
            Maticsoft.Common.Ajax.WriteOk("审核成功");
        }

        #region 审核头像
        private void VerifyPhoto()
        {
            string status = Request.Form["photo"];
            if (string.IsNullOrEmpty(status)) return;

            Model.User user = BLL.User.GetModel(Id);
            user.PhotoVerifyStatus = int.Parse(status);
            if (status == "1")
            {
                //当前头像
                string currentFacePath = smallfolder + user.Photo;
                if (File.Exists(Server.MapPath(currentFacePath)) && user.Photo != user.PhotoNew)
                {
                    File.Delete(Server.MapPath(currentFacePath));
                }
                user.Photo = user.PhotoNew;
                user.PhotoVerifyStatus = 1;
                user.PhotoNew = "";
            }
            BLL.User.Update(user);
        }
        #endregion

        #region 审核资料
        private void VerifyNewInfo()
        {
            string status = Request.Form["info"];
            if (string.IsNullOrEmpty(status)) return;

            BLL.CompanyNewInfo.VerifyNewInfo(Id, int.Parse(status));
        }
        #endregion

        #region 审核相册
        private void VerifyAlbum()
        {
            string ids = Request.Form["al"];
            string vals = Request.Form["al_v"];
            if (string.IsNullOrEmpty(ids)) return;

            string[] arrayIds = ids.Split(',');
            string[] arrayVals = vals.Split(',');

            for (int i = 0; i < arrayIds.Length; i++)
            {
                Model.CompanyAlbum model = new Model.CompanyAlbum();
                model.Id = int.Parse(arrayIds[i]);
                model.Status = int.Parse(arrayVals[i]);

                BLL.CompanyAlbum.Update(model);
            }
        }
        #endregion

        #region 实名认证
        private void VerifyIdentity()
        {
            string identity = Request.Form["identity"];
            if (string.IsNullOrEmpty(identity)) return;

            Model.CompanyVerify model = BLL.CompanyVerify.GetModel(new Model.CompanyVerify() { CompanyID = Id });
            if (model == null) return;

            model.Status = int.Parse(identity);

            if (BLL.CompanyVerify.Update(model))
            {
                Model.Company company = new Model.Company();
                company.Id = Id;
                company.IdentityVerified = model.Status == 1;
                BLL.Company.Update(company);
            }
        }
        #endregion

        private void VerifyJob()
        {
            string ids = Request.Form["jl"];
            string vals = Request.Form["jl_v"];
            if (string.IsNullOrEmpty(ids)) return;

            string[] arrayIds = ids.Split(',');
            string[] arrayVals = vals.Split(',');

            for (int i = 0; i < arrayIds.Length; i++)
            {
                int jid = int.Parse(arrayIds[i]);
                int status = int.Parse(arrayVals[i]);

                Model.Job old = BLL.Job.GetModel(jid);
                if (old == null) return;

                Model.Job model = new Model.Job();
                model.Id = jid;
                model.Verified = status;
                if (status == 1)
                {
                    model.RefreshTime = DateTime.Now;

                    if (old.Description_New.Trim() != "")
                    {
                        model.Description = old.Description_New;
                        model.Description_New = "";
                    }

                    if (old.Jobtitle_New.Trim() != "")
                    {
                        model.JobTitle = old.Jobtitle_New;
                        model.Jobtitle_New = "";
                    }
                    if (old.SalaryDesc_New.Trim() != "")
                    {
                        model.SalaryDesc = old.SalaryDesc_New;
                        model.SalaryDesc_New = "";
                    }

                    if (old.WorkContent_New.Trim() != "")
                    {
                        model.WorkContent = old.WorkContent_New;
                        model.WorkContent_New = "";
                    }

                    if (old.Requirements_New.Trim() != "")
                    {
                        model.Requirements = old.Requirements_New;
                        model.Requirements_New = "";
                    }

                    if (old.RoomAndFood_New.Trim() != "")
                    {
                        model.RoomAndFood = old.RoomAndFood_New;
                        model.RoomAndFood_New = "";
                    }

                    if (old.Welfare_New.Trim() != "")
                    {
                        model.Welfare = old.Welfare_New;
                        model.Welfare_New = "";
                    }
                }

                BLL.Job.Update(model);
            }
        }
    }
}