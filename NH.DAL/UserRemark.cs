using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// UserRemark
    /// </summary>
    public static partial class UserRemark
    {
        /// <summary>
        /// 删除标记
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="memberId"></param>
        /// <param name="remarkTypeId"></param>
        /// <returns></returns>
        public static bool Delete(int companyId, int memberId, int remarkTypeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [UserRemark] ");
            strSql.Append(" where CompanyId=@CompanyId and MemberId=@MemberId and RemarkTypeId=@RemarkTypeId");
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyId", SqlDbType.Int,4),
					new SqlParameter("@MemberId", SqlDbType.Int,4),
					new SqlParameter("@RemarkTypeId", SqlDbType.Int,4)

			};
            parameters[0].Value = companyId;
            parameters[1].Value = memberId;
            parameters[2].Value = remarkTypeId;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 获取标记
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="memberid"></param>
        /// <returns></returns>
        public static DataTable GetRemark(int companyId,int memberid)
        {
            string strSql = "select t.Id,t.Name,r.Id as rid from UserRemarkType t(nolock) left join UserRemark r(nolock) on t.Id=r.RemarkTypeId and r.CompanyId=@CompanyID and MemberId=@MemberId";
            SqlParameter[] parameters = { 
					new SqlParameter("@CompanyId", SqlDbType.Int,4),
					new SqlParameter("@MemberId", SqlDbType.Int,4)
                                        };
            parameters[0].Value = companyId;
            parameters[1].Value = memberid;
            return SqlHelper.ExecuteDataTable(strSql, parameters);
        }
    }
}



