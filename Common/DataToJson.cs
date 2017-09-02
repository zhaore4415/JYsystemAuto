using System;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using System.Collections.Generic;

namespace Maticsoft.Common
{
    /// <summary>
    /// DataTable转json
    /// </summary>
    public class DataToJson
    {

        public static StringBuilder DtToJson(DataTable dt)
        {
            StringBuilder json = new StringBuilder();
            json.Append("{");
            json.Append("\"total\":");
            json.Append("\"" + dt.Rows.Count.ToString() + "\",");
            json.Append("\"rows\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                json.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    json.Append("\"");
                    json.Append(dt.Columns[j].ColumnName);
                    json.Append("\":\"");
                    json.Append(dt.Rows[i][j].ToString().Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r\n", "<br/>").Replace("\n", "<br/>").Replace("\r", ""));
                    json.Append("\",");
                }
                json.Remove(json.Length - 1, 1);
                if (i == dt.Rows.Count - 1)
                {
                    json.Append("}");
                }
                else
                {
                    json.Append("},");
                }
            }
            json.Append("]");

            json.Append("}");
            dt.Dispose();
            return json;
        }

        public static StringBuilder DtToJson(DataTable dt, int totalCount)
        {
            StringBuilder json = new StringBuilder();
            json.Append("{");
            json.Append("\"total\":");
            json.Append("\"" + totalCount.ToString() + "\",");
            json.Append("\"rows\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                json.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    json.Append("\"");
                    json.Append(dt.Columns[j].ColumnName);
                    json.Append("\":\"");
                    json.Append(dt.Rows[i][j].ToString().Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r\n", "<br/>").Replace("\n", "<br/>").Replace("\r", ""));
                    json.Append("\",");
                }
                json.Remove(json.Length - 1, 1);
                if (i == dt.Rows.Count - 1)
                {
                    json.Append("}");
                }
                else
                {
                    json.Append("},");
                }
            }
            json.Append("]");

            json.Append("}");
            dt.Dispose();
            return json;
        }

        /// <summary>
        /// 转成json，不带total和rows，只有数据:[{},{},{}]
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static StringBuilder DtToJson2(DataTable dt)
        {
            StringBuilder json = new StringBuilder();
            json.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                json.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    json.Append("\"");
                    json.Append(dt.Columns[j].ColumnName);
                    json.Append("\":\"");
                    json.Append(dt.Rows[i][j].ToString().Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r\n", "<br/>").Replace("\n", "<br/>").Replace("\r", ""));
                    json.Append("\",");
                }
                json.Remove(json.Length - 1, 1);
                if (i == dt.Rows.Count - 1)
                {
                    json.Append("}");
                }
                else
                {
                    json.Append("},");
                }
            }
            json.Append("]");
            dt.Dispose();
            return json;
        }

        public static string Obj2Json<T>(T data)
        {
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(data.GetType());
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, data);
                    string str = Encoding.UTF8.GetString(ms.ToArray());
                    //str = Regex.Replace(str, @"\\/Date\((\d+)\)\\/", match =>
                    str = Regex.Replace(str, @"\\/Date\((\d+[\+]\d+)\)\\/", match =>
                    {
                        DateTime dt = new DateTime(1970, 1, 1);
                        dt = dt.AddMilliseconds(long.Parse(match.Groups[1].Value.Split('+')[0]));
                        dt = dt.ToLocalTime();
                        return dt.ToString("yyyy-MM-dd HH:mm:ss");
                    });
                    return str;
                }
            }
            catch
            {
                return null;
            }
        }


     
        #region 表格转json数据
         //<summary>
         //表格转json数据
         //</summary>
         //<param name="dt"></param>
         //<returns></returns>
        public static string ToJson(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                DataColumnCollection dcc = dt.Columns;
                string columnName = string.Empty;
                if (dcc != null && dcc.Count > 0)
                {
                    StringBuilder data = new StringBuilder();
                    data.Append("{");
                    data.Append("\"total\":\"" + dt.Rows.Count + "\",");
                    data.Append("\"rows\":[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        data.Append("{");
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            data.Append("\"");
                            data.Append(dt.Columns[j].ColumnName);
                            data.Append("\":\"");
                            data.Append(dt.Rows[i][j].ToString().Replace("\\", "\\\\").Replace("\"", "\\\""));
                            data.Append(j + 1 == dcc.Count ? "" : ",");
                        }

                        data.Append(i + 1 == dt.Rows.Count ? "}" : "},");
                    }
                    data.Append("]}");
                    return data.ToString().Replace("\r\n", "<br/>").Replace("\n", "<br/>").Replace("\r", "");
                }
            }
            return ReturnNull();
        }
        #endregion
         
        #region 表格转json数据
         //<summary>
         //表格转json数据
         //</summary>
         //<param name="dt"></param>
         //<returns></returns>
        public static string ToJson(DataTable dt, int total)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                DataColumnCollection dcc = dt.Columns;
                string columnName = string.Empty;
                if (dcc != null && dcc.Count > 0)
                {
                    StringBuilder data = new StringBuilder();
                    data.Append("{");
                    data.Append("\"total\":\"" + ((total <= 0) ? dt.Rows.Count : total) + "\",");
                    data.Append("\"rows\":[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        data.Append("{");
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            data.Append("\"");
                            data.Append(dt.Columns[j].ColumnName);
                            data.Append("\":\"");
                            data.Append(dt.Rows[i][j].ToString().Replace("\\", "\\\\").Replace("\"", "\\\""));
                            data.Append(j + 1 == dcc.Count ? "" : ",");
                        }

                        data.Append(i + 1 == dt.Rows.Count ? "}" : "},");
                    }
                    data.Append("]}");
                    return data.ToString().Replace("\r", "").Replace("\n", "");
                }
            }
            return ReturnNull();
        }
        #endregion

        #region null
         //<summary>
         // json  空格式
         //</summary>
         //<returns></returns>
        public static string ReturnNull()
        {
            return "{\"total\":\"0\",\"rows\":[]}";
        }
        #endregion

        // <summary>
        /// 将json转换为DataTable
        /// </summary>
        /// <param name="strJson">得到的json</param>
        /// <returns></returns>
        public static DataTable JsonToDataTable(string strJson)
        {
            //转换json格式
            strJson = strJson.Replace(",\"", "*\"").Replace("\":", "\"#").ToString();
            //取出表名   
            var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
            string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            //去除表名   
            strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            strJson = strJson.Substring(0, strJson.IndexOf("]"));

            //获取数据   
            rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split('*');

                //创建表   
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = strName;
                    foreach (string str in strRows)
                    {
                        var dc = new DataColumn();
                        string[] strCell = str.Split('#');

                        if (strCell[0].Substring(0, 1) == "\"")
                        {
                            int a = strCell[0].Length;
                            dc.ColumnName = strCell[0].Substring(1, a - 2);
                        }
                        else
                        {
                            dc.ColumnName = strCell[0];
                        }
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }

                //增加内容   
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split('#')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }

            return tb;
        }


      
    }

}
