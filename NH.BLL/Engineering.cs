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
	/// Engineering
	/// </summary>
	public partial class Engineering
	{
        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteEngineering(int Fid)
        {
            return DAL.Engineering.DeleteEngineering(Fid);
        }
        #endregion
        //最大值
        public static DataTable GetMaxAdd(int fid)
        {

            return DAL.Engineering.GetMaxAdd(fid);
        }
        //最大值
        public static DataTable GetMaxModify(int id, int fid)
        {

            return DAL.Engineering.GetMaxModify(id, fid);
        }
        //最小值
        public static DataTable GetMinModify(int fid)
        {

            return DAL.Engineering.GetMinModify( fid);
        }
        //上一条
        public static DataTable GetPrev(int id, int fid)
        {

            return DAL.Engineering.GetPrev(id, fid);
        }
        //下一条
        public static DataTable GetNext(int id, int fid)
        {
            return DAL.Engineering.GetNext(id, fid);
        }

    }
}