using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// UserSuggest
	/// </summary>
	public partial class UserSuggest
    {
        public static DataSet GetList(int PageSize, int PageIndex, string strWhere, string sort)
        {
            return DAL.UserSuggest.GetList(PageSize, PageIndex, strWhere, sort);
        }
	}
}