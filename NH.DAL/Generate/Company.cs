using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Company
    /// </summary>
    public static partial class Company
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Company model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Company](nolock)");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(NH.Model.Company model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.Id != Int32.MinValue)
            {
                colList.Append("[Id],");
                colParamList.Append("@Id,");
                parameter = new SqlParameter("@Id", SqlDbType.Int, 4);
                parameter.Value = model.Id;
                sqlParamList.Add(parameter);
            }

            if (model.Address != null)
            {
                colList.Append("[Address],");
                colParamList.Append("@Address,");
                parameter = new SqlParameter("@Address", SqlDbType.NVarChar, 50);
                parameter.Value = model.Address;
                sqlParamList.Add(parameter);
            }

            if (model.HomePage != null)
            {
                colList.Append("[HomePage],");
                colParamList.Append("@HomePage,");
                parameter = new SqlParameter("@HomePage", SqlDbType.NVarChar, 50);
                parameter.Value = model.HomePage;
                sqlParamList.Add(parameter);
            }

            if (model.Space != null)
            {
                colList.Append("[Space],");
                colParamList.Append("@Space,");
                parameter = new SqlParameter("@Space", SqlDbType.NVarChar, 50);
                parameter.Value = model.Space;
                sqlParamList.Add(parameter);
            }

            if (model.EmployeeQty != null)
            {
                colList.Append("[EmployeeQty],");
                colParamList.Append("@EmployeeQty,");
                parameter = new SqlParameter("@EmployeeQty", SqlDbType.NVarChar, 50);
                parameter.Value = model.EmployeeQty;
                sqlParamList.Add(parameter);
            }

            if (model.Camera != null)
            {
                colList.Append("[Camera],");
                colParamList.Append("@Camera,");
                parameter = new SqlParameter("@Camera", SqlDbType.NVarChar, 100);
                parameter.Value = model.Camera;
                sqlParamList.Add(parameter);
            }

            if (model.Studio != null)
            {
                colList.Append("[Studio],");
                colParamList.Append("@Studio,");
                parameter = new SqlParameter("@Studio", SqlDbType.NVarChar, 20);
                parameter.Value = model.Studio;
                sqlParamList.Add(parameter);
            }

            if (model.Description != null)
            {
                colList.Append("[Description],");
                colParamList.Append("@Description,");
                parameter = new SqlParameter("@Description", SqlDbType.NText);
                parameter.Value = model.Description;
                sqlParamList.Add(parameter);
            }

            if (model.IdentityVerified.HasValue)
            {
                colList.Append("[IdentityVerified],");
                colParamList.Append("@IdentityVerified,");
                parameter = new SqlParameter("@IdentityVerified", SqlDbType.Bit, 1);
                parameter.Value = model.IdentityVerified.Value;
                sqlParamList.Add(parameter);
            }

            if (model.LevelID != Int32.MinValue)
            {
                colList.Append("[LevelID],");
                colParamList.Append("@LevelID,");
                parameter = new SqlParameter("@LevelID", SqlDbType.Int, 4);
                parameter.Value = model.LevelID;
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

            if (model.CompanyName != null)
            {
                colList.Append("[CompanyName],");
                colParamList.Append("@CompanyName,");
                parameter = new SqlParameter("@CompanyName", SqlDbType.NVarChar, 50);
                parameter.Value = model.CompanyName;
                sqlParamList.Add(parameter);
            }

            if (model.ExpireDate.HasValue)
            {
                colList.Append("[ExpireDate],");
                colParamList.Append("@ExpireDate,");
                parameter = new SqlParameter("@ExpireDate", SqlDbType.SmallDateTime);
                if (model.ExpireDate.Value != DateTime.MinValue)
                    parameter.Value = model.ExpireDate.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.ViewCount != Int32.MinValue)
            {
                colList.Append("[ViewCount],");
                colParamList.Append("@ViewCount,");
                parameter = new SqlParameter("@ViewCount", SqlDbType.Int, 4);
                parameter.Value = model.ViewCount;
                sqlParamList.Add(parameter);
            }

            if (model.IsVerify.HasValue)
            {
                colList.Append("[IsVerify],");
                colParamList.Append("@IsVerify,");
                parameter = new SqlParameter("@IsVerify", SqlDbType.Bit, 1);
                parameter.Value = model.IsVerify.Value;
                sqlParamList.Add(parameter);
            }

            if (model.VipOpenType != Int32.MinValue)
            {
                colList.Append("[VipOpenType],");
                colParamList.Append("@VipOpenType,");
                parameter = new SqlParameter("@VipOpenType", SqlDbType.Int, 4);
                parameter.Value = model.VipOpenType;
                sqlParamList.Add(parameter);
            }

            if (model.JobRefreshTime.HasValue)
            {
                colList.Append("[JobRefreshTime],");
                colParamList.Append("@JobRefreshTime,");
                parameter = new SqlParameter("@JobRefreshTime", SqlDbType.DateTime);
                if (model.JobRefreshTime.Value != DateTime.MinValue)
                    parameter.Value = model.JobRefreshTime.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.IsStandard.HasValue)
            {
                colList.Append("[IsStandard],");
                colParamList.Append("@IsStandard,");
                parameter = new SqlParameter("@IsStandard", SqlDbType.Bit, 1);
                parameter.Value = model.IsStandard.Value;
                sqlParamList.Add(parameter);
            }

            if (model.IsFoodAdd.HasValue)
            {
                colList.Append("[IsFoodAdd],");
                colParamList.Append("@IsFoodAdd,");
                parameter = new SqlParameter("@IsFoodAdd", SqlDbType.Bit, 1);
                parameter.Value = model.IsFoodAdd.Value;
                sqlParamList.Add(parameter);
            }

            if (model.IsOfferRoom.HasValue)
            {
                colList.Append("[IsOfferRoom],");
                colParamList.Append("@IsOfferRoom,");
                parameter = new SqlParameter("@IsOfferRoom", SqlDbType.Bit, 1);
                parameter.Value = model.IsOfferRoom.Value;
                sqlParamList.Add(parameter);
            }

            if (model.IsOfferFood.HasValue)
            {
                colList.Append("[IsOfferFood],");
                colParamList.Append("@IsOfferFood,");
                parameter = new SqlParameter("@IsOfferFood", SqlDbType.Bit, 1);
                parameter.Value = model.IsOfferFood.Value;
                sqlParamList.Add(parameter);
            }

            if (model.IsFiveInsurance.HasValue)
            {
                colList.Append("[IsFiveInsurance],");
                colParamList.Append("@IsFiveInsurance,");
                parameter = new SqlParameter("@IsFiveInsurance", SqlDbType.Bit, 1);
                parameter.Value = model.IsFiveInsurance.Value;
                sqlParamList.Add(parameter);
            }

            if (model.Contact != null)
            {
                colList.Append("[Contact],");
                colParamList.Append("@Contact,");
                parameter = new SqlParameter("@Contact", SqlDbType.NVarChar, 20);
                parameter.Value = model.Contact;
                sqlParamList.Add(parameter);
            }

            if (model.IsFund.HasValue)
            {
                colList.Append("[IsFund],");
                colParamList.Append("@IsFund,");
                parameter = new SqlParameter("@IsFund", SqlDbType.Bit, 1);
                parameter.Value = model.IsFund.Value;
                sqlParamList.Add(parameter);
            }

            if (model.IsCarFare.HasValue)
            {
                colList.Append("[IsCarFare],");
                colParamList.Append("@IsCarFare,");
                parameter = new SqlParameter("@IsCarFare", SqlDbType.Bit, 1);
                parameter.Value = model.IsCarFare.Value;
                sqlParamList.Add(parameter);
            }

            if (model.IsYearGuarantee.HasValue)
            {
                colList.Append("[IsYearGuarantee],");
                colParamList.Append("@IsYearGuarantee,");
                parameter = new SqlParameter("@IsYearGuarantee", SqlDbType.Bit, 1);
                parameter.Value = model.IsYearGuarantee.Value;
                sqlParamList.Add(parameter);
            }

            if (model.Balance != decimal.MinValue)
            {
                colList.Append("[Balance],");
                colParamList.Append("@Balance,");
                parameter = new SqlParameter("@Balance", SqlDbType.Decimal, 9);
                parameter.Value = model.Balance;
                sqlParamList.Add(parameter);
            }

            if (model.IsReceive.HasValue)
            {
                colList.Append("[IsReceive],");
                colParamList.Append("@IsReceive,");
                parameter = new SqlParameter("@IsReceive", SqlDbType.Bit, 1);
                parameter.Value = model.IsReceive.Value;
                sqlParamList.Add(parameter);
            }

            if (model.ReceiveEndTime.HasValue)
            {
                colList.Append("[ReceiveEndTime],");
                colParamList.Append("@ReceiveEndTime,");
                parameter = new SqlParameter("@ReceiveEndTime", SqlDbType.DateTime);
                if (model.ReceiveEndTime.Value != DateTime.MinValue)
                    parameter.Value = model.ReceiveEndTime.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.ReceiveAddress != null)
            {
                colList.Append("[ReceiveAddress],");
                colParamList.Append("@ReceiveAddress,");
                parameter = new SqlParameter("@ReceiveAddress", SqlDbType.NVarChar, 50);
                parameter.Value = model.ReceiveAddress;
                sqlParamList.Add(parameter);
            }

            if (model.TotalSignUp != Int32.MinValue)
            {
                colList.Append("[TotalSignUp],");
                colParamList.Append("@TotalSignUp,");
                parameter = new SqlParameter("@TotalSignUp", SqlDbType.Int, 4);
                parameter.Value = model.TotalSignUp;
                sqlParamList.Add(parameter);
            }

            if (model.CurSignUp != Int32.MinValue)
            {
                colList.Append("[CurSignUp],");
                colParamList.Append("@CurSignUp,");
                parameter = new SqlParameter("@CurSignUp", SqlDbType.Int, 4);
                parameter.Value = model.CurSignUp;
                sqlParamList.Add(parameter);
            }

            if (model.ReceiveTimes != Int32.MinValue)
            {
                colList.Append("[ReceiveTimes],");
                colParamList.Append("@ReceiveTimes,");
                parameter = new SqlParameter("@ReceiveTimes", SqlDbType.Int, 4);
                parameter.Value = model.ReceiveTimes;
                sqlParamList.Add(parameter);
            }

            if (model.AreaID != null)
            {
                colList.Append("[AreaID],");
                colParamList.Append("@AreaID,");
                parameter = new SqlParameter("@AreaID", SqlDbType.NVarChar, 20);
                parameter.Value = model.AreaID;
                sqlParamList.Add(parameter);
            }

            if (model.Logo != null)
            {
                colList.Append("[Logo],");
                colParamList.Append("@Logo,");
                parameter = new SqlParameter("@Logo", SqlDbType.NVarChar, 50);
                parameter.Value = model.Logo;
                sqlParamList.Add(parameter);
            }

            if (model.Area != null)
            {
                colList.Append("[Area],");
                colParamList.Append("@Area,");
                parameter = new SqlParameter("@Area", SqlDbType.NVarChar, 50);
                parameter.Value = model.Area;
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

            if (model.QQ != null)
            {
                colList.Append("[QQ],");
                colParamList.Append("@QQ,");
                parameter = new SqlParameter("@QQ", SqlDbType.NVarChar, 20);
                parameter.Value = model.QQ;
                sqlParamList.Add(parameter);
            }

            if (model.Phone != null)
            {
                colList.Append("[Phone],");
                colParamList.Append("@Phone,");
                parameter = new SqlParameter("@Phone", SqlDbType.NVarChar, 50);
                parameter.Value = model.Phone;
                sqlParamList.Add(parameter);
            }

            if (model.OtherPhone != null)
            {
                colList.Append("[OtherPhone],");
                colParamList.Append("@OtherPhone,");
                parameter = new SqlParameter("@OtherPhone", SqlDbType.NVarChar, 50);
                parameter.Value = model.OtherPhone;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [Company] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));

            return SqlHelper.ExecuteNonQuery(strSql, sqlParamList.ToArray()) > 0;

        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Company] ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
            parameters[0].Value = Id;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion


        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Company model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Company] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id  ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Company model, ref SqlParameter[] parameters, bool isUpdate)
        {
            StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (model.Id != Int32.MinValue)
            {
                colList.Append("[Id] = @Id,");
                SqlParameter parameter = new SqlParameter("@Id", SqlDbType.Int, 4);
                parameter.Value = model.Id;
                paramList.Add(parameter);
            }

            if (model.Address != null)
            {
                colList.Append("[Address] = @Address,");
                SqlParameter parameter = new SqlParameter("@Address", SqlDbType.NVarChar, 50);
                parameter.Value = model.Address;
                paramList.Add(parameter);
            }

            if (model.HomePage != null)
            {
                colList.Append("[HomePage] = @HomePage,");
                SqlParameter parameter = new SqlParameter("@HomePage", SqlDbType.NVarChar, 50);
                parameter.Value = model.HomePage;
                paramList.Add(parameter);
            }

            if (model.Space != null)
            {
                colList.Append("[Space] = @Space,");
                SqlParameter parameter = new SqlParameter("@Space", SqlDbType.NVarChar, 50);
                parameter.Value = model.Space;
                paramList.Add(parameter);
            }

            if (model.EmployeeQty != null)
            {
                colList.Append("[EmployeeQty] = @EmployeeQty,");
                SqlParameter parameter = new SqlParameter("@EmployeeQty", SqlDbType.NVarChar, 50);
                parameter.Value = model.EmployeeQty;
                paramList.Add(parameter);
            }

            if (model.Camera != null)
            {
                colList.Append("[Camera] = @Camera,");
                SqlParameter parameter = new SqlParameter("@Camera", SqlDbType.NVarChar, 100);
                parameter.Value = model.Camera;
                paramList.Add(parameter);
            }

            if (model.Studio != null)
            {
                colList.Append("[Studio] = @Studio,");
                SqlParameter parameter = new SqlParameter("@Studio", SqlDbType.NVarChar, 20);
                parameter.Value = model.Studio;
                paramList.Add(parameter);
            }

            if (model.Description != null)
            {
                colList.Append("[Description] = @Description,");
                SqlParameter parameter = new SqlParameter("@Description", SqlDbType.NText);
                parameter.Value = model.Description;
                paramList.Add(parameter);
            }

            if (model.IdentityVerified.HasValue)
            {
                colList.Append("[IdentityVerified] = @IdentityVerified,");
                SqlParameter parameter = new SqlParameter("@IdentityVerified", SqlDbType.Bit, 1);
                parameter.Value = model.IdentityVerified.Value; paramList.Add(parameter);
            }

            if (model.LevelID != Int32.MinValue)
            {
                colList.Append("[LevelID] = @LevelID,");
                SqlParameter parameter = new SqlParameter("@LevelID", SqlDbType.Int, 4);
                parameter.Value = model.LevelID;
                paramList.Add(parameter);
            }

            if (model.VerifyStatus != Int32.MinValue)
            {
                colList.Append("[VerifyStatus] = @VerifyStatus,");
                SqlParameter parameter = new SqlParameter("@VerifyStatus", SqlDbType.Int, 4);
                parameter.Value = model.VerifyStatus;
                paramList.Add(parameter);
            }

            if (model.CompanyName != null)
            {
                colList.Append("[CompanyName] = @CompanyName,");
                SqlParameter parameter = new SqlParameter("@CompanyName", SqlDbType.NVarChar, 50);
                parameter.Value = model.CompanyName;
                paramList.Add(parameter);
            }

            if (model.ExpireDate.HasValue)
            {
                colList.Append("[ExpireDate] = @ExpireDate,");
                SqlParameter parameter = new SqlParameter("@ExpireDate", SqlDbType.SmallDateTime);
                if (model.ExpireDate.Value != DateTime.MinValue)
                    parameter.Value = model.ExpireDate.Value;
                else
                    parameter.Value = DBNull.Value;
                paramList.Add(parameter);
            }

            if (model.ViewCount != Int32.MinValue)
            {
                colList.Append("[ViewCount] = @ViewCount,");
                SqlParameter parameter = new SqlParameter("@ViewCount", SqlDbType.Int, 4);
                parameter.Value = model.ViewCount;
                paramList.Add(parameter);
            }

            if (model.IsVerify.HasValue)
            {
                colList.Append("[IsVerify] = @IsVerify,");
                SqlParameter parameter = new SqlParameter("@IsVerify", SqlDbType.Bit, 1);
                parameter.Value = model.IsVerify.Value; paramList.Add(parameter);
            }

            if (model.VipOpenType != Int32.MinValue)
            {
                colList.Append("[VipOpenType] = @VipOpenType,");
                SqlParameter parameter = new SqlParameter("@VipOpenType", SqlDbType.Int, 4);
                parameter.Value = model.VipOpenType;
                paramList.Add(parameter);
            }

            if (model.JobRefreshTime.HasValue)
            {
                colList.Append("[JobRefreshTime] = @JobRefreshTime,");
                SqlParameter parameter = new SqlParameter("@JobRefreshTime", SqlDbType.DateTime);
                if (model.JobRefreshTime.Value != DateTime.MinValue)
                    parameter.Value = model.JobRefreshTime.Value;
                else
                    parameter.Value = DBNull.Value;
                paramList.Add(parameter);
            }

            if (model.IsStandard.HasValue)
            {
                colList.Append("[IsStandard] = @IsStandard,");
                SqlParameter parameter = new SqlParameter("@IsStandard", SqlDbType.Bit, 1);
                parameter.Value = model.IsStandard.Value; paramList.Add(parameter);
            }

            if (model.IsFoodAdd.HasValue)
            {
                colList.Append("[IsFoodAdd] = @IsFoodAdd,");
                SqlParameter parameter = new SqlParameter("@IsFoodAdd", SqlDbType.Bit, 1);
                parameter.Value = model.IsFoodAdd.Value; paramList.Add(parameter);
            }

            if (model.IsOfferRoom.HasValue)
            {
                colList.Append("[IsOfferRoom] = @IsOfferRoom,");
                SqlParameter parameter = new SqlParameter("@IsOfferRoom", SqlDbType.Bit, 1);
                parameter.Value = model.IsOfferRoom.Value; paramList.Add(parameter);
            }

            if (model.IsOfferFood.HasValue)
            {
                colList.Append("[IsOfferFood] = @IsOfferFood,");
                SqlParameter parameter = new SqlParameter("@IsOfferFood", SqlDbType.Bit, 1);
                parameter.Value = model.IsOfferFood.Value; paramList.Add(parameter);
            }

            if (model.IsFiveInsurance.HasValue)
            {
                colList.Append("[IsFiveInsurance] = @IsFiveInsurance,");
                SqlParameter parameter = new SqlParameter("@IsFiveInsurance", SqlDbType.Bit, 1);
                parameter.Value = model.IsFiveInsurance.Value; paramList.Add(parameter);
            }

            if (model.Contact != null)
            {
                colList.Append("[Contact] = @Contact,");
                SqlParameter parameter = new SqlParameter("@Contact", SqlDbType.NVarChar, 20);
                parameter.Value = model.Contact;
                paramList.Add(parameter);
            }

            if (model.IsFund.HasValue)
            {
                colList.Append("[IsFund] = @IsFund,");
                SqlParameter parameter = new SqlParameter("@IsFund", SqlDbType.Bit, 1);
                parameter.Value = model.IsFund.Value; paramList.Add(parameter);
            }

            if (model.IsCarFare.HasValue)
            {
                colList.Append("[IsCarFare] = @IsCarFare,");
                SqlParameter parameter = new SqlParameter("@IsCarFare", SqlDbType.Bit, 1);
                parameter.Value = model.IsCarFare.Value; paramList.Add(parameter);
            }

            if (model.IsYearGuarantee.HasValue)
            {
                colList.Append("[IsYearGuarantee] = @IsYearGuarantee,");
                SqlParameter parameter = new SqlParameter("@IsYearGuarantee", SqlDbType.Bit, 1);
                parameter.Value = model.IsYearGuarantee.Value; paramList.Add(parameter);
            }

            if (model.Balance != decimal.MinValue)
            {
                colList.Append("[Balance] = @Balance,");
                SqlParameter parameter = new SqlParameter("@Balance", SqlDbType.Decimal, 9);
                parameter.Value = model.Balance;
                paramList.Add(parameter);
            }

            if (model.IsReceive.HasValue)
            {
                colList.Append("[IsReceive] = @IsReceive,");
                SqlParameter parameter = new SqlParameter("@IsReceive", SqlDbType.Bit, 1);
                parameter.Value = model.IsReceive.Value; paramList.Add(parameter);
            }

            if (model.ReceiveEndTime.HasValue)
            {
                colList.Append("[ReceiveEndTime] = @ReceiveEndTime,");
                SqlParameter parameter = new SqlParameter("@ReceiveEndTime", SqlDbType.DateTime);
                if (model.ReceiveEndTime.Value != DateTime.MinValue)
                    parameter.Value = model.ReceiveEndTime.Value;
                else
                    parameter.Value = DBNull.Value;
                paramList.Add(parameter);
            }

            if (model.ReceiveAddress != null)
            {
                colList.Append("[ReceiveAddress] = @ReceiveAddress,");
                SqlParameter parameter = new SqlParameter("@ReceiveAddress", SqlDbType.NVarChar, 50);
                parameter.Value = model.ReceiveAddress;
                paramList.Add(parameter);
            }

            if (model.TotalSignUp != Int32.MinValue)
            {
                colList.Append("[TotalSignUp] = @TotalSignUp,");
                SqlParameter parameter = new SqlParameter("@TotalSignUp", SqlDbType.Int, 4);
                parameter.Value = model.TotalSignUp;
                paramList.Add(parameter);
            }

            if (model.CurSignUp != Int32.MinValue)
            {
                colList.Append("[CurSignUp] = @CurSignUp,");
                SqlParameter parameter = new SqlParameter("@CurSignUp", SqlDbType.Int, 4);
                parameter.Value = model.CurSignUp;
                paramList.Add(parameter);
            }

            if (model.ReceiveTimes != Int32.MinValue)
            {
                colList.Append("[ReceiveTimes] = @ReceiveTimes,");
                SqlParameter parameter = new SqlParameter("@ReceiveTimes", SqlDbType.Int, 4);
                parameter.Value = model.ReceiveTimes;
                paramList.Add(parameter);
            }

            if (model.AreaID != null)
            {
                colList.Append("[AreaID] = @AreaID,");
                SqlParameter parameter = new SqlParameter("@AreaID", SqlDbType.NVarChar, 20);
                parameter.Value = model.AreaID;
                paramList.Add(parameter);
            }

            if (model.Logo != null)
            {
                colList.Append("[Logo] = @Logo,");
                SqlParameter parameter = new SqlParameter("@Logo", SqlDbType.NVarChar, 50);
                parameter.Value = model.Logo;
                paramList.Add(parameter);
            }

            if (model.Area != null)
            {
                colList.Append("[Area] = @Area,");
                SqlParameter parameter = new SqlParameter("@Area", SqlDbType.NVarChar, 50);
                parameter.Value = model.Area;
                paramList.Add(parameter);
            }

            if (model.Email != null)
            {
                colList.Append("[Email] = @Email,");
                SqlParameter parameter = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                parameter.Value = model.Email;
                paramList.Add(parameter);
            }

            if (model.QQ != null)
            {
                colList.Append("[QQ] = @QQ,");
                SqlParameter parameter = new SqlParameter("@QQ", SqlDbType.NVarChar, 20);
                parameter.Value = model.QQ;
                paramList.Add(parameter);
            }

            if (model.Phone != null)
            {
                colList.Append("[Phone] = @Phone,");
                SqlParameter parameter = new SqlParameter("@Phone", SqlDbType.NVarChar, 50);
                parameter.Value = model.Phone;
                paramList.Add(parameter);
            }

            if (model.OtherPhone != null)
            {
                colList.Append("[OtherPhone] = @OtherPhone,");
                SqlParameter parameter = new SqlParameter("@OtherPhone", SqlDbType.NVarChar, 50);
                parameter.Value = model.OtherPhone;
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
        public static NH.Model.Company GetModel(int Id)
        {
            NH.Model.Company model = new NH.Model.Company();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Company GetModel(NH.Model.Company model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Address, HomePage, Space, EmployeeQty, Camera, Studio, Description, IdentityVerified, LevelID, VerifyStatus, CompanyName, ExpireDate, ViewCount, IsVerify, VipOpenType, JobRefreshTime, IsStandard, IsFoodAdd, IsOfferRoom, IsOfferFood, IsFiveInsurance, Contact, IsFund, IsCarFare, IsYearGuarantee, Balance, IsReceive, ReceiveEndTime, ReceiveAddress, TotalSignUp, CurSignUp, ReceiveTimes, AreaID, Logo, Area, Email, QQ, Phone, OtherPhone ");
            strSql.Append(" from [Company] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Company();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            model.Address = row["Address"].ToString();

            model.HomePage = row["HomePage"].ToString();

            model.Space = row["Space"].ToString();

            model.EmployeeQty = row["EmployeeQty"].ToString();

            model.Camera = row["Camera"].ToString();

            model.Studio = row["Studio"].ToString();

            model.Description = row["Description"].ToString();


            if (row["IdentityVerified"].ToString() != "")
            {
                if ((row["IdentityVerified"].ToString() == "1") || (row["IdentityVerified"].ToString().ToLower() == "true"))
                {
                    model.IdentityVerified = true;
                }
                else
                {
                    model.IdentityVerified = false;
                }
            }

            if (row["LevelID"].ToString() != "")
            {
                model.LevelID = int.Parse(row["LevelID"].ToString());
            }

            if (row["VerifyStatus"].ToString() != "")
            {
                model.VerifyStatus = int.Parse(row["VerifyStatus"].ToString());
            }

            model.CompanyName = row["CompanyName"].ToString();

            if (row["ExpireDate"].ToString() != "")
            {
                model.ExpireDate = DateTime.Parse(row["ExpireDate"].ToString());
            }

            if (row["ViewCount"].ToString() != "")
            {
                model.ViewCount = int.Parse(row["ViewCount"].ToString());
            }


            if (row["IsVerify"].ToString() != "")
            {
                if ((row["IsVerify"].ToString() == "1") || (row["IsVerify"].ToString().ToLower() == "true"))
                {
                    model.IsVerify = true;
                }
                else
                {
                    model.IsVerify = false;
                }
            }

            if (row["VipOpenType"].ToString() != "")
            {
                model.VipOpenType = int.Parse(row["VipOpenType"].ToString());
            }

            if (row["JobRefreshTime"].ToString() != "")
            {
                model.JobRefreshTime = DateTime.Parse(row["JobRefreshTime"].ToString());
            }


            if (row["IsStandard"].ToString() != "")
            {
                if ((row["IsStandard"].ToString() == "1") || (row["IsStandard"].ToString().ToLower() == "true"))
                {
                    model.IsStandard = true;
                }
                else
                {
                    model.IsStandard = false;
                }
            }


            if (row["IsFoodAdd"].ToString() != "")
            {
                if ((row["IsFoodAdd"].ToString() == "1") || (row["IsFoodAdd"].ToString().ToLower() == "true"))
                {
                    model.IsFoodAdd = true;
                }
                else
                {
                    model.IsFoodAdd = false;
                }
            }


            if (row["IsOfferRoom"].ToString() != "")
            {
                if ((row["IsOfferRoom"].ToString() == "1") || (row["IsOfferRoom"].ToString().ToLower() == "true"))
                {
                    model.IsOfferRoom = true;
                }
                else
                {
                    model.IsOfferRoom = false;
                }
            }


            if (row["IsOfferFood"].ToString() != "")
            {
                if ((row["IsOfferFood"].ToString() == "1") || (row["IsOfferFood"].ToString().ToLower() == "true"))
                {
                    model.IsOfferFood = true;
                }
                else
                {
                    model.IsOfferFood = false;
                }
            }


            if (row["IsFiveInsurance"].ToString() != "")
            {
                if ((row["IsFiveInsurance"].ToString() == "1") || (row["IsFiveInsurance"].ToString().ToLower() == "true"))
                {
                    model.IsFiveInsurance = true;
                }
                else
                {
                    model.IsFiveInsurance = false;
                }
            }

            model.Contact = row["Contact"].ToString();


            if (row["IsFund"].ToString() != "")
            {
                if ((row["IsFund"].ToString() == "1") || (row["IsFund"].ToString().ToLower() == "true"))
                {
                    model.IsFund = true;
                }
                else
                {
                    model.IsFund = false;
                }
            }


            if (row["IsCarFare"].ToString() != "")
            {
                if ((row["IsCarFare"].ToString() == "1") || (row["IsCarFare"].ToString().ToLower() == "true"))
                {
                    model.IsCarFare = true;
                }
                else
                {
                    model.IsCarFare = false;
                }
            }


            if (row["IsYearGuarantee"].ToString() != "")
            {
                if ((row["IsYearGuarantee"].ToString() == "1") || (row["IsYearGuarantee"].ToString().ToLower() == "true"))
                {
                    model.IsYearGuarantee = true;
                }
                else
                {
                    model.IsYearGuarantee = false;
                }
            }

            if (row["Balance"].ToString() != "")
            {
                model.Balance = decimal.Parse(row["Balance"].ToString());
            }


            if (row["IsReceive"].ToString() != "")
            {
                if ((row["IsReceive"].ToString() == "1") || (row["IsReceive"].ToString().ToLower() == "true"))
                {
                    model.IsReceive = true;
                }
                else
                {
                    model.IsReceive = false;
                }
            }

            if (row["ReceiveEndTime"].ToString() != "")
            {
                model.ReceiveEndTime = DateTime.Parse(row["ReceiveEndTime"].ToString());
            }

            model.ReceiveAddress = row["ReceiveAddress"].ToString();

            if (row["TotalSignUp"].ToString() != "")
            {
                model.TotalSignUp = int.Parse(row["TotalSignUp"].ToString());
            }

            if (row["CurSignUp"].ToString() != "")
            {
                model.CurSignUp = int.Parse(row["CurSignUp"].ToString());
            }

            if (row["ReceiveTimes"].ToString() != "")
            {
                model.ReceiveTimes = int.Parse(row["ReceiveTimes"].ToString());
            }

            model.AreaID = row["AreaID"].ToString();

            model.Logo = row["Logo"].ToString();

            model.Area = row["Area"].ToString();

            model.Email = row["Email"].ToString();

            model.QQ = row["QQ"].ToString();

            model.Phone = row["Phone"].ToString();

            model.OtherPhone = row["OtherPhone"].ToString();

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
            strSql.Append(" FROM [Company] ");
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
            strSql.Append(" FROM [Company] ");
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



