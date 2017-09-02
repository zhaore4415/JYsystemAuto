using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// FunCode
    /// </summary>
    public partial class FunCode
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.FunCode model)
        {
            return DAL.FunCode.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.FunCode model)
        {
            return DAL.FunCode.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.FunCode model)
        {
            return DAL.FunCode.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.FunCode.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.FunCode.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.FunCode GetModel(int Id)
        {

            return DAL.FunCode.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.FunCode GetModel(NH.Model.FunCode model)
        {
            return DAL.FunCode.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.FunCode GetModelByCache(int Id)
        {

            string CacheKey = "FunCodeModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.FunCode.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.FunCode)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.FunCode.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.FunCode.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.FunCode> GetModelList(string strWhere)
        {
            DataSet ds = DAL.FunCode.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.FunCode> DataTableToList(DataTable dt)
        {
            List<NH.Model.FunCode> modelList = new List<NH.Model.FunCode>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.FunCode model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.FunCode();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Name = dt.Rows[n]["Name"].ToString();
                    model.Code = dt.Rows[n]["Code"].ToString();
                    if (dt.Rows[n]["FunType"].ToString() != "")
                    {
                        model.FunType = int.Parse(dt.Rows[n]["FunType"].ToString());
                    }
                    if (dt.Rows[n]["Sort"].ToString() != "")
                    {
                        model.Sort = int.Parse(dt.Rows[n]["Sort"].ToString());
                    }
                    if (dt.Rows[n]["GroupId"].ToString() != "")
                    {
                        model.GroupId = int.Parse(dt.Rows[n]["GroupId"].ToString());
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