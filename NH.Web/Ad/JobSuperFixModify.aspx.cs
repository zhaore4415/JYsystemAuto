using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Ad
{
    public partial class JobSuperFixModify : WebBase.Edit //WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("AdManage");
            if (!IsPostBack)
            {
                Bind();
                Show();
            }
        }

        private void Bind()
        {
            Model.AdType adtype = BLL.AdType.GetModelByCache2(int.Parse(Request.QueryString["cid"]));
            ltrTypeName.Text = ltrTypeName2.Text = adtype.TypeName;
            ltrDesc.Text = adtype.Remark;
        }
        private void Show()
        {
            Model.Ad model = BLL.Ad.GetModel(Id);
            if (model == null) Response.Redirect(ListUrl + "?cid=" + Request.QueryString["cid"]);
            Model.Company company = BLL.Company.GetModel(model.CompanyID);
            if (company != null) lbCompanyName.Text = company.CompanyName;
            Model.Job job = BLL.Job.GetModel(model.JobId);
            if (job != null)
            {
                Model.JobCategory category = BLL.JobCategory.GetModel(new Model.JobCategory(){CategoryNo = job.CategoryNo});
                if(category != null)lbJobName.Text = category.Name;
            }
            if(model.StartDate.HasValue)
            txtStartDate.Text = model.StartDate.Value.ToString("yyyy-MM-dd");

            if(model.EndDate.HasValue)
            txtEndDate.Text = model.EndDate.Value.ToString("yyyy-MM-dd");

            txtDescription.Text = model.Description;
            rblStatus.SelectedValue = model.IsShow.Value ? "1" : "0";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            DateTime? startdate = DateTime.MinValue;
            DateTime? enddate = DateTime.MinValue;
            string description = txtDescription.Text;
            bool isShow = rblStatus.SelectedValue == "1";

            try
            {
                startdate = DateTime.Parse(txtStartDate.Text.Trim());
            }
            catch { }
            try
            {
                enddate = DateTime.Parse(txtEndDate.Text.Trim());
            }
            catch
            { }

            Model.Ad model = new Model.Ad();
            model.Id = Id;
            model.Description = description;
            model.StartDate = startdate;
            model.EndDate = enddate;
            model.IsShow = isShow;

            if (BLL.Ad.Update(model))
            {
                MessageBox.ShowAndRedirect("修改成功", ListUrl + "?cid=" + Request.QueryString["cid"]);
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

    }
}