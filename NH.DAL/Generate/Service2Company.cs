using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// Service2Company
	/// </summary>
	public static partial class Service2Company
	{
		#region �Ƿ����
		/// <summary>
		/// �Ƿ����
		/// </summary>
		public static bool Exists(NH.Model.Service2Company model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [Service2Company](nolock)");
			strSql.Append(GetSql(model, ref parameters, false));
			return (int)SqlHelper.ExecuteScalar(strSql.ToString(),parameters) > 0;
		}
		#endregion
				
		#region ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public static int Add(NH.Model.Service2Company model)
		{
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;
            						
			if(model.CompanyId != Int32.MinValue){
				colList.Append("[CompanyId],");
				colParamList.Append("@CompanyId,");
				parameter = new SqlParameter("@CompanyId",SqlDbType.Int,4);
				parameter.Value = model.CompanyId;
				sqlParamList.Add(parameter);
			}
												
			if(model.ServiceId != Int32.MinValue){
				colList.Append("[ServiceId],");
				colParamList.Append("@ServiceId,");
				parameter = new SqlParameter("@ServiceId",SqlDbType.Int,4);
				parameter.Value = model.ServiceId;
				sqlParamList.Add(parameter);
			}
												
			if(model.AddTime != DateTime.MinValue){
				colList.Append("[AddTime],");
				colParamList.Append("@AddTime,");
				parameter = new SqlParameter("@AddTime",SqlDbType.DateTime);
				parameter.Value = model.AddTime;
				sqlParamList.Add(parameter);
			}
						            
            string strSql = string.Format("insert into [Service2Company] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
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

		#region ɾ��һ������
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public static bool Delete(int Id)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Service2Company] ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters) > 0;
		}
		#endregion
		
				
		#region ����ɾ��һ������
		/// <summary>
		/// ����ɾ��һ������
		/// </summary>
		public static bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Service2Company] ");
			strSql.Append(" where ID in ("+Idlist + ")  ");
			return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
		}
		#endregion
				
		#region ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public static bool Update(NH.Model.Service2Company model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [Service2Company] set ");
			strSql.Append(GetSql(model,ref parameters,true));
			strSql.Append(" where Id=@Id ");
			
            return SqlHelper.ExecuteNonQuery(strSql.ToString(),parameters) > 0;			
		}
		#endregion
		
		#region ��ȡSQL������
		/// <summary>
		/// ��ȡSQL������
		/// </summary>
		public static string GetSql(NH.Model.Service2Company model,ref SqlParameter[] parameters,bool isUpdate)
		{
			StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();			
									
			if(model.Id != Int32.MinValue){
				if (!isUpdate) colList.Append("[Id] = @Id,");
				SqlParameter parameter = new SqlParameter("@Id",SqlDbType.Int,4);
				parameter.Value = model.Id;
				paramList.Add(parameter);
			}
												
			if(model.CompanyId != Int32.MinValue){
				colList.Append("[CompanyId] = @CompanyId,");
				SqlParameter parameter = new SqlParameter("@CompanyId",SqlDbType.Int,4);
				parameter.Value = model.CompanyId;
				paramList.Add(parameter);
			}
												
			if(model.ServiceId != Int32.MinValue){
				colList.Append("[ServiceId] = @ServiceId,");
				SqlParameter parameter = new SqlParameter("@ServiceId",SqlDbType.Int,4);
				parameter.Value = model.ServiceId;
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
		
		#region �õ�һ������ʵ��
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public static NH.Model.Service2Company GetModel(int Id)
		{
			NH.Model.Service2Company model = new NH.Model.Service2Company();
			model.Id = Id;
			return GetModel(model);
		}
		#endregion
		
		#region �õ�һ������ʵ��
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public static NH.Model.Service2Company GetModel(NH.Model.Service2Company model)
		{
			SqlParameter[] parameters = null;
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, CompanyId, ServiceId, AddTime ");			
			strSql.Append(" from [Service2Company] ");
			strSql.Append(GetSql(model, ref parameters, false));
			
			DataTable dt=SqlHelper.ExecuteDataTable(strSql.ToString(),parameters);
			if(dt.Rows.Count==0)
			{
				return null;
			}
			model=new NH.Model.Service2Company();
			DataRow row = dt.Rows[0];
						
			if(row["Id"].ToString()!="")
			{
				model.Id=int.Parse(row["Id"].ToString());
			}				
																		
			if(row["CompanyId"].ToString()!="")
			{
				model.CompanyId=int.Parse(row["CompanyId"].ToString());
			}				
																		
			if(row["ServiceId"].ToString()!="")
			{
				model.ServiceId=int.Parse(row["ServiceId"].ToString());
			}				
																		
			if(row["AddTime"].ToString()!="")
			{
				model.AddTime=DateTime.Parse(row["AddTime"].ToString());
			}				
																					
			return model;			
		}
		#endregion
		
		#region ��������б�
		/// <summary>
		/// ��������б�
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [Service2Company] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return SqlHelper.ExecuteDataSet(strSql.ToString());
		}
		#endregion
		
		#region ���ǰ��������
		/// <summary>
		/// ���ǰ��������
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
			strSql.Append(" FROM [Service2Company] ");
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



