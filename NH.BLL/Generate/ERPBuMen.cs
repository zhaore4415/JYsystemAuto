using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// ERPBuMen
    /// </summary>
    public partial class ERPBuMen
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.ERPBuMen model)
        {
            return DAL.ERPBuMen.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.ERPBuMen model)
        {
            return DAL.ERPBuMen.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.ERPBuMen model)
        {
            return DAL.ERPBuMen.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
        {
            return DAL.ERPBuMen.Delete(ID);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string IDlist)
        {
            return DAL.ERPBuMen.DeleteList(IDlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ERPBuMen GetModel(int ID)
        {

            return DAL.ERPBuMen.GetModel(ID);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ERPBuMen GetModel(NH.Model.ERPBuMen model)
        {
            return DAL.ERPBuMen.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.ERPBuMen GetModelByCache(int ID)
        {

            string CacheKey = "ERPBuMenModel-" + ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.ERPBuMen.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.ERPBuMen)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.ERPBuMen.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.ERPBuMen.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.ERPBuMen> GetModelList(string strWhere)
        {
            DataSet ds = DAL.ERPBuMen.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.ERPBuMen> DataTableToList(DataTable dt)
        {
            List<NH.Model.ERPBuMen> modelList = new List<NH.Model.ERPBuMen>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.ERPBuMen model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.ERPBuMen();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.BuMenName = dt.Rows[n]["BuMenName"].ToString();
                    model.ChargeMan = dt.Rows[n]["ChargeMan"].ToString();
                    model.TelStr = dt.Rows[n]["TelStr"].ToString();
                    model.ChuanZhen = dt.Rows[n]["ChuanZhen"].ToString();
                    model.BackInfo = dt.Rows[n]["BackInfo"].ToString();
                    if (dt.Rows[n]["DirID"].ToString() != "")
                    {
                        model.DirID = int.Parse(dt.Rows[n]["DirID"].ToString());
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