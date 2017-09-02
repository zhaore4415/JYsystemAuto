using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// IdentityVerify
	/// </summary>
	public partial class IdentityVerify
	{
		#region 是否存在该记录
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(NH.Model.IdentityVerify model)
		{
			return DAL.IdentityVerify.Exists(model);
		}
		#endregion
		
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int  Add(NH.Model.IdentityVerify model)
		{
						return DAL.IdentityVerify.Add(model);
						
		}
		#endregion
		
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.IdentityVerify model)
		{
			return DAL.IdentityVerify.Update(model);
		}
		#endregion
		
		#region 删除一条数据
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int Id)
		{
			return DAL.IdentityVerify.Delete(Id);
		}
		#endregion
		
				#region 批量删除一批数据
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public static bool DeleteList(string Idlist )
		{
			return DAL.IdentityVerify.DeleteList(Idlist );
		}
		#endregion
				
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.IdentityVerify GetModel(int Id)
		{
			
			return DAL.IdentityVerify.GetModel(Id);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.IdentityVerify GetModel(NH.Model.IdentityVerify model)
		{
			return DAL.IdentityVerify.GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体，从缓存中
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public static NH.Model.IdentityVerify GetModelByCache(int Id)
		{
			
			string CacheKey = "IdentityVerifyModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = DAL.IdentityVerify.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NH.Model.IdentityVerify)objModel;
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			return DAL.IdentityVerify.GetList(strWhere);
		}
		#endregion
		
		#region 获得前几行数据
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return DAL.IdentityVerify.GetList(Top,strWhere,filedOrder);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.IdentityVerify> GetModelList(string strWhere)
		{
			DataSet ds = DAL.IdentityVerify.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.IdentityVerify> DataTableToList(DataTable dt)
		{
			List<NH.Model.IdentityVerify> modelList = new List<NH.Model.IdentityVerify>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NH.Model.IdentityVerify model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NH.Model.IdentityVerify();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["MemberID"].ToString()!="")
				{
					model.MemberID=int.Parse(dt.Rows[n]["MemberID"].ToString());
				}
																																				model.IdentityImg= dt.Rows[n]["IdentityImg"].ToString();
																																model.IdentityNo= dt.Rows[n]["IdentityNo"].ToString();
																												if(dt.Rows[n]["ExpireDate"].ToString()!="")
				{
					model.ExpireDate=DateTime.Parse(dt.Rows[n]["ExpireDate"].ToString());
				}
																																																if(dt.Rows[n]["Sex"].ToString()!="")
				{
					if((dt.Rows[n]["Sex"].ToString()=="1")||(dt.Rows[n]["Sex"].ToString().ToLower()=="true"))
					{
					model.Sex= true;
					}
					else
					{
					model.Sex= false;
					}
				}
																				model.Tel= dt.Rows[n]["Tel"].ToString();
																																model.QQ= dt.Rows[n]["QQ"].ToString();
																												if(dt.Rows[n]["Status"].ToString()!="")
				{
					model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
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