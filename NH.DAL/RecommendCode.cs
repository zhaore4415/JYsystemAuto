using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// RecommendCode
    /// </summary>
    public static partial class RecommendCode
    {

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateCode(NH.Model.RecommendCode model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [RecommendCode] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where TJCode=@TJCode ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion
    }
}



