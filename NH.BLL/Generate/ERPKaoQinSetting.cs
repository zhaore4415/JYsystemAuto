using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// ERPKaoQinSetting
    /// </summary>
    public partial class ERPKaoQinSetting
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.ERPKaoQinSetting model)
        {
            return DAL.ERPKaoQinSetting.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.ERPKaoQinSetting model)
        {
            return DAL.ERPKaoQinSetting.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.ERPKaoQinSetting model)
        {
            return DAL.ERPKaoQinSetting.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
        {
            return DAL.ERPKaoQinSetting.Delete(ID);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string IDlist)
        {
            return DAL.ERPKaoQinSetting.DeleteList(IDlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ERPKaoQinSetting GetModel(int ID)
        {

            return DAL.ERPKaoQinSetting.GetModel(ID);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ERPKaoQinSetting GetModel(NH.Model.ERPKaoQinSetting model)
        {
            return DAL.ERPKaoQinSetting.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.ERPKaoQinSetting GetModelByCache(int ID)
        {

            string CacheKey = "ERPKaoQinSettingModel-" + ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.ERPKaoQinSetting.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.ERPKaoQinSetting)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.ERPKaoQinSetting.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.ERPKaoQinSetting.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.ERPKaoQinSetting> GetModelList(string strWhere)
        {
            DataSet ds = DAL.ERPKaoQinSetting.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.ERPKaoQinSetting> DataTableToList(DataTable dt)
        {
            List<NH.Model.ERPKaoQinSetting> modelList = new List<NH.Model.ERPKaoQinSetting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.ERPKaoQinSetting model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.ERPKaoQinSetting();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.GuiDingTime1 = dt.Rows[n]["GuiDingTime1"].ToString();
                    model.GuiDingTime2 = dt.Rows[n]["GuiDingTime2"].ToString();


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