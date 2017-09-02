using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// Interview
	/// </summary>
	public static partial class Interview
    {
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataSet GetList(int PageSize, int PageIndex, string strWhere, string sort)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.NVarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 500),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@key", SqlDbType.NVarChar),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@sort", SqlDbType.NVarChar,50),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    };
            parameters[0].Value = "interview i(nolock) left join Member m(nolock) on i.MemberID=m.Id";
            parameters[1].Value = "i.*,m.Realname";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = "i.Id";
            parameters[5].Value = strWhere;
            parameters[6].Value = sort;
            parameters[7].Value = 1;
            return SqlHelper.RunProcedure("UP_GetList", parameters, "ds");
        }


        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteListByCompany(string Idlist,int companyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Interview] ");
            strSql.Append(" where ID in (" + Idlist + ") and CompanyID=" + companyId.ToString());
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteListByMember(string Idlist, int memberId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Interview] ");
            strSql.Append(" where ID in (" + Idlist + ") and MemberID=" + memberId.ToString());
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        public static DataSet GetCountByMemberId(int memberId)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@MemberID",memberId)
                                        };
            string strSql = @"select count(i.Id) from Interview i(nolock) join Company c(nolock) on i.CompanyID=c.Id where MemberID=@MemberID;
            select count(i.Id) from Interview i(nolock) join Company c(nolock) on i.CompanyID=c.Id where ReadStatus=0 and MemberID=@MemberID";
            return SqlHelper.ExecuteDataSet(strSql,parameters);
        }

        /// <summary>
        /// 获取新面试通知数量
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public static int GetNoReadCountByMemberId(int memberId)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@MemberID",memberId)
                                        };
            string strSql = @"select count(i.Id) from Interview i(nolock) join Company c(nolock) on i.CompanyID=c.Id where ReadStatus=0 and MemberID=@MemberID";
            return (int)SqlHelper.ExecuteScalar(strSql, parameters);
        }
	}
}



