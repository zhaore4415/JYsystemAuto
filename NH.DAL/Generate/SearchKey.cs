using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// SearchKey
    /// </summary>
    public static partial class SearchKey
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.SearchKey model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [SearchKey](nolock)");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.SearchKey model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.KeyName != null)
            {
                colList.Append("[KeyName],");
                colParamList.Append("@KeyName,");
                parameter = new SqlParameter("@KeyName", SqlDbType.NVarChar, 30);
                parameter.Value = model.KeyName;
                sqlParamList.Add(parameter);
            }

            if (model.Url != null)
            {
                colList.Append("[Url],");
                colParamList.Append("@Url,");
                parameter = new SqlParameter("@Url", SqlDbType.NVarChar, 200);
                parameter.Value = model.Url;
                sqlParamList.Add(parameter);
            }

            if (model.Sort != Int32.MinValue)
            {
                colList.Append("[Sort],");
                colParamList.Append("@Sort,");
                parameter = new SqlParameter("@Sort", SqlDbType.Int, 4);
                parameter.Value = model.Sort;
                sqlParamList.Add(parameter);
            }

            if (model.Type != Int32.MinValue)
            {
                colList.Append("[Type],");
                colParamList.Append("@Type,");
                parameter = new SqlParameter("@Type", SqlDbType.Int, 4);
                parameter.Value = model.Type;
                sqlParamList.Add(parameter);
            }

            if (model.Style != Int32.MinValue)
            {
                colList.Append("[Style],");
                colParamList.Append("@Style,");
                parameter = new SqlParameter("@Style", SqlDbType.Int, 4);
                parameter.Value = model.Style;
                sqlParamList.Add(parameter);
            }

            if (model.IsShow.HasValue)
            {
                colList.Append("[IsShow],");
                colParamList.Append("@IsShow,");
                parameter = new SqlParameter("@IsShow", SqlDbType.Bit, 1);
                parameter.Value = model.IsShow.Value;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [SearchKey] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from [SearchKey] ");
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
            strSql.Append("delete from [SearchKey] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.SearchKey model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [SearchKey] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.SearchKey model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.KeyName != null)
            {
                colList.Append("[KeyName] = @KeyName,");
                SqlParameter parameter = new SqlParameter("@KeyName", SqlDbType.NVarChar, 30);
                parameter.Value = model.KeyName;
                paramList.Add(parameter);
            }

            if (model.Url != null)
            {
                colList.Append("[Url] = @Url,");
                SqlParameter parameter = new SqlParameter("@Url", SqlDbType.NVarChar, 200);
                parameter.Value = model.Url;
                paramList.Add(parameter);
            }

            if (model.Sort != Int32.MinValue)
            {
                colList.Append("[Sort] = @Sort,");
                SqlParameter parameter = new SqlParameter("@Sort", SqlDbType.Int, 4);
                parameter.Value = model.Sort;
                paramList.Add(parameter);
            }

            if (model.Type != Int32.MinValue)
            {
                colList.Append("[Type] = @Type,");
                SqlParameter parameter = new SqlParameter("@Type", SqlDbType.Int, 4);
                parameter.Value = model.Type;
                paramList.Add(parameter);
            }

            if (model.Style != Int32.MinValue)
            {
                colList.Append("[Style] = @Style,");
                SqlParameter parameter = new SqlParameter("@Style", SqlDbType.Int, 4);
                parameter.Value = model.Style;
                paramList.Add(parameter);
            }

            if (model.IsShow.HasValue)
            {
                colList.Append("[IsShow] = @IsShow,");
                SqlParameter parameter = new SqlParameter("@IsShow", SqlDbType.Bit, 1);
                parameter.Value = model.IsShow.Value; paramList.Add(parameter);
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
        public static NH.Model.SearchKey GetModel(int Id)
        {
            NH.Model.SearchKey model = new NH.Model.SearchKey();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.SearchKey GetModel(NH.Model.SearchKey model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, KeyName, Url, Sort, Type, Style, IsShow ");
            strSql.Append(" from [SearchKey] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.SearchKey();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            model.KeyName = row["KeyName"].ToString();

            model.Url = row["Url"].ToString();

            if (row["Sort"].ToString() != "")
            {
                model.Sort = int.Parse(row["Sort"].ToString());
            }

            if (row["Type"].ToString() != "")
            {
                model.Type = int.Parse(row["Type"].ToString());
            }

            if (row["Style"].ToString() != "")
            {
                model.Style = int.Parse(row["Style"].ToString());
            }


            if (row["IsShow"].ToString() != "")
            {
                if ((row["IsShow"].ToString() == "1") || (row["IsShow"].ToString().ToLower() == "true"))
                {
                    model.IsShow = true;
                }
                else
                {
                    model.IsShow = false;
                }
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
            strSql.Append(" FROM [SearchKey] ");
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
            strSql.Append(" FROM [SearchKey] ");
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



