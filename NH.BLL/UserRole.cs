using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// UserRole
	/// </summary>
	public partial class UserRole
	{	
        #region 批量删除一批数据
		/// <summary>
        /// 根据用户删除数据
		/// </summary>
		public static bool DeleteByUserId(int userId)
		{
            return DAL.UserRole.DeleteByUserId(userId);
		}
		#endregion
	}
}