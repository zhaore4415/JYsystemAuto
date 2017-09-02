using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// OnLineService
    /// </summary>
    public static partial class OnLineService
    {
        public static int GetMaxSort()
        {
            string strSql = "select ISNULL(MAX(sort)+1,1) from OnLineService(nolock)";
            return (int)SqlHelper.ExecuteScalar(strSql, null);
        }
    }
}



