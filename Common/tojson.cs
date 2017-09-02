
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Reflection;


public class ToJson
{
    public ToJson()
    {

    }
    public static string DataTableToJson(string jsonName, DataTable dt)
    {
        StringBuilder Json = new StringBuilder();
        Json.Append("{\"" + jsonName + "\":[");
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Json.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    StringBuilder sb = new StringBuilder();
                    escape(dt.Rows[i][j].ToString(), sb);

                    Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + sb.ToString() + "\"");
                    if (j < dt.Columns.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
                Json.Append("}");
                if (i < dt.Rows.Count - 1)
                {
                    Json.Append(",");
                }
            }
        }
        Json.Append("]}");
        return Json.ToString();
    }

    /// <summary>
    /// 将string数组转换成json字符串
    /// </summary>
    /// <param name="TagStrings">json对象数组名称</param>
    /// <param name="Strings">json对象数组值</param>
    /// <returns></returns>
    public static string StringArrayToJason(string[] TagStrings, string[] Strings)
    {
        StringBuilder Json = new StringBuilder();
        Json.Append("{\"");
        for (int i = 0; i < Strings.Length; i++)
        {
            Json.Append(TagStrings[i]);
            Json.Append("\":\"");
            Json.Append(Strings[i]);
            if (i < Strings.Length - 1)
            {
                Json.Append("\",\"");
            }
        }
        Json.Append("\"}");
        return Json.ToString();
    }

    public static string ObjectToJson<T>(string jsonName, IList<T> IL)
    {
        StringBuilder Json = new StringBuilder();
        Json.Append("{\"" + jsonName + "\":[");
        if (IL.Count > 0)
        {
            for (int i = 0; i < IL.Count; i++)
            {
                T obj = Activator.CreateInstance<T>();
                Type type = obj.GetType();
                PropertyInfo[] pis = type.GetProperties();
                Json.Append("{");
                for (int j = 0; j < pis.Length; j++)
                {
                    Json.Append("\"" + pis[j].Name.ToString() + "\":\"" + pis[j].GetValue(IL[i], null) + "\"");
                    if (j < pis.Length - 1)
                    {
                        Json.Append(",");
                    }
                }
                Json.Append("}");
                if (i < IL.Count - 1)
                {
                    Json.Append(",");
                }
            }
        }
        Json.Append("]}");
        return Json.ToString();
    }


    public static void escape(string s, StringBuilder sb)
    {

        for (int i = 0; i < s.Length; i++)
        {
            char ch = s[i];

            switch (ch)
            {

                case '"':
                    sb.Append("\\\"");
                    break;

                case '\\':

                    sb.Append("\\\\");

                    break;

                case '\b':

                    sb.Append("\\b");

                    break;

                case '\f':

                    sb.Append("\\f");

                    break;

                case '\n':

                    sb.Append("\\n");

                    break;

                case '\r':

                    sb.Append("\\r");

                    break;

                case '\t':

                    sb.Append("\\t");

                    break;

                case '/':

                    sb.Append("\\/");

                    break;

                default:

                    // Reference: http://www.unicode.org/versions/Unicode5.1.0/

                    if ((ch >= '\u0000' && ch <= '\u001F')

                    || (ch >= '\u007F' && ch <= '\u009F')

                    || (ch >= '\u2000' && ch <= '\u20FF'))
                    {

                        string ss = Convert.ToString(ch, 16);

                        sb.Append("\\u");

                        for (int k = 0; k < 4 - ss.Length; k++)
                        {

                            sb.Append('0');

                        }

                        sb.Append(ss.ToUpper());

                    }
                    else
                    {

                        sb.Append(ch);

                    }

                    break;

            }

        }

    }

}
