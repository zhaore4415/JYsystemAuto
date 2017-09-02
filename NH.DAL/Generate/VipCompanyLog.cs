using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// VipCompanyLog
    /// </summary>
    public static partial class VipCompanyLog
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.VipCompanyLog model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [VipCompanyLog](nolock)");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.VipCompanyLog model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.CompanyId != Int32.MinValue)
            {
                colList.Append("[CompanyId],");
                colParamList.Append("@CompanyId,");
                parameter = new SqlParameter("@CompanyId", SqlDbType.Int, 4);
                parameter.Value = model.CompanyId;
                sqlParamList.Add(parameter);
            }

            if (model.LevelID != Int32.MinValue)
            {
                colList.Append("[LevelID],");
                colParamList.Append("@LevelID,");
                parameter = new SqlParameter("@LevelID", SqlDbType.Int, 4);
                parameter.Value = model.LevelID;
                sqlParamList.Add(parameter);
            }

            if (model.ExpireDate.HasValue)
            {
                colList.Append("[ExpireDate],");
                colParamList.Append("@ExpireDate,");
                parameter = new SqlParameter("@ExpireDate", SqlDbType.SmallDateTime);
                if (model.ExpireDate.Value != DateTime.MinValue)
                    parameter.Value = model.ExpireDate.Value;
                else
                    parameter.Value = DBNull.Value;

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

            if (model.AddType != Int32.MinValue)
            {
                colList.Append("[AddType],");
                colParamList.Append("@AddType,");
                parameter = new SqlParameter("@AddType", SqlDbType.Int, 4);
                parameter.Value = model.AddType;
                sqlParamList.Add(parameter);
            }

            if (model.AddUser != null)
            {
                colList.Append("[AddUser],");
                colParamList.Append("@AddUser,");
                parameter = new SqlParameter("@AddUser", SqlDbType.NVarChar, 20);
                parameter.Value = model.AddUser;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [VipCompanyLog] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from [VipCompanyLog] ");
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
            strSql.Append("delete from [VipCompanyLog] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.VipCompanyLog model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [VipCompanyLog] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.VipCompanyLog model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.CompanyId != Int32.MinValue)
            {
                colList.Append("[CompanyId] = @CompanyId,");
                SqlParameter parameter = new SqlParameter("@CompanyId", SqlDbType.Int, 4);
                parameter.Value = model.CompanyId;
                paramList.Add(parameter);
            }

            if (model.LevelID != Int32.MinValue)
            {
                colList.Append("[LevelID] = @LevelID,");
                SqlParameter parameter = new SqlParameter("@LevelID", SqlDbType.Int, 4);
                parameter.Value = model.LevelID;
                paramList.Add(parameter);
            }

            if (model.ExpireDate.HasValue)
            {
                colList.Append("[ExpireDate] = @ExpireDate,");
                SqlParameter parameter = new SqlParameter("@ExpireDate", SqlDbType.SmallDateTime);
                if (model.ExpireDate.Value != DateTime.MinValue)
                    parameter.Value = model.ExpireDate.Value;
                else
                    parameter.Value = DBNull.Value;
                paramList.Add(parameter);
            }

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                paramList.Add(parameter);
            }

            if (model.AddType != Int32.MinValue)
            {
                colList.Append("[AddType] = @AddType,");
                SqlParameter parameter = new SqlParameter("@AddType", SqlDbType.Int, 4);
                parameter.Value = model.AddType;
                paramList.Add(parameter);
            }

            if (model.AddUser != null)
            {
                colList.Append("[AddUser] = @AddUser,");
                SqlParameter parameter = new SqlParameter("@AddUser", SqlDbType.NVarChar, 20);
                parameter.Value = model.AddUser;
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
        public static NH.Model.VipCompanyLog GetModel(int Id)
        {
            NH.Model.VipCompanyLog model = new NH.Model.VipCompanyLog();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.VipCompanyLog GetModel(NH.Model.VipCompanyLog model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, CompanyId, LevelID, ExpireDate, AddTime, AddType, AddUser ");
            strSql.Append(" from [VipCompanyLog] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.VipCompanyLog();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            if (row["CompanyId"].ToString() != "")
            {
                model.CompanyId = int.Parse(row["CompanyId"].ToString());
            }

            if (row["LevelID"].ToString() != "")
            {
                model.LevelID = int.Parse(row["LevelID"].ToString());
            }

            if (row["ExpireDate"].ToString() != "")
            {
                model.ExpireDate = DateTime.Parse(row["ExpireDate"].ToString());
            }

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }

            if (row["AddType"].ToString() != "")
            {
                model.AddType = int.Parse(row["AddType"].ToString());
            }

            model.AddUser = row["AddUser"].ToString();

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
            strSql.Append(" FROM [VipCompanyLog] ");
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
            strSql.Append(" FROM [VipCompanyLog] ");
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



