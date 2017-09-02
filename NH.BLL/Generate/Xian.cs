using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Xian
    /// </summary>
    public partial class Xian
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.Xian model)
        {
            return DAL.Xian.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Xian model)
        {
            return DAL.Xian.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Xian model)
        {
            return DAL.Xian.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int tk_id)
        {
            return DAL.Xian.Delete(tk_id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string tk_idlist)
        {
            return DAL.Xian.DeleteList(tk_idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Xian GetModel(int tk_id)
        {

            return DAL.Xian.GetModel(tk_id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Xian GetModel(NH.Model.Xian model)
        {
            return DAL.Xian.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.Xian GetModelByCache(int tk_id)
        {

            string CacheKey = "XianModel-" + tk_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.Xian.GetModel(tk_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.Xian)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.Xian.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.Xian.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Xian> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Xian.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Xian> DataTableToList(DataTable dt)
        {
            List<NH.Model.Xian> modelList = new List<NH.Model.Xian>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.Xian model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.Xian();
                    if (dt.Rows[n]["tk_id"].ToString() != "")
                    {
                        model.tk_id = int.Parse(dt.Rows[n]["tk_id"].ToString());
                    }
                    if (dt.Rows[n]["sk_id"].ToString() != "")
                    {
                        model.sk_id = int.Parse(dt.Rows[n]["sk_id"].ToString());
                    }
                    model.third_kind_id = dt.Rows[n]["third_kind_id"].ToString();
                    model.third_kind_name = dt.Rows[n]["third_kind_name"].ToString();
                    model.third_kind_salary_id = dt.Rows[n]["third_kind_salary_id"].ToString();
                    model.third_kind_is_retail = dt.Rows[n]["third_kind_is_retail"].ToString();


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