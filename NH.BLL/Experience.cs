using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL 
{
	/// <summary>
	/// Experience
	/// </summary>
	public partial class Experience
	{
        public static string BuildOptions(string selectedId, bool showNolimit)
        {
            string options = "<option value=\"{0}\"{1}>{2}</option>";
            StringBuilder sb = new StringBuilder();
            DataTable dt = GetListByCache();
            foreach (DataRow row in dt.Rows)
            {
                if ((int)row["Id"] == 1 && !showNolimit) continue;//不显示【不限】
                sb.Append(string.Format(options,row["Id"].ToString(),GetSelectd(row["Id"].ToString(),selectedId),row["Name"].ToString()));
            }
            return sb.ToString();
        }

        private static string GetSelectd(string id, string selectedId)
        {
            //if (id == selectedId)
            if(selectedId.Contains("," + id + ","))
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
            string cacheKey = "Experience";
            object obj = DataCache.GetCache(cacheKey);
            if (obj == null)
            {
                obj = DAL.Experience.GetList(0, "Status=1", "sort").Tables[0];
                DataCache.SetCacheByDependency(cacheKey, obj);
            }
            return (DataTable)obj;
        }
	}
}