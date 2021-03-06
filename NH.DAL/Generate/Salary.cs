﻿using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// Salary
	/// </summary>
	public static partial class Salary
	{
		#region 是否存在
		/// <summary>
		/// 是否存在
		/// </summary>
		public static bool Exists(NH.Model.Salary model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Salary](nolock)");
			strSql.Append(GetSql(model, ref parameters, false));
			return (int)SqlHelper.ExecuteScalar(strSql.ToString(),parameters) > 0;
		}
		#endregion
				
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(NH.Model.Salary model)
		{
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;
            						
			if(model.Id != Int32.MinValue){
				colList.Append("[Id],");
				colParamList.Append("@Id,");
				parameter = new SqlParameter("@Id",SqlDbType.Int,4);
				parameter.Value = model.Id;
				sqlParamList.Add(parameter);
			}
												
			if(model.SalaryName != null){
				colList.Append("[SalaryName],");
				colParamList.Append("@SalaryName,");
				parameter = new SqlParameter("@SalaryName",SqlDbType.NVarChar,20);
				parameter.Value = model.SalaryName;
				sqlParamList.Add(parameter);
			}
												
			if(model.Status != Int32.MinValue){
				colList.Append("[Status],");
				colParamList.Append("@Status,");
				parameter = new SqlParameter("@Status",SqlDbType.Int,4);
				parameter.Value = model.Status;
				sqlParamList.Add(parameter);
			}
												
			if(model.Sort != Int32.MinValue){
				colList.Append("[Sort],");
				colParamList.Append("@Sort,");
				parameter = new SqlParameter("@Sort",SqlDbType.Int,4);
				parameter.Value = model.Sort;
				sqlParamList.Add(parameter);
			}
												
			if(model.Salary1.HasValue)
			{
				colList.Append("[Salary1],");
				colParamList.Append("@Salary1,");
				parameter = new SqlParameter("@Salary1",SqlDbType.Int,4);
				if(model.Salary1.Value != Int32.MinValue)
                	parameter.Value = model.Salary1.Value;
                else 
                	parameter.Value = DBNull.Value;
                                
                sqlParamList.Add(parameter);
			}
												
			if(model.Salary2.HasValue)
			{
				colList.Append("[Salary2],");
				colParamList.Append("@Salary2,");
				parameter = new SqlParameter("@Salary2",SqlDbType.Int,4);
				if(model.Salary2.Value != Int32.MinValue)
                	parameter.Value = model.Salary2.Value;
                else 
                	parameter.Value = DBNull.Value;
                                
                sqlParamList.Add(parameter);
			}
						            
            string strSql = string.Format("insert into [Salary] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
                                    
			return SqlHelper.ExecuteNonQuery(strSql, sqlParamList.ToArray()) > 0;
            			
		}
		#endregion

		#region 删除一条数据
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int Id)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Salary ");
			strSql.Append(" where Id=@Id ");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
			parameters[0].Value = Id;

			return SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters) > 0;
		}
		#endregion
		
				
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.Salary model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Salary] set ");
			strSql.Append(GetSql(model,ref parameters,true));
			strSql.Append(" where Id=@Id  ");
			
            return SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters) > 0;			
		}
		#endregion
		
		#region 获取SQL及参数
		/// <summary>
		/// 获取SQL及参数
		/// </summary>
		public static string GetSql(NH.Model.Salary model,ref SqlParameter[] parameters,bool isUpdate)
		{
			StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();			
									
			if(model.Id != Int32.MinValue){
				colList.Append("[Id] = @Id,");
				SqlParameter parameter = new SqlParameter("@Id",SqlDbType.Int,4);
				parameter.Value = model.Id;
				paramList.Add(parameter);
			}
												
			if(model.SalaryName != null){
				colList.Append("[SalaryName] = @SalaryName,");
				SqlParameter parameter = new SqlParameter("@SalaryName",SqlDbType.NVarChar,20);
				parameter.Value = model.SalaryName;
				paramList.Add(parameter);
			}
												
			if(model.Status != Int32.MinValue){
				colList.Append("[Status] = @Status,");
				SqlParameter parameter = new SqlParameter("@Status",SqlDbType.Int,4);
				parameter.Value = model.Status;
				paramList.Add(parameter);
			}
												
			if(model.Sort != Int32.MinValue){
				colList.Append("[Sort] = @Sort,");
				SqlParameter parameter = new SqlParameter("@Sort",SqlDbType.Int,4);
				parameter.Value = model.Sort;
				paramList.Add(parameter);
			}
												
			if(model.Salary1.HasValue)
			{
				colList.Append("[Salary1] = @Salary1,");
				SqlParameter parameter = new SqlParameter("@Salary1",SqlDbType.Int,4);
				parameter.Value = model.Salary1.Value;
                paramList.Add(parameter);
			}
												
			if(model.Salary2.HasValue)
			{
				colList.Append("[Salary2] = @Salary2,");
				SqlParameter parameter = new SqlParameter("@Salary2",SqlDbType.Int,4);
				parameter.Value = model.Salary2.Value;
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
		public static NH.Model.Salary GetModel(int Id)
		{
			NH.Model.Salary model = new NH.Model.Salary();
			model.Id = Id;
			return GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.Salary GetModel(NH.Model.Salary model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, SalaryName, Status, Sort, Salary1, Salary2 ");			
			strSql.Append(" from [Salary] ");
			strSql.Append(GetSql(model, ref parameters, false));
			
			DataTable dt=SqlHelper.ExecuteDataTable(strSql.ToString(),parameters);
			if(dt.Rows.Count==0)
			{
				return null;
			}
			model=new NH.Model.Salary();
			DataRow row = dt.Rows[0];
						
			if(row["Id"].ToString()!="")
			{
				model.Id=int.Parse(row["Id"].ToString());
			}				
																						
			model.SalaryName= row["SalaryName"].ToString();
																		
			if(row["Status"].ToString()!="")
			{
				model.Status=int.Parse(row["Status"].ToString());
			}				
																		
			if(row["Sort"].ToString()!="")
			{
				model.Sort=int.Parse(row["Sort"].ToString());
			}				
																		
			if(row["Salary1"].ToString()!="")
			{
				model.Salary1=int.Parse(row["Salary1"].ToString());
			}				
																		
			if(row["Salary2"].ToString()!="")
			{
				model.Salary2=int.Parse(row["Salary2"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Salary] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return SqlHelper.ExecuteDataSet(strSql.ToString());
		}
		#endregion
		
		#region 获得前几行数据
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM [Salary] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.ExecuteDataSet(strSql.ToString());
		}
		#endregion   
	}
}



