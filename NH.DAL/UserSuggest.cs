using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// UserSuggest
	/// </summary>
	public static partial class UserSuggest
    {
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataSet GetList(int PageSize, int PageIndex, string strWhere, string sort)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.NVarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 500),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@key", SqlDbType.NVarChar),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@sort", SqlDbType.NVarChar,50),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    };
            parameters[0].Value = "UserSuggest s(nolock)";
            parameters[1].Value = "*";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = "Id";
            parameters[5].Value = strWhere;
            parameters[6].Value = sort;
            parameters[7].Value = 1;
            return SqlHelper.RunProcedure("UP_GetList", parameters, "ds");
        }
	}
}



