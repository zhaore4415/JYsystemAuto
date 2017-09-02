using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Shen
    /// </summary>
    public partial class Shen
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.Shen model)
        {
            return DAL.Shen.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Shen model)
        {
            return DAL.Shen.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Shen model)
        {
            return DAL.Shen.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int fk_id)
        {
            return DAL.Shen.Delete(fk_id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string fk_idlist)
        {
            return DAL.Shen.DeleteList(fk_idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Shen GetModel(int fk_id)
        {

            return DAL.Shen.GetModel(fk_id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Shen GetModel(NH.Model.Shen model)
        {
            return DAL.Shen.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.Shen GetModelByCache(int fk_id)
        {

            string CacheKey = "ShenModel-" + fk_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.Shen.GetModel(fk_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.Shen)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.Shen.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.Shen.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Shen> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Shen.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Shen> DataTableToList(DataTable dt)
        {
            List<NH.Model.Shen> modelList = new List<NH.Model.Shen>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.Shen model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.Shen();
                    if (dt.Rows[n]["fk_id"].ToString() != "")
                    {
                        model.fk_id = int.Parse(dt.Rows[n]["fk_id"].ToString());
                    }
                    model.first_kind_id = dt.Rows[n]["first_kind_id"].ToString();
                    model.first_kind_name = dt.Rows[n]["first_kind_name"].ToString();
                    model.first_kind_salary_id = dt.Rows[n]["first_kind_salary_id"].ToString();
                    model.first_kind_sale_id = dt.Rows[n]["first_kind_sale_id"].ToString();


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