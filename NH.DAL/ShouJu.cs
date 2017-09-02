using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// ShouJu
    /// </summary>
    public static partial class ShouJu
    {

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteShouJu(int Fid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ShouJu ");
            strSql.Append(" where Fid=@Fid");
            SqlParameter[] parameters = {
				new SqlParameter("@Fid", SqlDbType.Int,4)	
			};
            parameters[0].Value = Fid;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion
    }
}
