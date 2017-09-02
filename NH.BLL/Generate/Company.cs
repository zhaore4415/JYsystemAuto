using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Company
    /// </summary>
    public partial class Company
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.Company model)
        {
            return DAL.Company.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static void Add(NH.Model.Company model)
        {

            DAL.Company.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Company model)
        {
            return DAL.Company.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.Company.Delete(Id);
        }
        #endregion


        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Company GetModel(int Id)
        {

            return DAL.Company.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Company GetModel(NH.Model.Company model)
        {
            return DAL.Company.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.Company GetModelByCache(int Id)
        {

            string CacheKey = "CompanyModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.Company.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.Company)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.Company.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.Company.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Company> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Company.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Company> DataTableToList(DataTable dt)
        {
            List<NH.Model.Company> modelList = new List<NH.Model.Company>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.Company model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.Company();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Address = dt.Rows[n]["Address"].ToString();
                    model.HomePage = dt.Rows[n]["HomePage"].ToString();
                    model.Space = dt.Rows[n]["Space"].ToString();
                    model.EmployeeQty = dt.Rows[n]["EmployeeQty"].ToString();
                    model.Camera = dt.Rows[n]["Camera"].ToString();
                    model.Studio = dt.Rows[n]["Studio"].ToString();
                    model.Description = dt.Rows[n]["Description"].ToString();
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
                    model.CompanyName = dt.Rows[n]["CompanyName"].ToString();
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
                    if (dt.Rows[n]["VipOpenType"].ToString() != "")
                    {
                        model.VipOpenType = int.Parse(dt.Rows[n]["VipOpenType"].ToString());
                    }
                    if (dt.Rows[n]["JobRefreshTime"].ToString() != "")
                    {
                        model.JobRefreshTime = DateTime.Parse(dt.Rows[n]["JobRefreshTime"].ToString());
                    }
                    if (dt.Rows[n]["IsStandard"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsStandard"].ToString() == "1") || (dt.Rows[n]["IsStandard"].ToString().ToLower() == "true"))
                        {
                            model.IsStandard = true;
                        }
                        else
                        {
                            model.IsStandard = false;
                        }
                    }
                    if (dt.Rows[n]["IsFoodAdd"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsFoodAdd"].ToString() == "1") || (dt.Rows[n]["IsFoodAdd"].ToString().ToLower() == "true"))
                        {
                            model.IsFoodAdd = true;
                        }
                        else
                        {
                            model.IsFoodAdd = false;
                        }
                    }
                    if (dt.Rows[n]["IsOfferRoom"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsOfferRoom"].ToString() == "1") || (dt.Rows[n]["IsOfferRoom"].ToString().ToLower() == "true"))
                        {
                            model.IsOfferRoom = true;
                        }
                        else
                        {
                            model.IsOfferRoom = false;
                        }
                    }
                    if (dt.Rows[n]["IsOfferFood"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsOfferFood"].ToString() == "1") || (dt.Rows[n]["IsOfferFood"].ToString().ToLower() == "true"))
                        {
                            model.IsOfferFood = true;
                        }
                        else
                        {
                            model.IsOfferFood = false;
                        }
                    }
                    if (dt.Rows[n]["IsFiveInsurance"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsFiveInsurance"].ToString() == "1") || (dt.Rows[n]["IsFiveInsurance"].ToString().ToLower() == "true"))
                        {
                            model.IsFiveInsurance = true;
                        }
                        else
                        {
                            model.IsFiveInsurance = false;
                        }
                    }
                    model.Contact = dt.Rows[n]["Contact"].ToString();
                    if (dt.Rows[n]["IsFund"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsFund"].ToString() == "1") || (dt.Rows[n]["IsFund"].ToString().ToLower() == "true"))
                        {
                            model.IsFund = true;
                        }
                        else
                        {
                            model.IsFund = false;
                        }
                    }
                    if (dt.Rows[n]["IsCarFare"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsCarFare"].ToString() == "1") || (dt.Rows[n]["IsCarFare"].ToString().ToLower() == "true"))
                        {
                            model.IsCarFare = true;
                        }
                        else
                        {
                            model.IsCarFare = false;
                        }
                    }
                    if (dt.Rows[n]["IsYearGuarantee"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsYearGuarantee"].ToString() == "1") || (dt.Rows[n]["IsYearGuarantee"].ToString().ToLower() == "true"))
                        {
                            model.IsYearGuarantee = true;
                        }
                        else
                        {
                            model.IsYearGuarantee = false;
                        }
                    }
                    if (dt.Rows[n]["Balance"].ToString() != "")
                    {
                        model.Balance = decimal.Parse(dt.Rows[n]["Balance"].ToString());
                    }
                    if (dt.Rows[n]["IsReceive"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsReceive"].ToString() == "1") || (dt.Rows[n]["IsReceive"].ToString().ToLower() == "true"))
                        {
                            model.IsReceive = true;
                        }
                        else
                        {
                            model.IsReceive = false;
                        }
                    }
                    if (dt.Rows[n]["ReceiveEndTime"].ToString() != "")
                    {
                        model.ReceiveEndTime = DateTime.Parse(dt.Rows[n]["ReceiveEndTime"].ToString());
                    }
                    model.ReceiveAddress = dt.Rows[n]["ReceiveAddress"].ToString();
                    if (dt.Rows[n]["TotalSignUp"].ToString() != "")
                    {
                        model.TotalSignUp = int.Parse(dt.Rows[n]["TotalSignUp"].ToString());
                    }
                    if (dt.Rows[n]["CurSignUp"].ToString() != "")
                    {
                        model.CurSignUp = int.Parse(dt.Rows[n]["CurSignUp"].ToString());
                    }
                    if (dt.Rows[n]["ReceiveTimes"].ToString() != "")
                    {
                        model.ReceiveTimes = int.Parse(dt.Rows[n]["ReceiveTimes"].ToString());
                    }
                    model.AreaID = dt.Rows[n]["AreaID"].ToString();
                    model.Logo = dt.Rows[n]["Logo"].ToString();
                    model.Area = dt.Rows[n]["Area"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    model.QQ = dt.Rows[n]["QQ"].ToString();
                    model.Phone = dt.Rows[n]["Phone"].ToString();
                    model.OtherPhone = dt.Rows[n]["OtherPhone"].ToString();


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