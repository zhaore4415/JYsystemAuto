using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Degree
    /// </summary>
    public partial class Degree
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedId">已选择的值</param>
        /// <param name="showNolimit">是否显示【不限】</param>
        /// <returns></returns>
        public static string BuildOptions(string selectedId,bool showNolimit)
        {
            string options = "<option value=\"{0}\"{1}>{2}</option>";
            StringBuilder sb = new StringBuilder();
            DataTable dt = GetListByCache();
            foreach (DataRow row in dt.Rows)
            {
                if ((int)row["Id"] == 0 && !showNolimit) continue;//不显示【不限】
                sb.Append(string.Format(options, row["Id"].ToString(), GetSelectd(row["Id"].ToString(), selectedId), row["DegreeName"].ToString()));
            }
            return sb.ToString();
        }

        private static string GetSelectd(string id, string selectedId)
        {
            if (!string.IsNullOrEmpty(selectedId) && selectedId.Contains("," + id + ","))
            //if (id == selectedId)
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
            string cacheKey = "Degree";
            object obj = DataCache.GetCache(cacheKey);
            if (obj == null)
            {
                obj = DAL.Degree.GetList(0, "", "sort").Tables[0];
                DataCache.SetCache(cacheKey, obj);
            }
            return (DataTable)obj;
        }
    }
}