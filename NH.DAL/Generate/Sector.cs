using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Sector
    /// </summary>
    public static partial class Sector
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Sector model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Sector] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(NH.Model.Sector model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.Depth.HasValue)
            {
                colList.Append("[Depth],");
                colParamList.Append("@Depth,");
                parameter = new SqlParameter("@Depth", SqlDbType.Int, 4);
                if (model.Depth.Value != Int32.MinValue)
                    parameter.Value = model.Depth.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.ParentID.HasValue)
            {
                colList.Append("[ParentID],");
                colParamList.Append("@ParentID,");
                parameter = new SqlParameter("@ParentID", SqlDbType.Int, 4);
                if (model.ParentID.Value != Int32.MinValue)
                    parameter.Value = model.ParentID.Value;
                else
                    parameter.Value = DBNull.Value;

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

            if (model.SectorId.HasValue)
            {
                colList.Append("[SectorId],");
                colParamList.Append("@SectorId,");
                parameter = new SqlParameter("@SectorId", SqlDbType.Int, 4);
                if (model.SectorId.Value != Int32.MinValue)
                    parameter.Value = model.SectorId.Value;
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

            if (model.Sort != Int32.MinValue)
            {
                colList.Append("[Sort],");
                colParamList.Append("@Sort,");
                parameter = new SqlParameter("@Sort", SqlDbType.Int, 4);
                parameter.Value = model.Sort;
                sqlParamList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark],");
                colParamList.Append("@Remark,");
                parameter = new SqlParameter("@Remark", SqlDbType.NVarChar, -1);
                parameter.Value = model.Remark;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [Sector] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
            return SqlHelper.ExecuteNonQuery(strSql, sqlParamList.ToArray()) > 0;
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sector ");
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
            strSql.Append("delete from [Sector] ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Sector model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Sector] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where ID=@ID ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Sector model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.Depth.HasValue)
            {
                colList.Append("[Depth] = @Depth,");
                SqlParameter parameter = new SqlParameter("@Depth", SqlDbType.Int, 4);
                parameter.Value = model.Depth.Value;
                paramList.Add(parameter);
            }

            if (model.ParentID.HasValue)
            {
                colList.Append("[ParentID] = @ParentID,");
                SqlParameter parameter = new SqlParameter("@ParentID", SqlDbType.Int, 4);
                parameter.Value = model.ParentID.Value;
                paramList.Add(parameter);
            }

            if (model.Name != null)
            {
                colList.Append("[Name] = @Name,");
                SqlParameter parameter = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
                parameter.Value = model.Name;
                paramList.Add(parameter);
            }

            if (model.SectorId.HasValue)
            {
                colList.Append("[SectorId] = @SectorId,");
                SqlParameter parameter = new SqlParameter("@SectorId", SqlDbType.Int, 4);
                parameter.Value = model.SectorId.Value;
                paramList.Add(parameter);
            }

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                paramList.Add(parameter);
            }

            if (model.Sort != Int32.MinValue)
            {
                colList.Append("[Sort] = @Sort,");
                SqlParameter parameter = new SqlParameter("@Sort", SqlDbType.Int, 4);
                parameter.Value = model.Sort;
                paramList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark] = @Remark,");
                SqlParameter parameter = new SqlParameter("@Remark", SqlDbType.NVarChar, -1);
                parameter.Value = model.Remark;
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
        public static NH.Model.Sector GetModel(int ID)
        {
            NH.Model.Sector model = new NH.Model.Sector();
            model.ID = ID;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Sector GetModel(NH.Model.Sector model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID], [Depth], [ParentID], [Name], [SectorId], [AddTime], [Sort], [Remark] ");
            strSql.Append(" from [Sector] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Sector();
            DataRow row = dt.Rows[0];

            if (row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }

            if (row["Depth"].ToString() != "")
            {
                model.Depth = int.Parse(row["Depth"].ToString());
            }

            if (row["ParentID"].ToString() != "")
            {
                model.ParentID = int.Parse(row["ParentID"].ToString());
            }

            model.Name = row["Name"].ToString();

            if (row["SectorId"].ToString() != "")
            {
                model.SectorId = int.Parse(row["SectorId"].ToString());
            }

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }

            if (row["Sort"].ToString() != "")
            {
                model.Sort = int.Parse(row["Sort"].ToString());
            }

            model.Remark = row["Remark"].ToString();

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
            strSql.Append(" FROM [Sector] ");
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
            strSql.Append(" FROM [Sector] ");
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



