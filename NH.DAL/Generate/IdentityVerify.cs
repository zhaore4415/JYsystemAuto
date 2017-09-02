using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// IdentityVerify
	/// </summary>
	public static partial class IdentityVerify
	{
		#region 是否存在
		/// <summary>
		/// 是否存在
		/// </summary>
		public static bool Exists(NH.Model.IdentityVerify model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [IdentityVerify](nolock)");
			strSql.Append(GetSql(model, ref parameters, false));
			return (int)SqlHelper.ExecuteScalar(strSql.ToString(),parameters) > 0;
		}
		#endregion
				
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(NH.Model.IdentityVerify model)
		{
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;
            						
			if(model.MemberID != Int32.MinValue){
				colList.Append("[MemberID],");
				colParamList.Append("@MemberID,");
				parameter = new SqlParameter("@MemberID",SqlDbType.Int,4);
				parameter.Value = model.MemberID;
				sqlParamList.Add(parameter);
			}
												
			if(model.IdentityImg != null){
				colList.Append("[IdentityImg],");
				colParamList.Append("@IdentityImg,");
				parameter = new SqlParameter("@IdentityImg",SqlDbType.NVarChar,50);
				parameter.Value = model.IdentityImg;
				sqlParamList.Add(parameter);
			}
												
			if(model.IdentityNo != null){
				colList.Append("[IdentityNo],");
				colParamList.Append("@IdentityNo,");
				parameter = new SqlParameter("@IdentityNo",SqlDbType.NVarChar,50);
				parameter.Value = model.IdentityNo;
				sqlParamList.Add(parameter);
			}
												
			if(model.ExpireDate != DateTime.MinValue){
				colList.Append("[ExpireDate],");
				colParamList.Append("@ExpireDate,");
				parameter = new SqlParameter("@ExpireDate",SqlDbType.SmallDateTime);
				parameter.Value = model.ExpireDate;
				sqlParamList.Add(parameter);
			}
												
			if(model.Sex.HasValue)
			{
				colList.Append("[Sex],");
				colParamList.Append("@Sex,");
				parameter = new SqlParameter("@Sex",SqlDbType.Bit,1);
				parameter.Value = model.Sex.Value;                
                sqlParamList.Add(parameter);
			}
												
			if(model.Tel != null){
				colList.Append("[Tel],");
				colParamList.Append("@Tel,");
				parameter = new SqlParameter("@Tel",SqlDbType.NVarChar,20);
				parameter.Value = model.Tel;
				sqlParamList.Add(parameter);
			}
												
			if(model.QQ != null){
				colList.Append("[QQ],");
				colParamList.Append("@QQ,");
				parameter = new SqlParameter("@QQ",SqlDbType.NVarChar,20);
				parameter.Value = model.QQ;
				sqlParamList.Add(parameter);
			}
												
			if(model.Status != Int32.MinValue){
				colList.Append("[Status],");
				colParamList.Append("@Status,");
				parameter = new SqlParameter("@Status",SqlDbType.Int,4);
				parameter.Value = model.Status;
				sqlParamList.Add(parameter);
			}
												
			if(model.AddTime != DateTime.MinValue){
				colList.Append("[AddTime],");
				colParamList.Append("@AddTime,");
				parameter = new SqlParameter("@AddTime",SqlDbType.DateTime);
				parameter.Value = model.AddTime;
				sqlParamList.Add(parameter);
			}
						            
            string strSql = string.Format("insert into [IdentityVerify] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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
			strSql.Append("delete from IdentityVerify ");
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
			strSql.Append("delete from [IdentityVerify] ");
			strSql.Append(" where ID in ("+Idlist + ")  ");
			return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
		}
		#endregion
				
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.IdentityVerify model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [IdentityVerify] set ");
			strSql.Append(GetSql(model,ref parameters,true));
			strSql.Append(" where Id=@Id ");
			
            return SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters) > 0;			
		}
		#endregion
		
		#region 获取SQL及参数
		/// <summary>
		/// 获取SQL及参数
		/// </summary>
		public static string GetSql(NH.Model.IdentityVerify model,ref SqlParameter[] parameters,bool isUpdate)
		{
			StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();			
									
			if(model.Id != Int32.MinValue){
				if (!isUpdate) colList.Append("[Id] = @Id,");
				SqlParameter parameter = new SqlParameter("@Id",SqlDbType.Int,4);
				parameter.Value = model.Id;
				paramList.Add(parameter);
			}
												
			if(model.MemberID != Int32.MinValue){
				colList.Append("[MemberID] = @MemberID,");
				SqlParameter parameter = new SqlParameter("@MemberID",SqlDbType.Int,4);
				parameter.Value = model.MemberID;
				paramList.Add(parameter);
			}
												
			if(model.IdentityImg != null){
				colList.Append("[IdentityImg] = @IdentityImg,");
				SqlParameter parameter = new SqlParameter("@IdentityImg",SqlDbType.NVarChar,50);
				parameter.Value = model.IdentityImg;
				paramList.Add(parameter);
			}
												
			if(model.IdentityNo != null){
				colList.Append("[IdentityNo] = @IdentityNo,");
				SqlParameter parameter = new SqlParameter("@IdentityNo",SqlDbType.NVarChar,50);
				parameter.Value = model.IdentityNo;
				paramList.Add(parameter);
			}
												
			if(model.ExpireDate != DateTime.MinValue){
				colList.Append("[ExpireDate] = @ExpireDate,");
				SqlParameter parameter = new SqlParameter("@ExpireDate",SqlDbType.SmallDateTime);
				parameter.Value = model.ExpireDate;
				paramList.Add(parameter);
			}
												
			if(model.Sex.HasValue)
			{
				colList.Append("[Sex] = @Sex,");
				SqlParameter parameter = new SqlParameter("@Sex",SqlDbType.Bit,1);
				parameter.Value = model.Sex.Value;
                paramList.Add(parameter);
			}
												
			if(model.Tel != null){
				colList.Append("[Tel] = @Tel,");
				SqlParameter parameter = new SqlParameter("@Tel",SqlDbType.NVarChar,20);
				parameter.Value = model.Tel;
				paramList.Add(parameter);
			}
												
			if(model.QQ != null){
				colList.Append("[QQ] = @QQ,");
				SqlParameter parameter = new SqlParameter("@QQ",SqlDbType.NVarChar,20);
				parameter.Value = model.QQ;
				paramList.Add(parameter);
			}
												
			if(model.Status != Int32.MinValue){
				colList.Append("[Status] = @Status,");
				SqlParameter parameter = new SqlParameter("@Status",SqlDbType.Int,4);
				parameter.Value = model.Status;
				paramList.Add(parameter);
			}
												
			if(model.AddTime != DateTime.MinValue){
				colList.Append("[AddTime] = @AddTime,");
				SqlParameter parameter = new SqlParameter("@AddTime",SqlDbType.DateTime);
				parameter.Value = model.AddTime;
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
		public static NH.Model.IdentityVerify GetModel(int Id)
		{
			NH.Model.IdentityVerify model = new NH.Model.IdentityVerify();
			model.Id = Id;
			return GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.IdentityVerify GetModel(NH.Model.IdentityVerify model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, MemberID, IdentityImg, IdentityNo, ExpireDate, Sex, Tel, QQ, Status, AddTime ");			
			strSql.Append(" from [IdentityVerify] ");
			strSql.Append(GetSql(model, ref parameters, false));
			
			DataTable dt=SqlHelper.ExecuteDataTable(strSql.ToString(),parameters);
			if(dt.Rows.Count==0)
			{
				return null;
			}
			model=new NH.Model.IdentityVerify();
			DataRow row = dt.Rows[0];
						
			if(row["Id"].ToString()!="")
			{
				model.Id=int.Parse(row["Id"].ToString());
			}				
																		
			if(row["MemberID"].ToString()!="")
			{
				model.MemberID=int.Parse(row["MemberID"].ToString());
			}				
																						
			model.IdentityImg= row["IdentityImg"].ToString();
																						
			model.IdentityNo= row["IdentityNo"].ToString();
																		
			if(row["ExpireDate"].ToString()!="")
			{
				model.ExpireDate=DateTime.Parse(row["ExpireDate"].ToString());
			}				
																						
															
			if(row["Sex"].ToString()!="")
			{
				if((row["Sex"].ToString()=="1")||(row["Sex"].ToString().ToLower()=="true"))
				{
					model.Sex= true;
				}
				else
				{
					model.Sex= false;
				}
			}
													
			model.Tel= row["Tel"].ToString();
																						
			model.QQ= row["QQ"].ToString();
																		
			if(row["Status"].ToString()!="")
			{
				model.Status=int.Parse(row["Status"].ToString());
			}				
																		
			if(row["AddTime"].ToString()!="")
			{
				model.AddTime=DateTime.Parse(row["AddTime"].ToString());
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
			strSql.Append(" FROM [IdentityVerify] ");
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
			strSql.Append(" FROM [IdentityVerify] ");
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



