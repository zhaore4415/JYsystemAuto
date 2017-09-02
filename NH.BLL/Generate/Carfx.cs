using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Carfx
    /// </summary>
    public partial class Carfx
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.Carfx model)
        {
            return DAL.Carfx.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Carfx model)
        {
            return DAL.Carfx.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Carfx model)
        {
            return DAL.Carfx.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.Carfx.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.Carfx.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Carfx GetModel(int Id)
        {

            return DAL.Carfx.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Carfx GetModel(NH.Model.Carfx model)
        {
            return DAL.Carfx.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.Carfx GetModelByCache(int Id)
        {

            string CacheKey = "CarfxModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.Carfx.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.Carfx)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.Carfx.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.Carfx.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Carfx> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Carfx.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Carfx> DataTableToList(DataTable dt)
        {
            List<NH.Model.Carfx> modelList = new List<NH.Model.Carfx>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.Carfx model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.Carfx();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Status = dt.Rows[n]["Status"].ToString();
                    model.PName = dt.Rows[n]["PName"].ToString();
                    if (dt.Rows[n]["Num"].ToString() != "")
                    {
                        model.Num = int.Parse(dt.Rows[n]["Num"].ToString());
                    }
                    if (dt.Rows[n]["JiFenPrice"].ToString() != "")
                    {
                        model.JiFenPrice = int.Parse(dt.Rows[n]["JiFenPrice"].ToString());
                    }
                    if (dt.Rows[n]["CategoryID"].ToString() != "")
                    {
                        model.CategoryID = int.Parse(dt.Rows[n]["CategoryID"].ToString());
                    }
                    model.CategoryPath = dt.Rows[n]["CategoryPath"].ToString();
                    if (dt.Rows[n]["UId"].ToString() != "")
                    {
                        model.UId = int.Parse(dt.Rows[n]["UId"].ToString());
                    }
                    if (dt.Rows[n]["PId"].ToString() != "")
                    {
                        model.PId = int.Parse(dt.Rows[n]["PId"].ToString());
                    }
                    model.OrderNumber = dt.Rows[n]["OrderNumber"].ToString();


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