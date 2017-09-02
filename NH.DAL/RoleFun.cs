using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// RoleFun
	/// </summary>
	public static partial class RoleFun
	{

        /// <summary>
        /// 根据RoleId删除功能码
        /// </summary>
        public static bool DeleteByRoleId(int roleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [RoleFun] ");
            strSql.Append(" where RoleId =" + roleId);
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }

        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static DataTable GetRoleFunByRoleId(int roleId)
        {
            SqlParameter[] parameters = { 
                                      new SqlParameter("@RoleId",roleId)
                                      };
            string strSql = "select * from RoleFun rf(nolock) join FunCode fc(nolock) on rf.FunId=fc.Id where rf.RoleId=@RoleId";
            return SqlHelper.ExecuteDataTable(strSql, parameters);
        }
	}
}



