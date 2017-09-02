using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Engineering
    /// </summary>
    public partial class Engineering
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.Engineering model)
        {
            return DAL.Engineering.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Engineering model)
        {
            return DAL.Engineering.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Engineering model)
        {
            return DAL.Engineering.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.Engineering.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.Engineering.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Engineering GetModel(int Id)
        {

            return DAL.Engineering.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Engineering GetModel(NH.Model.Engineering model)
        {
            return DAL.Engineering.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.Engineering GetModelByCache(int Id)
        {

            string CacheKey = "EngineeringModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.Engineering.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.Engineering)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.Engineering.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.Engineering.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Engineering> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Engineering.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Engineering> DataTableToList(DataTable dt)
        {
            List<NH.Model.Engineering> modelList = new List<NH.Model.Engineering>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.Engineering model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.Engineering();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["ZhiBaoJin"].ToString() != "")
                    {
                        model.ZhiBaoJin = decimal.Parse(dt.Rows[n]["ZhiBaoJin"].ToString());
                    }
                    if (dt.Rows[n]["GuangLiFei"].ToString() != "")
                    {
                        model.GuangLiFei = decimal.Parse(dt.Rows[n]["GuangLiFei"].ToString());
                    }
                    if (dt.Rows[n]["FuJiaShui"].ToString() != "")
                    {
                        model.FuJiaShui = decimal.Parse(dt.Rows[n]["FuJiaShui"].ToString());
                    }
                    if (dt.Rows[n]["QySuoDeShui"].ToString() != "")
                    {
                        model.QySuoDeShui = decimal.Parse(dt.Rows[n]["QySuoDeShui"].ToString());
                    }
                    if (dt.Rows[n]["GrSuoDeShui"].ToString() != "")
                    {
                        model.GrSuoDeShui = decimal.Parse(dt.Rows[n]["GrSuoDeShui"].ToString());
                    }
                    if (dt.Rows[n]["YinHuaShui"].ToString() != "")
                    {
                        model.YinHuaShui = decimal.Parse(dt.Rows[n]["YinHuaShui"].ToString());
                    }
                    if (dt.Rows[n]["QTKuan"].ToString() != "")
                    {
                        model.QTKuan = decimal.Parse(dt.Rows[n]["QTKuan"].ToString());
                    }
                    if (dt.Rows[n]["LiXi"].ToString() != "")
                    {
                        model.LiXi = decimal.Parse(dt.Rows[n]["LiXi"].ToString());
                    }
                    if (dt.Rows[n]["HGSKuan"].ToString() != "")
                    {
                        model.HGSKuan = decimal.Parse(dt.Rows[n]["HGSKuan"].ToString());
                    }
                    if (dt.Rows[n]["DDYHCunKuan"].ToString() != "")
                    {
                        model.DDYHCunKuan = decimal.Parse(dt.Rows[n]["DDYHCunKuan"].ToString());
                    }
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    if (dt.Rows[n]["Fid"].ToString() != "")
                    {
                        model.Fid = int.Parse(dt.Rows[n]["Fid"].ToString());
                    }
                    if (dt.Rows[n]["JiSuan"].ToString() != "")
                    {
                        if ((dt.Rows[n]["JiSuan"].ToString() == "1") || (dt.Rows[n]["JiSuan"].ToString().ToLower() == "true"))
                        {
                            model.JiSuan = true;
                        }
                        else
                        {
                            model.JiSuan = false;
                        }
                    }
                    model.Remark = dt.Rows[n]["Remark"].ToString();
                    if (dt.Rows[n]["ImportAmount"].ToString() != "")
                    {
                        model.ImportAmount = decimal.Parse(dt.Rows[n]["ImportAmount"].ToString());
                    }
                    if (dt.Rows[n]["ImportAmountConfirm"].ToString() != "")
                    {
                        model.ImportAmountConfirm = decimal.Parse(dt.Rows[n]["ImportAmountConfirm"].ToString());
                    }
                    if (dt.Rows[n]["ExportAmount"].ToString() != "")
                    {
                        model.ExportAmount = decimal.Parse(dt.Rows[n]["ExportAmount"].ToString());
                    }
                    if (dt.Rows[n]["ExportAmountConfirm"].ToString() != "")
                    {
                        model.ExportAmountConfirm = decimal.Parse(dt.Rows[n]["ExportAmountConfirm"].ToString());
                    }
                    if (dt.Rows[n]["Balance"].ToString() != "")
                    {
                        model.Balance = decimal.Parse(dt.Rows[n]["Balance"].ToString());
                    }
                    if (dt.Rows[n]["BaoZhenJin"].ToString() != "")
                    {
                        model.BaoZhenJin = decimal.Parse(dt.Rows[n]["BaoZhenJin"].ToString());
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