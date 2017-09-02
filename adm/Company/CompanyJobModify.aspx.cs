using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NH.Web.adm.Company
{
    public partial class CompanyJobModify : WebBase.Edit
    {
        protected int _verifyStatus = 0;
        protected int _status = 0;
        protected int _newinfoVerifyStatus = 0;

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
                case "ChangeStatus":
                    ChangeStatus();
                    break;
                case "VerifyNewInfo":
                    VerifyNewInfo();
                    break;
                default:
                    Show();
                    break;
            }
        }

        private void Show()
        {
            //if (string.IsNullOrEmpty(Request.QueryString["id"])) return;

            string categoryno = null;
            string salaryid = null;
            string jobtypeid = null;
            string degreeid = null;
            string experienceid = null;
            bool commission = false;
            string sex = "-1";
            string worktime = null;
            string qty = null;
            string jobtitle = null;
            string salarydesc = null;
            string workcontent = null;
            string requirement = null;
            string roomAndfood = null;
            string welfare = null;
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Model.Job model = BLL.Job.GetModel(Id);

                categoryno = model.CategoryNo;
                salaryid = model.SalaryID.ToString();
                jobtypeid = model.JobTypeID;
                degreeid = model.DegreeID;
                experienceid = model.ExperienceID.ToString();
                commission = model.Commission.HasValue ? model.Commission.Value : false;
                sex = model.Sex.ToString();
                worktime = model.WorkTime;
                qty = model.Quantity.ToString();
                jobtitle = model.JobTitle;
                salarydesc = model.SalaryDesc;
                workcontent = model.WorkContent;
                requirement = model.Requirements;
                roomAndfood = model.RoomAndFood;
                welfare = model.Welfare;


                //状态
                _verifyStatus = model.Verified;
                lbVerifyStatus.Text = WebBase.ModelEnum.VerifyStatusDesc((WebBase.ModelEnum.VerifyStatus)model.Verified);

                _status = model.Status;
                switch (model.Status)
                {
                    case 1:
                        lbStatus.Text = "已发布";
                        break;
                    case 0:
                        lbStatus.Text = "已隐藏";
                        break;
                    case -1:
                        lbStatus.Text = "已删除";
                        break;
                }

                //待审核信息
                if (model.Description_New != "")
                {
                    //lbDescription_new.Text = HtmlEncode(model.Description_New).Replace("\n", "<br/>");
                    lbJobTitle_new.Text = HtmlEncode(model.Jobtitle_New).Replace("\n", "<br/>");
                    lbSalaryDesc_new.Text = HtmlEncode(model.SalaryDesc_New).Replace("\n", "<br/>");
                    lbWorkContent_new.Text = HtmlEncode(model.WorkContent_New).Replace("\n", "<br/>");
                    lbRequirements_new.Text = HtmlEncode(model.Requirements_New).Replace("\n", "<br/>");
                    lbRoomAndFood_new.Text = HtmlEncode(model.RoomAndFood_New).Replace("\n", "<br/>");
                    lbWelfare_new.Text = HtmlEncode(model.Welfare_New).Replace("\n", "<br/>");
                    phNewInfo1.Visible = true;
                }
                else
                {
                    phNewInfo1.Visible = false;
                }
            }
            else
            {
                phNewInfo1.Visible = false;
                phHide.Visible = false;
            }

            //职位类别
            this.ltrJobCategory.Text = BLL.JobCategory.BuildOptions("," + categoryno + ",");
            //薪水
            this.ltrSalary.Text = BLL.Salary.BuildOptions(salaryid);
            cbCommission.Checked = commission;
            //工作类型
            this.ltrJobType.Text = BLL.JobType.BuildOptions(jobtypeid);
            //教育程度(学历)
            this.ltrDegree.Text = BLL.Degree.BuildOptions(degreeid,true);
            //工作年限
            this.ltrExperience.Text = BLL.Experience.BuildOptions("," + experienceid + ",",true);
            //性别
            ddlSex.SelectedValue = sex;
            //报销车费
            //IsCarfare.SelectedValue = model.IsCarFare.ToString();
            //住宿
            //IsHousing.SelectedValue = model.IsHousing.ToString();
            //工作时间
            txtWorkTime.Text = worktime;
            //招聘人数
            txtQty.Text = qty;
            //有效期
            //if (model.ExpireDate.HasValue)
            //{
            //    txtExpireDate.Text = model.ExpireDate.Value.ToString("yyyy-MM-dd");
            //}
            //txtDescription.Text = model.Description;
            txtJobTitle.Text = jobtitle;
            txtSalaryDesc.Text = salarydesc;
            txtWorkContent.Text = workcontent;
            txtRequirements.Text = requirement;
            txtRoomAndFood.Text = roomAndfood;
            txtWelfare.Text = welfare;
            


        }

        private void Modify()
        {
            string categoryNo = Request.Form["ddlJobCategory"];
            int salaryId = 0;
            bool isCommission = cbCommission.Checked; //Request.Form["cbCommission"] == "1";
            string jobTypeId = Request.Form["ddlJobType"];
            string jobTypename = null;
            string degreeId = Request.Form["ddlDegree"];
            string degreename = null;
            int experienceId = -1;
            int sex = -1;
            int isCarFare = -1;
            int isHousing = -1;
            string worktime = null;
            int qty = 0;
            DateTime? expiredate = null;
            string description = null;
            string JobTitle = null;
            string SalaryDesc = null;
            string WorkContent = null;
            string Requirements = null;
            string RoomAndFood = null;
            string Welfare = null;
            #region
            if (string.IsNullOrEmpty(categoryNo) || categoryNo == "1")
            {
                Maticsoft.Common.Ajax.WriteError("请选择职位");
            }
            if (!int.TryParse(Request.Form["ddlSalary"], out salaryId))
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
            if (!int.TryParse(Request.Form["ddlExperience"], out experienceId))
            {
                Maticsoft.Common.Ajax.WriteError("请选择工作经验");
            }
            sex = int.Parse(this.ddlSex.SelectedValue);
            //isCarFare = int.Parse(this.IsCarfare.SelectedValue);
            //isHousing = int.Parse(this.IsHousing.SelectedValue);
            worktime = Request.Form["txtWorkTime"];
            if (!string.IsNullOrEmpty(Request.Form["txtQty"]))
            {
                if (!int.TryParse(Request.Form["txtQty"], out qty))
                {
                    Maticsoft.Common.Ajax.WriteError("招聘人数填写错误，只能为正整数");
                }
                if (qty < 0)
                {
                    Maticsoft.Common.Ajax.WriteError("招聘人数填写错误，只能为正整数");
                }
            }
            //if (!string.IsNullOrEmpty(Request.Form["txtExpireDate"]))
            //{
            //    try
            //    {
            //        expiredate = DateTime.Parse(Request.Form["txtExpireDate"]);
            //    }
            //    catch
            //    {
            //        Maticsoft.Common.Ajax.WriteError("有效期格式填写不正确");
            //    }
            //}
            //else
            //{
            //    expiredate = DateTime.MinValue;
            //}
            expiredate = DateTime.MinValue;
            description = Request.Form["txtDescription"];
            JobTitle = Request.Form["txtJobTitle"];
            SalaryDesc = Request.Form["txtSalaryDesc"];
            WorkContent = Request.Form["txtWorkContent"];
            Requirements = Request.Form["txtRequirements"];
            RoomAndFood = Request.Form["txtRoomAndFood"];
            Welfare = Request.Form["txtWelfare"];
            #endregion
            Model.Job model = new Model.Job();
            model.CategoryNo = categoryNo;
            model.SalaryID = salaryId;
            model.Commission = isCommission;
            model.JobTypeID = "," + jobTypeId + ",";
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
            model.JobTypeName = jobTypename;
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
            model.DegreeName = degreename;
            #endregion
            model.DegreeID = "," + degreeId + ",";
            model.ExperienceID = experienceId;
            model.Sex = sex;
            model.IsCarFare = isCarFare;
            model.IsHousing = isHousing;
            model.WorkTime = worktime;
            model.Quantity = qty;
            model.ExpireDate = expiredate;
            model.Description = description;
            model.JobTitle = JobTitle;
            model.SalaryDesc = SalaryDesc;
            model.WorkContent = WorkContent;
            model.Requirements = Requirements;
            model.RoomAndFood = RoomAndFood;
            model.Welfare = Welfare;
            model.UpdateTime = DateTime.Now;

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                model.Id = Id;
                BLL.Job.Update(model);
            }
            else
            {
                model.CompanyID = int.Parse(Request.QueryString["companyid"]);
                model.Verified = 1;
                model.Status= 1;
                BLL.Job.Add(model);
            }
            Maticsoft.Common.Ajax.WriteOk("保存成功");
        }

        private void Verify()
        {
            Model.Job model = new Model.Job();
            model.Id = Id;
            model.Verified = int.Parse(Request.Form["status"]);

            if (BLL.Job.Update(model))
            {
                Maticsoft.Common.Ajax.WriteOk("审核操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
        }

        private void ChangeStatus()
        {
            Model.Job model = new Model.Job();
            model.Id = Id;
            model.Status = int.Parse(Request.Form["status"]);

            if (BLL.Job.Update(model))
            {
                Maticsoft.Common.Ajax.WriteOk("操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
        }

        private void VerifyNewInfo()
        {
            BLL.Job.VerifyNewInfo(Id,int.Parse(Request.Form["status"]));
            Maticsoft.Common.Ajax.WriteOk("审核成功");
        }

    }
}