using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Product
    /// </summary>
    public static partial class Product
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Product model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Product] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Product model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.Model != null)
            {
                colList.Append("[Model],");
                colParamList.Append("@Model,");
                parameter = new SqlParameter("@Model", SqlDbType.NVarChar, 20);
                parameter.Value = model.Model;
                sqlParamList.Add(parameter);
            }

            if (model.Phone != null)
            {
                colList.Append("[Phone],");
                colParamList.Append("@Phone,");
                parameter = new SqlParameter("@Phone", SqlDbType.NVarChar, 20);
                parameter.Value = model.Phone;
                sqlParamList.Add(parameter);
            }

            if (model.Imgs != null)
            {
                colList.Append("[Imgs],");
                colParamList.Append("@Imgs,");
                parameter = new SqlParameter("@Imgs", SqlDbType.NVarChar, 50);
                parameter.Value = model.Imgs;
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

            if (model.content != null)
            {
                colList.Append("[content],");
                colParamList.Append("@content,");
                parameter = new SqlParameter("@content", SqlDbType.NVarChar, 4000);
                parameter.Value = model.content;
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

            if (model.Barcode != null)
            {
                colList.Append("[Barcode],");
                colParamList.Append("@Barcode,");
                parameter = new SqlParameter("@Barcode", SqlDbType.NVarChar, 100);
                parameter.Value = model.Barcode;
                sqlParamList.Add(parameter);
            }

            if (model.ChengBen.HasValue)
            {
                colList.Append("[ChengBen],");
                colParamList.Append("@ChengBen,");
                parameter = new SqlParameter("@ChengBen", SqlDbType.Money, 8);
                if (model.ChengBen.Value != decimal.MinValue)
                    parameter.Value = model.ChengBen.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.ChuShou.HasValue)
            {
                colList.Append("[ChuShou],");
                colParamList.Append("@ChuShou,");
                parameter = new SqlParameter("@ChuShou", SqlDbType.Money, 8);
                if (model.ChuShou.Value != decimal.MinValue)
                    parameter.Value = model.ChuShou.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.RuKuSum.HasValue)
            {
                colList.Append("[RuKuSum],");
                colParamList.Append("@RuKuSum,");
                parameter = new SqlParameter("@RuKuSum", SqlDbType.Int, 4);
                if (model.RuKuSum.Value != Int32.MinValue)
                    parameter.Value = model.RuKuSum.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Name != null)
            {
                colList.Append("[Name],");
                colParamList.Append("@Name,");
                parameter = new SqlParameter("@Name", SqlDbType.NVarChar, 20);
                parameter.Value = model.Name;
                sqlParamList.Add(parameter);
            }

            if (model.ChuKuSum.HasValue)
            {
                colList.Append("[ChuKuSum],");
                colParamList.Append("@ChuKuSum,");
                parameter = new SqlParameter("@ChuKuSum", SqlDbType.Int, 4);
                if (model.ChuKuSum.Value != Int32.MinValue)
                    parameter.Value = model.ChuKuSum.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.NowKuCun.HasValue)
            {
                colList.Append("[NowKuCun],");
                colParamList.Append("@NowKuCun,");
                parameter = new SqlParameter("@NowKuCun", SqlDbType.Int, 4);
                if (model.NowKuCun.Value != Int32.MinValue)
                    parameter.Value = model.NowKuCun.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.KuCunBaoJing.HasValue)
            {
                colList.Append("[KuCunBaoJing],");
                colParamList.Append("@KuCunBaoJing,");
                parameter = new SqlParameter("@KuCunBaoJing", SqlDbType.Int, 4);
                if (model.KuCunBaoJing.Value != Int32.MinValue)
                    parameter.Value = model.KuCunBaoJing.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.CunChuWeiZhi != null)
            {
                colList.Append("[CunChuWeiZhi],");
                colParamList.Append("@CunChuWeiZhi,");
                parameter = new SqlParameter("@CunChuWeiZhi", SqlDbType.VarChar, 50);
                parameter.Value = model.CunChuWeiZhi;
                sqlParamList.Add(parameter);
            }

            if (model.JiFenPrice.HasValue)
            {
                colList.Append("[JiFenPrice],");
                colParamList.Append("@JiFenPrice,");
                parameter = new SqlParameter("@JiFenPrice", SqlDbType.Int, 4);
                if (model.JiFenPrice.Value != Int32.MinValue)
                    parameter.Value = model.JiFenPrice.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.KeJiFen.HasValue)
            {
                colList.Append("[KeJiFen],");
                colParamList.Append("@KeJiFen,");
                parameter = new SqlParameter("@KeJiFen", SqlDbType.Int, 4);
                if (model.KeJiFen.Value != Int32.MinValue)
                    parameter.Value = model.KeJiFen.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Order.HasValue)
            {
                colList.Append("[Order],");
                colParamList.Append("@Order,");
                parameter = new SqlParameter("@Order", SqlDbType.Int, 4);
                if (model.Order.Value != Int32.MinValue)
                    parameter.Value = model.Order.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Pic != null)
            {
                colList.Append("[Pic],");
                colParamList.Append("@Pic,");
                parameter = new SqlParameter("@Pic", SqlDbType.NVarChar, 50);
                parameter.Value = model.Pic;
                sqlParamList.Add(parameter);
            }

            if (model.SmallPic != null)
            {
                colList.Append("[SmallPic],");
                colParamList.Append("@SmallPic,");
                parameter = new SqlParameter("@SmallPic", SqlDbType.NVarChar, 50);
                parameter.Value = model.SmallPic;
                sqlParamList.Add(parameter);
            }

            if (model.CategoryID.HasValue)
            {
                colList.Append("[CategoryID],");
                colParamList.Append("@CategoryID,");
                parameter = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
                if (model.CategoryID.Value != Int32.MinValue)
                    parameter.Value = model.CategoryID.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.CategoryPath != null)
            {
                colList.Append("[CategoryPath],");
                colParamList.Append("@CategoryPath,");
                parameter = new SqlParameter("@CategoryPath", SqlDbType.NVarChar, 50);
                parameter.Value = model.CategoryPath;
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

            string strSql = string.Format("insert into [Product] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from Product ");
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
            strSql.Append("delete from [Product] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Product model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Product] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Product model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.Model != null)
            {
                colList.Append("[Model] = @Model,");
                SqlParameter parameter = new SqlParameter("@Model", SqlDbType.NVarChar, 20);
                parameter.Value = model.Model;
                paramList.Add(parameter);
            }

            if (model.Phone != null)
            {
                colList.Append("[Phone] = @Phone,");
                SqlParameter parameter = new SqlParameter("@Phone", SqlDbType.NVarChar, 20);
                parameter.Value = model.Phone;
                paramList.Add(parameter);
            }

            if (model.Imgs != null)
            {
                colList.Append("[Imgs] = @Imgs,");
                SqlParameter parameter = new SqlParameter("@Imgs", SqlDbType.NVarChar, 50);
                parameter.Value = model.Imgs;
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

            if (model.content != null)
            {
                colList.Append("[content] = @content,");
                SqlParameter parameter = new SqlParameter("@content", SqlDbType.NVarChar, 4000);
                parameter.Value = model.content;
                paramList.Add(parameter);
            }

            if (model.IdentityVerified.HasValue)
            {
                colList.Append("[IdentityVerified] = @IdentityVerified,");
                SqlParameter parameter = new SqlParameter("@IdentityVerified", SqlDbType.Bit, 1);
                parameter.Value = model.IdentityVerified.Value;
                paramList.Add(parameter);
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

            if (model.ExpireDate.HasValue)
            {
                colList.Append("[ExpireDate] = @ExpireDate,");
                SqlParameter parameter = new SqlParameter("@ExpireDate", SqlDbType.SmallDateTime);
                parameter.Value = model.ExpireDate.Value;
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
                parameter.Value = model.IsVerify.Value;
                paramList.Add(parameter);
            }

            if (model.Barcode != null)
            {
                colList.Append("[Barcode] = @Barcode,");
                SqlParameter parameter = new SqlParameter("@Barcode", SqlDbType.NVarChar, 100);
                parameter.Value = model.Barcode;
                paramList.Add(parameter);
            }

            if (model.ChengBen.HasValue)
            {
                colList.Append("[ChengBen] = @ChengBen,");
                SqlParameter parameter = new SqlParameter("@ChengBen", SqlDbType.Money, 8);
                parameter.Value = model.ChengBen.Value;
                paramList.Add(parameter);
            }

            if (model.ChuShou.HasValue)
            {
                colList.Append("[ChuShou] = @ChuShou,");
                SqlParameter parameter = new SqlParameter("@ChuShou", SqlDbType.Money, 8);
                parameter.Value = model.ChuShou.Value;
                paramList.Add(parameter);
            }

            if (model.RuKuSum.HasValue)
            {
                colList.Append("[RuKuSum] = @RuKuSum,");
                SqlParameter parameter = new SqlParameter("@RuKuSum", SqlDbType.Int, 4);
                parameter.Value = model.RuKuSum.Value;
                paramList.Add(parameter);
            }

            if (model.Name != null)
            {
                colList.Append("[Name] = @Name,");
                SqlParameter parameter = new SqlParameter("@Name", SqlDbType.NVarChar, 20);
                parameter.Value = model.Name;
                paramList.Add(parameter);
            }

            if (model.ChuKuSum.HasValue)
            {
                colList.Append("[ChuKuSum] = @ChuKuSum,");
                SqlParameter parameter = new SqlParameter("@ChuKuSum", SqlDbType.Int, 4);
                parameter.Value = model.ChuKuSum.Value;
                paramList.Add(parameter);
            }

            if (model.NowKuCun.HasValue)
            {
                colList.Append("[NowKuCun] = @NowKuCun,");
                SqlParameter parameter = new SqlParameter("@NowKuCun", SqlDbType.Int, 4);
                parameter.Value = model.NowKuCun.Value;
                paramList.Add(parameter);
            }

            if (model.KuCunBaoJing.HasValue)
            {
                colList.Append("[KuCunBaoJing] = @KuCunBaoJing,");
                SqlParameter parameter = new SqlParameter("@KuCunBaoJing", SqlDbType.Int, 4);
                parameter.Value = model.KuCunBaoJing.Value;
                paramList.Add(parameter);
            }

            if (model.CunChuWeiZhi != null)
            {
                colList.Append("[CunChuWeiZhi] = @CunChuWeiZhi,");
                SqlParameter parameter = new SqlParameter("@CunChuWeiZhi", SqlDbType.VarChar, 50);
                parameter.Value = model.CunChuWeiZhi;
                paramList.Add(parameter);
            }

            if (model.JiFenPrice.HasValue)
            {
                colList.Append("[JiFenPrice] = @JiFenPrice,");
                SqlParameter parameter = new SqlParameter("@JiFenPrice", SqlDbType.Int, 4);
                parameter.Value = model.JiFenPrice.Value;
                paramList.Add(parameter);
            }

            if (model.KeJiFen.HasValue)
            {
                colList.Append("[KeJiFen] = @KeJiFen,");
                SqlParameter parameter = new SqlParameter("@KeJiFen", SqlDbType.Int, 4);
                parameter.Value = model.KeJiFen.Value;
                paramList.Add(parameter);
            }

            if (model.Order.HasValue)
            {
                colList.Append("[Order] = @Order,");
                SqlParameter parameter = new SqlParameter("@Order", SqlDbType.Int, 4);
                parameter.Value = model.Order.Value;
                paramList.Add(parameter);
            }

            if (model.Pic != null)
            {
                colList.Append("[Pic] = @Pic,");
                SqlParameter parameter = new SqlParameter("@Pic", SqlDbType.NVarChar, 50);
                parameter.Value = model.Pic;
                paramList.Add(parameter);
            }

            if (model.SmallPic != null)
            {
                colList.Append("[SmallPic] = @SmallPic,");
                SqlParameter parameter = new SqlParameter("@SmallPic", SqlDbType.NVarChar, 50);
                parameter.Value = model.SmallPic;
                paramList.Add(parameter);
            }

            if (model.CategoryID.HasValue)
            {
                colList.Append("[CategoryID] = @CategoryID,");
                SqlParameter parameter = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
                parameter.Value = model.CategoryID.Value;
                paramList.Add(parameter);
            }

            if (model.CategoryPath != null)
            {
                colList.Append("[CategoryPath] = @CategoryPath,");
                SqlParameter parameter = new SqlParameter("@CategoryPath", SqlDbType.NVarChar, 50);
                parameter.Value = model.CategoryPath;
                paramList.Add(parameter);
            }

            if (model.AddTime.HasValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime.Value;
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
        public static NH.Model.Product GetModel(int Id)
        {
            NH.Model.Product model = new NH.Model.Product();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Product GetModel(NH.Model.Product model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [Id], [Model], [Phone], [Imgs], [Address], [HomePage], [Space], [EmployeeQty], [Camera], [Studio], [Description], [content], [IdentityVerified], [LevelID], [VerifyStatus], [ExpireDate], [ViewCount], [IsVerify], [Barcode], [ChengBen], [ChuShou], [RuKuSum], [Name], [ChuKuSum], [NowKuCun], [KuCunBaoJing], [CunChuWeiZhi], [JiFenPrice], [KeJiFen], [Order], [Pic], [SmallPic], [CategoryID], [CategoryPath], [AddTime] ");
            strSql.Append(" from [Product] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Product();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            model.Model = row["Model"].ToString();

            model.Phone = row["Phone"].ToString();

            model.Imgs = row["Imgs"].ToString();

            model.Address = row["Address"].ToString();

            model.HomePage = row["HomePage"].ToString();

            model.Space = row["Space"].ToString();

            model.EmployeeQty = row["EmployeeQty"].ToString();

            model.Camera = row["Camera"].ToString();

            model.Studio = row["Studio"].ToString();

            model.Description = row["Description"].ToString();

            model.content = row["content"].ToString();


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

            model.Barcode = row["Barcode"].ToString();

            if (row["ChengBen"].ToString() != "")
            {
                model.ChengBen = decimal.Parse(row["ChengBen"].ToString());
            }

            if (row["ChuShou"].ToString() != "")
            {
                model.ChuShou = decimal.Parse(row["ChuShou"].ToString());
            }

            if (row["RuKuSum"].ToString() != "")
            {
                model.RuKuSum = int.Parse(row["RuKuSum"].ToString());
            }

            model.Name = row["Name"].ToString();

            if (row["ChuKuSum"].ToString() != "")
            {
                model.ChuKuSum = int.Parse(row["ChuKuSum"].ToString());
            }

            if (row["NowKuCun"].ToString() != "")
            {
                model.NowKuCun = int.Parse(row["NowKuCun"].ToString());
            }

            if (row["KuCunBaoJing"].ToString() != "")
            {
                model.KuCunBaoJing = int.Parse(row["KuCunBaoJing"].ToString());
            }

            model.CunChuWeiZhi = row["CunChuWeiZhi"].ToString();

            if (row["JiFenPrice"].ToString() != "")
            {
                model.JiFenPrice = int.Parse(row["JiFenPrice"].ToString());
            }

            if (row["KeJiFen"].ToString() != "")
            {
                model.KeJiFen = int.Parse(row["KeJiFen"].ToString());
            }

            if (row["Order"].ToString() != "")
            {
                model.Order = int.Parse(row["Order"].ToString());
            }

            model.Pic = row["Pic"].ToString();

            model.SmallPic = row["SmallPic"].ToString();

            if (row["CategoryID"].ToString() != "")
            {
                model.CategoryID = int.Parse(row["CategoryID"].ToString());
            }

            model.CategoryPath = row["CategoryPath"].ToString();

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
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
            strSql.Append(" FROM [Product] ");
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
            strSql.Append(" FROM [Product] ");
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



