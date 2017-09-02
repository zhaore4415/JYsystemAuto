using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// AUser
	/// </summary>
	public static partial class AUser
	{
        public static int GetMaxSort()
        {
            return (int)SqlHelper.ExecuteScalar("SELECT isnull(max(SerialNumber),0)+1 from AUser");
        }
		/// <summary>
		/// 获取用户拥有的权限
		/// </summary>
		public static DataTable GetUserFunCode(int userId)
		{
            SqlParameter[] parameters = { 
                                        new SqlParameter("@UserId",userId)
                                        };
            string strSql = "select fc.Code,fc.FunType from UserRole ur(nolock) join RoleFun rf(nolock) on ur.RoleId=rf.RoleId join FunCode fc(nolock) on rf.FunId=fc.Id where ur.UserId=@UserId";
            return SqlHelper.ExecuteDataTable(strSql,parameters);
		}
	
	}
}



