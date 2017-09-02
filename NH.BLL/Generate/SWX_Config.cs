using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    //SWX_Config
    public partial class SWX_Config
    {

  
        public SWX_Config()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(int Id)
        {
            return DAL.SWX_Config.Exists(Id);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Existss(string access_token)
        {
            return DAL.SWX_Config.Existss(access_token);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.SWX_Config model)
        {
            return DAL.SWX_Config.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.SWX_Config model)
        {
            return DAL.SWX_Config.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {

            return DAL.SWX_Config.Delete(Id);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.SWX_Config.DeleteList(Idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.SWX_Config GetModel(int Id)
        {

            return DAL.SWX_Config.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.SWX_Config GetModelByCache(int Id)
        {

            string CacheKey = "SWX_ConfigModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.SWX_Config.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.SWX_Config)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.SWX_Config.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.SWX_Config.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.SWX_Config> GetModelList(string strWhere)
        {
            DataSet ds = DAL.SWX_Config.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.SWX_Config> DataTableToList(DataTable dt)
        {
            List<NH.Model.SWX_Config> modelList = new List<NH.Model.SWX_Config>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.SWX_Config model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.SWX_Config();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.access_token = dt.Rows[n]["access_token"].ToString();
                    model.CorpId = dt.Rows[n]["CorpId"].ToString();
                    model.Secret = dt.Rows[n]["Secret"].ToString();


                    modelList.Add(model);
                }
            }
            return modelList;
        }

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