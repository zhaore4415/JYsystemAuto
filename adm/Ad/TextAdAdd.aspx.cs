using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Ad
{
    public partial class TextAdAdd : WebBase.Free //WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("AdManage");
            if (!IsPostBack)
            {
                //BindCategory();
                Bind();
            }
        }
        private void Bind()
        {
            Model.AdType adtype = BLL.AdType.GetModelByCache2(int.Parse(Request.QueryString["cid"]));
            ltrTypeName.Text = ltrTypeName2.Text = adtype.TypeName;
            if (!string.IsNullOrEmpty(adtype.Remark))
                ltrDesc.Text = "(" + adtype.Remark + ")";

            //地区 js
            this.ltrAreaJsObject.Text = BLL.Area.BuildJsObject();

            //当前所在地区
            this.ltrCurrProvince.Text = BLL.Area.BuildOption("ParentNo=1", "");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int categorId = int.Parse(Request.QueryString["cid"]);
            string title = txtTitle.Text.Trim();
            string url = txtUrl.Text.Trim();
            DateTime? startdate = DateTime.MinValue;
            DateTime? enddate = DateTime.MinValue;
            string description = txtDescription.Text;
            bool isShow = rblStatus.SelectedValue == "1";
            string areaId = !string.IsNullOrEmpty(Request.Form["ddlCurrCity"]) ? Request.Form["ddlCurrCity"] : Request.Form["ddlCurrProvince"];

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
            model.AdType = categorId;
            model.AreaNo = areaId;
            model.Title = title;
            model.Description = description;
            model.Url = url;
            model.StartDate = startdate;
            model.EndDate = enddate;
            model.AddUser = UserBase.CurAdmin.LoginName;
            model.AddTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;
            model.Sort = BLL.Ad.GetMaxSort(categorId);
            model.IsShow = isShow;
            model.Icon = int.Parse(ddlIcon.SelectedValue);

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