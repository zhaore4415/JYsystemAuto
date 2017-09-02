using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.Data.SqlClient;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using NH.Model;

namespace NH.BLL 
{
	/// <summary>
	/// Article
	/// </summary>
	public partial class Article
	{
        #region 增加系统消息
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int AddSysNews(NH.Model.Article model,int userType)
        {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString))
            {
                int id = 0;
                SqlTransaction trans = null;

                try
                {
                    conn.Open();
                    trans = conn.BeginTransaction();
                    id = DAL.Article.Add(model, trans);
                    if (id <= 0)
                    {
                        trans.Rollback();
                        return id;
                    }
                    if (DAL.SysNewsRecord.Add(id,userType,trans))
                    {
                        trans.Commit();
                    }
                    else
                    {
                        trans.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    id = Int32.MinValue;
                    if (trans != null)
                    {
                        trans.Rollback();
                    }
                    Maticsoft.Common.Log.Write(ex);
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }

                return id;
            }
        }
        #endregion

        public static DataSet GetList(int PageSize, int PageIndex, string strWhere, string sort)
        {
            return DAL.Article.GetList(PageSize, PageIndex, strWhere, sort);
        }

        public static DataSet GetHrTools()
        {
            return DAL.Article.GetHrTools();
        }

        public static DataSet GetSolution()
        {
            return DAL.Article.GetSolution();
        }
        public static DataTable GetPrev(int id)
        {
           
            return DAL.Article.GetPrev(id);
        }

        public static DataTable GetNext(int id)
        {
            return DAL.Article.GetNext(id);
        }

    }
}