using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// ERPDengJi
    /// </summary>
    public static partial class ERPDengJi
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.ERPDengJi model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ERPDengJi] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.ERPDengJi model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.UserName != null)
            {
                colList.Append("[UserName],");
                colParamList.Append("@UserName,");
                parameter = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                parameter.Value = model.UserName;
                sqlParamList.Add(parameter);
            }

            if (model.ShenPiRen != null)
            {
                colList.Append("[ShenPiRen],");
                colParamList.Append("@ShenPiRen,");
                parameter = new SqlParameter("@ShenPiRen", SqlDbType.VarChar, 50);
                parameter.Value = model.ShenPiRen;
                sqlParamList.Add(parameter);
            }

            if (model.ShenQingTime.HasValue)
            {
                colList.Append("[ShenQingTime],");
                colParamList.Append("@ShenQingTime,");
                parameter = new SqlParameter("@ShenQingTime", SqlDbType.DateTime);
                if (model.ShenQingTime.Value != DateTime.MinValue)
                    parameter.Value = model.ShenQingTime.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.BackInfo != null)
            {
                colList.Append("[BackInfo],");
                colParamList.Append("@BackInfo,");
                parameter = new SqlParameter("@BackInfo", SqlDbType.VarChar, 8000);
                parameter.Value = model.BackInfo;
                sqlParamList.Add(parameter);
            }

            if (model.StartTime.HasValue)
            {
                colList.Append("[StartTime],");
                colParamList.Append("@StartTime,");
                parameter = new SqlParameter("@StartTime", SqlDbType.DateTime);
                if (model.StartTime.Value != DateTime.MinValue)
                    parameter.Value = model.StartTime.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.EndTime.HasValue)
            {
                colList.Append("[EndTime],");
                colParamList.Append("@EndTime,");
                parameter = new SqlParameter("@EndTime", SqlDbType.DateTime);
                if (model.EndTime.Value != DateTime.MinValue)
                    parameter.Value = model.EndTime.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.StateNow != null)
            {
                colList.Append("[StateNow],");
                colParamList.Append("@StateNow,");
                parameter = new SqlParameter("@StateNow", SqlDbType.VarChar, 50);
                parameter.Value = model.StateNow;
                sqlParamList.Add(parameter);
            }

            if (model.TypeName != null)
            {
                colList.Append("[TypeName],");
                colParamList.Append("@TypeName,");
                parameter = new SqlParameter("@TypeName", SqlDbType.VarChar, 50);
                parameter.Value = model.TypeName;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [ERPDengJi] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
        public static bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ERPDengJi ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion


        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [ERPDengJi] ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.ERPDengJi model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ERPDengJi] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where ID=@ID ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.ERPDengJi model, ref SqlParameter[] parameters, bool isUpdate)
        {
            StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (model.ID != Int32.MinValue)
            {
                if (!isUpdate) colList.Append("[ID] = @ID,");
                SqlParameter parameter = new SqlParameter("@ID", SqlDbType.Int, 4);
                parameter.Value = model.ID;
                paramList.Add(parameter);
            }

            if (model.UserName != null)
            {
                colList.Append("[UserName] = @UserName,");
                SqlParameter parameter = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                parameter.Value = model.UserName;
                paramList.Add(parameter);
            }

            if (model.ShenPiRen != null)
            {
                colList.Append("[ShenPiRen] = @ShenPiRen,");
                SqlParameter parameter = new SqlParameter("@ShenPiRen", SqlDbType.VarChar, 50);
                parameter.Value = model.ShenPiRen;
                paramList.Add(parameter);
            }

            if (model.ShenQingTime.HasValue)
            {
                colList.Append("[ShenQingTime] = @ShenQingTime,");
                SqlParameter parameter = new SqlParameter("@ShenQingTime", SqlDbType.DateTime);
                parameter.Value = model.ShenQingTime.Value;
                paramList.Add(parameter);
            }

            if (model.BackInfo != null)
            {
                colList.Append("[BackInfo] = @BackInfo,");
                SqlParameter parameter = new SqlParameter("@BackInfo", SqlDbType.VarChar, 8000);
                parameter.Value = model.BackInfo;
                paramList.Add(parameter);
            }

            if (model.StartTime.HasValue)
            {
                colList.Append("[StartTime] = @StartTime,");
                SqlParameter parameter = new SqlParameter("@StartTime", SqlDbType.DateTime);
                parameter.Value = model.StartTime.Value;
                paramList.Add(parameter);
            }

            if (model.EndTime.HasValue)
            {
                colList.Append("[EndTime] = @EndTime,");
                SqlParameter parameter = new SqlParameter("@EndTime", SqlDbType.DateTime);
                parameter.Value = model.EndTime.Value;
                paramList.Add(parameter);
            }

            if (model.StateNow != null)
            {
                colList.Append("[StateNow] = @StateNow,");
                SqlParameter parameter = new SqlParameter("@StateNow", SqlDbType.VarChar, 50);
                parameter.Value = model.StateNow;
                paramList.Add(parameter);
            }

            if (model.TypeName != null)
            {
                colList.Append("[TypeName] = @TypeName,");
                SqlParameter parameter = new SqlParameter("@TypeName", SqlDbType.VarChar, 50);
                parameter.Value = model.TypeName;
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
        public static NH.Model.ERPDengJi GetModel(int ID)
        {
            NH.Model.ERPDengJi model = new NH.Model.ERPDengJi();
            model.ID = ID;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ERPDengJi GetModel(NH.Model.ERPDengJi model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID], [UserName], [ShenPiRen], [ShenQingTime], [BackInfo], [StartTime], [EndTime], [StateNow], [TypeName] ");
            strSql.Append(" from [ERPDengJi] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.ERPDengJi();
            DataRow row = dt.Rows[0];

            if (row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }

            model.UserName = row["UserName"].ToString();

            model.ShenPiRen = row["ShenPiRen"].ToString();

            if (row["ShenQingTime"].ToString() != "")
            {
                model.ShenQingTime = DateTime.Parse(row["ShenQingTime"].ToString());
            }

            model.BackInfo = row["BackInfo"].ToString();

            if (row["StartTime"].ToString() != "")
            {
                model.StartTime = DateTime.Parse(row["StartTime"].ToString());
            }

            if (row["EndTime"].ToString() != "")
            {
                model.EndTime = DateTime.Parse(row["EndTime"].ToString());
            }

            model.StateNow = row["StateNow"].ToString();

            model.TypeName = row["TypeName"].ToString();

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
            strSql.Append(" FROM [ERPDengJi] ");
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
            strSql.Append(" FROM [ERPDengJi] ");
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



