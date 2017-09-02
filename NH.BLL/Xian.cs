using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.Data.SqlClient;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using NH.Model;

namespace NH.BLL 
{
	/// <summary>
	/// Xian
	/// </summary>
	public partial class Xian
	{
     

        public static DataSet GetList(int PageSize, int PageIndex, string strWhere, string sort)
        {
            return DAL.Xian.GetList(PageSize, PageIndex, strWhere, sort);
        }

    }
}