using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Company
{
    public partial class CompanyReg : WebBase.Edit
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
            this.ltrArea.Text = BLL.Area.BuildFullAreaOption("");
            //职位类别
            //this.ltrJobCategory.Text = BLL.JobCategory.BuildOptions("");
            ////薪水
            //this.ltrSalary.Text = BLL.Salary.BuildOptions("");
            ////工作类型
            //this.ltrJobType.Text = BLL.JobType.BuildOptions("");
            ////教育程度(学历)
            //this.ltrDegree.Text = BLL.Degree.BuildOptions("", true);
            ////工作年限
            //this.ltrExperience.Text = BLL.Experience.BuildOptions("", true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string LoginName = txtLoginName.Text.Trim();
            string Password = txtPassword.Text.Trim();
            string Password2 = txtPassword2.Text.Trim();
            string companyname = txtCompanyName.Text.Trim();
            string contact = txtContact.Text.Trim();
            string QQ = txtQQ.Text;
            string Email = txtEmail.Text;
            string phone = txtPhone.Text.Trim();
            string _areaId = Request.Form["ddlArea"];
            string _area = null;
            string otherphone = txtOtherPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            //string homepage = txtHomePage.Text.Trim();
            //string space = txtSpace.Text.Trim();
            //string employeeQty = txtEmployeeQty.Text.Trim();
            //string camera = txtCamera.Text.Trim();
            //string studio = txtStudio.Text.Trim();
            string description = txtDescription.Text;

            if (LoginName == "")
            {
                Maticsoft.Common.Ajax.WriteError("请填写用户名！");
            }

            if (Password == "")
            {
                Maticsoft.Common.Ajax.WriteError("请填写登录密码！");
            }

            if (Password != Password2)
            {
                Maticsoft.Common.Ajax.WriteError("两次输入的密码不一致！");
            }

            Model.User user = new Model.User();
            user.LoginName = LoginName;
            if (BLL.User.Exists(user))
            {
                Maticsoft.Common.Ajax.WriteError("此用户名已经存在！");
            }


            Model.Area area = new Model.Area() { AreaNo = _areaId };
            area = BLL.Area.GetModel(area);
            if (area != null)
            {
                _area = area.FullName;
            }

            user.LoginName = LoginName;
            user.LoginName = LoginName;
            user.Password = DESEncrypt.Encrypt(Password);
            user.LoginIP = RequestHelper.GetIP();
            user.LoginAddress = new IPScanner(user.LoginIP).IPLocation();
            user.UserType = 2;


            Model.Company company = new Model.Company();
            company.Email = Email;
            company.QQ = QQ;
            company.LevelID = 1;
            company.AreaID = _areaId;
            company.Area = _area;

            company.CompanyName = companyname;
            company.Contact = contact;
            company.Email = Email;
            company.QQ = QQ;
            company.Phone = phone;
            company.OtherPhone = otherphone;
            company.Address = address;
            //company.HomePage = homepage;
            //company.Space = space;
            //company.EmployeeQty = employeeQty;
            //company.Camera = camera;
            //company.Studio = studio;
            company.Description = description;
            company.IsVerify = false;
            company.VerifyStatus = 1;


            int userid = BLL.User.AddCompany(user, company);

            if (userid > 0)
            {
                #region
                /*
                int jobcount = int.Parse(Request.Form["jobcount"]);
                for (int i = 0; i < jobcount; i++)
                {
                    string categoryNo = Request.Form["ddlJobCategory_" + i.ToString()];
                    int salaryId = 0;

                    string t = Request.Form["cbCommission_" + i.ToString()];

                    bool isCommission = Request.Form["cbCommission_" + i.ToString()] != null;//Request.Form["cbCommission_" + i.ToString()] == "1";
                    string jobTypeId = Request.Form["ddlJobType_" + i.ToString()];
                    string jobTypename = null;
                    string degreeId = Request.Form["ddlDegree_" + i.ToString()];
                    string degreename = null;
                    int experienceId = -1;
                    int sex = -1;
                    int isCarFare = -1;
                    int isHousing = -1;
                    string worktime = null;
                    int qty = 0;
                    DateTime? expiredate = null;
                    string jobdescription = null;
                    #region
                    if (string.IsNullOrEmpty(categoryNo) || categoryNo == "1")
                    {
                        Maticsoft.Common.Ajax.WriteError("请选择职位");
                    }
                    if (!int.TryParse(Request.Form["ddlSalary_" + i.ToString()], out salaryId))
                    {
                        Maticsoft.Common.Ajax.WriteError("请选择薪酬");
                    }
                    if (string.IsNullOrEmpty(jobTypeId))
                    {
                        Maticsoft.Common.Ajax.WriteError("请选择工作方式");
                    }
                    if (string.IsNullOrEmpty(degreeId))
                    {
                        Maticsoft.Common.Ajax.WriteError("请选择教育程度");
                    }
                    if (!int.TryParse(Request.Form["ddlExperience_" + i.ToString()], out experienceId))
                    {
                        Maticsoft.Common.Ajax.WriteError("请选择工作经验");
                    }
                    sex = int.Parse(Request.Form["ddlSex_" + i.ToString()]);//int.Parse(this.ddlSex.SelectedValue);
                    isCarFare = int.Parse(Request.Form["IsCarfare_" + i.ToString()]); //int.Parse(this.IsCarfare.SelectedValue);
                    isHousing = int.Parse(Request.Form["IsHousing_" + i.ToString()]);//int.Parse(this.IsHousing.SelectedValue);
                    worktime = Request.Form["txtWorkTime_" + i.ToString()];
                    if (!string.IsNullOrEmpty(Request.Form["txtQty_" + i.ToString()]))
                    {
                        if (!int.TryParse(Request.Form["txtQty_" + i.ToString()], out qty))
                        {
                            Maticsoft.Common.Ajax.WriteError("招聘人数填写错误，只能为正整数");
                        }
                        if (qty < 0)
                        {
                            Maticsoft.Common.Ajax.WriteError("招聘人数填写错误，只能为正整数");
                        }
                    }
                    if (!string.IsNullOrEmpty(Request.Form["txtExpireDate_" + i.ToString()]))
                    {
                        try
                        {
                            expiredate = DateTime.Parse(Request.Form["txtExpireDate_" + i.ToString()]);
                        }
                        catch
                        {
                            Maticsoft.Common.Ajax.WriteError("有效期格式填写不正确");
                        }
                    }
                    else
                    {
                        expiredate = DateTime.MinValue;
                    }
                    description = Request.Form["txtJobDescription_" + i.ToString()];
                    #endregion
                    Model.Job job = new Model.Job();
                    job.CompanyID = userid;
                    job.CategoryNo = categoryNo;
                    job.SalaryID = salaryId;
                    job.Commission = isCommission;
                    job.JobTypeID = "," + jobTypeId + ",";
                    #region 工作方式名称
                    string[] arrayJobTypeIds = jobTypeId.Split(',');
                    foreach (string typeid in arrayJobTypeIds)
                    {
                        if (!string.IsNullOrEmpty(typeid))
                        {
                            Model.JobType jobtype = BLL.JobType.GetModel(int.Parse(typeid));
                            if (jobtype != null)
                            {
                                jobTypename += jobtype.TypeName + ",";
                            }
                        }
                    }
                    if (jobTypename != null) jobTypename = jobTypename.TrimEnd(',');
                    job.JobTypeName = jobTypename;
                    #endregion
                    #region 学历名称
                    string[] arrayDegreeIds = degreeId.Split(',');
                    foreach (string _degreeid in arrayDegreeIds)
                    {
                        if (!string.IsNullOrEmpty(_degreeid))
                        {
                            Model.Degree degree = BLL.Degree.GetModel(int.Parse(_degreeid));
                            if (degree != null)
                            {
                                degreename += degree.DegreeName + ",";
                            }
                        }
                    }
                    if (degreename != null) degreename = degreename.TrimEnd(',');
                    job.DegreeName = degreename;
                    #endregion
                    job.DegreeID = "," + degreeId + ",";
                    job.ExperienceID = experienceId;
                    job.Sex = sex;
                    job.IsCarFare = isCarFare;
                    job.IsHousing = isHousing;
                    job.WorkTime = worktime;
                    job.Quantity = qty;
                    job.ExpireDate = expiredate;
                    job.Description = jobdescription;
                    job.UpdateTime = DateTime.Now;
                    job.Verified = 1;
                    job.Status = 1;

                    BLL.Job.Add(job);
                }
                */
                #endregion
                Maticsoft.Common.Ajax.WriteOk("添加成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("添加失败");
            }




        }
    }
}