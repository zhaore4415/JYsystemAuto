using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// EmailConfig
    /// </summary>
    public partial class EmailConfig
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.EmailConfig model)
        {
            return DAL.EmailConfig.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.EmailConfig model)
        {
            return DAL.EmailConfig.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.EmailConfig model)
        {
            return DAL.EmailConfig.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.EmailConfig.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.EmailConfig.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.EmailConfig GetModel(int Id)
        {

            return DAL.EmailConfig.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.EmailConfig GetModel(NH.Model.EmailConfig model)
        {
            return DAL.EmailConfig.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.EmailConfig GetModelByCache(int Id)
        {

            string CacheKey = "EmailConfigModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.EmailConfig.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.EmailConfig)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.EmailConfig.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.EmailConfig.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.EmailConfig> GetModelList(string strWhere)
        {
            DataSet ds = DAL.EmailConfig.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.EmailConfig> DataTableToList(DataTable dt)
        {
            List<NH.Model.EmailConfig> modelList = new List<NH.Model.EmailConfig>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.EmailConfig model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.EmailConfig();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Server = dt.Rows[n]["Server"].ToString();
                    model.Account = dt.Rows[n]["Account"].ToString();
                    model.Password = dt.Rows[n]["Password"].ToString();
                    model.Sender = dt.Rows[n]["Sender"].ToString();
                    if (dt.Rows[n]["Authentication"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Authentication"].ToString() == "1") || (dt.Rows[n]["Authentication"].ToString().ToLower() == "true"))
                        {
                            model.Authentication = true;
                        }
                        else
                        {
                            model.Authentication = false;
                        }
                    }
                    if (dt.Rows[n]["EnableSsl"].ToString() != "")
                    {
                        if ((dt.Rows[n]["EnableSsl"].ToString() == "1") || (dt.Rows[n]["EnableSsl"].ToString().ToLower() == "true"))
                        {
                            model.EnableSsl = true;
                        }
                        else
                        {
                            model.EnableSsl = false;
                        }
                    }
                    model.Port = dt.Rows[n]["Port"].ToString();
                    if (dt.Rows[n]["IsShow"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsShow"].ToString() == "1") || (dt.Rows[n]["IsShow"].ToString().ToLower() == "true"))
                        {
                            model.IsShow = true;
                        }
                        else
                        {
                            model.IsShow = false;
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