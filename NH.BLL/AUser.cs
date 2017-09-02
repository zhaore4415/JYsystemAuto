using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// AUser
	/// </summary>
	public partial class AUser
	{

        public static int GetMaxSort()
        {
            return DAL.AUser.GetMaxSort();
        }
        /// <summary>
        /// 得到一个对象实体，包含权限
        /// </summary>
        public static NH.Model.AUser GetModelWithFunCode(NH.Model.AUser model)
        {
            model = DAL.AUser.GetModel(model);
            if (model != null)
            {
                List<Model.UserRole> userRoleList = BLL.UserRole.GetModelList("UserId=" + model.Id.ToString());
                List<string> rolesList = new List<string>();
                foreach (Model.UserRole userRole in userRoleList)
                {
                    DataTable dtRoleFun = BLL.RoleFun.GetRoleFunByRoleId(userRole.RoleId);
                    foreach (DataRow row in dtRoleFun.Rows)
                    {
                        if (!rolesList.Contains(row["Code"].ToString()))
                        {
                            rolesList.Add(row["Code"].ToString());
                        }
                    }
                }
                StringBuilder sb = new StringBuilder();
                sb.Append(",");
                foreach (string str in rolesList)
                {
                    sb.Append(str + ",");
                }
                model.FunCode = sb.ToString().ToLower();
            }
            return model;
        }

        
		/// <summary>
		/// 获取用户拥有的权限
		/// </summary>
        public static DataTable GetUserFunCode(int userId)
        {
            return DAL.AUser.GetUserFunCode(userId);
        }
	}
}