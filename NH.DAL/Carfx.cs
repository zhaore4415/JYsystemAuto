using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace NH.DAL
{
    public partial class Carfx
    {
        public static int GetNums(string uid, long OrderSN)
        {
            return (int)SqlHelper.ExecuteScalar("SELECT sum(Num) from [Carfx] where UId=" + uid + " and OrderNumber=" + OrderSN);
        }
        public static int GetSums(string uid, long OrderSN)
        {
            return (int)SqlHelper.ExecuteScalar("select sum(JiFenPrice) from [Carfx] where UId=" + uid + " and OrderNumber=" + OrderSN);
        }

        #region 删除一条数据
        /// <summary>
        /// 根据订单号删除数据
        /// </summary>
        public static bool DeleteUId(int uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Carfx ");
            strSql.Append(" where UId=@UId");
            SqlParameter[] parameters = {
					new SqlParameter("@UId", SqlDbType.Int, 4)
			};
            parameters[0].Value = uid;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateNum(NH.Model.Carfx model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Carfx] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where PName=@PName ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        ///  更新订单状态
        /// </summary>
        public static bool UpdateOrder(NH.Model.Carfx model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Carfx] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where OrderNumber=@OrderNumber ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

    
    }
}
