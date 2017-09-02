using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Aftersales
    /// </summary>
    public static partial class Aftersales
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Aftersales model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Aftersales] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Aftersales model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.OrderNumber != null)
            {
                colList.Append("[OrderNumber],");
                colParamList.Append("@OrderNumber,");
                parameter = new SqlParameter("@OrderNumber", SqlDbType.VarChar, 100);
                parameter.Value = model.OrderNumber;
                sqlParamList.Add(parameter);
            }

            if (model.ExpressOrder != null)
            {
                colList.Append("[ExpressOrder],");
                colParamList.Append("@ExpressOrder,");
                parameter = new SqlParameter("@ExpressOrder", SqlDbType.VarChar, 50);
                parameter.Value = model.ExpressOrder;
                sqlParamList.Add(parameter);
            }

            if (model.Couriercompanies != null)
            {
                colList.Append("[Couriercompanies],");
                colParamList.Append("@Couriercompanies,");
                parameter = new SqlParameter("@Couriercompanies", SqlDbType.VarChar, 50);
                parameter.Value = model.Couriercompanies;
                sqlParamList.Add(parameter);
            }

            if (model.Realname != null)
            {
                colList.Append("[Realname],");
                colParamList.Append("@Realname,");
                parameter = new SqlParameter("@Realname", SqlDbType.VarChar, 20);
                parameter.Value = model.Realname;
                sqlParamList.Add(parameter);
            }

            if (model.Email != null)
            {
                colList.Append("[Email],");
                colParamList.Append("@Email,");
                parameter = new SqlParameter("@Email", SqlDbType.VarChar, 50);
                parameter.Value = model.Email;
                sqlParamList.Add(parameter);
            }

            if (model.Tel != null)
            {
                colList.Append("[Tel],");
                colParamList.Append("@Tel,");
                parameter = new SqlParameter("@Tel", SqlDbType.VarChar, 50);
                parameter.Value = model.Tel;
                sqlParamList.Add(parameter);
            }

            if (model.Phone != null)
            {
                colList.Append("[Phone],");
                colParamList.Append("@Phone,");
                parameter = new SqlParameter("@Phone", SqlDbType.VarChar, 50);
                parameter.Value = model.Phone;
                sqlParamList.Add(parameter);
            }

            if (model.CompanyName != null)
            {
                colList.Append("[CompanyName],");
                colParamList.Append("@CompanyName,");
                parameter = new SqlParameter("@CompanyName", SqlDbType.VarChar, 100);
                parameter.Value = model.CompanyName;
                sqlParamList.Add(parameter);
            }

            if (model.Address != null)
            {
                colList.Append("[Address],");
                colParamList.Append("@Address,");
                parameter = new SqlParameter("@Address", SqlDbType.VarChar, 80);
                parameter.Value = model.Address;
                sqlParamList.Add(parameter);
            }

            if (model.Description != null)
            {
                colList.Append("[Description],");
                colParamList.Append("@Description,");
                parameter = new SqlParameter("@Description", SqlDbType.VarChar, 0);
                parameter.Value = model.Description;
                sqlParamList.Add(parameter);
            }

            if (model.AddTime != null)
            {
                colList.Append("[AddTime],");
                colParamList.Append("@AddTime,");
                parameter = new SqlParameter("@AddTime", SqlDbType.Date);
                if (model.AddTime != DateTime.MinValue)
                    parameter.Value = model.AddTime;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.DeliveryTime != null)
            {
                colList.Append("[DeliveryTime],");
                colParamList.Append("@DeliveryTime,");
                parameter = new SqlParameter("@DeliveryTime", SqlDbType.Date);
                if (model.DeliveryTime != DateTime.MinValue)
                    parameter.Value = model.DeliveryTime;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.ArrivalTime != null)
            {
                colList.Append("[ArrivalTime],");
                colParamList.Append("@ArrivalTime,");
                parameter = new SqlParameter("@ArrivalTime", SqlDbType.Date);
                if (model.ArrivalTime != DateTime.MinValue)
                    parameter.Value = model.ArrivalTime;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Status != Int32.MinValue)
            {
                colList.Append("[Status],");
                colParamList.Append("@Status,");
                parameter = new SqlParameter("@Status", SqlDbType.Int, 4);
                if (model.Status != Int32.MinValue)
                    parameter.Value = model.Status;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark],");
                colParamList.Append("@Remark,");
                parameter = new SqlParameter("@Remark", SqlDbType.VarChar, 0);
                parameter.Value = model.Remark;
                sqlParamList.Add(parameter);
            }

            if (model.Pid != Int32.MinValue)
            {
                colList.Append("[Pid],");
                colParamList.Append("@Pid,");
                parameter = new SqlParameter("@Pid", SqlDbType.Int, 4);
                if (model.Pid != Int32.MinValue)
                    parameter.Value = model.Pid;
                else
                    parameter.Value = DBNull.Value;

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
        

            string strSql = string.Format("insert into [Aftersales] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from Aftersales ");
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
            strSql.Append("delete from [Aftersales] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Aftersales model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Aftersales] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Aftersales model, ref SqlParameter[] parameters, bool isUpdate)
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

            if (model.OrderNumber != null)
            {
                colList.Append("[OrderNumber] = @OrderNumber,");
                SqlParameter parameter = new SqlParameter("@OrderNumber", SqlDbType.VarChar, 100);
                parameter.Value = model.OrderNumber;
                paramList.Add(parameter);
            }

            if (model.ExpressOrder != null)
            {
                colList.Append("[ExpressOrder] = @ExpressOrder,");
                SqlParameter parameter = new SqlParameter("@ExpressOrder", SqlDbType.VarChar, 50);
                parameter.Value = model.ExpressOrder;
                paramList.Add(parameter);
            }

            if (model.Couriercompanies != null)
            {
                colList.Append("[Couriercompanies] = @Couriercompanies,");
                SqlParameter parameter = new SqlParameter("@Couriercompanies", SqlDbType.VarChar, 50);
                parameter.Value = model.Couriercompanies;
                paramList.Add(parameter);
            }

            if (model.Realname != null)
            {
                colList.Append("[Realname] = @Realname,");
                SqlParameter parameter = new SqlParameter("@Realname", SqlDbType.VarChar, 20);
                parameter.Value = model.Realname;
                paramList.Add(parameter);
            }

            if (model.Email != null)
            {
                colList.Append("[Email] = @Email,");
                SqlParameter parameter = new SqlParameter("@Email", SqlDbType.VarChar, 50);
                parameter.Value = model.Email;
                paramList.Add(parameter);
            }

            if (model.Tel != null)
            {
                colList.Append("[Tel] = @Tel,");
                SqlParameter parameter = new SqlParameter("@Tel", SqlDbType.VarChar, 50);
                parameter.Value = model.Tel;
                paramList.Add(parameter);
            }

            if (model.Phone != null)
            {
                colList.Append("[Phone] = @Phone,");
                SqlParameter parameter = new SqlParameter("@Phone", SqlDbType.VarChar, 50);
                parameter.Value = model.Phone;
                paramList.Add(parameter);
            }

            if (model.CompanyName != null)
            {
                colList.Append("[CompanyName] = @CompanyName,");
                SqlParameter parameter = new SqlParameter("@CompanyName", SqlDbType.VarChar, 100);
                parameter.Value = model.CompanyName;
                paramList.Add(parameter);
            }

            if (model.Address != null)
            {
                colList.Append("[Address] = @Address,");
                SqlParameter parameter = new SqlParameter("@Address", SqlDbType.VarChar, 80);
                parameter.Value = model.Address;
                paramList.Add(parameter);
            }

            if (model.Description != null)
            {
                colList.Append("[Description] = @Description,");
                SqlParameter parameter = new SqlParameter("@Description", SqlDbType.VarChar, 0);
                parameter.Value = model.Description;
                paramList.Add(parameter);
            }

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime] = @AddTime,");
                SqlParameter parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                paramList.Add(parameter);
            }

            if (model.DeliveryTime != DateTime.MinValue)
            {
                colList.Append("[DeliveryTime] = @DeliveryTime,");
                SqlParameter parameter = new SqlParameter("@DeliveryTime", SqlDbType.DateTime);
                parameter.Value = model.DeliveryTime;
                paramList.Add(parameter);
            }

            if (model.ArrivalTime != DateTime.MinValue)
            {
                colList.Append("[ArrivalTime] = @ArrivalTime,");
                SqlParameter parameter = new SqlParameter("@ArrivalTime", SqlDbType.DateTime);
                parameter.Value = model.ArrivalTime;
                paramList.Add(parameter);
            }

            if (model.Status != Int32.MinValue)
            {
                colList.Append("[Status] = @Status,");
                SqlParameter parameter = new SqlParameter("@Status", SqlDbType.Int, 4);
                parameter.Value = model.Status;
                paramList.Add(parameter);
            }

            if (model.Remark != null)
            {
                colList.Append("[Remark] = @Remark,");
                SqlParameter parameter = new SqlParameter("@Remark", SqlDbType.VarChar, 0);
                parameter.Value = model.Remark;
                paramList.Add(parameter);
            }

            if (model.Pid != Int32.MinValue)
            {
                colList.Append("[Pid] = @Pid,");
                SqlParameter parameter = new SqlParameter("@Pid", SqlDbType.Int, 4);
                parameter.Value = model.Pid;
                paramList.Add(parameter);
            }
            if (model.IsVerify.HasValue)
            {
                colList.Append("[IsVerify] = @IsVerify,");
                SqlParameter parameter = new SqlParameter("@IsVerify", SqlDbType.Bit, 1);
                parameter.Value = model.IsVerify.Value;
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
        public static NH.Model.Aftersales GetModel(int Id)
        {
            NH.Model.Aftersales model = new NH.Model.Aftersales();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Aftersales GetModel(NH.Model.Aftersales model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [Id], [OrderNumber], [ExpressOrder], [Couriercompanies], [Realname], [Email], [Tel], [Phone], [CompanyName], [Address], [Description], [AddTime], [DeliveryTime], [ArrivalTime], [Status], [Remark], [Pid],[IsVerify] ");
            strSql.Append(" from [Aftersales] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Aftersales();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            model.OrderNumber = row["OrderNumber"].ToString();

            model.ExpressOrder = row["ExpressOrder"].ToString();

            model.Couriercompanies = row["Couriercompanies"].ToString();

            model.Realname = row["Realname"].ToString();

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

            if (row["Status"].ToString() != "")
            {
                model.Status = int.Parse(row["Status"].ToString());
            }

            model.Remark = row["Remark"].ToString();

            if (row["Pid"].ToString() != "")
            {
                model.Pid = int.Parse(row["Pid"].ToString());
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
            return model;
        }
        #endregion
        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetListt(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [OrderNumber],[CompanyName],[Couriercompanies],[ExpressOrder],[Realname],[Email],[Tel],[Phone],[Address],[AddTime],[DeliveryTime],[ArrivalTime],[IsVerify] ");
            strSql.Append(" FROM [Aftersales] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.ExecuteDataSet(strSql.ToString());
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
            strSql.Append(" FROM [Aftersales] ");
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
            strSql.Append(" FROM [Aftersales] ");
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