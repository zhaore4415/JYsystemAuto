using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// PersonRefresh
	/// </summary>
	public partial class PersonRefresh
    {
        public static int GetRefreshCount(int memberId)
        {
            return DAL.PersonRefresh.GetRefreshCount(memberId);
        }
	}
}