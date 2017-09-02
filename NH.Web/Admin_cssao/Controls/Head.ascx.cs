using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NH.Web.Admin_cssao.Controls
{
    public partial class Head : System.Web.UI.UserControl
    {
        protected int _interviewCount = 0;
        protected int _jobapplyCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //_jobapplyCount = GetJobApplyCount();
                _interviewCount = GetInterviewCount();
            }
        }

        //protected int GetJobApplyCount()
        //{
        //    if (UserBase.IsCompanyLogin)
        //    {
        //        return BLL.Company.GetJobApplyNoReadCount(UserBase.CurCompany.Id);
        //    }
        //    else { return 0; }
        //}

        protected int GetInterviewCount()
        {
            if (UserBase.IsPersonLogin)
            {
                return BLL.Interview.GetNoReadCountByMemberId(UserBase.CurMember.Id);
            }
            else
            {
                return 0;
            }
        }
    }
}