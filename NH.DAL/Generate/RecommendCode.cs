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
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.RecommendCode model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [RecommendCode] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.RecommendCode model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.TJCode != null)
            {
                colList.Append("[TJCode],");
                colParamList.Append("@TJCode,");
                parameter = new SqlParameter("@TJCode", SqlDbType.NVarChar, 30);
                parameter.Value = model.TJCode;
                sqlParamList.Add(parameter);
            }

            if (model.AddTime.HasValue)
            {
                colList.Append("[AddTime],");
                colParamList.Append("@AddTime,");
                parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                if (model.AddTime.Value != DateTime.MinValue)
                    parameter.Value = model.AddTime.Value;
                else
                    parameter.Value = DBNull.Value;

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

            if (model.U_ID.HasValue)
            {
                colList.Append("[U_ID],");
                colParamList.Append("@U_ID,");
                parameter = new SqlParameter("@U_ID", SqlDbType.Int, 4);
                if (model.U_ID.Value != Int32.MinValue)
                    parameter.Value = model.U_ID.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.FailureTime.HasValue)
            {
                colList.Append("[FailureTime],");
                colParamList.Append("@FailureTime,");
                parameter = new SqlParameter("@FailureTime", SqlDbType.DateTime);
                if (model.FailureTime.Value != DateTime.MinValue)
                    parameter.Value = model.FailureTime.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.TJZheKou.HasValue)
            {
                colList.Append("[TJZheKou],");
                colParamList.Append("@TJZheKou,");
                parameter = new SqlParameter("@TJZheKou", SqlDbType.Decimal, 9);
                if (model.TJZheKou.Value != decimal.MinValue)
                    parameter.Value = model.TJZheKou.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [RecommendCode] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from RecommendCode ");
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
            strSql.Append("delete from [RecommendCode] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.RecommendCode model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [RecommendCode] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.RecommendCode model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.TJCode != null)
            {
                colList.Append("[TJCode] = @TJCode,");
                SqlParameter parameter = new SqlParameter("@TJCode", SqlDbType.NVarChar, 30);
                parameter.Value = model.TJCode;
                paramList.Add(parameter);
            }

            if (model.AddTime.HasValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime.Value;
                paramList.Add(parameter);
            }

            if (model.Status != Int32.MinValue)
            {
                colList.Append("[Status] = @Status,");
                SqlParameter parameter = new SqlParameter("@Status", SqlDbType.Int, 4);
                parameter.Value = model.Status;
                paramList.Add(parameter);
            }

            if (model.U_ID.HasValue)
            {
                colList.Append("[U_ID] = @U_ID,");
                SqlParameter parameter = new SqlParameter("@U_ID", SqlDbType.Int, 4);
                parameter.Value = model.U_ID.Value;
                paramList.Add(parameter);
            }

            if (model.FailureTime.HasValue)
            {
                colList.Append("[FailureTime] = @FailureTime,");
                SqlParameter parameter = new SqlParameter("@FailureTime", SqlDbType.DateTime);
                parameter.Value = model.FailureTime.Value;
                paramList.Add(parameter);
            }

            if (model.TJZheKou.HasValue)
            {
                colList.Append("[TJZheKou] = @TJZheKou,");
                SqlParameter parameter = new SqlParameter("@TJZheKou", SqlDbType.Decimal, 9);
                parameter.Value = model.TJZheKou.Value;
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
        public static NH.Model.RecommendCode GetModel(int Id)
        {
            NH.Model.RecommendCode model = new NH.Model.RecommendCode();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.RecommendCode GetModel(NH.Model.RecommendCode model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [Id], [TJCode], [AddTime], [Status], [U_ID], [FailureTime], [TJZheKou] ");
            strSql.Append(" from [RecommendCode] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.RecommendCode();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            model.TJCode = row["TJCode"].ToString();

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }

            if (row["Status"].ToString() != "")
            {
                model.Status = int.Parse(row["Status"].ToString());
            }

            if (row["U_ID"].ToString() != "")
            {
                model.U_ID = int.Parse(row["U_ID"].ToString());
            }

            if (row["FailureTime"].ToString() != "")
            {
                model.FailureTime = DateTime.Parse(row["FailureTime"].ToString());
            }

            if (row["TJZheKou"].ToString() != "")
            {
                model.TJZheKou = decimal.Parse(row["TJZheKou"].ToString());
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
            strSql.Append(" FROM [RecommendCode] ");
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
            strSql.Append(" FROM [RecommendCode] ");
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



