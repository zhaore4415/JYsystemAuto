using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// ShouJu
    /// </summary>
    public static partial class ShouJu
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.ShouJu model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ShouJu] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.ShouJu model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.AddTime.HasValue)
            {
                colList.Append("[AddTime],");
                colParamList.Append("@AddTime,");
                parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                if (model.AddTime.Value != DateTime.MinValue)
                    parameter.Value = model.AddTime.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.ShouJuHao != null)
            {
                colList.Append("[ShouJuHao],");
                colParamList.Append("@ShouJuHao,");
                parameter = new SqlParameter("@ShouJuHao", SqlDbType.NVarChar, 50);
                parameter.Value = model.ShouJuHao;
                sqlParamList.Add(parameter);
            }

            if (model.SJAmount.HasValue)
            {
                colList.Append("[SJAmount],");
                colParamList.Append("@SJAmount,");
                parameter = new SqlParameter("@SJAmount", SqlDbType.Decimal, 9);
                if (model.SJAmount.Value != decimal.MinValue)
                    parameter.Value = model.SJAmount.Value;
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

            if (model.Fid != Int32.MinValue)
            {
                colList.Append("[Fid],");
                colParamList.Append("@Fid,");
                parameter = new SqlParameter("@Fid", SqlDbType.Int, 4);
                parameter.Value = model.Fid;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [ShouJu] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from ShouJu ");
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
            strSql.Append("delete from [ShouJu] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.ShouJu model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ShouJu] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.ShouJu model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.AddTime.HasValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime.Value;
                paramList.Add(parameter);
            }

            if (model.ShouJuHao != null)
            {
                colList.Append("[ShouJuHao] = @ShouJuHao,");
                SqlParameter parameter = new SqlParameter("@ShouJuHao", SqlDbType.NVarChar, 50);
                parameter.Value = model.ShouJuHao;
                paramList.Add(parameter);
            }

            if (model.SJAmount.HasValue)
            {
                colList.Append("[SJAmount] = @SJAmount,");
                SqlParameter parameter = new SqlParameter("@SJAmount", SqlDbType.Decimal, 9);
                parameter.Value = model.SJAmount.Value;
                paramList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark] = @Remark,");
                SqlParameter parameter = new SqlParameter("@Remark", SqlDbType.NVarChar, 200);
                parameter.Value = model.Remark;
                paramList.Add(parameter);
            }

            if (model.Fid != Int32.MinValue)
            {
                colList.Append("[Fid] = @Fid,");
                SqlParameter parameter = new SqlParameter("@Fid", SqlDbType.Int, 4);
                parameter.Value = model.Fid;
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
        public static NH.Model.ShouJu GetModel(int Id)
        {
            NH.Model.ShouJu model = new NH.Model.ShouJu();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ShouJu GetModel(NH.Model.ShouJu model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [Id], [AddTime], [ShouJuHao], [SJAmount], [Remark], [Fid] ");
            strSql.Append(" from [ShouJu] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.ShouJu();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }

            model.ShouJuHao = row["ShouJuHao"].ToString();

            if (row["SJAmount"].ToString() != "")
            {
                model.SJAmount = decimal.Parse(row["SJAmount"].ToString());
            }

            model.Remark = row["Remark"].ToString();

            if (row["Fid"].ToString() != "")
            {
                model.Fid = int.Parse(row["Fid"].ToString());
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
            strSql.Append(" FROM [ShouJu] ");
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
            strSql.Append(" FROM [ShouJu] ");
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



