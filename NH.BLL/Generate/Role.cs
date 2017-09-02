﻿using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// Role
	/// </summary>
	public partial class Role
	{
		#region 是否存在该记录
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(NH.Model.Role model)
		{
			return DAL.Role.Exists(model);
		}
		#endregion
		
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int  Add(NH.Model.Role model)
		{
						return DAL.Role.Add(model);
						
		}
		#endregion
		
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.Role model)
		{
			return DAL.Role.Update(model);
		}
		#endregion
		
		#region 删除一条数据
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int Id)
		{
			return DAL.Role.Delete(Id);
		}
		#endregion
		
				#region 批量删除一批数据
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public static bool DeleteList(string Idlist )
		{
			return DAL.Role.DeleteList(Idlist );
		}
		#endregion
				
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.Role GetModel(int Id)
		{
			
			return DAL.Role.GetModel(Id);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.Role GetModel(NH.Model.Role model)
		{
			return DAL.Role.GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体，从缓存中
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public static NH.Model.Role GetModelByCache(int Id)
		{
			
			string CacheKey = "RoleModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = DAL.Role.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NH.Model.Role)objModel;
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			return DAL.Role.GetList(strWhere);
		}
		#endregion
		
		#region 获得前几行数据
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return DAL.Role.GetList(Top,strWhere,filedOrder);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.Role> GetModelList(string strWhere)
		{
			DataSet ds = DAL.Role.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.Role> DataTableToList(DataTable dt)
		{
			List<NH.Model.Role> modelList = new List<NH.Model.Role>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NH.Model.Role model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NH.Model.Role();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																				model.RoleName= dt.Rows[n]["RoleName"].ToString();
																												if(dt.Rows[n]["Status"].ToString()!="")
				{
					model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
				}
																										
				
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetAllList()
		{
			return GetList("");
		}
		#endregion   
	}
}