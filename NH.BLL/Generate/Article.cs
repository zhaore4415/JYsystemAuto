using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// Article
	/// </summary>
	public partial class Article
	{
		#region 是否存在该记录
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(NH.Model.Article model)
		{
			return DAL.Article.Exists(model);
		}
		#endregion
		
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int  Add(NH.Model.Article model)
		{
						return DAL.Article.Add(model);
						
		}
		#endregion
		
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.Article model)
		{
			return DAL.Article.Update(model);
		}
		#endregion
		
		#region 删除一条数据
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int Id)
		{
			return DAL.Article.Delete(Id);
		}
		#endregion
		
				#region 批量删除一批数据
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public static bool DeleteList(string Idlist )
		{
			return DAL.Article.DeleteList(Idlist );
		}
		#endregion
				
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.Article GetModel(int Id)
		{
			
			return DAL.Article.GetModel(Id);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.Article GetModel(NH.Model.Article model)
		{
			return DAL.Article.GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体，从缓存中
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public static NH.Model.Article GetModelByCache(int Id)
		{
			
			string CacheKey = "ArticleModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = DAL.Article.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NH.Model.Article)objModel;
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			return DAL.Article.GetList(strWhere);
		}
		#endregion
		
		#region 获得前几行数据
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return DAL.Article.GetList(Top,strWhere,filedOrder);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.Article> GetModelList(string strWhere)
		{
			DataSet ds = DAL.Article.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.Article> DataTableToList(DataTable dt)
		{
			List<NH.Model.Article> modelList = new List<NH.Model.Article>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NH.Model.Article model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NH.Model.Article();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["CategoryID"].ToString()!="")
				{
					model.CategoryID=int.Parse(dt.Rows[n]["CategoryID"].ToString());
				}
																																				model.Title= dt.Rows[n]["Title"].ToString();
																																model.Description= dt.Rows[n]["Description"].ToString();
																																model.Url= dt.Rows[n]["Url"].ToString();
																												if(dt.Rows[n]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
				}
																																if(dt.Rows[n]["Status"].ToString()!="")
				{
					model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
				}
																																if(dt.Rows[n]["Hits"].ToString()!="")
				{
					model.Hits=int.Parse(dt.Rows[n]["Hits"].ToString());
				}
																																																if(dt.Rows[n]["IsTop"].ToString()!="")
				{
					if((dt.Rows[n]["IsTop"].ToString()=="1")||(dt.Rows[n]["IsTop"].ToString().ToLower()=="true"))
					{
					model.IsTop= true;
					}
					else
					{
					model.IsTop= false;
					}
				}
																																if(dt.Rows[n]["IsHilight"].ToString()!="")
				{
					if((dt.Rows[n]["IsHilight"].ToString()=="1")||(dt.Rows[n]["IsHilight"].ToString().ToLower()=="true"))
					{
					model.IsHilight= true;
					}
					else
					{
					model.IsHilight= false;
					}
				}
																if(dt.Rows[n]["AddUserId"].ToString()!="")
				{
					model.AddUserId=int.Parse(dt.Rows[n]["AddUserId"].ToString());
				}
																																if(dt.Rows[n]["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
				}
																																				model.Files= dt.Rows[n]["Files"].ToString();
																						
				
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