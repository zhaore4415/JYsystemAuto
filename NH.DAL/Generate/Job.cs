using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Job
    /// </summary>
    public static partial class Job
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Job model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Job](nolock)");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Job model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.DegreeName != null)
            {
                colList.Append("[DegreeName],");
                colParamList.Append("@DegreeName,");
                parameter = new SqlParameter("@DegreeName", SqlDbType.NVarChar, 50);
                parameter.Value = model.DegreeName;
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

            if (model.Sex != Int32.MinValue)
            {
                colList.Append("[Sex],");
                colParamList.Append("@Sex,");
                parameter = new SqlParameter("@Sex", SqlDbType.Int, 4);
                parameter.Value = model.Sex;
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

            if (model.IsHousing != Int32.MinValue)
            {
                colList.Append("[IsHousing],");
                colParamList.Append("@IsHousing,");
                parameter = new SqlParameter("@IsHousing", SqlDbType.Int, 4);
                parameter.Value = model.IsHousing;
                sqlParamList.Add(parameter);
            }

            if (model.WorkTime != null)
            {
                colList.Append("[WorkTime],");
                colParamList.Append("@WorkTime,");
                parameter = new SqlParameter("@WorkTime", SqlDbType.NVarChar, 50);
                parameter.Value = model.WorkTime;
                sqlParamList.Add(parameter);
            }

            if (model.Quantity != Int32.MinValue)
            {
                colList.Append("[Quantity],");
                colParamList.Append("@Quantity,");
                parameter = new SqlParameter("@Quantity", SqlDbType.Int, 4);
                parameter.Value = model.Quantity;
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

            if (model.Description != null)
            {
                colList.Append("[Description],");
                colParamList.Append("@Description,");
                parameter = new SqlParameter("@Description", SqlDbType.NText);
                parameter.Value = model.Description;
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

            if (model.JobTitle != null)
            {
                colList.Append("[JobTitle],");
                colParamList.Append("@JobTitle,");
                parameter = new SqlParameter("@JobTitle", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobTitle;
                sqlParamList.Add(parameter);
            }

            if (model.Verified != Int32.MinValue)
            {
                colList.Append("[Verified],");
                colParamList.Append("@Verified,");
                parameter = new SqlParameter("@Verified", SqlDbType.Int, 4);
                parameter.Value = model.Verified;
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

            if (model.ViewCount != Int32.MinValue)
            {
                colList.Append("[ViewCount],");
                colParamList.Append("@ViewCount,");
                parameter = new SqlParameter("@ViewCount", SqlDbType.Int, 4);
                parameter.Value = model.ViewCount;
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

            if (model.RefreshTime != DateTime.MinValue)
            {
                colList.Append("[RefreshTime],");
                colParamList.Append("@RefreshTime,");
                parameter = new SqlParameter("@RefreshTime", SqlDbType.DateTime);
                parameter.Value = model.RefreshTime;
                sqlParamList.Add(parameter);
            }

            if (model.IsFix.HasValue)
            {
                colList.Append("[IsFix],");
                colParamList.Append("@IsFix,");
                parameter = new SqlParameter("@IsFix", SqlDbType.Bit, 1);
                parameter.Value = model.IsFix.Value;
                sqlParamList.Add(parameter);
            }

            if (model.Description_New != null)
            {
                colList.Append("[Description_New],");
                colParamList.Append("@Description_New,");
                parameter = new SqlParameter("@Description_New", SqlDbType.NText);
                parameter.Value = model.Description_New;
                sqlParamList.Add(parameter);
            }

            if (model.SalaryDesc != null)
            {
                colList.Append("[SalaryDesc],");
                colParamList.Append("@SalaryDesc,");
                parameter = new SqlParameter("@SalaryDesc", SqlDbType.NText);
                parameter.Value = model.SalaryDesc;
                sqlParamList.Add(parameter);
            }

            if (model.WorkContent != null)
            {
                colList.Append("[WorkContent],");
                colParamList.Append("@WorkContent,");
                parameter = new SqlParameter("@WorkContent", SqlDbType.NText);
                parameter.Value = model.WorkContent;
                sqlParamList.Add(parameter);
            }

            if (model.Requirements != null)
            {
                colList.Append("[Requirements],");
                colParamList.Append("@Requirements,");
                parameter = new SqlParameter("@Requirements", SqlDbType.NText);
                parameter.Value = model.Requirements;
                sqlParamList.Add(parameter);
            }

            if (model.CompanyID != Int32.MinValue)
            {
                colList.Append("[CompanyID],");
                colParamList.Append("@CompanyID,");
                parameter = new SqlParameter("@CompanyID", SqlDbType.Int, 4);
                parameter.Value = model.CompanyID;
                sqlParamList.Add(parameter);
            }

            if (model.RoomAndFood != null)
            {
                colList.Append("[RoomAndFood],");
                colParamList.Append("@RoomAndFood,");
                parameter = new SqlParameter("@RoomAndFood", SqlDbType.NText);
                parameter.Value = model.RoomAndFood;
                sqlParamList.Add(parameter);
            }

            if (model.Welfare != null)
            {
                colList.Append("[Welfare],");
                colParamList.Append("@Welfare,");
                parameter = new SqlParameter("@Welfare", SqlDbType.NText);
                parameter.Value = model.Welfare;
                sqlParamList.Add(parameter);
            }

            if (model.Jobtitle_New != null)
            {
                colList.Append("[Jobtitle_New],");
                colParamList.Append("@Jobtitle_New,");
                parameter = new SqlParameter("@Jobtitle_New", SqlDbType.NVarChar, 50);
                parameter.Value = model.Jobtitle_New;
                sqlParamList.Add(parameter);
            }

            if (model.SalaryDesc_New != null)
            {
                colList.Append("[SalaryDesc_New],");
                colParamList.Append("@SalaryDesc_New,");
                parameter = new SqlParameter("@SalaryDesc_New", SqlDbType.NText);
                parameter.Value = model.SalaryDesc_New;
                sqlParamList.Add(parameter);
            }

            if (model.WorkContent_New != null)
            {
                colList.Append("[WorkContent_New],");
                colParamList.Append("@WorkContent_New,");
                parameter = new SqlParameter("@WorkContent_New", SqlDbType.NText);
                parameter.Value = model.WorkContent_New;
                sqlParamList.Add(parameter);
            }

            if (model.Requirements_New != null)
            {
                colList.Append("[Requirements_New],");
                colParamList.Append("@Requirements_New,");
                parameter = new SqlParameter("@Requirements_New", SqlDbType.NText);
                parameter.Value = model.Requirements_New;
                sqlParamList.Add(parameter);
            }

            if (model.RoomAndFood_New != null)
            {
                colList.Append("[RoomAndFood_New],");
                colParamList.Append("@RoomAndFood_New,");
                parameter = new SqlParameter("@RoomAndFood_New", SqlDbType.NText);
                parameter.Value = model.RoomAndFood_New;
                sqlParamList.Add(parameter);
            }

            if (model.Welfare_New != null)
            {
                colList.Append("[Welfare_New],");
                colParamList.Append("@Welfare_New,");
                parameter = new SqlParameter("@Welfare_New", SqlDbType.NText);
                parameter.Value = model.Welfare_New;
                sqlParamList.Add(parameter);
            }

            if (model.WorkAddress != null)
            {
                colList.Append("[WorkAddress],");
                colParamList.Append("@WorkAddress,");
                parameter = new SqlParameter("@WorkAddress", SqlDbType.NVarChar, 50);
                parameter.Value = model.WorkAddress;
                sqlParamList.Add(parameter);
            }

            if (model.CategoryNo != null)
            {
                colList.Append("[CategoryNo],");
                colParamList.Append("@CategoryNo,");
                parameter = new SqlParameter("@CategoryNo", SqlDbType.NVarChar, 15);
                parameter.Value = model.CategoryNo;
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

            if (model.DegreeID != null)
            {
                colList.Append("[DegreeID],");
                colParamList.Append("@DegreeID,");
                parameter = new SqlParameter("@DegreeID", SqlDbType.NVarChar, 50);
                parameter.Value = model.DegreeID;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [Job] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from [Job] ");
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
            strSql.Append("delete from [Job] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Job model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Job] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Job model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.DegreeName != null)
            {
                colList.Append("[DegreeName] = @DegreeName,");
                SqlParameter parameter = new SqlParameter("@DegreeName", SqlDbType.NVarChar, 50);
                parameter.Value = model.DegreeName;
                paramList.Add(parameter);
            }

            if (model.ExperienceID != Int32.MinValue)
            {
                colList.Append("[ExperienceID] = @ExperienceID,");
                SqlParameter parameter = new SqlParameter("@ExperienceID", SqlDbType.Int, 4);
                parameter.Value = model.ExperienceID;
                paramList.Add(parameter);
            }

            if (model.Sex != Int32.MinValue)
            {
                colList.Append("[Sex] = @Sex,");
                SqlParameter parameter = new SqlParameter("@Sex", SqlDbType.Int, 4);
                parameter.Value = model.Sex;
                paramList.Add(parameter);
            }

            if (model.IsCarFare != Int32.MinValue)
            {
                colList.Append("[IsCarFare] = @IsCarFare,");
                SqlParameter parameter = new SqlParameter("@IsCarFare", SqlDbType.Int, 4);
                parameter.Value = model.IsCarFare;
                paramList.Add(parameter);
            }

            if (model.IsHousing != Int32.MinValue)
            {
                colList.Append("[IsHousing] = @IsHousing,");
                SqlParameter parameter = new SqlParameter("@IsHousing", SqlDbType.Int, 4);
                parameter.Value = model.IsHousing;
                paramList.Add(parameter);
            }

            if (model.WorkTime != null)
            {
                colList.Append("[WorkTime] = @WorkTime,");
                SqlParameter parameter = new SqlParameter("@WorkTime", SqlDbType.NVarChar, 50);
                parameter.Value = model.WorkTime;
                paramList.Add(parameter);
            }

            if (model.Quantity != Int32.MinValue)
            {
                colList.Append("[Quantity] = @Quantity,");
                SqlParameter parameter = new SqlParameter("@Quantity", SqlDbType.Int, 4);
                parameter.Value = model.Quantity;
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

            if (model.Description != null)
            {
                colList.Append("[Description] = @Description,");
                SqlParameter parameter = new SqlParameter("@Description", SqlDbType.NText);
                parameter.Value = model.Description;
                paramList.Add(parameter);
            }

            if (model.Status != Int32.MinValue)
            {
                colList.Append("[Status] = @Status,");
                SqlParameter parameter = new SqlParameter("@Status", SqlDbType.Int, 4);
                parameter.Value = model.Status;
                paramList.Add(parameter);
            }

            if (model.JobTitle != null)
            {
                colList.Append("[JobTitle] = @JobTitle,");
                SqlParameter parameter = new SqlParameter("@JobTitle", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobTitle;
                paramList.Add(parameter);
            }

            if (model.Verified != Int32.MinValue)
            {
                colList.Append("[Verified] = @Verified,");
                SqlParameter parameter = new SqlParameter("@Verified", SqlDbType.Int, 4);
                parameter.Value = model.Verified;
                paramList.Add(parameter);
            }

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                paramList.Add(parameter);
            }

            if (model.ViewCount != Int32.MinValue)
            {
                colList.Append("[ViewCount] = @ViewCount,");
                SqlParameter parameter = new SqlParameter("@ViewCount", SqlDbType.Int, 4);
                parameter.Value = model.ViewCount;
                paramList.Add(parameter);
            }

            if (model.UpdateTime != DateTime.MinValue)
            {
                colList.Append("[UpdateTime] = @UpdateTime,");
                SqlParameter parameter = new SqlParameter("@UpdateTime", SqlDbType.DateTime);
                parameter.Value = model.UpdateTime;
                paramList.Add(parameter);
            }

            if (model.RefreshTime != DateTime.MinValue)
            {
                colList.Append("[RefreshTime] = @RefreshTime,");
                SqlParameter parameter = new SqlParameter("@RefreshTime", SqlDbType.DateTime);
                parameter.Value = model.RefreshTime;
                paramList.Add(parameter);
            }

            if (model.IsFix.HasValue)
            {
                colList.Append("[IsFix] = @IsFix,");
                SqlParameter parameter = new SqlParameter("@IsFix", SqlDbType.Bit, 1);
                parameter.Value = model.IsFix.Value; paramList.Add(parameter);
            }

            if (model.Description_New != null)
            {
                colList.Append("[Description_New] = @Description_New,");
                SqlParameter parameter = new SqlParameter("@Description_New", SqlDbType.NText);
                parameter.Value = model.Description_New;
                paramList.Add(parameter);
            }

            if (model.SalaryDesc != null)
            {
                colList.Append("[SalaryDesc] = @SalaryDesc,");
                SqlParameter parameter = new SqlParameter("@SalaryDesc", SqlDbType.NText);
                parameter.Value = model.SalaryDesc;
                paramList.Add(parameter);
            }

            if (model.WorkContent != null)
            {
                colList.Append("[WorkContent] = @WorkContent,");
                SqlParameter parameter = new SqlParameter("@WorkContent", SqlDbType.NText);
                parameter.Value = model.WorkContent;
                paramList.Add(parameter);
            }

            if (model.Requirements != null)
            {
                colList.Append("[Requirements] = @Requirements,");
                SqlParameter parameter = new SqlParameter("@Requirements", SqlDbType.NText);
                parameter.Value = model.Requirements;
                paramList.Add(parameter);
            }

            if (model.CompanyID != Int32.MinValue)
            {
                colList.Append("[CompanyID] = @CompanyID,");
                SqlParameter parameter = new SqlParameter("@CompanyID", SqlDbType.Int, 4);
                parameter.Value = model.CompanyID;
                paramList.Add(parameter);
            }

            if (model.RoomAndFood != null)
            {
                colList.Append("[RoomAndFood] = @RoomAndFood,");
                SqlParameter parameter = new SqlParameter("@RoomAndFood", SqlDbType.NText);
                parameter.Value = model.RoomAndFood;
                paramList.Add(parameter);
            }

            if (model.Welfare != null)
            {
                colList.Append("[Welfare] = @Welfare,");
                SqlParameter parameter = new SqlParameter("@Welfare", SqlDbType.NText);
                parameter.Value = model.Welfare;
                paramList.Add(parameter);
            }

            if (model.Jobtitle_New != null)
            {
                colList.Append("[Jobtitle_New] = @Jobtitle_New,");
                SqlParameter parameter = new SqlParameter("@Jobtitle_New", SqlDbType.NVarChar, 50);
                parameter.Value = model.Jobtitle_New;
                paramList.Add(parameter);
            }

            if (model.SalaryDesc_New != null)
            {
                colList.Append("[SalaryDesc_New] = @SalaryDesc_New,");
                SqlParameter parameter = new SqlParameter("@SalaryDesc_New", SqlDbType.NText);
                parameter.Value = model.SalaryDesc_New;
                paramList.Add(parameter);
            }

            if (model.WorkContent_New != null)
            {
                colList.Append("[WorkContent_New] = @WorkContent_New,");
                SqlParameter parameter = new SqlParameter("@WorkContent_New", SqlDbType.NText);
                parameter.Value = model.WorkContent_New;
                paramList.Add(parameter);
            }

            if (model.Requirements_New != null)
            {
                colList.Append("[Requirements_New] = @Requirements_New,");
                SqlParameter parameter = new SqlParameter("@Requirements_New", SqlDbType.NText);
                parameter.Value = model.Requirements_New;
                paramList.Add(parameter);
            }

            if (model.RoomAndFood_New != null)
            {
                colList.Append("[RoomAndFood_New] = @RoomAndFood_New,");
                SqlParameter parameter = new SqlParameter("@RoomAndFood_New", SqlDbType.NText);
                parameter.Value = model.RoomAndFood_New;
                paramList.Add(parameter);
            }

            if (model.Welfare_New != null)
            {
                colList.Append("[Welfare_New] = @Welfare_New,");
                SqlParameter parameter = new SqlParameter("@Welfare_New", SqlDbType.NText);
                parameter.Value = model.Welfare_New;
                paramList.Add(parameter);
            }

            if (model.WorkAddress != null)
            {
                colList.Append("[WorkAddress] = @WorkAddress,");
                SqlParameter parameter = new SqlParameter("@WorkAddress", SqlDbType.NVarChar, 50);
                parameter.Value = model.WorkAddress;
                paramList.Add(parameter);
            }

            if (model.CategoryNo != null)
            {
                colList.Append("[CategoryNo] = @CategoryNo,");
                SqlParameter parameter = new SqlParameter("@CategoryNo", SqlDbType.NVarChar, 15);
                parameter.Value = model.CategoryNo;
                paramList.Add(parameter);
            }

            if (model.SalaryID != Int32.MinValue)
            {
                colList.Append("[SalaryID] = @SalaryID,");
                SqlParameter parameter = new SqlParameter("@SalaryID", SqlDbType.Int, 4);
                parameter.Value = model.SalaryID;
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

            if (model.DegreeID != null)
            {
                colList.Append("[DegreeID] = @DegreeID,");
                SqlParameter parameter = new SqlParameter("@DegreeID", SqlDbType.NVarChar, 50);
                parameter.Value = model.DegreeID;
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
        public static NH.Model.Job GetModel(int Id)
        {
            NH.Model.Job model = new NH.Model.Job();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Job GetModel(NH.Model.Job model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, DegreeName, ExperienceID, Sex, IsCarFare, IsHousing, WorkTime, Quantity, ExpireDate, Description, Status, JobTitle, Verified, AddTime, ViewCount, UpdateTime, RefreshTime, IsFix, Description_New, SalaryDesc, WorkContent, Requirements, CompanyID, RoomAndFood, Welfare, Jobtitle_New, SalaryDesc_New, WorkContent_New, Requirements_New, RoomAndFood_New, Welfare_New, WorkAddress, CategoryNo, SalaryID, Commission, JobTypeID, JobTypeName, DegreeID ");
            strSql.Append(" from [Job] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Job();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            model.DegreeName = row["DegreeName"].ToString();

            if (row["ExperienceID"].ToString() != "")
            {
                model.ExperienceID = int.Parse(row["ExperienceID"].ToString());
            }

            if (row["Sex"].ToString() != "")
            {
                model.Sex = int.Parse(row["Sex"].ToString());
            }

            if (row["IsCarFare"].ToString() != "")
            {
                model.IsCarFare = int.Parse(row["IsCarFare"].ToString());
            }

            if (row["IsHousing"].ToString() != "")
            {
                model.IsHousing = int.Parse(row["IsHousing"].ToString());
            }

            model.WorkTime = row["WorkTime"].ToString();

            if (row["Quantity"].ToString() != "")
            {
                model.Quantity = int.Parse(row["Quantity"].ToString());
            }

            if (row["ExpireDate"].ToString() != "")
            {
                model.ExpireDate = DateTime.Parse(row["ExpireDate"].ToString());
            }

            model.Description = row["Description"].ToString();

            if (row["Status"].ToString() != "")
            {
                model.Status = int.Parse(row["Status"].ToString());
            }

            model.JobTitle = row["JobTitle"].ToString();

            if (row["Verified"].ToString() != "")
            {
                model.Verified = int.Parse(row["Verified"].ToString());
            }

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }

            if (row["ViewCount"].ToString() != "")
            {
                model.ViewCount = int.Parse(row["ViewCount"].ToString());
            }

            if (row["UpdateTime"].ToString() != "")
            {
                model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
            }

            if (row["RefreshTime"].ToString() != "")
            {
                model.RefreshTime = DateTime.Parse(row["RefreshTime"].ToString());
            }


            if (row["IsFix"].ToString() != "")
            {
                if ((row["IsFix"].ToString() == "1") || (row["IsFix"].ToString().ToLower() == "true"))
                {
                    model.IsFix = true;
                }
                else
                {
                    model.IsFix = false;
                }
            }

            model.Description_New = row["Description_New"].ToString();

            model.SalaryDesc = row["SalaryDesc"].ToString();

            model.WorkContent = row["WorkContent"].ToString();

            model.Requirements = row["Requirements"].ToString();

            if (row["CompanyID"].ToString() != "")
            {
                model.CompanyID = int.Parse(row["CompanyID"].ToString());
            }

            model.RoomAndFood = row["RoomAndFood"].ToString();

            model.Welfare = row["Welfare"].ToString();

            model.Jobtitle_New = row["Jobtitle_New"].ToString();

            model.SalaryDesc_New = row["SalaryDesc_New"].ToString();

            model.WorkContent_New = row["WorkContent_New"].ToString();

            model.Requirements_New = row["Requirements_New"].ToString();

            model.RoomAndFood_New = row["RoomAndFood_New"].ToString();

            model.Welfare_New = row["Welfare_New"].ToString();

            model.WorkAddress = row["WorkAddress"].ToString();

            model.CategoryNo = row["CategoryNo"].ToString();

            if (row["SalaryID"].ToString() != "")
            {
                model.SalaryID = int.Parse(row["SalaryID"].ToString());
            }


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

            model.DegreeID = row["DegreeID"].ToString();

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
            strSql.Append(" FROM [Job] ");
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
            strSql.Append(" FROM [Job] ");
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



