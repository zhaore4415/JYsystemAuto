using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// UserRole
	/// </summary>
	public static partial class UserRole
	{
		#region 批量删除一批数据
		/// <summary>
		/// 根据用户删除数据
        /// </summary>
        public static bool DeleteByUserId(int userId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [UserRole] ");
			strSql.Append(" where UserId = " + userId);
			return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
		}
		#endregion
	}
}



