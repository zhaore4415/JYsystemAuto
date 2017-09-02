using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// ProjectManager
    /// </summary>
    public static partial class ProjectManager
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.ProjectManager model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ProjectManager] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.ProjectManager model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.Photo != null)
            {
                colList.Append("[Photo],");
                colParamList.Append("@Photo,");
                parameter = new SqlParameter("@Photo", SqlDbType.NVarChar, 50);
                parameter.Value = model.Photo;
                sqlParamList.Add(parameter);
            }

            if (model.Workingday != null)
            {
                colList.Append("[Workingday],");
                colParamList.Append("@Workingday,");
                parameter = new SqlParameter("@Workingday", SqlDbType.NVarChar, 50);
                parameter.Value = model.Workingday;
                sqlParamList.Add(parameter);
            }

            if (model.Departuredate != null)
            {
                colList.Append("[Departuredate],");
                colParamList.Append("@Departuredate,");
                parameter = new SqlParameter("@Departuredate", SqlDbType.NVarChar, 50);
                parameter.Value = model.Departuredate;
                sqlParamList.Add(parameter);
            }

            if (model.Balance.HasValue)
            {
                colList.Append("[Balance],");
                colParamList.Append("@Balance,");
                parameter = new SqlParameter("@Balance", SqlDbType.Decimal, 9);
                if (model.Balance.Value != decimal.MinValue)
                    parameter.Value = model.Balance.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark],");
                colParamList.Append("@Remark,");
                parameter = new SqlParameter("@Remark", SqlDbType.NVarChar, 200);
                parameter.Value = model.Remark;
                sqlParamList.Add(parameter);
            }

            if (model.Name != null)
            {
                colList.Append("[Name],");
                colParamList.Append("@Name,");
                parameter = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
                parameter.Value = model.Name;
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

            if (model.ShouJi != null)
            {
                colList.Append("[ShouJi],");
                colParamList.Append("@ShouJi,");
                parameter = new SqlParameter("@ShouJi", SqlDbType.NVarChar, 30);
                parameter.Value = model.ShouJi;
                sqlParamList.Add(parameter);
            }

            if (model.Tel != null)
            {
                colList.Append("[Tel],");
                colParamList.Append("@Tel,");
                parameter = new SqlParameter("@Tel", SqlDbType.NVarChar, 30);
                parameter.Value = model.Tel;
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

            if (model.Sex != Int32.MinValue)
            {
                colList.Append("[Sex],");
                colParamList.Append("@Sex,");
                parameter = new SqlParameter("@Sex", SqlDbType.Int, 4);
                parameter.Value = model.Sex;
                sqlParamList.Add(parameter);
            }

            if (model.Fax != null)
            {
                colList.Append("[Fax],");
                colParamList.Append("@Fax,");
                parameter = new SqlParameter("@Fax", SqlDbType.NVarChar, 30);
                parameter.Value = model.Fax;
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

            string strSql = string.Format("insert into [ProjectManager] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from ProjectManager ");
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
            strSql.Append("delete from [ProjectManager] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.ProjectManager model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ProjectManager] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.ProjectManager model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.Photo != null)
            {
                colList.Append("[Photo] = @Photo,");
                SqlParameter parameter = new SqlParameter("@Photo", SqlDbType.NVarChar, 50);
                parameter.Value = model.Photo;
                paramList.Add(parameter);
            }

            if (model.Workingday != null)
            {
                colList.Append("[Workingday] = @Workingday,");
                SqlParameter parameter = new SqlParameter("@Workingday", SqlDbType.NVarChar, 50);
                parameter.Value = model.Workingday;
                paramList.Add(parameter);
            }

            if (model.Departuredate != null)
            {
                colList.Append("[Departuredate] = @Departuredate,");
                SqlParameter parameter = new SqlParameter("@Departuredate", SqlDbType.NVarChar, 50);
                parameter.Value = model.Departuredate;
                paramList.Add(parameter);
            }

            if (model.Balance.HasValue)
            {
                colList.Append("[Balance] = @Balance,");
                SqlParameter parameter = new SqlParameter("@Balance", SqlDbType.Decimal, 9);
                parameter.Value = model.Balance.Value;
                paramList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark] = @Remark,");
                SqlParameter parameter = new SqlParameter("@Remark", SqlDbType.NVarChar, 200);
                parameter.Value = model.Remark;
                paramList.Add(parameter);
            }

            if (model.Name != null)
            {
                colList.Append("[Name] = @Name,");
                SqlParameter parameter = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
                parameter.Value = model.Name;
                paramList.Add(parameter);
            }

            if (model.Email != null)
            {
                colList.Append("[Email] = @Email,");
                SqlParameter parameter = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                parameter.Value = model.Email;
                paramList.Add(parameter);
            }

            if (model.ShouJi != null)
            {
                colList.Append("[ShouJi] = @ShouJi,");
                SqlParameter parameter = new SqlParameter("@ShouJi", SqlDbType.NVarChar, 30);
                parameter.Value = model.ShouJi;
                paramList.Add(parameter);
            }

            if (model.Tel != null)
            {
                colList.Append("[Tel] = @Tel,");
                SqlParameter parameter = new SqlParameter("@Tel", SqlDbType.NVarChar, 30);
                parameter.Value = model.Tel;
                paramList.Add(parameter);
            }

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                paramList.Add(parameter);
            }

            if (model.Sex != Int32.MinValue)
            {
                colList.Append("[Sex] = @Sex,");
                SqlParameter parameter = new SqlParameter("@Sex", SqlDbType.Int, 4);
                parameter.Value = model.Sex;
                paramList.Add(parameter);
            }

            if (model.Fax != null)
            {
                colList.Append("[Fax] = @Fax,");
                SqlParameter parameter = new SqlParameter("@Fax", SqlDbType.NVarChar, 30);
                parameter.Value = model.Fax;
                paramList.Add(parameter);
            }

            if (model.Status != Int32.MinValue)
            {
                colList.Append("[Status] = @Status,");
                SqlParameter parameter = new SqlParameter("@Status", SqlDbType.Int, 4);
                parameter.Value = model.Status;
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
        public static NH.Model.ProjectManager GetModel(int Id)
        {
            NH.Model.ProjectManager model = new NH.Model.ProjectManager();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ProjectManager GetModel(NH.Model.ProjectManager model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [Id], [Photo], [Workingday], [Departuredate], [Balance], [Remark], [Name], [Email], [ShouJi], [Tel], [AddTime], [Sex], [Fax], [Status] ");
            strSql.Append(" from [ProjectManager] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.ProjectManager();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            model.Photo = row["Photo"].ToString();

            model.Workingday = row["Workingday"].ToString();

            model.Departuredate = row["Departuredate"].ToString();

            if (row["Balance"].ToString() != "")
            {
                model.Balance = decimal.Parse(row["Balance"].ToString());
            }

            model.Remark = row["Remark"].ToString();

            model.Name = row["Name"].ToString();

            model.Email = row["Email"].ToString();

            model.ShouJi = row["ShouJi"].ToString();

            model.Tel = row["Tel"].ToString();

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }

            if (row["Sex"].ToString() != "")
            {
                model.Sex = int.Parse(row["Sex"].ToString());
            }

            model.Fax = row["Fax"].ToString();

            if (row["Status"].ToString() != "")
            {
                model.Status = int.Parse(row["Status"].ToString());
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
            strSql.Append(" FROM [ProjectManager] ");
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
            strSql.Append(" FROM [ProjectManager] ");
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



