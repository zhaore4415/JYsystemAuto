using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// EmailValidateCode
    /// </summary>
    public static partial class EmailValidateCode
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.EmailValidateCode model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [EmailValidateCode](nolock)");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.EmailValidateCode model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.UserId != Int32.MinValue)
            {
                colList.Append("[UserId],");
                colParamList.Append("@UserId,");
                parameter = new SqlParameter("@UserId", SqlDbType.Int, 4);
                parameter.Value = model.UserId;
                sqlParamList.Add(parameter);
            }

            if (model.Loginname != null)
            {
                colList.Append("[Loginname],");
                colParamList.Append("@Loginname,");
                parameter = new SqlParameter("@Loginname", SqlDbType.NVarChar, 50);
                parameter.Value = model.Loginname;
                sqlParamList.Add(parameter);
            }

            if (model.Email != null)
            {
                colList.Append("[Email],");
                colParamList.Append("@Email,");
                parameter = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                parameter.Value = model.Email;
                sqlParamList.Add(parameter);
            }

            if (model.Code != null)
            {
                colList.Append("[Code],");
                colParamList.Append("@Code,");
                parameter = new SqlParameter("@Code", SqlDbType.NVarChar, 10);
                parameter.Value = model.Code;
                sqlParamList.Add(parameter);
            }

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime],");
                colParamList.Append("@AddTime,");
                parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                sqlParamList.Add(parameter);
            }

            if (model.Status.HasValue)
            {
                colList.Append("[Status],");
                colParamList.Append("@Status,");
                parameter = new SqlParameter("@Status", SqlDbType.Bit, 1);
                parameter.Value = model.Status.Value;
                sqlParamList.Add(parameter);
            }

            if (model.CodeType != Int32.MinValue)
            {
                colList.Append("[CodeType],");
                colParamList.Append("@CodeType,");
                parameter = new SqlParameter("@CodeType", SqlDbType.Int, 4);
                parameter.Value = model.CodeType;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [EmailValidateCode] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from [EmailValidateCode] ");
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
            strSql.Append("delete from [EmailValidateCode] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.EmailValidateCode model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [EmailValidateCode] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.EmailValidateCode model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.UserId != Int32.MinValue)
            {
                colList.Append("[UserId] = @UserId,");
                SqlParameter parameter = new SqlParameter("@UserId", SqlDbType.Int, 4);
                parameter.Value = model.UserId;
                paramList.Add(parameter);
            }

            if (model.Loginname != null)
            {
                colList.Append("[Loginname] = @Loginname,");
                SqlParameter parameter = new SqlParameter("@Loginname", SqlDbType.NVarChar, 50);
                parameter.Value = model.Loginname;
                paramList.Add(parameter);
            }

            if (model.Email != null)
            {
                colList.Append("[Email] = @Email,");
                SqlParameter parameter = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                parameter.Value = model.Email;
                paramList.Add(parameter);
            }

            if (model.Code != null)
            {
                colList.Append("[Code] = @Code,");
                SqlParameter parameter = new SqlParameter("@Code", SqlDbType.NVarChar, 10);
                parameter.Value = model.Code;
                paramList.Add(parameter);
            }

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                paramList.Add(parameter);
            }

            if (model.Status.HasValue)
            {
                colList.Append("[Status] = @Status,");
                SqlParameter parameter = new SqlParameter("@Status", SqlDbType.Bit, 1);
                parameter.Value = model.Status.Value; paramList.Add(parameter);
            }

            if (model.CodeType != Int32.MinValue)
            {
                colList.Append("[CodeType] = @CodeType,");
                SqlParameter parameter = new SqlParameter("@CodeType", SqlDbType.Int, 4);
                parameter.Value = model.CodeType;
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
        public static NH.Model.EmailValidateCode GetModel(int Id)
        {
            NH.Model.EmailValidateCode model = new NH.Model.EmailValidateCode();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.EmailValidateCode GetModel(NH.Model.EmailValidateCode model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, UserId, Loginname, Email, Code, AddTime, Status, CodeType ");
            strSql.Append(" from [EmailValidateCode] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.EmailValidateCode();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            if (row["UserId"].ToString() != "")
            {
                model.UserId = int.Parse(row["UserId"].ToString());
            }

            model.Loginname = row["Loginname"].ToString();

            model.Email = row["Email"].ToString();

            model.Code = row["Code"].ToString();

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }


            if (row["Status"].ToString() != "")
            {
                if ((row["Status"].ToString() == "1") || (row["Status"].ToString().ToLower() == "true"))
                {
                    model.Status = true;
                }
                else
                {
                    model.Status = false;
                }
            }

            if (row["CodeType"].ToString() != "")
            {
                model.CodeType = int.Parse(row["CodeType"].ToString());
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
            strSql.Append(" FROM [EmailValidateCode] ");
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
            strSql.Append(" FROM [EmailValidateCode] ");
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



