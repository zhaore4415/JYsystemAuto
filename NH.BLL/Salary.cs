using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// Salary
	/// </summary>
	public partial class Salary
    {
        public static string BuildOptions(string selectedId)
        {
            string options = "<option value=\"{0}\"{1}>{2}</option>";
            StringBuilder sb = new StringBuilder();
            DataTable dt = GetListByCache();
            foreach (DataRow row in dt.Rows)
            {
                sb.Append(string.Format(options, row["Id"].ToString(), GetSelectd(row["Id"].ToString(), selectedId), row["SalaryName"].ToString()));
            }
            return sb.ToString();
        }

        private static string GetSelectd(string id, string selectedId)
        {
            if (id == selectedId)
            {
                return " selected=\"selected\"";
            }
            else
            {
                return "";
            }
        }

        public static DataTable GetListByCache()
        {
            string cacheKey = "Salary";
            object obj = DataCache.GetCache(cacheKey);
            if (obj == null)
            {
                obj = DAL.Salary.GetList(0, "", "sort").Tables[0];
                DataCache.SetCacheByDependency(cacheKey, obj);
            }
            return (DataTable)obj;
        }
	}
}