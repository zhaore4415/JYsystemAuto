using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// UserSuggest
	/// </summary>
	public static partial class UserSuggest
	{
		#region 是否存在
		/// <summary>
		/// 是否存在
		/// </summary>
		public static bool Exists(NH.Model.UserSuggest model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [UserSuggest](nolock)");
			strSql.Append(GetSql(model, ref parameters, false));
			return (int)SqlHelper.ExecuteScalar(strSql.ToString(),parameters) > 0;
		}
		#endregion
				
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(NH.Model.UserSuggest model)
		{
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;
            						
			if(model.UserID != Int32.MinValue){
				colList.Append("[UserID],");
				colParamList.Append("@UserID,");
				parameter = new SqlParameter("@UserID",SqlDbType.Int,4);
				parameter.Value = model.UserID;
				sqlParamList.Add(parameter);
			}
												
			if(model.UserType != Int32.MinValue){
				colList.Append("[UserType],");
				colParamList.Append("@UserType,");
				parameter = new SqlParameter("@UserType",SqlDbType.Int,4);
				parameter.Value = model.UserType;
				sqlParamList.Add(parameter);
			}
												
			if(model.Title != null){
				colList.Append("[Title],");
				colParamList.Append("@Title,");
				parameter = new SqlParameter("@Title",SqlDbType.NVarChar,200);
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
												
			if(model.Remark != null){
				colList.Append("[Remark],");
				colParamList.Append("@Remark,");
				parameter = new SqlParameter("@Remark",SqlDbType.NVarChar,100);
				parameter.Value = model.Remark;
				sqlParamList.Add(parameter);
			}
												
			if(model.AddTime != DateTime.MinValue){
				colList.Append("[AddTime],");
				colParamList.Append("@AddTime,");
				parameter = new SqlParameter("@AddTime",SqlDbType.DateTime);
				parameter.Value = model.AddTime;
				sqlParamList.Add(parameter);
			}
												
			if(model.IsRead.HasValue)
			{
				colList.Append("[IsRead],");
				colParamList.Append("@IsRead,");
				parameter = new SqlParameter("@IsRead",SqlDbType.Bit,1);
				parameter.Value = model.IsRead.Value;                
                sqlParamList.Add(parameter);
			}
												
			if(model.Status != Int32.MinValue){
				colList.Append("[Status],");
				colParamList.Append("@Status,");
				parameter = new SqlParameter("@Status",SqlDbType.Int,4);
				parameter.Value = model.Status;
				sqlParamList.Add(parameter);
			}
						            
            string strSql = string.Format("insert into [UserSuggest] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
			strSql.Append("delete from UserSuggest ");
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
			strSql.Append("delete from [UserSuggest] ");
			strSql.Append(" where ID in ("+Idlist + ")  ");
			return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
		}
		#endregion
				
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.UserSuggest model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [UserSuggest] set ");
			strSql.Append(GetSql(model,ref parameters,true));
			strSql.Append(" where Id=@Id ");
			
            return SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters) > 0;			
		}
		#endregion
		
		#region 获取SQL及参数
		/// <summary>
		/// 获取SQL及参数
		/// </summary>
		public static string GetSql(NH.Model.UserSuggest model,ref SqlParameter[] parameters,bool isUpdate)
		{
			StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();			
									
			if(model.Id != Int32.MinValue){
				if (!isUpdate) colList.Append("[Id] = @Id,");
				SqlParameter parameter = new SqlParameter("@Id",SqlDbType.Int,4);
				parameter.Value = model.Id;
				paramList.Add(parameter);
			}
												
			if(model.UserID != Int32.MinValue){
				colList.Append("[UserID] = @UserID,");
				SqlParameter parameter = new SqlParameter("@UserID",SqlDbType.Int,4);
				parameter.Value = model.UserID;
				paramList.Add(parameter);
			}
												
			if(model.UserType != Int32.MinValue){
				colList.Append("[UserType] = @UserType,");
				SqlParameter parameter = new SqlParameter("@UserType",SqlDbType.Int,4);
				parameter.Value = model.UserType;
				paramList.Add(parameter);
			}
												
			if(model.Title != null){
				colList.Append("[Title] = @Title,");
				SqlParameter parameter = new SqlParameter("@Title",SqlDbType.NVarChar,200);
				parameter.Value = model.Title;
				paramList.Add(parameter);
			}
												
			if(model.Description != null){
				colList.Append("[Description] = @Description,");
				SqlParameter parameter = new SqlParameter("@Description",SqlDbType.NText);
				parameter.Value = model.Description;
				paramList.Add(parameter);
			}
												
			if(model.Remark != null){
				colList.Append("[Remark] = @Remark,");
				SqlParameter parameter = new SqlParameter("@Remark",SqlDbType.NVarChar,100);
				parameter.Value = model.Remark;
				paramList.Add(parameter);
			}
												
			if(model.AddTime != DateTime.MinValue){
				colList.Append("[AddTime] = @AddTime,");
				SqlParameter parameter = new SqlParameter("@AddTime",SqlDbType.DateTime);
				parameter.Value = model.AddTime;
				paramList.Add(parameter);
			}
												
			if(model.IsRead.HasValue)
			{
				colList.Append("[IsRead] = @IsRead,");
				SqlParameter parameter = new SqlParameter("@IsRead",SqlDbType.Bit,1);
				parameter.Value = model.IsRead.Value;
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
		public static NH.Model.UserSuggest GetModel(int Id)
		{
			NH.Model.UserSuggest model = new NH.Model.UserSuggest();
			model.Id = Id;
			return GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.UserSuggest GetModel(NH.Model.UserSuggest model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, UserID, UserType, Title, Description, Remark, AddTime, IsRead, Status ");			
			strSql.Append(" from [UserSuggest] ");
			strSql.Append(GetSql(model, ref parameters, false));
			
			DataTable dt=SqlHelper.ExecuteDataTable(strSql.ToString(),parameters);
			if(dt.Rows.Count==0)
			{
				return null;
			}
			model=new NH.Model.UserSuggest();
			DataRow row = dt.Rows[0];
						
			if(row["Id"].ToString()!="")
			{
				model.Id=int.Parse(row["Id"].ToString());
			}				
																		
			if(row["UserID"].ToString()!="")
			{
				model.UserID=int.Parse(row["UserID"].ToString());
			}				
																		
			if(row["UserType"].ToString()!="")
			{
				model.UserType=int.Parse(row["UserType"].ToString());
			}				
																						
			model.Title= row["Title"].ToString();
																						
			model.Description= row["Description"].ToString();
																						
			model.Remark= row["Remark"].ToString();
																		
			if(row["AddTime"].ToString()!="")
			{
				model.AddTime=DateTime.Parse(row["AddTime"].ToString());
			}				
																						
															
			if(row["IsRead"].ToString()!="")
			{
				if((row["IsRead"].ToString()=="1")||(row["IsRead"].ToString().ToLower()=="true"))
				{
					model.IsRead= true;
				}
				else
				{
					model.IsRead= false;
				}
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
			strSql.Append(" FROM [UserSuggest] ");
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
			strSql.Append(" FROM [UserSuggest] ");
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



