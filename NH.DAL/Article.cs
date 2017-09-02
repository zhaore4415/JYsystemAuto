using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// Article
	/// </summary>
	public static partial class Article
	{
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public static DataSet GetList(int PageSize, int PageIndex, string strWhere, string sort)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.NVarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 500),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@key", SqlDbType.NVarChar),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@sort", SqlDbType.NVarChar,50),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    };
            parameters[0].Value = "Article a(nolock) left join ArticleCategory ac(nolock) on a.CategoryID=ac.Id";
            parameters[1].Value = "a.Id,a.CategoryID,a.Title,a.Url,a.AddTime,a.Status,a.IsTop,a.IsHilight,a.UpdateTime,ac.Name CategoryName";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = "a.Id";
            parameters[5].Value = strWhere;
            parameters[6].Value = sort;
            parameters[7].Value = 1;
            return SqlHelper.RunProcedure("UP_GetList", parameters, "ds");
        }

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.Article model, SqlTransaction trans)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.CategoryID != Int32.MinValue)
            {
                colList.Append("[CategoryID],");
                colParamList.Append("@CategoryID,");
                parameter = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
                parameter.Value = model.CategoryID;
                sqlParamList.Add(parameter);
            }

            if (model.Title != null)
            {
                colList.Append("[Title],");
                colParamList.Append("@Title,");
                parameter = new SqlParameter("@Title", SqlDbType.NVarChar, 50);
                parameter.Value = model.Title;
                sqlParamList.Add(parameter);
            }

            if (model.Description != null)
            {
                colList.Append("[Description],");
                colParamList.Append("@Description,");
                parameter = new SqlParameter("@Description", SqlDbType.NText);
                parameter.Value = model.Description;
                sqlParamList.Add(parameter);
            }

            if (model.Url != null)
            {
                colList.Append("[Url],");
                colParamList.Append("@Url,");
                parameter = new SqlParameter("@Url", SqlDbType.NVarChar, 50);
                parameter.Value = model.Url;
                sqlParamList.Add(parameter);
            }

            if (model.AddTime != DateTime.MinValue)
            {
                colList.Append("[AddTime],");
                colParamList.Append("@AddTime,");
                parameter = new SqlParameter("@AddTime", SqlDbType.DateTime);
                parameter.Value = model.AddTime;
                sqlParamList.Add(parameter);
            }

            if (model.Status != Int32.MinValue)
            {
                colList.Append("[Status],");
                colParamList.Append("@Status,");
                parameter = new SqlParameter("@Status", SqlDbType.Int, 4);
                parameter.Value = model.Status;
                sqlParamList.Add(parameter);
            }

            if (model.Hits != Int32.MinValue)
            {
                colList.Append("[Hits],");
                colParamList.Append("@Hits,");
                parameter = new SqlParameter("@Hits", SqlDbType.Int, 4);
                parameter.Value = model.Hits;
                sqlParamList.Add(parameter);
            }

            if (model.IsTop.HasValue)
            {
                colList.Append("[IsTop],");
                colParamList.Append("@IsTop,");
                parameter = new SqlParameter("@IsTop", SqlDbType.Bit, 1);
                parameter.Value = model.IsTop.Value;
                sqlParamList.Add(parameter);
            }

            if (model.IsHilight.HasValue)
            {
                colList.Append("[IsHilight],");
                colParamList.Append("@IsHilight,");
                parameter = new SqlParameter("@IsHilight", SqlDbType.Bit, 1);
                parameter.Value = model.IsHilight.Value;
                sqlParamList.Add(parameter);
            }

            if (model.AddUserId != Int32.MinValue)
            {
                colList.Append("[AddUserId],");
                colParamList.Append("@AddUserId,");
                parameter = new SqlParameter("@AddUserId", SqlDbType.Int, 4);
                parameter.Value = model.AddUserId;
                sqlParamList.Add(parameter);
            }

            if (model.UpdateTime.HasValue)
            {
                colList.Append("[UpdateTime],");
                colParamList.Append("@UpdateTime,");
                parameter = new SqlParameter("@UpdateTime", SqlDbType.DateTime);
                if (model.UpdateTime.Value != DateTime.MinValue)
                    parameter.Value = model.UpdateTime.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.Files != null)
            {
                colList.Append("[Files],");
                colParamList.Append("@Files,");
                parameter = new SqlParameter("@Files", SqlDbType.NVarChar, 50);
                parameter.Value = model.Files;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [Article] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
            strSql += ";select @@IDENTITY"; 

            object obj = SqlHelper.ExecuteScalar(trans,strSql, sqlParamList.ToArray());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }
        #endregion

        public static DataSet GetHrTools()
        {
            string sql = "select Id,Name from ArticleCategory ac(nolock) where ac.Status=1 and ac.Type=5 order by ac.Sort asc";
            sql += ";select a.Id,a.CategoryID,a.Title from Article a(nolock) join ArticleCategory ac(nolock) on a.CategoryID=ac.Id where ac.Status=1 and ac.Type=5 and a.Status=1";
            return SqlHelper.ExecuteDataSet(sql, null);
        }

        public static DataSet GetSolution()
        {
            string sql = "select Id,Name from ArticleCategory ac(nolock) where ac.Status=1 and ac.Type=6 order by ac.Sort asc";
            sql += ";select a.Id,a.CategoryID,a.Title from Article a(nolock) join ArticleCategory ac(nolock) on a.CategoryID=ac.Id where ac.Status=1 and ac.Type=6 and a.Status=1";
            return SqlHelper.ExecuteDataSet(sql, null);
        }

        public static DataTable GetPrev(int id)
        {
            string sql = "select top 1 a.Id,a.Title from Article a where a.Id < " + id.ToString() + " order by a.Id desc";
            return SqlHelper.ExecuteDataTable(sql, null);
        }

        public static DataTable GetNext(int id)
        {
            string sql = "select top 1 a.Id,a.Title from Article a where a.Id > " + id.ToString() + " order by a.Id asc"; ;
            return SqlHelper.ExecuteDataTable(sql, null);
        }
	}
}



