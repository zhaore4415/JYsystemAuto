using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// ERPBuyOrder
    /// </summary>
    public static partial class ERPBuyOrder
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.ERPBuyOrder model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ERPBuyOrder] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.ERPBuyOrder model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.ChuangJianRen != null)
            {
                colList.Append("[ChuangJianRen],");
                colParamList.Append("@ChuangJianRen,");
                parameter = new SqlParameter("@ChuangJianRen", SqlDbType.VarChar, 50);
                parameter.Value = model.ChuangJianRen;
                sqlParamList.Add(parameter);
            }

            if (model.FuZeRen != null)
            {
                colList.Append("[FuZeRen],");
                colParamList.Append("@FuZeRen,");
                parameter = new SqlParameter("@FuZeRen", SqlDbType.VarChar, 50);
                parameter.Value = model.FuZeRen;
                sqlParamList.Add(parameter);
            }

            if (model.FuJianList != null)
            {
                colList.Append("[FuJianList],");
                colParamList.Append("@FuJianList,");
                parameter = new SqlParameter("@FuJianList", SqlDbType.VarChar, 500);
                parameter.Value = model.FuJianList;
                sqlParamList.Add(parameter);
            }

            if (model.NowState != null)
            {
                colList.Append("[NowState],");
                colParamList.Append("@NowState,");
                parameter = new SqlParameter("@NowState", SqlDbType.VarChar, 50);
                parameter.Value = model.NowState;
                sqlParamList.Add(parameter);
            }

            if (model.ShenPiTongGuoRen != null)
            {
                colList.Append("[ShenPiTongGuoRen],");
                colParamList.Append("@ShenPiTongGuoRen,");
                parameter = new SqlParameter("@ShenPiTongGuoRen", SqlDbType.VarChar, 50);
                parameter.Value = model.ShenPiTongGuoRen;
                sqlParamList.Add(parameter);
            }

            if (model.BackInfo != null)
            {
                colList.Append("[BackInfo],");
                colParamList.Append("@BackInfo,");
                parameter = new SqlParameter("@BackInfo", SqlDbType.Text);
                parameter.Value = model.BackInfo;
                sqlParamList.Add(parameter);
            }

            if (model.UserName != null)
            {
                colList.Append("[UserName],");
                colParamList.Append("@UserName,");
                parameter = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                parameter.Value = model.UserName;
                sqlParamList.Add(parameter);
            }

            if (model.TimeStr.HasValue)
            {
                colList.Append("[TimeStr],");
                colParamList.Append("@TimeStr,");
                parameter = new SqlParameter("@TimeStr", SqlDbType.DateTime);
                if (model.TimeStr.Value != DateTime.MinValue)
                    parameter.Value = model.TimeStr.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.U_ID.HasValue)
            {
                colList.Append("[U_ID],");
                colParamList.Append("@U_ID,");
                parameter = new SqlParameter("@U_ID", SqlDbType.Int, 4);
                if (model.U_ID.Value != Int32.MinValue)
                    parameter.Value = model.U_ID.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.OrderName != null)
            {
                colList.Append("[OrderName],");
                colParamList.Append("@OrderName,");
                parameter = new SqlParameter("@OrderName", SqlDbType.VarChar, 50);
                parameter.Value = model.OrderName;
                sqlParamList.Add(parameter);
            }

            if (model.GongYingShangName != null)
            {
                colList.Append("[GongYingShangName],");
                colParamList.Append("@GongYingShangName,");
                parameter = new SqlParameter("@GongYingShangName", SqlDbType.VarChar, 50);
                parameter.Value = model.GongYingShangName;
                sqlParamList.Add(parameter);
            }

            if (model.Serils != null)
            {
                colList.Append("[Serils],");
                colParamList.Append("@Serils,");
                parameter = new SqlParameter("@Serils", SqlDbType.VarChar, 50);
                parameter.Value = model.Serils;
                sqlParamList.Add(parameter);
            }

            if (model.DingDanLeiXing != null)
            {
                colList.Append("[DingDanLeiXing],");
                colParamList.Append("@DingDanLeiXing,");
                parameter = new SqlParameter("@DingDanLeiXing", SqlDbType.VarChar, 50);
                parameter.Value = model.DingDanLeiXing;
                sqlParamList.Add(parameter);
            }

            if (model.DingDanMiaoShu != null)
            {
                colList.Append("[DingDanMiaoShu],");
                colParamList.Append("@DingDanMiaoShu,");
                parameter = new SqlParameter("@DingDanMiaoShu", SqlDbType.VarChar, 5000);
                parameter.Value = model.DingDanMiaoShu;
                sqlParamList.Add(parameter);
            }

            if (model.CreateDate != DateTime.MinValue)
            {
                colList.Append("[CreateDate],");
                colParamList.Append("@CreateDate,");
                parameter = new SqlParameter("@CreateDate", SqlDbType.DateTime);
                parameter.Value = model.CreateDate;
                sqlParamList.Add(parameter);
            }

            if (model.LaiHuoDate != DateTime.MinValue)
            {
                colList.Append("[LaiHuoDate],");
                colParamList.Append("@LaiHuoDate,");
                parameter = new SqlParameter("@LaiHuoDate", SqlDbType.DateTime);
                parameter.Value = model.LaiHuoDate;
                sqlParamList.Add(parameter);
            }

            if (model.TiXingDate != DateTime.MinValue)
            {
                colList.Append("[TiXingDate],");
                colParamList.Append("@TiXingDate,");
                parameter = new SqlParameter("@TiXingDate", SqlDbType.DateTime);
                parameter.Value = model.TiXingDate;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [ERPBuyOrder] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from ERPBuyOrder ");
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
            strSql.Append("delete from [ERPBuyOrder] ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.ERPBuyOrder model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ERPBuyOrder] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where ID=@ID ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.ERPBuyOrder model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.ChuangJianRen != null)
            {
                colList.Append("[ChuangJianRen] = @ChuangJianRen,");
                SqlParameter parameter = new SqlParameter("@ChuangJianRen", SqlDbType.VarChar, 50);
                parameter.Value = model.ChuangJianRen;
                paramList.Add(parameter);
            }

            if (model.FuZeRen != null)
            {
                colList.Append("[FuZeRen] = @FuZeRen,");
                SqlParameter parameter = new SqlParameter("@FuZeRen", SqlDbType.VarChar, 50);
                parameter.Value = model.FuZeRen;
                paramList.Add(parameter);
            }

            if (model.FuJianList != null)
            {
                colList.Append("[FuJianList] = @FuJianList,");
                SqlParameter parameter = new SqlParameter("@FuJianList", SqlDbType.VarChar, 500);
                parameter.Value = model.FuJianList;
                paramList.Add(parameter);
            }

            if (model.NowState != null)
            {
                colList.Append("[NowState] = @NowState,");
                SqlParameter parameter = new SqlParameter("@NowState", SqlDbType.VarChar, 50);
                parameter.Value = model.NowState;
                paramList.Add(parameter);
            }

            if (model.ShenPiTongGuoRen != null)
            {
                colList.Append("[ShenPiTongGuoRen] = @ShenPiTongGuoRen,");
                SqlParameter parameter = new SqlParameter("@ShenPiTongGuoRen", SqlDbType.VarChar, 50);
                parameter.Value = model.ShenPiTongGuoRen;
                paramList.Add(parameter);
            }

            if (model.BackInfo != null)
            {
                colList.Append("[BackInfo] = @BackInfo,");
                SqlParameter parameter = new SqlParameter("@BackInfo", SqlDbType.Text);
                parameter.Value = model.BackInfo;
                paramList.Add(parameter);
            }

            if (model.UserName != null)
            {
                colList.Append("[UserName] = @UserName,");
                SqlParameter parameter = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                parameter.Value = model.UserName;
                paramList.Add(parameter);
            }

            if (model.TimeStr.HasValue)
            {
                colList.Append("[TimeStr] = @TimeStr,");
                SqlParameter parameter = new SqlParameter("@TimeStr", SqlDbType.DateTime);
                parameter.Value = model.TimeStr.Value;
                paramList.Add(parameter);
            }

            if (model.U_ID.HasValue)
            {
                colList.Append("[U_ID] = @U_ID,");
                SqlParameter parameter = new SqlParameter("@U_ID", SqlDbType.Int, 4);
                parameter.Value = model.U_ID.Value;
                paramList.Add(parameter);
            }

            if (model.OrderName != null)
            {
                colList.Append("[OrderName] = @OrderName,");
                SqlParameter parameter = new SqlParameter("@OrderName", SqlDbType.VarChar, 50);
                parameter.Value = model.OrderName;
                paramList.Add(parameter);
            }

            if (model.GongYingShangName != null)
            {
                colList.Append("[GongYingShangName] = @GongYingShangName,");
                SqlParameter parameter = new SqlParameter("@GongYingShangName", SqlDbType.VarChar, 50);
                parameter.Value = model.GongYingShangName;
                paramList.Add(parameter);
            }

            if (model.Serils != null)
            {
                colList.Append("[Serils] = @Serils,");
                SqlParameter parameter = new SqlParameter("@Serils", SqlDbType.VarChar, 50);
                parameter.Value = model.Serils;
                paramList.Add(parameter);
            }

            if (model.DingDanLeiXing != null)
            {
                colList.Append("[DingDanLeiXing] = @DingDanLeiXing,");
                SqlParameter parameter = new SqlParameter("@DingDanLeiXing", SqlDbType.VarChar, 50);
                parameter.Value = model.DingDanLeiXing;
                paramList.Add(parameter);
            }

            if (model.DingDanMiaoShu != null)
            {
                colList.Append("[DingDanMiaoShu] = @DingDanMiaoShu,");
                SqlParameter parameter = new SqlParameter("@DingDanMiaoShu", SqlDbType.VarChar, 5000);
                parameter.Value = model.DingDanMiaoShu;
                paramList.Add(parameter);
            }

            if (model.CreateDate != DateTime.MinValue)
            {
                colList.Append("[CreateDate] = @CreateDate,");
                SqlParameter parameter = new SqlParameter("@CreateDate", SqlDbType.DateTime);
                parameter.Value = model.CreateDate;
                paramList.Add(parameter);
            }

            if (model.LaiHuoDate != DateTime.MinValue)
            {
                colList.Append("[LaiHuoDate] = @LaiHuoDate,");
                SqlParameter parameter = new SqlParameter("@LaiHuoDate", SqlDbType.DateTime);
                parameter.Value = model.LaiHuoDate;
                paramList.Add(parameter);
            }

            if (model.TiXingDate != DateTime.MinValue)
            {
                colList.Append("[TiXingDate] = @TiXingDate,");
                SqlParameter parameter = new SqlParameter("@TiXingDate", SqlDbType.DateTime);
                parameter.Value = model.TiXingDate;
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
        public static NH.Model.ERPBuyOrder GetModel(int ID)
        {
            NH.Model.ERPBuyOrder model = new NH.Model.ERPBuyOrder();
            model.ID = ID;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ERPBuyOrder GetModel(NH.Model.ERPBuyOrder model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID], [ChuangJianRen], [FuZeRen], [FuJianList], [NowState], [ShenPiTongGuoRen], [BackInfo], [UserName], [TimeStr], [U_ID], [OrderName], [GongYingShangName], [Serils], [DingDanLeiXing], [DingDanMiaoShu], [CreateDate], [LaiHuoDate], [TiXingDate] ");
            strSql.Append(" from [ERPBuyOrder] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.ERPBuyOrder();
            DataRow row = dt.Rows[0];

            if (row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }

            model.ChuangJianRen = row["ChuangJianRen"].ToString();

            model.FuZeRen = row["FuZeRen"].ToString();

            model.FuJianList = row["FuJianList"].ToString();

            model.NowState = row["NowState"].ToString();

            model.ShenPiTongGuoRen = row["ShenPiTongGuoRen"].ToString();

            model.BackInfo = row["BackInfo"].ToString();

            model.UserName = row["UserName"].ToString();

            if (row["TimeStr"].ToString() != "")
            {
                model.TimeStr = DateTime.Parse(row["TimeStr"].ToString());
            }

            if (row["U_ID"].ToString() != "")
            {
                model.U_ID = int.Parse(row["U_ID"].ToString());
            }

            model.OrderName = row["OrderName"].ToString();

            model.GongYingShangName = row["GongYingShangName"].ToString();

            model.Serils = row["Serils"].ToString();

            model.DingDanLeiXing = row["DingDanLeiXing"].ToString();

            model.DingDanMiaoShu = row["DingDanMiaoShu"].ToString();

            if (row["CreateDate"].ToString() != "")
            {
                model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
            }

            if (row["LaiHuoDate"].ToString() != "")
            {
                model.LaiHuoDate = DateTime.Parse(row["LaiHuoDate"].ToString());
            }

            if (row["TiXingDate"].ToString() != "")
            {
                model.TiXingDate = DateTime.Parse(row["TiXingDate"].ToString());
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
            strSql.Append(" FROM [ERPBuyOrder] ");
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
            strSql.Append(" FROM [ERPBuyOrder] ");
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



