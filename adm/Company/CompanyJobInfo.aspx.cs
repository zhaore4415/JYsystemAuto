using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NH.Web.adm.Company
{
    public partial class CompanyJobInfo : WebBase.Free
    {
        protected int _verifyStatus = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Show();
        }


        private void Show()
        {
            Model.Job model = BLL.Job.GetModel(Id);
            if (model == null) return;
            //职位类别
            Model.JobCategory category = BLL.JobCategory.GetModel(new Model.JobCategory() { CategoryNo=model.CategoryNo});
            if (category != null) lbJobCategory.Text = category.Name;

            //薪水
            Model.Salary salary = BLL.Salary.GetModelByCache(model.SalaryID);
            if (salary != null)
            {
                lbJobSalary.Text = salary.SalaryName;
                if (model.Commission.HasValue && model.Commission.Value)
                {
                    lbJobSalary.Text += " + 提成";
                }
            }

            //工作类型
            lbJobType.Text = model.JobTypeName;
            //教育程度(学历)
            lbJobDegree.Text = model.DegreeName;
            //工作年限
            Model.Experience experience = BLL.Experience.GetModelByCache(model.ExperienceID);
            if (experience != null) lbJobExperience.Text = experience.Name;
            //性别
            lbJobSex.Text = model.SexString;
            //报销车费
            lbCarfare.Text = model.CarFareString;
            //住宿
            lbHousing.Text = model.HousingString;
            //工作时间
            lbJobWorkTime.Text = HtmlEncode(model.WorkTime);
            //招聘人数
            lbJobEmployeeQty.Text = model.Quantity.ToString();
            //有效期
            if (model.ExpireDate.HasValue)
            {
                lbJobExpireDate.Text = model.ExpireDate.Value.ToString("yyyy-MM-dd");
            }
            lbJobTitle.Text = HtmlEncode(model.JobTitle).Replace("\n", "<br/>");
            if (model.Jobtitle_New.Trim() != "")
            {
                lbJobTitle_new.Text = "【新内容】<br/>" + HtmlEncode(model.Jobtitle_New).Replace("\n", "<br/>");
            }

            lbJobDescription.Text = HtmlEncode(model.Description).Replace("\n", "<br/>");
            if (model.Description_New.Trim() != "")
            {
                lbJobDescription_new.Text = "【新内容】<br/>" + HtmlEncode(model.Description_New).Replace("\n", "<br/>");
            }

            lbSalaryDesc.Text = HtmlEncode(model.SalaryDesc).Replace("\n", "<br/>");
            if (model.SalaryDesc_New.Trim() != "")
            {
                lbSalaryDesc_new.Text = "【新内容】<br/><hr />" + HtmlEncode(model.SalaryDesc_New).Replace("\n", "<br/>");
            }

            lbWorkContent.Text = HtmlEncode(model.WorkContent).Replace("\n", "<br/>");
            if (model.WorkContent_New.Trim() != "")
            {
                lbWorkContent_new.Text = "【新内容】<br/>" + HtmlEncode(model.WorkContent_New).Replace("\n", "<br/>");
            }

            lbRequirements.Text = HtmlEncode(model.Requirements).Replace("\n", "<br/>");
            if (model.Requirements_New.Trim() != "")
            {
                lbRequirements_new.Text = "【新内容】<br/>" + HtmlEncode(model.Requirements_New).Replace("\n", "<br/>");
            }

            lbRoomAndFood.Text = HtmlEncode(model.RoomAndFood).Replace("\n", "<br/>");
            if (model.RoomAndFood_New.Trim() != "")
            {
                lbRoomAndFood_new.Text = "【新内容】<br/>" + HtmlEncode(model.RoomAndFood_New).Replace("\n", "<br/>");
            }

            lbWelfare.Text = HtmlEncode(model.Welfare).Replace("\n", "<br/>");
            if (model.Welfare_New.Trim() != "")
            {
                lbWelfare_new.Text = "【新内容】<br/>" + HtmlEncode(model.Welfare_New).Replace("\n", "<br/>");
            }

            //状态
            _verifyStatus = model.Verified;
            //lbVerifyStatus.Text = WebBase.ModelEnum.VerifyStatusDesc((WebBase.ModelEnum.VerifyStatus)model.Verified);

            /*
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
            */
            //待审核信息

        }
    }
}