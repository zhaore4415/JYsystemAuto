using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// Xian
	/// </summary>
	public static partial class Xian
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
            //parameters[0].Value = "Xian  ";
            parameters[0].Value = " [Shen],[Shi],[Xian] ";
            //select Shen.*,Xian.f from Shen inner join Shi on Shen.fk_id = Shi.fk_id inner join Shi.sk_id = Shi.sk_id

            parameters[1].Value = "Shen.fk_id,Shi.sk_id,Xian.tk_id,Xian.third_kind_name,Shi.second_kind_name,Shen.first_kind_name";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = "Xian.sk_id";
            parameters[5].Value = " and [Shen].fk_id=[Shi].fk_id and [Shi].sk_id=[Xian].sk_id ";
            parameters[6].Value = sort;
            parameters[7].Value = 1;
            return SqlHelper.RunProcedure("UP_GetList", parameters, "ds");
        }

      
	}
}



