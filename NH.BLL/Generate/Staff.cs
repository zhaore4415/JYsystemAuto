using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Staff
    /// </summary>
    public partial class Staff
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.Staff model)
        {
            return DAL.Staff.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Staff model)
        {
            return DAL.Staff.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Staff model)
        {
            return DAL.Staff.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.Staff.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.Staff.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Staff GetModel(int Id)
        {

            return DAL.Staff.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Staff GetModel(NH.Model.Staff model)
        {
            return DAL.Staff.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.Staff GetModelByCache(int Id)
        {

            string CacheKey = "StaffModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.Staff.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.Staff)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.Staff.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.Staff.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Staff> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Staff.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Staff> DataTableToList(DataTable dt)
        {
            List<NH.Model.Staff> modelList = new List<NH.Model.Staff>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.Staff model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.Staff();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["LastLoginTime"].ToString() != "")
                    {
                        model.LastLoginTime = DateTime.Parse(dt.Rows[n]["LastLoginTime"].ToString());
                    }
                    model.LastIP = dt.Rows[n]["LastIP"].ToString();
                    model.LastAddress = dt.Rows[n]["LastAddress"].ToString();
                    if (dt.Rows[n]["LoginCount"].ToString() != "")
                    {
                        model.LoginCount = int.Parse(dt.Rows[n]["LoginCount"].ToString());
                    }
                    if (dt.Rows[n]["UpdateTime"].ToString() != "")
                    {
                        model.UpdateTime = DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
                    }
                    if (dt.Rows[n]["RoleType"].ToString() != "")
                    {
                        model.RoleType = int.Parse(dt.Rows[n]["RoleType"].ToString());
                    }
                    model.Phone = dt.Rows[n]["Phone"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    model.Address = dt.Rows[n]["Address"].ToString();
                    model.Data1 = dt.Rows[n]["Data1"].ToString();
                    model.LoginName = dt.Rows[n]["LoginName"].ToString();
                    model.Data2 = dt.Rows[n]["Data2"].ToString();
                    if (dt.Rows[n]["DataType1"].ToString() != "")
                    {
                        model.DataType1 = int.Parse(dt.Rows[n]["DataType1"].ToString());
                    }
                    if (dt.Rows[n]["DataType2"].ToString() != "")
                    {
                        model.DataType2 = int.Parse(dt.Rows[n]["DataType2"].ToString());
                    }
                    model.WorkNumber = dt.Rows[n]["WorkNumber"].ToString();
                    model.TodayDate = dt.Rows[n]["TodayDate"].ToString();
                    model.Password = dt.Rows[n]["Password"].ToString();
                    model.Realname = dt.Rows[n]["Realname"].ToString();
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["LoginTime"].ToString() != "")
                    {
                        model.LoginTime = DateTime.Parse(dt.Rows[n]["LoginTime"].ToString());
                    }
                    model.LoginIP = dt.Rows[n]["LoginIP"].ToString();
                    model.LoginAddress = dt.Rows[n]["LoginAddress"].ToString();


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