using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NH.Web.adm.Suggest
{
    public partial class SuggestModify : WebBase.Free
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("InfomationManage");
            switch (Request.Form["action"])
            {
                case "modify":
                    Modify();
                    break;
                default:
                    Show();
                    break;
            }
        }

        private void Show()
        {
            Model.UserSuggest model = BLL.UserSuggest.GetModel(Id);
            if (model == null) return;
            BLL.UserSuggest.Update(new Model.UserSuggest() { Id=Id,IsRead=true});

            lbTitle.Text = HtmlEncode(model.Title);
            lbDescription.Text = HtmlEncode(model.Description);
            lbUserType.Text = model.UserType == 1 ? "个人" : "企业";
            lbAddTime.Text = model.AddTime.ToString();
            txtRemark.Text = model.Remark;

            Model.User user = BLL.User.GetModel(model.UserID);
            if(user == null)return;
            lbLoginName.Text = HtmlEncode(user.LoginName);

            if (model.UserType == 1)
            {
                phCompanyName.Visible = false;
                Model.Member member = BLL.Member.GetModel(model.UserID);
                if (member != null)
                {
                    lbName.Text = HtmlEncode(member.Realname);
                    lbPhone.Text = HtmlEncode(member.Phone);
                    lbEmail.Text = HtmlEncode(member.Email);
                }
            }
            else
            {
                phCompanyName.Visible = true;
                Model.Company company = BLL.Company.GetModel(model.UserID);
                if (company != null)
                {
                    lbName.Text = HtmlEncode(company.Contact);
                    lbPhone.Text = HtmlEncode(company.Phone);
                    lbEmail.Text = HtmlEncode(company.Email);
                }
            }
        }

        private void Modify()
        {
            Model.UserSuggest model = new Model.UserSuggest();
            model.Id = Id;
            model.Remark = txtRemark.Text;
            if (BLL.UserSuggest.Update(model))
            {
                Maticsoft.Common.Ajax.WriteOk("操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
        }
    }
}