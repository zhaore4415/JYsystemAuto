using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Ajax
{
    /// <summary>
    /// Summary description for Common
    /// </summary>
    public class Common : IHttpHandler
    {
        HttpRequest Request = HttpContext.Current.Request;
        HttpResponse Response = HttpContext.Current.Response;

        public void ProcessRequest(HttpContext context)
        {
            switch (Request["action"])
            {
                case "GetCompanyModal":
                    GetCompanyModal();
                    break;
                case "GetCompanyJobs":
                    GetCompanyJobs();
                    break;
                case "GetCustomerService":
                    GetCustomerService();
                    break;
                case "GetCompanyByService":
                    GetCompanyByService();
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

        private void GetCompanyModal()
        {
            DataTable dt = BLL.Company.GetList("Id=" + int.Parse(Request.QueryString["id"])).Tables[0];
            Response.Write(Maticsoft.Common.DataToJson.DtToJson(dt));
        }

        private void GetCompanyJobs()
        {
            int cid = int.Parse(Request.QueryString["companyid"]);
            DataTable dt = DataUtility.GetList("Job j(nolock) join JobCategory jc(nolock) on j.CategoryNo=jc.CategoryNo", "j.Id,jc.Name,j.UpdateTime,j.RefreshTime,j.Status,j.Verified", 0, 1, "j.Id", "and j.CompanyId=" + cid, "", false).Tables[0];
            Response.Write(Maticsoft.Common.DataToJson.DtToJson(dt));
        }

        private void GetCustomerService()
        {
            //DataTable dt = BLL.AUser.GetList(0, "", "Realname").Tables[0];
            DataTable dt = DataUtility.GetList("AUser (nolock)","Id,LoginName,Realname","Realname","",1,0,false).Tables[0];
            Response.Write(Maticsoft.Common.DataToJson.DtToJson2(dt));
        }

        private void GetCompanyByService()
        {
            DataTable dt = DataUtility.GetList(
                "Service2Company sc(nolock) left join Company c(nolock) on sc.CompanyId=c.Id",
                "c.Id,c.CompanyName",
                "c.CompanyName",
                "and sc.ServiceId=" + Request.QueryString["serviceid"],
                1,
                0,
                false).Tables[0];

            Response.Write(Maticsoft.Common.DataToJson.DtToJson2(dt));
        }





    }
}