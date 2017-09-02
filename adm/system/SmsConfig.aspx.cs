using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.system
{
    public partial class SmsConfig : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show();
            }
        }

        private void Show()
        {
            Model.Config model = BLL.Config.GetModel(1);
            txtId.Text = model.Sms_ID;
            txtAccount.Text = model.Sms_Account;
            txtPassword.Text = model.Sms_Password;
            txtFrom.Text = model.Sms_SendMobile;

            if (!string.IsNullOrEmpty(model.Sms_ID) && !string.IsNullOrEmpty(model.Sms_Account) && !string.IsNullOrEmpty(model.Sms_Password))
            {
                NH.Web.SMS_Model smsmodel = new SMS().GetUserInfo();
                string smsinfo = null;
                if (smsmodel.Code == "1000")
                {
                    smsinfo = string.Format("余额：{0}元，短信价格：{1}元/条",smsmodel.Balance,smsmodel.SmsPrice);
                }
                else
                {
                    smsinfo = "获取信息失败：错误代码" + smsmodel.Code;
                }
                lbInfo.Text = smsinfo;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.Config model = new Model.Config();
            model.Id = 1;
            model.Sms_ID = txtId.Text.Trim();
            model.Sms_Account = txtAccount.Text.Trim();
            model.Sms_Password = txtPassword.Text.Trim();
            model.Sms_SendMobile = txtFrom.Text.Trim();

            if (BLL.Config.Update(model))
            {

                DataCache.RemoveDependencyFile("Config");
                Maticsoft.Common.MessageBox.ShowAndRedirect("保存成功", Request.RawUrl);
            }
            else
            {
                Maticsoft.Common.MessageBox.Show("保存失败");
            }
        }
    }
}