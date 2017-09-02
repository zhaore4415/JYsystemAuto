using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// WaiChuZhen
    /// </summary>
    public static partial class WaiChuZhen
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.WaiChuZhen model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [WaiChuZhen] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.WaiChuZhen model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.OutYQMoney.HasValue)
            {
                colList.Append("[OutYQMoney],");
                colParamList.Append("@OutYQMoney,");
                parameter = new SqlParameter("@OutYQMoney", SqlDbType.Decimal, 9);
                if (model.OutYQMoney.Value != decimal.MinValue)
                    parameter.Value = model.OutYQMoney.Value;
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

            if (model.Haoma != null)
            {
                colList.Append("[Haoma],");
                colParamList.Append("@Haoma,");
                parameter = new SqlParameter("@Haoma", SqlDbType.NVarChar, 50);
                parameter.Value = model.Haoma;
                sqlParamList.Add(parameter);
            }

            if (model.YQhaoma != null)
            {
                colList.Append("[YQhaoma],");
                colParamList.Append("@YQhaoma,");
                parameter = new SqlParameter("@YQhaoma", SqlDbType.NVarChar, 50);
                parameter.Value = model.YQhaoma;
                sqlParamList.Add(parameter);
            }

            if (model.OutMoney.HasValue)
            {
                colList.Append("[OutMoney],");
                colParamList.Append("@OutMoney,");
                parameter = new SqlParameter("@OutMoney", SqlDbType.Decimal, 9);
                if (model.OutMoney.Value != decimal.MinValue)
                    parameter.Value = model.OutMoney.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.OutDate != null)
            {
                colList.Append("[OutDate],");
                colParamList.Append("@OutDate,");
                parameter = new SqlParameter("@OutDate", SqlDbType.NVarChar, 30);
                parameter.Value = model.OutDate;
                sqlParamList.Add(parameter);
            }

            if (model.MaturityDate != null)
            {
                colList.Append("[MaturityDate],");
                colParamList.Append("@MaturityDate,");
                parameter = new SqlParameter("@MaturityDate", SqlDbType.NVarChar, 30);
                parameter.Value = model.MaturityDate;
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

            if (model.OutYQDate != null)
            {
                colList.Append("[OutYQDate],");
                colParamList.Append("@OutYQDate,");
                parameter = new SqlParameter("@OutYQDate", SqlDbType.NVarChar, 30);
                parameter.Value = model.OutYQDate;
                sqlParamList.Add(parameter);
            }

            if (model.MaturityTYDate != null)
            {
                colList.Append("[MaturityTYDate],");
                colParamList.Append("@MaturityTYDate,");
                parameter = new SqlParameter("@MaturityTYDate", SqlDbType.NVarChar, 30);
                parameter.Value = model.MaturityTYDate;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [WaiChuZhen] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from WaiChuZhen ");
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
            strSql.Append("delete from [WaiChuZhen] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.WaiChuZhen model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [WaiChuZhen] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.WaiChuZhen model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.OutYQMoney.HasValue)
            {
                colList.Append("[OutYQMoney] = @OutYQMoney,");
                SqlParameter parameter = new SqlParameter("@OutYQMoney", SqlDbType.Decimal, 9);
                parameter.Value = model.OutYQMoney.Value;
                paramList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark] = @Remark,");
                SqlParameter parameter = new SqlParameter("@Remark", SqlDbType.NVarChar, 200);
                parameter.Value = model.Remark;
                paramList.Add(parameter);
            }

            if (model.Haoma != null)
            {
                colList.Append("[Haoma] = @Haoma,");
                SqlParameter parameter = new SqlParameter("@Haoma", SqlDbType.NVarChar, 50);
                parameter.Value = model.Haoma;
                paramList.Add(parameter);
            }

            if (model.YQhaoma != null)
            {
                colList.Append("[YQhaoma] = @YQhaoma,");
                SqlParameter parameter = new SqlParameter("@YQhaoma", SqlDbType.NVarChar, 50);
                parameter.Value = model.YQhaoma;
                paramList.Add(parameter);
            }

            if (model.OutMoney.HasValue)
            {
                colList.Append("[OutMoney] = @OutMoney,");
                SqlParameter parameter = new SqlParameter("@OutMoney", SqlDbType.Decimal, 9);
                parameter.Value = model.OutMoney.Value;
                paramList.Add(parameter);
            }

            if (model.OutDate != null)
            {
                colList.Append("[OutDate] = @OutDate,");
                SqlParameter parameter = new SqlParameter("@OutDate", SqlDbType.NVarChar, 30);
                parameter.Value = model.OutDate;
                paramList.Add(parameter);
            }

            if (model.MaturityDate != null)
            {
                colList.Append("[MaturityDate] = @MaturityDate,");
                SqlParameter parameter = new SqlParameter("@MaturityDate", SqlDbType.NVarChar, 30);
                parameter.Value = model.MaturityDate;
                paramList.Add(parameter);
            }

            if (model.Fid != Int32.MinValue)
            {
                colList.Append("[Fid] = @Fid,");
                SqlParameter parameter = new SqlParameter("@Fid", SqlDbType.Int, 4);
                parameter.Value = model.Fid;
                paramList.Add(parameter);
            }

            if (model.OutYQDate != null)
            {
                colList.Append("[OutYQDate] = @OutYQDate,");
                SqlParameter parameter = new SqlParameter("@OutYQDate", SqlDbType.NVarChar, 30);
                parameter.Value = model.OutYQDate;
                paramList.Add(parameter);
            }

            if (model.MaturityTYDate != null)
            {
                colList.Append("[MaturityTYDate] = @MaturityTYDate,");
                SqlParameter parameter = new SqlParameter("@MaturityTYDate", SqlDbType.NVarChar, 30);
                parameter.Value = model.MaturityTYDate;
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
        public static NH.Model.WaiChuZhen GetModel(int Id)
        {
            NH.Model.WaiChuZhen model = new NH.Model.WaiChuZhen();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.WaiChuZhen GetModel(NH.Model.WaiChuZhen model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [Id], [OutYQMoney], [Remark], [Haoma], [YQhaoma], [OutMoney], [OutDate], [MaturityDate], [Fid], [OutYQDate], [MaturityTYDate] ");
            strSql.Append(" from [WaiChuZhen] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.WaiChuZhen();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            if (row["OutYQMoney"].ToString() != "")
            {
                model.OutYQMoney = decimal.Parse(row["OutYQMoney"].ToString());
            }

            model.Remark = row["Remark"].ToString();

            model.Haoma = row["Haoma"].ToString();

            model.YQhaoma = row["YQhaoma"].ToString();

            if (row["OutMoney"].ToString() != "")
            {
                model.OutMoney = decimal.Parse(row["OutMoney"].ToString());
            }

            model.OutDate = row["OutDate"].ToString();

            model.MaturityDate = row["MaturityDate"].ToString();

            if (row["Fid"].ToString() != "")
            {
                model.Fid = int.Parse(row["Fid"].ToString());
            }

            model.OutYQDate = row["OutYQDate"].ToString();

            model.MaturityTYDate = row["MaturityTYDate"].ToString();

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
            strSql.Append(" FROM [WaiChuZhen] ");
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
            strSql.Append(" FROM [WaiChuZhen] ");
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



