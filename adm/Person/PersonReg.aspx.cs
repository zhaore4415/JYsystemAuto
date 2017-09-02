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
                Show();
            }
        }

        private void Show()
        {
            //籍贯
            this.ltrResidence.Text = BLL.Area.BuildFullAreaOption("");
            //所在地区
            this.ltrCurr.Text = BLL.Area.BuildFullAreaOption("");
            //工作年限
            this.ltrExperience.Text = BLL.Experience.BuildOptions("", false);
            //教育程度(学历)
            this.ltrDegree.Text = BLL.Degree.BuildOptions("", false);
            //期望职位
            this.ltrJobCategor.Text = BLL.JobCategory.BuildOptions("");
            //期望薪水
            this.ltrSalary.Text = BLL.Salary.BuildOptions("");
            //到岗时间
            this.ltrComeTime.Text = BLL.ComeTime.BuildOptions("");
            //工作类型
            this.ltrJobType.Text = BLL.JobType.BuildOptions("");
            //期望地区
            this.ltrJobAddress.Text = BLL.Area.BuildFullAreaOption("");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string LoginName = txtLoginName.Text.Trim();
            string Password = txtPassword.Text.Trim();
            string Password2 = txtPassword2.Text.Trim();
            if (LoginName == "")
            {
                Maticsoft.Common.Ajax.WriteError("请填写用户名！");
            }
            if (Password == "")
            {
                Maticsoft.Common.Ajax.WriteError("请填写密码！");
            }
            if (Password2 != Password)
            {
                Maticsoft.Common.Ajax.WriteError("两次输入的密码不一致！");
            }

            //手机
            string mobile = txtMobile.Text.Trim();
            if (mobile == "")
            {
                Maticsoft.Common.Ajax.WriteError("请填写手机号！");
            }

            if (mobile != "")
            {
                Model.Member tempMember = new Model.Member();
                tempMember.Mobile = mobile;
                if (BLL.Member.Exists(tempMember))
                {
                    Maticsoft.Common.Ajax.WriteError("此手机号已被使用！");
                }
            }

            Model.User tempUser = new Model.User();
            tempUser.LoginName = LoginName;
            if (BLL.User.Exists(tempUser))
            {
                Maticsoft.Common.Ajax.WriteError("用户名已被使用！");
            }

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
            try
            {
                height = int.Parse(Request.Form["txtHeight"]);
            }
            catch
            {
                Maticsoft.Common.Ajax.WriteError("身高填写不正确");
            }
            #endregion
            //婚姻状况
            int marriage = int.Parse(ddlMarriage.SelectedValue);
            #region//籍贯
            /*
            string residenceProvinceId = Request.Form["ddlResidenceProvince"];
            string residenceCityId = Request.Form["ddlResidenceCity"];

            if (string.IsNullOrEmpty(residenceCityId) && string.IsNullOrEmpty(residenceProvinceId))
            {
                Ajax.WriteError("请选择籍贯");
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
            */
            string residenceId = Request.Form["ddlResidence"];
            string residence = null;

            if (string.IsNullOrEmpty(residenceId))
            {
                Maticsoft.Common.Ajax.WriteError("请选择籍贯");
            }
            else
            {
                Model.Area area = new Model.Area() { AreaNo = residenceId };
                area = BLL.Area.GetModel(area);
                if (area != null)
                {
                    residence = area.FullName;
                }
            }
            #endregion

            #region//所在省份
            /*
            string curAddressProvinceId = Request.Form["ddlCurrProvince"];
            string curAddressCityId = Request.Form["ddlCurrCity"];
            string curAddress = "";
            if (string.IsNullOrEmpty(curAddressCityId) && string.IsNullOrEmpty(curAddressProvinceId))
            {
                Ajax.WriteError("请选择所在省份");
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
            }*/

            string curAddressId = Request.Form["ddlCurr"];
            string curAddress = "";
            if (string.IsNullOrEmpty(curAddressId))
            {
                Maticsoft.Common.Ajax.WriteError("请选择所在省份");
            }

            if (!string.IsNullOrEmpty(curAddressId))
            {
                Model.Area area = new Model.Area() { AreaNo = curAddressId };
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
                Maticsoft.Common.Ajax.WriteError("请选择工作经验");
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
            //座机
            string phone = Request.Form["txtPhone"].Trim();
            //qq
            string qq = Request.Form["txtQQ"].Trim();
            if (qq == "") { Maticsoft.Common.Ajax.WriteError("请填写QQ"); }
            //email
            string email = Request.Form["txtEmail"].Trim();
            if (email == "") { Maticsoft.Common.Ajax.WriteError("请填写邮箱"); }
            if (!PageValidate.IsEmail(email)) { Maticsoft.Common.Ajax.WriteError("邮箱格式不正确"); }
            //联系地址
            //string address = Request.Form["txtAddress"].Trim();
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

            #region//到岗时间
            string comeTimeId = Request.Form["ddlComeTime"];
            string comeTimeDesc = null;
            if (string.IsNullOrEmpty(comeTimeId))
            {
                Maticsoft.Common.Ajax.WriteError("请选择到岗时间");
            }
            else
            {
                comeTimeDesc = BLL.ComeTime.GetModel(int.Parse(comeTimeId)).Name;
            }
            #endregion

            //个人简历
            string resume = Request.Form["txtResume"];
            //教育背景
            string education = Request.Form["txtEducation"];
            //爱好
            string hobby = Request.Form["txtHobby"];
            //自我评价
            string selfevaluation = Request.Form["txtSelfEvaluation"];

            Model.User user = new Model.User();
            user.LoginName = LoginName;
            user.Password = DESEncrypt.Encrypt(Password);
            user.LoginIP = RequestHelper.GetIP();
            user.LoginAddress = new IPScanner(user.LoginIP).IPLocation();
            user.UserType = 1;


            Model.Member member = new Model.Member();
            member.Realname = truename;
            member.Sex = sex;
            member.Birthday = birthday;
            member.Height = height;
            member.Marriage = marriage;
            member.ResidenceAddrID = residenceId;
            member.Residence = residence;
            member.CurrAddrID = curAddressId;
            member.CurAddr = curAddress;
            member.ExperienceID = experienceId;
            member.DegreeID = degreeId;
            member.DegreeName = degreename;
            member.Mobile = mobile;
            member.MobileVerified = true;
            member.Phone = phone;
            member.QQ = qq;
            member.Email = email;
            //member.Address = address;
            member.HomePage = homepage;
            member.IsHousing = isHousing;
            member.IsCarFare = isCarFare;
            member.JobCategoryIDs = "," + jobcategoryIds + ",";
            member.JobCategoryName = jobcategoryName;
            member.SalaryID = salaryId;
            member.SalaryName = salaryName;
            member.Commission = commission;
            member.JobTypeID = "," + jobtype + ",";
            member.JobTypeName = jobtypename;
            member.JobAddrID = "," + jobAddressIds + ",";
            member.JobAddr = jobAddress;
            member.ComeTimeID = int.Parse(comeTimeId);
            member.ComeTimeDesc = comeTimeDesc;
            member.Resume = resume;
            member.SelfEvaluation = selfevaluation;
            member.IsVerify = false;
            member.VerifyStatus = 1;

            int userid = BLL.User.AddMember(user, member);

            if (userid > 0)
            {
                int expcount = int.Parse(Request.Form["expcount"]);
                for (int i = 0; i < expcount; i++)
                {
                    string companyname = Request.Form["txtCompanyName_" + i.ToString()];
                    string positionname = Request.Form["txtPositionName_" + i.ToString()];
                    DateTime starttime = DateTime.Now;
                    try
                    {
                        starttime = DateTime.Parse(Request.Form["txtStartTime_" + i.ToString()]);
                    }
                    catch 
                    { 
                    }
                    DateTime? endtime = DateTime.MinValue;
                    try
                    {
                        endtime = DateTime.Parse(Request.Form["txtEndTime_" + i.ToString()]);
                    }
                    catch
                    { }

                    Model.MemberExperience model = new Model.MemberExperience();
                    model.MemberId = userid;
                    model.CompanyName = companyname;
                    model.PositionName = positionname;
                    model.StartTime = starttime;
                    model.EndTime = endtime;
                    model.Status = 1;

                    BLL.MemberExperience.Add(model);
                }

                BLL.Member.UpdateComplete(userid);
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