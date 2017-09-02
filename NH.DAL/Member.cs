using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace NH.DAL
{
	/// <summary>
	/// Member
	/// </summary>
	public static partial class Member
	{				
		#region 增加一条数据
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static bool Add(NH.Model.Member model,SqlTransaction trans)
        {
            StringBuilder colList = new StringBuilder();
            StringBuilder colParamList = new StringBuilder();
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            SqlParameter parameter = null;

            if (model.Id != Int32.MinValue)
            {
                colList.Append("[Id],");
                colParamList.Append("@Id,");
                parameter = new SqlParameter("@Id", SqlDbType.Int, 4);
                parameter.Value = model.Id;
                sqlParamList.Add(parameter);
            }

            if (model.CurAddr != null)
            {
                colList.Append("[CurAddr],");
                colParamList.Append("@CurAddr,");
                parameter = new SqlParameter("@CurAddr", SqlDbType.NVarChar, 50);
                parameter.Value = model.CurAddr;
                sqlParamList.Add(parameter);
            }

            if (model.ExperienceID != Int32.MinValue)
            {
                colList.Append("[ExperienceID],");
                colParamList.Append("@ExperienceID,");
                parameter = new SqlParameter("@ExperienceID", SqlDbType.Int, 4);
                parameter.Value = model.ExperienceID;
                sqlParamList.Add(parameter);
            }

            if (model.DegreeID != Int32.MinValue)
            {
                colList.Append("[DegreeID],");
                colParamList.Append("@DegreeID,");
                parameter = new SqlParameter("@DegreeID", SqlDbType.Int, 4);
                parameter.Value = model.DegreeID;
                sqlParamList.Add(parameter);
            }

            if (model.DegreeName != null)
            {
                colList.Append("[DegreeName],");
                colParamList.Append("@DegreeName,");
                parameter = new SqlParameter("@DegreeName", SqlDbType.NVarChar, 20);
                parameter.Value = model.DegreeName;
                sqlParamList.Add(parameter);
            }

            if (model.Mobile != null)
            {
                colList.Append("[Mobile],");
                colParamList.Append("@Mobile,");
                parameter = new SqlParameter("@Mobile", SqlDbType.NVarChar, 50);
                parameter.Value = model.Mobile;
                sqlParamList.Add(parameter);
            }

            if (model.MobileVerified.HasValue)
            {
                colList.Append("[MobileVerified],");
                colParamList.Append("@MobileVerified,");
                parameter = new SqlParameter("@MobileVerified", SqlDbType.Bit, 1);
                parameter.Value = model.MobileVerified.Value;
                sqlParamList.Add(parameter);
            }

            if (model.Phone != null)
            {
                colList.Append("[Phone],");
                colParamList.Append("@Phone,");
                parameter = new SqlParameter("@Phone", SqlDbType.NVarChar, 50);
                parameter.Value = model.Phone;
                sqlParamList.Add(parameter);
            }

            if (model.QQ != null)
            {
                colList.Append("[QQ],");
                colParamList.Append("@QQ,");
                parameter = new SqlParameter("@QQ", SqlDbType.NVarChar, 50);
                parameter.Value = model.QQ;
                sqlParamList.Add(parameter);
            }

            if (model.Email != null)
            {
                colList.Append("[Email],");
                colParamList.Append("@Email,");
                parameter = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
                parameter.Value = model.Email;
                sqlParamList.Add(parameter);
            }

            if (model.Address != null)
            {
                colList.Append("[Address],");
                colParamList.Append("@Address,");
                parameter = new SqlParameter("@Address", SqlDbType.NVarChar, 50);
                parameter.Value = model.Address;
                sqlParamList.Add(parameter);
            }

            if (model.Realname != null)
            {
                colList.Append("[Realname],");
                colParamList.Append("@Realname,");
                parameter = new SqlParameter("@Realname", SqlDbType.NVarChar, 20);
                parameter.Value = model.Realname;
                sqlParamList.Add(parameter);
            }

            if (model.HomePage != null)
            {
                colList.Append("[HomePage],");
                colParamList.Append("@HomePage,");
                parameter = new SqlParameter("@HomePage", SqlDbType.NVarChar, 50);
                parameter.Value = model.HomePage;
                sqlParamList.Add(parameter);
            }

            if (model.IsHousing != Int32.MinValue)
            {
                colList.Append("[IsHousing],");
                colParamList.Append("@IsHousing,");
                parameter = new SqlParameter("@IsHousing", SqlDbType.Int, 4);
                parameter.Value = model.IsHousing;
                sqlParamList.Add(parameter);
            }

            if (model.IsCarFare != Int32.MinValue)
            {
                colList.Append("[IsCarFare],");
                colParamList.Append("@IsCarFare,");
                parameter = new SqlParameter("@IsCarFare", SqlDbType.Int, 4);
                parameter.Value = model.IsCarFare;
                sqlParamList.Add(parameter);
            }

            if (model.JobCategoryIDs != null)
            {
                colList.Append("[JobCategoryIDs],");
                colParamList.Append("@JobCategoryIDs,");
                parameter = new SqlParameter("@JobCategoryIDs", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobCategoryIDs;
                sqlParamList.Add(parameter);
            }

            if (model.JobCategoryName != null)
            {
                colList.Append("[JobCategoryName],");
                colParamList.Append("@JobCategoryName,");
                parameter = new SqlParameter("@JobCategoryName", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobCategoryName;
                sqlParamList.Add(parameter);
            }

            if (model.SalaryID != Int32.MinValue)
            {
                colList.Append("[SalaryID],");
                colParamList.Append("@SalaryID,");
                parameter = new SqlParameter("@SalaryID", SqlDbType.Int, 4);
                parameter.Value = model.SalaryID;
                sqlParamList.Add(parameter);
            }

            if (model.SalaryName != null)
            {
                colList.Append("[SalaryName],");
                colParamList.Append("@SalaryName,");
                parameter = new SqlParameter("@SalaryName", SqlDbType.NVarChar, 20);
                parameter.Value = model.SalaryName;
                sqlParamList.Add(parameter);
            }

            if (model.Commission.HasValue)
            {
                colList.Append("[Commission],");
                colParamList.Append("@Commission,");
                parameter = new SqlParameter("@Commission", SqlDbType.Bit, 1);
                parameter.Value = model.Commission.Value;
                sqlParamList.Add(parameter);
            }

            if (model.JobTypeID != null)
            {
                colList.Append("[JobTypeID],");
                colParamList.Append("@JobTypeID,");
                parameter = new SqlParameter("@JobTypeID", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobTypeID;
                sqlParamList.Add(parameter);
            }

            if (model.JobTypeName != null)
            {
                colList.Append("[JobTypeName],");
                colParamList.Append("@JobTypeName,");
                parameter = new SqlParameter("@JobTypeName", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobTypeName;
                sqlParamList.Add(parameter);
            }

            if (model.Sex != Int32.MinValue)
            {
                colList.Append("[Sex],");
                colParamList.Append("@Sex,");
                parameter = new SqlParameter("@Sex", SqlDbType.Int, 4);
                parameter.Value = model.Sex;
                sqlParamList.Add(parameter);
            }

            if (model.JobAddrID != null)
            {
                colList.Append("[JobAddrID],");
                colParamList.Append("@JobAddrID,");
                parameter = new SqlParameter("@JobAddrID", SqlDbType.NVarChar, 50);
                parameter.Value = model.JobAddrID;
                sqlParamList.Add(parameter);
            }

            if (model.JobAddr != null)
            {
                colList.Append("[JobAddr],");
                colParamList.Append("@JobAddr,");
                parameter = new SqlParameter("@JobAddr", SqlDbType.NVarChar, 100);
                parameter.Value = model.JobAddr;
                sqlParamList.Add(parameter);
            }

            if (model.Resume != null)
            {
                colList.Append("[Resume],");
                colParamList.Append("@Resume,");
                parameter = new SqlParameter("@Resume", SqlDbType.NText);
                parameter.Value = model.Resume;
                sqlParamList.Add(parameter);
            }

            if (model.SelfEvaluation != null)
            {
                colList.Append("[SelfEvaluation],");
                colParamList.Append("@SelfEvaluation,");
                parameter = new SqlParameter("@SelfEvaluation", SqlDbType.NText);
                parameter.Value = model.SelfEvaluation;
                sqlParamList.Add(parameter);
            }

            if (model.IdentityNo != null)
            {
                colList.Append("[IdentityNo],");
                colParamList.Append("@IdentityNo,");
                parameter = new SqlParameter("@IdentityNo", SqlDbType.NVarChar, 50);
                parameter.Value = model.IdentityNo;
                sqlParamList.Add(parameter);
            }

            if (model.IdentityVerified.HasValue)
            {
                colList.Append("[IdentityVerified],");
                colParamList.Append("@IdentityVerified,");
                parameter = new SqlParameter("@IdentityVerified", SqlDbType.Bit, 1);
                parameter.Value = model.IdentityVerified.Value;
                sqlParamList.Add(parameter);
            }

            if (model.IsShow.HasValue)
            {
                colList.Append("[IsShow],");
                colParamList.Append("@IsShow,");
                parameter = new SqlParameter("@IsShow", SqlDbType.Bit, 1);
                parameter.Value = model.IsShow.Value;
                sqlParamList.Add(parameter);
            }

            if (model.ViewCount != Int32.MinValue)
            {
                colList.Append("[ViewCount],");
                colParamList.Append("@ViewCount,");
                parameter = new SqlParameter("@ViewCount", SqlDbType.Int, 4);
                parameter.Value = model.ViewCount;
                sqlParamList.Add(parameter);
            }

            if (model.WorksCount != Int32.MinValue)
            {
                colList.Append("[WorksCount],");
                colParamList.Append("@WorksCount,");
                parameter = new SqlParameter("@WorksCount", SqlDbType.Int, 4);
                parameter.Value = model.WorksCount;
                sqlParamList.Add(parameter);
            }

            if (model.VerifyStatus != Int32.MinValue)
            {
                colList.Append("[VerifyStatus],");
                colParamList.Append("@VerifyStatus,");
                parameter = new SqlParameter("@VerifyStatus", SqlDbType.Int, 4);
                parameter.Value = model.VerifyStatus;
                sqlParamList.Add(parameter);
            }

            if (model.Birthday.HasValue)
            {
                colList.Append("[Birthday],");
                colParamList.Append("@Birthday,");
                parameter = new SqlParameter("@Birthday", SqlDbType.SmallDateTime);
                if (model.Birthday.Value != DateTime.MinValue)
                    parameter.Value = model.Birthday.Value;
                else
                    parameter.Value = DBNull.Value;

                sqlParamList.Add(parameter);
            }

            if (model.IsGood.HasValue)
            {
                colList.Append("[IsGood],");
                colParamList.Append("@IsGood,");
                parameter = new SqlParameter("@IsGood", SqlDbType.Bit, 1);
                parameter.Value = model.IsGood.Value;
                sqlParamList.Add(parameter);
            }
            
            if (model.ComeTimeID != Int32.MinValue)
            {
                colList.Append("[ComeTimeID],");
                colParamList.Append("@ComeTimeID,");
                parameter = new SqlParameter("@ComeTimeID", SqlDbType.Int, 4);
                parameter.Value = model.ComeTimeID;
                sqlParamList.Add(parameter);
            }

            if (model.ComeTimeDesc != null)
            {
                colList.Append("[ComeTimeDesc],");
                colParamList.Append("@ComeTimeDesc,");
                parameter = new SqlParameter("@ComeTimeDesc", SqlDbType.NVarChar, 10);
                parameter.Value = model.ComeTimeDesc;
                sqlParamList.Add(parameter);
            }

            if (model.IsVerify.HasValue)
            {
                colList.Append("[IsVerify],");
                colParamList.Append("@IsVerify,");
                parameter = new SqlParameter("@IsVerify", SqlDbType.Bit, 1);
                parameter.Value = model.IsVerify.Value;
                sqlParamList.Add(parameter);
            }

            if (model.Height != Int32.MinValue)
            {
                colList.Append("[Height],");
                colParamList.Append("@Height,");
                parameter = new SqlParameter("@Height", SqlDbType.Int, 4);
                parameter.Value = model.Height;
                sqlParamList.Add(parameter);
            }

            if (model.Marriage != Int32.MinValue)
            {
                colList.Append("[Marriage],");
                colParamList.Append("@Marriage,");
                parameter = new SqlParameter("@Marriage", SqlDbType.Int, 4);
                parameter.Value = model.Marriage;
                sqlParamList.Add(parameter);
            }

            if (model.ResidenceAddrID != null)
            {
                colList.Append("[ResidenceAddrID],");
                colParamList.Append("@ResidenceAddrID,");
                parameter = new SqlParameter("@ResidenceAddrID", SqlDbType.NVarChar, 20);
                parameter.Value = model.ResidenceAddrID;
                sqlParamList.Add(parameter);
            }

            if (model.Residence != null)
            {
                colList.Append("[Residence],");
                colParamList.Append("@Residence,");
                parameter = new SqlParameter("@Residence", SqlDbType.NVarChar, 50);
                parameter.Value = model.Residence;
                sqlParamList.Add(parameter);
            }

            if (model.CurrAddrID != null)
            {
                colList.Append("[CurrAddrID],");
                colParamList.Append("@CurrAddrID,");
                parameter = new SqlParameter("@CurrAddrID", SqlDbType.NVarChar, 20);
                parameter.Value = model.CurrAddrID;
                sqlParamList.Add(parameter);
            }
            string strSql = string.Format("insert into [Member] ({0}) values ({1})", colList.ToString().TrimEnd(','), colParamList.ToString().TrimEnd(','));
                            
            return SqlHelper.ExecuteNonQuery(trans,CommandType.Text,strSql, sqlParamList.ToArray()) > 0;
            			
		}
		#endregion

        /// <summary>
        /// 获取求职者信息
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public static DataSet GetPersonInfo(int memberId)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@memberId",SqlDbType.Int)
                                        };
            parameters[0].Value = memberId;

            return SqlHelper.RunProcedure("GetPerInfo", parameters, "ds");
        }

        /// <summary>
        /// 分页获取数据列表(后台)
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
            parameters[0].Value = "Member m(nolock) left join [User] u(nolock) on m.Id=u.Id left join Experience ex on m.ExperienceID=ex.Id";
            parameters[1].Value = "u.Id,u.LoginName,u.AddTime,u.Status,m.Realname,m.Sex,m.Birthday,m.Mobile,m.Phone,m.Email,m.JobCategoryName,m.CurAddr,m.DegreeName,ex.Name Experience";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = "u.Id";
            parameters[5].Value = strWhere;
            parameters[6].Value = sort;
            parameters[7].Value = 1;
            return SqlHelper.RunProcedure("UP_GetList", parameters, "ds");
        }

        public static DataSet GetMemberMsg(int memberId)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@memberId",SqlDbType.Int)
                                        };
            parameters[0].Value = memberId;

            return SqlHelper.RunProcedure("Get_Member_Msg", parameters, "ds");
        }

        public static DataSet GetMemberPopMsg(int memberId)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@memberId",SqlDbType.Int)
                                        };
            parameters[0].Value = memberId;

            return SqlHelper.RunProcedure("Get_Member_Pop_Msg", parameters, "ds");
        }

        /// <summary>
        /// 更新作品数量
        /// </summary>
        /// <param name="memberId"></param>
        public static void UpdateWorksCount(int memberId)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@MemberID",memberId)
                                        };
            string strSql = "update Member set WorksCount = (select count(*) from MemberWorks w(nolock) where w.MemberID=@MemberID) where Id = @MemberID";
            SqlHelper.ExecuteNonQuery(strSql, parameters);
        }

        /// <summary>
        /// 更新浏览量
        /// </summary>
        /// <param name="memberId"></param>
        public static void UpdateViewCount(int memberId)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@MemberID",memberId)
                                        };
            string strSql = "update Member set ViewCount = ViewCount+1 where Id = @MemberID";
            SqlHelper.ExecuteNonQuery(strSql, parameters);
        }

        /// <summary>
        /// 更新完善度
        /// </summary>
        /// <param name="memberId"></param>
        public static void UpdateComplete(int memberId)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@MemberID",memberId)
                                        };
            SqlHelper.RunProcedure("Update_Member_Complete", parameters, "ds");
        }

        /// <summary>
        /// 获取面试通知数量
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public static int GetInterviewCount(int memberId)
        {
            string strSql = "select COUNT(i.Id) from Interview i(nolock) where MemberID = @memberId and ReadStatus=0";
            SqlParameter[] parameters = { 
                                        new SqlParameter("@memberId",memberId)
                                        };

            return (int)SqlHelper.ExecuteScalar(strSql, parameters);
        }

        /// <summary>
        /// 更新是否需要审核的标识
        /// </summary>
        /// <param name="memberId"></param>
        public static bool UpdateMemberIsVerify(int memberId)
        {
            SqlParameter[] parameters = { 
                                        new SqlParameter("@memberID",memberId)
                                        };
            return (bool)SqlHelper.RunProcedure("Update_Member_IsVerify", parameters, "ds").Tables[0].Rows[0][0];
        }

        /// <summary>
        /// 获取待审核的人才数量
        /// </summary>
        /// <returns></returns>
        public static int GetVerifyCount()
        {
            return (int)SqlHelper.ExecuteScalar("select count(m.Id) from Member m(nolock) join [User] u(nolock) on m.Id=u.Id where (IsVerify = 1 or VerifyStatus=0) and u.Status<>-1", null);
        }

        /// <summary>
        /// 获取上一个、下一个
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataSet GetPreNext(int mid, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("declare @mid int;");
            strSql.Append("set @mid=" + mid);
            strSql.Append(";declare @tb table(rowid int,mid int)");
            strSql.Append(";insert into @tb ");
            strSql.Append("select ROW_NUMBER() over (order by u.RefreshTime desc) as rowid,m.Id ");
            strSql.Append("from [User] u(nolock) join Member m(nolock) on u.Id=m.Id ");
            if (!string.IsNullOrEmpty(strWhere))
                strSql.Append("where " + strWhere);

            strSql.Append(";select top 1 mid from @tb where rowid < (select rowid from @tb where mid=@mid) order by rowid desc");//上一个
            strSql.Append(";select top 1 mid from @tb where rowid > (select rowid from @tb where mid=@mid)");//下一个

            return SqlHelper.ExecuteDataSet(strSql.ToString(), null);
        }



        /// <summary>
        /// 获取首页人才
        /// </summary>
        public static DataSet GetHomePerson()
        {
            return SqlHelper.RunProcedure("GetHomePerson", new SqlParameter[] { }, "ds");
        }
        public static DataTable GetAutoRefresh()
        {
            string strSql = "select id,RefreshTime from [User](nolock) where UserType=1 and RefreshTime > '" + DateTime.Now.AddHours(-1) + "'";
            return SqlHelper.ExecuteDataSet(strSql, null).Tables[0];
        }
        public static void UpdateViewcount(int id)
        {
            Random ran = new Random();
            string sql = "update [Member] set ViewCount=ViewCount+" + ran.Next(3, 6) + " where Id=" + id.ToString();
            SqlHelper.ExecuteNonQuery(sql);

            //test
            //DAL.a.Add(new Model.a() { addtime = DateTime.Now, content = sql });
        }
	}
}



