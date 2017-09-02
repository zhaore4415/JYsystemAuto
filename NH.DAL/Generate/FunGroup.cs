using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// FunGroup
    /// </summary>
    public static partial class FunGroup
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.FunGroup model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [FunGroup](nolock)");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.FunGroup model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.GroupName != null)
            {
                colList.Append("[GroupName],");
                colParamList.Append("@GroupName,");
                parameter = new SqlParameter("@GroupName", SqlDbType.NVarChar, 20);
                parameter.Value = model.GroupName;
                sqlParamList.Add(parameter);
            }

            if (model.ParentID != Int32.MinValue)
            {
                colList.Append("[ParentID],");
                colParamList.Append("@ParentID,");
                parameter = new SqlParameter("@ParentID", SqlDbType.Int, 4);
                parameter.Value = model.ParentID;
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

            if (model.Depth != Int32.MinValue)
            {
                colList.Append("[Depth],");
                colParamList.Append("@Depth,");
                parameter = new SqlParameter("@Depth", SqlDbType.Int, 4);
                parameter.Value = model.Depth;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [FunGroup] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from FunGroup ");
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
            strSql.Append("delete from [FunGroup] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.FunGroup model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [FunGroup] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.FunGroup model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.GroupName != null)
            {
                colList.Append("[GroupName] = @GroupName,");
                SqlParameter parameter = new SqlParameter("@GroupName", SqlDbType.NVarChar, 20);
                parameter.Value = model.GroupName;
                paramList.Add(parameter);
            }

            if (model.ParentID != Int32.MinValue)
            {
                colList.Append("[ParentID] = @ParentID,");
                SqlParameter parameter = new SqlParameter("@ParentID", SqlDbType.Int, 4);
                parameter.Value = model.ParentID;
                paramList.Add(parameter);
            }

            if (model.IsShow.HasValue)
            {
                colList.Append("[IsShow] = @IsShow,");
                SqlParameter parameter = new SqlParameter("@IsShow", SqlDbType.Bit, 1);
                parameter.Value = model.IsShow.Value;
                paramList.Add(parameter);
            }

            if (model.Depth != Int32.MinValue)
            {
                colList.Append("[Depth] = @Depth,");
                SqlParameter parameter = new SqlParameter("@Depth", SqlDbType.Int, 4);
                parameter.Value = model.Depth;
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
        public static NH.Model.FunGroup GetModel(int Id)
        {
            NH.Model.FunGroup model = new NH.Model.FunGroup();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.FunGroup GetModel(NH.Model.FunGroup model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, GroupName, ParentID, IsShow, Depth ");
            strSql.Append(" from [FunGroup] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.FunGroup();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            model.GroupName = row["GroupName"].ToString();

            if (row["ParentID"].ToString() != "")
            {
                model.ParentID = int.Parse(row["ParentID"].ToString());
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

            if (row["Depth"].ToString() != "")
            {
                model.Depth = int.Parse(row["Depth"].ToString());
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
            strSql.Append(" FROM [FunGroup] ");
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
            strSql.Append(" FROM [FunGroup] ");
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



