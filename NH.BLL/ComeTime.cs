using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// ComeTime
    /// </summary>
    public partial class ComeTime
    {
        public static string BuildOptions(string selectedId)
        {
            string options = "<option value=\"{0}\"{1}>{2}</option>";
            StringBuilder sb = new StringBuilder();
            DataTable dt = GetListByCache();
            foreach (DataRow row in dt.Rows)
            {
                sb.Append(string.Format(options, row["Id"].ToString(), GetSelectd(row["Id"].ToString(), selectedId), row["Name"].ToString()));
            }
            return sb.ToString();
        }

        private static string GetSelectd(string id, string selectedId)
        {
            //if (id == selectedId)
            if (selectedId.Contains("," + id + ","))
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
            string cacheKey = "ComeTime";
            object obj = DataCache.GetCache(cacheKey);
            if (obj == null)
            {
                obj = DAL.ComeTime.GetList(0, "", "sort").Tables[0];
                DataCache.SetCacheByDependency(cacheKey, obj);
            }
            return (DataTable)obj;
        }
    }
}