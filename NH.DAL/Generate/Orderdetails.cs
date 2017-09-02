using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Orderdetails
    /// </summary>
    public static partial class Orderdetails
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.Orderdetails model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [Orderdetails] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Orderdetails model)
		{
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;            
            						
			if(model.Barcode != null){
				colList.Append("[Barcode],");
				colParamList.Append("@Barcode,");
				parameter = new SqlParameter("@Barcode",SqlDbType.NVarChar,80);
				parameter.Value = model.Barcode;
				sqlParamList.Add(parameter);
			}
												
			if(model.AddTime != DateTime.MinValue){
				colList.Append("[AddTime],");
				colParamList.Append("@AddTime,");
				parameter = new SqlParameter("@AddTime",SqlDbType.DateTime);
				parameter.Value = model.AddTime;
				sqlParamList.Add(parameter);
			}

            if (model.QdId != long.MinValue)
            {
				colList.Append("[QdId],");
				colParamList.Append("@QdId,");
				parameter = new SqlParameter("@QdId",SqlDbType.BigInt,8);
				parameter.Value = model.QdId;
				sqlParamList.Add(parameter);
			}
												
			if(model.Q_ID != Int32.MinValue){
				colList.Append("[Q_ID],");
				colParamList.Append("@Q_ID,");
				parameter = new SqlParameter("@Q_ID",SqlDbType.Int,4);
				parameter.Value = model.Q_ID;
				sqlParamList.Add(parameter);
			}
												
			if(model.Buyers != null){
				colList.Append("[Buyers],");
				colParamList.Append("@Buyers,");
				parameter = new SqlParameter("@Buyers",SqlDbType.NVarChar,20);
				parameter.Value = model.Buyers;
				sqlParamList.Add(parameter);
			}
												
			if(model.Name != null){
				colList.Append("[Name],");
				colParamList.Append("@Name,");
				parameter = new SqlParameter("@Name",SqlDbType.NVarChar,50);
				parameter.Value = model.Name;
				sqlParamList.Add(parameter);
			}
												
			if(model.Colors != null){
				colList.Append("[Colors],");
				colParamList.Append("@Colors,");
				parameter = new SqlParameter("@Colors",SqlDbType.NVarChar,20);
				parameter.Value = model.Colors;
				sqlParamList.Add(parameter);
			}
												
			if(model.Babynumber != Int32.MinValue){
				colList.Append("[Babynumber],");
				colParamList.Append("@Babynumber,");
				parameter = new SqlParameter("@Babynumber",SqlDbType.Int,4);
				parameter.Value = model.Babynumber;
				sqlParamList.Add(parameter);
			}
												
			if(model.Prices != decimal.MinValue){
				colList.Append("[Prices],");
				colParamList.Append("@Prices,");
				parameter = new SqlParameter("@Prices",SqlDbType.Decimal,5);
				parameter.Value = model.Prices;
				sqlParamList.Add(parameter);
			}
												
			if(model.Amount != decimal.MinValue){
				colList.Append("[Amount],");
				colParamList.Append("@Amount,");
				parameter = new SqlParameter("@Amount",SqlDbType.Decimal,9);
				parameter.Value = model.Amount;
				sqlParamList.Add(parameter);
			}
												
			if(model.Remark != null){
				colList.Append("[Remark],");
				colParamList.Append("@Remark,");
				parameter = new SqlParameter("@Remark",SqlDbType.NVarChar,150);
				parameter.Value = model.Remark;
				sqlParamList.Add(parameter);
			}
						            
            string strSql = string.Format("insert into [Orderdetails] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
            strSql.Append("delete from Orderdetails ");
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
            strSql.Append("delete from [Orderdetails] ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Orderdetails model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Orderdetails] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where Id=@Id ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.Orderdetails model, ref SqlParameter[] parameters, bool isUpdate)
		{
			StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();			
									
			if(model.Id != Int32.MinValue){
				if (!isUpdate) colList.Append("[Id] = @Id,");
				SqlParameter parameter = new SqlParameter("@Id",SqlDbType.Int,4);
				parameter.Value = model.Id;
				paramList.Add(parameter);
			}
												
			if(model.Barcode != null){
				colList.Append("[Barcode] = @Barcode,");
				SqlParameter parameter = new SqlParameter("@Barcode",SqlDbType.NVarChar,80);
				parameter.Value = model.Barcode;
				paramList.Add(parameter);
			}
												
			if(model.AddTime != DateTime.MinValue){
				colList.Append("[AddTime] = @AddTime,");
				SqlParameter parameter = new SqlParameter("@AddTime",SqlDbType.DateTime);
				parameter.Value = model.AddTime;
				paramList.Add(parameter);
			}

            if (model.QdId != long.MinValue)
            {
				colList.Append("[QdId] = @QdId,");
				SqlParameter parameter = new SqlParameter("@QdId",SqlDbType.BigInt,8);
				parameter.Value = model.QdId;
				paramList.Add(parameter);
			}
												
			if(model.Q_ID != Int32.MinValue){
				colList.Append("[Q_ID] = @Q_ID,");
				SqlParameter parameter = new SqlParameter("@Q_ID",SqlDbType.Int,4);
				parameter.Value = model.Q_ID;
				paramList.Add(parameter);
			}
												
			if(model.Buyers != null){
				colList.Append("[Buyers] = @Buyers,");
				SqlParameter parameter = new SqlParameter("@Buyers",SqlDbType.NVarChar,20);
				parameter.Value = model.Buyers;
				paramList.Add(parameter);
			}
												
			if(model.Name != null){
				colList.Append("[Name] = @Name,");
				SqlParameter parameter = new SqlParameter("@Name",SqlDbType.NVarChar,50);
				parameter.Value = model.Name;
				paramList.Add(parameter);
			}
												
			if(model.Colors != null){
				colList.Append("[Colors] = @Colors,");
				SqlParameter parameter = new SqlParameter("@Colors",SqlDbType.NVarChar,20);
				parameter.Value = model.Colors;
				paramList.Add(parameter);
			}
												
			if(model.Babynumber != Int32.MinValue){
				colList.Append("[Babynumber] = @Babynumber,");
				SqlParameter parameter = new SqlParameter("@Babynumber",SqlDbType.Int,4);
				parameter.Value = model.Babynumber;
				paramList.Add(parameter);
			}
												
			if(model.Prices != decimal.MinValue){
				colList.Append("[Prices] = @Prices,");
				SqlParameter parameter = new SqlParameter("@Prices",SqlDbType.Decimal,5);
				parameter.Value = model.Prices;
				paramList.Add(parameter);
			}
												
			if(model.Amount != decimal.MinValue){
				colList.Append("[Amount] = @Amount,");
				SqlParameter parameter = new SqlParameter("@Amount",SqlDbType.Decimal,9);
				parameter.Value = model.Amount;
				paramList.Add(parameter);
			}
												
			if(model.Remark != null){
				colList.Append("[Remark] = @Remark,");
				SqlParameter parameter = new SqlParameter("@Remark",SqlDbType.NVarChar,150);
				parameter.Value = model.Remark;
				paramList.Add(parameter);
			}
													
            string result = null;
            if (colList.Length > 0){
				if(isUpdate){
					paramList.Add(paramList[0]);
					paramList.RemoveAt(0);
					result = colList.ToString().TrimEnd(',');
				}else{
                    result = "where " + colList.ToString().TrimEnd(',').Replace(","," and ");
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
        public static NH.Model.Orderdetails GetModel(int Id)
        {
            NH.Model.Orderdetails model = new NH.Model.Orderdetails();
            model.Id = Id;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Orderdetails GetModel(NH.Model.Orderdetails model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [Id], [Barcode], [AddTime], [QdId], [Q_ID], [Buyers], [Name], [Colors], [Babynumber], [Prices], [Amount], [Remark] ");
            strSql.Append(" from [Orderdetails] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.Orderdetails();
            DataRow row = dt.Rows[0];

            if (row["Id"].ToString() != "")
            {
                model.Id = int.Parse(row["Id"].ToString());
            }

            model.Barcode = row["Barcode"].ToString();

            if (row["AddTime"].ToString() != "")
            {
                model.AddTime = DateTime.Parse(row["AddTime"].ToString());
            }

            if (row["QdId"].ToString() != "")
            {
                model.QdId = long.Parse(row["QdId"].ToString());
            }

            if (row["Q_ID"].ToString() != "")
            {
                model.Q_ID = int.Parse(row["Q_ID"].ToString());
            }

            model.Buyers = row["Buyers"].ToString();

            model.Name = row["Name"].ToString();

            model.Colors = row["Colors"].ToString();

            if (row["Babynumber"].ToString() != "")
            {
                model.Babynumber = int.Parse(row["Babynumber"].ToString());
            }

            if (row["Prices"].ToString() != "")
            {
                model.Prices = decimal.Parse(row["Prices"].ToString());
            }

            if (row["Amount"].ToString() != "")
            {
                model.Amount = decimal.Parse(row["Amount"].ToString());
            }

            model.Remark = row["Remark"].ToString();

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
            strSql.Append(" FROM [Orderdetails] ");
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
            strSql.Append(" FROM [Orderdetails] ");
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



