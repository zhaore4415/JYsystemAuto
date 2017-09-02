using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// User
    /// </summary>
    public static partial class User
    {
        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.User model, SqlTransaction trans)
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

            if (model.Completed != decimal.MinValue)
            {
                colList.Append("[Completed],");
                colParamList.Append("@Completed,");
                parameter = new SqlParameter("@Completed", SqlDbType.Decimal, 9);
                parameter.Value = model.Completed;
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

            if (model.RefreshTime != DateTime.MinValue)
            {
                colList.Append("[RefreshTime],");
                colParamList.Append("@RefreshTime,");
                parameter = new SqlParameter("@RefreshTime", SqlDbType.DateTime);
                parameter.Value = model.RefreshTime;
                sqlParamList.Add(parameter);
            }

            if (model.UserType != Int32.MinValue)
            {
                colList.Append("[UserType],");
                colParamList.Append("@UserType,");
                parameter = new SqlParameter("@UserType", SqlDbType.Int, 4);
                parameter.Value = model.UserType;
                sqlParamList.Add(parameter);
            }

            if (model.PhotoOriginal != null)
            {
                colList.Append("[PhotoOriginal],");
                colParamList.Append("@PhotoOriginal,");
                parameter = new SqlParameter("@PhotoOriginal", SqlDbType.NVarChar, 50);
                parameter.Value = model.PhotoOriginal;
                sqlParamList.Add(parameter);
            }

            if (model.PhotoCoording != null)
            {
                colList.Append("[PhotoCoording],");
                colParamList.Append("@PhotoCoording,");
                parameter = new SqlParameter("@PhotoCoording", SqlDbType.NVarChar, 20);
                parameter.Value = model.PhotoCoording;
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

            if (model.PhotoVerifyStatus != Int32.MinValue)
            {
                colList.Append("[PhotoVerifyStatus],");
                colParamList.Append("@PhotoVerifyStatus,");
                parameter = new SqlParameter("@PhotoVerifyStatus", SqlDbType.Int, 4);
                parameter.Value = model.PhotoVerifyStatus;
                sqlParamList.Add(parameter);
            }

            if (model.PhotoNew != null)
            {
                colList.Append("[PhotoNew],");
                colParamList.Append("@PhotoNew,");
                parameter = new SqlParameter("@PhotoNew", SqlDbType.NVarChar, 50);
                parameter.Value = model.PhotoNew;
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

            if (model.Photo != null)
            {
                colList.Append("[Photo],");
                colParamList.Append("@Photo,");
                parameter = new SqlParameter("@Photo", SqlDbType.NVarChar, 50);
                parameter.Value = model.Photo;
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

            string strSql = string.Format("insert into [User] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
            strSql += ";select @@IDENTITY";                        
			   
            object obj = SqlHelper.ExecuteScalar(trans,strSql, sqlParamList.ToArray());
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

        /// <summary>
        /// 获取登录SessionId
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static string GetSessionId(int userId)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@UserId",SqlDbType.Int)
                                        };
            parameters[0].Value = userId;

            DataTable dt = SqlHelper.RunProcedure("Get_User_SessionId", parameters, "ds").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString().ToLower();
            }
            else
            {
                return null;
            }

        }

        public static void Refresh(string strWhere)
        {
            string sql = "update u set u.RefreshTime=getdate() from [User] u,Member m where u.Id=m.Id " + strWhere;
            SqlHelper.ExecuteNonQuery(sql);
        }

    }
}



