using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// ERPRiZhi
    /// </summary>
    public static partial class ERPRiZhi
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.ERPRiZhi model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ERPRiZhi] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.ERPRiZhi model)
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

            if (model.TimeStr.HasValue)
            {
                colList.Append("[TimeStr],");
                colParamList.Append("@TimeStr,");
                parameter = new SqlParameter("@TimeStr", SqlDbType.DateTime);
                if (model.TimeStr.Value != DateTime.MinValue)
                    parameter.Value = model.TimeStr.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.DoSomething != null)
            {
                colList.Append("[DoSomething],");
                colParamList.Append("@DoSomething,");
                parameter = new SqlParameter("@DoSomething", SqlDbType.VarChar, 1000);
                parameter.Value = model.DoSomething;
                sqlParamList.Add(parameter);
            }

            if (model.IpStr != null)
            {
                colList.Append("[IpStr],");
                colParamList.Append("@IpStr,");
                parameter = new SqlParameter("@IpStr", SqlDbType.VarChar, 50);
                parameter.Value = model.IpStr;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [ERPRiZhi] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from ERPRiZhi ");
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
            strSql.Append("delete from [ERPRiZhi] ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.ERPRiZhi model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ERPRiZhi] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where ID=@ID ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.ERPRiZhi model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.TimeStr.HasValue)
            {
                colList.Append("[TimeStr] = @TimeStr,");
                SqlParameter parameter = new SqlParameter("@TimeStr", SqlDbType.DateTime);
                parameter.Value = model.TimeStr.Value;
                paramList.Add(parameter);
            }

            if (model.DoSomething != null)
            {
                colList.Append("[DoSomething] = @DoSomething,");
                SqlParameter parameter = new SqlParameter("@DoSomething", SqlDbType.VarChar, 1000);
                parameter.Value = model.DoSomething;
                paramList.Add(parameter);
            }

            if (model.IpStr != null)
            {
                colList.Append("[IpStr] = @IpStr,");
                SqlParameter parameter = new SqlParameter("@IpStr", SqlDbType.VarChar, 50);
                parameter.Value = model.IpStr;
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
        public static NH.Model.ERPRiZhi GetModel(int ID)
        {
            NH.Model.ERPRiZhi model = new NH.Model.ERPRiZhi();
            model.ID = ID;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ERPRiZhi GetModel(NH.Model.ERPRiZhi model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID], [UserName], [TimeStr], [DoSomething], [IpStr] ");
            strSql.Append(" from [ERPRiZhi] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.ERPRiZhi();
            DataRow row = dt.Rows[0];

            if (row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }

            model.UserName = row["UserName"].ToString();

            if (row["TimeStr"].ToString() != "")
            {
                model.TimeStr = DateTime.Parse(row["TimeStr"].ToString());
            }

            model.DoSomething = row["DoSomething"].ToString();

            model.IpStr = row["IpStr"].ToString();

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
            strSql.Append(" FROM [ERPRiZhi] ");
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
            strSql.Append(" FROM [ERPRiZhi] ");
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



