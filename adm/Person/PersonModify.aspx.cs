using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Person
{
    public partial class PersonModify : WebBase.Edit
    {
        #region 基本信息
        protected string _errormsg = null;
        protected string _residence_provinceId;
        protected string _residence_cityId;
        protected string _currAddr_ProvinceId;
        protected string _currAddr_CityId;

        protected int _verifyStatus = 0;
        protected int _loginStatus = 0;
        protected int _resumeStatus = 0;
        protected int _newinfoVerifyStatus = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.Form["action"])
            {
                case "modify":
                    Modify();
                    break;
                case "verify":
                    Verify();
                    break;
                case "ChangeLoginStatus":
                    ChangeLoginStatus();
                    break;
                case "ChangeResumeStatus":
                    ChangeResumeStatus();
                    break;
                case "VerifyNewInfo":
                    VerifyNewInfo();
                    break;
                case "VerifyExp":
                    VerifyExp();
                    break;
                default:
                    Show();
                    break;
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
            DataSet ds = BLL.Member.GetPersonInfo(mid);
            if (ds.Tables[0].Rows.Count == 0 || ds.Tables[1].Rows.Count == 0)
            {
                _errormsg = "此用户不存在";
                return;
            }
            Model.User user = BLL.User.DataTableToList(ds.Tables[0])[0];
            Model.Member member = BLL.Member.DataTableToList(ds.Tables[1])[0];
            /*
            Model.User user = BLL.User.DataTableToList(ds.Tables[0])[0];
            if (user.Status != 1)
            {
                _errormsg = "此用户已被禁用";
                return;
            }
            Model.Member member = BLL.Member.DataTableToList(ds.Tables[1])[0];
            if (member.IsShow.Value == false)
            {
                _errormsg = "此用户已隐藏简历";
                return;
            }
             */
            #endregion

            #region 基本信息
            //审核状态
            _verifyStatus = member.VerifyStatus;
            lbVerifyStatus.Text = WebBase.ModelEnum.VerifyStatusDesc((WebBase.ModelEnum.VerifyStatus)member.VerifyStatus);
            //登录状态
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
            //简历状态
            _resumeStatus = member.IsShow.Value ? 1 : 0;
            lbResumeStatus.Text = member.IsShow.Value ? "开放" : "隐藏";

            lbLoginName.Text = user.LoginName;
            txtTrueName.Text = member.Realname;
            ddlMarriage.SelectedValue = member.Marriage.ToString();
            rblSex.SelectedValue = member.Sex.ToString();
            //学历
            this.ltrDegree.Text = BLL.Degree.BuildOptions("," + member.DegreeID.ToString() + ",");
            //工作年限
            this.ltrExperience.Text = BLL.Experience.BuildOptions("," + member.ExperienceID.ToString() + ",");
            if (member.Birthday.HasValue)
            {
                txtBirthday.Text = member.Birthday.Value.ToString("yyyy-MM-dd");
            }

            //地区 js
            this.ltrAreaJsObject.Text = BLL.Area.BuildJsObject();
            //籍贯
            this.ltrResidenceProvince.Text = BLL.Area.BuildOption("ParentNo=1", member.ResidenceProvinceId);
            this.ltrResidenceCity.Text = BLL.Area.BuildOption("ParentNo='" + member.ResidenceProvinceId + "'", member.ResidenceCityId);
            //当前所在地区
            this.ltrCurrProvince.Text = BLL.Area.BuildOption("ParentNo=1", member.CurrAddrProvinceId);
            this.ltrCurrCity.Text = BLL.Area.BuildOption("ParentNo='" + member.CurrAddrProvinceId + "'", member.CurrAddrCityId);

            if (member.Height > 0)
                txtHeight.Text = member.Height.ToString();
            #endregion

            #region 联系方式
            txtMobile.Text = member.Mobile;
            txtQQ.Text = member.QQ;
            txtPhone.Text = member.Phone;
            txtEmail.Text = member.Email;
            txtHomePage.Text = member.HomePage;
            txtAddress.Text = member.Address;
            #endregion

            #region 求职意向
            rblHousing.SelectedValue = member.IsHousing.ToString();
            rblCarFare.SelectedValue = member.IsCarFare.ToString();

            //期望职位
            this.ltrJobCategor.Text = BLL.JobCategory.BuildOptions(member.JobCategoryIDs);

            //期望地区
            this.ltrJobAddress.Text = BLL.Area.BuildFullAreaOption(member.JobAddrID);

            //期望薪水
            this.ltrSalary.Text = BLL.Salary.BuildOptions(member.SalaryID.ToString());
            this.chkCommission.Checked = member.Commission.Value;

            //工作类型
            this.ltrJobType.Text = BLL.JobType.BuildOptions(member.JobTypeID);
            #endregion

            #region 简历信息
            txtResume.Text = member.Resume;
            txtSelfEvaluation.Text = member.SelfEvaluation;
            #endregion

            #region 工作经验
            rptExpList.DataSource = BLL.MemberExperience.GetList(0, "MemberID=" + member.Id.ToString(), "StartTime asc").Tables[0];
            rptExpList.DataBind();
            #endregion

            #region 个人相册
            //rptAlbums.DataSource = ds.Tables[2];
            //rptAlbums.DataBind();
            #endregion

            #region 个人作品
            //rptWorks.DataSource = ds.Tables[3];
            //rptWorks.DataBind();
            #endregion

            BindNewInfo();
        }

        private void Modify()
        {
            #region//姓名
            string truename = Request.Form["txtTrueName"].Trim();
            if (truename == "")
            {
                Maticsoft.Common.Ajax.WriteError("请填写真实姓名");
            }
            #endregion
            //性别
            int sex = int.Parse(rblSex.SelectedValue);
            #region//生日
            DateTime birthday = DateTime.Now;
            try
            {
                birthday = DateTime.Parse(Request.Form["txtBirthday"]);
            }
            catch
            {
                Maticsoft.Common.Ajax.WriteError("请填写生日");
            }
            #endregion
            #region//身高
            int height = 0;
            if (!string.IsNullOrEmpty(Request.Form["txtHeight"]))
            {
                try
                {

                    height = int.Parse(Request.Form["txtHeight"]);
                }
                catch
                {
                    Maticsoft.Common.Ajax.WriteError("身高填写不正确");
                }
            }
            #endregion
            //婚姻状况
            int marriage = int.Parse(ddlMarriage.SelectedValue);
            #region//籍贯
            string residenceProvinceId = Request.Form["ddlResidenceProvince"];
            string residenceCityId = Request.Form["ddlResidenceCity"];

            if (string.IsNullOrEmpty(residenceCityId) && string.IsNullOrEmpty(residenceProvinceId))
            {
                Maticsoft.Common.Ajax.WriteError("请选择籍贯");
            }
            string residence = null;
            if (!string.IsNullOrEmpty(residenceCityId))
            {
                Model.Area area = new Model.Area() { AreaNo = residenceCityId };
                area = BLL.Area.GetModel(area);
                if (area != null)
                {
                    residence = area.FullName;
                }
            }
            if (string.IsNullOrEmpty(residence) && !string.IsNullOrEmpty(residenceProvinceId))
            {
                Model.Area area = new Model.Area() { AreaNo = residenceProvinceId };
                area = BLL.Area.GetModel(area);
                if (area != null)
                {
                    residence = area.FullName;
                }
            }
            #endregion

            #region//所在省份
            string curAddressProvinceId = Request.Form["ddlCurrProvince"];
            string curAddressCityId = Request.Form["ddlCurrCity"];
            string curAddress = "";
            if (string.IsNullOrEmpty(curAddressCityId) && string.IsNullOrEmpty(curAddressProvinceId))
            {
                Maticsoft.Common.Ajax.WriteError("请选择所在省份");
            }

            if (!string.IsNullOrEmpty(curAddressCityId))
            {
                Model.Area area = new Model.Area() { AreaNo = curAddressCityId };
                area = BLL.Area.GetModel(area);
                if (area != null)
                {
                    curAddress = area.FullName;
                }
            }
            if (string.IsNullOrEmpty(curAddress) && !string.IsNullOrEmpty(curAddressProvinceId))
            {
                Model.Area area = new Model.Area() { AreaNo = curAddressProvinceId };
                area = BLL.Area.GetModel(area);
                if (area != null)
                {
                    curAddress = area.FullName;
                }
            }
            #endregion

            #region//工作年限
            int experienceId = -1;
            try
            {
                experienceId = int.Parse(Request.Form["ddlExperience"]);
            }
            catch
            {
                Maticsoft.Common.Ajax.WriteError("请选择工作年限");
            }
            #endregion

            #region//教育程度
            int degreeId = 0;
            try
            {
                degreeId = int.Parse(Request.Form["ddlDegree"]);
            }
            catch
            {
                Maticsoft.Common.Ajax.WriteError("请选择教育程度");
            }
            string degreename = BLL.Degree.GetModel(degreeId).DegreeName;
            #endregion
            //手机
            //string mobile = Request.Form["txtMobile"].Trim();
            //座机
            string phone = Request.Form["txtPhone"].Trim();
            //qq
            string qq = Request.Form["txtQQ"].Trim();
            //email
            string email = Request.Form["txtEmail"].Trim();
            //联系地址
            string address = Request.Form["txtAddress"].Trim();
            //主页
            string homepage = Request.Form["txtHomePage"].Trim();
            //住宿
            int isHousing = int.Parse(rblHousing.SelectedValue);
            //报销路费
            int isCarFare = int.Parse(rblCarFare.SelectedValue);
            #region//期望职位
            string jobcategoryIds = Request.Form["ddlJobCategory"];
            string jobcategoryName = "";
            if (string.IsNullOrEmpty(jobcategoryIds))
            {
                Maticsoft.Common.Ajax.WriteError("请选择期望的职位");
            }
            else
            {
                string[] arrayIds = jobcategoryIds.Split(',');
                for (int i = 0; i < arrayIds.Length; i++)
                {
                    Model.JobCategory category = new Model.JobCategory() { CategoryNo = arrayIds[i] };
                    category = BLL.JobCategory.GetModel(category);
                    if (category != null)
                    {
                        jobcategoryName += category.Name + ",";
                    }
                }
            }
            jobcategoryName = jobcategoryName.TrimEnd(',');
            #endregion

            #region//期望薪水
            int salaryId = 0;
            try
            {
                salaryId = int.Parse(Request.Form["ddlSalary"]);
            }
            catch
            {
                Maticsoft.Common.Ajax.WriteError("请选择期望的薪水");
            }
            string salaryName = BLL.Salary.GetModel(salaryId).SalaryName;
            bool commission = chkCommission.Checked;

            #endregion

            #region//工作方式
            string jobtype = null;
            jobtype = Request.Form["ddlJobType"];
            if (string.IsNullOrEmpty(jobtype))
            {
                Maticsoft.Common.Ajax.WriteError("请选择工作方式");
            }
            string[] jtypes = jobtype.Split(',');

            string jobtypename = "";
            Model.JobType model_jobtype = null;
            for (int i = 0; i < jtypes.Length; i++)
            {
                model_jobtype = BLL.JobType.GetModel(int.Parse(jtypes[i]));
                if (model_jobtype != null)
                {
                    jobtypename += model_jobtype.TypeName + ",";
                }
            }
            jobtypename = jobtypename.TrimEnd(',');
            #endregion

            #region//期望地区
            string jobAddressIds = Request.Form["ddlJobAddress"];
            string jobAddress = "";
            if (string.IsNullOrEmpty(jobAddressIds))
            {
                Maticsoft.Common.Ajax.WriteError("请选择期望的工作地区");
            }
            string[] jobaddrs = jobAddressIds.Split(',');
            for (int i = 0; i < jobaddrs.Length; i++)
            {
                Model.Area area = new Model.Area() { AreaNo = jobaddrs[i] };
                area = BLL.Area.GetModel(area);
                if (area != null)
                {
                    jobAddress += area.FullName + ",";
                }
            }
            jobAddress = jobAddress.TrimEnd(',');
            #endregion

            //个人简历
            string resume = Request.Form["txtResume"];
            //教育背景
            string education = Request.Form["txtEducation"];
            //爱好
            string hobby = Request.Form["txtHobby"];
            //自我评价
            string selfevaluation = Request.Form["txtSelfEvaluation"];

            Model.Member model = new Model.Member();
            model.Realname = truename;
            model.Sex = sex;
            model.Birthday = birthday;
            model.Height = height;
            model.Marriage = marriage;
            model.ResidenceAddrID = !string.IsNullOrEmpty(residenceCityId) ? residenceCityId : residenceProvinceId;
            model.Residence = residence;
            model.CurrAddrID = !string.IsNullOrEmpty(curAddressCityId) ? curAddressCityId : curAddressProvinceId;
            model.CurAddr = curAddress;
            model.ExperienceID = experienceId;
            model.DegreeID = degreeId;
            model.DegreeName = degreename;
            //model.Mobile = mobile;
            model.Phone = phone;
            model.QQ = qq;
            model.Email = email;
            model.Address = address;
            model.HomePage = homepage;
            model.IsHousing = isHousing;
            model.IsCarFare = isCarFare;
            model.JobCategoryIDs = "," + jobcategoryIds + ",";
            model.JobCategoryName = jobcategoryName;
            model.SalaryID = salaryId;
            model.SalaryName = salaryName;
            model.Commission = commission;
            model.JobTypeID = "," + jobtype + ",";
            model.JobTypeName = jobtypename;
            model.JobAddrID = "," + jobAddressIds + ",";
            model.JobAddr = jobAddress;
            model.Resume = resume;
            model.SelfEvaluation = selfevaluation;

            model.Id = int.Parse(Request.QueryString["id"]);
            if (BLL.Member.Update(model))
            {
                Model.User user = new Model.User();
                user.Id = model.Id;
                user.UpdateTime = DateTime.Now;
                BLL.User.Update(user);

                BLL.Member.UpdateComplete(Id);

                Maticsoft.Common.Ajax.WriteOk("保存成功");
                //MessageBox.ShowAndRedirect("保存成功",Urls.BaseInfo());
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("修改失败");
                //MessageBox.Show("修改失败");
            }
        }

        private void Verify()
        {
            Model.Member model = new Model.Member();
            model.Id = Id;
            model.VerifyStatus = int.Parse(Request.Form["status"]);

            if (BLL.Member.Update(model))
            {
                Maticsoft.Common.Ajax.WriteOk("审核操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
        }

        private void ChangeLoginStatus()
        {
            Model.User model = new Model.User();
            model.Id = Id;
            model.Status = int.Parse(Request.Form["status"]);

            if (BLL.User.Update(model))
            {
                Maticsoft.Common.Ajax.WriteOk("审核操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
        }

        private void ChangeResumeStatus()
        {
            Model.Member model = new Model.Member();
            model.Id = Id;
            model.IsShow = Request.Form["status"] == "1";

            if (BLL.Member.Update(model))
            {
                Maticsoft.Common.Ajax.WriteOk("审核操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
        }

        private void VerifyNewInfo()
        {
            int status = int.Parse(Request.Form["status"]);
            BLL.MemberNewInfo.VerifyNewInfo(Id, status);
            BLL.Member.UpdateComplete(Id);
            Maticsoft.Common.Ajax.WriteOk("审核成功");
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
                lbRealname_new.Text = HtmlEncode(model.Realname);
                lbPhone_new.Text = HtmlEncode(model.Phone);
                lbQQ_new.Text = HtmlEncode(model.QQ);
                lbEmail_new.Text = HtmlEncode(model.Email);
                lbAddress_new.Text = HtmlEncode(model.Address);
                lbHomepage_new.Text = HtmlEncode(model.HomePage);
                lbResume_new.Text = HtmlEncode(model.Resume);
                lbSelfEvaluation_new.Text = model.SelfEvaluation;

                phNewInfo1.Visible = true;
            }
            else
            {
                phNewInfo1.Visible = false;
            }
            /*
            rptNewExp.DataSource = BLL.MemberExperienceNew.GetList("MemberID=" + Id);
            rptNewExp.DataBind();
            if (rptNewExp.Items.Count == 0)
                rptNewExp.Visible = false;

            if (model == null && rptNewExp.Items.Count == 0)
            {
                phNewInfo1.Visible = false;
            }
             */
        }


        private void VerifyExp()
        {
            Model.MemberExperience model = new Model.MemberExperience();
            model.Id = int.Parse(Request.Form["id"]);
            model.Status = int.Parse(Request.Form["status"]);

            if (BLL.MemberExperience.Update(model))
            {
                Maticsoft.Common.Ajax.WriteOk("操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
        }
    }
}