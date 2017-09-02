using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Job
    /// </summary>
    public partial class Job
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.Job model)
        {
            return DAL.Job.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Job model)
        {
            return DAL.Job.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Job model)
        {
            return DAL.Job.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.Job.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.Job.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Job GetModel(int Id)
        {

            return DAL.Job.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Job GetModel(NH.Model.Job model)
        {
            return DAL.Job.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.Job GetModelByCache(int Id)
        {

            string CacheKey = "JobModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.Job.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.Job)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.Job.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.Job.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Job> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Job.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Job> DataTableToList(DataTable dt)
        {
            List<NH.Model.Job> modelList = new List<NH.Model.Job>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.Job model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.Job();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.DegreeName = dt.Rows[n]["DegreeName"].ToString();
                    if (dt.Rows[n]["ExperienceID"].ToString() != "")
                    {
                        model.ExperienceID = int.Parse(dt.Rows[n]["ExperienceID"].ToString());
                    }
                    if (dt.Rows[n]["Sex"].ToString() != "")
                    {
                        model.Sex = int.Parse(dt.Rows[n]["Sex"].ToString());
                    }
                    if (dt.Rows[n]["IsCarFare"].ToString() != "")
                    {
                        model.IsCarFare = int.Parse(dt.Rows[n]["IsCarFare"].ToString());
                    }
                    if (dt.Rows[n]["IsHousing"].ToString() != "")
                    {
                        model.IsHousing = int.Parse(dt.Rows[n]["IsHousing"].ToString());
                    }
                    model.WorkTime = dt.Rows[n]["WorkTime"].ToString();
                    if (dt.Rows[n]["Quantity"].ToString() != "")
                    {
                        model.Quantity = int.Parse(dt.Rows[n]["Quantity"].ToString());
                    }
                    if (dt.Rows[n]["ExpireDate"].ToString() != "")
                    {
                        model.ExpireDate = DateTime.Parse(dt.Rows[n]["ExpireDate"].ToString());
                    }
                    model.Description = dt.Rows[n]["Description"].ToString();
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    model.JobTitle = dt.Rows[n]["JobTitle"].ToString();
                    if (dt.Rows[n]["Verified"].ToString() != "")
                    {
                        model.Verified = int.Parse(dt.Rows[n]["Verified"].ToString());
                    }
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    if (dt.Rows[n]["ViewCount"].ToString() != "")
                    {
                        model.ViewCount = int.Parse(dt.Rows[n]["ViewCount"].ToString());
                    }
                    if (dt.Rows[n]["UpdateTime"].ToString() != "")
                    {
                        model.UpdateTime = DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
                    }
                    if (dt.Rows[n]["RefreshTime"].ToString() != "")
                    {
                        model.RefreshTime = DateTime.Parse(dt.Rows[n]["RefreshTime"].ToString());
                    }
                    if (dt.Rows[n]["IsFix"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsFix"].ToString() == "1") || (dt.Rows[n]["IsFix"].ToString().ToLower() == "true"))
                        {
                            model.IsFix = true;
                        }
                        else
                        {
                            model.IsFix = false;
                        }
                    }
                    model.Description_New = dt.Rows[n]["Description_New"].ToString();
                    model.SalaryDesc = dt.Rows[n]["SalaryDesc"].ToString();
                    model.WorkContent = dt.Rows[n]["WorkContent"].ToString();
                    model.Requirements = dt.Rows[n]["Requirements"].ToString();
                    if (dt.Rows[n]["CompanyID"].ToString() != "")
                    {
                        model.CompanyID = int.Parse(dt.Rows[n]["CompanyID"].ToString());
                    }
                    model.RoomAndFood = dt.Rows[n]["RoomAndFood"].ToString();
                    model.Welfare = dt.Rows[n]["Welfare"].ToString();
                    model.Jobtitle_New = dt.Rows[n]["Jobtitle_New"].ToString();
                    model.SalaryDesc_New = dt.Rows[n]["SalaryDesc_New"].ToString();
                    model.WorkContent_New = dt.Rows[n]["WorkContent_New"].ToString();
                    model.Requirements_New = dt.Rows[n]["Requirements_New"].ToString();
                    model.RoomAndFood_New = dt.Rows[n]["RoomAndFood_New"].ToString();
                    model.Welfare_New = dt.Rows[n]["Welfare_New"].ToString();
                    model.WorkAddress = dt.Rows[n]["WorkAddress"].ToString();
                    model.CategoryNo = dt.Rows[n]["CategoryNo"].ToString();
                    if (dt.Rows[n]["SalaryID"].ToString() != "")
                    {
                        model.SalaryID = int.Parse(dt.Rows[n]["SalaryID"].ToString());
                    }
                    if (dt.Rows[n]["Commission"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Commission"].ToString() == "1") || (dt.Rows[n]["Commission"].ToString().ToLower() == "true"))
                        {
                            model.Commission = true;
                        }
                        else
                        {
                            model.Commission = false;
                        }
                    }
                    model.JobTypeID = dt.Rows[n]["JobTypeID"].ToString();
                    model.JobTypeName = dt.Rows[n]["JobTypeName"].ToString();
                    model.DegreeID = dt.Rows[n]["DegreeID"].ToString();


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