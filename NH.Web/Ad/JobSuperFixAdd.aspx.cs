using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Ad
{
    public partial class JobSuperFixAdd : WebBase.Edit //WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("AdManage");
            if (!IsPostBack)
            {
                Bind();
            }
        }
        private void Bind()
        {
            Model.AdType adtype = BLL.AdType.GetModelByCache2(int.Parse(Request.QueryString["cid"]));
            ltrTypeName.Text = ltrTypeName2.Text = adtype.TypeName;
            ltrDesc.Text = adtype.Remark;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //int categorId = int.Parse(ddlCategory.SelectedValue);
            int companyId = int.Parse(Request.Form["companyid"]);
            int jobid = int.Parse(Request.Form["jobid"]);
            if (!BLL.Company.Exists(new Model.Company() { Id = companyId }))
            {
                MessageBox.Show("填写的企业ID不存在"); return;
            }
            int categorId = int.Parse(Request.QueryString["cid"]);

            Model.Ad ad = new Model.Ad();
            ad.AdType = categorId;
            ad.JobId = jobid;
            if (BLL.Ad.Exists(ad))
            {
                MessageBox.Show("此招聘信息已经存在！"); return;
            }

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
            model.CompanyID = companyId;
            model.JobId = jobid;
            model.AdType = categorId;
            model.Description = description;
            model.StartDate = startdate;
            model.EndDate = enddate;
            model.AddUser = UserBase.CurAdmin.LoginName;
            model.AddTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;
            model.Sort = 0;
            model.IsShow = isShow;

            if (BLL.Ad.Add(model) > 0)
            {
                MessageBox.ShowAndRedirect("添加成功", ListUrl + "?cid=" + categorId);
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }
    }
}