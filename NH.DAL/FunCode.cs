using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// FunCode
    /// </summary>
    public static partial class FunCode
    {

        public static DataTable GetListWithRoleId(int roleId)
        {
            string strSql = "select fc.*,rf.RoleId from FunCode fc(nolock) left join RoleFun rf(nolock) on fc.Id=rf.FunId and RoleId=" + roleId;
            return SqlHelper.ExecuteDataTable(strSql, null);
        }

    }
}



