using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// EmailConfig
    /// </summary>
    public static partial class EmailConfig
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.EmailConfig model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [EmailConfig](nolock)");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.EmailConfig model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.Server != null)
            {
                colList.Append("[Server],");
                colParamList.Append("@Server,");
                parameter = new SqlParameter("@Server", SqlDbType.NVarChar, 30);
                parameter.Value = model.Server;
                sqlParamList.Add(parameter);
            }

            if (model.Account != null)
            {
                colList.Append("[Account],");
                colParamList.Append("@Account,");
                parameter = new SqlParameter("@Account", SqlDbType.NVarChar, 50);
                parameter.Value = model.Account;
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

            if (model.Sender != null)
            {
                colList.Append("[Sender],");
                colParamList.Append("@Sender,");
                parameter = new SqlParameter("@Sender", SqlDbType.NVarChar, 50);
                parameter.Value = model.Sender;
                sqlParamList.Add(parameter);
            }

            if (model.Authentication.HasValue)
            {
                colList.Append("[Authentication],");
                colParamList.Append("@Authentication,");
                parameter = new SqlParameter("@Authentication", SqlDbType.Bit, 1);
                parameter.Value = model.Authentication.Value;
                sqlParamList.Add(parameter);
            }

            if (model.EnableSsl.HasValue)
            {
                colList.Append("[EnableSsl],");
                colParamList.Append("@EnableSsl,");
                parameter = new SqlParameter("@EnableSsl", SqlDbType.Bit, 1);
                parameter.Value = model.EnableSsl.Value;
                sqlParamList.Add(parameter);
            }

            if (model.Port != null)
            {
                colList.Append("[Port],");
                colParamList.Append("@Port,");
                parameter = new SqlParameter("@Port", SqlDbType.NVarChar, 10);
                parameter.Value = model.Port;
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

            string strSql = string.Format("insert into [EmailConfig] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from [EmailConfig] ");
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
            strSql.Append("delete from [EmailConfig] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.EmailConfig model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [EmailConfig] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.EmailConfig model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.Server != null)
            {
                colList.Append("[Server] = @Server,");
                SqlParameter parameter = new SqlParameter("@Server", SqlDbType.NVarChar, 30);
                parameter.Value = model.Server;
                paramList.Add(parameter);
            }

            if (model.Account != null)
            {
                colList.Append("[Account] = @Account,");
                SqlParameter parameter = new SqlParameter("@Account", SqlDbType.NVarChar, 50);
                parameter.Value = model.Account;
                paramList.Add(parameter);
            }

            if (model.Password != null)
            {
                colList.Append("[Password] = @Password,");
                SqlParameter parameter = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
                parameter.Value = model.Password;
                paramList.Add(parameter);
            }

            if (model.Sender != null)
            {
                colList.Append("[Sender] = @Sender,");
                SqlParameter parameter = new SqlParameter("@Sender", SqlDbType.NVarChar, 50);
                parameter.Value = model.Sender;
                paramList.Add(parameter);
            }

            if (model.Authentication.HasValue)
            {
                colList.Append("[Authentication] = @Authentication,");
                SqlParameter parameter = new SqlParameter("@Authentication", SqlDbType.Bit, 1);
                parameter.Value = model.Authentication.Value; paramList.Add(parameter);
            }

            if (model.EnableSsl.HasValue)
            {
                colList.Append("[EnableSsl] = @EnableSsl,");
                SqlParameter parameter = new SqlParameter("@EnableSsl", SqlDbType.Bit, 1);
                parameter.Value = model.EnableSsl.Value; paramList.Add(parameter);
            }

            if (model.Port != null)
            {
                colList.Append("[Port] = @Port,");
                SqlParameter parameter = new SqlParameter("@Port", SqlDbType.NVarChar, 10);
                parameter.Value = model.Port;
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
        public static NH.Model.EmailConfig GetModel(int Id)
        {
            NH.Model.EmailConfig model = new NH.Model.EmailConfig();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.EmailConfig GetModel(NH.Model.EmailConfig model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Server, Account, Password, Sender, Authentication, EnableSsl, Port, IsShow ");
            strSql.Append(" from [EmailConfig] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.EmailConfig();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            model.Server = row["Server"].ToString();

            model.Account = row["Account"].ToString();

            model.Password = row["Password"].ToString();

            model.Sender = row["Sender"].ToString();


            if (row["Authentication"].ToString() != "")
            {
                if ((row["Authentication"].ToString() == "1") || (row["Authentication"].ToString().ToLower() == "true"))
                {
                    model.Authentication = true;
                }
                else
                {
                    model.Authentication = false;
                }
            }


            if (row["EnableSsl"].ToString() != "")
            {
                if ((row["EnableSsl"].ToString() == "1") || (row["EnableSsl"].ToString().ToLower() == "true"))
                {
                    model.EnableSsl = true;
                }
                else
                {
                    model.EnableSsl = false;
                }
            }

            model.Port = row["Port"].ToString();


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
            strSql.Append(" FROM [EmailConfig] ");
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
            strSql.Append(" FROM [EmailConfig] ");
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



