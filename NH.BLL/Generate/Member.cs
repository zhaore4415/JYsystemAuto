using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Member
    /// </summary>
    public partial class Member
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.Member model)
        {
            return DAL.Member.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static void Add(NH.Model.Member model)
        {

            DAL.Member.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Member model)
        {
            return DAL.Member.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.Member.Delete(Id);
        }
        #endregion


        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Member GetModel(int Id)
        {

            return DAL.Member.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Member GetModel(NH.Model.Member model)
        {
            return DAL.Member.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.Member GetModelByCache(int Id)
        {

            string CacheKey = "MemberModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.Member.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.Member)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.Member.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.Member.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Member> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Member.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Member> DataTableToList(DataTable dt)
        {
            List<NH.Model.Member> modelList = new List<NH.Model.Member>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.Member model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.Member();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.CurAddr = dt.Rows[n]["CurAddr"].ToString();
                    if (dt.Rows[n]["ExperienceID"].ToString() != "")
                    {
                        model.ExperienceID = int.Parse(dt.Rows[n]["ExperienceID"].ToString());
                    }
                    if (dt.Rows[n]["DegreeID"].ToString() != "")
                    {
                        model.DegreeID = int.Parse(dt.Rows[n]["DegreeID"].ToString());
                    }
                    model.DegreeName = dt.Rows[n]["DegreeName"].ToString();
                    model.Mobile = dt.Rows[n]["Mobile"].ToString();
                    if (dt.Rows[n]["MobileVerified"].ToString() != "")
                    {
                        if ((dt.Rows[n]["MobileVerified"].ToString() == "1") || (dt.Rows[n]["MobileVerified"].ToString().ToLower() == "true"))
                        {
                            model.MobileVerified = true;
                        }
                        else
                        {
                            model.MobileVerified = false;
                        }
                    }
                    model.Phone = dt.Rows[n]["Phone"].ToString();
                    model.QQ = dt.Rows[n]["QQ"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    model.Address = dt.Rows[n]["Address"].ToString();
                    model.Realname = dt.Rows[n]["Realname"].ToString();
                    model.HomePage = dt.Rows[n]["HomePage"].ToString();
                    if (dt.Rows[n]["IsHousing"].ToString() != "")
                    {
                        model.IsHousing = int.Parse(dt.Rows[n]["IsHousing"].ToString());
                    }
                    if (dt.Rows[n]["IsCarFare"].ToString() != "")
                    {
                        model.IsCarFare = int.Parse(dt.Rows[n]["IsCarFare"].ToString());
                    }
                    model.JobCategoryIDs = dt.Rows[n]["JobCategoryIDs"].ToString();
                    model.JobCategoryName = dt.Rows[n]["JobCategoryName"].ToString();
                    if (dt.Rows[n]["SalaryID"].ToString() != "")
                    {
                        model.SalaryID = int.Parse(dt.Rows[n]["SalaryID"].ToString());
                    }
                    model.SalaryName = dt.Rows[n]["SalaryName"].ToString();
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
                    if (dt.Rows[n]["Sex"].ToString() != "")
                    {
                        model.Sex = int.Parse(dt.Rows[n]["Sex"].ToString());
                    }
                    model.JobAddrID = dt.Rows[n]["JobAddrID"].ToString();
                    model.JobAddr = dt.Rows[n]["JobAddr"].ToString();
                    model.Resume = dt.Rows[n]["Resume"].ToString();
                    model.SelfEvaluation = dt.Rows[n]["SelfEvaluation"].ToString();
                    model.IdentityNo = dt.Rows[n]["IdentityNo"].ToString();
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
                    if (dt.Rows[n]["IsShow"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsShow"].ToString() == "1") || (dt.Rows[n]["IsShow"].ToString().ToLower() == "true"))
                        {
                            model.IsShow = true;
                        }
                        else
                        {
                            model.IsShow = false;
                        }
                    }
                    if (dt.Rows[n]["ViewCount"].ToString() != "")
                    {
                        model.ViewCount = int.Parse(dt.Rows[n]["ViewCount"].ToString());
                    }
                    if (dt.Rows[n]["WorksCount"].ToString() != "")
                    {
                        model.WorksCount = int.Parse(dt.Rows[n]["WorksCount"].ToString());
                    }
                    if (dt.Rows[n]["VerifyStatus"].ToString() != "")
                    {
                        model.VerifyStatus = int.Parse(dt.Rows[n]["VerifyStatus"].ToString());
                    }
                    if (dt.Rows[n]["Birthday"].ToString() != "")
                    {
                        model.Birthday = DateTime.Parse(dt.Rows[n]["Birthday"].ToString());
                    }
                    if (dt.Rows[n]["IsGood"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsGood"].ToString() == "1") || (dt.Rows[n]["IsGood"].ToString().ToLower() == "true"))
                        {
                            model.IsGood = true;
                        }
                        else
                        {
                            model.IsGood = false;
                        }
                    }
                    if (dt.Rows[n]["ComeTimeID"].ToString() != "")
                    {
                        model.ComeTimeID = int.Parse(dt.Rows[n]["ComeTimeID"].ToString());
                    }
                    model.ComeTimeDesc = dt.Rows[n]["ComeTimeDesc"].ToString();
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
                    model.Weixin = dt.Rows[n]["Weixin"].ToString();
                    if (dt.Rows[n]["Height"].ToString() != "")
                    {
                        model.Height = int.Parse(dt.Rows[n]["Height"].ToString());
                    }
                    if (dt.Rows[n]["Marriage"].ToString() != "")
                    {
                        model.Marriage = int.Parse(dt.Rows[n]["Marriage"].ToString());
                    }
                    model.ResidenceAddrID = dt.Rows[n]["ResidenceAddrID"].ToString();
                    model.Residence = dt.Rows[n]["Residence"].ToString();
                    model.CurrAddrID = dt.Rows[n]["CurrAddrID"].ToString();


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