using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Member
    /// </summary>
    public static partial class Member
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Member model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Member](nolock)");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(NH.Model.Member model)
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

            if (model.CurAddr != null)
            {
                colList.Append("[CurAddr],");
                colParamList.Append("@CurAddr,");
                parameter = new SqlParameter("@CurAddr", SqlDbType.NVarChar, 50);
                parameter.Value = model.CurAddr;
                sqlParamList.Add(parameter);
            }

            if (model.ExperienceID != Int32.MinValue)
            {
                colList.Append("[ExperienceID],");
                colParamList.Append("@ExperienceID,");
                parameter = new SqlParameter("@ExperienceID", SqlDbType.Int, 4);
                parameter.Value = model.ExperienceID;
                sqlParamList.Add(parameter);
            }

            if (model.DegreeID != Int32.MinValue)
            {
                colList.Append("[DegreeID],");
                colParamList.Append("@DegreeID,");
                parameter = new SqlParameter("@DegreeID", SqlDbType.Int, 4);
                parameter.Value = model.DegreeID;
                sqlParamList.Add(parameter);
            }

            if (model.DegreeName != null)
            {
                colList.Append("[DegreeName],");
                colParamList.Append("@DegreeName,");
                parameter = new SqlParameter("@DegreeName", SqlDbType.NVarChar, 20);
                parameter.Value = model.DegreeName;
                sqlParamList.Add(parameter);
            }

            if (model.Mobile != null)
            {
                colList.Append("[Mobile],");
                colParamList.Append("@Mobile,");
                parameter = new SqlParameter("@Mobile", SqlDbType.NVarChar, 50);
                parameter.Value = model.Mobile;
                sqlParamList.Add(parameter);
            }

            if (model.MobileVerified.HasValue)
            {
                colList.Append("[MobileVerified],");
                colParamList.Append("@MobileVerified,");
                parameter = new SqlParameter("@MobileVerified", SqlDbType.Bit, 1);
                parameter.Value = model.MobileVerified.Value;
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

            if (model.QQ != null)
            {
                colList.Append("[QQ],");
                colParamList.Append("@QQ,");
                parameter = new SqlParameter("@QQ", SqlDbType.NVarChar, 50);
                parameter.Value = model.QQ;
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

            if (model.Address != null)
            {
                colList.Append("[Address],");
                colParamList.Append("@Address,");
                parameter = new SqlParameter("@Address", SqlDbType.NVarChar, 50);
                parameter.Value = model.Address;
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

            if (model.HomePage != null)
            {
                colList.Append("[HomePage],");
                colParamList.Append("@HomePage,");
                parameter = new SqlParameter("@HomePage", SqlDbType.NVarChar, 50);
                parameter.Value = model.HomePage;
                sqlParamList.Add(parameter);
            }

            if (model.IsHousing != Int32.MinValue)
            {
                colList.Append("[IsHousing],");
                colParamList.Append("@IsHousing,");
                parameter = new SqlParameter("@IsHousing", SqlDbType.Int, 4);
                parameter.Value = model.IsHousing;
                sqlParamList.Add(parameter);
            }

            if (model.IsCarFare != Int32.MinValue)
            {
                colList.Append("[IsCarFare],");
                colParamList.Append("@IsCarFare,");
                parameter = new SqlParameter("@IsCarFare", SqlDbType.Int, 4);
                parameter.Value = model.IsCarFare;
                sqlParamList.Add(parameter);
            }

            if (model.JobCategoryIDs != null)
            {
                colList.Append("[JobCategoryIDs],");
                colParamList.Append("@JobCategoryIDs,");
                parameter = new SqlParameter("@JobCategoryIDs", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobCategoryIDs;
                sqlParamList.Add(parameter);
            }

            if (model.JobCategoryName != null)
            {
                colList.Append("[JobCategoryName],");
                colParamList.Append("@JobCategoryName,");
                parameter = new SqlParameter("@JobCategoryName", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobCategoryName;
                sqlParamList.Add(parameter);
            }

            if (model.SalaryID != Int32.MinValue)
            {
                colList.Append("[SalaryID],");
                colParamList.Append("@SalaryID,");
                parameter = new SqlParameter("@SalaryID", SqlDbType.Int, 4);
                parameter.Value = model.SalaryID;
                sqlParamList.Add(parameter);
            }

            if (model.SalaryName != null)
            {
                colList.Append("[SalaryName],");
                colParamList.Append("@SalaryName,");
                parameter = new SqlParameter("@SalaryName", SqlDbType.NVarChar, 20);
                parameter.Value = model.SalaryName;
                sqlParamList.Add(parameter);
            }

            if (model.Commission.HasValue)
            {
                colList.Append("[Commission],");
                colParamList.Append("@Commission,");
                parameter = new SqlParameter("@Commission", SqlDbType.Bit, 1);
                parameter.Value = model.Commission.Value;
                sqlParamList.Add(parameter);
            }

            if (model.JobTypeID != null)
            {
                colList.Append("[JobTypeID],");
                colParamList.Append("@JobTypeID,");
                parameter = new SqlParameter("@JobTypeID", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobTypeID;
                sqlParamList.Add(parameter);
            }

            if (model.JobTypeName != null)
            {
                colList.Append("[JobTypeName],");
                colParamList.Append("@JobTypeName,");
                parameter = new SqlParameter("@JobTypeName", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobTypeName;
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

            if (model.JobAddrID != null)
            {
                colList.Append("[JobAddrID],");
                colParamList.Append("@JobAddrID,");
                parameter = new SqlParameter("@JobAddrID", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobAddrID;
                sqlParamList.Add(parameter);
            }

            if (model.JobAddr != null)
            {
                colList.Append("[JobAddr],");
                colParamList.Append("@JobAddr,");
                parameter = new SqlParameter("@JobAddr", SqlDbType.NVarChar, 100);
                parameter.Value = model.JobAddr;
                sqlParamList.Add(parameter);
            }

            if (model.Resume != null)
            {
                colList.Append("[Resume],");
                colParamList.Append("@Resume,");
                parameter = new SqlParameter("@Resume", SqlDbType.NText);
                parameter.Value = model.Resume;
                sqlParamList.Add(parameter);
            }

            if (model.SelfEvaluation != null)
            {
                colList.Append("[SelfEvaluation],");
                colParamList.Append("@SelfEvaluation,");
                parameter = new SqlParameter("@SelfEvaluation", SqlDbType.NText);
                parameter.Value = model.SelfEvaluation;
                sqlParamList.Add(parameter);
            }

            if (model.IdentityNo != null)
            {
                colList.Append("[IdentityNo],");
                colParamList.Append("@IdentityNo,");
                parameter = new SqlParameter("@IdentityNo", SqlDbType.NVarChar, 50);
                parameter.Value = model.IdentityNo;
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

            if (model.IsShow.HasValue)
            {
                colList.Append("[IsShow],");
                colParamList.Append("@IsShow,");
                parameter = new SqlParameter("@IsShow", SqlDbType.Bit, 1);
                parameter.Value = model.IsShow.Value;
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

            if (model.WorksCount != Int32.MinValue)
            {
                colList.Append("[WorksCount],");
                colParamList.Append("@WorksCount,");
                parameter = new SqlParameter("@WorksCount", SqlDbType.Int, 4);
                parameter.Value = model.WorksCount;
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

            if (model.Birthday.HasValue)
            {
                colList.Append("[Birthday],");
                colParamList.Append("@Birthday,");
                parameter = new SqlParameter("@Birthday", SqlDbType.SmallDateTime);
                if (model.Birthday.Value != DateTime.MinValue)
                    parameter.Value = model.Birthday.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.IsGood.HasValue)
            {
                colList.Append("[IsGood],");
                colParamList.Append("@IsGood,");
                parameter = new SqlParameter("@IsGood", SqlDbType.Bit, 1);
                parameter.Value = model.IsGood.Value;
                sqlParamList.Add(parameter);
            }

            if (model.ComeTimeID != Int32.MinValue)
            {
                colList.Append("[ComeTimeID],");
                colParamList.Append("@ComeTimeID,");
                parameter = new SqlParameter("@ComeTimeID", SqlDbType.Int, 4);
                parameter.Value = model.ComeTimeID;
                sqlParamList.Add(parameter);
            }

            if (model.ComeTimeDesc != null)
            {
                colList.Append("[ComeTimeDesc],");
                colParamList.Append("@ComeTimeDesc,");
                parameter = new SqlParameter("@ComeTimeDesc", SqlDbType.NVarChar, 10);
                parameter.Value = model.ComeTimeDesc;
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

            if (model.Weixin != null)
            {
                colList.Append("[Weixin],");
                colParamList.Append("@Weixin,");
                parameter = new SqlParameter("@Weixin", SqlDbType.NVarChar, 50);
                parameter.Value = model.Weixin;
                sqlParamList.Add(parameter);
            }

            if (model.Height != Int32.MinValue)
            {
                colList.Append("[Height],");
                colParamList.Append("@Height,");
                parameter = new SqlParameter("@Height", SqlDbType.Int, 4);
                parameter.Value = model.Height;
                sqlParamList.Add(parameter);
            }

            if (model.Marriage != Int32.MinValue)
            {
                colList.Append("[Marriage],");
                colParamList.Append("@Marriage,");
                parameter = new SqlParameter("@Marriage", SqlDbType.Int, 4);
                parameter.Value = model.Marriage;
                sqlParamList.Add(parameter);
            }

            if (model.ResidenceAddrID != null)
            {
                colList.Append("[ResidenceAddrID],");
                colParamList.Append("@ResidenceAddrID,");
                parameter = new SqlParameter("@ResidenceAddrID", SqlDbType.NVarChar, 20);
                parameter.Value = model.ResidenceAddrID;
                sqlParamList.Add(parameter);
            }

            if (model.Residence != null)
            {
                colList.Append("[Residence],");
                colParamList.Append("@Residence,");
                parameter = new SqlParameter("@Residence", SqlDbType.NVarChar, 50);
                parameter.Value = model.Residence;
                sqlParamList.Add(parameter);
            }

            if (model.CurrAddrID != null)
            {
                colList.Append("[CurrAddrID],");
                colParamList.Append("@CurrAddrID,");
                parameter = new SqlParameter("@CurrAddrID", SqlDbType.NVarChar, 20);
                parameter.Value = model.CurrAddrID;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [Member] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));

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
            strSql.Append("delete from [Member] ");
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
        public static bool Update(NH.Model.Member model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Member] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id  ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Member model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.CurAddr != null)
            {
                colList.Append("[CurAddr] = @CurAddr,");
                SqlParameter parameter = new SqlParameter("@CurAddr", SqlDbType.NVarChar, 50);
                parameter.Value = model.CurAddr;
                paramList.Add(parameter);
            }

            if (model.ExperienceID != Int32.MinValue)
            {
                colList.Append("[ExperienceID] = @ExperienceID,");
                SqlParameter parameter = new SqlParameter("@ExperienceID", SqlDbType.Int, 4);
                parameter.Value = model.ExperienceID;
                paramList.Add(parameter);
            }

            if (model.DegreeID != Int32.MinValue)
            {
                colList.Append("[DegreeID] = @DegreeID,");
                SqlParameter parameter = new SqlParameter("@DegreeID", SqlDbType.Int, 4);
                parameter.Value = model.DegreeID;
                paramList.Add(parameter);
            }

            if (model.DegreeName != null)
            {
                colList.Append("[DegreeName] = @DegreeName,");
                SqlParameter parameter = new SqlParameter("@DegreeName", SqlDbType.NVarChar, 20);
                parameter.Value = model.DegreeName;
                paramList.Add(parameter);
            }

            if (model.Mobile != null)
            {
                colList.Append("[Mobile] = @Mobile,");
                SqlParameter parameter = new SqlParameter("@Mobile", SqlDbType.NVarChar, 50);
                parameter.Value = model.Mobile;
                paramList.Add(parameter);
            }

            if (model.MobileVerified.HasValue)
            {
                colList.Append("[MobileVerified] = @MobileVerified,");
                SqlParameter parameter = new SqlParameter("@MobileVerified", SqlDbType.Bit, 1);
                parameter.Value = model.MobileVerified.Value; paramList.Add(parameter);
            }

            if (model.Phone != null)
            {
                colList.Append("[Phone] = @Phone,");
                SqlParameter parameter = new SqlParameter("@Phone", SqlDbType.NVarChar, 50);
                parameter.Value = model.Phone;
                paramList.Add(parameter);
            }

            if (model.QQ != null)
            {
                colList.Append("[QQ] = @QQ,");
                SqlParameter parameter = new SqlParameter("@QQ", SqlDbType.NVarChar, 50);
                parameter.Value = model.QQ;
                paramList.Add(parameter);
            }

            if (model.Email != null)
            {
                colList.Append("[Email] = @Email,");
                SqlParameter parameter = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                parameter.Value = model.Email;
                paramList.Add(parameter);
            }

            if (model.Address != null)
            {
                colList.Append("[Address] = @Address,");
                SqlParameter parameter = new SqlParameter("@Address", SqlDbType.NVarChar, 50);
                parameter.Value = model.Address;
                paramList.Add(parameter);
            }

            if (model.Realname != null)
            {
                colList.Append("[Realname] = @Realname,");
                SqlParameter parameter = new SqlParameter("@Realname", SqlDbType.NVarChar, 20);
                parameter.Value = model.Realname;
                paramList.Add(parameter);
            }

            if (model.HomePage != null)
            {
                colList.Append("[HomePage] = @HomePage,");
                SqlParameter parameter = new SqlParameter("@HomePage", SqlDbType.NVarChar, 50);
                parameter.Value = model.HomePage;
                paramList.Add(parameter);
            }

            if (model.IsHousing != Int32.MinValue)
            {
                colList.Append("[IsHousing] = @IsHousing,");
                SqlParameter parameter = new SqlParameter("@IsHousing", SqlDbType.Int, 4);
                parameter.Value = model.IsHousing;
                paramList.Add(parameter);
            }

            if (model.IsCarFare != Int32.MinValue)
            {
                colList.Append("[IsCarFare] = @IsCarFare,");
                SqlParameter parameter = new SqlParameter("@IsCarFare", SqlDbType.Int, 4);
                parameter.Value = model.IsCarFare;
                paramList.Add(parameter);
            }

            if (model.JobCategoryIDs != null)
            {
                colList.Append("[JobCategoryIDs] = @JobCategoryIDs,");
                SqlParameter parameter = new SqlParameter("@JobCategoryIDs", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobCategoryIDs;
                paramList.Add(parameter);
            }

            if (model.JobCategoryName != null)
            {
                colList.Append("[JobCategoryName] = @JobCategoryName,");
                SqlParameter parameter = new SqlParameter("@JobCategoryName", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobCategoryName;
                paramList.Add(parameter);
            }

            if (model.SalaryID != Int32.MinValue)
            {
                colList.Append("[SalaryID] = @SalaryID,");
                SqlParameter parameter = new SqlParameter("@SalaryID", SqlDbType.Int, 4);
                parameter.Value = model.SalaryID;
                paramList.Add(parameter);
            }

            if (model.SalaryName != null)
            {
                colList.Append("[SalaryName] = @SalaryName,");
                SqlParameter parameter = new SqlParameter("@SalaryName", SqlDbType.NVarChar, 20);
                parameter.Value = model.SalaryName;
                paramList.Add(parameter);
            }

            if (model.Commission.HasValue)
            {
                colList.Append("[Commission] = @Commission,");
                SqlParameter parameter = new SqlParameter("@Commission", SqlDbType.Bit, 1);
                parameter.Value = model.Commission.Value; paramList.Add(parameter);
            }

            if (model.JobTypeID != null)
            {
                colList.Append("[JobTypeID] = @JobTypeID,");
                SqlParameter parameter = new SqlParameter("@JobTypeID", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobTypeID;
                paramList.Add(parameter);
            }

            if (model.JobTypeName != null)
            {
                colList.Append("[JobTypeName] = @JobTypeName,");
                SqlParameter parameter = new SqlParameter("@JobTypeName", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobTypeName;
                paramList.Add(parameter);
            }

            if (model.Sex != Int32.MinValue)
            {
                colList.Append("[Sex] = @Sex,");
                SqlParameter parameter = new SqlParameter("@Sex", SqlDbType.Int, 4);
                parameter.Value = model.Sex;
                paramList.Add(parameter);
            }

            if (model.JobAddrID != null)
            {
                colList.Append("[JobAddrID] = @JobAddrID,");
                SqlParameter parameter = new SqlParameter("@JobAddrID", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobAddrID;
                paramList.Add(parameter);
            }

            if (model.JobAddr != null)
            {
                colList.Append("[JobAddr] = @JobAddr,");
                SqlParameter parameter = new SqlParameter("@JobAddr", SqlDbType.NVarChar, 100);
                parameter.Value = model.JobAddr;
                paramList.Add(parameter);
            }

            if (model.Resume != null)
            {
                colList.Append("[Resume] = @Resume,");
                SqlParameter parameter = new SqlParameter("@Resume", SqlDbType.NText);
                parameter.Value = model.Resume;
                paramList.Add(parameter);
            }

            if (model.SelfEvaluation != null)
            {
                colList.Append("[SelfEvaluation] = @SelfEvaluation,");
                SqlParameter parameter = new SqlParameter("@SelfEvaluation", SqlDbType.NText);
                parameter.Value = model.SelfEvaluation;
                paramList.Add(parameter);
            }

            if (model.IdentityNo != null)
            {
                colList.Append("[IdentityNo] = @IdentityNo,");
                SqlParameter parameter = new SqlParameter("@IdentityNo", SqlDbType.NVarChar, 50);
                parameter.Value = model.IdentityNo;
                paramList.Add(parameter);
            }

            if (model.IdentityVerified.HasValue)
            {
                colList.Append("[IdentityVerified] = @IdentityVerified,");
                SqlParameter parameter = new SqlParameter("@IdentityVerified", SqlDbType.Bit, 1);
                parameter.Value = model.IdentityVerified.Value; paramList.Add(parameter);
            }

            if (model.IsShow.HasValue)
            {
                colList.Append("[IsShow] = @IsShow,");
                SqlParameter parameter = new SqlParameter("@IsShow", SqlDbType.Bit, 1);
                parameter.Value = model.IsShow.Value; paramList.Add(parameter);
            }

            if (model.ViewCount != Int32.MinValue)
            {
                colList.Append("[ViewCount] = @ViewCount,");
                SqlParameter parameter = new SqlParameter("@ViewCount", SqlDbType.Int, 4);
                parameter.Value = model.ViewCount;
                paramList.Add(parameter);
            }

            if (model.WorksCount != Int32.MinValue)
            {
                colList.Append("[WorksCount] = @WorksCount,");
                SqlParameter parameter = new SqlParameter("@WorksCount", SqlDbType.Int, 4);
                parameter.Value = model.WorksCount;
                paramList.Add(parameter);
            }

            if (model.VerifyStatus != Int32.MinValue)
            {
                colList.Append("[VerifyStatus] = @VerifyStatus,");
                SqlParameter parameter = new SqlParameter("@VerifyStatus", SqlDbType.Int, 4);
                parameter.Value = model.VerifyStatus;
                paramList.Add(parameter);
            }

            if (model.Birthday.HasValue)
            {
                colList.Append("[Birthday] = @Birthday,");
                SqlParameter parameter = new SqlParameter("@Birthday", SqlDbType.SmallDateTime);
                if (model.Birthday.Value != DateTime.MinValue)
                    parameter.Value = model.Birthday.Value;
                else
                    parameter.Value = DBNull.Value;
                paramList.Add(parameter);
            }

            if (model.IsGood.HasValue)
            {
                colList.Append("[IsGood] = @IsGood,");
                SqlParameter parameter = new SqlParameter("@IsGood", SqlDbType.Bit, 1);
                parameter.Value = model.IsGood.Value; paramList.Add(parameter);
            }

            if (model.ComeTimeID != Int32.MinValue)
            {
                colList.Append("[ComeTimeID] = @ComeTimeID,");
                SqlParameter parameter = new SqlParameter("@ComeTimeID", SqlDbType.Int, 4);
                parameter.Value = model.ComeTimeID;
                paramList.Add(parameter);
            }

            if (model.ComeTimeDesc != null)
            {
                colList.Append("[ComeTimeDesc] = @ComeTimeDesc,");
                SqlParameter parameter = new SqlParameter("@ComeTimeDesc", SqlDbType.NVarChar, 10);
                parameter.Value = model.ComeTimeDesc;
                paramList.Add(parameter);
            }

            if (model.IsVerify.HasValue)
            {
                colList.Append("[IsVerify] = @IsVerify,");
                SqlParameter parameter = new SqlParameter("@IsVerify", SqlDbType.Bit, 1);
                parameter.Value = model.IsVerify.Value; paramList.Add(parameter);
            }

            if (model.Weixin != null)
            {
                colList.Append("[Weixin] = @Weixin,");
                SqlParameter parameter = new SqlParameter("@Weixin", SqlDbType.NVarChar, 50);
                parameter.Value = model.Weixin;
                paramList.Add(parameter);
            }

            if (model.Height != Int32.MinValue)
            {
                colList.Append("[Height] = @Height,");
                SqlParameter parameter = new SqlParameter("@Height", SqlDbType.Int, 4);
                parameter.Value = model.Height;
                paramList.Add(parameter);
            }

            if (model.Marriage != Int32.MinValue)
            {
                colList.Append("[Marriage] = @Marriage,");
                SqlParameter parameter = new SqlParameter("@Marriage", SqlDbType.Int, 4);
                parameter.Value = model.Marriage;
                paramList.Add(parameter);
            }

            if (model.ResidenceAddrID != null)
            {
                colList.Append("[ResidenceAddrID] = @ResidenceAddrID,");
                SqlParameter parameter = new SqlParameter("@ResidenceAddrID", SqlDbType.NVarChar, 20);
                parameter.Value = model.ResidenceAddrID;
                paramList.Add(parameter);
            }

            if (model.Residence != null)
            {
                colList.Append("[Residence] = @Residence,");
                SqlParameter parameter = new SqlParameter("@Residence", SqlDbType.NVarChar, 50);
                parameter.Value = model.Residence;
                paramList.Add(parameter);
            }

            if (model.CurrAddrID != null)
            {
                colList.Append("[CurrAddrID] = @CurrAddrID,");
                SqlParameter parameter = new SqlParameter("@CurrAddrID", SqlDbType.NVarChar, 20);
                parameter.Value = model.CurrAddrID;
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
        public static NH.Model.Member GetModel(int Id)
        {
            NH.Model.Member model = new NH.Model.Member();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Member GetModel(NH.Model.Member model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, CurAddr, ExperienceID, DegreeID, DegreeName, Mobile, MobileVerified, Phone, QQ, Email, Address, Realname, HomePage, IsHousing, IsCarFare, JobCategoryIDs, JobCategoryName, SalaryID, SalaryName, Commission, JobTypeID, JobTypeName, Sex, JobAddrID, JobAddr, Resume, SelfEvaluation, IdentityNo, IdentityVerified, IsShow, ViewCount, WorksCount, VerifyStatus, Birthday, IsGood, ComeTimeID, ComeTimeDesc, IsVerify, Weixin, Height, Marriage, ResidenceAddrID, Residence, CurrAddrID ");
            strSql.Append(" from [Member] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Member();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            model.CurAddr = row["CurAddr"].ToString();

            if (row["ExperienceID"].ToString() != "")
            {
                model.ExperienceID = int.Parse(row["ExperienceID"].ToString());
            }

            if (row["DegreeID"].ToString() != "")
            {
                model.DegreeID = int.Parse(row["DegreeID"].ToString());
            }

            model.DegreeName = row["DegreeName"].ToString();

            model.Mobile = row["Mobile"].ToString();


            if (row["MobileVerified"].ToString() != "")
            {
                if ((row["MobileVerified"].ToString() == "1") || (row["MobileVerified"].ToString().ToLower() == "true"))
                {
                    model.MobileVerified = true;
                }
                else
                {
                    model.MobileVerified = false;
                }
            }

            model.Phone = row["Phone"].ToString();

            model.QQ = row["QQ"].ToString();

            model.Email = row["Email"].ToString();

            model.Address = row["Address"].ToString();

            model.Realname = row["Realname"].ToString();

            model.HomePage = row["HomePage"].ToString();

            if (row["IsHousing"].ToString() != "")
            {
                model.IsHousing = int.Parse(row["IsHousing"].ToString());
            }

            if (row["IsCarFare"].ToString() != "")
            {
                model.IsCarFare = int.Parse(row["IsCarFare"].ToString());
            }

            model.JobCategoryIDs = row["JobCategoryIDs"].ToString();

            model.JobCategoryName = row["JobCategoryName"].ToString();

            if (row["SalaryID"].ToString() != "")
            {
                model.SalaryID = int.Parse(row["SalaryID"].ToString());
            }

            model.SalaryName = row["SalaryName"].ToString();


            if (row["Commission"].ToString() != "")
            {
                if ((row["Commission"].ToString() == "1") || (row["Commission"].ToString().ToLower() == "true"))
                {
                    model.Commission = true;
                }
                else
                {
                    model.Commission = false;
                }
            }

            model.JobTypeID = row["JobTypeID"].ToString();

            model.JobTypeName = row["JobTypeName"].ToString();

            if (row["Sex"].ToString() != "")
            {
                model.Sex = int.Parse(row["Sex"].ToString());
            }

            model.JobAddrID = row["JobAddrID"].ToString();

            model.JobAddr = row["JobAddr"].ToString();

            model.Resume = row["Resume"].ToString();

            model.SelfEvaluation = row["SelfEvaluation"].ToString();

            model.IdentityNo = row["IdentityNo"].ToString();


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


            if (row["IsShow"].ToString() != "")
            {
                if ((row["IsShow"].ToString() == "1") || (row["IsShow"].ToString().ToLower() == "true"))
                {
                    model.IsShow = true;
                }
                else
                {
                    model.IsShow = false;
                }
            }

            if (row["ViewCount"].ToString() != "")
            {
                model.ViewCount = int.Parse(row["ViewCount"].ToString());
            }

            if (row["WorksCount"].ToString() != "")
            {
                model.WorksCount = int.Parse(row["WorksCount"].ToString());
            }

            if (row["VerifyStatus"].ToString() != "")
            {
                model.VerifyStatus = int.Parse(row["VerifyStatus"].ToString());
            }

            if (row["Birthday"].ToString() != "")
            {
                model.Birthday = DateTime.Parse(row["Birthday"].ToString());
            }


            if (row["IsGood"].ToString() != "")
            {
                if ((row["IsGood"].ToString() == "1") || (row["IsGood"].ToString().ToLower() == "true"))
                {
                    model.IsGood = true;
                }
                else
                {
                    model.IsGood = false;
                }
            }

            if (row["ComeTimeID"].ToString() != "")
            {
                model.ComeTimeID = int.Parse(row["ComeTimeID"].ToString());
            }

            model.ComeTimeDesc = row["ComeTimeDesc"].ToString();


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

            model.Weixin = row["Weixin"].ToString();

            if (row["Height"].ToString() != "")
            {
                model.Height = int.Parse(row["Height"].ToString());
            }

            if (row["Marriage"].ToString() != "")
            {
                model.Marriage = int.Parse(row["Marriage"].ToString());
            }

            model.ResidenceAddrID = row["ResidenceAddrID"].ToString();

            model.Residence = row["Residence"].ToString();

            model.CurrAddrID = row["CurrAddrID"].ToString();

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
            strSql.Append(" FROM [Member] ");
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
            strSql.Append(" FROM [Member] ");
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



