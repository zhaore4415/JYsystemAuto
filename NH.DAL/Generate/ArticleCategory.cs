using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// ArticleCategory
	/// </summary>
	public static partial class ArticleCategory
	{
		#region 是否存在
		/// <summary>
		/// 是否存在
		/// </summary>
		public static bool Exists(NH.Model.ArticleCategory model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ArticleCategory](nolock)");
			strSql.Append(GetSql(model, ref parameters, false));
			return (int)SqlHelper.ExecuteScalar(strSql.ToString(),parameters) > 0;
		}
		#endregion
				
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(NH.Model.ArticleCategory model)
		{
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;
            						
			if(model.Name != null){
				colList.Append("[Name],");
				colParamList.Append("@Name,");
				parameter = new SqlParameter("@Name",SqlDbType.NVarChar,50);
				parameter.Value = model.Name;
				sqlParamList.Add(parameter);
			}
												
			if(model.Status != Int32.MinValue){
				colList.Append("[Status],");
				colParamList.Append("@Status,");
				parameter = new SqlParameter("@Status",SqlDbType.Int,4);
				parameter.Value = model.Status;
				sqlParamList.Add(parameter);
			}
												
			if(model.Type != Int32.MinValue){
				colList.Append("[Type],");
				colParamList.Append("@Type,");
				parameter = new SqlParameter("@Type",SqlDbType.Int,4);
				parameter.Value = model.Type;
				sqlParamList.Add(parameter);
			}
												
			if(model.CanDelete.HasValue)
			{
				colList.Append("[CanDelete],");
				colParamList.Append("@CanDelete,");
				parameter = new SqlParameter("@CanDelete",SqlDbType.Bit,1);
				parameter.Value = model.CanDelete.Value;                
                sqlParamList.Add(parameter);
			}
												
			if(model.Sort != Int32.MinValue){
				colList.Append("[Sort],");
				colParamList.Append("@Sort,");
				parameter = new SqlParameter("@Sort",SqlDbType.Int,4);
				parameter.Value = model.Sort;
				sqlParamList.Add(parameter);
			}
						            
            string strSql = string.Format("insert into [ArticleCategory] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
            strSql += ";select @@IDENTITY";                        
			   
			object obj = SqlHelper.ExecuteScalar(strSql,sqlParamList.ToArray());			
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ArticleCategory ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters) > 0;
		}
		#endregion
		
				
		#region 批量删除一批数据
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public static bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [ArticleCategory] ");
			strSql.Append(" where ID in ("+Idlist + ")  ");
			return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
		}
		#endregion
				
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.ArticleCategory model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [ArticleCategory] set ");
			strSql.Append(GetSql(model,ref parameters,true));
			strSql.Append(" where Id=@Id ");
			
            return SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters) > 0;			
		}
		#endregion
		
		#region 获取SQL及参数
		/// <summary>
		/// 获取SQL及参数
		/// </summary>
		public static string GetSql(NH.Model.ArticleCategory model,ref SqlParameter[] parameters,bool isUpdate)
		{
			StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();			
									
			if(model.Id != Int32.MinValue){
				if (!isUpdate) colList.Append("[Id] = @Id,");
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
												
			if(model.Status != Int32.MinValue){
				colList.Append("[Status] = @Status,");
				SqlParameter parameter = new SqlParameter("@Status",SqlDbType.Int,4);
				parameter.Value = model.Status;
				paramList.Add(parameter);
			}
												
			if(model.Type != Int32.MinValue){
				colList.Append("[Type] = @Type,");
				SqlParameter parameter = new SqlParameter("@Type",SqlDbType.Int,4);
				parameter.Value = model.Type;
				paramList.Add(parameter);
			}
												
			if(model.CanDelete.HasValue)
			{
				colList.Append("[CanDelete] = @CanDelete,");
				SqlParameter parameter = new SqlParameter("@CanDelete",SqlDbType.Bit,1);
				parameter.Value = model.CanDelete.Value;
                paramList.Add(parameter);
			}
												
			if(model.Sort != Int32.MinValue){
				colList.Append("[Sort] = @Sort,");
				SqlParameter parameter = new SqlParameter("@Sort",SqlDbType.Int,4);
				parameter.Value = model.Sort;
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
		public static NH.Model.ArticleCategory GetModel(int Id)
		{
			NH.Model.ArticleCategory model = new NH.Model.ArticleCategory();
			model.Id = Id;
			return GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.ArticleCategory GetModel(NH.Model.ArticleCategory model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, Name, Status, Type, CanDelete, Sort ");			
			strSql.Append(" from [ArticleCategory] ");
			strSql.Append(GetSql(model, ref parameters, false));
			
			DataTable dt=SqlHelper.ExecuteDataTable(strSql.ToString(),parameters);
			if(dt.Rows.Count==0)
			{
				return null;
			}
			model=new NH.Model.ArticleCategory();
			DataRow row = dt.Rows[0];
						
			if(row["Id"].ToString()!="")
			{
				model.Id=int.Parse(row["Id"].ToString());
			}				
																						
			model.Name= row["Name"].ToString();
																		
			if(row["Status"].ToString()!="")
			{
				model.Status=int.Parse(row["Status"].ToString());
			}				
																		
			if(row["Type"].ToString()!="")
			{
				model.Type=int.Parse(row["Type"].ToString());
			}				
																						
															
			if(row["CanDelete"].ToString()!="")
			{
				if((row["CanDelete"].ToString()=="1")||(row["CanDelete"].ToString().ToLower()=="true"))
				{
					model.CanDelete= true;
				}
				else
				{
					model.CanDelete= false;
				}
			}
									
			if(row["Sort"].ToString()!="")
			{
				model.Sort=int.Parse(row["Sort"].ToString());
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
			strSql.Append(" FROM [ArticleCategory] ");
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
			strSql.Append(" FROM [ArticleCategory] ");
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



