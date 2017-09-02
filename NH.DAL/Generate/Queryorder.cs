using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Queryorder
    /// </summary>
    public static partial class Queryorder
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Queryorder model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Queryorder] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Queryorder model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.Email != null)
            {
                colList.Append("[Email],");
                colParamList.Append("@Email,");
                parameter = new SqlParameter("@Email", SqlDbType.NVarChar, 30);
                parameter.Value = model.Email;
                sqlParamList.Add(parameter);
            }

            if (model.Tel != null)
            {
                colList.Append("[Tel],");
                colParamList.Append("@Tel,");
                parameter = new SqlParameter("@Tel", SqlDbType.NVarChar, 20);
                parameter.Value = model.Tel;
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

            if (model.CompanyName != null)
            {
                colList.Append("[CompanyName],");
                colParamList.Append("@CompanyName,");
                parameter = new SqlParameter("@CompanyName", SqlDbType.NVarChar, 50);
                parameter.Value = model.CompanyName;
                sqlParamList.Add(parameter);
            }

            if (model.Address != null)
            {
                colList.Append("[Address],");
                colParamList.Append("@Address,");
                parameter = new SqlParameter("@Address", SqlDbType.NVarChar, 80);
                parameter.Value = model.Address;
                sqlParamList.Add(parameter);
            }

            if (model.Description != null)
            {
                colList.Append("[Description],");
                colParamList.Append("@Description,");
                parameter = new SqlParameter("@Description", SqlDbType.NVarChar, -1);
                parameter.Value = model.Description;
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

            if (model.DeliveryTime.HasValue)
            {
                colList.Append("[DeliveryTime],");
                colParamList.Append("@DeliveryTime,");
                parameter = new SqlParameter("@DeliveryTime", SqlDbType.DateTime);
                if (model.DeliveryTime.Value != DateTime.MinValue)
                    parameter.Value = model.DeliveryTime.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.ArrivalTime.HasValue)
            {
                colList.Append("[ArrivalTime],");
                colParamList.Append("@ArrivalTime,");
                parameter = new SqlParameter("@ArrivalTime", SqlDbType.DateTime);
                if (model.ArrivalTime.Value != DateTime.MinValue)
                    parameter.Value = model.ArrivalTime.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Status != null)
            {
                colList.Append("[Status],");
                colParamList.Append("@Status,");
                parameter = new SqlParameter("@Status", SqlDbType.NVarChar, 4);
                parameter.Value = model.Status;
                sqlParamList.Add(parameter);
            }

            if (model.Buyers != null)
            {
                colList.Append("[Buyers],");
                colParamList.Append("@Buyers,");
                parameter = new SqlParameter("@Buyers", SqlDbType.NVarChar, 20);
                parameter.Value = model.Buyers;
                sqlParamList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark],");
                colParamList.Append("@Remark,");
                parameter = new SqlParameter("@Remark", SqlDbType.NVarChar, -1);
                parameter.Value = model.Remark;
                sqlParamList.Add(parameter);
            }

            if (model.Babynumber.HasValue)
            {
                colList.Append("[Babynumber],");
                colParamList.Append("@Babynumber,");
                parameter = new SqlParameter("@Babynumber", SqlDbType.Int, 4);
                if (model.Babynumber.Value != Int32.MinValue)
                    parameter.Value = model.Babynumber.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Pid != null)
            {
                colList.Append("[Pid],");
                colParamList.Append("@Pid,");
                parameter = new SqlParameter("@Pid", SqlDbType.NVarChar, 50);
                parameter.Value = model.Pid;
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

            if (model.Barcode != null)
            {
                colList.Append("[Barcode],");
                colParamList.Append("@Barcode,");
                parameter = new SqlParameter("@Barcode", SqlDbType.NVarChar, 80);
                parameter.Value = model.Barcode;
                sqlParamList.Add(parameter);
            }

            if (model.QdId.HasValue)
            {
                colList.Append("[QdId],");
                colParamList.Append("@QdId,");
                parameter = new SqlParameter("@QdId", SqlDbType.BigInt, 8);
                parameter.Value = model.QdId.Value;
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

            if (model.province.HasValue)
            {
                colList.Append("[province],");
                colParamList.Append("@province,");
                parameter = new SqlParameter("@province", SqlDbType.Int, 4);
                if (model.province.Value != Int32.MinValue)
                    parameter.Value = model.province.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.city.HasValue)
            {
                colList.Append("[city],");
                colParamList.Append("@city,");
                parameter = new SqlParameter("@city", SqlDbType.Int, 4);
                if (model.city.Value != Int32.MinValue)
                    parameter.Value = model.city.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.area.HasValue)
            {
                colList.Append("[area],");
                colParamList.Append("@area,");
                parameter = new SqlParameter("@area", SqlDbType.Int, 4);
                if (model.area.Value != Int32.MinValue)
                    parameter.Value = model.area.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Buyerpayspoints != null)
            {
                colList.Append("[Buyerpayspoints],");
                colParamList.Append("@Buyerpayspoints,");
                parameter = new SqlParameter("@Buyerpayspoints", SqlDbType.NVarChar, 20);
                parameter.Value = model.Buyerpayspoints;
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

            if (model.PaymentMethod.HasValue)
            {
                colList.Append("[PaymentMethod],");
                colParamList.Append("@PaymentMethod,");
                parameter = new SqlParameter("@PaymentMethod", SqlDbType.Int, 4);
                if (model.PaymentMethod.Value != Int32.MinValue)
                    parameter.Value = model.PaymentMethod.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Amount.HasValue)
            {
                colList.Append("[Amount],");
                colParamList.Append("@Amount,");
                parameter = new SqlParameter("@Amount", SqlDbType.Decimal, 9);
                if (model.Amount.Value != decimal.MinValue)
                    parameter.Value = model.Amount.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.OrderNumber.HasValue)
            {
                colList.Append("[OrderNumber],");
                colParamList.Append("@OrderNumber,");
                parameter = new SqlParameter("@OrderNumber", SqlDbType.BigInt, 8);
                parameter.Value = model.OrderNumber.Value;
                sqlParamList.Add(parameter);
            }

            if (model.ExpressOrder != null)
            {
                colList.Append("[ExpressOrder],");
                colParamList.Append("@ExpressOrder,");
                parameter = new SqlParameter("@ExpressOrder", SqlDbType.NVarChar, 20);
                parameter.Value = model.ExpressOrder;
                sqlParamList.Add(parameter);
            }

            if (model.Couriercompanies != null)
            {
                colList.Append("[Couriercompanies],");
                colParamList.Append("@Couriercompanies,");
                parameter = new SqlParameter("@Couriercompanies", SqlDbType.NVarChar, 20);
                parameter.Value = model.Couriercompanies;
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

            if (model.Products != null)
            {
                colList.Append("[Products],");
                colParamList.Append("@Products,");
                parameter = new SqlParameter("@Products", SqlDbType.NVarChar, 250);
                parameter.Value = model.Products;
                sqlParamList.Add(parameter);
            }

            if (model.Babynumbers != null)
            {
                colList.Append("[Babynumbers],");
                colParamList.Append("@Babynumbers,");
                parameter = new SqlParameter("@Babynumbers", SqlDbType.NVarChar, 200);
                parameter.Value = model.Babynumbers;
                sqlParamList.Add(parameter);
            }

            if (model.Amounts != null)
            {
                colList.Append("[Amounts],");
                colParamList.Append("@Amounts,");
                parameter = new SqlParameter("@Amounts", SqlDbType.NVarChar, 200);
                parameter.Value = model.Amounts;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [Queryorder] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from Queryorder ");
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
            strSql.Append("delete from [Queryorder] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Queryorder model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Queryorder] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Queryorder model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.Email != null)
            {
                colList.Append("[Email] = @Email,");
                SqlParameter parameter = new SqlParameter("@Email", SqlDbType.NVarChar, 30);
                parameter.Value = model.Email;
                paramList.Add(parameter);
            }

            if (model.Tel != null)
            {
                colList.Append("[Tel] = @Tel,");
                SqlParameter parameter = new SqlParameter("@Tel", SqlDbType.NVarChar, 20);
                parameter.Value = model.Tel;
                paramList.Add(parameter);
            }

            if (model.Phone != null)
            {
                colList.Append("[Phone] = @Phone,");
                SqlParameter parameter = new SqlParameter("@Phone", SqlDbType.NVarChar, 20);
                parameter.Value = model.Phone;
                paramList.Add(parameter);
            }

            if (model.CompanyName != null)
            {
                colList.Append("[CompanyName] = @CompanyName,");
                SqlParameter parameter = new SqlParameter("@CompanyName", SqlDbType.NVarChar, 50);
                parameter.Value = model.CompanyName;
                paramList.Add(parameter);
            }

            if (model.Address != null)
            {
                colList.Append("[Address] = @Address,");
                SqlParameter parameter = new SqlParameter("@Address", SqlDbType.NVarChar, 80);
                parameter.Value = model.Address;
                paramList.Add(parameter);
            }

            if (model.Description != null)
            {
                colList.Append("[Description] = @Description,");
                SqlParameter parameter = new SqlParameter("@Description", SqlDbType.NVarChar, -1);
                parameter.Value = model.Description;
                paramList.Add(parameter);
            }

            if (model.AddTime.HasValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime.Value;
                paramList.Add(parameter);
            }

            if (model.DeliveryTime.HasValue)
            {
                colList.Append("[DeliveryTime] = @DeliveryTime,");
                SqlParameter parameter = new SqlParameter("@DeliveryTime", SqlDbType.DateTime);
                parameter.Value = model.DeliveryTime.Value;
                paramList.Add(parameter);
            }

            if (model.ArrivalTime.HasValue)
            {
                colList.Append("[ArrivalTime] = @ArrivalTime,");
                SqlParameter parameter = new SqlParameter("@ArrivalTime", SqlDbType.DateTime);
                parameter.Value = model.ArrivalTime.Value;
                paramList.Add(parameter);
            }

            if (model.Status != null)
            {
                colList.Append("[Status] = @Status,");
                SqlParameter parameter = new SqlParameter("@Status", SqlDbType.NVarChar, 4);
                parameter.Value = model.Status;
                paramList.Add(parameter);
            }

            if (model.Buyers != null)
            {
                colList.Append("[Buyers] = @Buyers,");
                SqlParameter parameter = new SqlParameter("@Buyers", SqlDbType.NVarChar, 20);
                parameter.Value = model.Buyers;
                paramList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark] = @Remark,");
                SqlParameter parameter = new SqlParameter("@Remark", SqlDbType.NVarChar, -1);
                parameter.Value = model.Remark;
                paramList.Add(parameter);
            }

            if (model.Babynumber.HasValue)
            {
                colList.Append("[Babynumber] = @Babynumber,");
                SqlParameter parameter = new SqlParameter("@Babynumber", SqlDbType.Int, 4);
                parameter.Value = model.Babynumber.Value;
                paramList.Add(parameter);
            }

            if (model.Pid != null)
            {
                colList.Append("[Pid] = @Pid,");
                SqlParameter parameter = new SqlParameter("@Pid", SqlDbType.NVarChar, 50);
                parameter.Value = model.Pid;
                paramList.Add(parameter);
            }

            if (model.Type.HasValue)
            {
                colList.Append("[Type] = @Type,");
                SqlParameter parameter = new SqlParameter("@Type", SqlDbType.Int, 4);
                parameter.Value = model.Type.Value;
                paramList.Add(parameter);
            }

            if (model.Barcode != null)
            {
                colList.Append("[Barcode] = @Barcode,");
                SqlParameter parameter = new SqlParameter("@Barcode", SqlDbType.NVarChar, 80);
                parameter.Value = model.Barcode;
                paramList.Add(parameter);
            }

            if (model.QdId.HasValue)
            {
                colList.Append("[QdId] = @QdId,");
                SqlParameter parameter = new SqlParameter("@QdId", SqlDbType.BigInt, 8);
                parameter.Value = model.QdId.Value;
                paramList.Add(parameter);
            }

            if (model.U_ID.HasValue)
            {
                colList.Append("[U_ID] = @U_ID,");
                SqlParameter parameter = new SqlParameter("@U_ID", SqlDbType.Int, 4);
                parameter.Value = model.U_ID.Value;
                paramList.Add(parameter);
            }

            if (model.province.HasValue)
            {
                colList.Append("[province] = @province,");
                SqlParameter parameter = new SqlParameter("@province", SqlDbType.Int, 4);
                parameter.Value = model.province.Value;
                paramList.Add(parameter);
            }

            if (model.city.HasValue)
            {
                colList.Append("[city] = @city,");
                SqlParameter parameter = new SqlParameter("@city", SqlDbType.Int, 4);
                parameter.Value = model.city.Value;
                paramList.Add(parameter);
            }

            if (model.area.HasValue)
            {
                colList.Append("[area] = @area,");
                SqlParameter parameter = new SqlParameter("@area", SqlDbType.Int, 4);
                parameter.Value = model.area.Value;
                paramList.Add(parameter);
            }

            if (model.Buyerpayspoints != null)
            {
                colList.Append("[Buyerpayspoints] = @Buyerpayspoints,");
                SqlParameter parameter = new SqlParameter("@Buyerpayspoints", SqlDbType.NVarChar, 20);
                parameter.Value = model.Buyerpayspoints;
                paramList.Add(parameter);
            }

            if (model.KeJiFen.HasValue)
            {
                colList.Append("[KeJiFen] = @KeJiFen,");
                SqlParameter parameter = new SqlParameter("@KeJiFen", SqlDbType.Int, 4);
                parameter.Value = model.KeJiFen.Value;
                paramList.Add(parameter);
            }

            if (model.PaymentMethod.HasValue)
            {
                colList.Append("[PaymentMethod] = @PaymentMethod,");
                SqlParameter parameter = new SqlParameter("@PaymentMethod", SqlDbType.Int, 4);
                parameter.Value = model.PaymentMethod.Value;
                paramList.Add(parameter);
            }

            if (model.Amount.HasValue)
            {
                colList.Append("[Amount] = @Amount,");
                SqlParameter parameter = new SqlParameter("@Amount", SqlDbType.Decimal, 9);
                parameter.Value = model.Amount.Value;
                paramList.Add(parameter);
            }

            if (model.OrderNumber.HasValue)
            {
                colList.Append("[OrderNumber] = @OrderNumber,");
                SqlParameter parameter = new SqlParameter("@OrderNumber", SqlDbType.BigInt, 8);
                parameter.Value = model.OrderNumber.Value;
                paramList.Add(parameter);
            }

            if (model.ExpressOrder != null)
            {
                colList.Append("[ExpressOrder] = @ExpressOrder,");
                SqlParameter parameter = new SqlParameter("@ExpressOrder", SqlDbType.NVarChar, 20);
                parameter.Value = model.ExpressOrder;
                paramList.Add(parameter);
            }

            if (model.Couriercompanies != null)
            {
                colList.Append("[Couriercompanies] = @Couriercompanies,");
                SqlParameter parameter = new SqlParameter("@Couriercompanies", SqlDbType.NVarChar, 20);
                parameter.Value = model.Couriercompanies;
                paramList.Add(parameter);
            }

            if (model.Realname != null)
            {
                colList.Append("[Realname] = @Realname,");
                SqlParameter parameter = new SqlParameter("@Realname", SqlDbType.NVarChar, 20);
                parameter.Value = model.Realname;
                paramList.Add(parameter);
            }

            if (model.Products != null)
            {
                colList.Append("[Products] = @Products,");
                SqlParameter parameter = new SqlParameter("@Products", SqlDbType.NVarChar, 250);
                parameter.Value = model.Products;
                paramList.Add(parameter);
            }

            if (model.Babynumbers != null)
            {
                colList.Append("[Babynumbers] = @Babynumbers,");
                SqlParameter parameter = new SqlParameter("@Babynumbers", SqlDbType.NVarChar, 200);
                parameter.Value = model.Babynumbers;
                paramList.Add(parameter);
            }

            if (model.Amounts != null)
            {
                colList.Append("[Amounts] = @Amounts,");
                SqlParameter parameter = new SqlParameter("@Amounts", SqlDbType.NVarChar, 200);
                parameter.Value = model.Amounts;
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
        public static NH.Model.Queryorder GetModel(int Id)
        {
            NH.Model.Queryorder model = new NH.Model.Queryorder();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Queryorder GetModel(NH.Model.Queryorder model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [Id], [Email], [Tel], [Phone], [CompanyName], [Address], [Description], [AddTime], [DeliveryTime], [ArrivalTime], [Status], [Buyers], [Remark], [Babynumber], [Pid], [Type], [Barcode], [QdId], [U_ID], [province], [city], [area], [Buyerpayspoints], [KeJiFen], [PaymentMethod], [Amount], [OrderNumber], [ExpressOrder], [Couriercompanies], [Realname],[Products],[Babynumbers],[Amounts] ");
            strSql.Append(" from [Queryorder] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Queryorder();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            model.Email = row["Email"].ToString();

            model.Tel = row["Tel"].ToString();

            model.Phone = row["Phone"].ToString();

            model.CompanyName = row["CompanyName"].ToString();

            model.Address = row["Address"].ToString();

            model.Description = row["Description"].ToString();

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }

            if (row["DeliveryTime"].ToString() != "")
            {
                model.DeliveryTime = DateTime.Parse(row["DeliveryTime"].ToString());
            }

            if (row["ArrivalTime"].ToString() != "")
            {
                model.ArrivalTime = DateTime.Parse(row["ArrivalTime"].ToString());
            }

            model.Status = row["Status"].ToString();

            model.Buyers = row["Buyers"].ToString();

            model.Remark = row["Remark"].ToString();

            if (row["Babynumber"].ToString() != "")
            {
                model.Babynumber = int.Parse(row["Babynumber"].ToString());
            }

            model.Pid = row["Pid"].ToString();

            if (row["Type"].ToString() != "")
            {
                model.Type = int.Parse(row["Type"].ToString());
            }

            model.Barcode = row["Barcode"].ToString();

            if (row["QdId"].ToString() != "")
            {
                model.QdId = long.Parse(row["QdId"].ToString());
            }

            if (row["U_ID"].ToString() != "")
            {
                model.U_ID = int.Parse(row["U_ID"].ToString());
            }

            if (row["province"].ToString() != "")
            {
                model.province = int.Parse(row["province"].ToString());
            }

            if (row["city"].ToString() != "")
            {
                model.city = int.Parse(row["city"].ToString());
            }

            if (row["area"].ToString() != "")
            {
                model.area = int.Parse(row["area"].ToString());
            }

            model.Buyerpayspoints = row["Buyerpayspoints"].ToString();

            if (row["KeJiFen"].ToString() != "")
            {
                model.KeJiFen = int.Parse(row["KeJiFen"].ToString());
            }

            if (row["PaymentMethod"].ToString() != "")
            {
                model.PaymentMethod = int.Parse(row["PaymentMethod"].ToString());
            }

            if (row["Amount"].ToString() != "")
            {
                model.Amount = decimal.Parse(row["Amount"].ToString());
            }

            if (row["OrderNumber"].ToString() != "")
            {
                model.OrderNumber = long.Parse(row["OrderNumber"].ToString());
            }

            model.ExpressOrder = row["ExpressOrder"].ToString();

            model.Couriercompanies = row["Couriercompanies"].ToString();

            model.Realname = row["Realname"].ToString();

            model.Products = row["Products"].ToString();

            model.Babynumbers = row["Babynumbers"].ToString();

            model.Amounts = row["Amounts"].ToString();

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
            strSql.Append(@" SELECT 
            fb.Id,
            fb.OrderNumber,
            U.LoginName
            FROM[Queryorder]  fb
            LEFT JOIN[User] U
            ON fb.U_ID = U.[Id]


                ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.ExecuteDataSet(strSql.ToString());
        }
        #endregion

        #region 获得下一级会员金额
        /// <summary>
        /// 获得下一级会员金额
        /// </summary>
        public static string OneAmount(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" select Convert(decimal(18,2),sum(Amount*0.1)) as OneAmounts  
            from Queryorder
                ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);//U_ID in (select Id from [User] where ParentID=21) and  DeliveryTime >= '2017-07-01' and DeliveryTime <= '2017-07-28'
            }
            object o = SqlHelper.ExecuteScalar(strSql.ToString());
            return o.ToString();
        }
        #endregion

        #region 获得下二级会员金额
        /// <summary>
        /// 获得下二级会员金额
        /// </summary>
        public static string TwoAmount(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" select Convert(decimal(18,2),sum(Amount*0.1)) as TwoAmounts  
            from Queryorder
                ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);//U_ID in (select Id from [User] where ParentID=21) and  DeliveryTime >= '2017-07-01' and DeliveryTime <= '2017-07-28'
            }
            object o = SqlHelper.ExecuteScalar(strSql.ToString());
            return o.ToString();
        }
        #endregion

        public static string onePlustwoAmount(string strWhere1,string strWhere2)
        {
            string a = OneAmount(strWhere1);
            string b = TwoAmount(strWhere2);
            decimal c = (string.IsNullOrEmpty(a) ? 0 : decimal.Parse(a)) + (string.IsNullOrEmpty(b) ? 0 : decimal.Parse(b));

            return c.ToString();
        }

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
            strSql.Append(" FROM [Queryorder] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.ExecuteDataSet(strSql.ToString());
        }
        #endregion


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataSet GetListByPage(string strWhere, string orderField, string orderby, int pageIndex, int pageSize, ref int count)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT fb.*,
 U.LoginName


FROM [Queryorder]  fb

   LEFT JOIN [User] U
          ON fb.U_ID = U.[Id]

");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            //strSql.Append(" order by " + orderField);
            return SqlHelper.GetPageList(strSql.ToString(), orderField, orderby, pageIndex, pageSize, ref count);

        }


        /// <summary>
        /// 分页获取数据列表  --分组
        /// </summary>
        public static DataSet GetListByPage2(string strWhere, string orderField, string orderby, int pageIndex, int pageSize, ref int count)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" select g.U_ID,
            u.LoginName,
            count(*) as Ordernumber,
            sum(Amount) as OrderAmount 

            from Queryorder g

            LEFT JOIN [User] u
            ON g.U_ID = U.[Id]

");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere + " group by g.U_ID,u.LoginName");
            }
            //strSql.Append(" order by " + orderField);
            return SqlHelper.GetPageList(strSql.ToString(), orderField, orderby, pageIndex, pageSize, ref count);

        }
    }
}



