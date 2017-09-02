using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// FaPiao
    /// </summary>
    public partial class FaPiao
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.FaPiao model)
        {
            return DAL.FaPiao.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.FaPiao model)
        {
            return DAL.FaPiao.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.FaPiao model)
        {
            return DAL.FaPiao.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.FaPiao.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.FaPiao.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.FaPiao GetModel(int Id)
        {

            return DAL.FaPiao.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.FaPiao GetModel(NH.Model.FaPiao model)
        {
            return DAL.FaPiao.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.FaPiao GetModelByCache(int Id)
        {

            string CacheKey = "FaPiaoModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.FaPiao.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.FaPiao)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.FaPiao.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.FaPiao.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.FaPiao> GetModelList(string strWhere)
        {
            DataSet ds = DAL.FaPiao.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.FaPiao> DataTableToList(DataTable dt)
        {
            List<NH.Model.FaPiao> modelList = new List<NH.Model.FaPiao>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.FaPiao model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.FaPiao();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["YinYeEr"].ToString() != "")
                    {
                        model.YinYeEr = decimal.Parse(dt.Rows[n]["YinYeEr"].ToString());
                    }
                    if (dt.Rows[n]["ChenJianEr"].ToString() != "")
                    {
                        model.ChenJianEr = decimal.Parse(dt.Rows[n]["ChenJianEr"].ToString());
                    }
                    if (dt.Rows[n]["JYFFuJia"].ToString() != "")
                    {
                        model.JYFFuJia = decimal.Parse(dt.Rows[n]["JYFFuJia"].ToString());
                    }
                    if (dt.Rows[n]["DFJYFFuJia"].ToString() != "")
                    {
                        model.DFJYFFuJia = decimal.Parse(dt.Rows[n]["DFJYFFuJia"].ToString());
                    }
                    if (dt.Rows[n]["QYSuoDeShui"].ToString() != "")
                    {
                        model.QYSuoDeShui = decimal.Parse(dt.Rows[n]["QYSuoDeShui"].ToString());
                    }
                    if (dt.Rows[n]["GRSuoDeShui"].ToString() != "")
                    {
                        model.GRSuoDeShui = decimal.Parse(dt.Rows[n]["GRSuoDeShui"].ToString());
                    }
                    if (dt.Rows[n]["YinHuaShui"].ToString() != "")
                    {
                        model.YinHuaShui = decimal.Parse(dt.Rows[n]["YinHuaShui"].ToString());
                    }
                    if (dt.Rows[n]["QiTa"].ToString() != "")
                    {
                        model.QiTa = decimal.Parse(dt.Rows[n]["QiTa"].ToString());
                    }
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    model.ZiHao = dt.Rows[n]["ZiHao"].ToString();
                    if (dt.Rows[n]["FPAmount"].ToString() != "")
                    {
                        model.FPAmount = decimal.Parse(dt.Rows[n]["FPAmount"].ToString());
                    }
                    model.SPHao = dt.Rows[n]["SPHao"].ToString();
                    if (dt.Rows[n]["FPShuiKuan"].ToString() != "")
                    {
                        model.FPShuiKuan = decimal.Parse(dt.Rows[n]["FPShuiKuan"].ToString());
                    }
                    model.LSAddress = dt.Rows[n]["LSAddress"].ToString();
                    if (dt.Rows[n]["Fid"].ToString() != "")
                    {
                        model.Fid = int.Parse(dt.Rows[n]["Fid"].ToString());
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