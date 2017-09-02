using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Config
    /// </summary>
    public partial class Config
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.Config model)
        {
            return DAL.Config.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static void Add(NH.Model.Config model)
        {

            DAL.Config.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Config model)
        {
            return DAL.Config.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.Config.Delete(Id);
        }
        #endregion


        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Config GetModel(int Id)
        {

            return DAL.Config.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Config GetModel(NH.Model.Config model)
        {
            return DAL.Config.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.Config GetModelByCache(int Id)
        {

            string CacheKey = "ConfigModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.Config.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.Config)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.Config.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.Config.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Config> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Config.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Config> DataTableToList(DataTable dt)
        {
            List<NH.Model.Config> modelList = new List<NH.Model.Config>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.Config model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.Config();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.FriendLinkContact = dt.Rows[n]["FriendLinkContact"].ToString();
                    model.ContactDesc = dt.Rows[n]["ContactDesc"].ToString();
                    model.Foot = dt.Rows[n]["Foot"].ToString();
                    model.RegProtocol = dt.Rows[n]["RegProtocol"].ToString();
                    model.WaterMarkPic = dt.Rows[n]["WaterMarkPic"].ToString();
                    model.Sms_ID = dt.Rows[n]["Sms_ID"].ToString();
                    model.Sms_Account = dt.Rows[n]["Sms_Account"].ToString();
                    model.Sms_Password = dt.Rows[n]["Sms_Password"].ToString();
                    model.Sms_SendMobile = dt.Rows[n]["Sms_SendMobile"].ToString();
                    model.SiteName = dt.Rows[n]["SiteName"].ToString();
                    model.SiteTitle = dt.Rows[n]["SiteTitle"].ToString();
                    model.SiteKeyword = dt.Rows[n]["SiteKeyword"].ToString();
                    model.SiteDescription = dt.Rows[n]["SiteDescription"].ToString();
                    model.Logo = dt.Rows[n]["Logo"].ToString();
                    if (dt.Rows[n]["IsMobileValidate"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsMobileValidate"].ToString() == "1") || (dt.Rows[n]["IsMobileValidate"].ToString().ToLower() == "true"))
                        {
                            model.IsMobileValidate = true;
                        }
                        else
                        {
                            model.IsMobileValidate = false;
                        }
                    }
                    model.ServiceTel1 = dt.Rows[n]["ServiceTel1"].ToString();
                    model.ServiceTel2 = dt.Rows[n]["ServiceTel2"].ToString();


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