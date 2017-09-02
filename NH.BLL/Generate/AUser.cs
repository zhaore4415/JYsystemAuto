using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// AUser
    /// </summary>
    public partial class AUser
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.AUser model)
        {
            return DAL.AUser.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.AUser model)
        {
            return DAL.AUser.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.AUser model)
        {
            return DAL.AUser.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.AUser.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.AUser.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.AUser GetModel(int Id)
        {

            return DAL.AUser.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.AUser GetModel(NH.Model.AUser model)
        {
            return DAL.AUser.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.AUser GetModelByCache(int Id)
        {

            string CacheKey = "AUserModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.AUser.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.AUser)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.AUser.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.AUser.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.AUser> GetModelList(string strWhere)
        {
            DataSet ds = DAL.AUser.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.AUser> DataTableToList(DataTable dt)
        {
            List<NH.Model.AUser> modelList = new List<NH.Model.AUser>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.AUser model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.AUser();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
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
                    if (dt.Rows[n]["SerialNumber"].ToString() != "")
                    {
                        model.SerialNumber = int.Parse(dt.Rows[n]["SerialNumber"].ToString());
                    }
                    if (dt.Rows[n]["RoleType"].ToString() != "")
                    {
                        model.RoleType = int.Parse(dt.Rows[n]["RoleType"].ToString());
                    }
                    if (dt.Rows[n]["ZhiWei"].ToString() != "")
                    {
                        model.ZhiWei = int.Parse(dt.Rows[n]["ZhiWei"].ToString());
                    }
                    if (dt.Rows[n]["ZaiGang"].ToString() != "")
                    {
                        model.ZaiGang = int.Parse(dt.Rows[n]["ZaiGang"].ToString());
                    }
                    model.GangWei = dt.Rows[n]["GangWei"].ToString();
                    model.Department = dt.Rows[n]["Department"].ToString();
                    model.Born = dt.Rows[n]["Born"].ToString();
                    model.MingZu = dt.Rows[n]["MingZu"].ToString();
                    model.ShenFengZheng = dt.Rows[n]["ShenFengZheng"].ToString();
                    model.Marital = dt.Rows[n]["Marital"].ToString();
                    model.ZhenZhi = dt.Rows[n]["ZhenZhi"].ToString();
                    model.LoginName = dt.Rows[n]["LoginName"].ToString();
                    model.GuanJi = dt.Rows[n]["GuanJi"].ToString();
                    model.HuKou = dt.Rows[n]["HuKou"].ToString();
                    model.XueLi = dt.Rows[n]["XueLi"].ToString();
                    model.ZhiCheng = dt.Rows[n]["ZhiCheng"].ToString();
                    model.BiYeXueXiao = dt.Rows[n]["BiYeXueXiao"].ToString();
                    model.ZhuanYe = dt.Rows[n]["ZhuanYe"].ToString();
                    model.GongZuoTime = dt.Rows[n]["GongZuoTime"].ToString();
                    model.JiaRuTime = dt.Rows[n]["JiaRuTime"].ToString();
                    model.GraduationTime = dt.Rows[n]["GraduationTime"].ToString();
                    model.ShouJi = dt.Rows[n]["ShouJi"].ToString();
                    model.Password = dt.Rows[n]["Password"].ToString();
                    model.JiaTingAddress = dt.Rows[n]["JiaTingAddress"].ToString();
                    model.JiaoYu = dt.Rows[n]["JiaoYu"].ToString();
                    model.HeTong = dt.Rows[n]["HeTong"].ToString();
                    model.SheBao = dt.Rows[n]["SheBao"].ToString();
                    model.Notes = dt.Rows[n]["Notes"].ToString();
                    model.FuJian = dt.Rows[n]["FuJian"].ToString();
                    model.Code = dt.Rows[n]["Code"].ToString();
                    if (dt.Rows[n]["fk_id"].ToString() != "")
                    {
                        model.fk_id = int.Parse(dt.Rows[n]["fk_id"].ToString());
                    }
                    if (dt.Rows[n]["sk_id"].ToString() != "")
                    {
                        model.sk_id = int.Parse(dt.Rows[n]["sk_id"].ToString());
                    }
                    if (dt.Rows[n]["tk_id"].ToString() != "")
                    {
                        model.tk_id = int.Parse(dt.Rows[n]["tk_id"].ToString());
                    }
                    model.Realname = dt.Rows[n]["Realname"].ToString();
                    model.WaiYu1 = dt.Rows[n]["WaiYu1"].ToString();
                    model.WaiYu2 = dt.Rows[n]["WaiYu2"].ToString();
                    model.DengJi1 = dt.Rows[n]["DengJi1"].ToString();
                    model.DengJi2 = dt.Rows[n]["DengJi2"].ToString();
                    if (dt.Rows[n]["D_Id"].ToString() != "")
                    {
                        model.D_Id = int.Parse(dt.Rows[n]["D_Id"].ToString());
                    }
                    model.Source = dt.Rows[n]["Source"].ToString();
                    model.CompanyName = dt.Rows[n]["CompanyName"].ToString();
                    model.QQWeiXin = dt.Rows[n]["QQWeiXin"].ToString();
                    if (dt.Rows[n]["JeFen"].ToString() != "")
                    {
                        model.JeFen = int.Parse(dt.Rows[n]["JeFen"].ToString());
                    }
                    if (dt.Rows[n]["T_ID"].ToString() != "")
                    {
                        model.T_ID = int.Parse(dt.Rows[n]["T_ID"].ToString());
                    }
                    if (dt.Rows[n]["Sex"].ToString() != "")
                    {
                        model.Sex = int.Parse(dt.Rows[n]["Sex"].ToString());
                    }
                    if (dt.Rows[n]["ZheKou"].ToString() != "")
                    {
                        model.ZheKou = decimal.Parse(dt.Rows[n]["ZheKou"].ToString());
                    }
                    if (dt.Rows[n]["TJZheKou"].ToString() != "")
                    {
                        model.TJZheKou = decimal.Parse(dt.Rows[n]["TJZheKou"].ToString());
                    }
                    model.Openbank = dt.Rows[n]["Openbank"].ToString();
                    model.OpenbankCard = dt.Rows[n]["OpenbankCard"].ToString();
                    model.OpenCity = dt.Rows[n]["OpenCity"].ToString();
                    if (dt.Rows[n]["IsPayment"].ToString() != "")
                    {
                        model.IsPayment = int.Parse(dt.Rows[n]["IsPayment"].ToString());
                    }
                    if (dt.Rows[n]["VerifyStatus"].ToString() != "")
                    {
                        model.VerifyStatus = int.Parse(dt.Rows[n]["VerifyStatus"].ToString());
                    }
                    model.Pic2 = dt.Rows[n]["Pic2"].ToString();
                    model.Pic4 = dt.Rows[n]["Pic4"].ToString();
                    model.Pic3 = dt.Rows[n]["Pic3"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    if (dt.Rows[n]["IsCheck"].ToString() != "")
                    {
                        model.IsCheck = int.Parse(dt.Rows[n]["IsCheck"].ToString());
                    }
                    if (dt.Rows[n]["IsCheckType"].ToString() != "")
                    {
                        model.IsCheckType = int.Parse(dt.Rows[n]["IsCheckType"].ToString());
                    }
                    model.Pic = dt.Rows[n]["Pic"].ToString();
                    model.Height = dt.Rows[n]["Height"].ToString();


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