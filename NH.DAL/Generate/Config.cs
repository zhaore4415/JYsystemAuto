using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Config
    /// </summary>
    public static partial class Config
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Config model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Config](nolock)");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(NH.Model.Config model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.Id != Int32.MinValue)
            {
                colList.Append("[Id],");
                colParamList.Append("@Id,");
                parameter = new SqlParameter("@Id", SqlDbType.Int, 4);
                parameter.Value = model.Id;
                sqlParamList.Add(parameter);
            }

            if (model.FriendLinkContact != null)
            {
                colList.Append("[FriendLinkContact],");
                colParamList.Append("@FriendLinkContact,");
                parameter = new SqlParameter("@FriendLinkContact", SqlDbType.NVarChar, 50);
                parameter.Value = model.FriendLinkContact;
                sqlParamList.Add(parameter);
            }

            if (model.ContactDesc != null)
            {
                colList.Append("[ContactDesc],");
                colParamList.Append("@ContactDesc,");
                parameter = new SqlParameter("@ContactDesc", SqlDbType.NText);
                parameter.Value = model.ContactDesc;
                sqlParamList.Add(parameter);
            }

            if (model.Foot != null)
            {
                colList.Append("[Foot],");
                colParamList.Append("@Foot,");
                parameter = new SqlParameter("@Foot", SqlDbType.NText);
                parameter.Value = model.Foot;
                sqlParamList.Add(parameter);
            }

            if (model.RegProtocol != null)
            {
                colList.Append("[RegProtocol],");
                colParamList.Append("@RegProtocol,");
                parameter = new SqlParameter("@RegProtocol", SqlDbType.NText);
                parameter.Value = model.RegProtocol;
                sqlParamList.Add(parameter);
            }

            if (model.WaterMarkPic != null)
            {
                colList.Append("[WaterMarkPic],");
                colParamList.Append("@WaterMarkPic,");
                parameter = new SqlParameter("@WaterMarkPic", SqlDbType.NVarChar, 20);
                parameter.Value = model.WaterMarkPic;
                sqlParamList.Add(parameter);
            }

            if (model.Sms_ID != null)
            {
                colList.Append("[Sms_ID],");
                colParamList.Append("@Sms_ID,");
                parameter = new SqlParameter("@Sms_ID", SqlDbType.NVarChar, 20);
                parameter.Value = model.Sms_ID;
                sqlParamList.Add(parameter);
            }

            if (model.Sms_Account != null)
            {
                colList.Append("[Sms_Account],");
                colParamList.Append("@Sms_Account,");
                parameter = new SqlParameter("@Sms_Account", SqlDbType.NVarChar, 20);
                parameter.Value = model.Sms_Account;
                sqlParamList.Add(parameter);
            }

            if (model.Sms_Password != null)
            {
                colList.Append("[Sms_Password],");
                colParamList.Append("@Sms_Password,");
                parameter = new SqlParameter("@Sms_Password", SqlDbType.NVarChar, 50);
                parameter.Value = model.Sms_Password;
                sqlParamList.Add(parameter);
            }

            if (model.Sms_SendMobile != null)
            {
                colList.Append("[Sms_SendMobile],");
                colParamList.Append("@Sms_SendMobile,");
                parameter = new SqlParameter("@Sms_SendMobile", SqlDbType.NVarChar, 50);
                parameter.Value = model.Sms_SendMobile;
                sqlParamList.Add(parameter);
            }

            if (model.SiteName != null)
            {
                colList.Append("[SiteName],");
                colParamList.Append("@SiteName,");
                parameter = new SqlParameter("@SiteName", SqlDbType.NVarChar, 50);
                parameter.Value = model.SiteName;
                sqlParamList.Add(parameter);
            }

            if (model.SiteTitle != null)
            {
                colList.Append("[SiteTitle],");
                colParamList.Append("@SiteTitle,");
                parameter = new SqlParameter("@SiteTitle", SqlDbType.NVarChar, 100);
                parameter.Value = model.SiteTitle;
                sqlParamList.Add(parameter);
            }

            if (model.SiteKeyword != null)
            {
                colList.Append("[SiteKeyword],");
                colParamList.Append("@SiteKeyword,");
                parameter = new SqlParameter("@SiteKeyword", SqlDbType.NVarChar, 200);
                parameter.Value = model.SiteKeyword;
                sqlParamList.Add(parameter);
            }

            if (model.SiteDescription != null)
            {
                colList.Append("[SiteDescription],");
                colParamList.Append("@SiteDescription,");
                parameter = new SqlParameter("@SiteDescription", SqlDbType.NVarChar, 200);
                parameter.Value = model.SiteDescription;
                sqlParamList.Add(parameter);
            }

            if (model.Logo != null)
            {
                colList.Append("[Logo],");
                colParamList.Append("@Logo,");
                parameter = new SqlParameter("@Logo", SqlDbType.NVarChar, 50);
                parameter.Value = model.Logo;
                sqlParamList.Add(parameter);
            }

            if (model.IsMobileValidate.HasValue)
            {
                colList.Append("[IsMobileValidate],");
                colParamList.Append("@IsMobileValidate,");
                parameter = new SqlParameter("@IsMobileValidate", SqlDbType.Bit, 1);
                parameter.Value = model.IsMobileValidate.Value;
                sqlParamList.Add(parameter);
            }

            if (model.ServiceTel1 != null)
            {
                colList.Append("[ServiceTel1],");
                colParamList.Append("@ServiceTel1,");
                parameter = new SqlParameter("@ServiceTel1", SqlDbType.NVarChar, 30);
                parameter.Value = model.ServiceTel1;
                sqlParamList.Add(parameter);
            }

            if (model.ServiceTel2 != null)
            {
                colList.Append("[ServiceTel2],");
                colParamList.Append("@ServiceTel2,");
                parameter = new SqlParameter("@ServiceTel2", SqlDbType.NVarChar, 30);
                parameter.Value = model.ServiceTel2;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [Config] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));

            return SqlHelper.ExecuteNonQuery(strSql, sqlParamList.ToArray()) > 0;

        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Config] ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
            parameters[0].Value = Id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion


        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Config model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Config] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id  ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Config model, ref SqlParameter[] parameters, bool isUpdate)
        {
            StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (model.Id != Int32.MinValue)
            {
                colList.Append("[Id] = @Id,");
                SqlParameter parameter = new SqlParameter("@Id", SqlDbType.Int, 4);
                parameter.Value = model.Id;
                paramList.Add(parameter);
            }

            if (model.FriendLinkContact != null)
            {
                colList.Append("[FriendLinkContact] = @FriendLinkContact,");
                SqlParameter parameter = new SqlParameter("@FriendLinkContact", SqlDbType.NVarChar, 50);
                parameter.Value = model.FriendLinkContact;
                paramList.Add(parameter);
            }

            if (model.ContactDesc != null)
            {
                colList.Append("[ContactDesc] = @ContactDesc,");
                SqlParameter parameter = new SqlParameter("@ContactDesc", SqlDbType.NText);
                parameter.Value = model.ContactDesc;
                paramList.Add(parameter);
            }

            if (model.Foot != null)
            {
                colList.Append("[Foot] = @Foot,");
                SqlParameter parameter = new SqlParameter("@Foot", SqlDbType.NText);
                parameter.Value = model.Foot;
                paramList.Add(parameter);
            }

            if (model.RegProtocol != null)
            {
                colList.Append("[RegProtocol] = @RegProtocol,");
                SqlParameter parameter = new SqlParameter("@RegProtocol", SqlDbType.NText);
                parameter.Value = model.RegProtocol;
                paramList.Add(parameter);
            }

            if (model.WaterMarkPic != null)
            {
                colList.Append("[WaterMarkPic] = @WaterMarkPic,");
                SqlParameter parameter = new SqlParameter("@WaterMarkPic", SqlDbType.NVarChar, 20);
                parameter.Value = model.WaterMarkPic;
                paramList.Add(parameter);
            }

            if (model.Sms_ID != null)
            {
                colList.Append("[Sms_ID] = @Sms_ID,");
                SqlParameter parameter = new SqlParameter("@Sms_ID", SqlDbType.NVarChar, 20);
                parameter.Value = model.Sms_ID;
                paramList.Add(parameter);
            }

            if (model.Sms_Account != null)
            {
                colList.Append("[Sms_Account] = @Sms_Account,");
                SqlParameter parameter = new SqlParameter("@Sms_Account", SqlDbType.NVarChar, 20);
                parameter.Value = model.Sms_Account;
                paramList.Add(parameter);
            }

            if (model.Sms_Password != null)
            {
                colList.Append("[Sms_Password] = @Sms_Password,");
                SqlParameter parameter = new SqlParameter("@Sms_Password", SqlDbType.NVarChar, 50);
                parameter.Value = model.Sms_Password;
                paramList.Add(parameter);
            }

            if (model.Sms_SendMobile != null)
            {
                colList.Append("[Sms_SendMobile] = @Sms_SendMobile,");
                SqlParameter parameter = new SqlParameter("@Sms_SendMobile", SqlDbType.NVarChar, 50);
                parameter.Value = model.Sms_SendMobile;
                paramList.Add(parameter);
            }

            if (model.SiteName != null)
            {
                colList.Append("[SiteName] = @SiteName,");
                SqlParameter parameter = new SqlParameter("@SiteName", SqlDbType.NVarChar, 50);
                parameter.Value = model.SiteName;
                paramList.Add(parameter);
            }

            if (model.SiteTitle != null)
            {
                colList.Append("[SiteTitle] = @SiteTitle,");
                SqlParameter parameter = new SqlParameter("@SiteTitle", SqlDbType.NVarChar, 100);
                parameter.Value = model.SiteTitle;
                paramList.Add(parameter);
            }

            if (model.SiteKeyword != null)
            {
                colList.Append("[SiteKeyword] = @SiteKeyword,");
                SqlParameter parameter = new SqlParameter("@SiteKeyword", SqlDbType.NVarChar, 200);
                parameter.Value = model.SiteKeyword;
                paramList.Add(parameter);
            }

            if (model.SiteDescription != null)
            {
                colList.Append("[SiteDescription] = @SiteDescription,");
                SqlParameter parameter = new SqlParameter("@SiteDescription", SqlDbType.NVarChar, 200);
                parameter.Value = model.SiteDescription;
                paramList.Add(parameter);
            }

            if (model.Logo != null)
            {
                colList.Append("[Logo] = @Logo,");
                SqlParameter parameter = new SqlParameter("@Logo", SqlDbType.NVarChar, 50);
                parameter.Value = model.Logo;
                paramList.Add(parameter);
            }

            if (model.IsMobileValidate.HasValue)
            {
                colList.Append("[IsMobileValidate] = @IsMobileValidate,");
                SqlParameter parameter = new SqlParameter("@IsMobileValidate", SqlDbType.Bit, 1);
                parameter.Value = model.IsMobileValidate.Value; paramList.Add(parameter);
            }

            if (model.ServiceTel1 != null)
            {
                colList.Append("[ServiceTel1] = @ServiceTel1,");
                SqlParameter parameter = new SqlParameter("@ServiceTel1", SqlDbType.NVarChar, 30);
                parameter.Value = model.ServiceTel1;
                paramList.Add(parameter);
            }

            if (model.ServiceTel2 != null)
            {
                colList.Append("[ServiceTel2] = @ServiceTel2,");
                SqlParameter parameter = new SqlParameter("@ServiceTel2", SqlDbType.NVarChar, 30);
                parameter.Value = model.ServiceTel2;
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
        public static NH.Model.Config GetModel(int Id)
        {
            NH.Model.Config model = new NH.Model.Config();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Config GetModel(NH.Model.Config model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, FriendLinkContact, ContactDesc, Foot, RegProtocol, WaterMarkPic, Sms_ID, Sms_Account, Sms_Password, Sms_SendMobile, SiteName, SiteTitle, SiteKeyword, SiteDescription, Logo, IsMobileValidate, ServiceTel1, ServiceTel2 ");
            strSql.Append(" from [Config] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Config();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            model.FriendLinkContact = row["FriendLinkContact"].ToString();

            model.ContactDesc = row["ContactDesc"].ToString();

            model.Foot = row["Foot"].ToString();

            model.RegProtocol = row["RegProtocol"].ToString();

            model.WaterMarkPic = row["WaterMarkPic"].ToString();

            model.Sms_ID = row["Sms_ID"].ToString();

            model.Sms_Account = row["Sms_Account"].ToString();

            model.Sms_Password = row["Sms_Password"].ToString();

            model.Sms_SendMobile = row["Sms_SendMobile"].ToString();

            model.SiteName = row["SiteName"].ToString();

            model.SiteTitle = row["SiteTitle"].ToString();

            model.SiteKeyword = row["SiteKeyword"].ToString();

            model.SiteDescription = row["SiteDescription"].ToString();

            model.Logo = row["Logo"].ToString();


            if (row["IsMobileValidate"].ToString() != "")
            {
                if ((row["IsMobileValidate"].ToString() == "1") || (row["IsMobileValidate"].ToString().ToLower() == "true"))
                {
                    model.IsMobileValidate = true;
                }
                else
                {
                    model.IsMobileValidate = false;
                }
            }

            model.ServiceTel1 = row["ServiceTel1"].ToString();

            model.ServiceTel2 = row["ServiceTel2"].ToString();

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
            strSql.Append(" FROM [Config] ");
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
            strSql.Append(" FROM [Config] ");
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



