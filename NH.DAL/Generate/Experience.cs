using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// Experience
	/// </summary>
	public static partial class Experience
	{
		#region 是否存在
		/// <summary>
		/// 是否存在
		/// </summary>
		public static bool Exists(NH.Model.Experience model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Experience](nolock)");
			strSql.Append(GetSql(model, ref parameters, false));
			return (int)SqlHelper.ExecuteScalar(strSql.ToString(),parameters) > 0;
		}
		#endregion
				
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(NH.Model.Experience model)
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
												
			if(model.Name != null){
				colList.Append("[Name],");
				colParamList.Append("@Name,");
				parameter = new SqlParameter("@Name",SqlDbType.NVarChar,50);
				parameter.Value = model.Name;
				sqlParamList.Add(parameter);
			}
												
			if(model.Year1.HasValue)
			{
				colList.Append("[Year1],");
				colParamList.Append("@Year1,");
				parameter = new SqlParameter("@Year1",SqlDbType.Int,4);
				if(model.Year1.Value != Int32.MinValue)
                	parameter.Value = model.Year1.Value;
                else 
                	parameter.Value = DBNull.Value;
                                
                sqlParamList.Add(parameter);
			}
												
			if(model.Year2.HasValue)
			{
				colList.Append("[Year2],");
				colParamList.Append("@Year2,");
				parameter = new SqlParameter("@Year2",SqlDbType.Int,4);
				if(model.Year2.Value != Int32.MinValue)
                	parameter.Value = model.Year2.Value;
                else 
                	parameter.Value = DBNull.Value;
                                
                sqlParamList.Add(parameter);
			}
												
			if(model.Sort != Int32.MinValue){
				colList.Append("[Sort],");
				colParamList.Append("@Sort,");
				parameter = new SqlParameter("@Sort",SqlDbType.Int,4);
				parameter.Value = model.Sort;
				sqlParamList.Add(parameter);
			}
												
			if(model.Status != Int32.MinValue){
				colList.Append("[Status],");
				colParamList.Append("@Status,");
				parameter = new SqlParameter("@Status",SqlDbType.Int,4);
				parameter.Value = model.Status;
				sqlParamList.Add(parameter);
			}
						            
            string strSql = string.Format("insert into [Experience] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
                                    
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
			strSql.Append("delete from Experience ");
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
		public static bool Update(NH.Model.Experience model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Experience] set ");
			strSql.Append(GetSql(model,ref parameters,true));
			strSql.Append(" where Id=@Id  ");
			
            return SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters) > 0;			
		}
		#endregion
		
		#region 获取SQL及参数
		/// <summary>
		/// 获取SQL及参数
		/// </summary>
		public static string GetSql(NH.Model.Experience model,ref SqlParameter[] parameters,bool isUpdate)
		{
			StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();			
									
			if(model.Id != Int32.MinValue){
				colList.Append("[Id] = @Id,");
				SqlParameter parameter = new SqlParameter("@Id",SqlDbType.Int,4);
				parameter.Value = model.Id;
				paramList.Add(parameter);
			}
												
			if(model.Name != null){
				colList.Append("[Name] = @Name,");
				SqlParameter parameter = new SqlParameter("@Name",SqlDbType.NVarChar,50);
				parameter.Value = model.Name;
				paramList.Add(parameter);
			}
												
			if(model.Year1.HasValue)
			{
				colList.Append("[Year1] = @Year1,");
				SqlParameter parameter = new SqlParameter("@Year1",SqlDbType.Int,4);
				parameter.Value = model.Year1.Value;
                paramList.Add(parameter);
			}
												
			if(model.Year2.HasValue)
			{
				colList.Append("[Year2] = @Year2,");
				SqlParameter parameter = new SqlParameter("@Year2",SqlDbType.Int,4);
				parameter.Value = model.Year2.Value;
                paramList.Add(parameter);
			}
												
			if(model.Sort != Int32.MinValue){
				colList.Append("[Sort] = @Sort,");
				SqlParameter parameter = new SqlParameter("@Sort",SqlDbType.Int,4);
				parameter.Value = model.Sort;
				paramList.Add(parameter);
			}
												
			if(model.Status != Int32.MinValue){
				colList.Append("[Status] = @Status,");
				SqlParameter parameter = new SqlParameter("@Status",SqlDbType.Int,4);
				parameter.Value = model.Status;
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
		public static NH.Model.Experience GetModel(int Id)
		{
			NH.Model.Experience model = new NH.Model.Experience();
			model.Id = Id;
			return GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.Experience GetModel(NH.Model.Experience model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, Name, Year1, Year2, Sort, Status ");			
			strSql.Append(" from [Experience] ");
			strSql.Append(GetSql(model, ref parameters, false));
			
			DataTable dt=SqlHelper.ExecuteDataTable(strSql.ToString(),parameters);
			if(dt.Rows.Count==0)
			{
				return null;
			}
			model=new NH.Model.Experience();
			DataRow row = dt.Rows[0];
						
			if(row["Id"].ToString()!="")
			{
				model.Id=int.Parse(row["Id"].ToString());
			}				
																						
			model.Name= row["Name"].ToString();
																		
			if(row["Year1"].ToString()!="")
			{
				model.Year1=int.Parse(row["Year1"].ToString());
			}				
																		
			if(row["Year2"].ToString()!="")
			{
				model.Year2=int.Parse(row["Year2"].ToString());
			}				
																		
			if(row["Sort"].ToString()!="")
			{
				model.Sort=int.Parse(row["Sort"].ToString());
			}				
																		
			if(row["Status"].ToString()!="")
			{
				model.Status=int.Parse(row["Status"].ToString());
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
			strSql.Append(" FROM [Experience] ");
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
			strSql.Append(" FROM [Experience] ");
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



