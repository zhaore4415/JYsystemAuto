using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// SysLog
	/// </summary>
	public partial class SysLog
	{
		#region 是否存在该记录
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(NH.Model.SysLog model)
		{
			return DAL.SysLog.Exists(model);
		}
		#endregion
		
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int  Add(NH.Model.SysLog model)
		{
						return DAL.SysLog.Add(model);
						
		}
		#endregion
		
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.SysLog model)
		{
			return DAL.SysLog.Update(model);
		}
		#endregion
		
		#region 删除一条数据
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int Id)
		{
			return DAL.SysLog.Delete(Id);
		}
		#endregion
		
				#region 批量删除一批数据
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public static bool DeleteList(string Idlist )
		{
			return DAL.SysLog.DeleteList(Idlist );
		}
		#endregion
				
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.SysLog GetModel(int Id)
		{
			
			return DAL.SysLog.GetModel(Id);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.SysLog GetModel(NH.Model.SysLog model)
		{
			return DAL.SysLog.GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体，从缓存中
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public static NH.Model.SysLog GetModelByCache(int Id)
		{
			
			string CacheKey = "SysLogModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = DAL.SysLog.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NH.Model.SysLog)objModel;
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			return DAL.SysLog.GetList(strWhere);
		}
		#endregion
		
		#region 获得前几行数据
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return DAL.SysLog.GetList(Top,strWhere,filedOrder);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.SysLog> GetModelList(string strWhere)
		{
			DataSet ds = DAL.SysLog.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.SysLog> DataTableToList(DataTable dt)
		{
			List<NH.Model.SysLog> modelList = new List<NH.Model.SysLog>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NH.Model.SysLog model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NH.Model.SysLog();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(dt.Rows[n]["UserID"].ToString());
				}
																																				model.LoginName= dt.Rows[n]["LoginName"].ToString();
																												if(dt.Rows[n]["UserType"].ToString()!="")
				{
					model.UserType=int.Parse(dt.Rows[n]["UserType"].ToString());
				}
																																if(dt.Rows[n]["EventNo"].ToString()!="")
				{
					model.EventNo=int.Parse(dt.Rows[n]["EventNo"].ToString());
				}
																																				model.EventName= dt.Rows[n]["EventName"].ToString();
																																model.Remark= dt.Rows[n]["Remark"].ToString();
																																model.IP= dt.Rows[n]["IP"].ToString();
																																model.Address= dt.Rows[n]["Address"].ToString();
																												if(dt.Rows[n]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
				}
																																if(dt.Rows[n]["TargeObjID"].ToString()!="")
				{
					model.TargeObjID=int.Parse(dt.Rows[n]["TargeObjID"].ToString());
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