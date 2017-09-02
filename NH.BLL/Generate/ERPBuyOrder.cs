using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// ERPBuyOrder
    /// </summary>
    public partial class ERPBuyOrder
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.ERPBuyOrder model)
        {
            return DAL.ERPBuyOrder.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.ERPBuyOrder model)
        {
            return DAL.ERPBuyOrder.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.ERPBuyOrder model)
        {
            return DAL.ERPBuyOrder.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
        {
            return DAL.ERPBuyOrder.Delete(ID);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string IDlist)
        {
            return DAL.ERPBuyOrder.DeleteList(IDlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ERPBuyOrder GetModel(int ID)
        {

            return DAL.ERPBuyOrder.GetModel(ID);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ERPBuyOrder GetModel(NH.Model.ERPBuyOrder model)
        {
            return DAL.ERPBuyOrder.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.ERPBuyOrder GetModelByCache(int ID)
        {

            string CacheKey = "ERPBuyOrderModel-" + ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.ERPBuyOrder.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.ERPBuyOrder)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.ERPBuyOrder.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.ERPBuyOrder.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.ERPBuyOrder> GetModelList(string strWhere)
        {
            DataSet ds = DAL.ERPBuyOrder.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.ERPBuyOrder> DataTableToList(DataTable dt)
        {
            List<NH.Model.ERPBuyOrder> modelList = new List<NH.Model.ERPBuyOrder>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.ERPBuyOrder model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.ERPBuyOrder();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.ChuangJianRen = dt.Rows[n]["ChuangJianRen"].ToString();
                    model.FuZeRen = dt.Rows[n]["FuZeRen"].ToString();
                    model.FuJianList = dt.Rows[n]["FuJianList"].ToString();
                    model.NowState = dt.Rows[n]["NowState"].ToString();
                    model.ShenPiTongGuoRen = dt.Rows[n]["ShenPiTongGuoRen"].ToString();
                    model.BackInfo = dt.Rows[n]["BackInfo"].ToString();
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    if (dt.Rows[n]["TimeStr"].ToString() != "")
                    {
                        model.TimeStr = DateTime.Parse(dt.Rows[n]["TimeStr"].ToString());
                    }
                    if (dt.Rows[n]["U_ID"].ToString() != "")
                    {
                        model.U_ID = int.Parse(dt.Rows[n]["U_ID"].ToString());
                    }
                    model.OrderName = dt.Rows[n]["OrderName"].ToString();
                    model.GongYingShangName = dt.Rows[n]["GongYingShangName"].ToString();
                    model.Serils = dt.Rows[n]["Serils"].ToString();
                    model.DingDanLeiXing = dt.Rows[n]["DingDanLeiXing"].ToString();
                    model.DingDanMiaoShu = dt.Rows[n]["DingDanMiaoShu"].ToString();
                    if (dt.Rows[n]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    }
                    if (dt.Rows[n]["LaiHuoDate"].ToString() != "")
                    {
                        model.LaiHuoDate = DateTime.Parse(dt.Rows[n]["LaiHuoDate"].ToString());
                    }
                    if (dt.Rows[n]["TiXingDate"].ToString() != "")
                    {
                        model.TiXingDate = DateTime.Parse(dt.Rows[n]["TiXingDate"].ToString());
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