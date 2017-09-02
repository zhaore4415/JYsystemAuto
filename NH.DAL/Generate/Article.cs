using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// Article
	/// </summary>
	public static partial class Article
	{
		#region 是否存在
		/// <summary>
		/// 是否存在
		/// </summary>
		public static bool Exists(NH.Model.Article model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Article](nolock)");
			strSql.Append(GetSql(model, ref parameters, false));
			return (int)SqlHelper.ExecuteScalar(strSql.ToString(),parameters) > 0;
		}
		#endregion
				
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(NH.Model.Article model)
		{
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;
            						
			if(model.CategoryID != Int32.MinValue){
				colList.Append("[CategoryID],");
				colParamList.Append("@CategoryID,");
				parameter = new SqlParameter("@CategoryID",SqlDbType.Int,4);
				parameter.Value = model.CategoryID;
				sqlParamList.Add(parameter);
			}
												
			if(model.Title != null){
				colList.Append("[Title],");
				colParamList.Append("@Title,");
				parameter = new SqlParameter("@Title",SqlDbType.NVarChar,50);
				parameter.Value = model.Title;
				sqlParamList.Add(parameter);
			}
												
			if(model.Description != null){
				colList.Append("[Description],");
				colParamList.Append("@Description,");
				parameter = new SqlParameter("@Description",SqlDbType.NText);
				parameter.Value = model.Description;
				sqlParamList.Add(parameter);
			}
												
			if(model.Url != null){
				colList.Append("[Url],");
				colParamList.Append("@Url,");
				parameter = new SqlParameter("@Url",SqlDbType.NVarChar,50);
				parameter.Value = model.Url;
				sqlParamList.Add(parameter);
			}
												
			if(model.AddTime != DateTime.MinValue){
				colList.Append("[AddTime],");
				colParamList.Append("@AddTime,");
				parameter = new SqlParameter("@AddTime",SqlDbType.DateTime);
				parameter.Value = model.AddTime;
				sqlParamList.Add(parameter);
			}
												
			if(model.Status != Int32.MinValue){
				colList.Append("[Status],");
				colParamList.Append("@Status,");
				parameter = new SqlParameter("@Status",SqlDbType.Int,4);
				parameter.Value = model.Status;
				sqlParamList.Add(parameter);
			}
												
			if(model.Hits != Int32.MinValue){
				colList.Append("[Hits],");
				colParamList.Append("@Hits,");
				parameter = new SqlParameter("@Hits",SqlDbType.Int,4);
				parameter.Value = model.Hits;
				sqlParamList.Add(parameter);
			}
												
			if(model.IsTop.HasValue)
			{
				colList.Append("[IsTop],");
				colParamList.Append("@IsTop,");
				parameter = new SqlParameter("@IsTop",SqlDbType.Bit,1);
				parameter.Value = model.IsTop.Value;                
                sqlParamList.Add(parameter);
			}
												
			if(model.IsHilight.HasValue)
			{
				colList.Append("[IsHilight],");
				colParamList.Append("@IsHilight,");
				parameter = new SqlParameter("@IsHilight",SqlDbType.Bit,1);
				parameter.Value = model.IsHilight.Value;                
                sqlParamList.Add(parameter);
			}
												
			if(model.AddUserId != Int32.MinValue){
				colList.Append("[AddUserId],");
				colParamList.Append("@AddUserId,");
				parameter = new SqlParameter("@AddUserId",SqlDbType.Int,4);
				parameter.Value = model.AddUserId;
				sqlParamList.Add(parameter);
			}
												
			if(model.UpdateTime.HasValue)
			{
				colList.Append("[UpdateTime],");
				colParamList.Append("@UpdateTime,");
				parameter = new SqlParameter("@UpdateTime",SqlDbType.DateTime);
				if(model.UpdateTime.Value != DateTime.MinValue)
                	parameter.Value = model.UpdateTime.Value;
                else 
                	parameter.Value = DBNull.Value;
                                
                sqlParamList.Add(parameter);
			}
												
			if(model.Files != null){
				colList.Append("[Files],");
				colParamList.Append("@Files,");
				parameter = new SqlParameter("@Files",SqlDbType.NVarChar,50);
				parameter.Value = model.Files;
				sqlParamList.Add(parameter);
			}
						            
            string strSql = string.Format("insert into [Article] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
			strSql.Append("delete from Article ");
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
			strSql.Append("delete from [Article] ");
			strSql.Append(" where ID in ("+Idlist + ")  ");
			return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
		}
		#endregion
				
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.Article model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Article] set ");
			strSql.Append(GetSql(model,ref parameters,true));
			strSql.Append(" where Id=@Id ");
			
            return SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters) > 0;			
		}
		#endregion
		
		#region 获取SQL及参数
		/// <summary>
		/// 获取SQL及参数
		/// </summary>
		public static string GetSql(NH.Model.Article model,ref SqlParameter[] parameters,bool isUpdate)
		{
			StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();			
									
			if(model.Id != Int32.MinValue){
				if (!isUpdate) colList.Append("[Id] = @Id,");
				SqlParameter parameter = new SqlParameter("@Id",SqlDbType.Int,4);
				parameter.Value = model.Id;
				paramList.Add(parameter);
			}
												
			if(model.CategoryID != Int32.MinValue){
				colList.Append("[CategoryID] = @CategoryID,");
				SqlParameter parameter = new SqlParameter("@CategoryID",SqlDbType.Int,4);
				parameter.Value = model.CategoryID;
				paramList.Add(parameter);
			}
												
			if(model.Title != null){
				colList.Append("[Title] = @Title,");
				SqlParameter parameter = new SqlParameter("@Title",SqlDbType.NVarChar,50);
				parameter.Value = model.Title;
				paramList.Add(parameter);
			}
												
			if(model.Description != null){
				colList.Append("[Description] = @Description,");
				SqlParameter parameter = new SqlParameter("@Description",SqlDbType.NText);
				parameter.Value = model.Description;
				paramList.Add(parameter);
			}
												
			if(model.Url != null){
				colList.Append("[Url] = @Url,");
				SqlParameter parameter = new SqlParameter("@Url",SqlDbType.NVarChar,50);
				parameter.Value = model.Url;
				paramList.Add(parameter);
			}
												
			if(model.AddTime != DateTime.MinValue){
				colList.Append("[AddTime] = @AddTime,");
				SqlParameter parameter = new SqlParameter("@AddTime",SqlDbType.DateTime);
				parameter.Value = model.AddTime;
				paramList.Add(parameter);
			}
												
			if(model.Status != Int32.MinValue){
				colList.Append("[Status] = @Status,");
				SqlParameter parameter = new SqlParameter("@Status",SqlDbType.Int,4);
				parameter.Value = model.Status;
				paramList.Add(parameter);
			}
												
			if(model.Hits != Int32.MinValue){
				colList.Append("[Hits] = @Hits,");
				SqlParameter parameter = new SqlParameter("@Hits",SqlDbType.Int,4);
				parameter.Value = model.Hits;
				paramList.Add(parameter);
			}
												
			if(model.IsTop.HasValue)
			{
				colList.Append("[IsTop] = @IsTop,");
				SqlParameter parameter = new SqlParameter("@IsTop",SqlDbType.Bit,1);
				parameter.Value = model.IsTop.Value;
                paramList.Add(parameter);
			}
												
			if(model.IsHilight.HasValue)
			{
				colList.Append("[IsHilight] = @IsHilight,");
				SqlParameter parameter = new SqlParameter("@IsHilight",SqlDbType.Bit,1);
				parameter.Value = model.IsHilight.Value;
                paramList.Add(parameter);
			}
												
			if(model.AddUserId != Int32.MinValue){
				colList.Append("[AddUserId] = @AddUserId,");
				SqlParameter parameter = new SqlParameter("@AddUserId",SqlDbType.Int,4);
				parameter.Value = model.AddUserId;
				paramList.Add(parameter);
			}
												
			if(model.UpdateTime.HasValue)
			{
				colList.Append("[UpdateTime] = @UpdateTime,");
				SqlParameter parameter = new SqlParameter("@UpdateTime",SqlDbType.DateTime);
				parameter.Value = model.UpdateTime.Value;
                paramList.Add(parameter);
			}
												
			if(model.Files != null){
				colList.Append("[Files] = @Files,");
				SqlParameter parameter = new SqlParameter("@Files",SqlDbType.NVarChar,50);
				parameter.Value = model.Files;
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
		public static NH.Model.Article GetModel(int Id)
		{
			NH.Model.Article model = new NH.Model.Article();
			model.Id = Id;
			return GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.Article GetModel(NH.Model.Article model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append(@"select Id, CategoryID, Title, Description, Url, AddTime, 
                Status, Hits, IsTop, IsHilight, AddUserId, UpdateTime, Files ");			
			strSql.Append(" from [Article] ");
			strSql.Append(GetSql(model, ref parameters, false));
			
			DataTable dt=SqlHelper.ExecuteDataTable(strSql.ToString(),parameters);
			if(dt.Rows.Count==0)
			{
				return null;
			}
			model=new NH.Model.Article();
			DataRow row = dt.Rows[0];
						
			if(row["Id"].ToString()!="")
			{
				model.Id=int.Parse(row["Id"].ToString());
			}				
																		
			if(row["CategoryID"].ToString()!="")
			{
				model.CategoryID=int.Parse(row["CategoryID"].ToString());
			}				
																						
			model.Title= row["Title"].ToString();
																						
			model.Description= row["Description"].ToString();
																						
			model.Url= row["Url"].ToString();
																		
			if(row["AddTime"].ToString()!="")
			{
				model.AddTime=DateTime.Parse(row["AddTime"].ToString());
			}				
																		
			if(row["Status"].ToString()!="")
			{
				model.Status=int.Parse(row["Status"].ToString());
			}				
																		
			if(row["Hits"].ToString()!="")
			{
				model.Hits=int.Parse(row["Hits"].ToString());
			}				
																						
															
			if(row["IsTop"].ToString()!="")
			{
				if((row["IsTop"].ToString()=="1")||(row["IsTop"].ToString().ToLower()=="true"))
				{
					model.IsTop= true;
				}
				else
				{
					model.IsTop= false;
				}
			}
													
															
			if(row["IsHilight"].ToString()!="")
			{
				if((row["IsHilight"].ToString()=="1")||(row["IsHilight"].ToString().ToLower()=="true"))
				{
					model.IsHilight= true;
				}
				else
				{
					model.IsHilight= false;
				}
			}
									
			if(row["AddUserId"].ToString()!="")
			{
				model.AddUserId=int.Parse(row["AddUserId"].ToString());
			}				
																		
			if(row["UpdateTime"].ToString()!="")
			{
				model.UpdateTime=DateTime.Parse(row["UpdateTime"].ToString());
			}				
																						
			model.Files= row["Files"].ToString();
																					
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
			strSql.Append(" FROM [Article] ");
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
			strSql.Append(" FROM [Article] ");
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



