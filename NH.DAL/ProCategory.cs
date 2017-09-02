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
    public static partial class ProCategory
    {
        public static int GetMaxSort()
        {
            return (int)SqlHelper.ExecuteScalar("SELECT isnull(max(sort),0)+1 from ProCategory");
        }

        public static int DeleteSubCategory(int id)
        {
            string sql = "delete from ProCategory where Path like '%," + id.ToString() + ",%'";
            return (int)SqlHelper.ExecuteNonQuery(sql);
        }

        public static int UpdateParentChildCount(string parentId)
        {
            int count = (int)SqlHelper.ExecuteScalar("select count(Id) from ProCategory where Path like '%," + parentId.Replace("'", "''") + ",'");
            string sql = "update ProCategory set Child=" + count.ToString() + " where id=" + parentId.Replace("'", "''");
            return (int)SqlHelper.ExecuteNonQuery(sql);
        }

   
    }
}



