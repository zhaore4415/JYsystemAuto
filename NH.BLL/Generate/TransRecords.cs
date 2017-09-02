using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// TransRecords
    /// </summary>
    public partial class TransRecords
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.TransRecords model)
        {
            return DAL.TransRecords.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.TransRecords model)
        {
            return DAL.TransRecords.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.TransRecords model)
        {
            return DAL.TransRecords.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.TransRecords.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.TransRecords.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.TransRecords GetModel(int Id)
        {

            return DAL.TransRecords.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.TransRecords GetModel(NH.Model.TransRecords model)
        {
            return DAL.TransRecords.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.TransRecords GetModelByCache(int Id)
        {

            string CacheKey = "TransRecordsModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.TransRecords.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.TransRecords)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.TransRecords.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.TransRecords.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.TransRecords> GetModelList(string strWhere)
        {
            DataSet ds = DAL.TransRecords.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.TransRecords> DataTableToList(DataTable dt)
        {
            List<NH.Model.TransRecords> modelList = new List<NH.Model.TransRecords>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.TransRecords model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.TransRecords();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["CompanyId"].ToString() != "")
                    {
                        model.CompanyId = int.Parse(dt.Rows[n]["CompanyId"].ToString());
                    }
                    if (dt.Rows[n]["TransType"].ToString() != "")
                    {
                        model.TransType = int.Parse(dt.Rows[n]["TransType"].ToString());
                    }
                    if (dt.Rows[n]["ChangeAmount"].ToString() != "")
                    {
                        model.ChangeAmount = decimal.Parse(dt.Rows[n]["ChangeAmount"].ToString());
                    }
                    if (dt.Rows[n]["Balance"].ToString() != "")
                    {
                        model.Balance = decimal.Parse(dt.Rows[n]["Balance"].ToString());
                    }
                    model.Remark = dt.Rows[n]["Remark"].ToString();
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    if (dt.Rows[n]["AddUserType"].ToString() != "")
                    {
                        model.AddUserType = int.Parse(dt.Rows[n]["AddUserType"].ToString());
                    }
                    if (dt.Rows[n]["AddUserId"].ToString() != "")
                    {
                        model.AddUserId = int.Parse(dt.Rows[n]["AddUserId"].ToString());
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