using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Accounting
    /// </summary>
    public partial class Accounting
    {
        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(NH.Model.Accounting model)
        {
            return DAL.Accounting.Exists(model);
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Accounting model)
        {
            return DAL.Accounting.Add(model);

        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.Accounting model)
        {
            return DAL.Accounting.Update(model);
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {
            return DAL.Accounting.Delete(Id);
        }
        #endregion

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            return DAL.Accounting.DeleteList(Idlist);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Accounting GetModel(int Id)
        {

            return DAL.Accounting.GetModel(Id);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.Accounting GetModel(NH.Model.Accounting model)
        {
            return DAL.Accounting.GetModel(model);
        }
        #endregion

        #region 得到一个对象实体，从缓存中
        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public static NH.Model.Accounting GetModelByCache(int Id)
        {

            string CacheKey = "AccountingModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = DAL.Accounting.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (NH.Model.Accounting)objModel;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return DAL.Accounting.GetList(strWhere);
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return DAL.Accounting.GetList(Top, strWhere, filedOrder);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Accounting> GetModelList(string strWhere)
        {
            DataSet ds = DAL.Accounting.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<NH.Model.Accounting> DataTableToList(DataTable dt)
        {
            List<NH.Model.Accounting> modelList = new List<NH.Model.Accounting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                NH.Model.Accounting model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new NH.Model.Accounting();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.OutDate = dt.Rows[n]["OutDate"].ToString();
                    model.MaturityDate = dt.Rows[n]["MaturityDate"].ToString();
                    model.OutNo = dt.Rows[n]["OutNo"].ToString();
                    if (dt.Rows[n]["OutMoney"].ToString() != "")
                    {
                        model.OutMoney = decimal.Parse(dt.Rows[n]["OutMoney"].ToString());
                    }
                    if (dt.Rows[n]["IsIssuing"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsIssuing"].ToString() == "1") || (dt.Rows[n]["IsIssuing"].ToString().ToLower() == "true"))
                        {
                            model.IsIssuing = true;
                        }
                        else
                        {
                            model.IsIssuing = false;
                        }
                    }
                    model.PartyName = dt.Rows[n]["PartyName"].ToString();
                    model.ProjectAddress = dt.Rows[n]["ProjectAddress"].ToString();
                    model.Authorize = dt.Rows[n]["Authorize"].ToString();
                    model.AuthorizeTel = dt.Rows[n]["AuthorizeTel"].ToString();
                    model.AuthorizeDate = dt.Rows[n]["AuthorizeDate"].ToString();
                    model.ProjectName = dt.Rows[n]["ProjectName"].ToString();
                    model.AuthorizeMaturityDate = dt.Rows[n]["AuthorizeMaturityDate"].ToString();
                    model.Remark = dt.Rows[n]["Remark"].ToString();
                    model.Remark2 = dt.Rows[n]["Remark2"].ToString();
                    if (dt.Rows[n]["Rates1"].ToString() != "")
                    {
                        model.Rates1 = decimal.Parse(dt.Rows[n]["Rates1"].ToString());
                    }
                    if (dt.Rows[n]["Rates2"].ToString() != "")
                    {
                        model.Rates2 = decimal.Parse(dt.Rows[n]["Rates2"].ToString());
                    }
                    if (dt.Rows[n]["Rates3"].ToString() != "")
                    {
                        model.Rates3 = decimal.Parse(dt.Rows[n]["Rates3"].ToString());
                    }
                    if (dt.Rows[n]["Rates4"].ToString() != "")
                    {
                        model.Rates4 = decimal.Parse(dt.Rows[n]["Rates4"].ToString());
                    }
                    if (dt.Rows[n]["Rates5"].ToString() != "")
                    {
                        model.Rates5 = decimal.Parse(dt.Rows[n]["Rates5"].ToString());
                    }
                    if (dt.Rows[n]["Rates6"].ToString() != "")
                    {
                        model.Rates6 = decimal.Parse(dt.Rows[n]["Rates6"].ToString());
                    }
                    if (dt.Rows[n]["Rates7"].ToString() != "")
                    {
                        model.Rates7 = decimal.Parse(dt.Rows[n]["Rates7"].ToString());
                    }
                    model.ProjectNumber = dt.Rows[n]["ProjectNumber"].ToString();
                    if (dt.Rows[n]["Rates8"].ToString() != "")
                    {
                        model.Rates8 = decimal.Parse(dt.Rows[n]["Rates8"].ToString());
                    }
                    if (dt.Rows[n]["BalanceManager"].ToString() != "")
                    {
                        model.BalanceManager = decimal.Parse(dt.Rows[n]["BalanceManager"].ToString());
                    }
                    if (dt.Rows[n]["Balance"].ToString() != "")
                    {
                        model.Balance = decimal.Parse(dt.Rows[n]["Balance"].ToString());
                    }
                    if (dt.Rows[n]["ClearingMoney"].ToString() != "")
                    {
                        model.ClearingMoney = decimal.Parse(dt.Rows[n]["ClearingMoney"].ToString());
                    }
                    if (dt.Rows[n]["ImportAmount"].ToString() != "")
                    {
                        model.ImportAmount = decimal.Parse(dt.Rows[n]["ImportAmount"].ToString());
                    }
                    if (dt.Rows[n]["ExportAmount"].ToString() != "")
                    {
                        model.ExportAmount = decimal.Parse(dt.Rows[n]["ExportAmount"].ToString());
                    }
                    if (dt.Rows[n]["FuJiaShui"].ToString() != "")
                    {
                        model.FuJiaShui = decimal.Parse(dt.Rows[n]["FuJiaShui"].ToString());
                    }
                    if (dt.Rows[n]["QySuoDeShui"].ToString() != "")
                    {
                        model.QySuoDeShui = decimal.Parse(dt.Rows[n]["QySuoDeShui"].ToString());
                    }
                    if (dt.Rows[n]["YinHuaShui"].ToString() != "")
                    {
                        model.YinHuaShui = decimal.Parse(dt.Rows[n]["YinHuaShui"].ToString());
                    }
                    if (dt.Rows[n]["GrSuoDeShui"].ToString() != "")
                    {
                        model.GrSuoDeShui = decimal.Parse(dt.Rows[n]["GrSuoDeShui"].ToString());
                    }
                    model.ProjectManager = dt.Rows[n]["ProjectManager"].ToString();
                    if (dt.Rows[n]["BaoZhenJin"].ToString() != "")
                    {
                        model.BaoZhenJin = decimal.Parse(dt.Rows[n]["BaoZhenJin"].ToString());
                    }
                    if (dt.Rows[n]["ZhiBaoJin"].ToString() != "")
                    {
                        model.ZhiBaoJin = decimal.Parse(dt.Rows[n]["ZhiBaoJin"].ToString());
                    }
                    if (dt.Rows[n]["GuangLiFei"].ToString() != "")
                    {
                        model.GuangLiFei = decimal.Parse(dt.Rows[n]["GuangLiFei"].ToString());
                    }
                    if (dt.Rows[n]["LiXi"].ToString() != "")
                    {
                        model.LiXi = decimal.Parse(dt.Rows[n]["LiXi"].ToString());
                    }
                    if (dt.Rows[n]["QTKuan"].ToString() != "")
                    {
                        model.QTKuan = decimal.Parse(dt.Rows[n]["QTKuan"].ToString());
                    }
                    if (dt.Rows[n]["FPAmount"].ToString() != "")
                    {
                        model.FPAmount = decimal.Parse(dt.Rows[n]["FPAmount"].ToString());
                    }
                    if (dt.Rows[n]["FPShuiKuan"].ToString() != "")
                    {
                        model.FPShuiKuan = decimal.Parse(dt.Rows[n]["FPShuiKuan"].ToString());
                    }
                    if (dt.Rows[n]["SJAmount"].ToString() != "")
                    {
                        model.SJAmount = decimal.Parse(dt.Rows[n]["SJAmount"].ToString());
                    }
                    if (dt.Rows[n]["HGSKuan"].ToString() != "")
                    {
                        model.HGSKuan = decimal.Parse(dt.Rows[n]["HGSKuan"].ToString());
                    }
                    if (dt.Rows[n]["DDYHCunKuan"].ToString() != "")
                    {
                        model.DDYHCunKuan = decimal.Parse(dt.Rows[n]["DDYHCunKuan"].ToString());
                    }
                    model.Tel = dt.Rows[n]["Tel"].ToString();
                    if (dt.Rows[n]["Type"].ToString() != "")
                    {
                        model.Type = int.Parse(dt.Rows[n]["Type"].ToString());
                    }
                    model.BankName = dt.Rows[n]["BankName"].ToString();
                    model.Account = dt.Rows[n]["Account"].ToString();
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
                    if (dt.Rows[n]["Fid"].ToString() != "")
                    {
                        model.Fid = int.Parse(dt.Rows[n]["Fid"].ToString());
                    }
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    if (dt.Rows[n]["IfCompleted"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IfCompleted"].ToString() == "1") || (dt.Rows[n]["IfCompleted"].ToString().ToLower() == "true"))
                        {
                            model.IfCompleted = true;
                        }
                        else
                        {
                            model.IfCompleted = false;
                        }
                    }
                    model.ProjectCategory = dt.Rows[n]["ProjectCategory"].ToString();
                    model.SigningDate = dt.Rows[n]["SigningDate"].ToString();
                    if (dt.Rows[n]["ContractAmount"].ToString() != "")
                    {
                        model.ContractAmount = decimal.Parse(dt.Rows[n]["ContractAmount"].ToString());
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