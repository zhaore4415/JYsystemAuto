using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// province
    /// </summary>
    public static partial class province
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.province model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [province] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.province model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.code != null)
            {
                colList.Append("[code],");
                colParamList.Append("@code,");
                parameter = new SqlParameter("@code", SqlDbType.NVarChar, 6);
                parameter.Value = model.code;
                sqlParamList.Add(parameter);
            }

            if (model.name != null)
            {
                colList.Append("[name],");
                colParamList.Append("@name,");
                parameter = new SqlParameter("@name", SqlDbType.NVarChar, 40);
                parameter.Value = model.name;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [province] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
        public static bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from province ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion


        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [province] ");
            strSql.Append(" where ID in (" + idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.province model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [province] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where id=@id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.province model, ref SqlParameter[] parameters, bool isUpdate)
        {
            StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (model.id != Int32.MinValue)
            {
                if (!isUpdate) colList.Append("[id] = @id,");
                SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int, 4);
                parameter.Value = model.id;
                paramList.Add(parameter);
            }

            if (model.code != null)
            {
                colList.Append("[code] = @code,");
                SqlParameter parameter = new SqlParameter("@code", SqlDbType.NVarChar, 6);
                parameter.Value = model.code;
                paramList.Add(parameter);
            }

            if (model.name != null)
            {
                colList.Append("[name] = @name,");
                SqlParameter parameter = new SqlParameter("@name", SqlDbType.NVarChar, 40);
                parameter.Value = model.name;
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
        public static NH.Model.province GetModel(int id)
        {
            NH.Model.province model = new NH.Model.province();
            model.id = id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.province GetModel(NH.Model.province model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [id], [code], [name] ");
            strSql.Append(" from [province] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.province();
            DataRow row = dt.Rows[0];

            if (row["id"].ToString() != "")
            {
                model.id = int.Parse(row["id"].ToString());
            }

            model.code = row["code"].ToString();

            model.name = row["name"].ToString();

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
            strSql.Append(" FROM [province] ");
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
            strSql.Append(" FROM [province] ");
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



