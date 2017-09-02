using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Shi
    /// </summary>
    public partial class Shi
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.Shi model)
        {
            return DAL.Shi.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Shi model)
        {
            return DAL.Shi.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Shi model)
        {
            return DAL.Shi.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int sk_id)
        {
            return DAL.Shi.Delete(sk_id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string sk_idlist)
        {
            return DAL.Shi.DeleteList(sk_idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Shi GetModel(int sk_id)
        {

            return DAL.Shi.GetModel(sk_id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Shi GetModel(NH.Model.Shi model)
        {
            return DAL.Shi.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.Shi GetModelByCache(int sk_id)
        {

            string CacheKey = "ShiModel-" + sk_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.Shi.GetModel(sk_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.Shi)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.Shi.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.Shi.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Shi> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Shi.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Shi> DataTableToList(DataTable dt)
        {
            List<NH.Model.Shi> modelList = new List<NH.Model.Shi>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.Shi model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.Shi();
                    if (dt.Rows[n]["sk_id"].ToString() != "")
                    {
                        model.sk_id = int.Parse(dt.Rows[n]["sk_id"].ToString());
                    }
                    if (dt.Rows[n]["fk_id"].ToString() != "")
                    {
                        model.fk_id = int.Parse(dt.Rows[n]["fk_id"].ToString());
                    }
                    model.second_kind_id = dt.Rows[n]["second_kind_id"].ToString();
                    model.second_kind_name = dt.Rows[n]["second_kind_name"].ToString();
                    model.second_kind_salary_id = dt.Rows[n]["second_kind_salary_id"].ToString();
                    model.second_kind_sale_id = dt.Rows[n]["second_kind_sale_id"].ToString();


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