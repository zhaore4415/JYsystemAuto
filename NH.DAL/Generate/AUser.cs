using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// AUser
    /// </summary>
    public static partial class AUser
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.AUser model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [AUser] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.AUser model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime],");
                colParamList.Append("@AddTime,");
                parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                sqlParamList.Add(parameter);
            }

            if (model.Status != Int32.MinValue)
            {
                colList.Append("[Status],");
                colParamList.Append("@Status,");
                parameter = new SqlParameter("@Status", SqlDbType.Int, 4);
                parameter.Value = model.Status;
                sqlParamList.Add(parameter);
            }

            if (model.LoginTime != DateTime.MinValue)
            {
                colList.Append("[LoginTime],");
                colParamList.Append("@LoginTime,");
                parameter = new SqlParameter("@LoginTime", SqlDbType.DateTime);
                parameter.Value = model.LoginTime;
                sqlParamList.Add(parameter);
            }

            if (model.LoginIP != null)
            {
                colList.Append("[LoginIP],");
                colParamList.Append("@LoginIP,");
                parameter = new SqlParameter("@LoginIP", SqlDbType.NVarChar, 20);
                parameter.Value = model.LoginIP;
                sqlParamList.Add(parameter);
            }

            if (model.LoginAddress != null)
            {
                colList.Append("[LoginAddress],");
                colParamList.Append("@LoginAddress,");
                parameter = new SqlParameter("@LoginAddress", SqlDbType.NVarChar, 50);
                parameter.Value = model.LoginAddress;
                sqlParamList.Add(parameter);
            }

            if (model.LastLoginTime != DateTime.MinValue)
            {
                colList.Append("[LastLoginTime],");
                colParamList.Append("@LastLoginTime,");
                parameter = new SqlParameter("@LastLoginTime", SqlDbType.DateTime);
                parameter.Value = model.LastLoginTime;
                sqlParamList.Add(parameter);
            }

            if (model.LastIP != null)
            {
                colList.Append("[LastIP],");
                colParamList.Append("@LastIP,");
                parameter = new SqlParameter("@LastIP", SqlDbType.NVarChar, 20);
                parameter.Value = model.LastIP;
                sqlParamList.Add(parameter);
            }

            if (model.LastAddress != null)
            {
                colList.Append("[LastAddress],");
                colParamList.Append("@LastAddress,");
                parameter = new SqlParameter("@LastAddress", SqlDbType.NVarChar, 50);
                parameter.Value = model.LastAddress;
                sqlParamList.Add(parameter);
            }

            if (model.LoginCount != Int32.MinValue)
            {
                colList.Append("[LoginCount],");
                colParamList.Append("@LoginCount,");
                parameter = new SqlParameter("@LoginCount", SqlDbType.Int, 4);
                parameter.Value = model.LoginCount;
                sqlParamList.Add(parameter);
            }

            if (model.UpdateTime != DateTime.MinValue)
            {
                colList.Append("[UpdateTime],");
                colParamList.Append("@UpdateTime,");
                parameter = new SqlParameter("@UpdateTime", SqlDbType.DateTime);
                parameter.Value = model.UpdateTime;
                sqlParamList.Add(parameter);
            }

            if (model.SerialNumber.HasValue)
            {
                colList.Append("[SerialNumber],");
                colParamList.Append("@SerialNumber,");
                parameter = new SqlParameter("@SerialNumber", SqlDbType.Int, 4);
                if (model.SerialNumber.Value != Int32.MinValue)
                    parameter.Value = model.SerialNumber.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.RoleType != Int32.MinValue)
            {
                colList.Append("[RoleType],");
                colParamList.Append("@RoleType,");
                parameter = new SqlParameter("@RoleType", SqlDbType.Int, 4);
                parameter.Value = model.RoleType;
                sqlParamList.Add(parameter);
            }

            if (model.ZhiWei != Int32.MinValue)
            {
                colList.Append("[ZhiWei],");
                colParamList.Append("@ZhiWei,");
                parameter = new SqlParameter("@ZhiWei", SqlDbType.Int, 4);
                parameter.Value = model.ZhiWei;
                sqlParamList.Add(parameter);
            }

            if (model.ZaiGang != Int32.MinValue)
            {
                colList.Append("[ZaiGang],");
                colParamList.Append("@ZaiGang,");
                parameter = new SqlParameter("@ZaiGang", SqlDbType.Int, 4);
                parameter.Value = model.ZaiGang;
                sqlParamList.Add(parameter);
            }

            if (model.GangWei != null)
            {
                colList.Append("[GangWei],");
                colParamList.Append("@GangWei,");
                parameter = new SqlParameter("@GangWei", SqlDbType.NVarChar, 50);
                parameter.Value = model.GangWei;
                sqlParamList.Add(parameter);
            }

            if (model.Department != null)
            {
                colList.Append("[Department],");
                colParamList.Append("@Department,");
                parameter = new SqlParameter("@Department", SqlDbType.NVarChar, 50);
                parameter.Value = model.Department;
                sqlParamList.Add(parameter);
            }

            if (model.Born != null)
            {
                colList.Append("[Born],");
                colParamList.Append("@Born,");
                parameter = new SqlParameter("@Born", SqlDbType.NVarChar, 50);
                parameter.Value = model.Born;
                sqlParamList.Add(parameter);
            }

            if (model.MingZu != null)
            {
                colList.Append("[MingZu],");
                colParamList.Append("@MingZu,");
                parameter = new SqlParameter("@MingZu", SqlDbType.NVarChar, 20);
                parameter.Value = model.MingZu;
                sqlParamList.Add(parameter);
            }

            if (model.ShenFengZheng != null)
            {
                colList.Append("[ShenFengZheng],");
                colParamList.Append("@ShenFengZheng,");
                parameter = new SqlParameter("@ShenFengZheng", SqlDbType.NVarChar, 50);
                parameter.Value = model.ShenFengZheng;
                sqlParamList.Add(parameter);
            }

            if (model.Marital != null)
            {
                colList.Append("[Marital],");
                colParamList.Append("@Marital,");
                parameter = new SqlParameter("@Marital", SqlDbType.NVarChar, 20);
                parameter.Value = model.Marital;
                sqlParamList.Add(parameter);
            }

            if (model.ZhenZhi != null)
            {
                colList.Append("[ZhenZhi],");
                colParamList.Append("@ZhenZhi,");
                parameter = new SqlParameter("@ZhenZhi", SqlDbType.NVarChar, 50);
                parameter.Value = model.ZhenZhi;
                sqlParamList.Add(parameter);
            }

            if (model.LoginName != null)
            {
                colList.Append("[LoginName],");
                colParamList.Append("@LoginName,");
                parameter = new SqlParameter("@LoginName", SqlDbType.NVarChar, 50);
                parameter.Value = model.LoginName;
                sqlParamList.Add(parameter);
            }

            if (model.GuanJi != null)
            {
                colList.Append("[GuanJi],");
                colParamList.Append("@GuanJi,");
                parameter = new SqlParameter("@GuanJi", SqlDbType.NVarChar, 20);
                parameter.Value = model.GuanJi;
                sqlParamList.Add(parameter);
            }

            if (model.HuKou != null)
            {
                colList.Append("[HuKou],");
                colParamList.Append("@HuKou,");
                parameter = new SqlParameter("@HuKou", SqlDbType.NVarChar, 80);
                parameter.Value = model.HuKou;
                sqlParamList.Add(parameter);
            }

            if (model.XueLi != null)
            {
                colList.Append("[XueLi],");
                colParamList.Append("@XueLi,");
                parameter = new SqlParameter("@XueLi", SqlDbType.NVarChar, 20);
                parameter.Value = model.XueLi;
                sqlParamList.Add(parameter);
            }

            if (model.ZhiCheng != null)
            {
                colList.Append("[ZhiCheng],");
                colParamList.Append("@ZhiCheng,");
                parameter = new SqlParameter("@ZhiCheng", SqlDbType.NVarChar, 50);
                parameter.Value = model.ZhiCheng;
                sqlParamList.Add(parameter);
            }

            if (model.BiYeXueXiao != null)
            {
                colList.Append("[BiYeXueXiao],");
                colParamList.Append("@BiYeXueXiao,");
                parameter = new SqlParameter("@BiYeXueXiao", SqlDbType.NVarChar, 80);
                parameter.Value = model.BiYeXueXiao;
                sqlParamList.Add(parameter);
            }

            if (model.ZhuanYe != null)
            {
                colList.Append("[ZhuanYe],");
                colParamList.Append("@ZhuanYe,");
                parameter = new SqlParameter("@ZhuanYe", SqlDbType.NVarChar, 50);
                parameter.Value = model.ZhuanYe;
                sqlParamList.Add(parameter);
            }

            if (model.GongZuoTime != null)
            {
                colList.Append("[GongZuoTime],");
                colParamList.Append("@GongZuoTime,");
                parameter = new SqlParameter("@GongZuoTime", SqlDbType.NVarChar, 50);
                parameter.Value = model.GongZuoTime;
                sqlParamList.Add(parameter);
            }

            if (model.JiaRuTime != null)
            {
                colList.Append("[JiaRuTime],");
                colParamList.Append("@JiaRuTime,");
                parameter = new SqlParameter("@JiaRuTime", SqlDbType.NVarChar, 50);
                parameter.Value = model.JiaRuTime;
                sqlParamList.Add(parameter);
            }

            if (model.GraduationTime != null)
            {
                colList.Append("[GraduationTime],");
                colParamList.Append("@GraduationTime,");
                parameter = new SqlParameter("@GraduationTime", SqlDbType.NVarChar, 50);
                parameter.Value = model.GraduationTime;
                sqlParamList.Add(parameter);
            }

            if (model.ShouJi != null)
            {
                colList.Append("[ShouJi],");
                colParamList.Append("@ShouJi,");
                parameter = new SqlParameter("@ShouJi", SqlDbType.NVarChar, 30);
                parameter.Value = model.ShouJi;
                sqlParamList.Add(parameter);
            }

            if (model.Password != null)
            {
                colList.Append("[Password],");
                colParamList.Append("@Password,");
                parameter = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
                parameter.Value = model.Password;
                sqlParamList.Add(parameter);
            }

            if (model.JiaTingAddress != null)
            {
                colList.Append("[JiaTingAddress],");
                colParamList.Append("@JiaTingAddress,");
                parameter = new SqlParameter("@JiaTingAddress", SqlDbType.NVarChar, 100);
                parameter.Value = model.JiaTingAddress;
                sqlParamList.Add(parameter);
            }

            if (model.JiaoYu != null)
            {
                colList.Append("[JiaoYu],");
                colParamList.Append("@JiaoYu,");
                parameter = new SqlParameter("@JiaoYu", SqlDbType.NVarChar, 50);
                parameter.Value = model.JiaoYu;
                sqlParamList.Add(parameter);
            }

            if (model.HeTong != null)
            {
                colList.Append("[HeTong],");
                colParamList.Append("@HeTong,");
                parameter = new SqlParameter("@HeTong", SqlDbType.NVarChar, 100);
                parameter.Value = model.HeTong;
                sqlParamList.Add(parameter);
            }

            if (model.SheBao != null)
            {
                colList.Append("[SheBao],");
                colParamList.Append("@SheBao,");
                parameter = new SqlParameter("@SheBao", SqlDbType.NVarChar, 50);
                parameter.Value = model.SheBao;
                sqlParamList.Add(parameter);
            }

            if (model.Notes != null)
            {
                colList.Append("[Notes],");
                colParamList.Append("@Notes,");
                parameter = new SqlParameter("@Notes", SqlDbType.NVarChar, 200);
                parameter.Value = model.Notes;
                sqlParamList.Add(parameter);
            }

            if (model.FuJian != null)
            {
                colList.Append("[FuJian],");
                colParamList.Append("@FuJian,");
                parameter = new SqlParameter("@FuJian", SqlDbType.NVarChar, 200);
                parameter.Value = model.FuJian;
                sqlParamList.Add(parameter);
            }

            if (model.Code != null)
            {
                colList.Append("[Code],");
                colParamList.Append("@Code,");
                parameter = new SqlParameter("@Code", SqlDbType.NVarChar, 20);
                parameter.Value = model.Code;
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

            if (model.Realname != null)
            {
                colList.Append("[Realname],");
                colParamList.Append("@Realname,");
                parameter = new SqlParameter("@Realname", SqlDbType.NVarChar, 20);
                parameter.Value = model.Realname;
                sqlParamList.Add(parameter);
            }

            if (model.WaiYu1 != null)
            {
                colList.Append("[WaiYu1],");
                colParamList.Append("@WaiYu1,");
                parameter = new SqlParameter("@WaiYu1", SqlDbType.NVarChar, 20);
                parameter.Value = model.WaiYu1;
                sqlParamList.Add(parameter);
            }

            if (model.WaiYu2 != null)
            {
                colList.Append("[WaiYu2],");
                colParamList.Append("@WaiYu2,");
                parameter = new SqlParameter("@WaiYu2", SqlDbType.NVarChar, 20);
                parameter.Value = model.WaiYu2;
                sqlParamList.Add(parameter);
            }

            if (model.DengJi1 != null)
            {
                colList.Append("[DengJi1],");
                colParamList.Append("@DengJi1,");
                parameter = new SqlParameter("@DengJi1", SqlDbType.NVarChar, 20);
                parameter.Value = model.DengJi1;
                sqlParamList.Add(parameter);
            }

            if (model.DengJi2 != null)
            {
                colList.Append("[DengJi2],");
                colParamList.Append("@DengJi2,");
                parameter = new SqlParameter("@DengJi2", SqlDbType.NVarChar, 20);
                parameter.Value = model.DengJi2;
                sqlParamList.Add(parameter);
            }

            if (model.D_Id.HasValue)
            {
                colList.Append("[D_Id],");
                colParamList.Append("@D_Id,");
                parameter = new SqlParameter("@D_Id", SqlDbType.Int, 4);
                if (model.D_Id.Value != Int32.MinValue)
                    parameter.Value = model.D_Id.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Source != null)
            {
                colList.Append("[Source],");
                colParamList.Append("@Source,");
                parameter = new SqlParameter("@Source", SqlDbType.NVarChar, 20);
                parameter.Value = model.Source;
                sqlParamList.Add(parameter);
            }

            if (model.CompanyName != null)
            {
                colList.Append("[CompanyName],");
                colParamList.Append("@CompanyName,");
                parameter = new SqlParameter("@CompanyName", SqlDbType.NVarChar, 80);
                parameter.Value = model.CompanyName;
                sqlParamList.Add(parameter);
            }

            if (model.QQWeiXin != null)
            {
                colList.Append("[QQWeiXin],");
                colParamList.Append("@QQWeiXin,");
                parameter = new SqlParameter("@QQWeiXin", SqlDbType.NVarChar, 20);
                parameter.Value = model.QQWeiXin;
                sqlParamList.Add(parameter);
            }

            if (model.JeFen.HasValue)
            {
                colList.Append("[JeFen],");
                colParamList.Append("@JeFen,");
                parameter = new SqlParameter("@JeFen", SqlDbType.Int, 4);
                if (model.JeFen.Value != Int32.MinValue)
                    parameter.Value = model.JeFen.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.T_ID.HasValue)
            {
                colList.Append("[T_ID],");
                colParamList.Append("@T_ID,");
                parameter = new SqlParameter("@T_ID", SqlDbType.Int, 4);
                if (model.T_ID.Value != Int32.MinValue)
                    parameter.Value = model.T_ID.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Sex != Int32.MinValue)
            {
                colList.Append("[Sex],");
                colParamList.Append("@Sex,");
                parameter = new SqlParameter("@Sex", SqlDbType.Int, 4);
                parameter.Value = model.Sex;
                sqlParamList.Add(parameter);
            }

            if (model.ZheKou.HasValue)
            {
                colList.Append("[ZheKou],");
                colParamList.Append("@ZheKou,");
                parameter = new SqlParameter("@ZheKou", SqlDbType.Decimal, 9);
                if (model.ZheKou.Value != decimal.MinValue)
                    parameter.Value = model.ZheKou.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.TJZheKou.HasValue)
            {
                colList.Append("[TJZheKou],");
                colParamList.Append("@TJZheKou,");
                parameter = new SqlParameter("@TJZheKou", SqlDbType.Decimal, 9);
                if (model.TJZheKou.Value != decimal.MinValue)
                    parameter.Value = model.TJZheKou.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Openbank != null)
            {
                colList.Append("[Openbank],");
                colParamList.Append("@Openbank,");
                parameter = new SqlParameter("@Openbank", SqlDbType.NVarChar, 50);
                parameter.Value = model.Openbank;
                sqlParamList.Add(parameter);
            }

            if (model.OpenbankCard != null)
            {
                colList.Append("[OpenbankCard],");
                colParamList.Append("@OpenbankCard,");
                parameter = new SqlParameter("@OpenbankCard", SqlDbType.NVarChar, 50);
                parameter.Value = model.OpenbankCard;
                sqlParamList.Add(parameter);
            }

            if (model.OpenCity != null)
            {
                colList.Append("[OpenCity],");
                colParamList.Append("@OpenCity,");
                parameter = new SqlParameter("@OpenCity", SqlDbType.NVarChar, 20);
                parameter.Value = model.OpenCity;
                sqlParamList.Add(parameter);
            }

            if (model.IsPayment != Int32.MinValue)
            {
                colList.Append("[IsPayment],");
                colParamList.Append("@IsPayment,");
                parameter = new SqlParameter("@IsPayment", SqlDbType.Int, 4);
                parameter.Value = model.IsPayment;
                sqlParamList.Add(parameter);
            }

            if (model.VerifyStatus != Int32.MinValue)
            {
                colList.Append("[VerifyStatus],");
                colParamList.Append("@VerifyStatus,");
                parameter = new SqlParameter("@VerifyStatus", SqlDbType.Int, 4);
                parameter.Value = model.VerifyStatus;
                sqlParamList.Add(parameter);
            }

            if (model.Pic2 != null)
            {
                colList.Append("[Pic2],");
                colParamList.Append("@Pic2,");
                parameter = new SqlParameter("@Pic2", SqlDbType.NVarChar, 25);
                parameter.Value = model.Pic2;
                sqlParamList.Add(parameter);
            }

            if (model.Pic4 != null)
            {
                colList.Append("[Pic4],");
                colParamList.Append("@Pic4,");
                parameter = new SqlParameter("@Pic4", SqlDbType.NVarChar, 25);
                parameter.Value = model.Pic4;
                sqlParamList.Add(parameter);
            }

            if (model.Pic3 != null)
            {
                colList.Append("[Pic3],");
                colParamList.Append("@Pic3,");
                parameter = new SqlParameter("@Pic3", SqlDbType.NVarChar, 25);
                parameter.Value = model.Pic3;
                sqlParamList.Add(parameter);
            }

            if (model.Email != null)
            {
                colList.Append("[Email],");
                colParamList.Append("@Email,");
                parameter = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                parameter.Value = model.Email;
                sqlParamList.Add(parameter);
            }

            if (model.IsCheck.HasValue)
            {
                colList.Append("[IsCheck],");
                colParamList.Append("@IsCheck,");
                parameter = new SqlParameter("@IsCheck", SqlDbType.Int, 4);
                if (model.IsCheck.Value != Int32.MinValue)
                    parameter.Value = model.IsCheck.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.IsCheckType.HasValue)
            {
                colList.Append("[IsCheckType],");
                colParamList.Append("@IsCheckType,");
                parameter = new SqlParameter("@IsCheckType", SqlDbType.Int, 4);
                if (model.IsCheckType.Value != Int32.MinValue)
                    parameter.Value = model.IsCheckType.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Pic != null)
            {
                colList.Append("[Pic],");
                colParamList.Append("@Pic,");
                parameter = new SqlParameter("@Pic", SqlDbType.NVarChar, 25);
                parameter.Value = model.Pic;
                sqlParamList.Add(parameter);
            }

            if (model.Height != null)
            {
                colList.Append("[Height],");
                colParamList.Append("@Height,");
                parameter = new SqlParameter("@Height", SqlDbType.NVarChar, 20);
                parameter.Value = model.Height;
                sqlParamList.Add(parameter);
            }
          
            string strSql = string.Format("insert into [AUser] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from AUser ");
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
            strSql.Append("delete from [AUser] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.AUser model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [AUser] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.AUser model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                paramList.Add(parameter);
            }

            if (model.Status != Int32.MinValue)
            {
                colList.Append("[Status] = @Status,");
                SqlParameter parameter = new SqlParameter("@Status", SqlDbType.Int, 4);
                parameter.Value = model.Status;
                paramList.Add(parameter);
            }

            if (model.LoginTime != DateTime.MinValue)
            {
                colList.Append("[LoginTime] = @LoginTime,");
                SqlParameter parameter = new SqlParameter("@LoginTime", SqlDbType.DateTime);
                parameter.Value = model.LoginTime;
                paramList.Add(parameter);
            }

            if (model.LoginIP != null)
            {
                colList.Append("[LoginIP] = @LoginIP,");
                SqlParameter parameter = new SqlParameter("@LoginIP", SqlDbType.NVarChar, 20);
                parameter.Value = model.LoginIP;
                paramList.Add(parameter);
            }

            if (model.LoginAddress != null)
            {
                colList.Append("[LoginAddress] = @LoginAddress,");
                SqlParameter parameter = new SqlParameter("@LoginAddress", SqlDbType.NVarChar, 50);
                parameter.Value = model.LoginAddress;
                paramList.Add(parameter);
            }

            if (model.LastLoginTime != DateTime.MinValue)
            {
                colList.Append("[LastLoginTime] = @LastLoginTime,");
                SqlParameter parameter = new SqlParameter("@LastLoginTime", SqlDbType.DateTime);
                parameter.Value = model.LastLoginTime;
                paramList.Add(parameter);
            }

            if (model.LastIP != null)
            {
                colList.Append("[LastIP] = @LastIP,");
                SqlParameter parameter = new SqlParameter("@LastIP", SqlDbType.NVarChar, 20);
                parameter.Value = model.LastIP;
                paramList.Add(parameter);
            }

            if (model.LastAddress != null)
            {
                colList.Append("[LastAddress] = @LastAddress,");
                SqlParameter parameter = new SqlParameter("@LastAddress", SqlDbType.NVarChar, 50);
                parameter.Value = model.LastAddress;
                paramList.Add(parameter);
            }

            if (model.LoginCount != Int32.MinValue)
            {
                colList.Append("[LoginCount] = @LoginCount,");
                SqlParameter parameter = new SqlParameter("@LoginCount", SqlDbType.Int, 4);
                parameter.Value = model.LoginCount;
                paramList.Add(parameter);
            }

            if (model.UpdateTime != DateTime.MinValue)
            {
                colList.Append("[UpdateTime] = @UpdateTime,");
                SqlParameter parameter = new SqlParameter("@UpdateTime", SqlDbType.DateTime);
                parameter.Value = model.UpdateTime;
                paramList.Add(parameter);
            }

            if (model.SerialNumber.HasValue)
            {
                colList.Append("[SerialNumber] = @SerialNumber,");
                SqlParameter parameter = new SqlParameter("@SerialNumber", SqlDbType.Int, 4);
                parameter.Value = model.SerialNumber.Value;
                paramList.Add(parameter);
            }

            if (model.RoleType != Int32.MinValue)
            {
                colList.Append("[RoleType] = @RoleType,");
                SqlParameter parameter = new SqlParameter("@RoleType", SqlDbType.Int, 4);
                parameter.Value = model.RoleType;
                paramList.Add(parameter);
            }

            if (model.ZhiWei != Int32.MinValue)
            {
                colList.Append("[ZhiWei] = @ZhiWei,");
                SqlParameter parameter = new SqlParameter("@ZhiWei", SqlDbType.Int, 4);
                parameter.Value = model.ZhiWei;
                paramList.Add(parameter);
            }

            if (model.ZaiGang != Int32.MinValue)
            {
                colList.Append("[ZaiGang] = @ZaiGang,");
                SqlParameter parameter = new SqlParameter("@ZaiGang", SqlDbType.Int, 4);
                parameter.Value = model.ZaiGang;
                paramList.Add(parameter);
            }

            if (model.GangWei != null)
            {
                colList.Append("[GangWei] = @GangWei,");
                SqlParameter parameter = new SqlParameter("@GangWei", SqlDbType.NVarChar, 50);
                parameter.Value = model.GangWei;
                paramList.Add(parameter);
            }

            if (model.Department != null)
            {
                colList.Append("[Department] = @Department,");
                SqlParameter parameter = new SqlParameter("@Department", SqlDbType.NVarChar, 50);
                parameter.Value = model.Department;
                paramList.Add(parameter);
            }

            if (model.Born != null)
            {
                colList.Append("[Born] = @Born,");
                SqlParameter parameter = new SqlParameter("@Born", SqlDbType.NVarChar, 50);
                parameter.Value = model.Born;
                paramList.Add(parameter);
            }

            if (model.MingZu != null)
            {
                colList.Append("[MingZu] = @MingZu,");
                SqlParameter parameter = new SqlParameter("@MingZu", SqlDbType.NVarChar, 20);
                parameter.Value = model.MingZu;
                paramList.Add(parameter);
            }

            if (model.ShenFengZheng != null)
            {
                colList.Append("[ShenFengZheng] = @ShenFengZheng,");
                SqlParameter parameter = new SqlParameter("@ShenFengZheng", SqlDbType.NVarChar, 50);
                parameter.Value = model.ShenFengZheng;
                paramList.Add(parameter);
            }

            if (model.Marital != null)
            {
                colList.Append("[Marital] = @Marital,");
                SqlParameter parameter = new SqlParameter("@Marital", SqlDbType.NVarChar, 20);
                parameter.Value = model.Marital;
                paramList.Add(parameter);
            }

            if (model.ZhenZhi != null)
            {
                colList.Append("[ZhenZhi] = @ZhenZhi,");
                SqlParameter parameter = new SqlParameter("@ZhenZhi", SqlDbType.NVarChar, 50);
                parameter.Value = model.ZhenZhi;
                paramList.Add(parameter);
            }

            if (model.LoginName != null)
            {
                colList.Append("[LoginName] = @LoginName,");
                SqlParameter parameter = new SqlParameter("@LoginName", SqlDbType.NVarChar, 50);
                parameter.Value = model.LoginName;
                paramList.Add(parameter);
            }

            if (model.GuanJi != null)
            {
                colList.Append("[GuanJi] = @GuanJi,");
                SqlParameter parameter = new SqlParameter("@GuanJi", SqlDbType.NVarChar, 20);
                parameter.Value = model.GuanJi;
                paramList.Add(parameter);
            }

            if (model.HuKou != null)
            {
                colList.Append("[HuKou] = @HuKou,");
                SqlParameter parameter = new SqlParameter("@HuKou", SqlDbType.NVarChar, 80);
                parameter.Value = model.HuKou;
                paramList.Add(parameter);
            }

            if (model.XueLi != null)
            {
                colList.Append("[XueLi] = @XueLi,");
                SqlParameter parameter = new SqlParameter("@XueLi", SqlDbType.NVarChar, 20);
                parameter.Value = model.XueLi;
                paramList.Add(parameter);
            }

            if (model.ZhiCheng != null)
            {
                colList.Append("[ZhiCheng] = @ZhiCheng,");
                SqlParameter parameter = new SqlParameter("@ZhiCheng", SqlDbType.NVarChar, 50);
                parameter.Value = model.ZhiCheng;
                paramList.Add(parameter);
            }

            if (model.BiYeXueXiao != null)
            {
                colList.Append("[BiYeXueXiao] = @BiYeXueXiao,");
                SqlParameter parameter = new SqlParameter("@BiYeXueXiao", SqlDbType.NVarChar, 80);
                parameter.Value = model.BiYeXueXiao;
                paramList.Add(parameter);
            }

            if (model.ZhuanYe != null)
            {
                colList.Append("[ZhuanYe] = @ZhuanYe,");
                SqlParameter parameter = new SqlParameter("@ZhuanYe", SqlDbType.NVarChar, 50);
                parameter.Value = model.ZhuanYe;
                paramList.Add(parameter);
            }

            if (model.GongZuoTime != null)
            {
                colList.Append("[GongZuoTime] = @GongZuoTime,");
                SqlParameter parameter = new SqlParameter("@GongZuoTime", SqlDbType.NVarChar, 50);
                parameter.Value = model.GongZuoTime;
                paramList.Add(parameter);
            }

            if (model.JiaRuTime != null)
            {
                colList.Append("[JiaRuTime] = @JiaRuTime,");
                SqlParameter parameter = new SqlParameter("@JiaRuTime", SqlDbType.NVarChar, 50);
                parameter.Value = model.JiaRuTime;
                paramList.Add(parameter);
            }

            if (model.GraduationTime != null)
            {
                colList.Append("[GraduationTime] = @GraduationTime,");
                SqlParameter parameter = new SqlParameter("@GraduationTime", SqlDbType.NVarChar, 50);
                parameter.Value = model.GraduationTime;
                paramList.Add(parameter);
            }

            if (model.ShouJi != null)
            {
                colList.Append("[ShouJi] = @ShouJi,");
                SqlParameter parameter = new SqlParameter("@ShouJi", SqlDbType.NVarChar, 30);
                parameter.Value = model.ShouJi;
                paramList.Add(parameter);
            }

            if (model.Password != null)
            {
                colList.Append("[Password] = @Password,");
                SqlParameter parameter = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
                parameter.Value = model.Password;
                paramList.Add(parameter);
            }

            if (model.JiaTingAddress != null)
            {
                colList.Append("[JiaTingAddress] = @JiaTingAddress,");
                SqlParameter parameter = new SqlParameter("@JiaTingAddress", SqlDbType.NVarChar, 100);
                parameter.Value = model.JiaTingAddress;
                paramList.Add(parameter);
            }

            if (model.JiaoYu != null)
            {
                colList.Append("[JiaoYu] = @JiaoYu,");
                SqlParameter parameter = new SqlParameter("@JiaoYu", SqlDbType.NVarChar, 50);
                parameter.Value = model.JiaoYu;
                paramList.Add(parameter);
            }

            if (model.HeTong != null)
            {
                colList.Append("[HeTong] = @HeTong,");
                SqlParameter parameter = new SqlParameter("@HeTong", SqlDbType.NVarChar, 100);
                parameter.Value = model.HeTong;
                paramList.Add(parameter);
            }

            if (model.SheBao != null)
            {
                colList.Append("[SheBao] = @SheBao,");
                SqlParameter parameter = new SqlParameter("@SheBao", SqlDbType.NVarChar, 50);
                parameter.Value = model.SheBao;
                paramList.Add(parameter);
            }

            if (model.Notes != null)
            {
                colList.Append("[Notes] = @Notes,");
                SqlParameter parameter = new SqlParameter("@Notes", SqlDbType.NVarChar, 200);
                parameter.Value = model.Notes;
                paramList.Add(parameter);
            }

            if (model.FuJian != null)
            {
                colList.Append("[FuJian] = @FuJian,");
                SqlParameter parameter = new SqlParameter("@FuJian", SqlDbType.NVarChar, 200);
                parameter.Value = model.FuJian;
                paramList.Add(parameter);
            }

            if (model.Code != null)
            {
                colList.Append("[Code] = @Code,");
                SqlParameter parameter = new SqlParameter("@Code", SqlDbType.NVarChar, 20);
                parameter.Value = model.Code;
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

            if (model.Realname != null)
            {
                colList.Append("[Realname] = @Realname,");
                SqlParameter parameter = new SqlParameter("@Realname", SqlDbType.NVarChar, 20);
                parameter.Value = model.Realname;
                paramList.Add(parameter);
            }

            if (model.WaiYu1 != null)
            {
                colList.Append("[WaiYu1] = @WaiYu1,");
                SqlParameter parameter = new SqlParameter("@WaiYu1", SqlDbType.NVarChar, 20);
                parameter.Value = model.WaiYu1;
                paramList.Add(parameter);
            }

            if (model.WaiYu2 != null)
            {
                colList.Append("[WaiYu2] = @WaiYu2,");
                SqlParameter parameter = new SqlParameter("@WaiYu2", SqlDbType.NVarChar, 20);
                parameter.Value = model.WaiYu2;
                paramList.Add(parameter);
            }

            if (model.DengJi1 != null)
            {
                colList.Append("[DengJi1] = @DengJi1,");
                SqlParameter parameter = new SqlParameter("@DengJi1", SqlDbType.NVarChar, 20);
                parameter.Value = model.DengJi1;
                paramList.Add(parameter);
            }

            if (model.DengJi2 != null)
            {
                colList.Append("[DengJi2] = @DengJi2,");
                SqlParameter parameter = new SqlParameter("@DengJi2", SqlDbType.NVarChar, 20);
                parameter.Value = model.DengJi2;
                paramList.Add(parameter);
            }

            if (model.D_Id.HasValue)
            {
                colList.Append("[D_Id] = @D_Id,");
                SqlParameter parameter = new SqlParameter("@D_Id", SqlDbType.Int, 4);
                parameter.Value = model.D_Id.Value;
                paramList.Add(parameter);
            }

            if (model.Source != null)
            {
                colList.Append("[Source] = @Source,");
                SqlParameter parameter = new SqlParameter("@Source", SqlDbType.NVarChar, 20);
                parameter.Value = model.Source;
                paramList.Add(parameter);
            }

            if (model.CompanyName != null)
            {
                colList.Append("[CompanyName] = @CompanyName,");
                SqlParameter parameter = new SqlParameter("@CompanyName", SqlDbType.NVarChar, 80);
                parameter.Value = model.CompanyName;
                paramList.Add(parameter);
            }

            if (model.QQWeiXin != null)
            {
                colList.Append("[QQWeiXin] = @QQWeiXin,");
                SqlParameter parameter = new SqlParameter("@QQWeiXin", SqlDbType.NVarChar, 20);
                parameter.Value = model.QQWeiXin;
                paramList.Add(parameter);
            }

            if (model.JeFen.HasValue)
            {
                colList.Append("[JeFen] = @JeFen,");
                SqlParameter parameter = new SqlParameter("@JeFen", SqlDbType.Int, 4);
                parameter.Value = model.JeFen.Value;
                paramList.Add(parameter);
            }

            if (model.T_ID.HasValue)
            {
                colList.Append("[T_ID] = @T_ID,");
                SqlParameter parameter = new SqlParameter("@T_ID", SqlDbType.Int, 4);
                parameter.Value = model.T_ID.Value;
                paramList.Add(parameter);
            }

            if (model.Sex != Int32.MinValue)
            {
                colList.Append("[Sex] = @Sex,");
                SqlParameter parameter = new SqlParameter("@Sex", SqlDbType.Int, 4);
                parameter.Value = model.Sex;
                paramList.Add(parameter);
            }

            if (model.ZheKou.HasValue)
            {
                colList.Append("[ZheKou] = @ZheKou,");
                SqlParameter parameter = new SqlParameter("@ZheKou", SqlDbType.Decimal, 9);
                parameter.Value = model.ZheKou.Value;
                paramList.Add(parameter);
            }

            if (model.TJZheKou.HasValue)
            {
                colList.Append("[TJZheKou] = @TJZheKou,");
                SqlParameter parameter = new SqlParameter("@TJZheKou", SqlDbType.Decimal, 9);
                parameter.Value = model.TJZheKou.Value;
                paramList.Add(parameter);
            }

            if (model.Openbank != null)
            {
                colList.Append("[Openbank] = @Openbank,");
                SqlParameter parameter = new SqlParameter("@Openbank", SqlDbType.NVarChar, 50);
                parameter.Value = model.Openbank;
                paramList.Add(parameter);
            }

            if (model.OpenbankCard != null)
            {
                colList.Append("[OpenbankCard] = @OpenbankCard,");
                SqlParameter parameter = new SqlParameter("@OpenbankCard", SqlDbType.NVarChar, 50);
                parameter.Value = model.OpenbankCard;
                paramList.Add(parameter);
            }

            if (model.OpenCity != null)
            {
                colList.Append("[OpenCity] = @OpenCity,");
                SqlParameter parameter = new SqlParameter("@OpenCity", SqlDbType.NVarChar, 20);
                parameter.Value = model.OpenCity;
                paramList.Add(parameter);
            }

            if (model.IsPayment != Int32.MinValue)
            {
                colList.Append("[IsPayment] = @IsPayment,");
                SqlParameter parameter = new SqlParameter("@IsPayment", SqlDbType.Int, 4);
                parameter.Value = model.IsPayment;
                paramList.Add(parameter);
            }

            if (model.VerifyStatus != Int32.MinValue)
            {
                colList.Append("[VerifyStatus] = @VerifyStatus,");
                SqlParameter parameter = new SqlParameter("@VerifyStatus", SqlDbType.Int, 4);
                parameter.Value = model.VerifyStatus;
                paramList.Add(parameter);
            }

            if (model.Pic2 != null)
            {
                colList.Append("[Pic2] = @Pic2,");
                SqlParameter parameter = new SqlParameter("@Pic2", SqlDbType.NVarChar, 25);
                parameter.Value = model.Pic2;
                paramList.Add(parameter);
            }

            if (model.Pic4 != null)
            {
                colList.Append("[Pic4] = @Pic4,");
                SqlParameter parameter = new SqlParameter("@Pic4", SqlDbType.NVarChar, 25);
                parameter.Value = model.Pic4;
                paramList.Add(parameter);
            }

            if (model.Pic3 != null)
            {
                colList.Append("[Pic3] = @Pic3,");
                SqlParameter parameter = new SqlParameter("@Pic3", SqlDbType.NVarChar, 25);
                parameter.Value = model.Pic3;
                paramList.Add(parameter);
            }

            if (model.Email != null)
            {
                colList.Append("[Email] = @Email,");
                SqlParameter parameter = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                parameter.Value = model.Email;
                paramList.Add(parameter);
            }

            if (model.IsCheck.HasValue)
            {
                colList.Append("[IsCheck] = @IsCheck,");
                SqlParameter parameter = new SqlParameter("@IsCheck", SqlDbType.Int, 4);
                parameter.Value = model.IsCheck.Value;
                paramList.Add(parameter);
            }

            if (model.IsCheckType.HasValue)
            {
                colList.Append("[IsCheckType] = @IsCheckType,");
                SqlParameter parameter = new SqlParameter("@IsCheckType", SqlDbType.Int, 4);
                parameter.Value = model.IsCheckType.Value;
                paramList.Add(parameter);
            }

            if (model.Pic != null)
            {
                colList.Append("[Pic] = @Pic,");
                SqlParameter parameter = new SqlParameter("@Pic", SqlDbType.NVarChar, 25);
                parameter.Value = model.Pic;
                paramList.Add(parameter);
            }

            if (model.Height != null)
            {
                colList.Append("[Height] = @Height,");
                SqlParameter parameter = new SqlParameter("@Height", SqlDbType.NVarChar, 20);
                parameter.Value = model.Height;
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
        public static NH.Model.AUser GetModel(int Id)
        {
            NH.Model.AUser model = new NH.Model.AUser();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.AUser GetModel(NH.Model.AUser model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [Id], [AddTime], [Status], [LoginTime], [LoginIP], [LoginAddress], [LastLoginTime], [LastIP], [LastAddress], [LoginCount], [UpdateTime], [SerialNumber], [RoleType], [ZhiWei], [ZaiGang], [GangWei], [Department], [Born], [MingZu], [ShenFengZheng], [Marital], [ZhenZhi], [LoginName], [GuanJi], [HuKou], [XueLi], [ZhiCheng], [BiYeXueXiao], [ZhuanYe], [GongZuoTime], [JiaRuTime], [GraduationTime], [ShouJi], [Password], [JiaTingAddress], [JiaoYu], [HeTong], [SheBao], [Notes], [FuJian], [Code], [fk_id], [sk_id], [tk_id], [Realname], [WaiYu1], [WaiYu2], [DengJi1], [DengJi2], [D_Id], [Source], [CompanyName], [QQWeiXin], [JeFen], [T_ID], [Sex], [ZheKou], [TJZheKou], [Openbank], [OpenbankCard], [OpenCity], [IsPayment], [VerifyStatus], [Pic2], [Pic4], [Pic3], [Email], [IsCheck], [IsCheckType], [Pic], [Height]");
            strSql.Append(" from [AUser] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.AUser();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }

            if (row["Status"].ToString() != "")
            {
                model.Status = int.Parse(row["Status"].ToString());
            }

            if (row["LoginTime"].ToString() != "")
            {
                model.LoginTime = DateTime.Parse(row["LoginTime"].ToString());
            }

            model.LoginIP = row["LoginIP"].ToString();

            model.LoginAddress = row["LoginAddress"].ToString();

            if (row["LastLoginTime"].ToString() != "")
            {
                model.LastLoginTime = DateTime.Parse(row["LastLoginTime"].ToString());
            }

            model.LastIP = row["LastIP"].ToString();

            model.LastAddress = row["LastAddress"].ToString();

            if (row["LoginCount"].ToString() != "")
            {
                model.LoginCount = int.Parse(row["LoginCount"].ToString());
            }

            if (row["UpdateTime"].ToString() != "")
            {
                model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
            }

            if (row["SerialNumber"].ToString() != "")
            {
                model.SerialNumber = int.Parse(row["SerialNumber"].ToString());
            }

            if (row["RoleType"].ToString() != "")
            {
                model.RoleType = int.Parse(row["RoleType"].ToString());
            }

            if (row["ZhiWei"].ToString() != "")
            {
                model.ZhiWei = int.Parse(row["ZhiWei"].ToString());
            }

            if (row["ZaiGang"].ToString() != "")
            {
                model.ZaiGang = int.Parse(row["ZaiGang"].ToString());
            }

            model.GangWei = row["GangWei"].ToString();

            model.Department = row["Department"].ToString();

            model.Born = row["Born"].ToString();

            model.MingZu = row["MingZu"].ToString();

            model.ShenFengZheng = row["ShenFengZheng"].ToString();

            model.Marital = row["Marital"].ToString();

            model.ZhenZhi = row["ZhenZhi"].ToString();

            model.LoginName = row["LoginName"].ToString();

            model.GuanJi = row["GuanJi"].ToString();

            model.HuKou = row["HuKou"].ToString();

            model.XueLi = row["XueLi"].ToString();

            model.ZhiCheng = row["ZhiCheng"].ToString();

            model.BiYeXueXiao = row["BiYeXueXiao"].ToString();

            model.ZhuanYe = row["ZhuanYe"].ToString();

            model.GongZuoTime = row["GongZuoTime"].ToString();

            model.JiaRuTime = row["JiaRuTime"].ToString();

            model.GraduationTime = row["GraduationTime"].ToString();

            model.ShouJi = row["ShouJi"].ToString();

            model.Password = row["Password"].ToString();

            model.JiaTingAddress = row["JiaTingAddress"].ToString();

            model.JiaoYu = row["JiaoYu"].ToString();

            model.HeTong = row["HeTong"].ToString();

            model.SheBao = row["SheBao"].ToString();

            model.Notes = row["Notes"].ToString();

            model.FuJian = row["FuJian"].ToString();

            model.Code = row["Code"].ToString();

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

            model.Realname = row["Realname"].ToString();

            model.WaiYu1 = row["WaiYu1"].ToString();

            model.WaiYu2 = row["WaiYu2"].ToString();

            model.DengJi1 = row["DengJi1"].ToString();

            model.DengJi2 = row["DengJi2"].ToString();

            if (row["D_Id"].ToString() != "")
            {
                model.D_Id = int.Parse(row["D_Id"].ToString());
            }

            model.Source = row["Source"].ToString();

            model.CompanyName = row["CompanyName"].ToString();

            model.QQWeiXin = row["QQWeiXin"].ToString();

            if (row["JeFen"].ToString() != "")
            {
                model.JeFen = int.Parse(row["JeFen"].ToString());
            }

            if (row["T_ID"].ToString() != "")
            {
                model.T_ID = int.Parse(row["T_ID"].ToString());
            }

            if (row["Sex"].ToString() != "")
            {
                model.Sex = int.Parse(row["Sex"].ToString());
            }

            if (row["ZheKou"].ToString() != "")
            {
                model.ZheKou = decimal.Parse(row["ZheKou"].ToString());
            }

            if (row["TJZheKou"].ToString() != "")
            {
                model.TJZheKou = decimal.Parse(row["TJZheKou"].ToString());
            }

            model.Openbank = row["Openbank"].ToString();

            model.OpenbankCard = row["OpenbankCard"].ToString();

            model.OpenCity = row["OpenCity"].ToString();

            if (row["IsPayment"].ToString() != "")
            {
                model.IsPayment = int.Parse(row["IsPayment"].ToString());
            }

            if (row["VerifyStatus"].ToString() != "")
            {
                model.VerifyStatus = int.Parse(row["VerifyStatus"].ToString());
            }

            model.Pic2 = row["Pic2"].ToString();

            model.Pic4 = row["Pic4"].ToString();

            model.Pic3 = row["Pic3"].ToString();

            model.Email = row["Email"].ToString();

            if (row["IsCheck"].ToString() != "")
            {
                model.IsCheck = int.Parse(row["IsCheck"].ToString());
            }

            if (row["IsCheckType"].ToString() != "")
            {
                model.IsCheckType = int.Parse(row["IsCheckType"].ToString());
            }

            model.Pic = row["Pic"].ToString();

            model.Height = row["Height"].ToString();
          
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
            strSql.Append(" FROM [AUser] ");
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
            strSql.Append(" FROM [AUser] ");
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



