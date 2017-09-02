using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    /// <summary>
    /// ERPKaoQinSetting
    /// </summary>
    public static partial class ERPKaoQinSetting
    {
        #region 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(NH.Model.ERPKaoQinSetting model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ERPKaoQinSetting] ");
            strSql.Append(GetSql(model, ref parameters, false));
            return (int)SqlHelper.ExecuteScalar(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.ERPKaoQinSetting model)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.GuiDingTime1 != null)
            {
                colList.Append("[GuiDingTime1],");
                colParamList.Append("@GuiDingTime1,");
                parameter = new SqlParameter("@GuiDingTime1", SqlDbType.NVarChar, 50);
                parameter.Value = model.GuiDingTime1;
                sqlParamList.Add(parameter);
            }

            if (model.GuiDingTime2 != null)
            {
                colList.Append("[GuiDingTime2],");
                colParamList.Append("@GuiDingTime2,");
                parameter = new SqlParameter("@GuiDingTime2", SqlDbType.NVarChar, 50);
                parameter.Value = model.GuiDingTime2;
                sqlParamList.Add(parameter);
            }

            string strSql = string.Format("insert into [ERPKaoQinSetting] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
            strSql += ";select @@IDENTITY";
            object obj = SqlHelper.ExecuteScalar(strSql, sqlParamList.ToArray());
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

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ERPKaoQinSetting ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion


        #region 批量删除一批数据
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [ERPKaoQinSetting] ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            return SqlHelper.ExecuteNonQuery(strSql.ToString()) > 0;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.ERPKaoQinSetting model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ERPKaoQinSetting] set ");
            strSql.Append(GetSql(model, ref parameters, true));
            strSql.Append(" where ID=@ID ");

            return SqlHelper.ExecuteNonQuery(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #region 获取SQL及参数
        /// <summary>
        /// 获取SQL及参数
        /// </summary>
        public static string GetSql(NH.Model.ERPKaoQinSetting model, ref SqlParameter[] parameters, bool isUpdate)
        {
            StringBuilder colList = new StringBuilder();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (model.ID != Int32.MinValue)
            {
                if (!isUpdate) colList.Append("[ID] = @ID,");
                SqlParameter parameter = new SqlParameter("@ID", SqlDbType.Int, 4);
                parameter.Value = model.ID;
                paramList.Add(parameter);
            }

            if (model.GuiDingTime1 != null)
            {
                colList.Append("[GuiDingTime1] = @GuiDingTime1,");
                SqlParameter parameter = new SqlParameter("@GuiDingTime1", SqlDbType.NVarChar, 50);
                parameter.Value = model.GuiDingTime1;
                paramList.Add(parameter);
            }

            if (model.GuiDingTime2 != null)
            {
                colList.Append("[GuiDingTime2] = @GuiDingTime2,");
                SqlParameter parameter = new SqlParameter("@GuiDingTime2", SqlDbType.NVarChar, 50);
                parameter.Value = model.GuiDingTime2;
                paramList.Add(parameter);
            }

            string result = null;
            if (colList.Length > 0)
            {
                if (isUpdate)
                {
                    paramList.Add(paramList[0]);
                    paramList.RemoveAt(0);
                    result = colList.ToString().TrimEnd(',');
                }
                else
                {
                    result = "where " + colList.ToString().TrimEnd(',').Replace(",", " and ");
                }
            }
            parameters = paramList.ToArray();
            return result;
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ERPKaoQinSetting GetModel(int ID)
        {
            NH.Model.ERPKaoQinSetting model = new NH.Model.ERPKaoQinSetting();
            model.ID = ID;
            return GetModel(model);
        }
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.ERPKaoQinSetting GetModel(NH.Model.ERPKaoQinSetting model)
        {
            SqlParameter[] parameters = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID], [GuiDingTime1], [GuiDingTime2] ");
            strSql.Append(" from [ERPKaoQinSetting] ");
            strSql.Append(GetSql(model, ref parameters, false));

            DataTable dt = SqlHelper.ExecuteDataTable(strSql.ToString(), parameters);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            model = new NH.Model.ERPKaoQinSetting();
            DataRow row = dt.Rows[0];

            if (row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }

            model.GuiDingTime1 = row["GuiDingTime1"].ToString();

            model.GuiDingTime2 = row["GuiDingTime2"].ToString();

            return model;
        }
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [ERPKaoQinSetting] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.ExecuteDataSet(strSql.ToString());
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM [ERPKaoQinSetting] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.ExecuteDataSet(strSql.ToString());
        }
        #endregion
    }
}



