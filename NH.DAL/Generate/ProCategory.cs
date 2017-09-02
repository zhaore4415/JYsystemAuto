using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class ProCategory
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.ProCategory model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ProCategory] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.ProCategory model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.IsShow.HasValue)
            {
                colList.Append("[IsShow],");
                colParamList.Append("@IsShow,");
                parameter = new SqlParameter("@IsShow", SqlDbType.Bit, 1);
                parameter.Value = model.IsShow.Value;
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


            if (model.Name != null)
            {
                colList.Append("[Name],");
                colParamList.Append("@Name,");
                parameter = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                parameter.Value = model.Name;
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

            if (model.Pic != null)
            {
                colList.Append("[Pic],");
                colParamList.Append("@Pic,");
                parameter = new SqlParameter("@Pic", SqlDbType.VarChar, 50);
                parameter.Value = model.Pic;
                sqlParamList.Add(parameter);
            }

            if (model.Child != Int32.MinValue)
            {
                colList.Append("[Child],");
                colParamList.Append("@Child,");
                parameter = new SqlParameter("@Child", SqlDbType.Int, 4);
                if (model.Child != Int32.MinValue)
                    parameter.Value = model.Child;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Sort != Int32.MinValue)
            {
                colList.Append("[Sort],");
                colParamList.Append("@Sort,");
                parameter = new SqlParameter("@Sort", SqlDbType.Int, 4);
                if (model.Sort != Int32.MinValue)
                    parameter.Value = model.Sort;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark],");
                colParamList.Append("@Remark,");
                parameter = new SqlParameter("@Remark", SqlDbType.VarChar, 50);
                parameter.Value = model.Remark;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [ProCategory] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from ProCategory ");
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
            strSql.Append("delete from [ProCategory] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.ProCategory model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ProCategory] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.ProCategory model, ref SqlParameter[] parameters, bool isUpdate)
        {
            StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (model.ID != Int32.MinValue)
            {
                if (!isUpdate) colList.Append("[Id] = @Id,");
                SqlParameter parameter = new SqlParameter("@Id", SqlDbType.Int, 4);
                parameter.Value = model.ID;
                paramList.Add(parameter);
            }

            if (model.IsShow.HasValue)
            {
                colList.Append("[IsShow] = @IsShow,");
                SqlParameter parameter = new SqlParameter("@IsShow", SqlDbType.Bit, 1);
                parameter.Value = model.IsShow.Value;
                paramList.Add(parameter);
            }

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                paramList.Add(parameter);
            }

            if (model.Name != null)
            {
                colList.Append("[Name] = @Name,");
                SqlParameter parameter = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                parameter.Value = model.Name;
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

            if (model.Pic != null)
            {
                colList.Append("[Pic] = @Pic,");
                SqlParameter parameter = new SqlParameter("@Pic", SqlDbType.VarChar, 50);
                parameter.Value = model.Pic;
                paramList.Add(parameter);
            }

            if (model.Child != Int32.MinValue)
            {
                colList.Append("[Child] = @Child,");
                SqlParameter parameter = new SqlParameter("@Child", SqlDbType.Int, 4);
                parameter.Value = model.Child;
                paramList.Add(parameter);
            }

            if (model.Sort!= Int32.MinValue)
            {
                colList.Append("[Sort] = @Sort,");
                SqlParameter parameter = new SqlParameter("@Sort", SqlDbType.Int, 4);
                parameter.Value = model.Sort;
                paramList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark] = @Remark,");
                SqlParameter parameter = new SqlParameter("@Remark", SqlDbType.VarChar, 50);
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
        public static NH.Model.ProCategory GetModel(int Id)
        {
            NH.Model.ProCategory model = new NH.Model.ProCategory();
            model.ID = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ProCategory GetModel(NH.Model.ProCategory model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [Id], [IsShow], [AddTime],   [Name], [Depth], [ParentID], [Path], [Pic], [Child], [Sort], [Remark] ");
            strSql.Append(" from [ProCategory] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.ProCategory();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.ID = int.Parse(row["Id"].ToString());
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

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }
       
            model.Name = row["Name"].ToString();

            if (row["Depth"].ToString() != "")
            {
                model.Depth = int.Parse(row["Depth"].ToString());
            }

            if (row["ParentID"].ToString() != "")
            {
                model.ParentID = int.Parse(row["ParentID"].ToString());
            }

            model.Path = row["Path"].ToString();

            model.Pic = row["Pic"].ToString();

            if (row["Child"].ToString() != "")
            {
                model.Child = int.Parse(row["Child"].ToString());
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
            strSql.Append(" FROM [ProCategory] ");
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
            strSql.Append(" FROM [ProCategory] ");
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



