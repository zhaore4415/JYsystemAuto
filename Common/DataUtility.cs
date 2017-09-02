using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;

namespace Maticsoft.Common
{
    public static class DataUtility
    {
        /*
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="fieldname">字段名</param>
        /// <param name="pagesize">每页显示数量(为0则读取所有，不分页)</param>
        /// <param name="pageindex">页码</param>
        /// <param name="key">主键字段</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="sort">排序(需要加 order by)</param>
        /// <param name="IsRecount">是否查询总记录数量</param>
        /// <returns></returns>
        public static DataSet GetList_(string tablename, string fieldname, int pagesize, int pageindex, string key, string strWhere, string sort, bool IsRecount)
        {
            //if (string.IsNullOrEmpty(strWhere) || strWhere.Replace(" ", "") == "1=1")
            //{
            //    strWhere = "";
            //}
            //else
            //{
                strWhere = " where 1=1 " + strWhere;
            //}

            int befrows = pagesize * (pageindex - 1);
            string sql = string.Format("select {0} {1} from {2} {3}",(pagesize > 0 ? "top " + pagesize.ToString() : ""),fieldname,tablename,strWhere);
            if (befrows > 0)
            {
                sql += " and " + key + " not in (select top " + befrows + " " + key + " from " + tablename + strWhere + " " + sort + ")";
            }
            sql += " " + sort;
            string sqlcount = null;
            if (IsRecount)
            {
                sqlcount = "select count(1) as Total from " + tablename + strWhere;
            }
            else
            {
                sqlcount = "select 0";
            }

            DataSet ds = new DataSet();
            DataTable dt1 = SqlHelper.ExecuteDataTable(sql, null).Copy();
            dt1.TableName = "List";
            ds.Tables.Add(dt1);

            if (IsRecount)
            {
                DataTable dt2 = SqlHelper.ExecuteDataTable(sqlcount, null).Copy();
                dt2.TableName = "Count";
                ds.Tables.Add(dt2);
            }

            return ds;
        }
        */

        /// <summary>
        /// 分页获取数据(继承自新方法)
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="fieldname">字段名</param>
        /// <param name="pagesize">每页显示数量</param>
        /// <param name="pageindex">页码</param>
        /// <param name="key">主键字段</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="sort">排序(不需要order by)</param>
        /// <param name="IsRecount">是否查询总记录数量</param>
        /// <returns></returns>
        public static DataSet GetList(string tablename, string fieldname, int pagesize, int pageindex, string key, string strWhere, string sort, bool IsRecount)
        {
            return GetList(
                tablename, 
                fieldname, 
                string.IsNullOrEmpty(sort) ? key : sort.ToLower().Replace("order by ", ""), 
                strWhere, 
                pageindex, 
                pagesize, 
                IsRecount
                );
        }

        /// <summary>
        /// 获取分页列表(新方法)
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="columnName">要查询的列</param>
        /// <param name="sort">排序字段（不要order by）</param>
        /// <param name="where">查询条件，以and开头</param>
        /// <param name="page">第几页</param>
        /// <param name="pageSize">每页显示大小</param>
        /// <param name="IsReturnCount">是否返回总记录数</param>
        /// <returns></returns>
        public static DataSet GetList(string table, string columnName, string sort, string where, int page, int pageSize, bool IsReturnCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select *");
            sb.Append(" from (");
            sb.Append("select ");
            sb.Append(columnName);
            sb.Append(",ROW_NUMBER() OVER (order by ");
            sb.Append(sort);
            sb.Append(") as pagerID from ");
            if (table.ToLower().Contains("select"))
            {
                sb.Append("(");
                sb.Append(table);
                if (!string.IsNullOrEmpty(where))
                {
                    sb.Append(" where 1=1 ");
                    sb.Append(where);
                }
                sb.Append(") temptemp");
            }
            else
            {
                sb.Append(table);
                if (!string.IsNullOrEmpty(where))
                {
                    sb.Append(" where 1=1 ");
                    sb.Append(where);
                }
            }

            sb.Append(") temp");
            if (page < 1) page = 1;

            if (pageSize > 0)
            {
                int start = (page - 1) * pageSize + 1;
                int end = start + pageSize;
                sb.Append(" where pagerID>=");
                sb.Append(start);
                sb.Append(" and pagerID<");
                sb.Append(end);
            }



            /*
            int start = (page - 1) * pageSize + 1;
            int end = start + pageSize;
            sb.Append(" ) temp where pagerID>=");
            sb.Append(start);
            sb.Append(" and pagerID<");
            sb.Append(end);
            */
            string sqlcount = null;
            if (IsReturnCount)
            {
                sqlcount = "select count(1) as Total from " + table + (!string.IsNullOrEmpty(where) ? " where 1=1 " + where : "");
            }
            else
            {
                sqlcount = "select 0";
            }


            DataSet ds = new DataSet();
            //DataTable dt1 = SqlHelper.ExecuteDataTable(sb.ToString(), null).Copy();
            //dt1.TableName = "List";
            //ds.Tables.Add(dt1);

            //if (IsReturnCount)
            //{
            //    DataTable dt2 = SqlHelper.ExecuteDataTable(sqlcount, null).Copy();
            //    dt2.TableName = "Count";
            //    ds.Tables.Add(dt2);
            //}

            ds = SqlHelper.ExecuteDataSet(sb.ToString() + ";" + sqlcount);

            return ds;
        }
        /// <summary>
        /// 分页获取数据(继承自新方法)
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="fieldname">字段名</param>
        /// <param name="pagesize">每页显示数量</param>
        /// <param name="pageindex">页码</param>
        /// <param name="key">主键字段</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="sort">排序(不需要order by)</param>
        /// <param name="IsRecount">是否查询总记录数量</param>
        /// <returns></returns>
        public static DataSet GetListProduct(string tablename, string fieldname, int pagesize, int pageindex, string key, string strWhere, string sort, bool IsRecount)
        {
            return GetListProduct(
                tablename,
                fieldname,
                string.IsNullOrEmpty(sort) ? key : sort.ToLower().Replace("order by ", ""),
                strWhere,
                pageindex,
                pagesize,
                IsRecount
                );
        }

