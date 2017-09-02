using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Xian
    /// </summary>
    public static partial class Xian
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Xian model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Xian] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Xian model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.sk_id != Int32.MinValue)
            {
                colList.Append("[sk_id],");
                colParamList.Append("@sk_id,");
                parameter = new SqlParameter("@sk_id", SqlDbType.Int, 4);
                parameter.Value = model.sk_id;
                sqlParamList.Add(parameter);
            }

            if (model.third_kind_id != null)
            {
                colList.Append("[third_kind_id],");
                colParamList.Append("@third_kind_id,");
                parameter = new SqlParameter("@third_kind_id", SqlDbType.Char, 2);
                parameter.Value = model.third_kind_id;
                sqlParamList.Add(parameter);
            }

            if (model.third_kind_name != null)
            {
                colList.Append("[third_kind_name],");
                colParamList.Append("@third_kind_name,");
                parameter = new SqlParameter("@third_kind_name", SqlDbType.VarChar, 60);
                parameter.Value = model.third_kind_name;
                sqlParamList.Add(parameter);
            }

            if (model.third_kind_salary_id != null)
            {
                colList.Append("[third_kind_salary_id],");
                colParamList.Append("@third_kind_salary_id,");
                parameter = new SqlParameter("@third_kind_salary_id", SqlDbType.Text);
                parameter.Value = model.third_kind_salary_id;
                sqlParamList.Add(parameter);
            }

            if (model.third_kind_is_retail != null)
            {
                colList.Append("[third_kind_is_retail],");
                colParamList.Append("@third_kind_is_retail,");
                parameter = new SqlParameter("@third_kind_is_retail", SqlDbType.Char, 2);
                parameter.Value = model.third_kind_is_retail;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [Xian] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
        public static bool Delete(int tk_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xian ");
            strSql.Append(" where tk_id=@tk_id");
            SqlParameter[] parameters = {
					new SqlParameter("@tk_id", SqlDbType.Int,4)
			};
            parameters[0].Value = tk_id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion


        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string tk_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Xian] ");
            strSql.Append(" where sk_id in (" + tk_idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Xian model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Xian] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where tk_id=@tk_id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Xian model, ref SqlParameter[] parameters, bool isUpdate)
        {
            StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (model.tk_id != Int32.MinValue)
            {
                if (!isUpdate) colList.Append("[tk_id] = @tk_id,");
                SqlParameter parameter = new SqlParameter("@tk_id", SqlDbType.Int, 4);
                parameter.Value = model.tk_id;
                paramList.Add(parameter);
            }

            if (model.sk_id != Int32.MinValue)
            {
                colList.Append("[sk_id] = @sk_id,");
                SqlParameter parameter = new SqlParameter("@sk_id", SqlDbType.Int, 4);
                parameter.Value = model.sk_id;
                paramList.Add(parameter);
            }

            if (model.third_kind_id != null)
            {
                colList.Append("[third_kind_id] = @third_kind_id,");
                SqlParameter parameter = new SqlParameter("@third_kind_id", SqlDbType.Char, 2);
                parameter.Value = model.third_kind_id;
                paramList.Add(parameter);
            }

            if (model.third_kind_name != null)
            {
                colList.Append("[third_kind_name] = @third_kind_name,");
                SqlParameter parameter = new SqlParameter("@third_kind_name", SqlDbType.VarChar, 60);
                parameter.Value = model.third_kind_name;
                paramList.Add(parameter);
            }

            if (model.third_kind_salary_id != null)
            {
                colList.Append("[third_kind_salary_id] = @third_kind_salary_id,");
                SqlParameter parameter = new SqlParameter("@third_kind_salary_id", SqlDbType.Text);
                parameter.Value = model.third_kind_salary_id;
                paramList.Add(parameter);
            }

            if (model.third_kind_is_retail != null)
            {
                colList.Append("[third_kind_is_retail] = @third_kind_is_retail,");
                SqlParameter parameter = new SqlParameter("@third_kind_is_retail", SqlDbType.Char, 2);
                parameter.Value = model.third_kind_is_retail;
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
        public static NH.Model.Xian GetModel(int tk_id)
        {
            NH.Model.Xian model = new NH.Model.Xian();
            model.tk_id = tk_id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Xian GetModel(NH.Model.Xian model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [tk_id], [sk_id], [third_kind_id], [third_kind_name], [third_kind_salary_id], [third_kind_is_retail] ");
            strSql.Append(" from [Xian] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Xian();
            DataRow row = dt.Rows[0];

            if (row["tk_id"].ToString() != "")
            {
                model.tk_id = int.Parse(row["tk_id"].ToString());
            }

            if (row["sk_id"].ToString() != "")
            {
                model.sk_id = int.Parse(row["sk_id"].ToString());
            }

            model.third_kind_id = row["third_kind_id"].ToString();

            model.third_kind_name = row["third_kind_name"].ToString();

            model.third_kind_salary_id = row["third_kind_salary_id"].ToString();

            model.third_kind_is_retail = row["third_kind_is_retail"].ToString();

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
            strSql.Append(" FROM [Xian] ");
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
            strSql.Append(" FROM [Xian] ");
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



