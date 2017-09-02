using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Orderdetails
    /// </summary>
    public partial class Orderdetails
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.Orderdetails model)
        {
            return DAL.Orderdetails.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Orderdetails model)
        {
            return DAL.Orderdetails.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Orderdetails model)
        {
            return DAL.Orderdetails.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.Orderdetails.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.Orderdetails.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Orderdetails GetModel(int Id)
        {

            return DAL.Orderdetails.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Orderdetails GetModel(NH.Model.Orderdetails model)
        {
            return DAL.Orderdetails.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.Orderdetails GetModelByCache(int Id)
        {

            string CacheKey = "OrderdetailsModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.Orderdetails.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.Orderdetails)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.Orderdetails.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.Orderdetails.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Orderdetails> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Orderdetails.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Orderdetails> DataTableToList(DataTable dt)
        {
            List<NH.Model.Orderdetails> modelList = new List<NH.Model.Orderdetails>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.Orderdetails model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.Orderdetails();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Barcode = dt.Rows[n]["Barcode"].ToString();
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    if (dt.Rows[n]["QdId"].ToString() != "")
                    {
                        model.QdId = long.Parse(dt.Rows[n]["QdId"].ToString());
                    }
                    if (dt.Rows[n]["Q_ID"].ToString() != "")
                    {
                        model.Q_ID = int.Parse(dt.Rows[n]["Q_ID"].ToString());
                    }
                    model.Buyers = dt.Rows[n]["Buyers"].ToString();
                    model.Name = dt.Rows[n]["Name"].ToString();
                    model.Colors = dt.Rows[n]["Colors"].ToString();
                    if (dt.Rows[n]["Babynumber"].ToString() != "")
                    {
                        model.Babynumber = int.Parse(dt.Rows[n]["Babynumber"].ToString());
                    }
                    if (dt.Rows[n]["Prices"].ToString() != "")
                    {
                        model.Prices = decimal.Parse(dt.Rows[n]["Prices"].ToString());
                    }
                    if (dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = decimal.Parse(dt.Rows[n]["Amount"].ToString());
                    }
                    model.Remark = dt.Rows[n]["Remark"].ToString();


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