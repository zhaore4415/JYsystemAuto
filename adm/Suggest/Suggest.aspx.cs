using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Suggest
{
    public partial class Suggest : WebBase.Free
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("InfomationManage");
            switch (Request.QueryString["action"])
            {
                case "GetList":
                    GetList();
                    break;
                case "Delete":
                    Delete();
                    break;
                default:
                    break;
            }
        }

        private void GetList()
        {
            #region
            int pagesize = EasyUI.GetPageSize();//每页显示数量
            int pageindex = EasyUI.GetPageIndex();//页码
            #endregion
            string strWhere = null;
            string loginname = Request.Form["loginname"];
            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];
            string readstatus = Request.Form["readstatus"];
            string usertype = Request.Form["usertype"];

            #region
            if (!string.IsNullOrEmpty(loginname))
            {
                strWhere += " and u.LoginName = '" + loginname.Replace("'", "''") + "'";
            }
            if (!string.IsNullOrEmpty(starttime))
            {
                try
                {
                    strWhere += " and us.AddTime >= '" + DateTime.Parse(starttime) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(endtime))
            {
                try
                {
                    strWhere += " and us.AddTime < '" + DateTime.Parse(endtime).AddDays(1) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(readstatus) && PageValidate.IsNumber(readstatus))
            {
                strWhere += " and us.IsRead=" + readstatus;
            }
            if (!string.IsNullOrEmpty(usertype) && PageValidate.IsNumber(usertype))
            {
                strWhere += " and us.UserType=" + usertype;
            }
            #endregion

            Response.Write(
                DataUtility.GetListToJson(
                "UserSuggest us(nolock) left join [User] u(nolock) on us.UserId=u.Id left join Company c(nolock) on u.Id=c.Id left join Member m(nolock) on m.Id=u.Id"
                , "us.Id,us.Title,us.IsRead,us.AddTime,u.LoginName,u.UserType,c.CompanyName,(case u.UserType when 1 then m.Realname when 2 then c.Contact end) as Name,(case u.UserType when 1 then m.Phone when 2 then c.Phone end) as Phone,(case u.UserType when 1 then m.Email when 2 then c.Email end) as Email"
                , pagesize
                , pageindex
                , "us.Id"
                , strWhere
                , "order by us.Id desc"
                , true)
                );
            Response.End();
        }

        private void Delete()
        {
            BLL.UserSuggest.Delete(Id);
            Maticsoft.Common.Ajax.WriteOk("删除成功");
        }
    }
}