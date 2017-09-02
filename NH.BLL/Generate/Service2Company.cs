using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// Service2Company
	/// </summary>
	public partial class Service2Company
	{
		#region �Ƿ���ڸü�¼
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public static bool Exists(NH.Model.Service2Company model)
		{
			return DAL.Service2Company.Exists(model);
		}
		#endregion
		
		#region ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public static int  Add(NH.Model.Service2Company model)
		{
						return DAL.Service2Company.Add(model);
						
		}
		#endregion
		
		#region ����һ������
		/// <summary>
		/// ����һ������
		/// </summary>
		public static bool Update(NH.Model.Service2Company model)
		{
			return DAL.Service2Company.Update(model);
		}
		#endregion
		
		#region ɾ��һ������
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public static bool Delete(int Id)
		{
			return DAL.Service2Company.Delete(Id);
		}
		#endregion
		
				#region ����ɾ��һ������
		/// <summary>
		/// ����ɾ��һ������
		/// </summary>
		public static bool DeleteList(string Idlist )
		{
			return DAL.Service2Company.DeleteList(Idlist );
		}
		#endregion
				
		#region �õ�һ������ʵ��
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public static NH.Model.Service2Company GetModel(int Id)
		{
			
			return DAL.Service2Company.GetModel(Id);
		}
		#endregion
		
		#region �õ�һ������ʵ��
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public static NH.Model.Service2Company GetModel(NH.Model.Service2Company model)
		{
			return DAL.Service2Company.GetModel(model);
		}
		#endregion
		
		#region �õ�һ������ʵ�壬�ӻ�����
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public static NH.Model.Service2Company GetModelByCache(int Id)
		{
			
			string CacheKey = "Service2CompanyModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = DAL.Service2Company.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NH.Model.Service2Company)objModel;
		}
		#endregion
		
		#region ��������б�
		/// <summary>
		/// ��������б�
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			return DAL.Service2Company.GetList(strWhere);
		}
		#endregion
		
		#region ���ǰ��������
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return DAL.Service2Company.GetList(Top,strWhere,filedOrder);
		}
		#endregion
		
		#region ��������б�
		/// <summary>
		/// ��������б�
		/// </summary>
		public static List<NH.Model.Service2Company> GetModelList(string strWhere)
		{
			DataSet ds = DAL.Service2Company.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion
		
		#region ��������б�
		/// <summary>
		/// ��������б�
		/// </summary>
		public static List<NH.Model.Service2Company> DataTableToList(DataTable dt)
		{
			List<NH.Model.Service2Company> modelList = new List<NH.Model.Service2Company>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NH.Model.Service2Company model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NH.Model.Service2Company();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["CompanyId"].ToString()!="")
				{
					model.CompanyId=int.Parse(dt.Rows[n]["CompanyId"].ToString());
				}
																																if(dt.Rows[n]["ServiceId"].ToString()!="")
				{
					model.ServiceId=int.Parse(dt.Rows[n]["ServiceId"].ToString());
				}
																																if(dt.Rows[n]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
				}
																										
				
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion
		
		#region ��������б�
		/// <summary>
		/// ��������б�
		/// </summary>
		public static DataSet GetAllList()
		{
			return GetList("");
		}
		#endregion   
	}
}