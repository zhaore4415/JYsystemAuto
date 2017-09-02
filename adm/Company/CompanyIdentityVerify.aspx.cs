using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace NH.Web.adm.Company
{
    public partial class CompanyIdentityVerify : WebBase.Edit
    {
        protected int _status = 0;
        protected int _verifyId = 0;
        protected int _companyId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["action"])
            {
                case "verify":
                    Verify();
                    break;
                default:
                    Show();
                    break;
            }
        }

        private void Show()
        {
            _companyId = Id;
            Model.CompanyVerify model = new Model.CompanyVerify() { CompanyID = Id };
            model = BLL.CompanyVerify.GetModel(model);
            if (model != null)
            {
                _verifyId = model.Id;

                //lbStatus.Text = WebBase.ModelEnum.VerifyStatusDesc((WebBase.ModelEnum.VerifyStatus)model.Status);

                lbLicenceNo.Text = model.LicenceNo;
                lbExpireDate.Text = model.ExpireDate.ToString("yyyy-MM-dd");
                lbContact.Text = model.Contact;
                lbTel.Text = model.Tel;
                lbQQ.Text = model.QQ;
                string filepath = "/Upload/CompanyLicence/" + model.LicenceImg;
                if (File.Exists(Server.MapPath(filepath)))
                {
                    imgIdentity.ImageUrl = filepath;
                    imgIdentity.Visible = true;
                }
                _status = model.Status;

                phContent.Visible = true;
                phEmpty.Visible = false;
            }
            else
            {
                phContent.Visible = false;
                phEmpty.Visible = true;
            }

            Model.Company company = BLL.Company.GetModel(Id);
            cbIdentityVerified.Checked = company.IdentityVerified.Value;
            cbIsFoodAdd.Checked = company.IsFoodAdd.Value;
            cbIsOfferRoom.Checked = company.IsOfferRoom.Value;
            cbIsOfferFood.Checked = company.IsOfferFood.Value;
            cbIsFiveInsurance.Checked = company.IsFiveInsurance.Value;
            cbIsFund.Checked = company.IsFund.Value;
            cbIsCarFare.Checked = company.IsCarFare.Value;
            cbIsYearGuarantee.Checked = company.IsYearGuarantee.Value;
        }

        private void Verify()
        {
            Model.Company company = new Model.Company();
            company.Id = int.Parse(Request.QueryString["companyId"]);

            company.IdentityVerified = Request.Form["cbIdentityVerified"] != null;
            company.IsFoodAdd = Request.Form["cbIsFoodAdd"] != null;
            company.IsOfferRoom = Request.Form["cbIsOfferRoom"] != null;
            company.IsOfferFood = Request.Form["cbIsOfferFood"] != null;
            company.IsFiveInsurance = Request.Form["cbIsFiveInsurance"] != null;
            company.IsFund = Request.Form["cbIsFund"] != null;
            company.IsCarFare = Request.Form["cbIsCarFare"] != null;
            company.IsYearGuarantee = Request.Form["cbIsYearGuarantee"] != null;

            BLL.Company.Update(company);

            Model.CompanyVerify model = BLL.CompanyVerify.GetModel(Id);
            if (model != null)
            {
                model.Status = company.IdentityVerified.Value ? 1 : -1;
                BLL.CompanyVerify.Update(model);
            }

            BLL.Company.UpdateComplete(company.Id);
            Maticsoft.Common.Ajax.WriteOk("操作成功");
        }
    }
}