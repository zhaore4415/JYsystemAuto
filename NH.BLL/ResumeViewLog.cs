using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// ResumeViewLog
	/// </summary>
	public partial class ResumeViewLog
	{
        public static DataSet GetList(int PageSize, int PageIndex, string strWhere, string sort)
        {
            return DAL.ResumeViewLog.GetList(PageSize, PageIndex, strWhere, sort);
        }
	}
}