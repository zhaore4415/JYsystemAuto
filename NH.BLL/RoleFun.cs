using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// RoleFun
	/// </summary>
	public partial class RoleFun
	{

        /// <summary>
        /// 根据RoleId删除功能码
        /// </summary>
        public static bool DeleteByRoleId(int roleId)
        {
            return DAL.RoleFun.DeleteByRoleId(roleId);
        }
        
        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static DataTable GetRoleFunByRoleId(int roleId)
        {
            return DAL.RoleFun.GetRoleFunByRoleId(roleId);
        }

	}
}