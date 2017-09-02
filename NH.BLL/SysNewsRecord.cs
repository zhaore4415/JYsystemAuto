using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.Data.SqlClient;
using Maticsoft.Common;
using NH.Model;

namespace NH.BLL 
{
	/// <summary>
	/// Article
	/// </summary>
	public partial class SysNewsRecord
	{
        public static DataSet GetList(int PageSize, int PageIndex, string strWhere, string sort, bool isReCount)
        {
            return DAL.SysNewsRecord.GetList(PageSize, PageIndex, strWhere, sort,isReCount);
        }
        
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist, int userId)
        {
            return DAL.SysNewsRecord.DeleteList(Idlist, userId);
        }


        public static bool AddForNewUser(int userId, int userType)
        {
            return DAL.SysNewsRecord.AddForNewUser(userId, userType);
        }
	}
}