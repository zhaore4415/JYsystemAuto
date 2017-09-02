using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// ReceiveRecord
    /// </summary>
    public static partial class ReceiveRecord
    {
        /// <summary>
        /// 
        /// </summary>
        public static DataTable GetLastRecord(int companyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 *");
            strSql.Append(" FROM [ReceiveRecord] ");
            strSql.Append(" where Status=1 and CompanyID=" + companyId);
            strSql.Append(" order by Id desc");
            return SqlHelper.ExecuteDataTable(strSql.ToString(),null);
        }

        /// <summary>
        /// 更新报名记录数
        /// </summary>
        /// <param name="company"></param>
        public static void AddSignUpCount(int company)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ReceiveRecord set SignUpCount=SignUpCount+1 where Id=(select top 1 Id from ReceiveRecord(nolock) where CompanyId=@CompanyId);");
            strSql.Append("update Company set TotalSignUp=TotalSignUp+1,CurSignUp=CurSignUp+1 where Id=@CompanyId");

            SqlParameter[] parameters = { 
                                        new SqlParameter("@CompanyId",company)
                                        };

            SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }

        public static int GetMaxTimes(int CompanyId)
        {
            string strSql = "select ISNULL(MAX(Times)+1,1) from ReceiveRecord(nolock) where CompanyId=" + CompanyId.ToString();
            return (int)SqlHelper.ExecuteScalar(strSql, null);
        }


        public static DataSet GetCalendarJobs(int pageindex,int pagesize)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@PageIndex",pageindex),
                                        new SqlParameter("@Pagesize",pagesize)
                                        };
            return SqlHelper.RunProcedure("Get_Calendar_Jobs", parameters, "ds");
        }
    }
}



