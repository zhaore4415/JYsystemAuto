using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace NH.Web.adm.Person
{
    public partial class PersonVerify : WebBase.Edit
    {
        protected string originalfolder = "/Upload/PersonFace/Original/";
        protected string smallfolder = "/Upload/PersonFace/Small/";
        protected string _errormsg = null;
        protected int _loginStatus = 0;
        protected int _photoVerifyStatus = 0;
        protected int _newinfoVerifyStatus = 1;
        protected int _identitystatus = 0;
        protected bool _hasPhoto = false;
        protected bool _isGood = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                switch (Request["action"])
                {
                    case "verify":
                        Verify();
                        break;
                    case "SetGood":
                        SetGood();
                        break;
                    default:
                        Show();
                        break;
                }
            }
        }


        private void Show()
        {
            #region 状态判断
            int mid = Id;
            if (mid <= 0)
            {
                return;
            }

            Model.User user = BLL.User.GetModel(mid);
            Model.Member member = BLL.Member.GetModel(mid);
            if (user == null || member == null)
            {
                _errormsg = "此用户不存在";
                return;
            }

            _isGood = member.IsGood.Value;
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

            #region 基本信息
            //登录状态
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
            }*/
            //简历状态
            //lbResumeStatus.Text = member.IsShow.Value ? "开放" : "隐藏";

            lbLoginName.Text = user.LoginName;
            lbRealname.Text = member.Realname;
            lbMarriage.Text = member.MarriageString;
            lbSex.Text = member.SexString;
            //学历
            lbDegree.Text = member.DegreeName;
            //工作年限
            if (member.ExperienceID > -1)
            {
                Model.Experience exp = BLL.Experience.GetModel(member.ExperienceID);
                if (exp != null)
                    lbExperience.Text = exp.Name;
            }

            if (member.Birthday.HasValue)
            {
                lbBirthday.Text = member.Birthday.Value.ToString("yyyy-MM-dd");
            }

            //籍贯
            lbResidence.Text = member.Residence;
            //当前所在地区
            lbCurrAddr.Text = member.CurAddr;

            if (member.Height > 0)
                lbHeight.Text = member.Height.ToString();
            #endregion

            #region 联系方式
            SetLableText(lbMobile, member.Mobile);
            SetLableText(lbQQ, member.QQ);
            SetLableText(lbPhone, member.Phone);
            SetLableText(lbEmail, member.Email);
            //SetLableText(lbHomePage, member.HomePage);
            SetLableText(lbWeixin, member.Weixin);
            //SetLableText(lbAddress, member.Address);

            if (IsPower("PersonContact"))
            {
                phContact.Visible = true;
                phHideContact.Visible = false;
            }
            else
            {
                phContact.Visible = false;
                phHideContact.Visible = true;
            }
            #endregion

            #region 求职意向
            //lbHousing.Text = member.HousingString;
            //lbCarFare.Text = member.CarFareString;

            //期望职位
            lbJobCategory.Text = member.JobCategoryName;

            //期望地区
            lbJobAddress.Text = member.JobAddr;

            //期望薪水
            lbSalary.Text = member.SalaryName + (member.Commission.Value ? " + 提成" : "");

            //工作类型
            lbJobType.Text = member.JobTypeName;
            #endregion

            #region 简历信息
            SetLableText(lbResume, member.Resume);
            SetLableText(lbSelfEvaluation, member.SelfEvaluation);
            #endregion

            #region 工作经验
            rptExpList.DataSource = BLL.MemberExperience.GetList(0, "MemberID=" + member.Id.ToString(), "StartTime asc").Tables[0];
            rptExpList.DataBind();
            #endregion

            #region 个人相册
            rptAlbums.DataSource = BLL.MemberAlbum.GetList(0, "MemberID=" + mid.ToString(), "Status").Tables[0];
            rptAlbums.DataBind();
            #endregion

            #region 个人作品
            rptWorks.DataSource = BLL.MemberWorks.GetList(0, "MemberID=" + mid.ToString(), "Status").Tables[0];
            rptWorks.DataBind();
            #endregion

            #region 个人资料
            if (member.VerifyStatus == 0)
            {
                _newinfoVerifyStatus = 0;
            }
            else
            {
                BindNewInfo();
            }
            #endregion

            #region 实名认证
            Model.IdentityVerify identity = new Model.IdentityVerify() { MemberID = Id };
            identity = BLL.IdentityVerify.GetModel(identity);
            if (identity != null)
            {
                lbIdentityNo.Text = identity.IdentityNo;
                lbIdentityExpireDate.Text = identity.ExpireDate.ToString("yyyy-MM-dd");
                lbIdentitySex.Text = identity.Sex.Value ? "男" : "女";
                lbIdentityTel.Text = identity.Tel;
                lbIdentityQQ.Text = identity.QQ;
                string filepath = "/Upload/IdentityFile/" + identity.IdentityImg;
                if (File.Exists(Server.MapPath(filepath)))
                {
                    imgIdentity.ImageUrl = filepath;
                    imgIdentity.Visible = true;
                }
                _identitystatus = identity.Status;

                phContent.Visible = true;
            }
            else
            {
                phContent.Visible = false;
            }
            #endregion
        }

        private void BindNewInfo()
        {
            //DataTable dt = BLL.MemberNewInfo.GetList("Id=" + Id.ToString()).Tables[0];

            Model.MemberNewInfo model = new Model.MemberNewInfo();
            model.Id = Id;
            model.Status = 0;

            model = BLL.MemberNewInfo.GetModel(model);

            if (model != null)
            {
                _newinfoVerifyStatus = model.Status;
                SetLableText2(lbRealname_new, model.Realname);
                SetLableText2(lbPhone_new, model.Phone);
                SetLableText2(lbQQ_new, model.QQ);
                SetLableText2(lbEmail_new, model.Email);
                //SetLableText2(lbAddress_new, model.Address);
                //SetLableText2(lbHomepage_new, model.HomePage);
                SetLableText2(lbWeixin_new, model.Weixin);
                SetLableText2(lbResume_new, model.Resume);
                SetLableText2(lbSelfEvaluation_new, model.SelfEvaluation);

                //phNewInfo1.Visible = true;
            }
            else
            {
                //phNewInfo1.Visible = false;
            }
        }

        private void SetLableText(Label obj, string text)
        {
            if (text.Trim() != "")
                obj.Text = HtmlEncode(text).Replace("\n", "<br/>");
        }
        private void SetLableText2(Label obj, string text)
        {
            if (text.Trim() != "")
                obj.Text = "【新内容】<br/>" + HtmlEncode(text).Replace("\n", "<br/>");
        }

        //private void SetLableText(Label obj, string text)
        //{
        //    if (text.Trim() != "")
        //        obj.Text = "【新内容】<br/>" + HtmlEncode(text).Replace("\n","<br/>");
        //}

        private void Verify()
        {
            VerifyPhoto();
            VerifyNewInfo();
            VerifyExperience();
            VerifyAlbum();
            VerifyWorks();
            VerifyIdentity();

            BLL.Member.UpdateComplete(Id);
            BLL.Member.UpdateMemberIsVerify(Id);
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
                        
            BLL.MemberNewInfo.VerifyNewInfo(Id, int.Parse(status));
        }
        #endregion

        #region 审核工作经验
        private void VerifyExperience()
        {
            string ids = Request.Form["el"];
            string vals = Request.Form["el_v"];
            if (string.IsNullOrEmpty(ids)) return;

            string[] arrayIds = ids.Split(',');
            string[] arrayVals = vals.Split(',');

            for (int i = 0; i < arrayIds.Length; i++)
            {
                Model.MemberExperience model = new Model.MemberExperience();
                model.Id = int.Parse(arrayIds[i]);
                model.Status = int.Parse(arrayVals[i]);

                BLL.MemberExperience.Update(model);
            }
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
                Model.MemberAlbum model = new Model.MemberAlbum();
                model.Id = int.Parse(arrayIds[i]);
                model.Status = int.Parse(arrayVals[i]);

                BLL.MemberAlbum.Update(model);
            }
        }
        #endregion

        #region 审核作品
        private void VerifyWorks()
        {
            string ids = Request.Form["wl"];
            string vals = Request.Form["wl_v"];
            if (string.IsNullOrEmpty(ids)) return;

            string[] arrayIds = ids.Split(',');
            string[] arrayVals = vals.Split(',');

            for (int i = 0; i < arrayIds.Length; i++)
            {
                Model.MemberWorks model = new Model.MemberWorks();
                model.Id = int.Parse(arrayIds[i]);
                model.Status = int.Parse(arrayVals[i]);

                BLL.MemberWorks.Update(model);
            }
        }
        #endregion

        #region 实名认证
        private void VerifyIdentity()
        {
            string identity = Request.Form["identity"];
            if (string.IsNullOrEmpty(identity)) return;

            Model.IdentityVerify model = BLL.IdentityVerify.GetModel(new Model.IdentityVerify() { MemberID=Id});
            if (model == null) return;

            model.Status = int.Parse(identity);

            if (BLL.IdentityVerify.Update(model))
            {
                Model.Member member = new Model.Member();
                member.Id = Id;
                member.IdentityVerified = model.Status == 1;
                BLL.Member.Update(member);
            }
        }
        #endregion


        #region 精英推荐
        /// <summary>
        /// 将人才推荐到精英摄区
        /// </summary>
        private void SetGood()
        {
            string isgood = Request.Form["commend"];
            if (string.IsNullOrEmpty(isgood)) return;

            Model.Member model = new Model.Member();
            model.Id = Id;
            model.IsGood = (isgood == "1");

            if (BLL.Member.Update(model))
            {
                Maticsoft.Common.Ajax.WriteOk("操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
        }
        #endregion

    }
}