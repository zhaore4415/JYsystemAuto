using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NH.Web.adm.Company
{
    public partial class CompanyModify : WebBase.Edit
    {
        protected int _verifyStatus = 0;
        protected int _loginStatus = 0;
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
                case "ChangeLoginStatus":
                    ChangeLoginStatus();
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
            Model.User user = BLL.User.GetModel(Id);
            if (user == null || (Model.Enums.UserType)user.UserType != Model.Enums.UserType.Company) return;

            Model.Company company = BLL.Company.GetModel(user.Id);

            lbLoginName.Text = user.LoginName;
            txtCompanyName.Text = company.CompanyName;
            txtContact.Text = company.Contact;
            txtEmail.Text = company.Email;
            txtQQ.Text = company.QQ;
            txtPhone.Text = company.Phone;
            txtOtherPhone.Text = company.OtherPhone;
            txtAddress.Text = company.Address;
            //txtHomePage.Text = company.HomePage;
            //txtSpace.Text = company.Space;
            //txtEmployeeQty.Text = company.EmployeeQty;
            //txtCamera.Text = company.Camera;
            //txtStudio.Text = company.Studio;
            txtDescription.Text = company.Description;

            //地区 js
            //this.ltrAreaJsObject.Text = BLL.Area.BuildJsObject();
            this.ltrArea.Text = BLL.Area.BuildFullAreaOption(","+company.AreaID+",");
            //this.ltrAreaProvince.Text = BLL.Area.BuildOption("ParentNo=1", company.AreaProvinceId);
            //this.ltrAreaCity.Text = BLL.Area.BuildOption("ParentNo='" + company.AreaProvinceId + "'", company.AreaCityId);


            //状态
            _verifyStatus = company.VerifyStatus;
            lbVerifyStatus.Text = WebBase.ModelEnum.VerifyStatusDesc((WebBase.ModelEnum.VerifyStatus)company.VerifyStatus);

            _loginStatus = user.Status;
            switch (user.Status)
            {
                case 1:
                    lbStatus.Text = "正常";
                    break;
                case 0:
                    lbStatus.Text = "禁用";
                    break;
                case -1:
                    lbStatus.Text = "已删除";
                    break;
            }

            BindNewInfo();
        }
        private void BindNewInfo()
        {
            Model.CompanyNewInfo model = new Model.CompanyNewInfo();
            model.Id = Id;
            model.Status = 0;

            model = BLL.CompanyNewInfo.GetModel(model);

            if (model != null)
            {
                _newinfoVerifyStatus = model.Status;
                lbCompanyName_new.Text = HtmlEncode(model.CompanyName);
                lbContact_new.Text = HtmlEncode(model.Contact);
                lbEmail_new.Text = HtmlEncode(model.Email);
                lbQQ_new.Text = HtmlEncode(model.QQ);
                lbPhone_new.Text = HtmlEncode(model.Phone);
                lbOtherPhone_new.Text = HtmlEncode(model.OtherPhone);
                lbAddress_new.Text = HtmlEncode(model.Address);
                //lbHomepage_new.Text = HtmlEncode(model.HomePage);
                //lbSpace_new.Text = HtmlEncode(model.Space);
                //lbEmployeeQty_new.Text = HtmlEncode(model.EmployeeQty);
                //lbCamera_new.Text = HtmlEncode(model.Camera);
                //lbStudio_new.Text = HtmlEncode(model.Studio);
                lbDescription_new.Text = HtmlEncode(model.Description);

                phNewInfo1.Visible = true;
            }
            else
            {
                phNewInfo1.Visible = false;
            }
        }

        private void Modify()
        {
            //string _areaProvinceId = Request.Form["ddlAreaProvince"];
            //string _areaCityId = Request.Form["ddlAreaCity"];
            //string _area = null;

            //if (!string.IsNullOrEmpty(_areaCityId))
            //{
            //    Model.Area area = new Model.Area() { AreaNo = _areaCityId };
            //    area = BLL.Area.GetModel(area);
            //    if (area != null)
            //    {
            //        _area = area.FullName;
            //    }
            //}
            //if (string.IsNullOrEmpty(_areaCityId) && !string.IsNullOrEmpty(_areaProvinceId))
            //{
            //    Model.Area area = new Model.Area() { AreaNo = _areaProvinceId };
            //    area = BLL.Area.GetModel(area);
            //    if (area != null)
            //    {
            //        _area = area.FullName;
            //    }
            //}

            string _areaId = Request.Form["ddlArea"];

            string _area = null;


            Model.Area area = new Model.Area() { AreaNo = _areaId };
            area = BLL.Area.GetModel(area);
            if (area != null)
            {
                _area = area.FullName;
            }

            Model.Company model = new Model.Company();
            model.CompanyName = Request.Form["txtCompanyName"].Trim();
            model.Contact = Request.Form["txtContact"].Trim();
            model.AreaID = _areaId;
            model.Area = _area;
            model.Email = Request.Form["txtEmail"].Trim();
            model.QQ = Request.Form["txtQQ"].Trim();
            model.Phone = Request.Form["txtPhone"];
            model.OtherPhone = Request.Form["txtOtherPhone"];
            model.Address = Request.Form["txtAddress"];
            //model.HomePage = Request.Form["txtHomePage"];
            //model.Space = Request.Form["txtSpace"];
            //model.EmployeeQty = Request.Form["txtEmployeeQty"];
            //model.Camera = Request.Form["txtCamera"];
            //model.Studio = Request.Form["txtStudio"];
            model.Description = Request.Form["txtDescription"];


            model.Id = Id;

            if (BLL.Company.Update(model))
            {
                BLL.Company.UpdateComplete(Id);
                Maticsoft.Common.Ajax.WriteOk("保存成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("修改失败");
            }
        }

        private void Verify()
        {
            Model.Company model = new Model.Company();
            model.Id = Id;
            model.VerifyStatus = int.Parse(Request.Form["status"]);

            if (BLL.Company.Update(model))
            {
                Maticsoft.Common.Ajax.WriteOk("审核操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
        }
        
        private void ChangeLoginStatus()
        {
            Model.User model = new Model.User();
            model.Id = Id;
            model.Status = int.Parse(Request.Form["status"]);

            if (BLL.User.Update(model))
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
            BLL.CompanyNewInfo.VerifyNewInfo(Id, int.Parse(Request.Form["status"]));
            BLL.Company.UpdateComplete(Id);
            Maticsoft.Common.Ajax.WriteOk("审核成功");
        }

    }
}