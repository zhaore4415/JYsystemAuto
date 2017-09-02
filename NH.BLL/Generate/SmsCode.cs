using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// SmsCode
	/// </summary>
	public partial class SmsCode
	{
		#region 是否存在该记录
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(NH.Model.SmsCode model)
		{
			return DAL.SmsCode.Exists(model);
		}
		#endregion
		
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int  Add(NH.Model.SmsCode model)
		{
						return DAL.SmsCode.Add(model);
						
		}
		#endregion
		
		#region 更新一条数据
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static bool Update(NH.Model.SmsCode model)
		{
			return DAL.SmsCode.Update(model);
		}
		#endregion
		
		#region 删除一条数据
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static bool Delete(int Id)
		{
			return DAL.SmsCode.Delete(Id);
		}
		#endregion
		
				#region 批量删除一批数据
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public static bool DeleteList(string Idlist )
		{
			return DAL.SmsCode.DeleteList(Idlist );
		}
		#endregion
				
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.SmsCode GetModel(int Id)
		{
			
			return DAL.SmsCode.GetModel(Id);
		}
		#endregion
		
		#region 得到一个对象实体
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static NH.Model.SmsCode GetModel(NH.Model.SmsCode model)
		{
			return DAL.SmsCode.GetModel(model);
		}
		#endregion
		
		#region 得到一个对象实体，从缓存中
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public static NH.Model.SmsCode GetModelByCache(int Id)
		{
			
			string CacheKey = "SmsCodeModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = DAL.SmsCode.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (NH.Model.SmsCode)objModel;
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			return DAL.SmsCode.GetList(strWhere);
		}
		#endregion
		
		#region 获得前几行数据
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return DAL.SmsCode.GetList(Top,strWhere,filedOrder);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.SmsCode> GetModelList(string strWhere)
		{
			DataSet ds = DAL.SmsCode.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		#endregion
		
		#region 获得数据列表
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<NH.Model.SmsCode> DataTableToList(DataTable dt)
		{
			List<NH.Model.SmsCode> modelList = new List<NH.Model.SmsCode>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				NH.Model.SmsCode model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new NH.Model.SmsCode();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																if(dt.Rows[n]["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(dt.Rows[n]["UserId"].ToString());
				}
																																if(dt.Rows[n]["UserType"].ToString()!="")
				{
					model.UserType=int.Parse(dt.Rows[n]["UserType"].ToString());
				}
																																				model.Code= dt.Rows[n]["Code"].ToString();
																												if(dt.Rows[n]["CodeType"].ToString()!="")
				{
					model.CodeType=int.Parse(dt.Rows[n]["CodeType"].ToString());
				}
																																if(dt.Rows[n]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
				}
																																if(dt.Rows[n]["Status"].ToString()!="")
				{
					model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
				}
																																				model.IP= dt.Rows[n]["IP"].ToString();
																																model.Mobile= dt.Rows[n]["Mobile"].ToString();
																						
				
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