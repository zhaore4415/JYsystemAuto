using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
    //SWX_Config
    public partial class SWX_Config
    {

        public static bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SWX_Config");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public static bool Existss(string access_token)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SWX_Config");
            strSql.Append(" where ");
            strSql.Append(" access_token = @access_token  ");
            SqlParameter[] parameters = {
					  new SqlParameter("@access_token", SqlDbType.NVarChar,100)
			};
            parameters[0].Value = access_token;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Add(NH.Model.SWX_Config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SWX_Config(");
            strSql.Append("UserName,access_token,CorpId,Secret");
            strSql.Append(") values (");
            strSql.Append("@UserName,@access_token,@CorpId,@Secret");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@UserName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@access_token", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@CorpId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Secret", SqlDbType.NVarChar,100)             
              
            };

            parameters[0].Value = model.UserName;
            parameters[1].Value = model.access_token;
            parameters[2].Value = model.CorpId;
            parameters[3].Value = model.Secret;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                return Convert.ToInt32(obj);

            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(NH.Model.SWX_Config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SWX_Config set ");

            strSql.Append(" UserName = @UserName , ");
            strSql.Append(" access_token = @access_token , ");
            strSql.Append(" CorpId = @CorpId , ");
            strSql.Append(" Secret = @Secret  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@access_token", SqlDbType.NVarChar,100) ,            
                        new SqlParameter("@CorpId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@Secret", SqlDbType.NVarChar,100)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.access_token;
            parameters[3].Value = model.CorpId;
            parameters[4].Value = model.Secret;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SWX_Config ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public static bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SWX_Config ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static NH.Model.SWX_Config GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, UserName, access_token, CorpId, Secret  ");
            strSql.Append("  from SWX_Config ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            NH.Model.SWX_Config model = new NH.Model.SWX_Config();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.access_token = ds.Tables[0].Rows[0]["access_token"].ToString();
                model.CorpId = ds.Tables[0].Rows[0]["CorpId"].ToString();
                model.Secret = ds.Tables[0].Rows[0]["Secret"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SWX_Config ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

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
            strSql.Append(" FROM SWX_Config ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

