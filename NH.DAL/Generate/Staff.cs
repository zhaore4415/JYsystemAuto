using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Staff
    /// </summary>
    public static partial class Staff
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Staff model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Staff] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Staff model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.LastLoginTime != DateTime.MinValue)
            {
                colList.Append("[LastLoginTime],");
                colParamList.Append("@LastLoginTime,");
                parameter = new SqlParameter("@LastLoginTime", SqlDbType.DateTime);
                parameter.Value = model.LastLoginTime;
                sqlParamList.Add(parameter);
            }

            if (model.LastIP != null)
            {
                colList.Append("[LastIP],");
                colParamList.Append("@LastIP,");
                parameter = new SqlParameter("@LastIP", SqlDbType.NVarChar, 20);
                parameter.Value = model.LastIP;
                sqlParamList.Add(parameter);
            }

            if (model.LastAddress != null)
            {
                colList.Append("[LastAddress],");
                colParamList.Append("@LastAddress,");
                parameter = new SqlParameter("@LastAddress", SqlDbType.NVarChar, 50);
                parameter.Value = model.LastAddress;
                sqlParamList.Add(parameter);
            }

            if (model.LoginCount != Int32.MinValue)
            {
                colList.Append("[LoginCount],");
                colParamList.Append("@LoginCount,");
                parameter = new SqlParameter("@LoginCount", SqlDbType.Int, 4);
                parameter.Value = model.LoginCount;
                sqlParamList.Add(parameter);
            }

            if (model.UpdateTime != DateTime.MinValue)
            {
                colList.Append("[UpdateTime],");
                colParamList.Append("@UpdateTime,");
                parameter = new SqlParameter("@UpdateTime", SqlDbType.DateTime);
                parameter.Value = model.UpdateTime;
                sqlParamList.Add(parameter);
            }

            if (model.RoleType.HasValue)
            {
                colList.Append("[RoleType],");
                colParamList.Append("@RoleType,");
                parameter = new SqlParameter("@RoleType", SqlDbType.Int, 4);
                if (model.RoleType.Value != Int32.MinValue)
                    parameter.Value = model.RoleType.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Phone != null)
            {
                colList.Append("[Phone],");
                colParamList.Append("@Phone,");
                parameter = new SqlParameter("@Phone", SqlDbType.NVarChar, 30);
                parameter.Value = model.Phone;
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

            if (model.Address != null)
            {
                colList.Append("[Address],");
                colParamList.Append("@Address,");
                parameter = new SqlParameter("@Address", SqlDbType.NVarChar, 100);
                parameter.Value = model.Address;
                sqlParamList.Add(parameter);
            }

            if (model.Data1 != null)
            {
                colList.Append("[Data1],");
                colParamList.Append("@Data1,");
                parameter = new SqlParameter("@Data1", SqlDbType.NVarChar, 50);
                parameter.Value = model.Data1;
                sqlParamList.Add(parameter);
            }

            if (model.LoginName != null)
            {
                colList.Append("[LoginName],");
                colParamList.Append("@LoginName,");
                parameter = new SqlParameter("@LoginName", SqlDbType.NVarChar, 50);
                parameter.Value = model.LoginName;
                sqlParamList.Add(parameter);
            }

            if (model.Data2 != null)
            {
                colList.Append("[Data2],");
                colParamList.Append("@Data2,");
                parameter = new SqlParameter("@Data2", SqlDbType.NVarChar, 50);
                parameter.Value = model.Data2;
                sqlParamList.Add(parameter);
            }

            if (model.DataType1.HasValue)
            {
                colList.Append("[DataType1],");
                colParamList.Append("@DataType1,");
                parameter = new SqlParameter("@DataType1", SqlDbType.Int, 4);
                if (model.DataType1.Value != Int32.MinValue)
                    parameter.Value = model.DataType1.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.DataType2.HasValue)
            {
                colList.Append("[DataType2],");
                colParamList.Append("@DataType2,");
                parameter = new SqlParameter("@DataType2", SqlDbType.Int, 4);
                if (model.DataType2.Value != Int32.MinValue)
                    parameter.Value = model.DataType2.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.WorkNumber != null)
            {
                colList.Append("[WorkNumber],");
                colParamList.Append("@WorkNumber,");
                parameter = new SqlParameter("@WorkNumber", SqlDbType.NVarChar, 30);
                parameter.Value = model.WorkNumber;
                sqlParamList.Add(parameter);
            }

            if (model.TodayDate != null)
            {
                colList.Append("[TodayDate],");
                colParamList.Append("@TodayDate,");
                parameter = new SqlParameter("@TodayDate", SqlDbType.NVarChar, 30);
                parameter.Value = model.TodayDate;
                sqlParamList.Add(parameter);
            }

            if (model.Password != null)
            {
                colList.Append("[Password],");
                colParamList.Append("@Password,");
                parameter = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
                parameter.Value = model.Password;
                sqlParamList.Add(parameter);
            }

            if (model.Realname != null)
            {
                colList.Append("[Realname],");
                colParamList.Append("@Realname,");
                parameter = new SqlParameter("@Realname", SqlDbType.NVarChar, 20);
                parameter.Value = model.Realname;
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

            if (model.Status != Int32.MinValue)
            {
                colList.Append("[Status],");
                colParamList.Append("@Status,");
                parameter = new SqlParameter("@Status", SqlDbType.Int, 4);
                parameter.Value = model.Status;
                sqlParamList.Add(parameter);
            }

            if (model.LoginTime != DateTime.MinValue)
            {
                colList.Append("[LoginTime],");
                colParamList.Append("@LoginTime,");
                parameter = new SqlParameter("@LoginTime", SqlDbType.DateTime);
                parameter.Value = model.LoginTime;
                sqlParamList.Add(parameter);
            }

            if (model.LoginIP != null)
            {
                colList.Append("[LoginIP],");
                colParamList.Append("@LoginIP,");
                parameter = new SqlParameter("@LoginIP", SqlDbType.NVarChar, 20);
                parameter.Value = model.LoginIP;
                sqlParamList.Add(parameter);
            }

            if (model.LoginAddress != null)
            {
                colList.Append("[LoginAddress],");
                colParamList.Append("@LoginAddress,");
                parameter = new SqlParameter("@LoginAddress", SqlDbType.NVarChar, 50);
                parameter.Value = model.LoginAddress;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [Staff] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from Staff ");
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
            strSql.Append("delete from [Staff] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Staff model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Staff] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Staff model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.LastLoginTime != DateTime.MinValue)
            {
                colList.Append("[LastLoginTime] = @LastLoginTime,");
                SqlParameter parameter = new SqlParameter("@LastLoginTime", SqlDbType.DateTime);
                parameter.Value = model.LastLoginTime;
                paramList.Add(parameter);
            }

            if (model.LastIP != null)
            {
                colList.Append("[LastIP] = @LastIP,");
                SqlParameter parameter = new SqlParameter("@LastIP", SqlDbType.NVarChar, 20);
                parameter.Value = model.LastIP;
                paramList.Add(parameter);
            }

            if (model.LastAddress != null)
            {
                colList.Append("[LastAddress] = @LastAddress,");
                SqlParameter parameter = new SqlParameter("@LastAddress", SqlDbType.NVarChar, 50);
                parameter.Value = model.LastAddress;
                paramList.Add(parameter);
            }

            if (model.LoginCount != Int32.MinValue)
            {
                colList.Append("[LoginCount] = @LoginCount,");
                SqlParameter parameter = new SqlParameter("@LoginCount", SqlDbType.Int, 4);
                parameter.Value = model.LoginCount;
                paramList.Add(parameter);
            }

            if (model.UpdateTime != DateTime.MinValue)
            {
                colList.Append("[UpdateTime] = @UpdateTime,");
                SqlParameter parameter = new SqlParameter("@UpdateTime", SqlDbType.DateTime);
                parameter.Value = model.UpdateTime;
                paramList.Add(parameter);
            }

            if (model.RoleType.HasValue)
            {
                colList.Append("[RoleType] = @RoleType,");
                SqlParameter parameter = new SqlParameter("@RoleType", SqlDbType.Int, 4);
                parameter.Value = model.RoleType.Value;
                paramList.Add(parameter);
            }

            if (model.Phone != null)
            {
                colList.Append("[Phone] = @Phone,");
                SqlParameter parameter = new SqlParameter("@Phone", SqlDbType.NVarChar, 30);
                parameter.Value = model.Phone;
                paramList.Add(parameter);
            }

            if (model.Email != null)
            {
                colList.Append("[Email] = @Email,");
                SqlParameter parameter = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                parameter.Value = model.Email;
                paramList.Add(parameter);
            }

            if (model.Address != null)
            {
                colList.Append("[Address] = @Address,");
                SqlParameter parameter = new SqlParameter("@Address", SqlDbType.NVarChar, 100);
                parameter.Value = model.Address;
                paramList.Add(parameter);
            }

            if (model.Data1 != null)
            {
                colList.Append("[Data1] = @Data1,");
                SqlParameter parameter = new SqlParameter("@Data1", SqlDbType.NVarChar, 50);
                parameter.Value = model.Data1;
                paramList.Add(parameter);
            }

            if (model.LoginName != null)
            {
                colList.Append("[LoginName] = @LoginName,");
                SqlParameter parameter = new SqlParameter("@LoginName", SqlDbType.NVarChar, 50);
                parameter.Value = model.LoginName;
                paramList.Add(parameter);
            }

            if (model.Data2 != null)
            {
                colList.Append("[Data2] = @Data2,");
                SqlParameter parameter = new SqlParameter("@Data2", SqlDbType.NVarChar, 50);
                parameter.Value = model.Data2;
                paramList.Add(parameter);
            }

            if (model.DataType1.HasValue)
            {
                colList.Append("[DataType1] = @DataType1,");
                SqlParameter parameter = new SqlParameter("@DataType1", SqlDbType.Int, 4);
                parameter.Value = model.DataType1.Value;
                paramList.Add(parameter);
            }

            if (model.DataType2.HasValue)
            {
                colList.Append("[DataType2] = @DataType2,");
                SqlParameter parameter = new SqlParameter("@DataType2", SqlDbType.Int, 4);
                parameter.Value = model.DataType2.Value;
                paramList.Add(parameter);
            }

            if (model.WorkNumber != null)
            {
                colList.Append("[WorkNumber] = @WorkNumber,");
                SqlParameter parameter = new SqlParameter("@WorkNumber", SqlDbType.NVarChar, 30);
                parameter.Value = model.WorkNumber;
                paramList.Add(parameter);
            }

            if (model.TodayDate != null)
            {
                colList.Append("[TodayDate] = @TodayDate,");
                SqlParameter parameter = new SqlParameter("@TodayDate", SqlDbType.NVarChar, 30);
                parameter.Value = model.TodayDate;
                paramList.Add(parameter);
            }

            if (model.Password != null)
            {
                colList.Append("[Password] = @Password,");
                SqlParameter parameter = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
                parameter.Value = model.Password;
                paramList.Add(parameter);
            }

            if (model.Realname != null)
            {
                colList.Append("[Realname] = @Realname,");
                SqlParameter parameter = new SqlParameter("@Realname", SqlDbType.NVarChar, 20);
                parameter.Value = model.Realname;
                paramList.Add(parameter);
            }

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                paramList.Add(parameter);
            }

            if (model.Status != Int32.MinValue)
            {
                colList.Append("[Status] = @Status,");
                SqlParameter parameter = new SqlParameter("@Status", SqlDbType.Int, 4);
                parameter.Value = model.Status;
                paramList.Add(parameter);
            }

            if (model.LoginTime != DateTime.MinValue)
            {
                colList.Append("[LoginTime] = @LoginTime,");
                SqlParameter parameter = new SqlParameter("@LoginTime", SqlDbType.DateTime);
                parameter.Value = model.LoginTime;
                paramList.Add(parameter);
            }

            if (model.LoginIP != null)
            {
                colList.Append("[LoginIP] = @LoginIP,");
                SqlParameter parameter = new SqlParameter("@LoginIP", SqlDbType.NVarChar, 20);
                parameter.Value = model.LoginIP;
                paramList.Add(parameter);
            }

            if (model.LoginAddress != null)
            {
                colList.Append("[LoginAddress] = @LoginAddress,");
                SqlParameter parameter = new SqlParameter("@LoginAddress", SqlDbType.NVarChar, 50);
                parameter.Value = model.LoginAddress;
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
        public static NH.Model.Staff GetModel(int Id)
        {
            NH.Model.Staff model = new NH.Model.Staff();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Staff GetModel(NH.Model.Staff model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [Id], [LastLoginTime], [LastIP], [LastAddress], [LoginCount], [UpdateTime], [RoleType], [Phone], [Email], [Address], [Data1], [LoginName], [Data2], [DataType1], [DataType2], [WorkNumber], [TodayDate], [Password], [Realname], [AddTime], [Status], [LoginTime], [LoginIP], [LoginAddress] ");
            strSql.Append(" from [Staff] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Staff();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            if (row["LastLoginTime"].ToString() != "")
            {
                model.LastLoginTime = DateTime.Parse(row["LastLoginTime"].ToString());
            }

            model.LastIP = row["LastIP"].ToString();

            model.LastAddress = row["LastAddress"].ToString();

            if (row["LoginCount"].ToString() != "")
            {
                model.LoginCount = int.Parse(row["LoginCount"].ToString());
            }

            if (row["UpdateTime"].ToString() != "")
            {
                model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
            }

            if (row["RoleType"].ToString() != "")
            {
                model.RoleType = int.Parse(row["RoleType"].ToString());
            }

            model.Phone = row["Phone"].ToString();

            model.Email = row["Email"].ToString();

            model.Address = row["Address"].ToString();

            model.Data1 = row["Data1"].ToString();

            model.LoginName = row["LoginName"].ToString();

            model.Data2 = row["Data2"].ToString();

            if (row["DataType1"].ToString() != "")
            {
                model.DataType1 = int.Parse(row["DataType1"].ToString());
            }

            if (row["DataType2"].ToString() != "")
            {
                model.DataType2 = int.Parse(row["DataType2"].ToString());
            }

            model.WorkNumber = row["WorkNumber"].ToString();

            model.TodayDate = row["TodayDate"].ToString();

            model.Password = row["Password"].ToString();

            model.Realname = row["Realname"].ToString();

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }

            if (row["Status"].ToString() != "")
            {
                model.Status = int.Parse(row["Status"].ToString());
            }

            if (row["LoginTime"].ToString() != "")
            {
                model.LoginTime = DateTime.Parse(row["LoginTime"].ToString());
            }

            model.LoginIP = row["LoginIP"].ToString();

            model.LoginAddress = row["LoginAddress"].ToString();

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
            strSql.Append(" FROM [Staff] ");
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
            strSql.Append(" FROM [Staff] ");
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



