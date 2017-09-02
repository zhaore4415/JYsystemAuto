using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// SearchKey
    /// </summary>
    public static partial class SearchKey
    {
        public static int GetMaxSort(int type)
        {
            string strSql = "select ISNULL(MAX(sort)+1,1) from SearchKey(nolock) where Type=" + type;
            return (int)SqlHelper.ExecuteScalar(strSql, null);
        }
    }
}



