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
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.User model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [User] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.User model)
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

            if (model.LoginCount.HasValue)
            {
                colList.Append("[LoginCount],");
                colParamList.Append("@LoginCount,");
                parameter = new SqlParameter("@LoginCount", SqlDbType.Int, 4);
                if (model.LoginCount.Value != Int32.MinValue)
                    parameter.Value = model.LoginCount.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Completed.HasValue)
            {
                colList.Append("[Completed],");
                colParamList.Append("@Completed,");
                parameter = new SqlParameter("@Completed", SqlDbType.Decimal, 9);
                if (model.Completed.Value != decimal.MinValue)
                    parameter.Value = model.Completed.Value;
                else
                    parameter.Value = DBNull.Value;

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

            if (model.PhotoVerifyStatus.HasValue)
            {
                colList.Append("[PhotoVerifyStatus],");
                colParamList.Append("@PhotoVerifyStatus,");
                parameter = new SqlParameter("@PhotoVerifyStatus", SqlDbType.Int, 4);
                if (model.PhotoVerifyStatus.Value != Int32.MinValue)
                    parameter.Value = model.PhotoVerifyStatus.Value;
                else
                    parameter.Value = DBNull.Value;

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

            if (model.SessionId != null)
            {
                colList.Append("[SessionId],");
                colParamList.Append("@SessionId,");
                parameter = new SqlParameter("@SessionId", SqlDbType.NVarChar, 24);
                parameter.Value = model.SessionId;
                sqlParamList.Add(parameter);
            }

            if (model.Phone != null)
            {
                colList.Append("[Phone],");
                colParamList.Append("@Phone,");
                parameter = new SqlParameter("@Phone", SqlDbType.NVarChar, 20);
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

            if (model.QQ != null)
            {
                colList.Append("[QQ],");
                colParamList.Append("@QQ,");
                parameter = new SqlParameter("@QQ", SqlDbType.NVarChar, 20);
                parameter.Value = model.QQ;
                sqlParamList.Add(parameter);
            }

            if (model.Sex != Int32.MinValue)
            {
                colList.Append("[Sex],");
                colParamList.Append("@Sex,");
                parameter = new SqlParameter("@Sex", SqlDbType.Int, 4);
                parameter.Value = model.Sex;
                sqlParamList.Add(parameter);
            }

            if (model.Source != null)
            {
                colList.Append("[Source],");
                colParamList.Append("@Source,");
                parameter = new SqlParameter("@Source", SqlDbType.NVarChar, 20);
                parameter.Value = model.Source;
                sqlParamList.Add(parameter);
            }

            if (model.Environment != null)
            {
                colList.Append("[Environment],");
                colParamList.Append("@Environment,");
                parameter = new SqlParameter("@Environment", SqlDbType.NVarChar, 150);
                parameter.Value = model.Environment;
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

            if (model.Text1 != null)
            {
                colList.Append("[Text1],");
                colParamList.Append("@Text1,");
                parameter = new SqlParameter("@Text1", SqlDbType.NVarChar, 100);
                parameter.Value = model.Text1;
                sqlParamList.Add(parameter);
            }

            if (model.Text2 != null)
            {
                colList.Append("[Text2],");
                colParamList.Append("@Text2,");
                parameter = new SqlParameter("@Text2", SqlDbType.NVarChar, 100);
                parameter.Value = model.Text2;
                sqlParamList.Add(parameter);
            }

            if (model.Text3.HasValue)
            {
                colList.Append("[Text3],");
                colParamList.Append("@Text3,");
                parameter = new SqlParameter("@Text3", SqlDbType.Int, 4);
                if (model.Text3.Value != Int32.MinValue)
                    parameter.Value = model.Text3.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Text4.HasValue)
            {
                colList.Append("[Text4],");
                colParamList.Append("@Text4,");
                parameter = new SqlParameter("@Text4", SqlDbType.Int, 4);
                if (model.Text4.Value != Int32.MinValue)
                    parameter.Value = model.Text4.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Text5.HasValue)
            {
                colList.Append("[Text5],");
                colParamList.Append("@Text5,");
                parameter = new SqlParameter("@Text5", SqlDbType.Int, 4);
                if (model.Text5.Value != Int32.MinValue)
                    parameter.Value = model.Text5.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Text6.HasValue)
            {
                colList.Append("[Text6],");
                colParamList.Append("@Text6,");
                parameter = new SqlParameter("@Text6", SqlDbType.Int, 4);
                if (model.Text6.Value != Int32.MinValue)
                    parameter.Value = model.Text6.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Text7 != null)
            {
                colList.Append("[Text7],");
                colParamList.Append("@Text7,");
                parameter = new SqlParameter("@Text7", SqlDbType.NVarChar, 50);
                parameter.Value = model.Text7;
                sqlParamList.Add(parameter);
            }

            if (model.Text9 != null)
            {
                colList.Append("[Text9],");
                colParamList.Append("@Text9,");
                parameter = new SqlParameter("@Text9", SqlDbType.NVarChar, 50);
                parameter.Value = model.Text9;
                sqlParamList.Add(parameter);
            }

            if (model.Text10 != null)
            {
                colList.Append("[Text10],");
                colParamList.Append("@Text10,");
                parameter = new SqlParameter("@Text10", SqlDbType.NVarChar, 50);
                parameter.Value = model.Text10;
                sqlParamList.Add(parameter);
            }

            if (model.Text11 != null)
            {
                colList.Append("[Text11],");
                colParamList.Append("@Text11,");
                parameter = new SqlParameter("@Text11", SqlDbType.NVarChar, 50);
                parameter.Value = model.Text11;
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

            if (model.Age != null)
            {
                colList.Append("[Age],");
                colParamList.Append("@Age,");
                parameter = new SqlParameter("@Age", SqlDbType.NVarChar, 20);
                parameter.Value = model.Age;
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
            if (model.Depth != Int32.MinValue)
            {
                colList.Append("[Depth],");
                colParamList.Append("@Depth,");
                parameter = new SqlParameter("@Depth", SqlDbType.Int, 4);
                if (model.Depth != Int32.MinValue)
                    parameter.Value = model.Depth;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.ParentID != Int32.MinValue)
            {
                colList.Append("[ParentID],");
                colParamList.Append("@ParentID,");
                parameter = new SqlParameter("@ParentID", SqlDbType.Int, 4);
                if (model.ParentID != Int32.MinValue)
                    parameter.Value = model.ParentID;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Path != null)
            {
                colList.Append("[Path],");
                colParamList.Append("@Path,");
                parameter = new SqlParameter("@Path", SqlDbType.VarChar, 200);
                parameter.Value = model.Path;
                sqlParamList.Add(parameter);
            }
            if (model.Ordernumber.HasValue)
            {
                colList.Append("[Ordernumber],");
                colParamList.Append("@Ordernumber,");
                parameter = new SqlParameter("@Ordernumber", SqlDbType.Int, 4);
                if (model.Ordernumber.Value != Int32.MinValue)
                    parameter.Value = model.Ordernumber.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }
            if (model.OrderAmount.HasValue)
            {
                colList.Append("[OrderAmount],");
                colParamList.Append("@OrderAmount,");
                parameter = new SqlParameter("@OrderAmount", SqlDbType.Decimal, 9);
                if (model.OrderAmount.Value != decimal.MinValue)
                    parameter.Value = model.OrderAmount.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }
            if (model.IdNumber != null)
            {
                colList.Append("[IdNumber],");
                colParamList.Append("@IdNumber,");
                parameter = new SqlParameter("@IdNumber", SqlDbType.NVarChar, 30);
                parameter.Value = model.IdNumber;
                sqlParamList.Add(parameter);
            }

            if (model.Openbank != null)
            {
                colList.Append("[Openbank],");
                colParamList.Append("@Openbank,");
                parameter = new SqlParameter("@Openbank", SqlDbType.NVarChar, 5);
                parameter.Value = model.Openbank;
                sqlParamList.Add(parameter);
            }

            if (model.OpenbankCard != null)
            {
                colList.Append("[OpenbankCard],");
                colParamList.Append("@OpenbankCard,");
                parameter = new SqlParameter("@OpenbankCard", SqlDbType.NVarChar, 50);
                parameter.Value = model.OpenbankCard;
                sqlParamList.Add(parameter);
            }

            if (model.OpenCity != null)
            {
                colList.Append("[OpenCity],");
                colParamList.Append("@OpenCity,");
                parameter = new SqlParameter("@OpenCity", SqlDbType.NVarChar, 200);
                parameter.Value = model.OpenCity;
                sqlParamList.Add(parameter);
            }

            if (model.Pic2 != null)
            {
                colList.Append("[Pic2],");
                colParamList.Append("@Pic2,");
                parameter = new SqlParameter("@Pic2", SqlDbType.NVarChar, 50);
                parameter.Value = model.Pic2;
                sqlParamList.Add(parameter);
            }
            if (model.Pic4 != null)
            {
                colList.Append("[Pic4],");
                colParamList.Append("@Pic4,");
                parameter = new SqlParameter("@Pic4", SqlDbType.NVarChar, 50);
                parameter.Value = model.Pic4;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [User] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from User ");
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
            strSql.Append("delete from [User] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.User model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [User] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.User model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.LoginCount.HasValue)
            {
                colList.Append("[LoginCount] = @LoginCount,");
                SqlParameter parameter = new SqlParameter("@LoginCount", SqlDbType.Int, 4);
                parameter.Value = model.LoginCount.Value;
                paramList.Add(parameter);
            }

            if (model.Completed.HasValue)
            {
                colList.Append("[Completed] = @Completed,");
                SqlParameter parameter = new SqlParameter("@Completed", SqlDbType.Decimal, 9);
                parameter.Value = model.Completed.Value;
                paramList.Add(parameter);
            }

            if (model.UpdateTime != DateTime.MinValue)
            {
                colList.Append("[UpdateTime] = @UpdateTime,");
                SqlParameter parameter = new SqlParameter("@UpdateTime", SqlDbType.DateTime);
                parameter.Value = model.UpdateTime;
                paramList.Add(parameter);
            }

            if (model.RefreshTime != DateTime.MinValue)
            {
                colList.Append("[RefreshTime] = @RefreshTime,");
                SqlParameter parameter = new SqlParameter("@RefreshTime", SqlDbType.DateTime);
                parameter.Value = model.RefreshTime;
                paramList.Add(parameter);
            }

            if (model.UserType != Int32.MinValue)
            {
                colList.Append("[UserType] = @UserType,");
                SqlParameter parameter = new SqlParameter("@UserType", SqlDbType.Int, 4);
                parameter.Value = model.UserType;
                paramList.Add(parameter);
            }

            if (model.PhotoOriginal != null)
            {
                colList.Append("[PhotoOriginal] = @PhotoOriginal,");
                SqlParameter parameter = new SqlParameter("@PhotoOriginal", SqlDbType.NVarChar, 50);
                parameter.Value = model.PhotoOriginal;
                paramList.Add(parameter);
            }

            if (model.PhotoCoording != null)
            {
                colList.Append("[PhotoCoording] = @PhotoCoording,");
                SqlParameter parameter = new SqlParameter("@PhotoCoording", SqlDbType.NVarChar, 20);
                parameter.Value = model.PhotoCoording;
                paramList.Add(parameter);
            }

            if (model.LoginName != null)
            {
                colList.Append("[LoginName] = @LoginName,");
                SqlParameter parameter = new SqlParameter("@LoginName", SqlDbType.NVarChar, 50);
                parameter.Value = model.LoginName;
                paramList.Add(parameter);
            }

            if (model.PhotoVerifyStatus.HasValue)
            {
                colList.Append("[PhotoVerifyStatus] = @PhotoVerifyStatus,");
                SqlParameter parameter = new SqlParameter("@PhotoVerifyStatus", SqlDbType.Int, 4);
                parameter.Value = model.PhotoVerifyStatus.Value;
                paramList.Add(parameter);
            }

            if (model.PhotoNew != null)
            {
                colList.Append("[PhotoNew] = @PhotoNew,");
                SqlParameter parameter = new SqlParameter("@PhotoNew", SqlDbType.NVarChar, 50);
                parameter.Value = model.PhotoNew;
                paramList.Add(parameter);
            }

            if (model.SessionId != null)
            {
                colList.Append("[SessionId] = @SessionId,");
                SqlParameter parameter = new SqlParameter("@SessionId", SqlDbType.NVarChar, 24);
                parameter.Value = model.SessionId;
                paramList.Add(parameter);
            }

            if (model.Phone != null)
            {
                colList.Append("[Phone] = @Phone,");
                SqlParameter parameter = new SqlParameter("@Phone", SqlDbType.NVarChar, 20);
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

            if (model.QQ != null)
            {
                colList.Append("[QQ] = @QQ,");
                SqlParameter parameter = new SqlParameter("@QQ", SqlDbType.NVarChar, 20);
                parameter.Value = model.QQ;
                paramList.Add(parameter);
            }

            if (model.Sex != Int32.MinValue)
            {
                colList.Append("[Sex] = @Sex,");
                SqlParameter parameter = new SqlParameter("@Sex", SqlDbType.Int, 4);
                parameter.Value = model.Sex;
                paramList.Add(parameter);
            }

            if (model.Source != null)
            {
                colList.Append("[Source] = @Source,");
                SqlParameter parameter = new SqlParameter("@Source", SqlDbType.NVarChar, 20);
                parameter.Value = model.Source;
                paramList.Add(parameter);
            }

            if (model.Environment != null)
            {
                colList.Append("[Environment] = @Environment,");
                SqlParameter parameter = new SqlParameter("@Environment", SqlDbType.NVarChar, 150);
                parameter.Value = model.Environment;
                paramList.Add(parameter);
            }

            if (model.Password != null)
            {
                colList.Append("[Password] = @Password,");
                SqlParameter parameter = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
                parameter.Value = model.Password;
                paramList.Add(parameter);
            }

            if (model.Text1 != null)
            {
                colList.Append("[Text1] = @Text1,");
                SqlParameter parameter = new SqlParameter("@Text1", SqlDbType.NVarChar, 100);
                parameter.Value = model.Text1;
                paramList.Add(parameter);
            }

            if (model.Text2 != null)
            {
                colList.Append("[Text2] = @Text2,");
                SqlParameter parameter = new SqlParameter("@Text2", SqlDbType.NVarChar, 100);
                parameter.Value = model.Text2;
                paramList.Add(parameter);
            }

            if (model.Text3.HasValue)
            {
                colList.Append("[Text3] = @Text3,");
                SqlParameter parameter = new SqlParameter("@Text3", SqlDbType.Int, 4);
                parameter.Value = model.Text3.Value;
                paramList.Add(parameter);
            }

            if (model.Text4.HasValue)
            {
                colList.Append("[Text4] = @Text4,");
                SqlParameter parameter = new SqlParameter("@Text4", SqlDbType.Int, 4);
                parameter.Value = model.Text4.Value;
                paramList.Add(parameter);
            }

            if (model.Text5.HasValue)
            {
                colList.Append("[Text5] = @Text5,");
                SqlParameter parameter = new SqlParameter("@Text5", SqlDbType.Int, 4);
                parameter.Value = model.Text5.Value;
                paramList.Add(parameter);
            }

            if (model.Text6.HasValue)
            {
                colList.Append("[Text6] = @Text6,");
                SqlParameter parameter = new SqlParameter("@Text6", SqlDbType.Int, 4);
                parameter.Value = model.Text6.Value;
                paramList.Add(parameter);
            }

            if (model.Text7 != null)
            {
                colList.Append("[Text7] = @Text7,");
                SqlParameter parameter = new SqlParameter("@Text7", SqlDbType.NVarChar, 50);
                parameter.Value = model.Text7;
                paramList.Add(parameter);
            }

            if (model.Text9 != null)
            {
                colList.Append("[Text9] = @Text9,");
                SqlParameter parameter = new SqlParameter("@Text9", SqlDbType.NVarChar, 50);
                parameter.Value = model.Text9;
                paramList.Add(parameter);
            }

            if (model.Text10 != null)
            {
                colList.Append("[Text10] = @Text10,");
                SqlParameter parameter = new SqlParameter("@Text10", SqlDbType.NVarChar, 50);
                parameter.Value = model.Text10;
                paramList.Add(parameter);
            }

            if (model.Text11 != null)
            {
                colList.Append("[Text11] = @Text11,");
                SqlParameter parameter = new SqlParameter("@Text11", SqlDbType.NVarChar, 50);
                parameter.Value = model.Text11;
                paramList.Add(parameter);
            }

            if (model.Photo != null)
            {
                colList.Append("[Photo] = @Photo,");
                SqlParameter parameter = new SqlParameter("@Photo", SqlDbType.NVarChar, 50);
                parameter.Value = model.Photo;
                paramList.Add(parameter);
            }

            if (model.Age != null)
            {
                colList.Append("[Age] = @Age,");
                SqlParameter parameter = new SqlParameter("@Age", SqlDbType.NVarChar, 20);
                parameter.Value = model.Age;
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
            if (model.Depth != Int32.MinValue)
            {
                colList.Append("[Depth] = @Depth,");
                SqlParameter parameter = new SqlParameter("@Depth", SqlDbType.Int, 4);
                parameter.Value = model.Depth;
                paramList.Add(parameter);
            }

            if (model.ParentID != Int32.MinValue)
            {
                colList.Append("[ParentID] = @ParentID,");
                SqlParameter parameter = new SqlParameter("@ParentID", SqlDbType.Int, 4);
                parameter.Value = model.ParentID;
                paramList.Add(parameter);
            }

            if (model.Path != null)
            {
                colList.Append("[Path] = @Path,");
                SqlParameter parameter = new SqlParameter("@Path", SqlDbType.VarChar, 200);
                parameter.Value = model.Path;
                paramList.Add(parameter);
            }
            if (model.Ordernumber.HasValue)
            {
                colList.Append("[Ordernumber] = @Ordernumber,");
                SqlParameter parameter = new SqlParameter("@Ordernumber", SqlDbType.Int, 4);
                parameter.Value = model.Ordernumber.Value;
                paramList.Add(parameter);
            }

            if (model.OrderAmount.HasValue)
            {
                colList.Append("[OrderAmount] = @OrderAmount,");
                SqlParameter parameter = new SqlParameter("@OrderAmount", SqlDbType.Decimal, 9);
                parameter.Value = model.OrderAmount.Value;
                paramList.Add(parameter);
            }
            if (model.IdNumber != null)
            {
                colList.Append("[IdNumber] = @IdNumber,");
                SqlParameter parameter = new SqlParameter("@IdNumber", SqlDbType.NVarChar, 30);
                parameter.Value = model.IdNumber;
                paramList.Add(parameter);
            }
            if (model.Openbank != null)
            {
                colList.Append("[Openbank] = @Openbank,");
                SqlParameter parameter = new SqlParameter("@Openbank", SqlDbType.NVarChar, 50);
                parameter.Value = model.Openbank;
                paramList.Add(parameter);
            }
            if (model.OpenbankCard != null)
            {
                colList.Append("[OpenbankCard] = @OpenbankCard,");
                SqlParameter parameter = new SqlParameter("@OpenbankCard", SqlDbType.NVarChar, 50);
                parameter.Value = model.OpenbankCard;
                paramList.Add(parameter);
            }
            if (model.OpenCity != null)
            {
                colList.Append("[OpenCity] = @OpenCity,");
                SqlParameter parameter = new SqlParameter("@OpenCity", SqlDbType.NVarChar, 200);
                parameter.Value = model.OpenCity;
                paramList.Add(parameter);
            }
            if (model.Pic2 != null)
            {
                colList.Append("[Pic2] = @Pic2,");
                SqlParameter parameter = new SqlParameter("@Pic2", SqlDbType.NVarChar, 50);
                parameter.Value = model.Pic2;
                paramList.Add(parameter);
            }
            if (model.Pic4 != null)
            {
                colList.Append("[Pic4] = @Pic4,");
                SqlParameter parameter = new SqlParameter("@Pic4", SqlDbType.NVarChar, 50);
                parameter.Value = model.Pic4;
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
        public static NH.Model.User GetModel(int Id)
        {
            NH.Model.User model = new NH.Model.User();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.User GetModel(NH.Model.User model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [Id], [LastLoginTime], [LastIP], [LastAddress], [LoginCount], [Completed], [UpdateTime], [RefreshTime], [UserType], [PhotoOriginal], [PhotoCoording], [LoginName], [PhotoVerifyStatus], [PhotoNew], [SessionId], [Phone], [Email], [Address], [QQ], [Sex], [Source], [Environment], [Password], [Text1], [Text2], [Text3], [Text4], [Text5], [Text6], [Text7], [Text9], [Text10], [Text11], [Photo], [Age], [AddTime], [Status], [LoginTime], [LoginIP], [LoginAddress],[Depth], [ParentID], [Path],[Ordernumber], [OrderAmount],[IdNumber],[Openbank],[OpenbankCard],[OpenCity],[Pic2] ,[Pic4] ");
            strSql.Append(" from [User] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.User();
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

            if (row["Completed"].ToString() != "")
            {
                model.Completed = decimal.Parse(row["Completed"].ToString());
            }

            if (row["UpdateTime"].ToString() != "")
            {
                model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
            }

            if (row["RefreshTime"].ToString() != "")
            {
                model.RefreshTime = DateTime.Parse(row["RefreshTime"].ToString());
            }

            if (row["UserType"].ToString() != "")
            {
                model.UserType = int.Parse(row["UserType"].ToString());
            }

            model.PhotoOriginal = row["PhotoOriginal"].ToString();

            model.PhotoCoording = row["PhotoCoording"].ToString();

            model.LoginName = row["LoginName"].ToString();

            if (row["PhotoVerifyStatus"].ToString() != "")
            {
                model.PhotoVerifyStatus = int.Parse(row["PhotoVerifyStatus"].ToString());
            }

            model.PhotoNew = row["PhotoNew"].ToString();

            model.SessionId = row["SessionId"].ToString();

            model.Phone = row["Phone"].ToString();

            model.Email = row["Email"].ToString();

            model.Address = row["Address"].ToString();

            model.QQ = row["QQ"].ToString();

            if (row["Sex"].ToString() != "")
            {
                model.Sex = int.Parse(row["Sex"].ToString());
            }

            model.Source = row["Source"].ToString();

            model.Environment = row["Environment"].ToString();

            model.Password = row["Password"].ToString();

            model.Text1 = row["Text1"].ToString();

            model.Text2 = row["Text2"].ToString();

            if (row["Text3"].ToString() != "")
            {
                model.Text3 = int.Parse(row["Text3"].ToString());
            }

            if (row["Text4"].ToString() != "")
            {
                model.Text4 = int.Parse(row["Text4"].ToString());
            }

            if (row["Text5"].ToString() != "")
            {
                model.Text5 = int.Parse(row["Text5"].ToString());
            }

            if (row["Text6"].ToString() != "")
            {
                model.Text6 = int.Parse(row["Text6"].ToString());
            }

            model.Text7 = row["Text7"].ToString();

            model.Text9 = row["Text9"].ToString();

            model.Text10 = row["Text10"].ToString();

            model.Text11 = row["Text11"].ToString();

            model.Photo = row["Photo"].ToString();

            model.Age = row["Age"].ToString();

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
            if (row["Depth"].ToString() != "")
            {
                model.Depth = int.Parse(row["Depth"].ToString());
            }

            if (row["ParentID"].ToString() != "")
            {
                model.ParentID = int.Parse(row["ParentID"].ToString());
            }

            model.Path = row["Path"].ToString();

            if (row["Ordernumber"].ToString() != "")
            {
                model.Ordernumber = int.Parse(row["Ordernumber"].ToString());
            }

            if (row["OrderAmount"].ToString() != "")
            {
                model.OrderAmount = decimal.Parse(row["OrderAmount"].ToString());
            }
            model.IdNumber = row["IdNumber"].ToString();

            model.Openbank = row["Openbank"].ToString();

            model.OpenbankCard = row["OpenbankCard"].ToString();

            model.LastAddress = row["LastAddress"].ToString();

            model.Pic2 = row["Pic2"].ToString();

            model.Pic4 = row["Pic4"].ToString();
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
            strSql.Append(" FROM [User] ");
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
            strSql.Append(" FROM [User] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.ExecuteDataSet(strSql.ToString());
        }
        #endregion

        /// <summary>
        /// 更新共有多少订单和订单总金额
        /// </summary>
        private static void updateOrder() {
            SqlHelper.RunProcedure("UpdateOrder",new SqlParameter[] { }, "ds");
        }
        public  static int queryOrderNumber(int id)
        {
           
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT COUNT(U_ID) from Queryorder where U_ID in(" + id + ") ");
          
            return (int)SqlHelper.ExecuteScalar(strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataSet GetListByPage(string strWhere, string orderField, string orderby, int pageIndex, int pageSize, ref int count)
        {
            //updateOrder();

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT u.Id,
            u.LoginName,
        count(*) as Ordernumber,sum(Amount) as OrderAmount

            FROM [User]  u


            ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere+ " group by U_ID");
            }
            //strSql.Append(" order by " + orderField);
            return SqlHelper.GetPageList(strSql.ToString(), orderField, orderby, pageIndex, pageSize, ref count);

        }
    }
}



