using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Ad
    /// </summary>
    public static partial class Ad
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Ad model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Ad](nolock)");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Ad model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime],");
                colParamList.Append("@AddTime,");
                parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
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

            if (model.Sort != Int32.MinValue)
            {
                colList.Append("[Sort],");
                colParamList.Append("@Sort,");
                parameter = new SqlParameter("@Sort", SqlDbType.Int, 4);
                parameter.Value = model.Sort;
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

            if (model.CompanyID != Int32.MinValue)
            {
                colList.Append("[CompanyID],");
                colParamList.Append("@CompanyID,");
                parameter = new SqlParameter("@CompanyID", SqlDbType.Int, 4);
                parameter.Value = model.CompanyID;
                sqlParamList.Add(parameter);
            }

            if (model.AreaNo != null)
            {
                colList.Append("[AreaNo],");
                colParamList.Append("@AreaNo,");
                parameter = new SqlParameter("@AreaNo", SqlDbType.NVarChar, 20);
                parameter.Value = model.AreaNo;
                sqlParamList.Add(parameter);
            }

            if (model.Icon != Int32.MinValue)
            {
                colList.Append("[Icon],");
                colParamList.Append("@Icon,");
                parameter = new SqlParameter("@Icon", SqlDbType.Int, 4);
                parameter.Value = model.Icon;
                sqlParamList.Add(parameter);
            }

            if (model.JobId != Int32.MinValue)
            {
                colList.Append("[JobId],");
                colParamList.Append("@JobId,");
                parameter = new SqlParameter("@JobId", SqlDbType.Int, 4);
                parameter.Value = model.JobId;
                sqlParamList.Add(parameter);
            }

            if (model.AdType != Int32.MinValue)
            {
                colList.Append("[AdType],");
                colParamList.Append("@AdType,");
                parameter = new SqlParameter("@AdType", SqlDbType.Int, 4);
                parameter.Value = model.AdType;
                sqlParamList.Add(parameter);
            }

            if (model.Title != null)
            {
                colList.Append("[Title],");
                colParamList.Append("@Title,");
                parameter = new SqlParameter("@Title", SqlDbType.NVarChar, 50);
                parameter.Value = model.Title;
                sqlParamList.Add(parameter);
            }

            if (model.Description != null)
            {
                colList.Append("[Description],");
                colParamList.Append("@Description,");
                parameter = new SqlParameter("@Description", SqlDbType.NVarChar, 200);
                parameter.Value = model.Description;
                sqlParamList.Add(parameter);
            }

            if (model.Pic != null)
            {
                colList.Append("[Pic],");
                colParamList.Append("@Pic,");
                parameter = new SqlParameter("@Pic", SqlDbType.NVarChar, 30);
                parameter.Value = model.Pic;
                sqlParamList.Add(parameter);
            }

            if (model.Url != null)
            {
                colList.Append("[Url],");
                colParamList.Append("@Url,");
                parameter = new SqlParameter("@Url", SqlDbType.NVarChar, 100);
                parameter.Value = model.Url;
                sqlParamList.Add(parameter);
            }

            if (model.StartDate.HasValue)
            {
                colList.Append("[StartDate],");
                colParamList.Append("@StartDate,");
                parameter = new SqlParameter("@StartDate", SqlDbType.DateTime);
                if (model.StartDate.Value != DateTime.MinValue)
                    parameter.Value = model.StartDate.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.EndDate.HasValue)
            {
                colList.Append("[EndDate],");
                colParamList.Append("@EndDate,");
                parameter = new SqlParameter("@EndDate", SqlDbType.DateTime);
                if (model.EndDate.Value != DateTime.MinValue)
                    parameter.Value = model.EndDate.Value;
                else
                    parameter.Value = DBNull.Value;

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

            string strSql = string.Format("insert into [Ad] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from [Ad] ");
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
            strSql.Append("delete from [Ad] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Ad model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Ad] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Ad model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                paramList.Add(parameter);
            }

            if (model.UpdateTime != DateTime.MinValue)
            {
                colList.Append("[UpdateTime] = @UpdateTime,");
                SqlParameter parameter = new SqlParameter("@UpdateTime", SqlDbType.DateTime);
                parameter.Value = model.UpdateTime;
                paramList.Add(parameter);
            }

            if (model.Sort != Int32.MinValue)
            {
                colList.Append("[Sort] = @Sort,");
                SqlParameter parameter = new SqlParameter("@Sort", SqlDbType.Int, 4);
                parameter.Value = model.Sort;
                paramList.Add(parameter);
            }

            if (model.IsShow.HasValue)
            {
                colList.Append("[IsShow] = @IsShow,");
                SqlParameter parameter = new SqlParameter("@IsShow", SqlDbType.Bit, 1);
                parameter.Value = model.IsShow.Value; paramList.Add(parameter);
            }

            if (model.CompanyID != Int32.MinValue)
            {
                colList.Append("[CompanyID] = @CompanyID,");
                SqlParameter parameter = new SqlParameter("@CompanyID", SqlDbType.Int, 4);
                parameter.Value = model.CompanyID;
                paramList.Add(parameter);
            }

            if (model.AreaNo != null)
            {
                colList.Append("[AreaNo] = @AreaNo,");
                SqlParameter parameter = new SqlParameter("@AreaNo", SqlDbType.NVarChar, 20);
                parameter.Value = model.AreaNo;
                paramList.Add(parameter);
            }

            if (model.Icon != Int32.MinValue)
            {
                colList.Append("[Icon] = @Icon,");
                SqlParameter parameter = new SqlParameter("@Icon", SqlDbType.Int, 4);
                parameter.Value = model.Icon;
                paramList.Add(parameter);
            }

            if (model.JobId != Int32.MinValue)
            {
                colList.Append("[JobId] = @JobId,");
                SqlParameter parameter = new SqlParameter("@JobId", SqlDbType.Int, 4);
                parameter.Value = model.JobId;
                paramList.Add(parameter);
            }

            if (model.AdType != Int32.MinValue)
            {
                colList.Append("[AdType] = @AdType,");
                SqlParameter parameter = new SqlParameter("@AdType", SqlDbType.Int, 4);
                parameter.Value = model.AdType;
                paramList.Add(parameter);
            }

            if (model.Title != null)
            {
                colList.Append("[Title] = @Title,");
                SqlParameter parameter = new SqlParameter("@Title", SqlDbType.NVarChar, 50);
                parameter.Value = model.Title;
                paramList.Add(parameter);
            }

            if (model.Description != null)
            {
                colList.Append("[Description] = @Description,");
                SqlParameter parameter = new SqlParameter("@Description", SqlDbType.NVarChar, 200);
                parameter.Value = model.Description;
                paramList.Add(parameter);
            }

            if (model.Pic != null)
            {
                colList.Append("[Pic] = @Pic,");
                SqlParameter parameter = new SqlParameter("@Pic", SqlDbType.NVarChar, 30);
                parameter.Value = model.Pic;
                paramList.Add(parameter);
            }

            if (model.Url != null)
            {
                colList.Append("[Url] = @Url,");
                SqlParameter parameter = new SqlParameter("@Url", SqlDbType.NVarChar, 100);
                parameter.Value = model.Url;
                paramList.Add(parameter);
            }

            if (model.StartDate.HasValue)
            {
                colList.Append("[StartDate] = @StartDate,");
                SqlParameter parameter = new SqlParameter("@StartDate", SqlDbType.DateTime);
                if (model.StartDate.Value != DateTime.MinValue)
                    parameter.Value = model.StartDate.Value;
                else
                    parameter.Value = DBNull.Value;
                paramList.Add(parameter);
            }

            if (model.EndDate.HasValue)
            {
                colList.Append("[EndDate] = @EndDate,");
                SqlParameter parameter = new SqlParameter("@EndDate", SqlDbType.DateTime);
                if (model.EndDate.Value != DateTime.MinValue)
                    parameter.Value = model.EndDate.Value;
                else
                    parameter.Value = DBNull.Value;
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
        public static NH.Model.Ad GetModel(int Id)
        {
            NH.Model.Ad model = new NH.Model.Ad();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Ad GetModel(NH.Model.Ad model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, AddTime, UpdateTime, Sort, IsShow, CompanyID, AreaNo, Icon, JobId, AdType, Title, Description, Pic, Url, StartDate, EndDate, AddUser ");
            strSql.Append(" from [Ad] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Ad();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }

            if (row["UpdateTime"].ToString() != "")
            {
                model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
            }

            if (row["Sort"].ToString() != "")
            {
                model.Sort = int.Parse(row["Sort"].ToString());
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

            if (row["CompanyID"].ToString() != "")
            {
                model.CompanyID = int.Parse(row["CompanyID"].ToString());
            }

            model.AreaNo = row["AreaNo"].ToString();

            if (row["Icon"].ToString() != "")
            {
                model.Icon = int.Parse(row["Icon"].ToString());
            }

            if (row["JobId"].ToString() != "")
            {
                model.JobId = int.Parse(row["JobId"].ToString());
            }

            if (row["AdType"].ToString() != "")
            {
                model.AdType = int.Parse(row["AdType"].ToString());
            }

            model.Title = row["Title"].ToString();

            model.Description = row["Description"].ToString();

            model.Pic = row["Pic"].ToString();

            model.Url = row["Url"].ToString();

            if (row["StartDate"].ToString() != "")
            {
                model.StartDate = DateTime.Parse(row["StartDate"].ToString());
            }

            if (row["EndDate"].ToString() != "")
            {
                model.EndDate = DateTime.Parse(row["EndDate"].ToString());
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
            strSql.Append(" FROM [Ad] ");
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
            strSql.Append(" FROM [Ad] ");
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



