using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// UserSuggest
	/// </summary>
	public partial class UserSuggest
	{
		#region 是否存在该记录
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(NH.Model.UserSuggest model)
		{
			return DAL.UserSuggest.Exists(model);
		}
		#endregion
		
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int  Add(NH.Model.UserSuggest model)
		{
						return DAL.UserSuggest.Add(model);
						
		}
		#endregion
		
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.UserSuggest model)
		{
			return DAL.UserSuggest.Update(model);
		}
		#endregion
		
		#region 删除一条数据
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int Id)
		{
			return DAL.UserSuggest.Delete(Id);
		}
		#endregion
		
				#region 批量删除一批数据
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public static bool DeleteList(string Idlist )
		{
			return DAL.UserSuggest.DeleteList(Idlist );
		}
		#endregion
				
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.UserSuggest GetModel(int Id)
		{
			
			return DAL.UserSuggest.GetModel(Id);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.UserSuggest GetModel(NH.Model.UserSuggest model)
		{
			return DAL.UserSuggest.GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体，从缓存中
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public static NH.Model.UserSuggest GetModelByCache(int Id)
		{
			
			string CacheKey = "UserSuggestModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = DAL.UserSuggest.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NH.Model.UserSuggest)objModel;
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			return DAL.UserSuggest.GetList(strWhere);
		}
		#endregion
		
		#region 获得前几行数据
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return DAL.UserSuggest.GetList(Top,strWhere,filedOrder);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.UserSuggest> GetModelList(string strWhere)
		{
			DataSet ds = DAL.UserSuggest.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.UserSuggest> DataTableToList(DataTable dt)
		{
			List<NH.Model.UserSuggest> modelList = new List<NH.Model.UserSuggest>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NH.Model.UserSuggest model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NH.Model.UserSuggest();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(dt.Rows[n]["UserID"].ToString());
				}
																																if(dt.Rows[n]["UserType"].ToString()!="")
				{
					model.UserType=int.Parse(dt.Rows[n]["UserType"].ToString());
				}
																																				model.Title= dt.Rows[n]["Title"].ToString();
																																model.Description= dt.Rows[n]["Description"].ToString();
																																model.Remark= dt.Rows[n]["Remark"].ToString();
																												if(dt.Rows[n]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
				}
																																																if(dt.Rows[n]["IsRead"].ToString()!="")
				{
					if((dt.Rows[n]["IsRead"].ToString()=="1")||(dt.Rows[n]["IsRead"].ToString().ToLower()=="true"))
					{
					model.IsRead= true;
					}
					else
					{
					model.IsRead= false;
					}
				}
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