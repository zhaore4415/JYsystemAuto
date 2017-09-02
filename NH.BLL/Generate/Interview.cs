using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// Interview
	/// </summary>
	public partial class Interview
	{
		#region 是否存在该记录
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(NH.Model.Interview model)
		{
			return DAL.Interview.Exists(model);
		}
		#endregion
		
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int  Add(NH.Model.Interview model)
		{
						return DAL.Interview.Add(model);
						
		}
		#endregion
		
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.Interview model)
		{
			return DAL.Interview.Update(model);
		}
		#endregion
		
		#region 删除一条数据
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int Id)
		{
			return DAL.Interview.Delete(Id);
		}
		#endregion
		
				#region 批量删除一批数据
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public static bool DeleteList(string Idlist )
		{
			return DAL.Interview.DeleteList(Idlist );
		}
		#endregion
				
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.Interview GetModel(int Id)
		{
			
			return DAL.Interview.GetModel(Id);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.Interview GetModel(NH.Model.Interview model)
		{
			return DAL.Interview.GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体，从缓存中
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public static NH.Model.Interview GetModelByCache(int Id)
		{
			
			string CacheKey = "InterviewModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = DAL.Interview.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NH.Model.Interview)objModel;
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			return DAL.Interview.GetList(strWhere);
		}
		#endregion
		
		#region 获得前几行数据
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return DAL.Interview.GetList(Top,strWhere,filedOrder);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.Interview> GetModelList(string strWhere)
		{
			DataSet ds = DAL.Interview.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.Interview> DataTableToList(DataTable dt)
		{
			List<NH.Model.Interview> modelList = new List<NH.Model.Interview>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NH.Model.Interview model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NH.Model.Interview();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["CompanyID"].ToString()!="")
				{
					model.CompanyID=int.Parse(dt.Rows[n]["CompanyID"].ToString());
				}
																																if(dt.Rows[n]["MemberID"].ToString()!="")
				{
					model.MemberID=int.Parse(dt.Rows[n]["MemberID"].ToString());
				}
																																				model.Title= dt.Rows[n]["Title"].ToString();
																																model.Description= dt.Rows[n]["Description"].ToString();
																												if(dt.Rows[n]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
				}
																																																if(dt.Rows[n]["ReadStatus"].ToString()!="")
				{
					if((dt.Rows[n]["ReadStatus"].ToString()=="1")||(dt.Rows[n]["ReadStatus"].ToString().ToLower()=="true"))
					{
					model.ReadStatus= true;
					}
					else
					{
					model.ReadStatus= false;
					}
				}
																if(dt.Rows[n]["ReadTime"].ToString()!="")
				{
					model.ReadTime=DateTime.Parse(dt.Rows[n]["ReadTime"].ToString());
				}
																																																if(dt.Rows[n]["IsAccept"].ToString()!="")
				{
					if((dt.Rows[n]["IsAccept"].ToString()=="1")||(dt.Rows[n]["IsAccept"].ToString().ToLower()=="true"))
					{
					model.IsAccept= true;
					}
					else
					{
					model.IsAccept= false;
					}
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