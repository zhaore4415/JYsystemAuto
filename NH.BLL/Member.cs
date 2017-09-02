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
        /// <summary>
        /// 获取求职者信息
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public static DataSet GetPersonInfo(int memberId)
        {
            return DAL.Member.GetPersonInfo(memberId);
        }

        /// <summary>
        /// 分页获取数据列表(后台)
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public static DataSet GetList(int PageSize, int PageIndex, string strWhere, string sort)
        {
            return DAL.Member.GetList(PageSize, PageIndex, strWhere, sort);
        }

        public static DataSet GetMemberMsg(int memberId)
        {
            return DAL.Member.GetMemberMsg(memberId);
        }

        public static DataSet GetMemberPopMsg(int memberId)
        {
            return DAL.Member.GetMemberPopMsg(memberId);
        }

        public static void UpdateWorksCount(int memberId)
        {
            DAL.Member.UpdateWorksCount(memberId);
        }
        public static void UpdateViewCount(int memberId)
        {
            DAL.Member.UpdateViewCount(memberId);
        }

        /// <summary>
        /// 更新简历完善度
        /// </summary>
        /// <param name="memberId"></param>
        public static void UpdateComplete(int memberId)
        {
            DAL.Member.UpdateComplete(memberId);
        }

        
        /// <summary>
        /// 获取面试通知数量
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public static int GetInterviewCount(int memberId)
        {
            return DAL.Member.GetInterviewCount(memberId);
        }


        /// <summary>
        /// 更新是否需要审核的标识
        /// </summary>
        /// <param name="memberId"></param>
        public static bool UpdateMemberIsVerify(int memberId)
        {
            return DAL.Member.UpdateMemberIsVerify(memberId);
        }


        /// <summary>
        /// 获取待审核的人才数量
        /// </summary>
        /// <returns></returns>
        public static int GetVerifyCount()
        {
            return DAL.Member.GetVerifyCount();
        }

        
        /// <summary>
        /// 获取上一个、下一个
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetPreNext(int mid, string strWhere)
        {
            return DAL.Member.GetPreNext(mid, strWhere);
        }


        /// <summary>
        /// 获取首页人才
        /// </summary>
        /// <param name="memberId"></param>
        public static DataSet GetHomePerson()
        {
            return DAL.Member.GetHomePerson();
        }
        public static void AutoAddViewCount()
        {
            DataTable dt = DAL.Member.GetAutoRefresh();
            foreach (DataRow row in dt.Rows)
            {
                DAL.Member.UpdateViewcount((int)row["Id"]);
                //sb.Append("update Job set ViewCount=ViewCount+" + ran.Next(3,5) + ";");
            }

        }
	}
}