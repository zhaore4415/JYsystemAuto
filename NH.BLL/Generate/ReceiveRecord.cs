using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// ReceiveRecord
    /// </summary>
    public partial class ReceiveRecord
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.ReceiveRecord model)
        {
            return DAL.ReceiveRecord.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.ReceiveRecord model)
        {
            return DAL.ReceiveRecord.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.ReceiveRecord model)
        {
            return DAL.ReceiveRecord.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.ReceiveRecord.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.ReceiveRecord.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ReceiveRecord GetModel(int Id)
        {

            return DAL.ReceiveRecord.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ReceiveRecord GetModel(NH.Model.ReceiveRecord model)
        {
            return DAL.ReceiveRecord.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.ReceiveRecord GetModelByCache(int Id)
        {

            string CacheKey = "ReceiveRecordModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.ReceiveRecord.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.ReceiveRecord)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.ReceiveRecord.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.ReceiveRecord.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.ReceiveRecord> GetModelList(string strWhere)
        {
            DataSet ds = DAL.ReceiveRecord.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.ReceiveRecord> DataTableToList(DataTable dt)
        {
            List<NH.Model.ReceiveRecord> modelList = new List<NH.Model.ReceiveRecord>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.ReceiveRecord model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.ReceiveRecord();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["Times"].ToString() != "")
                    {
                        model.Times = int.Parse(dt.Rows[n]["Times"].ToString());
                    }
                    if (dt.Rows[n]["CompanyId"].ToString() != "")
                    {
                        model.CompanyId = int.Parse(dt.Rows[n]["CompanyId"].ToString());
                    }
                    if (dt.Rows[n]["SignUpCount"].ToString() != "")
                    {
                        model.SignUpCount = int.Parse(dt.Rows[n]["SignUpCount"].ToString());
                    }
                    if (dt.Rows[n]["StartTime"].ToString() != "")
                    {
                        model.StartTime = DateTime.Parse(dt.Rows[n]["StartTime"].ToString());
                    }
                    if (dt.Rows[n]["EndDate"].ToString() != "")
                    {
                        model.EndDate = DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
                    }
                    model.Address = dt.Rows[n]["Address"].ToString();
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    if (dt.Rows[n]["AddType"].ToString() != "")
                    {
                        model.AddType = int.Parse(dt.Rows[n]["AddType"].ToString());
                    }
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
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