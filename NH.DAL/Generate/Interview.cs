using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// Interview
	/// </summary>
	public static partial class Interview
	{
		#region 是否存在
		/// <summary>
		/// 是否存在
		/// </summary>
		public static bool Exists(NH.Model.Interview model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Interview](nolock)");
			strSql.Append(GetSql(model, ref parameters, false));
			return (int)SqlHelper.ExecuteScalar(strSql.ToString(),parameters) > 0;
		}
		#endregion
				
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(NH.Model.Interview model)
		{
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;
            						
			if(model.CompanyID != Int32.MinValue){
				colList.Append("[CompanyID],");
				colParamList.Append("@CompanyID,");
				parameter = new SqlParameter("@CompanyID",SqlDbType.Int,4);
				parameter.Value = model.CompanyID;
				sqlParamList.Add(parameter);
			}
												
			if(model.MemberID != Int32.MinValue){
				colList.Append("[MemberID],");
				colParamList.Append("@MemberID,");
				parameter = new SqlParameter("@MemberID",SqlDbType.Int,4);
				parameter.Value = model.MemberID;
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
												
			if(model.AddTime != DateTime.MinValue){
				colList.Append("[AddTime],");
				colParamList.Append("@AddTime,");
				parameter = new SqlParameter("@AddTime",SqlDbType.DateTime);
				parameter.Value = model.AddTime;
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
												
			if(model.ReadTime.HasValue)
			{
				colList.Append("[ReadTime],");
				colParamList.Append("@ReadTime,");
				parameter = new SqlParameter("@ReadTime",SqlDbType.DateTime);
				if(model.ReadTime.Value != DateTime.MinValue)
                	parameter.Value = model.ReadTime.Value;
                else 
                	parameter.Value = DBNull.Value;
                                
                sqlParamList.Add(parameter);
			}
												
			if(model.IsAccept.HasValue)
			{
				colList.Append("[IsAccept],");
				colParamList.Append("@IsAccept,");
				parameter = new SqlParameter("@IsAccept",SqlDbType.Bit,1);
				parameter.Value = model.IsAccept.Value;                
                sqlParamList.Add(parameter);
			}
						            
            string strSql = string.Format("insert into [Interview] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
			strSql.Append("delete from Interview ");
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
			strSql.Append("delete from [Interview] ");
			strSql.Append(" where ID in ("+Idlist + ")  ");
			return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
		}
		#endregion
				
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.Interview model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Interview] set ");
			strSql.Append(GetSql(model,ref parameters,true));
			strSql.Append(" where Id=@Id ");
			
            return SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters) > 0;			
		}
		#endregion
		
		#region 获取SQL及参数
		/// <summary>
		/// 获取SQL及参数
		/// </summary>
		public static string GetSql(NH.Model.Interview model,ref SqlParameter[] parameters,bool isUpdate)
		{
			StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();			
									
			if(model.Id != Int32.MinValue){
				if (!isUpdate) colList.Append("[Id] = @Id,");
				SqlParameter parameter = new SqlParameter("@Id",SqlDbType.Int,4);
				parameter.Value = model.Id;
				paramList.Add(parameter);
			}
												
			if(model.CompanyID != Int32.MinValue){
				colList.Append("[CompanyID] = @CompanyID,");
				SqlParameter parameter = new SqlParameter("@CompanyID",SqlDbType.Int,4);
				parameter.Value = model.CompanyID;
				paramList.Add(parameter);
			}
												
			if(model.MemberID != Int32.MinValue){
				colList.Append("[MemberID] = @MemberID,");
				SqlParameter parameter = new SqlParameter("@MemberID",SqlDbType.Int,4);
				parameter.Value = model.MemberID;
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
												
			if(model.AddTime != DateTime.MinValue){
				colList.Append("[AddTime] = @AddTime,");
				SqlParameter parameter = new SqlParameter("@AddTime",SqlDbType.DateTime);
				parameter.Value = model.AddTime;
				paramList.Add(parameter);
			}
												
			if(model.ReadStatus.HasValue)
			{
				colList.Append("[ReadStatus] = @ReadStatus,");
				SqlParameter parameter = new SqlParameter("@ReadStatus",SqlDbType.Bit,1);
				parameter.Value = model.ReadStatus.Value;
                paramList.Add(parameter);
			}
												
			if(model.ReadTime.HasValue)
			{
				colList.Append("[ReadTime] = @ReadTime,");
				SqlParameter parameter = new SqlParameter("@ReadTime",SqlDbType.DateTime);
				parameter.Value = model.ReadTime.Value;
                paramList.Add(parameter);
			}
												
			if(model.IsAccept.HasValue)
			{
				colList.Append("[IsAccept] = @IsAccept,");
				SqlParameter parameter = new SqlParameter("@IsAccept",SqlDbType.Bit,1);
				parameter.Value = model.IsAccept.Value;
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
		public static NH.Model.Interview GetModel(int Id)
		{
			NH.Model.Interview model = new NH.Model.Interview();
			model.Id = Id;
			return GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.Interview GetModel(NH.Model.Interview model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, CompanyID, MemberID, Title, Description, AddTime, ReadStatus, ReadTime, IsAccept ");			
			strSql.Append(" from [Interview] ");
			strSql.Append(GetSql(model, ref parameters, false));
			
			DataTable dt=SqlHelper.ExecuteDataTable(strSql.ToString(),parameters);
			if(dt.Rows.Count==0)
			{
				return null;
			}
			model=new NH.Model.Interview();
			DataRow row = dt.Rows[0];
						
			if(row["Id"].ToString()!="")
			{
				model.Id=int.Parse(row["Id"].ToString());
			}				
																		
			if(row["CompanyID"].ToString()!="")
			{
				model.CompanyID=int.Parse(row["CompanyID"].ToString());
			}				
																		
			if(row["MemberID"].ToString()!="")
			{
				model.MemberID=int.Parse(row["MemberID"].ToString());
			}				
																						
			model.Title= row["Title"].ToString();
																						
			model.Description= row["Description"].ToString();
																		
			if(row["AddTime"].ToString()!="")
			{
				model.AddTime=DateTime.Parse(row["AddTime"].ToString());
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
									
			if(row["ReadTime"].ToString()!="")
			{
				model.ReadTime=DateTime.Parse(row["ReadTime"].ToString());
			}				
																						
															
			if(row["IsAccept"].ToString()!="")
			{
				if((row["IsAccept"].ToString()=="1")||(row["IsAccept"].ToString().ToLower()=="true"))
				{
					model.IsAccept= true;
				}
				else
				{
					model.IsAccept= false;
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
			strSql.Append(" FROM [Interview] ");
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
			strSql.Append(" FROM [Interview] ");
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



