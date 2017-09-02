using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// OnlinePayOrder
    /// </summary>
    public static partial class OnlinePayOrder
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.OnlinePayOrder model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [OnlinePayOrder](nolock)");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.OnlinePayOrder model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.TradeTime.HasValue)
            {
                colList.Append("[TradeTime],");
                colParamList.Append("@TradeTime,");
                parameter = new SqlParameter("@TradeTime", SqlDbType.DateTime);
                if (model.TradeTime.Value != DateTime.MinValue)
                    parameter.Value = model.TradeTime.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.OrderDesc != null)
            {
                colList.Append("[OrderDesc],");
                colParamList.Append("@OrderDesc,");
                parameter = new SqlParameter("@OrderDesc", SqlDbType.NVarChar, 100);
                parameter.Value = model.OrderDesc;
                sqlParamList.Add(parameter);
            }

            if (model.BuyerEmail != null)
            {
                colList.Append("[BuyerEmail],");
                colParamList.Append("@BuyerEmail,");
                parameter = new SqlParameter("@BuyerEmail", SqlDbType.NVarChar, 50);
                parameter.Value = model.BuyerEmail;
                sqlParamList.Add(parameter);
            }

            if (model.Contact != null)
            {
                colList.Append("[Contact],");
                colParamList.Append("@Contact,");
                parameter = new SqlParameter("@Contact", SqlDbType.NVarChar, 50);
                parameter.Value = model.Contact;
                sqlParamList.Add(parameter);
            }

            if (model.Status != Int32.MinValue)
            {
                colList.Append("[Status],");
                colParamList.Append("@Status,");
                parameter = new SqlParameter("@Status", SqlDbType.Int, 4);
                parameter.Value = model.Status;
                sqlParamList.Add(parameter);
            }

            if (model.StartDate.HasValue)
            {
                colList.Append("[StartDate],");
                colParamList.Append("@StartDate,");
                parameter = new SqlParameter("@StartDate", SqlDbType.SmallDateTime);
                if (model.StartDate.Value != DateTime.MinValue)
                    parameter.Value = model.StartDate.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.EndDate.HasValue)
            {
                colList.Append("[EndDate],");
                colParamList.Append("@EndDate,");
                parameter = new SqlParameter("@EndDate", SqlDbType.SmallDateTime);
                if (model.EndDate.Value != DateTime.MinValue)
                    parameter.Value = model.EndDate.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.OrderNo != null)
            {
                colList.Append("[OrderNo],");
                colParamList.Append("@OrderNo,");
                parameter = new SqlParameter("@OrderNo", SqlDbType.NVarChar, 30);
                parameter.Value = model.OrderNo;
                sqlParamList.Add(parameter);
            }

            if (model.CompanyID != Int32.MinValue)
            {
                colList.Append("[CompanyID],");
                colParamList.Append("@CompanyID,");
                parameter = new SqlParameter("@CompanyID", SqlDbType.Int, 4);
                parameter.Value = model.CompanyID;
                sqlParamList.Add(parameter);
            }

            if (model.CompanyName != null)
            {
                colList.Append("[CompanyName],");
                colParamList.Append("@CompanyName,");
                parameter = new SqlParameter("@CompanyName", SqlDbType.NVarChar, 50);
                parameter.Value = model.CompanyName;
                sqlParamList.Add(parameter);
            }

            if (model.LoginName != null)
            {
                colList.Append("[LoginName],");
                colParamList.Append("@LoginName,");
                parameter = new SqlParameter("@LoginName", SqlDbType.NVarChar, 50);
                parameter.Value = model.LoginName;
                sqlParamList.Add(parameter);
            }

            if (model.LevelId != Int32.MinValue)
            {
                colList.Append("[LevelId],");
                colParamList.Append("@LevelId,");
                parameter = new SqlParameter("@LevelId", SqlDbType.Int, 4);
                parameter.Value = model.LevelId;
                sqlParamList.Add(parameter);
            }

            if (model.TotalPrice != decimal.MinValue)
            {
                colList.Append("[TotalPrice],");
                colParamList.Append("@TotalPrice,");
                parameter = new SqlParameter("@TotalPrice", SqlDbType.Decimal, 9);
                parameter.Value = model.TotalPrice;
                sqlParamList.Add(parameter);
            }

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime],");
                colParamList.Append("@AddTime,");
                parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                sqlParamList.Add(parameter);
            }

            if (model.TradeNo != null)
            {
                colList.Append("[TradeNo],");
                colParamList.Append("@TradeNo,");
                parameter = new SqlParameter("@TradeNo", SqlDbType.NVarChar, 50);
                parameter.Value = model.TradeNo;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [OnlinePayOrder] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
            strSql += ";select @@IDENTITY";

            object obj = SqlHelper.ExecuteScalar(strSql, sqlParamList.ToArray());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [OnlinePayOrder] ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion


        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [OnlinePayOrder] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.OnlinePayOrder model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [OnlinePayOrder] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.OnlinePayOrder model, ref SqlParameter[] parameters, bool isUpdate)
        {
            StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (model.Id != Int32.MinValue)
            {
                if (!isUpdate) colList.Append("[Id] = @Id,");
                SqlParameter parameter = new SqlParameter("@Id", SqlDbType.Int, 4);
                parameter.Value = model.Id;
                paramList.Add(parameter);
            }

            if (model.TradeTime.HasValue)
            {
                colList.Append("[TradeTime] = @TradeTime,");
                SqlParameter parameter = new SqlParameter("@TradeTime", SqlDbType.DateTime);
                if (model.TradeTime.Value != DateTime.MinValue)
                    parameter.Value = model.TradeTime.Value;
                else
                    parameter.Value = DBNull.Value;
                paramList.Add(parameter);
            }

            if (model.OrderDesc != null)
            {
                colList.Append("[OrderDesc] = @OrderDesc,");
                SqlParameter parameter = new SqlParameter("@OrderDesc", SqlDbType.NVarChar, 100);
                parameter.Value = model.OrderDesc;
                paramList.Add(parameter);
            }

            if (model.BuyerEmail != null)
            {
                colList.Append("[BuyerEmail] = @BuyerEmail,");
                SqlParameter parameter = new SqlParameter("@BuyerEmail", SqlDbType.NVarChar, 50);
                parameter.Value = model.BuyerEmail;
                paramList.Add(parameter);
            }

            if (model.Contact != null)
            {
                colList.Append("[Contact] = @Contact,");
                SqlParameter parameter = new SqlParameter("@Contact", SqlDbType.NVarChar, 50);
                parameter.Value = model.Contact;
                paramList.Add(parameter);
            }

            if (model.Status != Int32.MinValue)
            {
                colList.Append("[Status] = @Status,");
                SqlParameter parameter = new SqlParameter("@Status", SqlDbType.Int, 4);
                parameter.Value = model.Status;
                paramList.Add(parameter);
            }

            if (model.StartDate.HasValue)
            {
                colList.Append("[StartDate] = @StartDate,");
                SqlParameter parameter = new SqlParameter("@StartDate", SqlDbType.SmallDateTime);
                if (model.StartDate.Value != DateTime.MinValue)
                    parameter.Value = model.StartDate.Value;
                else
                    parameter.Value = DBNull.Value;
                paramList.Add(parameter);
            }

            if (model.EndDate.HasValue)
            {
                colList.Append("[EndDate] = @EndDate,");
                SqlParameter parameter = new SqlParameter("@EndDate", SqlDbType.SmallDateTime);
                if (model.EndDate.Value != DateTime.MinValue)
                    parameter.Value = model.EndDate.Value;
                else
                    parameter.Value = DBNull.Value;
                paramList.Add(parameter);
            }

            if (model.OrderNo != null)
            {
                colList.Append("[OrderNo] = @OrderNo,");
                SqlParameter parameter = new SqlParameter("@OrderNo", SqlDbType.NVarChar, 30);
                parameter.Value = model.OrderNo;
                paramList.Add(parameter);
            }

            if (model.CompanyID != Int32.MinValue)
            {
                colList.Append("[CompanyID] = @CompanyID,");
                SqlParameter parameter = new SqlParameter("@CompanyID", SqlDbType.Int, 4);
                parameter.Value = model.CompanyID;
                paramList.Add(parameter);
            }

            if (model.CompanyName != null)
            {
                colList.Append("[CompanyName] = @CompanyName,");
                SqlParameter parameter = new SqlParameter("@CompanyName", SqlDbType.NVarChar, 50);
                parameter.Value = model.CompanyName;
                paramList.Add(parameter);
            }

            if (model.LoginName != null)
            {
                colList.Append("[LoginName] = @LoginName,");
                SqlParameter parameter = new SqlParameter("@LoginName", SqlDbType.NVarChar, 50);
                parameter.Value = model.LoginName;
                paramList.Add(parameter);
            }

            if (model.LevelId != Int32.MinValue)
            {
                colList.Append("[LevelId] = @LevelId,");
                SqlParameter parameter = new SqlParameter("@LevelId", SqlDbType.Int, 4);
                parameter.Value = model.LevelId;
                paramList.Add(parameter);
            }

            if (model.TotalPrice != decimal.MinValue)
            {
                colList.Append("[TotalPrice] = @TotalPrice,");
                SqlParameter parameter = new SqlParameter("@TotalPrice", SqlDbType.Decimal, 9);
                parameter.Value = model.TotalPrice;
                paramList.Add(parameter);
            }

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                paramList.Add(parameter);
            }

            if (model.TradeNo != null)
            {
                colList.Append("[TradeNo] = @TradeNo,");
                SqlParameter parameter = new SqlParameter("@TradeNo", SqlDbType.NVarChar, 50);
                parameter.Value = model.TradeNo;
                paramList.Add(parameter);
            }
            string result = null;
            if (colList.Length > 0)
            {
                if (isUpdate)
                {
                    paramList.Add(paramList[0]);
                    paramList.RemoveAt(0);
                    result = colList.ToString().TrimEnd(',');
                }
                else
                {
                    result = "where " + colList.ToString().TrimEnd(',').Replace(",", " and ");
                }
            }
            parameters = paramList.ToArray();
            return result;
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.OnlinePayOrder GetModel(int Id)
        {
            NH.Model.OnlinePayOrder model = new NH.Model.OnlinePayOrder();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.OnlinePayOrder GetModel(NH.Model.OnlinePayOrder model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, TradeTime, OrderDesc, BuyerEmail, Contact, Status, StartDate, EndDate, OrderNo, CompanyID, CompanyName, LoginName, LevelId, TotalPrice, AddTime, TradeNo ");
            strSql.Append(" from [OnlinePayOrder] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.OnlinePayOrder();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            if (row["TradeTime"].ToString() != "")
            {
                model.TradeTime = DateTime.Parse(row["TradeTime"].ToString());
            }

            model.OrderDesc = row["OrderDesc"].ToString();

            model.BuyerEmail = row["BuyerEmail"].ToString();

            model.Contact = row["Contact"].ToString();

            if (row["Status"].ToString() != "")
            {
                model.Status = int.Parse(row["Status"].ToString());
            }

            if (row["StartDate"].ToString() != "")
            {
                model.StartDate = DateTime.Parse(row["StartDate"].ToString());
            }

            if (row["EndDate"].ToString() != "")
            {
                model.EndDate = DateTime.Parse(row["EndDate"].ToString());
            }

            model.OrderNo = row["OrderNo"].ToString();

            if (row["CompanyID"].ToString() != "")
            {
                model.CompanyID = int.Parse(row["CompanyID"].ToString());
            }

            model.CompanyName = row["CompanyName"].ToString();

            model.LoginName = row["LoginName"].ToString();

            if (row["LevelId"].ToString() != "")
            {
                model.LevelId = int.Parse(row["LevelId"].ToString());
            }

            if (row["TotalPrice"].ToString() != "")
            {
                model.TotalPrice = decimal.Parse(row["TotalPrice"].ToString());
            }

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }

            model.TradeNo = row["TradeNo"].ToString();

            return model;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [OnlinePayOrder] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.ExecuteDataSet(strSql.ToString());
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM [OnlinePayOrder] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.ExecuteDataSet(strSql.ToString());
        }
        #endregion
    }
}



