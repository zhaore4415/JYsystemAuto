using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Engineering
    /// </summary>
    public static partial class Engineering
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Engineering model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Engineering] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Engineering model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.ZhiBaoJin.HasValue)
            {
                colList.Append("[ZhiBaoJin],");
                colParamList.Append("@ZhiBaoJin,");
                parameter = new SqlParameter("@ZhiBaoJin", SqlDbType.Decimal, 9);
                if (model.ZhiBaoJin.Value != decimal.MinValue)
                    parameter.Value = model.ZhiBaoJin.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.GuangLiFei.HasValue)
            {
                colList.Append("[GuangLiFei],");
                colParamList.Append("@GuangLiFei,");
                parameter = new SqlParameter("@GuangLiFei", SqlDbType.Decimal, 9);
                if (model.GuangLiFei.Value != decimal.MinValue)
                    parameter.Value = model.GuangLiFei.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.FuJiaShui.HasValue)
            {
                colList.Append("[FuJiaShui],");
                colParamList.Append("@FuJiaShui,");
                parameter = new SqlParameter("@FuJiaShui", SqlDbType.Decimal, 9);
                if (model.FuJiaShui.Value != decimal.MinValue)
                    parameter.Value = model.FuJiaShui.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.QySuoDeShui.HasValue)
            {
                colList.Append("[QySuoDeShui],");
                colParamList.Append("@QySuoDeShui,");
                parameter = new SqlParameter("@QySuoDeShui", SqlDbType.Decimal, 9);
                if (model.QySuoDeShui.Value != decimal.MinValue)
                    parameter.Value = model.QySuoDeShui.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.GrSuoDeShui.HasValue)
            {
                colList.Append("[GrSuoDeShui],");
                colParamList.Append("@GrSuoDeShui,");
                parameter = new SqlParameter("@GrSuoDeShui", SqlDbType.Decimal, 9);
                if (model.GrSuoDeShui.Value != decimal.MinValue)
                    parameter.Value = model.GrSuoDeShui.Value;
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

            if (model.QTKuan.HasValue)
            {
                colList.Append("[QTKuan],");
                colParamList.Append("@QTKuan,");
                parameter = new SqlParameter("@QTKuan", SqlDbType.Decimal, 9);
                if (model.QTKuan.Value != decimal.MinValue)
                    parameter.Value = model.QTKuan.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.LiXi.HasValue)
            {
                colList.Append("[LiXi],");
                colParamList.Append("@LiXi,");
                parameter = new SqlParameter("@LiXi", SqlDbType.Decimal, 9);
                if (model.LiXi.Value != decimal.MinValue)
                    parameter.Value = model.LiXi.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.HGSKuan.HasValue)
            {
                colList.Append("[HGSKuan],");
                colParamList.Append("@HGSKuan,");
                parameter = new SqlParameter("@HGSKuan", SqlDbType.Decimal, 9);
                if (model.HGSKuan.Value != decimal.MinValue)
                    parameter.Value = model.HGSKuan.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.DDYHCunKuan.HasValue)
            {
                colList.Append("[DDYHCunKuan],");
                colParamList.Append("@DDYHCunKuan,");
                parameter = new SqlParameter("@DDYHCunKuan", SqlDbType.Decimal, 9);
                if (model.DDYHCunKuan.Value != decimal.MinValue)
                    parameter.Value = model.DDYHCunKuan.Value;
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

            if (model.Fid != Int32.MinValue)
            {
                colList.Append("[Fid],");
                colParamList.Append("@Fid,");
                parameter = new SqlParameter("@Fid", SqlDbType.Int, 4);
                parameter.Value = model.Fid;
                sqlParamList.Add(parameter);
            }

            if (model.JiSuan.HasValue)
            {
                colList.Append("[JiSuan],");
                colParamList.Append("@JiSuan,");
                parameter = new SqlParameter("@JiSuan", SqlDbType.Bit, 1);
                parameter.Value = model.JiSuan.Value;
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

            if (model.ImportAmount.HasValue)
            {
                colList.Append("[ImportAmount],");
                colParamList.Append("@ImportAmount,");
                parameter = new SqlParameter("@ImportAmount", SqlDbType.Decimal, 9);
                if (model.ImportAmount.Value != decimal.MinValue)
                    parameter.Value = model.ImportAmount.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.ImportAmountConfirm.HasValue)
            {
                colList.Append("[ImportAmountConfirm],");
                colParamList.Append("@ImportAmountConfirm,");
                parameter = new SqlParameter("@ImportAmountConfirm", SqlDbType.Decimal, 9);
                if (model.ImportAmountConfirm.Value != decimal.MinValue)
                    parameter.Value = model.ImportAmountConfirm.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.ExportAmount.HasValue)
            {
                colList.Append("[ExportAmount],");
                colParamList.Append("@ExportAmount,");
                parameter = new SqlParameter("@ExportAmount", SqlDbType.Decimal, 9);
                if (model.ExportAmount.Value != decimal.MinValue)
                    parameter.Value = model.ExportAmount.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.ExportAmountConfirm.HasValue)
            {
                colList.Append("[ExportAmountConfirm],");
                colParamList.Append("@ExportAmountConfirm,");
                parameter = new SqlParameter("@ExportAmountConfirm", SqlDbType.Decimal, 9);
                if (model.ExportAmountConfirm.Value != decimal.MinValue)
                    parameter.Value = model.ExportAmountConfirm.Value;
                else
                    parameter.Value = DBNull.Value;

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

            if (model.BaoZhenJin.HasValue)
            {
                colList.Append("[BaoZhenJin],");
                colParamList.Append("@BaoZhenJin,");
                parameter = new SqlParameter("@BaoZhenJin", SqlDbType.Decimal, 9);
                if (model.BaoZhenJin.Value != decimal.MinValue)
                    parameter.Value = model.BaoZhenJin.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [Engineering] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from Engineering ");
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
            strSql.Append("delete from [Engineering] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Engineering model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Engineering] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Engineering model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.ZhiBaoJin.HasValue)
            {
                colList.Append("[ZhiBaoJin] = @ZhiBaoJin,");
                SqlParameter parameter = new SqlParameter("@ZhiBaoJin", SqlDbType.Decimal, 9);
                parameter.Value = model.ZhiBaoJin.Value;
                paramList.Add(parameter);
            }

            if (model.GuangLiFei.HasValue)
            {
                colList.Append("[GuangLiFei] = @GuangLiFei,");
                SqlParameter parameter = new SqlParameter("@GuangLiFei", SqlDbType.Decimal, 9);
                parameter.Value = model.GuangLiFei.Value;
                paramList.Add(parameter);
            }

            if (model.FuJiaShui.HasValue)
            {
                colList.Append("[FuJiaShui] = @FuJiaShui,");
                SqlParameter parameter = new SqlParameter("@FuJiaShui", SqlDbType.Decimal, 9);
                parameter.Value = model.FuJiaShui.Value;
                paramList.Add(parameter);
            }

            if (model.QySuoDeShui.HasValue)
            {
                colList.Append("[QySuoDeShui] = @QySuoDeShui,");
                SqlParameter parameter = new SqlParameter("@QySuoDeShui", SqlDbType.Decimal, 9);
                parameter.Value = model.QySuoDeShui.Value;
                paramList.Add(parameter);
            }

            if (model.GrSuoDeShui.HasValue)
            {
                colList.Append("[GrSuoDeShui] = @GrSuoDeShui,");
                SqlParameter parameter = new SqlParameter("@GrSuoDeShui", SqlDbType.Decimal, 9);
                parameter.Value = model.GrSuoDeShui.Value;
                paramList.Add(parameter);
            }

            if (model.YinHuaShui.HasValue)
            {
                colList.Append("[YinHuaShui] = @YinHuaShui,");
                SqlParameter parameter = new SqlParameter("@YinHuaShui", SqlDbType.Decimal, 9);
                parameter.Value = model.YinHuaShui.Value;
                paramList.Add(parameter);
            }

            if (model.QTKuan.HasValue)
            {
                colList.Append("[QTKuan] = @QTKuan,");
                SqlParameter parameter = new SqlParameter("@QTKuan", SqlDbType.Decimal, 9);
                parameter.Value = model.QTKuan.Value;
                paramList.Add(parameter);
            }

            if (model.LiXi.HasValue)
            {
                colList.Append("[LiXi] = @LiXi,");
                SqlParameter parameter = new SqlParameter("@LiXi", SqlDbType.Decimal, 9);
                parameter.Value = model.LiXi.Value;
                paramList.Add(parameter);
            }

            if (model.HGSKuan.HasValue)
            {
                colList.Append("[HGSKuan] = @HGSKuan,");
                SqlParameter parameter = new SqlParameter("@HGSKuan", SqlDbType.Decimal, 9);
                parameter.Value = model.HGSKuan.Value;
                paramList.Add(parameter);
            }

            if (model.DDYHCunKuan.HasValue)
            {
                colList.Append("[DDYHCunKuan] = @DDYHCunKuan,");
                SqlParameter parameter = new SqlParameter("@DDYHCunKuan", SqlDbType.Decimal, 9);
                parameter.Value = model.DDYHCunKuan.Value;
                paramList.Add(parameter);
            }

            if (model.AddTime.HasValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime.Value;
                paramList.Add(parameter);
            }

            if (model.Fid != Int32.MinValue)
            {
                colList.Append("[Fid] = @Fid,");
                SqlParameter parameter = new SqlParameter("@Fid", SqlDbType.Int, 4);
                parameter.Value = model.Fid;
                paramList.Add(parameter);
            }

            if (model.JiSuan.HasValue)
            {
                colList.Append("[JiSuan] = @JiSuan,");
                SqlParameter parameter = new SqlParameter("@JiSuan", SqlDbType.Bit, 1);
                parameter.Value = model.JiSuan.Value;
                paramList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark] = @Remark,");
                SqlParameter parameter = new SqlParameter("@Remark", SqlDbType.NVarChar, 200);
                parameter.Value = model.Remark;
                paramList.Add(parameter);
            }

            if (model.ImportAmount.HasValue)
            {
                colList.Append("[ImportAmount] = @ImportAmount,");
                SqlParameter parameter = new SqlParameter("@ImportAmount", SqlDbType.Decimal, 9);
                parameter.Value = model.ImportAmount.Value;
                paramList.Add(parameter);
            }

            if (model.ImportAmountConfirm.HasValue)
            {
                colList.Append("[ImportAmountConfirm] = @ImportAmountConfirm,");
                SqlParameter parameter = new SqlParameter("@ImportAmountConfirm", SqlDbType.Decimal, 9);
                parameter.Value = model.ImportAmountConfirm.Value;
                paramList.Add(parameter);
            }

            if (model.ExportAmount.HasValue)
            {
                colList.Append("[ExportAmount] = @ExportAmount,");
                SqlParameter parameter = new SqlParameter("@ExportAmount", SqlDbType.Decimal, 9);
                parameter.Value = model.ExportAmount.Value;
                paramList.Add(parameter);
            }

            if (model.ExportAmountConfirm.HasValue)
            {
                colList.Append("[ExportAmountConfirm] = @ExportAmountConfirm,");
                SqlParameter parameter = new SqlParameter("@ExportAmountConfirm", SqlDbType.Decimal, 9);
                parameter.Value = model.ExportAmountConfirm.Value;
                paramList.Add(parameter);
            }

            if (model.Balance.HasValue)
            {
                colList.Append("[Balance] = @Balance,");
                SqlParameter parameter = new SqlParameter("@Balance", SqlDbType.Decimal, 9);
                parameter.Value = model.Balance.Value;
                paramList.Add(parameter);
            }

            if (model.BaoZhenJin.HasValue)
            {
                colList.Append("[BaoZhenJin] = @BaoZhenJin,");
                SqlParameter parameter = new SqlParameter("@BaoZhenJin", SqlDbType.Decimal, 9);
                parameter.Value = model.BaoZhenJin.Value;
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
        public static NH.Model.Engineering GetModel(int Id)
        {
            NH.Model.Engineering model = new NH.Model.Engineering();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Engineering GetModel(NH.Model.Engineering model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [Id], [ZhiBaoJin], [GuangLiFei], [FuJiaShui], [QySuoDeShui], [GrSuoDeShui], [YinHuaShui], [QTKuan], [LiXi], [HGSKuan], [DDYHCunKuan], [AddTime], [Fid], [JiSuan], [Remark], [ImportAmount], [ImportAmountConfirm], [ExportAmount], [ExportAmountConfirm], [Balance], [BaoZhenJin] ");
            strSql.Append(" from [Engineering] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Engineering();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            if (row["ZhiBaoJin"].ToString() != "")
            {
                model.ZhiBaoJin = decimal.Parse(row["ZhiBaoJin"].ToString());
            }

            if (row["GuangLiFei"].ToString() != "")
            {
                model.GuangLiFei = decimal.Parse(row["GuangLiFei"].ToString());
            }

            if (row["FuJiaShui"].ToString() != "")
            {
                model.FuJiaShui = decimal.Parse(row["FuJiaShui"].ToString());
            }

            if (row["QySuoDeShui"].ToString() != "")
            {
                model.QySuoDeShui = decimal.Parse(row["QySuoDeShui"].ToString());
            }

            if (row["GrSuoDeShui"].ToString() != "")
            {
                model.GrSuoDeShui = decimal.Parse(row["GrSuoDeShui"].ToString());
            }

            if (row["YinHuaShui"].ToString() != "")
            {
                model.YinHuaShui = decimal.Parse(row["YinHuaShui"].ToString());
            }

            if (row["QTKuan"].ToString() != "")
            {
                model.QTKuan = decimal.Parse(row["QTKuan"].ToString());
            }

            if (row["LiXi"].ToString() != "")
            {
                model.LiXi = decimal.Parse(row["LiXi"].ToString());
            }

            if (row["HGSKuan"].ToString() != "")
            {
                model.HGSKuan = decimal.Parse(row["HGSKuan"].ToString());
            }

            if (row["DDYHCunKuan"].ToString() != "")
            {
                model.DDYHCunKuan = decimal.Parse(row["DDYHCunKuan"].ToString());
            }

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }

            if (row["Fid"].ToString() != "")
            {
                model.Fid = int.Parse(row["Fid"].ToString());
            }


            if (row["JiSuan"].ToString() != "")
            {
                if ((row["JiSuan"].ToString() == "1") || (row["JiSuan"].ToString().ToLower() == "true"))
                {
                    model.JiSuan = true;
                }
                else
                {
                    model.JiSuan = false;
                }
            }

            model.Remark = row["Remark"].ToString();

            if (row["ImportAmount"].ToString() != "")
            {
                model.ImportAmount = decimal.Parse(row["ImportAmount"].ToString());
            }

            if (row["ImportAmountConfirm"].ToString() != "")
            {
                model.ImportAmountConfirm = decimal.Parse(row["ImportAmountConfirm"].ToString());
            }

            if (row["ExportAmount"].ToString() != "")
            {
                model.ExportAmount = decimal.Parse(row["ExportAmount"].ToString());
            }

            if (row["ExportAmountConfirm"].ToString() != "")
            {
                model.ExportAmountConfirm = decimal.Parse(row["ExportAmountConfirm"].ToString());
            }

            if (row["Balance"].ToString() != "")
            {
                model.Balance = decimal.Parse(row["Balance"].ToString());
            }

            if (row["BaoZhenJin"].ToString() != "")
            {
                model.BaoZhenJin = decimal.Parse(row["BaoZhenJin"].ToString());
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
            strSql.Append(" FROM [Engineering] ");
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
            strSql.Append(" FROM [Engineering] ");
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



