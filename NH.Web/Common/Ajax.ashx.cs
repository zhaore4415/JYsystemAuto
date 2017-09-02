using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.Common
{
    /// <summary>
    /// Summary description for Ajax
    /// </summary>
    public class Ajax : IHttpHandler, IReadOnlySessionState
    {

        HttpRequest Request = HttpContext.Current.Request;
        HttpResponse Response = HttpContext.Current.Response;
        public void ProcessRequest(HttpContext context)
        {
            switch (Request.QueryString["action"])
            {
                case "CheckMemberMobile":
                    CheckMemberMobile();
                    break;
                case "ValidateMemberMobile":
                    ValidateMemberMobile();
                    break;
                case "ValidateUserName":
                    ValidateUserName();
                    break;
                case "ValidateVCode":
                    ValidateVCode();
                    break;
                case "ValidateMobileCode":
                    ValidateMobileCode();
                    break;
                case "ValidateCompanyEmail":
                    ValidateCompanyEmail();
                    break;
             
                case "GetSubAreaOpts":
                    GetSubAreaOpts();
                    break;
            
                case "GetCalendarJobs":
                    GetCalendarJobs();
                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 检测个人用户手机号是否已存在
        /// </summary>
        private void CheckMemberMobile()
        {
            string mobile = Request.Form["mobile"];
            if (string.IsNullOrEmpty(mobile))
            {
                Maticsoft.Common.Ajax.WriteError("请输入手机号码");
            }
            Model.Member model = new Model.Member();
            model.Mobile = mobile;
            if (BLL.Member.Exists(model))
            {
                Maticsoft.Common.Ajax.WriteOk("1");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteOk("0");
            }
        }

        /// <summary>
        /// 检测个人用户手机号是否已存在
        /// </summary>
        private void ValidateMemberMobile()
        {
            string mobile = Request.QueryString[Request.QueryString["clientid"]];
            if (string.IsNullOrEmpty(mobile))
            {
                Maticsoft.Common.Ajax.WriteError("请输入手机号码");
            }
            Model.Member model = new Model.Member();
            model.Mobile = mobile;
            if (BLL.Member.Exists(model))
            {
                Maticsoft.Common.Ajax.WriteOk("1");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteOk("0");
            }
        }

        private void ValidateUserName()
        {
            string username = Request.QueryString[Request.QueryString["clientid"]];
            Model.User user = new Model.User() { LoginName = username };

            if (BLL.User.Exists(user))
            {
                Maticsoft.Common.Ajax.WriteOk("1");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteOk("0");
            }
        }
        /// <summary>
        /// 检测企业用户邮箱是否已存在
        /// </summary>
        private void ValidateCompanyEmail()
        {
            string email = Request.QueryString[Request.QueryString["clientid"]];
            if (string.IsNullOrEmpty(email))
            {
                Maticsoft.Common.Ajax.WriteError("请输入邮箱");
            }
            Model.Company model = new Model.Company();
            model.Email = email;
            if (BLL.Company.Exists(model))
            {
                Maticsoft.Common.Ajax.WriteOk("1");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteOk("0");
            }
        }

        private void ValidateVCode()
        {
            string code = Request.QueryString[Request.QueryString["clientid"]];
            HttpCookie hc = Request.Cookies[Request.QueryString["vctype"]];
            if (hc == null || Utility.EncryptValidateCode(code) != hc.Value)
            {
                Maticsoft.Common.Ajax.WriteOk("0");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteOk("1");
            }

        }

        private void ValidateMobileCode()
        {
            string code = Request.QueryString[Request.QueryString["clientid"]];
            int codeType = int.Parse(Request.QueryString["type"]);
            string mobile = Request.QueryString["txtMobile"];

            DataTable dt = BLL.SmsCode.GetList(1, "CodeType=1 and Status=1 and Mobile ='" + mobile.Replace("'", "''") + "'", "Id desc").Tables[0];

            if (dt.Rows.Count == 0)
            {
                Maticsoft.Common.Ajax.WriteOk("0");//不通过
            }
            if (dt.Rows[0]["Code"].ToString() != code)
            {
                Maticsoft.Common.Ajax.WriteOk("0");//不通过
            }
            else
            {
                Maticsoft.Common.Ajax.WriteOk("1");//通过 
            }

        }

       


        /// <summary>
        /// 获取地区下拉选择项
        /// </summary>
        private void GetSubAreaOpts()
        {
            string parentNo = Request.QueryString["pid"] == "0" ? "1" : Request.QueryString["pid"];
            string selectedNo = Request.QueryString["sid"];

            StringBuilder sb = new StringBuilder();
            DataTable dt = BLL.Area.GetListByCache("ParentNo='" + parentNo + "'");
            foreach (DataRow row in dt.Rows)
            {
                sb.Append(string.Format("<option value=\"{0}\" {1}>{2}</option>", row["AreaNo"], (row["AreaNo"].ToString() == selectedNo ? "selected=\"selected\"" : ""), row["Name"]));
            }
            Response.Write(sb);
        }
     


        /// <summary>
        /// 提交咨询
        /// </summary>
        private void AddAsk()
        { }

        private void GetCalendarJobs()
        {
            ViewManager<Controls.Calendar> viewManager = new ViewManager<Controls.Calendar>();
            Controls.Calendar control = viewManager.LoadViewControl("~/Controls/Calendar.ascx");
            control.PageIndex = int.Parse(Request.QueryString["page"]);
            //control.CompanyID = int.Parse(Request.QueryString["companyid"]);

            Response.Write(viewManager.RenderView(control));
        }
    }


}