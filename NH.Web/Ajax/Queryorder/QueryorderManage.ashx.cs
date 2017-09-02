using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.Ajax.Queryorder
{
    /// <summary>
    /// QueryorderManage 的摘要说明
    /// </summary>
    public class QueryorderManage : IHttpHandler
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
            int pagesize = context.Request["limit"] != "" ? Convert.ToInt32(context.Request["limit"]) : 0;
            int offset = context.Request["offset"] != "" ? Convert.ToInt32(context.Request["offset"]) : 0;
            //int pageIndex = context.Request["pageIndex"] != "" ? Convert.ToInt32(context.Request["pageIndex"]) : 0;
            int page = (offset / pagesize) + 1;
            string sort = context.Request["sort"] != "" ? context.Request["sort"] : "";
            string order = context.Request["order"] != "" ? context.Request["order"] : "";
            //string ddd = context.Request["temp"];
            string U_ID = context.Request["U_ID"];
            string name = context.Request["name"];
            string OrderNumber = context.Request["OrderNumber"];
            string status = context.Request["status"];
            string START_DATE = context.Request["START_DATE"];
            string END_DATE = context.Request["END_DATE"];

            StringBuilder sqlWhere = new StringBuilder();
            sqlWhere.Append(" 1=1 ");
            if (!string.IsNullOrEmpty(U_ID))
            {
                sqlWhere.AppendFormat(" AND fb.U_ID={0} ", U_ID);
            }
            if (!string.IsNullOrEmpty(name))
            {
                sqlWhere.AppendFormat(" AND  U.LoginName like '%{0}%'", name);
            }
            if (!string.IsNullOrEmpty(OrderNumber))
            {
                sqlWhere.AppendFormat(" AND fb.OrderNumber like '%{0}%'", OrderNumber);
            }
            if (!string.IsNullOrEmpty(status))
            {
                sqlWhere.AppendFormat(" AND fb.Status={0} ", status);
            }
            if (!string.IsNullOrEmpty(START_DATE))
            {
                sqlWhere.AppendFormat(" AND fb.DeliveryTime >= '{0}' ", START_DATE);
            }
            if (!string.IsNullOrEmpty(END_DATE))
            {
                sqlWhere.AppendFormat(" AND fb.DeliveryTime <= '{0}' ", END_DATE);
            }
            //DataSet ds = BLL.Queryorder.GetList(0, sqlWhere.ToString(), sort + " " + order);
            int count = 0;
            DataSet ds = BLL.Queryorder.GetListByPage(sqlWhere.ToString(), sort, order, page, pagesize, ref count);
            //DataSet ds =  DataUtility.GetList("[Queryorder] fb", "fb.*", pagesize, page, "fb.[Id]", sqlWhere.ToString(), "order by " + sort + " " + order + "", true);

            //int count = (int)ds.Tables[1].Rows[0][0];

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