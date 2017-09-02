using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// Ad
    /// </summary>
    public static partial class Ad
    {
        public static int GetMaxSort(int typeId)
        {
            string strSql = "select ISNULL(MAX(sort)+1,1) from Ad(nolock) where AdType=" + typeId.ToString();
            return (int)SqlHelper.ExecuteScalar(strSql, null);
        }
    }
}



