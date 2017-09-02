using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.Common;
using NH.Model;
using Maticsoft.DBUtility;
namespace NH.BLL
{
    /// <summary>
    /// User
    /// </summary>
    public partial class User
    {
        #region 增加人才账号
        /// <summary>
        /// 增加人才账号
        /// </summary>
        public static int AddMember(NH.Model.User user, Model.Member member)
        {
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString))
            {
                int uid = 0;
                SqlTransaction trans = null;

                try
                {
                    conn.Open();
                    trans = conn.BeginTransaction();
                    uid = DAL.User.Add(user, trans);
                    if (uid <= 0)
                    {
                        trans.Rollback();
                        return uid;
                    }
                    member.Id = uid;
                    if (DAL.Member.Add(member, trans))
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
                    uid = Int32.MinValue;
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

                return uid;
            }

        }
        #endregion

     

        public static string GetSessionId(int userId)
        {
            string sessionId = DAL.User.GetSessionId(userId);
            if (sessionId == "")
            {
                //第一次更新程序,已经登录的全为空，自动更新为当前的sessionId，避免被迫下线
                sessionId = System.Web.HttpContext.Current.Session.SessionID;
                BLL.User.Update(new Model.User() { Id=userId,SessionId=sessionId});
            }
            return sessionId;
        }


        public static void Refresh(string strWhere)
        {
            DAL.User.Refresh(strWhere);
        }
    }
}