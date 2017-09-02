using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    public static partial class SysNewsRecord
    {
        public static bool Add(int articleId, int userType, SqlTransaction trans)
        {
            string sql = "insert into SysNewsRecord(ArticleId,UserId,UserType,ReadStatus) select " + articleId.ToString() + ",Id,UserType,0 from [User](nolock) where UserType=" + userType.ToString();
            return SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, null) > 0;
        }

        /// <summary>
        /// 新注册用户默认消息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        public static bool AddForNewUser(int userId,int userType)
        {
            string sql = "insert into SysNewsRecord(ArticleId,UserId,UserType,ReadStatus) select Id," + userId.ToString() + "," + userType.ToString() + ",0 from Article(nolock) where Status = 1 and CategoryID=" + (userType == 1 ? 1 : 2);
            return SqlHelper.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataSet GetList(int PageSize, int PageIndex, string strWhere, string sort,bool isReCount)
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
            parameters[0].Value = "SysNewsRecord sn(nolock) join Article a(nolock) on sn.ArticleId=a.Id";
            parameters[1].Value = "a.Id,a.Title,a.Url,a.AddTime,a.IsHilight,a.UpdateTime";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = "a.Id";
            parameters[5].Value = strWhere;
            parameters[6].Value = sort;
            parameters[7].Value = isReCount ? 1 :0;
            return SqlHelper.RunProcedure("UP_GetList", parameters, "ds");
        }

        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [SysNewsRecord] ");
            strSql.Append(" where ID in (" + Idlist + ") and UserId=" + userId.ToString());
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }

        public static int GetSysNewsCount(int userId)
        {
            string sql = "select count(Id) from SysNewsRecord sn(nolock) join Article a(nolock) on sn.ArticleId=a.Id where UserId=" + userId.ToString();
            return (int)SqlHelper.ExecuteScalar(sql, null);
        }
    }
}
