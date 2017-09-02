using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace NH.Web.adm.Core
{
    public class Utility
    {
        public static string DecodeParamsToSql(string paras)
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            sql.Append(" 1=1 ");
            if (!string.IsNullOrEmpty(paras))
            {
                string[] keys = paras.Split('|');
                for (int i = 0; i < keys.Length; i++)
                {
                    if (keys[i].Trim() != "")
                    {
                        string[] item = keys[i].Split('#');
                        if (item[1] != "")
                        {
                            //sql.Append(" and " + item[0].Replace("'", "''") + " " + item[2].Replace("'", "''") + " '" + item[1].Replace("'", "''") + "'");
                            sql.Append(GetWhere(item));
                        }
                    }

                }
            }
            return sql.ToString();
        }

        private static string sqlFormat = "and {0} {1} '{2}'";
        private static string GetWhere(string[] item)
        {
            string result = null;
            item[0] = item[0].Replace("'", "''");
            item[1] = item[1].Replace("'", "''");
            switch (item[2])
            {
                case "=":
                    result = string.Format(sqlFormat, item[0], "=", item[1]);
                    break;
                case ">":
                    result = string.Format(sqlFormat, item[0], ">", item[1]);
                    break;
                case "<":
                    result = string.Format(sqlFormat, item[0], "<", item[1]);
                    break;
                //case "&gt;=":
                //    result = string.Format(sqlFormat, item[0], ">=", item[1]);
                //    break;
                case ">=":
                    result = string.Format(sqlFormat, item[0], ">=", item[1]);//这个特殊一点，页面上用 &gt;= 表示>=
                    break;
                case "<=":
                    result = string.Format(sqlFormat, item[0], "<=", item[1]);
                    break;
                case "like":
                    result = string.Format(sqlFormat, item[0], "like", "%" + item[1] + "%");
                    break;
                case "llike":
                    result = string.Format(sqlFormat, item[0], "like", item[1] + "%");
                    break;
                case "rlike":
                    result = string.Format(sqlFormat, item[0], "like", "%" + item[1]);
                    break;
                case "in":
                    result = " and " + item[0] + " in " + item[1];
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// 是否有sql注入关键字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ProcessSqlStr(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return true;
            }
            else
            {
                //string pattern = @"and\s*\d+\s*<>\s*\d+|and\s*\'.*\'\s*<>\s*\'.*\'|or\s*\d+\s*<>\s*\d+|or\s*\'.*\'\s*<>\s*\'.*\'|select\s*|union\s*|inner join\s*|insert\s*|delete\s*|drop\s*|update\s*|truncate\s*|exec\s*|sysobjects|exec|<\s*script\s*>|<\s*/\s*script\s*>|syscolumns|EXECUTE";
                string pattern = @"and\s+\d+\s*<>\s*\d+|and\s*\'.*\'\s*<>\s*\'.*\'|or\s+\d+\s*<>\s*\d+|or\s+\'.*\'\s*<>\s*\'.*\'|union\s+|inner join\s+|insert\s+|delete\s+|drop\s+|update\s+|truncate\s+|exec\s+|sysobjects|exec|<\s*script\s*>|<\s*/\s*script\s*>|syscolumns|EXECUTE";
                Regex re = new Regex(pattern, RegexOptions.IgnoreCase);
                if (re.IsMatch(str))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}