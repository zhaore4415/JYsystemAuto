using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// Accounting
	/// </summary>
    public static partial class Accounting
    {
        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(string Fid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounting ");
            strSql.Append(" where Fid=@Fid");
            SqlParameter[] parameters = {
					new SqlParameter("@Fid", SqlDbType.NVarChar, 20)
			};
            parameters[0].Value = Fid;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion
        public static int GetMaxSort()
        {
            return (int)SqlHelper.ExecuteScalar("SELECT isnull(max(Fid),0)+1 from Accounting");
        }
        public static decimal GetSum(string name)
        {
         
            return (decimal)SqlHelper.ExecuteScalar("select sum(Balance) from Accounting where ProjectManager='" + name + "'");
        }
        public static DataTable GetMaxAdd(string name)
        {
            string sql = "select * from Accounting where Id=(select max(Id) from Accounting) and ProjectManager='" + name + "' ";
            return SqlHelper.ExecuteDataTable(sql, null);
        }
        public static DataTable GetMaxModify(int id, int fid)
        {
            string sql = "select * from Accounting where Id=(select max(Id) from Accounting) and Id<>" + id + " and Fid=" + fid + " ";
            return SqlHelper.ExecuteDataTable(sql, null);
        }
        public static DataTable GetMinModify(int fid)
        {
            string sql = "select * from Accounting where Id=(select min(Id) from Accounting where Fid=" + fid + " ) ";
            return SqlHelper.ExecuteDataTable(sql, null);
        }
        //public static DataTable GetPrevious(string fid)
        //{
        //    string sql = "select top 1 from Accounting where newsid<Id and Fid=" + fid + " )  order by newsid DESC";
        //    return SqlHelper.ExecuteDataTable(sql, null);
        //}
        public static DataTable GetPrev(int fid, string  name)
        {
            string sql = "select top 1 a.Id,a.ImportAmount,a.ExportAmount,a.BalanceManager,a.Fid,a.Balance from Accounting a where a.Fid < " + fid.ToString() + " and a.ProjectManager='" + name + "' order by a.Id desc";
            return SqlHelper.ExecuteDataTable(sql, null);
        }

        public static DataTable GetNext(int id, int fid)
        {
            string sql = "select  * from Accounting a where a.Id > " + id.ToString() + " and a.Fid=" + fid + " order by a.Id asc"; ;
            return SqlHelper.ExecuteDataTable(sql, null);
        }

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top,string tablename, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(tablename);
            strSql.Append(" FROM [Accounting] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.ExecuteDataSet(strSql.ToString());
        }
        #endregion


        #region 更新该项目经理所有的项目经理余额为最新的统一的值
        /// <summary>
        /// 更新该项目经理所有的项目经理余额为最新的统一的值
        /// </summary>
        public static bool UpdateAll(decimal BalanceManager, string name)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [Accounting] set BalanceManager=" + BalanceManager + " where ProjectManager='" + name + "'");
          

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion
    }
}



