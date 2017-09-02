using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Ad
{
    public partial class TextAdModify : WebBase.Edit //WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("AdManage");
            if (!IsPostBack)
            {
                Show();
            }
        }

        private void Show()
        {
            Model.Ad model = BLL.Ad.GetModel(Id);
            if (model == null) Response.Redirect(ListUrl);

            txtTitle.Text = model.Title;
            txtUrl.Text = model.Url;
            txtStartDate.Text = model.StartDate.HasValue ? model.StartDate.Value.ToString("yyyy-MM-dd") : "";
            txtEndDate.Text = model.EndDate.HasValue ? model.EndDate.Value.ToString("yyyy-MM-dd") : "";
            txtDescription.Text = model.Description;
            rblStatus.SelectedValue = model.IsShow.Value ? "1" : "0";
            txtSort.Text = model.Sort.ToString();

            Model.AdType adtype = BLL.AdType.GetModelByCache2(int.Parse(Request.QueryString["cid"]));
            ltrTypeName.Text = ltrTypeName2.Text = adtype.TypeName;
            if (!string.IsNullOrEmpty(adtype.Remark))
                ltrDesc.Text = "(" + adtype.Remark + ")";

            try
            {
                ddlIcon.SelectedValue = model.Icon.ToString();
            }
            catch
            { }

            //地区 js
            this.ltrAreaJsObject.Text = BLL.Area.BuildJsObject();

            //当前所在地区
            this.ltrCurrProvince.Text = BLL.Area.BuildOption("ParentNo=1", Web.Site.GetProvinceId(model.AreaNo));
            this.ltrCurrCity.Text = BLL.Area.BuildOption("ParentNo='" + Web.Site.GetProvinceId(model.AreaNo) + "'", Web.Site.GetCityId(model.AreaNo));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int categorId = int.Parse(Request.QueryString["cid"]);
            string title = txtTitle.Text.Trim();
            string url = txtUrl.Text.Trim();
            DateTime? startdate = DateTime.MinValue;
            DateTime? enddate = DateTime.MinValue;
            string filename = null;
            string description = txtDescription.Text;
            bool isShow = rblStatus.SelectedValue == "1";
            int sort = 0;
            string areaId = !string.IsNullOrEmpty(Request.Form["ddlCurrCity"]) ? Request.Form["ddlCurrCity"] : Request.Form["ddlCurrProvince"];

            if (categorId == 0)
            {
                MessageBox.Show("请选择广告类型"); return;
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
            model.AdType = categorId;
            model.AreaNo = areaId;
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
            model.Icon = int.Parse(ddlIcon.SelectedValue);

            model.Id = Id;
            if (BLL.Ad.Update(model))
            {
                MessageBox.ShowAndRedirect("修改成功", ListUrl + "?cid=" + categorId);
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }
    }
}