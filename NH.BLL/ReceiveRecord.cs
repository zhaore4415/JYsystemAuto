using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// ReceiveRecord
    /// </summary>
    public partial class ReceiveRecord
    {
        public static int AddAndUpdateCount(Model.ReceiveRecord model)
        {
            int id= Add(model);
            Model.Company company = new Model.Company();
            company.Id = model.CompanyId;
            company.CurSignUp = 0;
            BLL.Company.Update(company);

            return id;
        }

        /// <summary>
        /// 
        /// </summary>
        public static DataTable GetLastRecord(int companyId)
        {
            return DAL.ReceiveRecord.GetLastRecord(companyId);
        }
        /// <summary>
        /// 更新报名记录数
        /// </summary>
        /// <param name="company"></param>
        public static void AddSignUpCount(int company)
        {
            DAL.ReceiveRecord.AddSignUpCount(company);
        }


        public static int GetMaxTimes(int CompanyId)
        {
            return DAL.ReceiveRecord.GetMaxTimes(CompanyId);
        }


        public static DataSet GetCalendarJobs(int pageindex,int pagesize)
        {
            return DAL.ReceiveRecord.GetCalendarJobs(pageindex,pagesize);
        }
    }
}