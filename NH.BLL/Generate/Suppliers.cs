using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Suppliers
    /// </summary>
    public partial class Suppliers
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.Suppliers model)
        {
            return DAL.Suppliers.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Suppliers model)
        {
            return DAL.Suppliers.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Suppliers model)
        {
            return DAL.Suppliers.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.Suppliers.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.Suppliers.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Suppliers GetModel(int Id)
        {

            return DAL.Suppliers.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Suppliers GetModel(NH.Model.Suppliers model)
        {
            return DAL.Suppliers.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.Suppliers GetModelByCache(int Id)
        {

            string CacheKey = "SuppliersModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.Suppliers.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.Suppliers)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.Suppliers.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.Suppliers.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Suppliers> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Suppliers.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Suppliers> DataTableToList(DataTable dt)
        {
            List<NH.Model.Suppliers> modelList = new List<NH.Model.Suppliers>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.Suppliers model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.Suppliers();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Address = dt.Rows[n]["Address"].ToString();
                    model.Description = dt.Rows[n]["Description"].ToString();
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    if (dt.Rows[n]["DeliveryTime"].ToString() != "")
                    {
                        model.DeliveryTime = DateTime.Parse(dt.Rows[n]["DeliveryTime"].ToString());
                    }
                    if (dt.Rows[n]["ArrivalTime"].ToString() != "")
                    {
                        model.ArrivalTime = DateTime.Parse(dt.Rows[n]["ArrivalTime"].ToString());
                    }
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    model.Remark = dt.Rows[n]["Remark"].ToString();
                    if (dt.Rows[n]["Pid"].ToString() != "")
                    {
                        model.Pid = int.Parse(dt.Rows[n]["Pid"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.OrderNumber = dt.Rows[n]["OrderNumber"].ToString();
                    model.ExpressOrder = dt.Rows[n]["ExpressOrder"].ToString();
                    model.Couriercompanies = dt.Rows[n]["Couriercompanies"].ToString();
                    model.Realname = dt.Rows[n]["Realname"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    model.Tel = dt.Rows[n]["Tel"].ToString();
                    model.Phone = dt.Rows[n]["Phone"].ToString();
                    model.CompanyName = dt.Rows[n]["CompanyName"].ToString();


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