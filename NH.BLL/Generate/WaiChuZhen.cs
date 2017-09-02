using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// WaiChuZhen
    /// </summary>
    public partial class WaiChuZhen
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.WaiChuZhen model)
        {
            return DAL.WaiChuZhen.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.WaiChuZhen model)
        {
            return DAL.WaiChuZhen.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.WaiChuZhen model)
        {
            return DAL.WaiChuZhen.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.WaiChuZhen.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.WaiChuZhen.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.WaiChuZhen GetModel(int Id)
        {

            return DAL.WaiChuZhen.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.WaiChuZhen GetModel(NH.Model.WaiChuZhen model)
        {
            return DAL.WaiChuZhen.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.WaiChuZhen GetModelByCache(int Id)
        {

            string CacheKey = "WaiChuZhenModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.WaiChuZhen.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.WaiChuZhen)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.WaiChuZhen.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.WaiChuZhen.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.WaiChuZhen> GetModelList(string strWhere)
        {
            DataSet ds = DAL.WaiChuZhen.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.WaiChuZhen> DataTableToList(DataTable dt)
        {
            List<NH.Model.WaiChuZhen> modelList = new List<NH.Model.WaiChuZhen>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.WaiChuZhen model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.WaiChuZhen();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["OutYQMoney"].ToString() != "")
                    {
                        model.OutYQMoney = decimal.Parse(dt.Rows[n]["OutYQMoney"].ToString());
                    }
                    model.Remark = dt.Rows[n]["Remark"].ToString();
                    model.Haoma = dt.Rows[n]["Haoma"].ToString();
                    model.YQhaoma = dt.Rows[n]["YQhaoma"].ToString();
                    if (dt.Rows[n]["OutMoney"].ToString() != "")
                    {
                        model.OutMoney = decimal.Parse(dt.Rows[n]["OutMoney"].ToString());
                    }
                    model.OutDate = dt.Rows[n]["OutDate"].ToString();
                    model.MaturityDate = dt.Rows[n]["MaturityDate"].ToString();
                    if (dt.Rows[n]["Fid"].ToString() != "")
                    {
                        model.Fid = int.Parse(dt.Rows[n]["Fid"].ToString());
                    }
                    model.OutYQDate = dt.Rows[n]["OutYQDate"].ToString();
                    model.MaturityTYDate = dt.Rows[n]["MaturityTYDate"].ToString();


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