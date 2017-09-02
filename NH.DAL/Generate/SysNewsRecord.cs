using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// SysNewsRecord
	/// </summary>
	public static partial class SysNewsRecord
	{
		#region 是否存在
		/// <summary>
		/// 是否存在
		/// </summary>
		public static bool Exists(NH.Model.SysNewsRecord model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [SysNewsRecord](nolock)");
			strSql.Append(GetSql(model, ref parameters, false));
			return (int)SqlHelper.ExecuteScalar(strSql.ToString(),parameters) > 0;
		}
		#endregion
				
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(NH.Model.SysNewsRecord model)
		{
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;
            						
			if(model.ArticleId != Int32.MinValue){
				colList.Append("[ArticleId],");
				colParamList.Append("@ArticleId,");
				parameter = new SqlParameter("@ArticleId",SqlDbType.Int,4);
				parameter.Value = model.ArticleId;
				sqlParamList.Add(parameter);
			}
												
			if(model.UserId != Int32.MinValue){
				colList.Append("[UserId],");
				colParamList.Append("@UserId,");
				parameter = new SqlParameter("@UserId",SqlDbType.Int,4);
				parameter.Value = model.UserId;
				sqlParamList.Add(parameter);
			}
												
			if(model.UserType != Int32.MinValue){
				colList.Append("[UserType],");
				colParamList.Append("@UserType,");
				parameter = new SqlParameter("@UserType",SqlDbType.Int,4);
				parameter.Value = model.UserType;
				sqlParamList.Add(parameter);
			}
												
			if(model.ReadStatus.HasValue)
			{
				colList.Append("[ReadStatus],");
				colParamList.Append("@ReadStatus,");
				parameter = new SqlParameter("@ReadStatus",SqlDbType.Bit,1);
				parameter.Value = model.ReadStatus.Value;                
                sqlParamList.Add(parameter);
			}
						            
            string strSql = string.Format("insert into [SysNewsRecord] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
			strSql.Append("delete from SysNewsRecord ");
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
			strSql.Append("delete from [SysNewsRecord] ");
			strSql.Append(" where ID in ("+Idlist + ")  ");
			return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
		}
		#endregion
				
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.SysNewsRecord model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [SysNewsRecord] set ");
			strSql.Append(GetSql(model,ref parameters,true));
			strSql.Append(" where Id=@Id ");
			
            return SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters) > 0;			
		}
		#endregion
		
		#region 获取SQL及参数
		/// <summary>
		/// 获取SQL及参数
		/// </summary>
		public static string GetSql(NH.Model.SysNewsRecord model,ref SqlParameter[] parameters,bool isUpdate)
		{
			StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();			
									
			if(model.Id != Int32.MinValue){
				if (!isUpdate) colList.Append("[Id] = @Id,");
				SqlParameter parameter = new SqlParameter("@Id",SqlDbType.Int,4);
				parameter.Value = model.Id;
				paramList.Add(parameter);
			}
												
			if(model.ArticleId != Int32.MinValue){
				colList.Append("[ArticleId] = @ArticleId,");
				SqlParameter parameter = new SqlParameter("@ArticleId",SqlDbType.Int,4);
				parameter.Value = model.ArticleId;
				paramList.Add(parameter);
			}
												
			if(model.UserId != Int32.MinValue){
				colList.Append("[UserId] = @UserId,");
				SqlParameter parameter = new SqlParameter("@UserId",SqlDbType.Int,4);
				parameter.Value = model.UserId;
				paramList.Add(parameter);
			}
												
			if(model.UserType != Int32.MinValue){
				colList.Append("[UserType] = @UserType,");
				SqlParameter parameter = new SqlParameter("@UserType",SqlDbType.Int,4);
				parameter.Value = model.UserType;
				paramList.Add(parameter);
			}
												
			if(model.ReadStatus.HasValue)
			{
				colList.Append("[ReadStatus] = @ReadStatus,");
				SqlParameter parameter = new SqlParameter("@ReadStatus",SqlDbType.Bit,1);
				parameter.Value = model.ReadStatus.Value;
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
		public static NH.Model.SysNewsRecord GetModel(int Id)
		{
			NH.Model.SysNewsRecord model = new NH.Model.SysNewsRecord();
			model.Id = Id;
			return GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.SysNewsRecord GetModel(NH.Model.SysNewsRecord model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, ArticleId, UserId, UserType, ReadStatus ");			
			strSql.Append(" from [SysNewsRecord] ");
			strSql.Append(GetSql(model, ref parameters, false));
			
			DataTable dt=SqlHelper.ExecuteDataTable(strSql.ToString(),parameters);
			if(dt.Rows.Count==0)
			{
				return null;
			}
			model=new NH.Model.SysNewsRecord();
			DataRow row = dt.Rows[0];
						
			if(row["Id"].ToString()!="")
			{
				model.Id=int.Parse(row["Id"].ToString());
			}				
																		
			if(row["ArticleId"].ToString()!="")
			{
				model.ArticleId=int.Parse(row["ArticleId"].ToString());
			}				
																		
			if(row["UserId"].ToString()!="")
			{
				model.UserId=int.Parse(row["UserId"].ToString());
			}				
																		
			if(row["UserType"].ToString()!="")
			{
				model.UserType=int.Parse(row["UserType"].ToString());
			}				
																						
															
			if(row["ReadStatus"].ToString()!="")
			{
				if((row["ReadStatus"].ToString()=="1")||(row["ReadStatus"].ToString().ToLower()=="true"))
				{
					model.ReadStatus= true;
				}
				else
				{
					model.ReadStatus= false;
				}
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
			strSql.Append(" FROM [SysNewsRecord] ");
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
			strSql.Append(" FROM [SysNewsRecord] ");
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



