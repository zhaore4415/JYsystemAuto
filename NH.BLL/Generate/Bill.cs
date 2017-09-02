using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Bill
    /// </summary>
    public partial class Bill
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.Bill model)
        {
            return DAL.Bill.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Bill model)
        {
            return DAL.Bill.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Bill model)
        {
            return DAL.Bill.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.Bill.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.Bill.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Bill GetModel(int Id)
        {

            return DAL.Bill.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Bill GetModel(NH.Model.Bill model)
        {
            return DAL.Bill.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.Bill GetModelByCache(int Id)
        {

            string CacheKey = "QueryorderfxModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.Bill.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.Bill)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.Bill.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.Bill.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Bill> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Bill.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Bill> DataTableToList(DataTable dt)
        {
            List<NH.Model.Bill> modelList = new List<NH.Model.Bill>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.Bill model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.Bill();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Email = dt.Rows[n]["Email"].ToString();
                    model.Tel = dt.Rows[n]["Tel"].ToString();
                    model.Phone = dt.Rows[n]["Phone"].ToString();
                    model.CompanyName = dt.Rows[n]["CompanyName"].ToString();
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
                    model.Status = dt.Rows[n]["Status"].ToString();
                    model.Buyers = dt.Rows[n]["Buyers"].ToString();
                    model.Remark = dt.Rows[n]["Remark"].ToString();
                    if (dt.Rows[n]["Babynumber"].ToString() != "")
                    {
                        model.Babynumber = int.Parse(dt.Rows[n]["Babynumber"].ToString());
                    }
                    model.Pid = dt.Rows[n]["Pid"].ToString();
                    if (dt.Rows[n]["Type"].ToString() != "")
                    {
                        model.Type = int.Parse(dt.Rows[n]["Type"].ToString());
                    }
                    model.Barcode = dt.Rows[n]["Barcode"].ToString();
                    if (dt.Rows[n]["QdId"].ToString() != "")
                    {
                        model.QdId = long.Parse(dt.Rows[n]["QdId"].ToString());
                    }
                    if (dt.Rows[n]["U_ID"].ToString() != "")
                    {
                        model.U_ID = int.Parse(dt.Rows[n]["U_ID"].ToString());
                    }
                    if (dt.Rows[n]["province"].ToString() != "")
                    {
                        model.province = int.Parse(dt.Rows[n]["province"].ToString());
                    }
                    if (dt.Rows[n]["city"].ToString() != "")
                    {
                        model.city = int.Parse(dt.Rows[n]["city"].ToString());
                    }
                    if (dt.Rows[n]["area"].ToString() != "")
                    {
                        model.area = int.Parse(dt.Rows[n]["area"].ToString());
                    }
                    model.Buyerpayspoints = dt.Rows[n]["Buyerpayspoints"].ToString();
                    if (dt.Rows[n]["PaymentMethod"].ToString() != "")
                    {
                        model.PaymentMethod = int.Parse(dt.Rows[n]["PaymentMethod"].ToString());
                    }
                    if (dt.Rows[n]["Amount"].ToString() != "")
                    {
                        model.Amount = decimal.Parse(dt.Rows[n]["Amount"].ToString());
                    }
                    if (dt.Rows[n]["OrderNumber"].ToString() != "")
                    {
                        model.OrderNumber = long.Parse(dt.Rows[n]["OrderNumber"].ToString());
                    }
                    model.ExpressOrder = dt.Rows[n]["ExpressOrder"].ToString();
                    model.Couriercompanies = dt.Rows[n]["Couriercompanies"].ToString();
                    model.Realname = dt.Rows[n]["Realname"].ToString();


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