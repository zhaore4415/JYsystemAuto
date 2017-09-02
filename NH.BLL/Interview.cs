using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// Interview
	/// </summary>
	public partial class Interview
    {
        public static DataSet GetList(int PageSize, int PageIndex, string strWhere, string sort)
        {
            return DAL.Interview.GetList(PageSize, PageIndex, strWhere, sort);
        }

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteListByCompany(string Idlist, int companyID)
        {
            return DAL.Interview.DeleteListByCompany(Idlist,companyID);
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteListByMember(string Idlist, int memberID)
        {
            return DAL.Interview.DeleteListByMember(Idlist, memberID);
        }
        #endregion


        public static DataSet GetCountByMemberId(int memberId)
        {
            return DAL.Interview.GetCountByMemberId(memberId);
        }

        
        /// <summary>
        /// 获取新面试通知数量
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public static int GetNoReadCountByMemberId(int memberId)
        {
            return DAL.Interview.GetNoReadCountByMemberId(memberId);
        }
	}
}