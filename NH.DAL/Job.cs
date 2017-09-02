using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// Job
	/// </summary>
	public static partial class Job
    {
        /// <summary>
        /// 获取职位信息
        /// </summary>
        /// <param name="jobid"></param>
        /// <returns></returns>
        public static DataSet GetJobInfo(int jobid)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@jobid",SqlDbType.Int)
                                        };
            parameters[0].Value = jobid;

            return SqlHelper.RunProcedure("GetJobInfo", parameters, "ds");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataSet GetList(int PageSize, int PageIndex, string strWhere, string sort)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.NVarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 500),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@key", SqlDbType.NVarChar),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@sort", SqlDbType.NVarChar,50),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    };
            parameters[0].Value = "Job j(nolock) left join JobCategory jc(nolock) on j.CategoryNo=jc.CategoryNo";
            parameters[1].Value = "j.Id,j.CategoryNo,j.Status,j.ViewCount,j.UpdateTime,j.RefreshTime,j.Verified,jc.Name JobCategoryName";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = "j.Id";
            parameters[5].Value = strWhere;
            parameters[6].Value = sort;
            parameters[7].Value = 1;
            return SqlHelper.RunProcedure("UP_GetList", parameters, "ds");
        }

        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist,int companyId)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("delete from [Job] ");
            strSql.Append("update [Job] set Status = -1");//逻辑删除
            strSql.Append(" where ID in (" + Idlist + ") and CompanyID=" + companyId.ToString());
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
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
            string strSql = "update Job set IsFix=1 where Id=" + jobId.ToString() + " and CompanyID=" + companyId.ToString();
            return SqlHelper.ExecuteNonQuery(strSql) > 0;
        }

        /// <summary>
        /// 取消套红
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public static bool SetUnFix(int companyId, int jobId)
        {
            string strSql = "update Job set IsFix=0 where Id=" + jobId.ToString() + " and CompanyID=" + companyId.ToString();
            return SqlHelper.ExecuteNonQuery(strSql) > 0;
        }

        /// <summary>
        /// 获取已套红的职位数量
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public static int GetFixedCount(int companyId)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@CompanyID",companyId)
                                        };
            parameters[0].Value = companyId;
            string sql = "select count(Id) from Job(nolock) where Status<>-1 and IsFix=1 and CompanyID=@CompanyID";
            return (int)SqlHelper.ExecuteScalar(sql, parameters);
        }

        /// <summary>
        /// 审核资料
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="status"></param>
        public static void VerifyNewInfo(int jobId, int status)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@JobId",jobId),
                                        new SqlParameter("@Status",status)
                                        };

            SqlHelper.RunProcedure("Verify_JobNewInfo", parameters, "ds");
        }

        ///// <summary>
        ///// 获取企业职位
        ///// </summary>
        ///// <param name="companyId"></param>
        ///// <returns></returns>
        //public static DataTable GetCompanyJobs(int companyId)
        //{
        //    string strSql = "select j.*,jc.Name as JobCategoryName from Job j(nolock) join JobCategory jc(nolock) on jc.Id=j.CategoryID where Verified=1 and j.[Status]=1 and CompanyID = @companyid";
        //    SqlParameter[] parameters = {
        //                                new SqlParameter("@companyid",SqlDbType.Int)
        //                                };
        //    parameters[0].Value = companyId;
        //    return SqlHelper.ExecuteDataTable(strSql, parameters);
        //}

        ///// <summary>
        ///// 获取今天已发布的职位数量
        ///// </summary>
        ///// <param name="companyId"></param>
        ///// <returns></returns>
        //public static int GetTodayJobCount(int companyId)
        //{
        //    string strSql = "select COUNT(Id) as TodayCount from Job j(nolock) where CompanyID=@CompanyID and DATEDIFF(day,AddTime,getdate())=0";
        //    SqlParameter[] parameters = {
        //                                new SqlParameter("@CompanyID",companyId)
        //                                };
        //    return (int)SqlHelper.ExecuteScalar(strSql,parameters);
        //}

        /// <summary>
        /// 获取已发内存卡的职位数量
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public static int GetPublishedJobCount(int companyId)
        {
            string strSql = "select COUNT(Id) as PublishedJobCount from Job j(nolock) where CompanyID=@CompanyID and Status<>-1";
            SqlParameter[] parameters = {
                                        new SqlParameter("@CompanyID",companyId)
                                        };
            return (int)SqlHelper.ExecuteScalar(strSql, parameters);
        }

        /// <summary>
        /// 获取上一个、下一个
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetPreNext(int jobId,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("declare @jobid int");
            strSql.Append(";set @jobid =" + jobId);
            strSql.Append(";declare @tb table(rowid int,jobid int)");
            strSql.Append(";insert into @tb ");
            strSql.Append("select ROW_NUMBER() over (order by (case c.LevelID when 1 then 0 else (case when DATEDIFF(day,getdate(),c.ExpireDate) >=0 then 1 else 0 end) end) desc,j.RefreshTime desc) as rowid,j.Id ");
            strSql.Append("from [Job] j(nolock) join JobCategory jc(nolock) on j.CategoryNo=jc.CategoryNo join Company c(nolock) on j.CompanyId=c.Id join [User] u(nolock) on u.Id=c.Id ");
            if (!string.IsNullOrEmpty(strWhere))
                strSql.Append("where " + strWhere);

            strSql.Append(";select top 1 jobid from @tb where rowid < (select rowid from @tb where jobid=@jobid) order by rowid desc");//上一个
            strSql.Append(";select top 1 jobid from @tb where rowid > (select rowid from @tb where jobid=@jobid)");//下一个

            return SqlHelper.ExecuteDataSet(strSql.ToString(),null);
        }

        public static DataTable GetAutoRefresh()
        {
            string strSql = "select id,RefreshTime from job(nolock) where RefreshTime > '" + DateTime.Now.AddHours(-1) + "'";
            return SqlHelper.ExecuteDataSet(strSql,null).Tables[0];
        }

        public static void UpdateViewcount(int id)
        {
            Random ran = new Random();
            string sql = "update Job set ViewCount=ViewCount+" + ran.Next(3, 6) + " where Id=" + id.ToString();
            SqlHelper.ExecuteNonQuery(sql);

            //test
            //DAL.a.Add(new Model.a() { addtime=DateTime.Now,content=sql});
        }
	}
}



