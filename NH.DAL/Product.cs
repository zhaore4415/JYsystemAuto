using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Product
    {
        public static DataTable GetPrev(int id)
        {
            string sql = "select top 1 * from Product where Id < " + id.ToString() + " order by Id desc";
            return SqlHelper.ExecuteDataTable(sql, null);
        }

        public static DataTable GetNext(int id)
        {
            string sql = "select top 1 * from Product where Id > " + id.ToString() + " order by Id asc"; ;
            return SqlHelper.ExecuteDataTable(sql, null);
        }

     
    }
}



