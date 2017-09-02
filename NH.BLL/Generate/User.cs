using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// User
    /// </summary>
    public partial class User
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.User model)
        {
            return DAL.User.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.User model)
        {
            return DAL.User.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.User model)
        {
            return DAL.User.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.User.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.User.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.User GetModel(int Id)
        {

            return DAL.User.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.User GetModel(NH.Model.User model)
        {
            return DAL.User.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.User GetModelByCache(int Id)
        {

            string CacheKey = "UserModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.User.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.User)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.User.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.User.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.User> GetModelList(string strWhere)
        {
            DataSet ds = DAL.User.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.User> DataTableToList(DataTable dt)
        {
            List<NH.Model.User> modelList = new List<NH.Model.User>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.User model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.User();
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
                    if (dt.Rows[n]["Completed"].ToString() != "")
                    {
                        model.Completed = decimal.Parse(dt.Rows[n]["Completed"].ToString());
                    }
                    if (dt.Rows[n]["UpdateTime"].ToString() != "")
                    {
                        model.UpdateTime = DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
                    }
                    if (dt.Rows[n]["RefreshTime"].ToString() != "")
                    {
                        model.RefreshTime = DateTime.Parse(dt.Rows[n]["RefreshTime"].ToString());
                    }
                    if (dt.Rows[n]["UserType"].ToString() != "")
                    {
                        model.UserType = int.Parse(dt.Rows[n]["UserType"].ToString());
                    }
                    model.PhotoOriginal = dt.Rows[n]["PhotoOriginal"].ToString();
                    model.PhotoCoording = dt.Rows[n]["PhotoCoording"].ToString();
                    model.LoginName = dt.Rows[n]["LoginName"].ToString();
                    if (dt.Rows[n]["PhotoVerifyStatus"].ToString() != "")
                    {
                        model.PhotoVerifyStatus = int.Parse(dt.Rows[n]["PhotoVerifyStatus"].ToString());
                    }
                    model.PhotoNew = dt.Rows[n]["PhotoNew"].ToString();
                    model.SessionId = dt.Rows[n]["SessionId"].ToString();
                    model.Phone = dt.Rows[n]["Phone"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    model.Address = dt.Rows[n]["Address"].ToString();
                    model.QQ = dt.Rows[n]["QQ"].ToString();
                    if (dt.Rows[n]["Sex"].ToString() != "")
                    {
                        model.Sex = int.Parse(dt.Rows[n]["Sex"].ToString());
                    }
                    model.Source = dt.Rows[n]["Source"].ToString();
                    model.Environment = dt.Rows[n]["Environment"].ToString();
                    model.Password = dt.Rows[n]["Password"].ToString();
                    model.Text1 = dt.Rows[n]["Text1"].ToString();
                    model.Text2 = dt.Rows[n]["Text2"].ToString();
                    if (dt.Rows[n]["Text3"].ToString() != "")
                    {
                        model.Text3 = int.Parse(dt.Rows[n]["Text3"].ToString());
                    }
                    if (dt.Rows[n]["Text4"].ToString() != "")
                    {
                        model.Text4 = int.Parse(dt.Rows[n]["Text4"].ToString());
                    }
                    if (dt.Rows[n]["Text5"].ToString() != "")
                    {
                        model.Text5 = int.Parse(dt.Rows[n]["Text5"].ToString());
                    }
                    if (dt.Rows[n]["Text6"].ToString() != "")
                    {
                        model.Text6 = int.Parse(dt.Rows[n]["Text6"].ToString());
                    }
                    model.Text7 = dt.Rows[n]["Text7"].ToString();
                    model.Text9 = dt.Rows[n]["Text9"].ToString();
                    model.Text10 = dt.Rows[n]["Text10"].ToString();
                    model.Text11 = dt.Rows[n]["Text11"].ToString();
                    model.Photo = dt.Rows[n]["Photo"].ToString();
                    model.Age = dt.Rows[n]["Age"].ToString();
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

        public static int queryOrderNumber(int id)
        {
            
            return DAL.User.queryOrderNumber(id);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataSet GetListByPage(string strWhere, string orderField, string orderby, int pageIndex, int pageSize, ref int count)
        {
            return DAL.User.GetListByPage(strWhere, orderField, orderby, pageIndex, pageSize, ref count);
        }
    }
}