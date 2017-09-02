using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// Engineering
	/// </summary>
    public static partial class Engineering
    {
        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool DeleteEngineering(int Fid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Engineering ");
            strSql.Append(" where Fid=@Fid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Fid", SqlDbType.Int,4)			};
            parameters[0].Value = Fid;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion
        public static DataTable GetMaxAdd(int fid)
        {
            string sql = "select * from Engineering where Id=(select max(Id) from Engineering) and Fid=" + fid + " ";
            return SqlHelper.ExecuteDataTable(sql, null);
        }
        public static DataTable GetMaxModify(int id, int fid)
        {
            string sql = "select * from Engineering where Id=(select max(Id) from Engineering) and Id<>" + id + " and Fid=" + fid + " ";
            return SqlHelper.ExecuteDataTable(sql, null);
        }
        public static DataTable GetMinModify(int fid)
        {
            string sql = "select * from Engineering where Id=(select min(Id) from Engineering where Fid=" + fid + " ) ";
            return SqlHelper.ExecuteDataTable(sql, null);
        }
        //public static DataTable GetPrevious(string fid)
        //{
        //    string sql = "select top 1 from Engineering where newsid<Id and Fid=" + fid + " )  order by newsid DESC";
        //    return SqlHelper.ExecuteDataTable(sql, null);
        //}
        public static DataTable GetPrev(int id, int fid)
        {
            string sql = "select top 1 a.Id,a.ImportAmount,a.ExportAmount,a.Balance from Engineering a where a.Id < " + id.ToString() + " and a.Fid=" + fid + " order by a.Id desc";
            return SqlHelper.ExecuteDataTable(sql, null);
        }

        public static DataTable GetNext(int id, int fid)
        {
            string sql = "select  * from Engineering a where a.Id > " + id.ToString() + " and a.Fid=" + fid + " order by a.Id asc"; ;
            return SqlHelper.ExecuteDataTable(sql, null);
        }
    }
}



