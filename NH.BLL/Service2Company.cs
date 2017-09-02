using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// Service2Company
	/// </summary>
	public partial class Service2Company
	{
        public static bool DeleteByWhere(string strWhere)
        {
            return DAL.Service2Company.DeleteByWhere(strWhere);
        }
	}
}