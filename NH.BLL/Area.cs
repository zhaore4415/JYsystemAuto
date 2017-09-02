using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using NH.Model;
namespace NH.BLL
{
    /// <summary>
    /// Area
    /// </summary>
    public partial class Area
    {
        #region 从缓存获得数据列表
        /// <summary>
        /// 从缓存获得数据列表
        /// </summary>
        public static DataTable GetListByCache(string strWhere)
        {
            string CacheKey = "Area";
            object obj = DataCache.GetCache(CacheKey);
            if (obj == null)
            {
                obj = DAL.Area.GetListBySort("");//获取所有放入缓存
                DataCache.SetCacheByDependency(CacheKey, obj);
            }
            DataSet ds = (DataSet)obj;
            DataRow[] rows = ds.Tables[0].Select(strWhere,"DlgSort");
            DataTable dt = ds.Tables[0].Clone();
            foreach (DataRow row in rows)
            {
                dt.Rows.Add(row.ItemArray);
            }
            return dt;
        }
        #endregion

        public static string BuildFullAreaOption(string selectedNos)
        {
            StringBuilder sb = new StringBuilder();
            string option = "<option value=\"{0}\"{1}>{2}</option>";
            DataTable dtProvince = BLL.Area.GetListByCache("ParentNo=1");
            foreach (DataRow row1 in dtProvince.Rows)
            {
                if ((int)row1["Child"] > 0)
                {
                    sb.Append("<optgroup label=\"" + row1["Name"].ToString() + "\">");
                    sb.Append(string.Format(option, row1["AreaNo"].ToString(), GetSelected(selectedNos, row1["AreaNo"].ToString()), row1["Name"].ToString()));
                    DataTable dtCity = BLL.Area.GetListByCache("ParentNo='" + row1["AreaNo"].ToString() + "'");
                    foreach (DataRow row2 in dtCity.Rows)
                    {
                        sb.Append(string.Format(option, row2["AreaNo"].ToString(), GetSelected(selectedNos, row2["AreaNo"].ToString()), row2["Name"].ToString()));
                    }
                    sb.Append("</optgroup>");
                }
                else
                {
                    sb.Append(string.Format(option, row1["AreaNo"].ToString(), GetSelected(selectedNos, row1["AreaNo"].ToString()), row1["Name"].ToString()));
                }
            }
            return sb.ToString();
        }

        public static string BuildOption(string strWhere, string selectedNos)
        {
            selectedNos = "," + selectedNos + ",";
            string option = "<option value=\"{0}\"{1}>{2}</option>";
            StringBuilder sb = new StringBuilder();
            DataTable dtProvince = BLL.Area.GetListByCache(strWhere);
            foreach (DataRow row1 in dtProvince.Rows)
            {
                sb.Append(string.Format(option, row1["AreaNo"].ToString(), GetSelected(selectedNos, row1["AreaNo"].ToString()), row1["Name"].ToString()));
            }
            return sb.ToString();
        }

        private static string GetSelected(string selectedNos, string areaNo)
        {
            if (selectedNos.Contains("," + areaNo + ","))
            {
                return " selected=\"selected\"";
            }
            else
            {
                return "";
            }
        }

        public static string BuildJsObject()
        {
            string cacheKey = "AreaJsObject";
            object obj = DataCache.GetCache(cacheKey);
            if(obj == null)
            {
                StringBuilder sb = new StringBuilder();
                DataTable dtProvince = BLL.Area.GetListByCache("ParentNo=1");
                sb.Append("{");
                foreach (DataRow row1 in dtProvince.Rows)
                {
                    sb.Append("\"" + row1["AreaNo"].ToString() + "\":");
                    sb.Append("{");
                    DataTable dtCity = BLL.Area.GetListByCache("ParentNo='" + row1["AreaNo"].ToString() + "'");
                    //List<string> subareas = new List<string>();
                    StringBuilder subareas = new StringBuilder();
                    foreach (DataRow row2 in dtCity.Rows)
                    {
                        //subareas.Add("\"" + row2["AreaNo"].ToString() + "\":\"" + row2["Name"].ToString() + "\"");
                        subareas.Append("\"" + row2["AreaNo"].ToString() + "\":\"" + row2["Name"].ToString() + "\",");
                    }
                    if (subareas.Length > 0)
                    {
                        sb.Append(subareas.ToString().TrimEnd(','));
                    }
                    //sb.Append(string.Join(",",subareas));
                    sb.Append("},");
                }
                if (sb.Length > 1)
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                sb.Append("}");
                obj = sb;
                DataCache.SetCache(cacheKey, obj);
            }

            return obj.ToString();
        }
    }
}