using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Maticsoft.Common;

namespace NH.Web.adm.Ad
{
    public partial class VipAdModify : WebBase.Edit //WebBase.Edit
    {
        string folder = "/Upload/Ad/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show();
            }
        }

        private void Show()
        {
            Model.Ad model = BLL.Ad.GetModel(Id);
            if (model == null) Response.Redirect(ListUrl);
            txtCompanyID.Text = model.CompanyID.ToString();
            Model.Company company = BLL.Company.GetModel(model.CompanyID);
            if (company != null)
            {
                cinfo.Text = company.CompanyName;
            }

            txtTitle.Text = model.Title;
            txtUrl.Text = model.Url;
            txtStartDate.Text = model.StartDate.HasValue ? model.StartDate.Value.ToString("yyyy-MM-dd") : "";
            txtEndDate.Text = model.EndDate.HasValue ? model.EndDate.Value.ToString("yyyy-MM-dd") : "";
            img.ImageUrl = folder + model.Pic;
            txtDescription.Text = model.Description;
            rblStatus.SelectedValue = model.IsShow.Value ? "1" : "0";
            txtSort.Text = model.Sort.ToString();

            Model.AdType adtype = BLL.AdType.GetModelByCache2(int.Parse(Request.QueryString["cid"]));
            ltrTypeName.Text = ltrTypeName2.Text = adtype.TypeName;
            ltrDesc.Text = adtype.Remark;


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int companyId = 0;
            try
            {
                companyId = int.Parse(txtCompanyID.Text);
            }
            catch
            {
                MessageBox.Show("请填写企业ID"); return;
            }
            if (!BLL.Company.Exists(new Model.Company() { Id = companyId }))
            {
                MessageBox.Show("填写的企业ID不存在"); return;
            }
            //int categorId = int.Parse(ddlCategory.SelectedValue);
            int categorId = int.Parse(Request.QueryString["cid"]);
            string title = txtTitle.Text.Trim();
            string url = txtUrl.Text.Trim();
            DateTime? startdate = DateTime.MinValue;
            DateTime? enddate = DateTime.MinValue;
            string filename = null;
            string description = txtDescription.Text;
            bool isShow = rblStatus.SelectedValue == "1";
            int sort = 0;
            HttpPostedFile hpf = file.PostedFile;
            //string areaId = !string.IsNullOrEmpty(Request.Form["ddlCurrCity"]) ? Request.Form["ddlCurrCity"] : Request.Form["ddlCurrProvince"];

            if (categorId == 0)
            {
                MessageBox.Show("请选择广告类型"); return;
            }
            if (file.HasFile)
            {
                if (!ImageHelper.IsWebImage(hpf.ContentType))
                {
                    MessageBox.Show("请上传正确的图片格式"); return;
                }
                else
                {
                    filename = categorId + "_" + DateTime.Now.ToString("yyMMddhhmmss") + Path.GetExtension(hpf.FileName);
                }
            }
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
            try
            {
                sort = int.Parse(txtSort.Text.Trim());
            }
            catch
            {
                MessageBox.Show("排序值不正确"); return;
            }
            Model.Ad model = new Model.Ad();
            model.CompanyID = companyId;
            model.AdType = categorId;
            //model.AreaNo = areaId;
            model.Title = title;
            model.Description = description;
            model.Pic = filename;
            model.Url = url;
            model.StartDate = startdate;
            model.EndDate = enddate;
            model.AddUser = UserBase.CurAdmin.LoginName;
            model.AddTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;
            model.Sort = sort;
            model.IsShow = isShow;

            model.Id = Id;
            if (BLL.Ad.Update(model))
            {
                if (file.HasFile)
                {
                    if (!Directory.Exists(Server.MapPath(folder)))
                    {
                        Directory.CreateDirectory(Server.MapPath(folder));
                    }
                    file.SaveAs(Server.MapPath(folder) + filename);

                    FileHelper.DeleteFile(img.ImageUrl);
                }
                MessageBox.ShowAndRedirect("修改成功", ListUrl + "?cid=" + categorId);
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }
    }
}