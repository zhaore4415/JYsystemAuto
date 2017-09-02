using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// FaPiao
    /// </summary>
    public static partial class FaPiao
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.FaPiao model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [FaPiao] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.FaPiao model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.YinYeEr.HasValue)
            {
                colList.Append("[YinYeEr],");
                colParamList.Append("@YinYeEr,");
                parameter = new SqlParameter("@YinYeEr", SqlDbType.Decimal, 9);
                if (model.YinYeEr.Value != decimal.MinValue)
                    parameter.Value = model.YinYeEr.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.ChenJianEr.HasValue)
            {
                colList.Append("[ChenJianEr],");
                colParamList.Append("@ChenJianEr,");
                parameter = new SqlParameter("@ChenJianEr", SqlDbType.Decimal, 9);
                if (model.ChenJianEr.Value != decimal.MinValue)
                    parameter.Value = model.ChenJianEr.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.JYFFuJia.HasValue)
            {
                colList.Append("[JYFFuJia],");
                colParamList.Append("@JYFFuJia,");
                parameter = new SqlParameter("@JYFFuJia", SqlDbType.Decimal, 9);
                if (model.JYFFuJia.Value != decimal.MinValue)
                    parameter.Value = model.JYFFuJia.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.DFJYFFuJia.HasValue)
            {
                colList.Append("[DFJYFFuJia],");
                colParamList.Append("@DFJYFFuJia,");
                parameter = new SqlParameter("@DFJYFFuJia", SqlDbType.Decimal, 9);
                if (model.DFJYFFuJia.Value != decimal.MinValue)
                    parameter.Value = model.DFJYFFuJia.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.QYSuoDeShui.HasValue)
            {
                colList.Append("[QYSuoDeShui],");
                colParamList.Append("@QYSuoDeShui,");
                parameter = new SqlParameter("@QYSuoDeShui", SqlDbType.Decimal, 9);
                if (model.QYSuoDeShui.Value != decimal.MinValue)
                    parameter.Value = model.QYSuoDeShui.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.GRSuoDeShui.HasValue)
            {
                colList.Append("[GRSuoDeShui],");
                colParamList.Append("@GRSuoDeShui,");
                parameter = new SqlParameter("@GRSuoDeShui", SqlDbType.Decimal, 9);
                if (model.GRSuoDeShui.Value != decimal.MinValue)
                    parameter.Value = model.GRSuoDeShui.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.YinHuaShui.HasValue)
            {
                colList.Append("[YinHuaShui],");
                colParamList.Append("@YinHuaShui,");
                parameter = new SqlParameter("@YinHuaShui", SqlDbType.Decimal, 9);
                if (model.YinHuaShui.Value != decimal.MinValue)
                    parameter.Value = model.YinHuaShui.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.QiTa.HasValue)
            {
                colList.Append("[QiTa],");
                colParamList.Append("@QiTa,");
                parameter = new SqlParameter("@QiTa", SqlDbType.Decimal, 9);
                if (model.QiTa.Value != decimal.MinValue)
                    parameter.Value = model.QiTa.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

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

            if (model.ZiHao != null)
            {
                colList.Append("[ZiHao],");
                colParamList.Append("@ZiHao,");
                parameter = new SqlParameter("@ZiHao", SqlDbType.NVarChar, 40);
                parameter.Value = model.ZiHao;
                sqlParamList.Add(parameter);
            }

            if (model.FPAmount.HasValue)
            {
                colList.Append("[FPAmount],");
                colParamList.Append("@FPAmount,");
                parameter = new SqlParameter("@FPAmount", SqlDbType.Decimal, 9);
                if (model.FPAmount.Value != decimal.MinValue)
                    parameter.Value = model.FPAmount.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.SPHao != null)
            {
                colList.Append("[SPHao],");
                colParamList.Append("@SPHao,");
                parameter = new SqlParameter("@SPHao", SqlDbType.NChar, 10);
                parameter.Value = model.SPHao;
                sqlParamList.Add(parameter);
            }

            if (model.FPShuiKuan.HasValue)
            {
                colList.Append("[FPShuiKuan],");
                colParamList.Append("@FPShuiKuan,");
                parameter = new SqlParameter("@FPShuiKuan", SqlDbType.Decimal, 9);
                if (model.FPShuiKuan.Value != decimal.MinValue)
                    parameter.Value = model.FPShuiKuan.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.LSAddress != null)
            {
                colList.Append("[LSAddress],");
                colParamList.Append("@LSAddress,");
                parameter = new SqlParameter("@LSAddress", SqlDbType.NVarChar, 100);
                parameter.Value = model.LSAddress;
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

            if (model.Remark != null)
            {
                colList.Append("[Remark],");
                colParamList.Append("@Remark,");
                parameter = new SqlParameter("@Remark", SqlDbType.NVarChar, 200);
                parameter.Value = model.Remark;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [FaPiao] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from FaPiao ");
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
            strSql.Append("delete from [FaPiao] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.FaPiao model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [FaPiao] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.FaPiao model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.YinYeEr.HasValue)
            {
                colList.Append("[YinYeEr] = @YinYeEr,");
                SqlParameter parameter = new SqlParameter("@YinYeEr", SqlDbType.Decimal, 9);
                parameter.Value = model.YinYeEr.Value;
                paramList.Add(parameter);
            }

            if (model.ChenJianEr.HasValue)
            {
                colList.Append("[ChenJianEr] = @ChenJianEr,");
                SqlParameter parameter = new SqlParameter("@ChenJianEr", SqlDbType.Decimal, 9);
                parameter.Value = model.ChenJianEr.Value;
                paramList.Add(parameter);
            }

            if (model.JYFFuJia.HasValue)
            {
                colList.Append("[JYFFuJia] = @JYFFuJia,");
                SqlParameter parameter = new SqlParameter("@JYFFuJia", SqlDbType.Decimal, 9);
                parameter.Value = model.JYFFuJia.Value;
                paramList.Add(parameter);
            }

            if (model.DFJYFFuJia.HasValue)
            {
                colList.Append("[DFJYFFuJia] = @DFJYFFuJia,");
                SqlParameter parameter = new SqlParameter("@DFJYFFuJia", SqlDbType.Decimal, 9);
                parameter.Value = model.DFJYFFuJia.Value;
                paramList.Add(parameter);
            }

            if (model.QYSuoDeShui.HasValue)
            {
                colList.Append("[QYSuoDeShui] = @QYSuoDeShui,");
                SqlParameter parameter = new SqlParameter("@QYSuoDeShui", SqlDbType.Decimal, 9);
                parameter.Value = model.QYSuoDeShui.Value;
                paramList.Add(parameter);
            }

            if (model.GRSuoDeShui.HasValue)
            {
                colList.Append("[GRSuoDeShui] = @GRSuoDeShui,");
                SqlParameter parameter = new SqlParameter("@GRSuoDeShui", SqlDbType.Decimal, 9);
                parameter.Value = model.GRSuoDeShui.Value;
                paramList.Add(parameter);
            }

            if (model.YinHuaShui.HasValue)
            {
                colList.Append("[YinHuaShui] = @YinHuaShui,");
                SqlParameter parameter = new SqlParameter("@YinHuaShui", SqlDbType.Decimal, 9);
                parameter.Value = model.YinHuaShui.Value;
                paramList.Add(parameter);
            }

            if (model.QiTa.HasValue)
            {
                colList.Append("[QiTa] = @QiTa,");
                SqlParameter parameter = new SqlParameter("@QiTa", SqlDbType.Decimal, 9);
                parameter.Value = model.QiTa.Value;
                paramList.Add(parameter);
            }

            if (model.AddTime.HasValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime.Value;
                paramList.Add(parameter);
            }

            if (model.ZiHao != null)
            {
                colList.Append("[ZiHao] = @ZiHao,");
                SqlParameter parameter = new SqlParameter("@ZiHao", SqlDbType.NVarChar, 40);
                parameter.Value = model.ZiHao;
                paramList.Add(parameter);
            }

            if (model.FPAmount.HasValue)
            {
                colList.Append("[FPAmount] = @FPAmount,");
                SqlParameter parameter = new SqlParameter("@FPAmount", SqlDbType.Decimal, 9);
                parameter.Value = model.FPAmount.Value;
                paramList.Add(parameter);
            }

            if (model.SPHao != null)
            {
                colList.Append("[SPHao] = @SPHao,");
                SqlParameter parameter = new SqlParameter("@SPHao", SqlDbType.NChar, 10);
                parameter.Value = model.SPHao;
                paramList.Add(parameter);
            }

            if (model.FPShuiKuan.HasValue)
            {
                colList.Append("[FPShuiKuan] = @FPShuiKuan,");
                SqlParameter parameter = new SqlParameter("@FPShuiKuan", SqlDbType.Decimal, 9);
                parameter.Value = model.FPShuiKuan.Value;
                paramList.Add(parameter);
            }

            if (model.LSAddress != null)
            {
                colList.Append("[LSAddress] = @LSAddress,");
                SqlParameter parameter = new SqlParameter("@LSAddress", SqlDbType.NVarChar, 100);
                parameter.Value = model.LSAddress;
                paramList.Add(parameter);
            }

            if (model.Fid != Int32.MinValue)
            {
                colList.Append("[Fid] = @Fid,");
                SqlParameter parameter = new SqlParameter("@Fid", SqlDbType.Int, 4);
                parameter.Value = model.Fid;
                paramList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark] = @Remark,");
                SqlParameter parameter = new SqlParameter("@Remark", SqlDbType.NVarChar, 200);
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
        public static NH.Model.FaPiao GetModel(int Id)
        {
            NH.Model.FaPiao model = new NH.Model.FaPiao();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.FaPiao GetModel(NH.Model.FaPiao model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [Id], [YinYeEr], [ChenJianEr], [JYFFuJia], [DFJYFFuJia], [QYSuoDeShui], [GRSuoDeShui], [YinHuaShui], [QiTa], [AddTime], [ZiHao], [FPAmount], [SPHao], [FPShuiKuan], [LSAddress], [Fid], [Remark] ");
            strSql.Append(" from [FaPiao] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.FaPiao();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            if (row["YinYeEr"].ToString() != "")
            {
                model.YinYeEr = decimal.Parse(row["YinYeEr"].ToString());
            }

            if (row["ChenJianEr"].ToString() != "")
            {
                model.ChenJianEr = decimal.Parse(row["ChenJianEr"].ToString());
            }

            if (row["JYFFuJia"].ToString() != "")
            {
                model.JYFFuJia = decimal.Parse(row["JYFFuJia"].ToString());
            }

            if (row["DFJYFFuJia"].ToString() != "")
            {
                model.DFJYFFuJia = decimal.Parse(row["DFJYFFuJia"].ToString());
            }

            if (row["QYSuoDeShui"].ToString() != "")
            {
                model.QYSuoDeShui = decimal.Parse(row["QYSuoDeShui"].ToString());
            }

            if (row["GRSuoDeShui"].ToString() != "")
            {
                model.GRSuoDeShui = decimal.Parse(row["GRSuoDeShui"].ToString());
            }

            if (row["YinHuaShui"].ToString() != "")
            {
                model.YinHuaShui = decimal.Parse(row["YinHuaShui"].ToString());
            }

            if (row["QiTa"].ToString() != "")
            {
                model.QiTa = decimal.Parse(row["QiTa"].ToString());
            }

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }

            model.ZiHao = row["ZiHao"].ToString();

            if (row["FPAmount"].ToString() != "")
            {
                model.FPAmount = decimal.Parse(row["FPAmount"].ToString());
            }

            model.SPHao = row["SPHao"].ToString();

            if (row["FPShuiKuan"].ToString() != "")
            {
                model.FPShuiKuan = decimal.Parse(row["FPShuiKuan"].ToString());
            }

            model.LSAddress = row["LSAddress"].ToString();

            if (row["Fid"].ToString() != "")
            {
                model.Fid = int.Parse(row["Fid"].ToString());
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
            strSql.Append(" FROM [FaPiao] ");
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
            strSql.Append(" FROM [FaPiao] ");
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



