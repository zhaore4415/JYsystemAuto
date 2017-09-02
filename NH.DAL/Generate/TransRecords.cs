using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// TransRecords
    /// </summary>
    public static partial class TransRecords
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.TransRecords model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [TransRecords](nolock)");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.TransRecords model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.CompanyId != Int32.MinValue)
            {
                colList.Append("[CompanyId],");
                colParamList.Append("@CompanyId,");
                parameter = new SqlParameter("@CompanyId", SqlDbType.Int, 4);
                parameter.Value = model.CompanyId;
                sqlParamList.Add(parameter);
            }

            if (model.TransType != Int32.MinValue)
            {
                colList.Append("[TransType],");
                colParamList.Append("@TransType,");
                parameter = new SqlParameter("@TransType", SqlDbType.Int, 4);
                parameter.Value = model.TransType;
                sqlParamList.Add(parameter);
            }

            if (model.ChangeAmount != decimal.MinValue)
            {
                colList.Append("[ChangeAmount],");
                colParamList.Append("@ChangeAmount,");
                parameter = new SqlParameter("@ChangeAmount", SqlDbType.Decimal, 9);
                parameter.Value = model.ChangeAmount;
                sqlParamList.Add(parameter);
            }

            if (model.Balance != decimal.MinValue)
            {
                colList.Append("[Balance],");
                colParamList.Append("@Balance,");
                parameter = new SqlParameter("@Balance", SqlDbType.Decimal, 9);
                parameter.Value = model.Balance;
                sqlParamList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark],");
                colParamList.Append("@Remark,");
                parameter = new SqlParameter("@Remark", SqlDbType.NVarChar, 100);
                parameter.Value = model.Remark;
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

            if (model.AddUserType != Int32.MinValue)
            {
                colList.Append("[AddUserType],");
                colParamList.Append("@AddUserType,");
                parameter = new SqlParameter("@AddUserType", SqlDbType.Int, 4);
                parameter.Value = model.AddUserType;
                sqlParamList.Add(parameter);
            }

            if (model.AddUserId != Int32.MinValue)
            {
                colList.Append("[AddUserId],");
                colParamList.Append("@AddUserId,");
                parameter = new SqlParameter("@AddUserId", SqlDbType.Int, 4);
                parameter.Value = model.AddUserId;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [TransRecords] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from [TransRecords] ");
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
            strSql.Append("delete from [TransRecords] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.TransRecords model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [TransRecords] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.TransRecords model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.CompanyId != Int32.MinValue)
            {
                colList.Append("[CompanyId] = @CompanyId,");
                SqlParameter parameter = new SqlParameter("@CompanyId", SqlDbType.Int, 4);
                parameter.Value = model.CompanyId;
                paramList.Add(parameter);
            }

            if (model.TransType != Int32.MinValue)
            {
                colList.Append("[TransType] = @TransType,");
                SqlParameter parameter = new SqlParameter("@TransType", SqlDbType.Int, 4);
                parameter.Value = model.TransType;
                paramList.Add(parameter);
            }

            if (model.ChangeAmount != decimal.MinValue)
            {
                colList.Append("[ChangeAmount] = @ChangeAmount,");
                SqlParameter parameter = new SqlParameter("@ChangeAmount", SqlDbType.Decimal, 9);
                parameter.Value = model.ChangeAmount;
                paramList.Add(parameter);
            }

            if (model.Balance != decimal.MinValue)
            {
                colList.Append("[Balance] = @Balance,");
                SqlParameter parameter = new SqlParameter("@Balance", SqlDbType.Decimal, 9);
                parameter.Value = model.Balance;
                paramList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark] = @Remark,");
                SqlParameter parameter = new SqlParameter("@Remark", SqlDbType.NVarChar, 100);
                parameter.Value = model.Remark;
                paramList.Add(parameter);
            }

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                paramList.Add(parameter);
            }

            if (model.AddUserType != Int32.MinValue)
            {
                colList.Append("[AddUserType] = @AddUserType,");
                SqlParameter parameter = new SqlParameter("@AddUserType", SqlDbType.Int, 4);
                parameter.Value = model.AddUserType;
                paramList.Add(parameter);
            }

            if (model.AddUserId != Int32.MinValue)
            {
                colList.Append("[AddUserId] = @AddUserId,");
                SqlParameter parameter = new SqlParameter("@AddUserId", SqlDbType.Int, 4);
                parameter.Value = model.AddUserId;
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
        public static NH.Model.TransRecords GetModel(int Id)
        {
            NH.Model.TransRecords model = new NH.Model.TransRecords();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.TransRecords GetModel(NH.Model.TransRecords model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, CompanyId, TransType, ChangeAmount, Balance, Remark, AddTime, AddUserType, AddUserId ");
            strSql.Append(" from [TransRecords] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.TransRecords();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            if (row["CompanyId"].ToString() != "")
            {
                model.CompanyId = int.Parse(row["CompanyId"].ToString());
            }

            if (row["TransType"].ToString() != "")
            {
                model.TransType = int.Parse(row["TransType"].ToString());
            }

            if (row["ChangeAmount"].ToString() != "")
            {
                model.ChangeAmount = decimal.Parse(row["ChangeAmount"].ToString());
            }

            if (row["Balance"].ToString() != "")
            {
                model.Balance = decimal.Parse(row["Balance"].ToString());
            }

            model.Remark = row["Remark"].ToString();

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }

            if (row["AddUserType"].ToString() != "")
            {
                model.AddUserType = int.Parse(row["AddUserType"].ToString());
            }

            if (row["AddUserId"].ToString() != "")
            {
                model.AddUserId = int.Parse(row["AddUserId"].ToString());
            }

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
            strSql.Append(" FROM [TransRecords] ");
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
            strSql.Append(" FROM [TransRecords] ");
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



