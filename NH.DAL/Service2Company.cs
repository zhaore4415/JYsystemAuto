using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// Service2Company
	/// </summary>
	public static partial class Service2Company
	{
		#region 批量删除一批数据
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public static bool DeleteByWhere(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [Service2Company] ");
			strSql.Append(" where " + strWhere);
			return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
		}
		#endregion
				
	}
}



