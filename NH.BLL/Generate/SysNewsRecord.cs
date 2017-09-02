using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// SysNewsRecord
    /// </summary>
    public partial class SysNewsRecord
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.SysNewsRecord model)
        {
            return DAL.SysNewsRecord.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.SysNewsRecord model)
        {
            return DAL.SysNewsRecord.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.SysNewsRecord model)
        {
            return DAL.SysNewsRecord.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.SysNewsRecord.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.SysNewsRecord.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.SysNewsRecord GetModel(int Id)
        {

            return DAL.SysNewsRecord.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.SysNewsRecord GetModel(NH.Model.SysNewsRecord model)
        {
            return DAL.SysNewsRecord.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.SysNewsRecord GetModelByCache(int Id)
        {

            string CacheKey = "SysNewsRecordModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.SysNewsRecord.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.SysNewsRecord)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.SysNewsRecord.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.SysNewsRecord.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.SysNewsRecord> GetModelList(string strWhere)
        {
            DataSet ds = DAL.SysNewsRecord.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.SysNewsRecord> DataTableToList(DataTable dt)
        {
            List<NH.Model.SysNewsRecord> modelList = new List<NH.Model.SysNewsRecord>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.SysNewsRecord model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.SysNewsRecord();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["ArticleId"].ToString() != "")
                    {
                        model.ArticleId = int.Parse(dt.Rows[n]["ArticleId"].ToString());
                    }
                    if (dt.Rows[n]["UserId"].ToString() != "")
                    {
                        model.UserId = int.Parse(dt.Rows[n]["UserId"].ToString());
                    }
                    if (dt.Rows[n]["UserType"].ToString() != "")
                    {
                        model.UserType = int.Parse(dt.Rows[n]["UserType"].ToString());
                    }
                    if (dt.Rows[n]["ReadStatus"].ToString() != "")
                    {
                        if ((dt.Rows[n]["ReadStatus"].ToString() == "1") || (dt.Rows[n]["ReadStatus"].ToString().ToLower() == "true"))
                        {
                            model.ReadStatus = true;
                        }
                        else
                        {
                            model.ReadStatus = false;
                        }
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