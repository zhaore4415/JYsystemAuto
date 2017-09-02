using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Shi
    /// </summary>
    public static partial class Shi
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Shi model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Shi] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Shi model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.fk_id != Int32.MinValue)
            {
                colList.Append("[fk_id],");
                colParamList.Append("@fk_id,");
                parameter = new SqlParameter("@fk_id", SqlDbType.Int, 4);
                parameter.Value = model.fk_id;
                sqlParamList.Add(parameter);
            }

            if (model.second_kind_id != null)
            {
                colList.Append("[second_kind_id],");
                colParamList.Append("@second_kind_id,");
                parameter = new SqlParameter("@second_kind_id", SqlDbType.Char, 2);
                parameter.Value = model.second_kind_id;
                sqlParamList.Add(parameter);
            }

            if (model.second_kind_name != null)
            {
                colList.Append("[second_kind_name],");
                colParamList.Append("@second_kind_name,");
                parameter = new SqlParameter("@second_kind_name", SqlDbType.VarChar, 60);
                parameter.Value = model.second_kind_name;
                sqlParamList.Add(parameter);
            }

            if (model.second_kind_salary_id != null)
            {
                colList.Append("[second_kind_salary_id],");
                colParamList.Append("@second_kind_salary_id,");
                parameter = new SqlParameter("@second_kind_salary_id", SqlDbType.Text);
                parameter.Value = model.second_kind_salary_id;
                sqlParamList.Add(parameter);
            }

            if (model.second_kind_sale_id != null)
            {
                colList.Append("[second_kind_sale_id],");
                colParamList.Append("@second_kind_sale_id,");
                parameter = new SqlParameter("@second_kind_sale_id", SqlDbType.Text);
                parameter.Value = model.second_kind_sale_id;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [Shi] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
        public static bool Delete(int sk_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shi ");
            strSql.Append(" where sk_id=@sk_id");
            SqlParameter[] parameters = {
					new SqlParameter("@sk_id", SqlDbType.Int,4)
			};
            parameters[0].Value = sk_id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion


        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string sk_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Shi] ");
            strSql.Append(" where fk_id in (" + sk_idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Shi model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Shi] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where sk_id=@sk_id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Shi model, ref SqlParameter[] parameters, bool isUpdate)
        {
            StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (model.sk_id != Int32.MinValue)
            {
                if (!isUpdate) colList.Append("[sk_id] = @sk_id,");
                SqlParameter parameter = new SqlParameter("@sk_id", SqlDbType.Int, 4);
                parameter.Value = model.sk_id;
                paramList.Add(parameter);
            }

            if (model.fk_id != Int32.MinValue)
            {
                colList.Append("[fk_id] = @fk_id,");
                SqlParameter parameter = new SqlParameter("@fk_id", SqlDbType.Int, 4);
                parameter.Value = model.fk_id;
                paramList.Add(parameter);
            }

            if (model.second_kind_id != null)
            {
                colList.Append("[second_kind_id] = @second_kind_id,");
                SqlParameter parameter = new SqlParameter("@second_kind_id", SqlDbType.Char, 2);
                parameter.Value = model.second_kind_id;
                paramList.Add(parameter);
            }

            if (model.second_kind_name != null)
            {
                colList.Append("[second_kind_name] = @second_kind_name,");
                SqlParameter parameter = new SqlParameter("@second_kind_name", SqlDbType.VarChar, 60);
                parameter.Value = model.second_kind_name;
                paramList.Add(parameter);
            }

            if (model.second_kind_salary_id != null)
            {
                colList.Append("[second_kind_salary_id] = @second_kind_salary_id,");
                SqlParameter parameter = new SqlParameter("@second_kind_salary_id", SqlDbType.Text);
                parameter.Value = model.second_kind_salary_id;
                paramList.Add(parameter);
            }

            if (model.second_kind_sale_id != null)
            {
                colList.Append("[second_kind_sale_id] = @second_kind_sale_id,");
                SqlParameter parameter = new SqlParameter("@second_kind_sale_id", SqlDbType.Text);
                parameter.Value = model.second_kind_sale_id;
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
        public static NH.Model.Shi GetModel(int sk_id)
        {
            NH.Model.Shi model = new NH.Model.Shi();
            model.sk_id = sk_id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Shi GetModel(NH.Model.Shi model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [sk_id], [fk_id], [second_kind_id], [second_kind_name], [second_kind_salary_id], [second_kind_sale_id] ");
            strSql.Append(" from [Shi] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Shi();
            DataRow row = dt.Rows[0];

            if (row["sk_id"].ToString() != "")
            {
                model.sk_id = int.Parse(row["sk_id"].ToString());
            }

            if (row["fk_id"].ToString() != "")
            {
                model.fk_id = int.Parse(row["fk_id"].ToString());
            }

            model.second_kind_id = row["second_kind_id"].ToString();

            model.second_kind_name = row["second_kind_name"].ToString();

            model.second_kind_salary_id = row["second_kind_salary_id"].ToString();

            model.second_kind_sale_id = row["second_kind_sale_id"].ToString();

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
            strSql.Append(" FROM [Shi] ");
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
            strSql.Append(" FROM [Shi] ");
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



