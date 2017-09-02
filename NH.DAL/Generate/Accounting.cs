using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Accounting
    /// </summary>
    public static partial class Accounting
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Accounting model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Accounting] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Accounting model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

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

            if (model.OutNo != null)
            {
                colList.Append("[OutNo],");
                colParamList.Append("@OutNo,");
                parameter = new SqlParameter("@OutNo", SqlDbType.NVarChar, 30);
                parameter.Value = model.OutNo;
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

            if (model.IsIssuing.HasValue)
            {
                colList.Append("[IsIssuing],");
                colParamList.Append("@IsIssuing,");
                parameter = new SqlParameter("@IsIssuing", SqlDbType.Bit, 1);
                parameter.Value = model.IsIssuing.Value;
                sqlParamList.Add(parameter);
            }

            if (model.PartyName != null)
            {
                colList.Append("[PartyName],");
                colParamList.Append("@PartyName,");
                parameter = new SqlParameter("@PartyName", SqlDbType.NVarChar, 60);
                parameter.Value = model.PartyName;
                sqlParamList.Add(parameter);
            }

            if (model.ProjectAddress != null)
            {
                colList.Append("[ProjectAddress],");
                colParamList.Append("@ProjectAddress,");
                parameter = new SqlParameter("@ProjectAddress", SqlDbType.NVarChar, 100);
                parameter.Value = model.ProjectAddress;
                sqlParamList.Add(parameter);
            }

            if (model.Authorize != null)
            {
                colList.Append("[Authorize],");
                colParamList.Append("@Authorize,");
                parameter = new SqlParameter("@Authorize", SqlDbType.NVarChar, 30);
                parameter.Value = model.Authorize;
                sqlParamList.Add(parameter);
            }

            if (model.AuthorizeTel != null)
            {
                colList.Append("[AuthorizeTel],");
                colParamList.Append("@AuthorizeTel,");
                parameter = new SqlParameter("@AuthorizeTel", SqlDbType.NVarChar, 30);
                parameter.Value = model.AuthorizeTel;
                sqlParamList.Add(parameter);
            }

            if (model.AuthorizeDate != null)
            {
                colList.Append("[AuthorizeDate],");
                colParamList.Append("@AuthorizeDate,");
                parameter = new SqlParameter("@AuthorizeDate", SqlDbType.NVarChar, 30);
                parameter.Value = model.AuthorizeDate;
                sqlParamList.Add(parameter);
            }

            if (model.ProjectName != null)
            {
                colList.Append("[ProjectName],");
                colParamList.Append("@ProjectName,");
                parameter = new SqlParameter("@ProjectName", SqlDbType.NVarChar, 60);
                parameter.Value = model.ProjectName;
                sqlParamList.Add(parameter);
            }

            if (model.AuthorizeMaturityDate != null)
            {
                colList.Append("[AuthorizeMaturityDate],");
                colParamList.Append("@AuthorizeMaturityDate,");
                parameter = new SqlParameter("@AuthorizeMaturityDate", SqlDbType.NVarChar, 30);
                parameter.Value = model.AuthorizeMaturityDate;
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

            if (model.Remark2 != null)
            {
                colList.Append("[Remark2],");
                colParamList.Append("@Remark2,");
                parameter = new SqlParameter("@Remark2", SqlDbType.NVarChar, 200);
                parameter.Value = model.Remark2;
                sqlParamList.Add(parameter);
            }

            if (model.Rates1.HasValue)
            {
                colList.Append("[Rates1],");
                colParamList.Append("@Rates1,");
                parameter = new SqlParameter("@Rates1", SqlDbType.Decimal, 5);
                if (model.Rates1.Value != decimal.MinValue)
                    parameter.Value = model.Rates1.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Rates2.HasValue)
            {
                colList.Append("[Rates2],");
                colParamList.Append("@Rates2,");
                parameter = new SqlParameter("@Rates2", SqlDbType.Decimal, 5);
                if (model.Rates2.Value != decimal.MinValue)
                    parameter.Value = model.Rates2.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Rates3.HasValue)
            {
                colList.Append("[Rates3],");
                colParamList.Append("@Rates3,");
                parameter = new SqlParameter("@Rates3", SqlDbType.Decimal, 5);
                if (model.Rates3.Value != decimal.MinValue)
                    parameter.Value = model.Rates3.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Rates4.HasValue)
            {
                colList.Append("[Rates4],");
                colParamList.Append("@Rates4,");
                parameter = new SqlParameter("@Rates4", SqlDbType.Decimal, 5);
                if (model.Rates4.Value != decimal.MinValue)
                    parameter.Value = model.Rates4.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Rates5.HasValue)
            {
                colList.Append("[Rates5],");
                colParamList.Append("@Rates5,");
                parameter = new SqlParameter("@Rates5", SqlDbType.Decimal, 5);
                if (model.Rates5.Value != decimal.MinValue)
                    parameter.Value = model.Rates5.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Rates6.HasValue)
            {
                colList.Append("[Rates6],");
                colParamList.Append("@Rates6,");
                parameter = new SqlParameter("@Rates6", SqlDbType.Decimal, 5);
                if (model.Rates6.Value != decimal.MinValue)
                    parameter.Value = model.Rates6.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Rates7.HasValue)
            {
                colList.Append("[Rates7],");
                colParamList.Append("@Rates7,");
                parameter = new SqlParameter("@Rates7", SqlDbType.Decimal, 5);
                if (model.Rates7.Value != decimal.MinValue)
                    parameter.Value = model.Rates7.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.ProjectNumber != null)
            {
                colList.Append("[ProjectNumber],");
                colParamList.Append("@ProjectNumber,");
                parameter = new SqlParameter("@ProjectNumber", SqlDbType.NVarChar, 30);
                parameter.Value = model.ProjectNumber;
                sqlParamList.Add(parameter);
            }

            if (model.Rates8.HasValue)
            {
                colList.Append("[Rates8],");
                colParamList.Append("@Rates8,");
                parameter = new SqlParameter("@Rates8", SqlDbType.Decimal, 5);
                if (model.Rates8.Value != decimal.MinValue)
                    parameter.Value = model.Rates8.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.BalanceManager.HasValue)
            {
                colList.Append("[BalanceManager],");
                colParamList.Append("@BalanceManager,");
                parameter = new SqlParameter("@BalanceManager", SqlDbType.Decimal, 9);
                if (model.BalanceManager.Value != decimal.MinValue)
                    parameter.Value = model.BalanceManager.Value;
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

            if (model.ClearingMoney.HasValue)
            {
                colList.Append("[ClearingMoney],");
                colParamList.Append("@ClearingMoney,");
                parameter = new SqlParameter("@ClearingMoney", SqlDbType.Decimal, 9);
                if (model.ClearingMoney.Value != decimal.MinValue)
                    parameter.Value = model.ClearingMoney.Value;
                else
                    parameter.Value = DBNull.Value;

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

            if (model.ProjectManager != null)
            {
                colList.Append("[ProjectManager],");
                colParamList.Append("@ProjectManager,");
                parameter = new SqlParameter("@ProjectManager", SqlDbType.NVarChar, 30);
                parameter.Value = model.ProjectManager;
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

            if (model.Tel != null)
            {
                colList.Append("[Tel],");
                colParamList.Append("@Tel,");
                parameter = new SqlParameter("@Tel", SqlDbType.NVarChar, 30);
                parameter.Value = model.Tel;
                sqlParamList.Add(parameter);
            }

            if (model.Type.HasValue)
            {
                colList.Append("[Type],");
                colParamList.Append("@Type,");
                parameter = new SqlParameter("@Type", SqlDbType.Int, 4);
                if (model.Type.Value != Int32.MinValue)
                    parameter.Value = model.Type.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.BankName != null)
            {
                colList.Append("[BankName],");
                colParamList.Append("@BankName,");
                parameter = new SqlParameter("@BankName", SqlDbType.NVarChar, 50);
                parameter.Value = model.BankName;
                sqlParamList.Add(parameter);
            }

            if (model.Account != null)
            {
                colList.Append("[Account],");
                colParamList.Append("@Account,");
                parameter = new SqlParameter("@Account", SqlDbType.NVarChar, 50);
                parameter.Value = model.Account;
                sqlParamList.Add(parameter);
            }

            if (model.fk_id.HasValue)
            {
                colList.Append("[fk_id],");
                colParamList.Append("@fk_id,");
                parameter = new SqlParameter("@fk_id", SqlDbType.Int, 4);
                if (model.fk_id.Value != Int32.MinValue)
                    parameter.Value = model.fk_id.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.sk_id.HasValue)
            {
                colList.Append("[sk_id],");
                colParamList.Append("@sk_id,");
                parameter = new SqlParameter("@sk_id", SqlDbType.Int, 4);
                if (model.sk_id.Value != Int32.MinValue)
                    parameter.Value = model.sk_id.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.tk_id.HasValue)
            {
                colList.Append("[tk_id],");
                colParamList.Append("@tk_id,");
                parameter = new SqlParameter("@tk_id", SqlDbType.Int, 4);
                if (model.tk_id.Value != Int32.MinValue)
                    parameter.Value = model.tk_id.Value;
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

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime],");
                colParamList.Append("@AddTime,");
                parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                sqlParamList.Add(parameter);
            }

            if (model.IfCompleted.HasValue)
            {
                colList.Append("[IfCompleted],");
                colParamList.Append("@IfCompleted,");
                parameter = new SqlParameter("@IfCompleted", SqlDbType.Bit, 1);
                parameter.Value = model.IfCompleted.Value;
                sqlParamList.Add(parameter);
            }

            if (model.ProjectCategory != null)
            {
                colList.Append("[ProjectCategory],");
                colParamList.Append("@ProjectCategory,");
                parameter = new SqlParameter("@ProjectCategory", SqlDbType.NVarChar, 30);
                parameter.Value = model.ProjectCategory;
                sqlParamList.Add(parameter);
            }

            if (model.SigningDate != null)
            {
                colList.Append("[SigningDate],");
                colParamList.Append("@SigningDate,");
                parameter = new SqlParameter("@SigningDate", SqlDbType.NVarChar, 30);
                parameter.Value = model.SigningDate;
                sqlParamList.Add(parameter);
            }

            if (model.ContractAmount.HasValue)
            {
                colList.Append("[ContractAmount],");
                colParamList.Append("@ContractAmount,");
                parameter = new SqlParameter("@ContractAmount", SqlDbType.Decimal, 9);
                if (model.ContractAmount.Value != decimal.MinValue)
                    parameter.Value = model.ContractAmount.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [Accounting] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from Accounting ");
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
            strSql.Append("delete from [Accounting] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Accounting model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Accounting] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Accounting model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.OutNo != null)
            {
                colList.Append("[OutNo] = @OutNo,");
                SqlParameter parameter = new SqlParameter("@OutNo", SqlDbType.NVarChar, 30);
                parameter.Value = model.OutNo;
                paramList.Add(parameter);
            }

            if (model.OutMoney.HasValue)
            {
                colList.Append("[OutMoney] = @OutMoney,");
                SqlParameter parameter = new SqlParameter("@OutMoney", SqlDbType.Decimal, 9);
                parameter.Value = model.OutMoney.Value;
                paramList.Add(parameter);
            }

            if (model.IsIssuing.HasValue)
            {
                colList.Append("[IsIssuing] = @IsIssuing,");
                SqlParameter parameter = new SqlParameter("@IsIssuing", SqlDbType.Bit, 1);
                parameter.Value = model.IsIssuing.Value;
                paramList.Add(parameter);
            }

            if (model.PartyName != null)
            {
                colList.Append("[PartyName] = @PartyName,");
                SqlParameter parameter = new SqlParameter("@PartyName", SqlDbType.NVarChar, 60);
                parameter.Value = model.PartyName;
                paramList.Add(parameter);
            }

            if (model.ProjectAddress != null)
            {
                colList.Append("[ProjectAddress] = @ProjectAddress,");
                SqlParameter parameter = new SqlParameter("@ProjectAddress", SqlDbType.NVarChar, 100);
                parameter.Value = model.ProjectAddress;
                paramList.Add(parameter);
            }

            if (model.Authorize != null)
            {
                colList.Append("[Authorize] = @Authorize,");
                SqlParameter parameter = new SqlParameter("@Authorize", SqlDbType.NVarChar, 30);
                parameter.Value = model.Authorize;
                paramList.Add(parameter);
            }

            if (model.AuthorizeTel != null)
            {
                colList.Append("[AuthorizeTel] = @AuthorizeTel,");
                SqlParameter parameter = new SqlParameter("@AuthorizeTel", SqlDbType.NVarChar, 30);
                parameter.Value = model.AuthorizeTel;
                paramList.Add(parameter);
            }

            if (model.AuthorizeDate != null)
            {
                colList.Append("[AuthorizeDate] = @AuthorizeDate,");
                SqlParameter parameter = new SqlParameter("@AuthorizeDate", SqlDbType.NVarChar, 30);
                parameter.Value = model.AuthorizeDate;
                paramList.Add(parameter);
            }

            if (model.ProjectName != null)
            {
                colList.Append("[ProjectName] = @ProjectName,");
                SqlParameter parameter = new SqlParameter("@ProjectName", SqlDbType.NVarChar, 60);
                parameter.Value = model.ProjectName;
                paramList.Add(parameter);
            }

            if (model.AuthorizeMaturityDate != null)
            {
                colList.Append("[AuthorizeMaturityDate] = @AuthorizeMaturityDate,");
                SqlParameter parameter = new SqlParameter("@AuthorizeMaturityDate", SqlDbType.NVarChar, 30);
                parameter.Value = model.AuthorizeMaturityDate;
                paramList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark] = @Remark,");
                SqlParameter parameter = new SqlParameter("@Remark", SqlDbType.NVarChar, 200);
                parameter.Value = model.Remark;
                paramList.Add(parameter);
            }

            if (model.Remark2 != null)
            {
                colList.Append("[Remark2] = @Remark2,");
                SqlParameter parameter = new SqlParameter("@Remark2", SqlDbType.NVarChar, 200);
                parameter.Value = model.Remark2;
                paramList.Add(parameter);
            }

            if (model.Rates1.HasValue)
            {
                colList.Append("[Rates1] = @Rates1,");
                SqlParameter parameter = new SqlParameter("@Rates1", SqlDbType.Decimal, 5);
                parameter.Value = model.Rates1.Value;
                paramList.Add(parameter);
            }

            if (model.Rates2.HasValue)
            {
                colList.Append("[Rates2] = @Rates2,");
                SqlParameter parameter = new SqlParameter("@Rates2", SqlDbType.Decimal, 5);
                parameter.Value = model.Rates2.Value;
                paramList.Add(parameter);
            }

            if (model.Rates3.HasValue)
            {
                colList.Append("[Rates3] = @Rates3,");
                SqlParameter parameter = new SqlParameter("@Rates3", SqlDbType.Decimal, 5);
                parameter.Value = model.Rates3.Value;
                paramList.Add(parameter);
            }

            if (model.Rates4.HasValue)
            {
                colList.Append("[Rates4] = @Rates4,");
                SqlParameter parameter = new SqlParameter("@Rates4", SqlDbType.Decimal, 5);
                parameter.Value = model.Rates4.Value;
                paramList.Add(parameter);
            }

            if (model.Rates5.HasValue)
            {
                colList.Append("[Rates5] = @Rates5,");
                SqlParameter parameter = new SqlParameter("@Rates5", SqlDbType.Decimal, 5);
                parameter.Value = model.Rates5.Value;
                paramList.Add(parameter);
            }

            if (model.Rates6.HasValue)
            {
                colList.Append("[Rates6] = @Rates6,");
                SqlParameter parameter = new SqlParameter("@Rates6", SqlDbType.Decimal, 5);
                parameter.Value = model.Rates6.Value;
                paramList.Add(parameter);
            }

            if (model.Rates7.HasValue)
            {
                colList.Append("[Rates7] = @Rates7,");
                SqlParameter parameter = new SqlParameter("@Rates7", SqlDbType.Decimal, 5);
                parameter.Value = model.Rates7.Value;
                paramList.Add(parameter);
            }

            if (model.ProjectNumber != null)
            {
                colList.Append("[ProjectNumber] = @ProjectNumber,");
                SqlParameter parameter = new SqlParameter("@ProjectNumber", SqlDbType.NVarChar, 30);
                parameter.Value = model.ProjectNumber;
                paramList.Add(parameter);
            }

            if (model.Rates8.HasValue)
            {
                colList.Append("[Rates8] = @Rates8,");
                SqlParameter parameter = new SqlParameter("@Rates8", SqlDbType.Decimal, 5);
                parameter.Value = model.Rates8.Value;
                paramList.Add(parameter);
            }

            if (model.BalanceManager.HasValue)
            {
                colList.Append("[BalanceManager] = @BalanceManager,");
                SqlParameter parameter = new SqlParameter("@BalanceManager", SqlDbType.Decimal, 9);
                parameter.Value = model.BalanceManager.Value;
                paramList.Add(parameter);
            }

            if (model.Balance.HasValue)
            {
                colList.Append("[Balance] = @Balance,");
                SqlParameter parameter = new SqlParameter("@Balance", SqlDbType.Decimal, 9);
                parameter.Value = model.Balance.Value;
                paramList.Add(parameter);
            }

            if (model.ClearingMoney.HasValue)
            {
                colList.Append("[ClearingMoney] = @ClearingMoney,");
                SqlParameter parameter = new SqlParameter("@ClearingMoney", SqlDbType.Decimal, 9);
                parameter.Value = model.ClearingMoney.Value;
                paramList.Add(parameter);
            }

            if (model.ImportAmount.HasValue)
            {
                colList.Append("[ImportAmount] = @ImportAmount,");
                SqlParameter parameter = new SqlParameter("@ImportAmount", SqlDbType.Decimal, 9);
                parameter.Value = model.ImportAmount.Value;
                paramList.Add(parameter);
            }

            if (model.ExportAmount.HasValue)
            {
                colList.Append("[ExportAmount] = @ExportAmount,");
                SqlParameter parameter = new SqlParameter("@ExportAmount", SqlDbType.Decimal, 9);
                parameter.Value = model.ExportAmount.Value;
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

            if (model.YinHuaShui.HasValue)
            {
                colList.Append("[YinHuaShui] = @YinHuaShui,");
                SqlParameter parameter = new SqlParameter("@YinHuaShui", SqlDbType.Decimal, 9);
                parameter.Value = model.YinHuaShui.Value;
                paramList.Add(parameter);
            }

            if (model.GrSuoDeShui.HasValue)
            {
                colList.Append("[GrSuoDeShui] = @GrSuoDeShui,");
                SqlParameter parameter = new SqlParameter("@GrSuoDeShui", SqlDbType.Decimal, 9);
                parameter.Value = model.GrSuoDeShui.Value;
                paramList.Add(parameter);
            }

            if (model.ProjectManager != null)
            {
                colList.Append("[ProjectManager] = @ProjectManager,");
                SqlParameter parameter = new SqlParameter("@ProjectManager", SqlDbType.NVarChar, 30);
                parameter.Value = model.ProjectManager;
                paramList.Add(parameter);
            }

            if (model.BaoZhenJin.HasValue)
            {
                colList.Append("[BaoZhenJin] = @BaoZhenJin,");
                SqlParameter parameter = new SqlParameter("@BaoZhenJin", SqlDbType.Decimal, 9);
                parameter.Value = model.BaoZhenJin.Value;
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

            if (model.LiXi.HasValue)
            {
                colList.Append("[LiXi] = @LiXi,");
                SqlParameter parameter = new SqlParameter("@LiXi", SqlDbType.Decimal, 9);
                parameter.Value = model.LiXi.Value;
                paramList.Add(parameter);
            }

            if (model.QTKuan.HasValue)
            {
                colList.Append("[QTKuan] = @QTKuan,");
                SqlParameter parameter = new SqlParameter("@QTKuan", SqlDbType.Decimal, 9);
                parameter.Value = model.QTKuan.Value;
                paramList.Add(parameter);
            }

            if (model.FPAmount.HasValue)
            {
                colList.Append("[FPAmount] = @FPAmount,");
                SqlParameter parameter = new SqlParameter("@FPAmount", SqlDbType.Decimal, 9);
                parameter.Value = model.FPAmount.Value;
                paramList.Add(parameter);
            }

            if (model.FPShuiKuan.HasValue)
            {
                colList.Append("[FPShuiKuan] = @FPShuiKuan,");
                SqlParameter parameter = new SqlParameter("@FPShuiKuan", SqlDbType.Decimal, 9);
                parameter.Value = model.FPShuiKuan.Value;
                paramList.Add(parameter);
            }

            if (model.SJAmount.HasValue)
            {
                colList.Append("[SJAmount] = @SJAmount,");
                SqlParameter parameter = new SqlParameter("@SJAmount", SqlDbType.Decimal, 9);
                parameter.Value = model.SJAmount.Value;
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

            if (model.Tel != null)
            {
                colList.Append("[Tel] = @Tel,");
                SqlParameter parameter = new SqlParameter("@Tel", SqlDbType.NVarChar, 30);
                parameter.Value = model.Tel;
                paramList.Add(parameter);
            }

            if (model.Type.HasValue)
            {
                colList.Append("[Type] = @Type,");
                SqlParameter parameter = new SqlParameter("@Type", SqlDbType.Int, 4);
                parameter.Value = model.Type.Value;
                paramList.Add(parameter);
            }

            if (model.BankName != null)
            {
                colList.Append("[BankName] = @BankName,");
                SqlParameter parameter = new SqlParameter("@BankName", SqlDbType.NVarChar, 50);
                parameter.Value = model.BankName;
                paramList.Add(parameter);
            }

            if (model.Account != null)
            {
                colList.Append("[Account] = @Account,");
                SqlParameter parameter = new SqlParameter("@Account", SqlDbType.NVarChar, 50);
                parameter.Value = model.Account;
                paramList.Add(parameter);
            }

            if (model.fk_id.HasValue)
            {
                colList.Append("[fk_id] = @fk_id,");
                SqlParameter parameter = new SqlParameter("@fk_id", SqlDbType.Int, 4);
                parameter.Value = model.fk_id.Value;
                paramList.Add(parameter);
            }

            if (model.sk_id.HasValue)
            {
                colList.Append("[sk_id] = @sk_id,");
                SqlParameter parameter = new SqlParameter("@sk_id", SqlDbType.Int, 4);
                parameter.Value = model.sk_id.Value;
                paramList.Add(parameter);
            }

            if (model.tk_id.HasValue)
            {
                colList.Append("[tk_id] = @tk_id,");
                SqlParameter parameter = new SqlParameter("@tk_id", SqlDbType.Int, 4);
                parameter.Value = model.tk_id.Value;
                paramList.Add(parameter);
            }

            if (model.Fid != Int32.MinValue)
            {
                colList.Append("[Fid] = @Fid,");
                SqlParameter parameter = new SqlParameter("@Fid", SqlDbType.Int, 4);
                parameter.Value = model.Fid;
                paramList.Add(parameter);
            }

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                paramList.Add(parameter);
            }

            if (model.IfCompleted.HasValue)
            {
                colList.Append("[IfCompleted] = @IfCompleted,");
                SqlParameter parameter = new SqlParameter("@IfCompleted", SqlDbType.Bit, 1);
                parameter.Value = model.IfCompleted.Value;
                paramList.Add(parameter);
            }

            if (model.ProjectCategory != null)
            {
                colList.Append("[ProjectCategory] = @ProjectCategory,");
                SqlParameter parameter = new SqlParameter("@ProjectCategory", SqlDbType.NVarChar, 30);
                parameter.Value = model.ProjectCategory;
                paramList.Add(parameter);
            }

            if (model.SigningDate != null)
            {
                colList.Append("[SigningDate] = @SigningDate,");
                SqlParameter parameter = new SqlParameter("@SigningDate", SqlDbType.NVarChar, 30);
                parameter.Value = model.SigningDate;
                paramList.Add(parameter);
            }

            if (model.ContractAmount.HasValue)
            {
                colList.Append("[ContractAmount] = @ContractAmount,");
                SqlParameter parameter = new SqlParameter("@ContractAmount", SqlDbType.Decimal, 9);
                parameter.Value = model.ContractAmount.Value;
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
        public static NH.Model.Accounting GetModel(int Id)
        {
            NH.Model.Accounting model = new NH.Model.Accounting();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Accounting GetModel(NH.Model.Accounting model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [Id], [OutDate], [MaturityDate], [OutNo], [OutMoney], [IsIssuing], [PartyName], [ProjectAddress], [Authorize], [AuthorizeTel], [AuthorizeDate], [ProjectName], [AuthorizeMaturityDate], [Remark], [Remark2], [Rates1], [Rates2], [Rates3], [Rates4], [Rates5], [Rates6], [Rates7], [ProjectNumber], [Rates8], [BalanceManager], [Balance], [ClearingMoney], [ImportAmount], [ExportAmount], [FuJiaShui], [QySuoDeShui], [YinHuaShui], [GrSuoDeShui], [ProjectManager], [BaoZhenJin], [ZhiBaoJin], [GuangLiFei], [LiXi], [QTKuan], [FPAmount], [FPShuiKuan], [SJAmount], [HGSKuan], [DDYHCunKuan], [Tel], [Type], [BankName], [Account], [fk_id], [sk_id], [tk_id], [Fid], [AddTime], [IfCompleted], [ProjectCategory], [SigningDate], [ContractAmount] ");
            strSql.Append(" from [Accounting] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Accounting();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            model.OutDate = row["OutDate"].ToString();

            model.MaturityDate = row["MaturityDate"].ToString();

            model.OutNo = row["OutNo"].ToString();

            if (row["OutMoney"].ToString() != "")
            {
                model.OutMoney = decimal.Parse(row["OutMoney"].ToString());
            }


            if (row["IsIssuing"].ToString() != "")
            {
                if ((row["IsIssuing"].ToString() == "1") || (row["IsIssuing"].ToString().ToLower() == "true"))
                {
                    model.IsIssuing = true;
                }
                else
                {
                    model.IsIssuing = false;
                }
            }

            model.PartyName = row["PartyName"].ToString();

            model.ProjectAddress = row["ProjectAddress"].ToString();

            model.Authorize = row["Authorize"].ToString();

            model.AuthorizeTel = row["AuthorizeTel"].ToString();

            model.AuthorizeDate = row["AuthorizeDate"].ToString();

            model.ProjectName = row["ProjectName"].ToString();

            model.AuthorizeMaturityDate = row["AuthorizeMaturityDate"].ToString();

            model.Remark = row["Remark"].ToString();

            model.Remark2 = row["Remark2"].ToString();

            if (row["Rates1"].ToString() != "")
            {
                model.Rates1 = decimal.Parse(row["Rates1"].ToString());
            }

            if (row["Rates2"].ToString() != "")
            {
                model.Rates2 = decimal.Parse(row["Rates2"].ToString());
            }

            if (row["Rates3"].ToString() != "")
            {
                model.Rates3 = decimal.Parse(row["Rates3"].ToString());
            }

            if (row["Rates4"].ToString() != "")
            {
                model.Rates4 = decimal.Parse(row["Rates4"].ToString());
            }

            if (row["Rates5"].ToString() != "")
            {
                model.Rates5 = decimal.Parse(row["Rates5"].ToString());
            }

            if (row["Rates6"].ToString() != "")
            {
                model.Rates6 = decimal.Parse(row["Rates6"].ToString());
            }

            if (row["Rates7"].ToString() != "")
            {
                model.Rates7 = decimal.Parse(row["Rates7"].ToString());
            }

            model.ProjectNumber = row["ProjectNumber"].ToString();

            if (row["Rates8"].ToString() != "")
            {
                model.Rates8 = decimal.Parse(row["Rates8"].ToString());
            }

            if (row["BalanceManager"].ToString() != "")
            {
                model.BalanceManager = decimal.Parse(row["BalanceManager"].ToString());
            }

            if (row["Balance"].ToString() != "")
            {
                model.Balance = decimal.Parse(row["Balance"].ToString());
            }

            if (row["ClearingMoney"].ToString() != "")
            {
                model.ClearingMoney = decimal.Parse(row["ClearingMoney"].ToString());
            }

            if (row["ImportAmount"].ToString() != "")
            {
                model.ImportAmount = decimal.Parse(row["ImportAmount"].ToString());
            }

            if (row["ExportAmount"].ToString() != "")
            {
                model.ExportAmount = decimal.Parse(row["ExportAmount"].ToString());
            }

            if (row["FuJiaShui"].ToString() != "")
            {
                model.FuJiaShui = decimal.Parse(row["FuJiaShui"].ToString());
            }

            if (row["QySuoDeShui"].ToString() != "")
            {
                model.QySuoDeShui = decimal.Parse(row["QySuoDeShui"].ToString());
            }

            if (row["YinHuaShui"].ToString() != "")
            {
                model.YinHuaShui = decimal.Parse(row["YinHuaShui"].ToString());
            }

            if (row["GrSuoDeShui"].ToString() != "")
            {
                model.GrSuoDeShui = decimal.Parse(row["GrSuoDeShui"].ToString());
            }

            model.ProjectManager = row["ProjectManager"].ToString();

            if (row["BaoZhenJin"].ToString() != "")
            {
                model.BaoZhenJin = decimal.Parse(row["BaoZhenJin"].ToString());
            }

            if (row["ZhiBaoJin"].ToString() != "")
            {
                model.ZhiBaoJin = decimal.Parse(row["ZhiBaoJin"].ToString());
            }

            if (row["GuangLiFei"].ToString() != "")
            {
                model.GuangLiFei = decimal.Parse(row["GuangLiFei"].ToString());
            }

            if (row["LiXi"].ToString() != "")
            {
                model.LiXi = decimal.Parse(row["LiXi"].ToString());
            }

            if (row["QTKuan"].ToString() != "")
            {
                model.QTKuan = decimal.Parse(row["QTKuan"].ToString());
            }

            if (row["FPAmount"].ToString() != "")
            {
                model.FPAmount = decimal.Parse(row["FPAmount"].ToString());
            }

            if (row["FPShuiKuan"].ToString() != "")
            {
                model.FPShuiKuan = decimal.Parse(row["FPShuiKuan"].ToString());
            }

            if (row["SJAmount"].ToString() != "")
            {
                model.SJAmount = decimal.Parse(row["SJAmount"].ToString());
            }

            if (row["HGSKuan"].ToString() != "")
            {
                model.HGSKuan = decimal.Parse(row["HGSKuan"].ToString());
            }

            if (row["DDYHCunKuan"].ToString() != "")
            {
                model.DDYHCunKuan = decimal.Parse(row["DDYHCunKuan"].ToString());
            }

            model.Tel = row["Tel"].ToString();

            if (row["Type"].ToString() != "")
            {
                model.Type = int.Parse(row["Type"].ToString());
            }

            model.BankName = row["BankName"].ToString();

            model.Account = row["Account"].ToString();

            if (row["fk_id"].ToString() != "")
            {
                model.fk_id = int.Parse(row["fk_id"].ToString());
            }

            if (row["sk_id"].ToString() != "")
            {
                model.sk_id = int.Parse(row["sk_id"].ToString());
            }

            if (row["tk_id"].ToString() != "")
            {
                model.tk_id = int.Parse(row["tk_id"].ToString());
            }

            if (row["Fid"].ToString() != "")
            {
                model.Fid = int.Parse(row["Fid"].ToString());
            }

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }


            if (row["IfCompleted"].ToString() != "")
            {
                if ((row["IfCompleted"].ToString() == "1") || (row["IfCompleted"].ToString().ToLower() == "true"))
                {
                    model.IfCompleted = true;
                }
                else
                {
                    model.IfCompleted = false;
                }
            }

            model.ProjectCategory = row["ProjectCategory"].ToString();

            model.SigningDate = row["SigningDate"].ToString();

            if (row["ContractAmount"].ToString() != "")
            {
                model.ContractAmount = decimal.Parse(row["ContractAmount"].ToString());
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
            strSql.Append(" FROM [Accounting] ");
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
            strSql.Append(" FROM [Accounting] ");
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



