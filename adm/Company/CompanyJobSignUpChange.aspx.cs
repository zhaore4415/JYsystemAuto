using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NH.Web.adm.Company
{
    public partial class CompanyJobSignUpChange : WebBase.Free
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.QueryString["action"];
            if (!string.IsNullOrEmpty(action))
            {
                switch (action)
                {
                    case "Update":
                        Update();
                        break;
                }
                Response.End();
            }
        }

        private void Update()
        {
            int companyid = int.Parse(Request.Form["company"]);
            int serviceid = int.Parse(Request.Form["service"]);
            int receiveid = 0;
            int jobid = 0;
            DataTable dtReceive = BLL.ReceiveRecord.GetLastRecord(companyid);
            if (dtReceive.Rows.Count > 0)
            {
                receiveid = (int)dtReceive.Rows[0]["Id"];
            }

            Model.SignUp2Company suc = new Model.SignUp2Company();
            suc.Id = int.Parse(Request.Form["SuCId"]);
            suc.CompanyId = companyid;
            suc.JobId = jobid;
            suc.BelongUserId = serviceid;
            suc.BelongUserName = BLL.AUser.GetModel(serviceid).Realname;
            suc.ReceiveId = receiveid;

            BLL.SignUp2Company.Update(suc);

            Maticsoft.Common.Ajax.WriteOk("操作成功");
        }
    }
}