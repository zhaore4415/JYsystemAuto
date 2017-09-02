using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace NH.DAL
{
    public static partial class Common
    {

        public static DataSet GetAdminDefaultMsg()
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@t1",DateTime.Now.ToString("yyyy-MM-dd")),
                                        new SqlParameter("@t2",DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"))
                                        };
            string strSql = "select count(u.Id) from [User] u(nolock) where u.UserType=1 and u.AddTime > @t1 and u.AddTime < @t2;";
            strSql += "select count(u.Id) from [User] u(nolock) where u.UserType=2 and u.AddTime > @t1 and u.AddTime < @t2;";
            return (DataSet)SqlHelper.ExecuteDataSet(strSql, parameters); 
        }
    }
}
