using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Product
    /// </summary>
    public partial class Product
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.Product model)
        {
            return DAL.Product.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Product model)
        {
            return DAL.Product.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Product model)
        {
            return DAL.Product.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.Product.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.Product.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Product GetModel(int Id)
        {

            return DAL.Product.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Product GetModel(NH.Model.Product model)
        {
            return DAL.Product.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.Product GetModelByCache(int Id)
        {

            string CacheKey = "ProductModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.Product.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.Product)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.Product.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.Product.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Product> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Product.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Product> DataTableToList(DataTable dt)
        {
            List<NH.Model.Product> modelList = new List<NH.Model.Product>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.Product model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.Product();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Model = dt.Rows[n]["Model"].ToString();
                    model.Phone = dt.Rows[n]["Phone"].ToString();
                    model.Imgs = dt.Rows[n]["Imgs"].ToString();
                    model.Address = dt.Rows[n]["Address"].ToString();
                    model.HomePage = dt.Rows[n]["HomePage"].ToString();
                    model.Space = dt.Rows[n]["Space"].ToString();
                    model.EmployeeQty = dt.Rows[n]["EmployeeQty"].ToString();
                    model.Camera = dt.Rows[n]["Camera"].ToString();
                    model.Studio = dt.Rows[n]["Studio"].ToString();
                    model.Description = dt.Rows[n]["Description"].ToString();
                    model.content = dt.Rows[n]["content"].ToString();
                    if (dt.Rows[n]["IdentityVerified"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IdentityVerified"].ToString() == "1") || (dt.Rows[n]["IdentityVerified"].ToString().ToLower() == "true"))
                        {
                            model.IdentityVerified = true;
                        }
                        else
                        {
                            model.IdentityVerified = false;
                        }
                    }
                    if (dt.Rows[n]["LevelID"].ToString() != "")
                    {
                        model.LevelID = int.Parse(dt.Rows[n]["LevelID"].ToString());
                    }
                    if (dt.Rows[n]["VerifyStatus"].ToString() != "")
                    {
                        model.VerifyStatus = int.Parse(dt.Rows[n]["VerifyStatus"].ToString());
                    }
                    if (dt.Rows[n]["ExpireDate"].ToString() != "")
                    {
                        model.ExpireDate = DateTime.Parse(dt.Rows[n]["ExpireDate"].ToString());
                    }
                    if (dt.Rows[n]["ViewCount"].ToString() != "")
                    {
                        model.ViewCount = int.Parse(dt.Rows[n]["ViewCount"].ToString());
                    }
                    if (dt.Rows[n]["IsVerify"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsVerify"].ToString() == "1") || (dt.Rows[n]["IsVerify"].ToString().ToLower() == "true"))
                        {
                            model.IsVerify = true;
                        }
                        else
                        {
                            model.IsVerify = false;
                        }
                    }
                    model.Barcode = dt.Rows[n]["Barcode"].ToString();
                    if (dt.Rows[n]["ChengBen"].ToString() != "")
                    {
                        model.ChengBen = decimal.Parse(dt.Rows[n]["ChengBen"].ToString());
                    }
                    if (dt.Rows[n]["ChuShou"].ToString() != "")
                    {
                        model.ChuShou = decimal.Parse(dt.Rows[n]["ChuShou"].ToString());
                    }
                    if (dt.Rows[n]["RuKuSum"].ToString() != "")
                    {
                        model.RuKuSum = int.Parse(dt.Rows[n]["RuKuSum"].ToString());
                    }
                    model.Name = dt.Rows[n]["Name"].ToString();
                    if (dt.Rows[n]["ChuKuSum"].ToString() != "")
                    {
                        model.ChuKuSum = int.Parse(dt.Rows[n]["ChuKuSum"].ToString());
                    }
                    if (dt.Rows[n]["NowKuCun"].ToString() != "")
                    {
                        model.NowKuCun = int.Parse(dt.Rows[n]["NowKuCun"].ToString());
                    }
                    if (dt.Rows[n]["KuCunBaoJing"].ToString() != "")
                    {
                        model.KuCunBaoJing = int.Parse(dt.Rows[n]["KuCunBaoJing"].ToString());
                    }
                    model.CunChuWeiZhi = dt.Rows[n]["CunChuWeiZhi"].ToString();
                    if (dt.Rows[n]["JiFenPrice"].ToString() != "")
                    {
                        model.JiFenPrice = int.Parse(dt.Rows[n]["JiFenPrice"].ToString());
                    }
                    if (dt.Rows[n]["KeJiFen"].ToString() != "")
                    {
                        model.KeJiFen = int.Parse(dt.Rows[n]["KeJiFen"].ToString());
                    }
                    if (dt.Rows[n]["Order"].ToString() != "")
                    {
                        model.Order = int.Parse(dt.Rows[n]["Order"].ToString());
                    }
                    model.Pic = dt.Rows[n]["Pic"].ToString();
                    model.SmallPic = dt.Rows[n]["SmallPic"].ToString();
                    if (dt.Rows[n]["CategoryID"].ToString() != "")
                    {
                        model.CategoryID = int.Parse(dt.Rows[n]["CategoryID"].ToString());
                    }
                    model.CategoryPath = dt.Rows[n]["CategoryPath"].ToString();
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
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