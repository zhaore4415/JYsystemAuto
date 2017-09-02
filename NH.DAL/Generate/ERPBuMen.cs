using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// ERPBuMen
    /// </summary>
    public static partial class ERPBuMen
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.ERPBuMen model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ERPBuMen] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.ERPBuMen model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.BuMenName != null)
            {
                colList.Append("[BuMenName],");
                colParamList.Append("@BuMenName,");
                parameter = new SqlParameter("@BuMenName", SqlDbType.VarChar, 50);
                parameter.Value = model.BuMenName;
                sqlParamList.Add(parameter);
            }

            if (model.ChargeMan != null)
            {
                colList.Append("[ChargeMan],");
                colParamList.Append("@ChargeMan,");
                parameter = new SqlParameter("@ChargeMan", SqlDbType.VarChar, 50);
                parameter.Value = model.ChargeMan;
                sqlParamList.Add(parameter);
            }

            if (model.TelStr != null)
            {
                colList.Append("[TelStr],");
                colParamList.Append("@TelStr,");
                parameter = new SqlParameter("@TelStr", SqlDbType.VarChar, 50);
                parameter.Value = model.TelStr;
                sqlParamList.Add(parameter);
            }

            if (model.ChuanZhen != null)
            {
                colList.Append("[ChuanZhen],");
                colParamList.Append("@ChuanZhen,");
                parameter = new SqlParameter("@ChuanZhen", SqlDbType.VarChar, 50);
                parameter.Value = model.ChuanZhen;
                sqlParamList.Add(parameter);
            }

            if (model.BackInfo != null)
            {
                colList.Append("[BackInfo],");
                colParamList.Append("@BackInfo,");
                parameter = new SqlParameter("@BackInfo", SqlDbType.VarChar, 8000);
                parameter.Value = model.BackInfo;
                sqlParamList.Add(parameter);
            }

            if (model.DirID.HasValue)
            {
                colList.Append("[DirID],");
                colParamList.Append("@DirID,");
                parameter = new SqlParameter("@DirID", SqlDbType.Int, 4);
                if (model.DirID.Value != Int32.MinValue)
                    parameter.Value = model.DirID.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [ERPBuMen] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
        public static bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ERPBuMen ");
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
            strSql.Append("delete from [ERPBuMen] ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.ERPBuMen model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ERPBuMen] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where ID=@ID ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.ERPBuMen model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.BuMenName != null)
            {
                colList.Append("[BuMenName] = @BuMenName,");
                SqlParameter parameter = new SqlParameter("@BuMenName", SqlDbType.VarChar, 50);
                parameter.Value = model.BuMenName;
                paramList.Add(parameter);
            }

            if (model.ChargeMan != null)
            {
                colList.Append("[ChargeMan] = @ChargeMan,");
                SqlParameter parameter = new SqlParameter("@ChargeMan", SqlDbType.VarChar, 50);
                parameter.Value = model.ChargeMan;
                paramList.Add(parameter);
            }

            if (model.TelStr != null)
            {
                colList.Append("[TelStr] = @TelStr,");
                SqlParameter parameter = new SqlParameter("@TelStr", SqlDbType.VarChar, 50);
                parameter.Value = model.TelStr;
                paramList.Add(parameter);
            }

            if (model.ChuanZhen != null)
            {
                colList.Append("[ChuanZhen] = @ChuanZhen,");
                SqlParameter parameter = new SqlParameter("@ChuanZhen", SqlDbType.VarChar, 50);
                parameter.Value = model.ChuanZhen;
                paramList.Add(parameter);
            }

            if (model.BackInfo != null)
            {
                colList.Append("[BackInfo] = @BackInfo,");
                SqlParameter parameter = new SqlParameter("@BackInfo", SqlDbType.VarChar, 8000);
                parameter.Value = model.BackInfo;
                paramList.Add(parameter);
            }

            if (model.DirID.HasValue)
            {
                colList.Append("[DirID] = @DirID,");
                SqlParameter parameter = new SqlParameter("@DirID", SqlDbType.Int, 4);
                parameter.Value = model.DirID.Value;
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
        public static NH.Model.ERPBuMen GetModel(int ID)
        {
            NH.Model.ERPBuMen model = new NH.Model.ERPBuMen();
            model.ID = ID;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ERPBuMen GetModel(NH.Model.ERPBuMen model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID], [BuMenName], [ChargeMan], [TelStr], [ChuanZhen], [BackInfo], [DirID] ");
            strSql.Append(" from [ERPBuMen] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.ERPBuMen();
            DataRow row = dt.Rows[0];

            if (row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }

            model.BuMenName = row["BuMenName"].ToString();

            model.ChargeMan = row["ChargeMan"].ToString();

            model.TelStr = row["TelStr"].ToString();

            model.ChuanZhen = row["ChuanZhen"].ToString();

            model.BackInfo = row["BackInfo"].ToString();

            if (row["DirID"].ToString() != "")
            {
                model.DirID = int.Parse(row["DirID"].ToString());
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
            strSql.Append(" FROM [ERPBuMen] ");
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
            strSql.Append(" FROM [ERPBuMen] ");
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



