using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Shen
    /// </summary>
    public static partial class Shen
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Shen model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Shen] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Shen model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.first_kind_id != null)
            {
                colList.Append("[first_kind_id],");
                colParamList.Append("@first_kind_id,");
                parameter = new SqlParameter("@first_kind_id", SqlDbType.Char, 2);
                parameter.Value = model.first_kind_id;
                sqlParamList.Add(parameter);
            }

            if (model.first_kind_name != null)
            {
                colList.Append("[first_kind_name],");
                colParamList.Append("@first_kind_name,");
                parameter = new SqlParameter("@first_kind_name", SqlDbType.VarChar, 60);
                parameter.Value = model.first_kind_name;
                sqlParamList.Add(parameter);
            }

            if (model.first_kind_salary_id != null)
            {
                colList.Append("[first_kind_salary_id],");
                colParamList.Append("@first_kind_salary_id,");
                parameter = new SqlParameter("@first_kind_salary_id", SqlDbType.Text);
                parameter.Value = model.first_kind_salary_id;
                sqlParamList.Add(parameter);
            }

            if (model.first_kind_sale_id != null)
            {
                colList.Append("[first_kind_sale_id],");
                colParamList.Append("@first_kind_sale_id,");
                parameter = new SqlParameter("@first_kind_sale_id", SqlDbType.Text);
                parameter.Value = model.first_kind_sale_id;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [Shen] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
        public static bool Delete(int fk_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shen ");
            strSql.Append(" where fk_id=@fk_id");
            SqlParameter[] parameters = {
					new SqlParameter("@fk_id", SqlDbType.Int,4)
			};
            parameters[0].Value = fk_id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion


        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string fk_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Shen] ");
            strSql.Append(" where ID in (" + fk_idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Shen model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Shen] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where fk_id=@fk_id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Shen model, ref SqlParameter[] parameters, bool isUpdate)
        {
            StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (model.fk_id != Int32.MinValue)
            {
                if (!isUpdate) colList.Append("[fk_id] = @fk_id,");
                SqlParameter parameter = new SqlParameter("@fk_id", SqlDbType.Int, 4);
                parameter.Value = model.fk_id;
                paramList.Add(parameter);
            }

            if (model.first_kind_id != null)
            {
                colList.Append("[first_kind_id] = @first_kind_id,");
                SqlParameter parameter = new SqlParameter("@first_kind_id", SqlDbType.Char, 2);
                parameter.Value = model.first_kind_id;
                paramList.Add(parameter);
            }

            if (model.first_kind_name != null)
            {
                colList.Append("[first_kind_name] = @first_kind_name,");
                SqlParameter parameter = new SqlParameter("@first_kind_name", SqlDbType.VarChar, 60);
                parameter.Value = model.first_kind_name;
                paramList.Add(parameter);
            }

            if (model.first_kind_salary_id != null)
            {
                colList.Append("[first_kind_salary_id] = @first_kind_salary_id,");
                SqlParameter parameter = new SqlParameter("@first_kind_salary_id", SqlDbType.Text);
                parameter.Value = model.first_kind_salary_id;
                paramList.Add(parameter);
            }

            if (model.first_kind_sale_id != null)
            {
                colList.Append("[first_kind_sale_id] = @first_kind_sale_id,");
                SqlParameter parameter = new SqlParameter("@first_kind_sale_id", SqlDbType.Text);
                parameter.Value = model.first_kind_sale_id;
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
        public static NH.Model.Shen GetModel(int fk_id)
        {
            NH.Model.Shen model = new NH.Model.Shen();
            model.fk_id = fk_id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Shen GetModel(NH.Model.Shen model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [fk_id], [first_kind_id], [first_kind_name], [first_kind_salary_id], [first_kind_sale_id] ");
            strSql.Append(" from [Shen] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Shen();
            DataRow row = dt.Rows[0];

            if (row["fk_id"].ToString() != "")
            {
                model.fk_id = int.Parse(row["fk_id"].ToString());
            }

            model.first_kind_id = row["first_kind_id"].ToString();

            model.first_kind_name = row["first_kind_name"].ToString();

            model.first_kind_salary_id = row["first_kind_salary_id"].ToString();

            model.first_kind_sale_id = row["first_kind_sale_id"].ToString();

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
            strSql.Append(" FROM [Shen] ");
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
            strSql.Append(" FROM [Shen] ");
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



