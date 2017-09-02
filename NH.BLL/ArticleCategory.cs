using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// ArticleCategory
	/// </summary>
	public partial class ArticleCategory
	{
        public static int GetMaxSort(int type)
        {
            return DAL.ArticleCategory.GetMaxSort(type);
        }

        public static DataSet GetList(int PageSize, int PageIndex, string strWhere, string sort)
        {
            return DAL.ArticleCategory.GetList(PageSize, PageIndex, strWhere, sort);
        }
	}
}