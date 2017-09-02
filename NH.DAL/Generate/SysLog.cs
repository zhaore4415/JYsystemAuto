using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// SysLog
	/// </summary>
	public static partial class SysLog
	{
		#region 是否存在
		/// <summary>
		/// 是否存在
		/// </summary>
		public static bool Exists(NH.Model.SysLog model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [SysLog](nolock)");
			strSql.Append(GetSql(model, ref parameters, false));
			return (int)SqlHelper.ExecuteScalar(strSql.ToString(),parameters) > 0;
		}
		#endregion
				
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(NH.Model.SysLog model)
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
												
			if(model.LoginName != null){
				colList.Append("[LoginName],");
				colParamList.Append("@LoginName,");
				parameter = new SqlParameter("@LoginName",SqlDbType.NVarChar,20);
				parameter.Value = model.LoginName;
				sqlParamList.Add(parameter);
			}
												
			if(model.UserType != Int32.MinValue){
				colList.Append("[UserType],");
				colParamList.Append("@UserType,");
				parameter = new SqlParameter("@UserType",SqlDbType.Int,4);
				parameter.Value = model.UserType;
				sqlParamList.Add(parameter);
			}
												
			if(model.EventNo != Int32.MinValue){
				colList.Append("[EventNo],");
				colParamList.Append("@EventNo,");
				parameter = new SqlParameter("@EventNo",SqlDbType.Int,4);
				parameter.Value = model.EventNo;
				sqlParamList.Add(parameter);
			}
												
			if(model.EventName != null){
				colList.Append("[EventName],");
				colParamList.Append("@EventName,");
				parameter = new SqlParameter("@EventName",SqlDbType.NVarChar,50);
				parameter.Value = model.EventName;
				sqlParamList.Add(parameter);
			}
												
			if(model.Remark != null){
				colList.Append("[Remark],");
				colParamList.Append("@Remark,");
				parameter = new SqlParameter("@Remark",SqlDbType.NVarChar,200);
				parameter.Value = model.Remark;
				sqlParamList.Add(parameter);
			}
												
			if(model.IP != null){
				colList.Append("[IP],");
				colParamList.Append("@IP,");
				parameter = new SqlParameter("@IP",SqlDbType.NVarChar,20);
				parameter.Value = model.IP;
				sqlParamList.Add(parameter);
			}
												
			if(model.Address != null){
				colList.Append("[Address],");
				colParamList.Append("@Address,");
				parameter = new SqlParameter("@Address",SqlDbType.NVarChar,20);
				parameter.Value = model.Address;
				sqlParamList.Add(parameter);
			}
												
			if(model.AddTime != DateTime.MinValue){
				colList.Append("[AddTime],");
				colParamList.Append("@AddTime,");
				parameter = new SqlParameter("@AddTime",SqlDbType.DateTime);
				parameter.Value = model.AddTime;
				sqlParamList.Add(parameter);
			}
												
			if(model.TargeObjID.HasValue)
			{
				colList.Append("[TargeObjID],");
				colParamList.Append("@TargeObjID,");
				parameter = new SqlParameter("@TargeObjID",SqlDbType.Int,4);
				if(model.TargeObjID.Value != Int32.MinValue)
                	parameter.Value = model.TargeObjID.Value;
                else 
                	parameter.Value = DBNull.Value;
                                
                sqlParamList.Add(parameter);
			}
						            
            string strSql = string.Format("insert into [SysLog] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
			strSql.Append("delete from SysLog ");
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
			strSql.Append("delete from [SysLog] ");
			strSql.Append(" where ID in ("+Idlist + ")  ");
			return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
		}
		#endregion
				
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.SysLog model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [SysLog] set ");
			strSql.Append(GetSql(model,ref parameters,true));
			strSql.Append(" where Id=@Id ");
			
            return SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters) > 0;			
		}
		#endregion
		
		#region 获取SQL及参数
		/// <summary>
		/// 获取SQL及参数
		/// </summary>
		public static string GetSql(NH.Model.SysLog model,ref SqlParameter[] parameters,bool isUpdate)
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
												
			if(model.LoginName != null){
				colList.Append("[LoginName] = @LoginName,");
				SqlParameter parameter = new SqlParameter("@LoginName",SqlDbType.NVarChar,20);
				parameter.Value = model.LoginName;
				paramList.Add(parameter);
			}
												
			if(model.UserType != Int32.MinValue){
				colList.Append("[UserType] = @UserType,");
				SqlParameter parameter = new SqlParameter("@UserType",SqlDbType.Int,4);
				parameter.Value = model.UserType;
				paramList.Add(parameter);
			}
												
			if(model.EventNo != Int32.MinValue){
				colList.Append("[EventNo] = @EventNo,");
				SqlParameter parameter = new SqlParameter("@EventNo",SqlDbType.Int,4);
				parameter.Value = model.EventNo;
				paramList.Add(parameter);
			}
												
			if(model.EventName != null){
				colList.Append("[EventName] = @EventName,");
				SqlParameter parameter = new SqlParameter("@EventName",SqlDbType.NVarChar,50);
				parameter.Value = model.EventName;
				paramList.Add(parameter);
			}
												
			if(model.Remark != null){
				colList.Append("[Remark] = @Remark,");
				SqlParameter parameter = new SqlParameter("@Remark",SqlDbType.NVarChar,200);
				parameter.Value = model.Remark;
				paramList.Add(parameter);
			}
												
			if(model.IP != null){
				colList.Append("[IP] = @IP,");
				SqlParameter parameter = new SqlParameter("@IP",SqlDbType.NVarChar,20);
				parameter.Value = model.IP;
				paramList.Add(parameter);
			}
												
			if(model.Address != null){
				colList.Append("[Address] = @Address,");
				SqlParameter parameter = new SqlParameter("@Address",SqlDbType.NVarChar,20);
				parameter.Value = model.Address;
				paramList.Add(parameter);
			}
												
			if(model.AddTime != DateTime.MinValue){
				colList.Append("[AddTime] = @AddTime,");
				SqlParameter parameter = new SqlParameter("@AddTime",SqlDbType.DateTime);
				parameter.Value = model.AddTime;
				paramList.Add(parameter);
			}
												
			if(model.TargeObjID.HasValue)
			{
				colList.Append("[TargeObjID] = @TargeObjID,");
				SqlParameter parameter = new SqlParameter("@TargeObjID",SqlDbType.Int,4);
				parameter.Value = model.TargeObjID.Value;
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
		public static NH.Model.SysLog GetModel(int Id)
		{
			NH.Model.SysLog model = new NH.Model.SysLog();
			model.Id = Id;
			return GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.SysLog GetModel(NH.Model.SysLog model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, UserID, LoginName, UserType, EventNo, EventName, Remark, IP, Address, AddTime, TargeObjID ");			
			strSql.Append(" from [SysLog] ");
			strSql.Append(GetSql(model, ref parameters, false));
			
			DataTable dt=SqlHelper.ExecuteDataTable(strSql.ToString(),parameters);
			if(dt.Rows.Count==0)
			{
				return null;
			}
			model=new NH.Model.SysLog();
			DataRow row = dt.Rows[0];
						
			if(row["Id"].ToString()!="")
			{
				model.Id=int.Parse(row["Id"].ToString());
			}				
																		
			if(row["UserID"].ToString()!="")
			{
				model.UserID=int.Parse(row["UserID"].ToString());
			}				
																						
			model.LoginName= row["LoginName"].ToString();
																		
			if(row["UserType"].ToString()!="")
			{
				model.UserType=int.Parse(row["UserType"].ToString());
			}				
																		
			if(row["EventNo"].ToString()!="")
			{
				model.EventNo=int.Parse(row["EventNo"].ToString());
			}				
																						
			model.EventName= row["EventName"].ToString();
																						
			model.Remark= row["Remark"].ToString();
																						
			model.IP= row["IP"].ToString();
																						
			model.Address= row["Address"].ToString();
																		
			if(row["AddTime"].ToString()!="")
			{
				model.AddTime=DateTime.Parse(row["AddTime"].ToString());
			}				
																		
			if(row["TargeObjID"].ToString()!="")
			{
				model.TargeObjID=int.Parse(row["TargeObjID"].ToString());
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
			strSql.Append(" FROM [SysLog] ");
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
			strSql.Append(" FROM [SysLog] ");
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



