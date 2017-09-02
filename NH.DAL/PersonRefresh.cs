using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// PersonRefresh
	/// </summary>
	public static partial class PersonRefresh
    {
        public static int GetRefreshCount(int memberID)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@MemberID",SqlDbType.Int)
                                        };
            parameters[0].Value = memberID;

            string strSql = "select count(*) from PersonRefresh(nolock) where MemberID=@MemberID and DATEDIFF(DAY,RefreshTime,getdate())=0";

            return (int)SqlHelper.ExecuteScalar(strSql, parameters);
        }
	}
}



