using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// UserRemark
    /// </summary>
    public partial class UserRemark
    {
        public static bool Delete(int companyId, int memberId, int remarkTypeId)
        {
            return DAL.UserRemark.Delete(companyId, memberId, remarkTypeId);
        }
        public static DataTable GetRemark(int companyId, int memberid)
        {
            return DAL.UserRemark.GetRemark(companyId,memberid);
        }
    }
}