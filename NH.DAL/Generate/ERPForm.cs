using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// ERPForm
    /// </summary>
    public static partial class ERPForm
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.ERPForm model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ERPForm] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.ERPForm model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.FormName != null)
            {
                colList.Append("[FormName],");
                colParamList.Append("@FormName,");
                parameter = new SqlParameter("@FormName", SqlDbType.VarChar, 50);
                parameter.Value = model.FormName;
                sqlParamList.Add(parameter);
            }

            if (model.FormType != null)
            {
                colList.Append("[FormType],");
                colParamList.Append("@FormType,");
                parameter = new SqlParameter("@FormType", SqlDbType.VarChar, 50);
                parameter.Value = model.FormType;
                sqlParamList.Add(parameter);
            }

            if (model.ShiYongUserList != null)
            {
                colList.Append("[ShiYongUserList],");
                colParamList.Append("@ShiYongUserList,");
                parameter = new SqlParameter("@ShiYongUserList", SqlDbType.VarChar, 8000);
                parameter.Value = model.ShiYongUserList;
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

            if (model.UserName != null)
            {
                colList.Append("[UserName],");
                colParamList.Append("@UserName,");
                parameter = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                parameter.Value = model.UserName;
                sqlParamList.Add(parameter);
            }

            if (model.TiaoJianList != null)
            {
                colList.Append("[TiaoJianList],");
                colParamList.Append("@TiaoJianList,");
                parameter = new SqlParameter("@TiaoJianList", SqlDbType.VarChar, 8000);
                parameter.Value = model.TiaoJianList;
                sqlParamList.Add(parameter);
            }

            if (model.ContentStr != null)
            {
                colList.Append("[ContentStr],");
                colParamList.Append("@ContentStr,");
                parameter = new SqlParameter("@ContentStr", SqlDbType.Text);
                parameter.Value = model.ContentStr;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [ERPForm] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from ERPForm ");
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
            strSql.Append("delete from [ERPForm] ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.ERPForm model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ERPForm] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where ID=@ID ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.ERPForm model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.FormName != null)
            {
                colList.Append("[FormName] = @FormName,");
                SqlParameter parameter = new SqlParameter("@FormName", SqlDbType.VarChar, 50);
                parameter.Value = model.FormName;
                paramList.Add(parameter);
            }

            if (model.FormType != null)
            {
                colList.Append("[FormType] = @FormType,");
                SqlParameter parameter = new SqlParameter("@FormType", SqlDbType.VarChar, 50);
                parameter.Value = model.FormType;
                paramList.Add(parameter);
            }

            if (model.ShiYongUserList != null)
            {
                colList.Append("[ShiYongUserList] = @ShiYongUserList,");
                SqlParameter parameter = new SqlParameter("@ShiYongUserList", SqlDbType.VarChar, 8000);
                parameter.Value = model.ShiYongUserList;
                paramList.Add(parameter);
            }

            if (model.TimeStr.HasValue)
            {
                colList.Append("[TimeStr] = @TimeStr,");
                SqlParameter parameter = new SqlParameter("@TimeStr", SqlDbType.DateTime);
                parameter.Value = model.TimeStr.Value;
                paramList.Add(parameter);
            }

            if (model.UserName != null)
            {
                colList.Append("[UserName] = @UserName,");
                SqlParameter parameter = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                parameter.Value = model.UserName;
                paramList.Add(parameter);
            }

            if (model.TiaoJianList != null)
            {
                colList.Append("[TiaoJianList] = @TiaoJianList,");
                SqlParameter parameter = new SqlParameter("@TiaoJianList", SqlDbType.VarChar, 8000);
                parameter.Value = model.TiaoJianList;
                paramList.Add(parameter);
            }

            if (model.ContentStr != null)
            {
                colList.Append("[ContentStr] = @ContentStr,");
                SqlParameter parameter = new SqlParameter("@ContentStr", SqlDbType.Text);
                parameter.Value = model.ContentStr;
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
        public static NH.Model.ERPForm GetModel(int ID)
        {
            NH.Model.ERPForm model = new NH.Model.ERPForm();
            model.ID = ID;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ERPForm GetModel(NH.Model.ERPForm model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID], [FormName], [FormType], [ShiYongUserList], [TimeStr], [UserName], [TiaoJianList], [ContentStr] ");
            strSql.Append(" from [ERPForm] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.ERPForm();
            DataRow row = dt.Rows[0];

            if (row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }

            model.FormName = row["FormName"].ToString();

            model.FormType = row["FormType"].ToString();

            model.ShiYongUserList = row["ShiYongUserList"].ToString();

            if (row["TimeStr"].ToString() != "")
            {
                model.TimeStr = DateTime.Parse(row["TimeStr"].ToString());
            }

            model.UserName = row["UserName"].ToString();

            model.TiaoJianList = row["TiaoJianList"].ToString();

            model.ContentStr = row["ContentStr"].ToString();

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
            strSql.Append(" FROM [ERPForm] ");
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
            strSql.Append(" FROM [ERPForm] ");
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



