using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Carfx
    /// </summary>
    public static partial class Carfx
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Carfx model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Carfx] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Carfx model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.Status != null)
            {
                colList.Append("[Status],");
                colParamList.Append("@Status,");
                parameter = new SqlParameter("@Status", SqlDbType.NVarChar, 2);
                parameter.Value = model.Status;
                sqlParamList.Add(parameter);
            }

            if (model.PName != null)
            {
                colList.Append("[PName],");
                colParamList.Append("@PName,");
                parameter = new SqlParameter("@PName", SqlDbType.NVarChar, 20);
                parameter.Value = model.PName;
                sqlParamList.Add(parameter);
            }

            if (model.Num.HasValue)
            {
                colList.Append("[Num],");
                colParamList.Append("@Num,");
                parameter = new SqlParameter("@Num", SqlDbType.Int, 4);
                if (model.Num.Value != Int32.MinValue)
                    parameter.Value = model.Num.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.JiFenPrice.HasValue)
            {
                colList.Append("[JiFenPrice],");
                colParamList.Append("@JiFenPrice,");
                parameter = new SqlParameter("@JiFenPrice", SqlDbType.Int, 4);
                if (model.JiFenPrice.Value != Int32.MinValue)
                    parameter.Value = model.JiFenPrice.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.CategoryID.HasValue)
            {
                colList.Append("[CategoryID],");
                colParamList.Append("@CategoryID,");
                parameter = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
                if (model.CategoryID.Value != Int32.MinValue)
                    parameter.Value = model.CategoryID.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.CategoryPath != null)
            {
                colList.Append("[CategoryPath],");
                colParamList.Append("@CategoryPath,");
                parameter = new SqlParameter("@CategoryPath", SqlDbType.NVarChar, 50);
                parameter.Value = model.CategoryPath;
                sqlParamList.Add(parameter);
            }

            if (model.UId.HasValue)
            {
                colList.Append("[UId],");
                colParamList.Append("@UId,");
                parameter = new SqlParameter("@UId", SqlDbType.Int, 4);
                if (model.UId.Value != Int32.MinValue)
                    parameter.Value = model.UId.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.PId.HasValue)
            {
                colList.Append("[PId],");
                colParamList.Append("@PId,");
                parameter = new SqlParameter("@PId", SqlDbType.Int, 4);
                if (model.PId.Value != Int32.MinValue)
                    parameter.Value = model.PId.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.OrderNumber != null)
            {
                colList.Append("[OrderNumber],");
                colParamList.Append("@OrderNumber,");
                parameter = new SqlParameter("@OrderNumber", SqlDbType.NVarChar, 20);
                parameter.Value = model.OrderNumber;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [Carfx] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from Carfx ");
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
            strSql.Append("delete from [Carfx] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Carfx model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Carfx] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Carfx model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.Status != null)
            {
                colList.Append("[Status] = @Status,");
                SqlParameter parameter = new SqlParameter("@Status", SqlDbType.NVarChar, 2);
                parameter.Value = model.Status;
                paramList.Add(parameter);
            }

            if (model.PName != null)
            {
                colList.Append("[PName] = @PName,");
                SqlParameter parameter = new SqlParameter("@PName", SqlDbType.NVarChar, 20);
                parameter.Value = model.PName;
                paramList.Add(parameter);
            }

            if (model.Num.HasValue)
            {
                colList.Append("[Num] = @Num,");
                SqlParameter parameter = new SqlParameter("@Num", SqlDbType.Int, 4);
                parameter.Value = model.Num.Value;
                paramList.Add(parameter);
            }

            if (model.JiFenPrice.HasValue)
            {
                colList.Append("[JiFenPrice] = @JiFenPrice,");
                SqlParameter parameter = new SqlParameter("@JiFenPrice", SqlDbType.Int, 4);
                parameter.Value = model.JiFenPrice.Value;
                paramList.Add(parameter);
            }

            if (model.CategoryID.HasValue)
            {
                colList.Append("[CategoryID] = @CategoryID,");
                SqlParameter parameter = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
                parameter.Value = model.CategoryID.Value;
                paramList.Add(parameter);
            }

            if (model.CategoryPath != null)
            {
                colList.Append("[CategoryPath] = @CategoryPath,");
                SqlParameter parameter = new SqlParameter("@CategoryPath", SqlDbType.NVarChar, 50);
                parameter.Value = model.CategoryPath;
                paramList.Add(parameter);
            }

            if (model.UId.HasValue)
            {
                colList.Append("[UId] = @UId,");
                SqlParameter parameter = new SqlParameter("@UId", SqlDbType.Int, 4);
                parameter.Value = model.UId.Value;
                paramList.Add(parameter);
            }

            if (model.PId.HasValue)
            {
                colList.Append("[PId] = @PId,");
                SqlParameter parameter = new SqlParameter("@PId", SqlDbType.Int, 4);
                parameter.Value = model.PId.Value;
                paramList.Add(parameter);
            }

            if (model.OrderNumber != null)
            {
                colList.Append("[OrderNumber] = @OrderNumber,");
                SqlParameter parameter = new SqlParameter("@OrderNumber", SqlDbType.NVarChar, 20);
                parameter.Value = model.OrderNumber;
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
        public static NH.Model.Carfx GetModel(int Id)
        {
            NH.Model.Carfx model = new NH.Model.Carfx();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Carfx GetModel(NH.Model.Carfx model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [Id], [Status], [PName], [Num], [JiFenPrice], [CategoryID], [CategoryPath], [UId], [PId], [OrderNumber] ");
            strSql.Append(" from [Carfx] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Carfx();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            model.Status = row["Status"].ToString();

            model.PName = row["PName"].ToString();

            if (row["Num"].ToString() != "")
            {
                model.Num = int.Parse(row["Num"].ToString());
            }

            if (row["JiFenPrice"].ToString() != "")
            {
                model.JiFenPrice = int.Parse(row["JiFenPrice"].ToString());
            }

            if (row["CategoryID"].ToString() != "")
            {
                model.CategoryID = int.Parse(row["CategoryID"].ToString());
            }

            model.CategoryPath = row["CategoryPath"].ToString();

            if (row["UId"].ToString() != "")
            {
                model.UId = int.Parse(row["UId"].ToString());
            }

            if (row["PId"].ToString() != "")
            {
                model.PId = int.Parse(row["PId"].ToString());
            }

            model.OrderNumber = row["OrderNumber"].ToString();

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
            strSql.Append(" FROM [Carfx] ");
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
            strSql.Append(" FROM [Carfx] ");
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



