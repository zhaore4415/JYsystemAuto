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
        public static DataSet GetList(int PageSize, int PageIndex, string strWhere, string sort)
        {
            return DAL.Job.GetList(PageSize, PageIndex, strWhere, sort);
        }

        public static DataSet GetJobInfo(int jobid)
        {
            return DAL.Job.GetJobInfo(jobid);
        }

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist,int companyId)
        {
            return DAL.Job.DeleteList(Idlist,companyId);
        }
        #endregion

        
        /// <summary>
        /// 套红
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public static bool SetFix(int companyId, int jobId)
        {
            return DAL.Job.SetFix(companyId, jobId);
        }

        /// <summary>
        /// 取消套红
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public static bool SetUnFix(int companyId, int jobId)
        {
            return DAL.Job.SetUnFix(companyId, jobId);
        }

        /// <summary>
        /// 获取已套红的职位数量
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public static int GetFixedCount(int companyId)
        {
            return DAL.Job.GetFixedCount(companyId);
        }
        
        /// <summary>
        /// 审核资料
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="status"></param>
        public static void VerifyNewInfo(int jobId, int status)
        {
            DAL.Job.VerifyNewInfo(jobId,status);
        }

        ///// <summary>
        ///// 获取企业职位
        ///// </summary>
        ///// <param name="companyId"></param>
        ///// <returns></returns>
        //public static DataTable GetCompanyJobs(int companyId)
        //{
        //    return DAL.Job.GetCompanyJobs(companyId);
        //}

        
        ///// <summary>
        ///// 获取今天已发布的职位数量
        ///// </summary>
        ///// <param name="companyId"></param>
        ///// <returns></returns>
        //public static int GetTodayJobCount(int companyId)
        //{
        //    return DAL.Job.GetTodayJobCount(companyId);
        //}


        /// <summary>
        /// 获取已发内存卡的职位数量
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public static int GetPublishedJobCount(int companyId)
        {
            return DAL.Job.GetPublishedJobCount(companyId);
        }
        
        /// <summary>
        /// 获取上一个、下一个
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetPreNext(int jobId, string strWhere)
        {
            return DAL.Job.GetPreNext(jobId, strWhere);
        }

        public static void AutoAddViewCount()
        {
            //Maticsoft.Common.Log.Write("auto add", "");
            //Maticsoft.Common.Log.Write("auto add", "/log/");
            //BLL.a.Add(new Model.a() {  addtime=DateTime.Now, content="auto add"});


            //StringBuilder sb = new StringBuilder();
            DataTable dt = DAL.Job.GetAutoRefresh();
            foreach (DataRow row in dt.Rows)
            {
                DAL.Job.UpdateViewcount((int)row["Id"]);
                //sb.Append("update Job set ViewCount=ViewCount+" + ran.Next(3,5) + ";");
            }

        }
	}
}