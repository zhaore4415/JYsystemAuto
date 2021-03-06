﻿using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// Salary
	/// </summary>
	public partial class Salary
	{
		#region 是否存在该记录
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(NH.Model.Salary model)
		{
			return DAL.Salary.Exists(model);
		}
		#endregion
		
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static void  Add(NH.Model.Salary model)
		{
						
			DAL.Salary.Add(model);
						
		}
		#endregion
		
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.Salary model)
		{
			return DAL.Salary.Update(model);
		}
		#endregion
		
		#region 删除一条数据
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int Id)
		{
			return DAL.Salary.Delete(Id);
		}
		#endregion
		
				
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.Salary GetModel(int Id)
		{
			
			return DAL.Salary.GetModel(Id);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.Salary GetModel(NH.Model.Salary model)
		{
			return DAL.Salary.GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体，从缓存中
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public static NH.Model.Salary GetModelByCache(int Id)
		{
			
			string CacheKey = "SalaryModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = DAL.Salary.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NH.Model.Salary)objModel;
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			return DAL.Salary.GetList(strWhere);
		}
		#endregion
		
		#region 获得前几行数据
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return DAL.Salary.GetList(Top,strWhere,filedOrder);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.Salary> GetModelList(string strWhere)
		{
			DataSet ds = DAL.Salary.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.Salary> DataTableToList(DataTable dt)
		{
			List<NH.Model.Salary> modelList = new List<NH.Model.Salary>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NH.Model.Salary model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NH.Model.Salary();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																				model.SalaryName= dt.Rows[n]["SalaryName"].ToString();
																												if(dt.Rows[n]["Status"].ToString()!="")
				{
					model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
				}
																																if(dt.Rows[n]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(dt.Rows[n]["Sort"].ToString());
				}
																																if(dt.Rows[n]["Salary1"].ToString()!="")
				{
					model.Salary1=int.Parse(dt.Rows[n]["Salary1"].ToString());
				}
																																if(dt.Rows[n]["Salary2"].ToString()!="")
				{
					model.Salary2=int.Parse(dt.Rows[n]["Salary2"].ToString());
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