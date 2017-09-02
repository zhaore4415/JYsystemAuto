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
    public static partial class Sector
    {
        public static int GetMaxSort()
        {
            return (int)SqlHelper.ExecuteScalar("SELECT isnull(max(sort),0)+1 from Sector");
        }

        public static int DeleteSubCategory(int id)
        {
            string sql = "delete from Sector where Path like '%," + id.ToString() + ",%'";
            return (int)SqlHelper.ExecuteNonQuery(sql);
        }

        public static int DeleteTruncate()
        { string sql = "delete from Sector"; return (int)SqlHelper.ExecuteNonQuery(sql); }

        public static int UpdateParentChildCount(string parentId)
        {
            int count = (int)SqlHelper.ExecuteScalar("select count(Id) from Sector where Path like '%," + parentId.Replace("'", "''") + ",'");
            string sql = "update Sector set Child=" + count.ToString() + " where id=" + parentId.Replace("'", "''");
            return (int)SqlHelper.ExecuteNonQuery(sql);
        }
    }
}