        /// <summary>
        /// 获取分页列表(新方法)
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="columnName">要查询的列</param>
        /// <param name="sort">排序字段（不要order by）</param>
        /// <param name="where">查询条件，以and开头</param>
        /// <param name="page">第几页</param>
        /// <param name="pageSize">每页显示大小</param>
        /// <param name="IsReturnCount">是否返回总记录数</param>
        /// <returns></returns>
        public static DataSet GetListProduct(string table, string columnName, string sort, string where, int page, int pageSize, bool IsReturnCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select *");
            sb.Append(" from (");
            sb.Append("select ");
            sb.Append(columnName);
            sb.Append(",ROW_NUMBER() OVER (order by ");
            sb.Append(sort);
            sb.Append(") as pagerID from ");
            if (table.ToLower().Contains("select"))
            {
                sb.Append("(");
                sb.Append(table);
                if (!string.IsNullOrEmpty(where))
                {
                    sb.Append(" where 1=1 ");
                    sb.Append(where);
                }
                sb.Append(") temptemp");
            }
            else
            {
                sb.Append(table);
                if (!string.IsNullOrEmpty(where))
                {
                    sb.Append(" where 1=1 ");
                    sb.Append(where);
                }
            }

            sb.Append(") temp");
            if (page < 1) page = 1;

            if (pageSize > 0)
            {
                int start = (page - 1) * pageSize + 1;
                int end = start + pageSize;
                sb.Append(" where pagerID>=");
                sb.Append(start);
                sb.Append(" and pagerID<");
                sb.Append(end);
            }



            /*
            int start = (page - 1) * pageSize + 1;
            int end = start + pageSize;
            sb.Append(" ) temp where pagerID>=");
            sb.Append(start);
            sb.Append(" and pagerID<");
            sb.Append(end);
            */
            string sqlcount = null;
            if (IsReturnCount)
            {
                sqlcount = "select count(1) as Total from " + table + (!string.IsNullOrEmpty(where) ? " where 1=1 " + where : "");
            }
            else
            {
                sqlcount = "select 0";
            }


            DataSet ds = new DataSet();
            //DataTable dt1 = SqlHelper.ExecuteDataTable(sb.ToString(), null).Copy();
            //dt1.TableName = "List";
            //ds.Tables.Add(dt1);

            //if (IsReturnCount)
            //{
            //    DataTable dt2 = SqlHelper.ExecuteDataTable(sqlcount, null).Copy();
            //    dt2.TableName = "Count";
            //    ds.Tables.Add(dt2);
            //}

            ds = SqlHelper.ExecuteDataSetProduct(sb.ToString() + ";" + sqlcount);

            return ds;
        }
        public static StringBuilder GetListToJson(string tablename, string fieldname, int pagesize, int pageindex, string key, string strWhere, string sort, bool IsRecount)
        {
            DataSet ds = GetList(tablename, fieldname, pagesize, pageindex, key, strWhere, sort, IsRecount);
            return DataToJson.DtToJson(ds.Tables[0], (IsRecount ? (int)ds.Tables[1].Rows[0][0] : ds.Tables[0].Rows.Count));
        }

    }
}
