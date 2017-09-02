using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.Data.SqlClient;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using NH.Model;

namespace NH.BLL 
{
	/// <summary>
	/// Accounting
	/// </summary>
	public partial class Accounting
	{
        public static int GetMaxSort()
        {
            return DAL.Accounting.GetMaxSort();
        }
        //某一项目值的和
        public static decimal GetSum(string name)
        {
            return DAL.Accounting.GetSum(name);
        }
        //最大值
        public static DataTable GetMaxAdd(string name)
        {

            return DAL.Accounting.GetMaxAdd(name);
        }
        //最大值
        public static DataTable GetMaxModify(int id, int fid)
        {

            return DAL.Accounting.GetMaxModify(id, fid);
        }
        //最小值
        public static DataTable GetMinModify(int fid)
        {

            return DAL.Accounting.GetMinModify( fid);
        }
        //上一条
        public static DataTable GetPrev(int fid, string name)
        {

            return DAL.Accounting.GetPrev(fid, name);
        }
        //下一条
        public static DataTable GetNext(int id, int fid)
        {
            return DAL.Accounting.GetNext(id, fid);
        }

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top,string tablename, string strWhere, string filedOrder)
        {
            return DAL.Accounting.GetList(Top,tablename, strWhere, filedOrder);
        }

        #region 更新该项目经理所有的项目经理余额为最新的统一的值
        /// <summary>
        ///更新该项目经理所有的项目经理余额为最新的统一的值
        /// </summary>
        public static bool UpdateAll(decimal BalanceManager, string name)
        {
            return DAL.Accounting.UpdateAll(BalanceManager,name);
        }
        #endregion
        #endregion
    }
}