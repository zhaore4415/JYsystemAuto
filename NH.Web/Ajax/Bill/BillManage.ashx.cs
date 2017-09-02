using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace NH.Web.Ajax.Bill
{
    /// <summary>
    /// BillManage 的摘要说明
    /// </summary>
    public class BillManage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";
            context.Response.Write(GetQuarter(context));
        }
      
        private string GetQuarter(HttpContext context)
        {
            int  pagesize = context.Request["limit"] != "" ? Convert.ToInt32(context.Request["limit"]) : 0;
            int offset = context.Request["offset"] != "" ? Convert.ToInt32(context.Request["offset"]) : 0;
            //int pageIndex = context.Request["pageIndex"] != "" ? Convert.ToInt32(context.Request["pageIndex"]) : 0;
            int page = (offset / pagesize) + 1;
            string sort = context.Request["sort"] != "" ? context.Request["sort"] : "";
            string order = context.Request["order"] != "" ? context.Request["order"] : "";
            //string ddd = context.Request["temp"];

            string name = context.Request["name"];
        
            string START_DATE = context.Request["START_DATE"];
            string END_DATE = context.Request["END_DATE"];

            StringBuilder sqlWhere = new StringBuilder();
            sqlWhere.Append("1=1");
            //if (!string.IsNullOrEmpty(name))
            //{
            //    sqlWhere.AppendFormat(" AND u.LoginName like '%{0}%'", name);
            //}
           
            if (!string.IsNullOrEmpty(START_DATE))
            {
                sqlWhere.AppendFormat(" AND DeliveryTime >= '{0}' ", START_DATE);
            }
            if (!string.IsNullOrEmpty(END_DATE))
            {
                sqlWhere.AppendFormat(" AND DeliveryTime <= '{0}' ", END_DATE);
            }
            //DataSet ds = DataUtility.GetList("[Bill] fb", "fb.*", pagesize, page, "fb.[Id]", sqlWhere.ToString(), "order by " + sort + " "+ order + "", true);

            //int count = (int)ds.Tables[1].Rows[0][0];

            int count = 0;
            DataSet ds = BLL.Queryorder.GetListByPage2(sqlWhere.ToString(), sort, order, page, pagesize, ref count);

            string strJSON = JsonHelper.CreateJsonParameters(ds.Tables[0], true, count);

            return strJSON;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}