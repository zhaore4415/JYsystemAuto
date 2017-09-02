using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// UserRole
	/// </summary>
	public partial class UserRole
	{
		#region 是否存在该记录
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(NH.Model.UserRole model)
		{
			return DAL.UserRole.Exists(model);
		}
		#endregion
		
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int  Add(NH.Model.UserRole model)
		{
						return DAL.UserRole.Add(model);
						
		}
		#endregion
		
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.UserRole model)
		{
			return DAL.UserRole.Update(model);
		}
		#endregion
		
		#region 删除一条数据
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int Id)
		{
			return DAL.UserRole.Delete(Id);
		}
		#endregion
		
				#region 批量删除一批数据
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public static bool DeleteList(string Idlist )
		{
			return DAL.UserRole.DeleteList(Idlist );
		}
		#endregion
				
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.UserRole GetModel(int Id)
		{
			
			return DAL.UserRole.GetModel(Id);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.UserRole GetModel(NH.Model.UserRole model)
		{
			return DAL.UserRole.GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体，从缓存中
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public static NH.Model.UserRole GetModelByCache(int Id)
		{
			
			string CacheKey = "UserRoleModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = DAL.UserRole.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NH.Model.UserRole)objModel;
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			return DAL.UserRole.GetList(strWhere);
		}
		#endregion
		
		#region 获得前几行数据
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return DAL.UserRole.GetList(Top,strWhere,filedOrder);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.UserRole> GetModelList(string strWhere)
		{
			DataSet ds = DAL.UserRole.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.UserRole> DataTableToList(DataTable dt)
		{
			List<NH.Model.UserRole> modelList = new List<NH.Model.UserRole>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NH.Model.UserRole model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NH.Model.UserRole();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(dt.Rows[n]["UserId"].ToString());
				}
																																if(dt.Rows[n]["RoleId"].ToString()!="")
				{
					model.RoleId=int.Parse(dt.Rows[n]["RoleId"].ToString());
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