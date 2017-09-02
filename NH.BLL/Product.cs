using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// Product
	/// </summary>
	public partial class Product
    {
        public static DataTable GetPrev(int id)
        {
            return DAL.Product.GetPrev(id);
        }

        public static DataTable GetNext(int id)
        {
            return DAL.Product.GetNext(id);
        }

     
	}
}