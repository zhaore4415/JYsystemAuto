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
    public partial class VipAdAdd : WebBase.Free //WebBase.Edit
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
            int categorId = int.Parse(Request.QueryString["cid"]);
            string title = txtTitle.Text.Trim();
            string url = txtUrl.Text.Trim();
            DateTime? startdate = DateTime.MinValue;
            DateTime? enddate = DateTime.MinValue;
            string filename = null;
            string description = txtDescription.Text;
            bool isShow = rblStatus.SelectedValue == "1";
            HttpPostedFile hpf = file.PostedFile;
            //string curAddressProvinceId = Request.Form["ddlCurrProvince"];
            //string curAddressCityId = Request.Form["ddlCurrCity"];
            //string areaId = !string.IsNullOrEmpty(Request.Form["ddlCurrCity"]) ? Request.Form["ddlCurrCity"] : Request.Form["ddlCurrProvince"];

            if (!file.HasFile)
            {
                MessageBox.Show("请选择要上传的图片");
                return;
            }
            else if (!ImageHelper.IsWebImage(hpf.ContentType))
            {
                MessageBox.Show("请上传正确的图片格式"); return;
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
            filename = categorId + "_" + DateTime.Now.ToString("yyMMddhhmmss") + Path.GetExtension(hpf.FileName);

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
            model.Sort = BLL.Ad.GetMaxSort(categorId);
            model.IsShow = isShow;

            if (BLL.Ad.Add(model) > 0)
            {
                string folder = Server.MapPath("/Upload/Ad/");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                file.SaveAs(folder + filename);
                MessageBox.ShowAndRedirect("添加成功", ListUrl + "?cid=" + categorId);
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }
    }
}