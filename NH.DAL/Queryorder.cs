using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Data;

namespace NH.DAL
{
    public static partial class Queryorder
    {
        public static long GetMaxSort()
        {
            return (long)SqlHelper.ExecuteScalar("SELECT isnull(max(OrderNumber),0)+1 from Queryorder");
        }
        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateOrder(NH.Model.Queryorder model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Queryorder] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where OrderNumber=@OrderNumber ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool ExistsOrder(long OrderNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Queryorder] ");
            strSql.Append(" where OrderNumber=@OrderNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNumber",SqlDbType.BigInt, 8)
			};
            parameters[0].Value = OrderNumber;
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion
    }
}
