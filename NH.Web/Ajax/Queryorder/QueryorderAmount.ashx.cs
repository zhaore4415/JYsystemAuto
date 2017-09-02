using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.Ajax.Queryorder
{
    /// <summary>
    /// QueryorderAmount 的摘要说明
    /// </summary>
    public class QueryorderAmount : IHttpHandler
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
        //Object locker = new Object();
        private string GetQuarter(HttpContext context)
        {
            string action = context.Request["action"];
            string U_ID = context.Request.Params["U_ID"];
            string START_DATE = context.Request["START_DATE"];
            string END_DATE = context.Request["END_DATE"];
            string sum = "";
            //decimal num = 0M;
            StringBuilder sqlWhere = new StringBuilder();
            StringBuilder sqlWhere1 = new StringBuilder();
            StringBuilder sqlWhere2 = new StringBuilder();
            sqlWhere.Append(" 1=1 ");
            sqlWhere1.Append(" 1=1 ");
            sqlWhere2.Append(" 1=1 ");

            if (!string.IsNullOrEmpty(START_DATE))
            {
                sqlWhere.AppendFormat(" AND DeliveryTime >= '{0}' ", START_DATE);
            }
            if (!string.IsNullOrEmpty(END_DATE))
            {
                sqlWhere.AppendFormat(" AND DeliveryTime <= '{0}' ", END_DATE);
            }


            if (action == "oneAmount")
            {
                if (!string.IsNullOrEmpty(U_ID))
                {
                    sqlWhere.AppendFormat(" AND U_ID in (select Id from [User] where ParentID={0}) ", U_ID);
                }

                sum = BLL.Queryorder.OneAmount(sqlWhere.ToString());
            }
            else if (action == "twoAmount")
            {
                if (!string.IsNullOrEmpty(U_ID))
                {
                    sqlWhere.AppendFormat(" AND U_ID in (select Id from [User] where ParentID in( select Id from [User] where  ParentID={0})) ", U_ID);
                }
                //lock (this.locker)
                sum = BLL.Queryorder.OneAmount(sqlWhere.ToString());
            }
            else
            {
                if (!string.IsNullOrEmpty(U_ID))
                {
                    sqlWhere1.AppendFormat(" AND U_ID in (select Id from [User] where ParentID={0}) ", U_ID);
                    sqlWhere2.AppendFormat(" AND U_ID in (select Id from [User] where ParentID in( select Id from [User] where  ParentID={0})) ", U_ID);
                }
                sum = BLL.Queryorder.onePlustwoAmount(sqlWhere1.ToString(), sqlWhere2.ToString());
            }


            return sum;
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