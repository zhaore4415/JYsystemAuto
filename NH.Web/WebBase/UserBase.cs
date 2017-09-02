using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using Maticsoft.Common;

namespace NH.Web
{
    public class UserBase
    {
        static string _CurrentUser = "CurrentUser";
        static string _CurMember = "CurMember";
        public static string _CurCompany = "CurCompany";
        static string _AdminUser = "AdminUser";
        //static string accounting = "accounting";
        static List<Model.OnlineMemberModel> _memberList;

        #region 属性
        public static bool IsLogin
        {
            get { return Current != null ? true : false; }
        }

        /// <summary>
        /// 个人是否登录
        /// </summary>
        public static bool IsPersonLogin
        {
            get { return CurMember != null ? true : false; }
        }

        ///// <summary>
        ///// 企业是否登录
        ///// </summary>
        //public static bool IsCompanyLogin
        //{
        //    get { return CurCompany != null ? true : false; }
        //}

        /// <summary>
        /// 管理员是否登录
        /// </summary>
        public static bool IsAdminLogin
        {
            get { return CurAdmin != null ? true : false; }
        }

        public static List<Model.OnlineMemberModel> OnlineUsers
        {
            get
            {
                if (_memberList == null)
                {
                    _memberList = new List<Model.OnlineMemberModel>();
                }
                return _memberList;
            }
        }
        #endregion

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="errorFlag">1登录成功，2用户名不存在，3密码错误，4已禁用</param>
        /// <returns></returns>
        public static bool Login(string username, string password, out int errorFlag)
        {
            Model.User model = new Model.User();
            model.LoginName = username;
            //model.Password = DESEncrypt.Encrypt(password);
            //model.Status = 1;

            model = BLL.User.GetModel(model);

            if (model == null)
            {
                errorFlag = 2;//用户名不存在
                return false;
            }
            else if (model.Password != DESEncrypt.Encrypt(password))
            {
                errorFlag = 3;//密码错误
                return false;
            }
            else if (model.Status != 1)
            {
                errorFlag = 4;//已禁用
                return false;
            }
            else
            {
                //LogOut();

                #region
                string userData = "Member";
               
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.Id.ToString(), DateTime.Now, DateTime.Now.AddHours(5), false, userData);
                //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.Id.ToString(), DateTime.Now, DateTime.Now.AddMinutes(1), false, userData);
                string hashTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket); //生成Cookie 
                HttpContext.Current.Response.Cookies.Add(userCookie); //输出Cookie 

                HttpContext.Current.Session[_CurrentUser] = model;//注意是 一般处理程序时引用IRequiresSessionState 接口

                errorFlag = 1;//登录成功

                BLL.User.Update(new Model.User() { Id=model.Id,SessionId=HttpContext.Current.Session.SessionID});

                //AddMemberToOnline(username);

                return true;
                #endregion

                #region
                /*
                string userData = "";//Admin,Company,Member
                string userDataFmt = "{0},{1},{2}";
                
                string uids = null;
                string uidsFmt = "{0},{1},{2}";//AdminId,CompanyId,MemberId

                string[] arryUids = HttpContext.Current.User.Identity.Name.Split(','); //User.Identity.Name.Split(',');
                string adminId = arryUids[0];
                string companyId = "";
                string memberId = "";

                switch (model.UserType)
                {
                    case (int)Model.Enums.UserType.Company:
                        userData = string.Format(userDataFmt,(IsAdminLogin ? "Admin":""),"Company",(IsPersonLogin ? "Member":""));
                        companyId = model.Id.ToString();
                        try
                        {
                            memberId = arryUids[2];
                        }
                        catch { }
                        break;
                    case (int)Model.Enums.UserType.Member:
                        userData = string.Format(userDataFmt, (IsAdminLogin ? "Admin" : ""), (IsCompanyLogin ? "Company" : ""), "Member");
                        memberId = model.Id.ToString();
                        try
                        {
                            companyId = arryUids[1];
                        }
                        catch { }
                        break;
                }
                uids = string.Format(uidsFmt, adminId, companyId, memberId);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, uids, DateTime.Now, DateTime.Now.AddHours(5), false, userData);
                string hashTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket); //生成Cookie 
                HttpContext.Current.Response.Cookies.Add(userCookie); //输出Cookie 

                HttpContext.Current.Session[_CurrentUser] = model;
                return true;
                */
                #endregion
            }
        }
        #endregion

        #region 管理员登录
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool AdminLogin(string username, string password)
        {
            Model.AUser model = new Model.AUser();
            model.LoginName = username;
            model.Password = DESEncrypt.Encrypt(password);
            //model.Status = 1;

            model = BLL.AUser.GetModelWithFunCode(model);

            if (model == null)
            {
                return false;
            }
            else
            {
                #region
                string userData = "Admin";
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.Id.ToString(), DateTime.Now, DateTime.Now.AddHours(5), false, userData);
                string hashTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket); //生成Cookie 
                HttpContext.Current.Response.Cookies.Add(userCookie); //输出Cookie 

                HttpContext.Current.Session[_AdminUser] = model;
                return true;
                #endregion

                #region
                /*
                string userData = null;//Admin,Company,Member
                string userDataFmt = "{0},{1},{2}";

                string uids = null;
                string uidsFmt = "{0},{1},{2}";//AdminId,CompanyId,MemberId

                string[] arryUids = HttpContext.Current.User.Identity.Name.Split(','); //User.Identity.Name.Split(',');
                string adminId = arryUids[0];
                string companyId = "";
                string memberId = "";

                userData = string.Format(userDataFmt,"Admin",(IsCompanyLogin ? "Company" : ""),(IsPersonLogin ? "Member":""));
                try
                {
                    companyId = arryUids[1];
                }
                catch { }
                try
                {
                    memberId = arryUids[2];
                }
                catch { }
                uids = string.Format(uidsFmt,adminId,companyId,memberId);

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, uids, DateTime.Now, DateTime.Now.AddHours(5), false, userData);
                string hashTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket); //生成Cookie 
                HttpContext.Current.Response.Cookies.Add(userCookie); //输出Cookie 

                HttpContext.Current.Session[_AdminUser] = model;
                return true;
                */
                #endregion
            }
        }
        #endregion

        #region 退出
        /// <summary>
        /// 退出
        /// </summary>
        public static void LogOut()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.RemoveAll();
        }
        #endregion

        #region 当前登录的用户信息
        /// <summary>
        /// 用户实体
        /// </summary>
        public static Model.User Current
        {
            get
            {
                HttpContext httpContext = HttpContext.Current;
                HttpSessionState session = httpContext.Session;

                if (session[_CurrentUser] == null)
                {
                    if (httpContext.User.Identity.Name != string.Empty && (httpContext.User.IsInRole("Member") || httpContext.User.IsInRole("Company")))
                    {
                        int id = int.Parse(httpContext.User.Identity.Name);
                        session[_CurrentUser] = BLL.User.GetModel(id);
                    }
                }
                return (Model.User)session[_CurrentUser];
            }
        }
        #endregion

        #region 当前的人才会员信息
        /// <summary>
        /// 当前的人才会员信息
        /// </summary>
        public static Model.Member CurMember
        {
            get
            {
                HttpContext httpContext = HttpContext.Current;
                HttpSessionState session = httpContext.Session;

                if (IsLogin)
                {
                    if (session[_CurMember] == null)
                    {
                        session[_CurMember] = BLL.Member.GetModel(Current.Id);
                    }
                }
                return (Model.Member)session[_CurMember];
            }
        }
        #endregion

        #region 刷新当前个人用户信息
        /// <summary>
        /// 刷新当前个人用户信息
        /// </summary>
        public static void RefreshCurMember()
        {
            HttpContext httpContext = HttpContext.Current;
            HttpSessionState session = httpContext.Session;
            if (session[_CurMember] != null)
            {
                session.Remove(_CurMember);
            }
            RefreshCurUser();
        }
        #endregion

        #region 刷新当前用户信息
        /// <summary>
        /// 刷新当前用户信息
        /// </summary>
        public static void RefreshCurUser()
        {
            HttpContext httpContext = HttpContext.Current;
            HttpSessionState session = httpContext.Session;
            if (session[_CurrentUser] != null)
            {
                session.Remove(_CurrentUser);
            }
        }
        #endregion

    

        #region 当前的管理员信息
        /// <summary>
        /// 当前的管理员信息
        /// </summary>
        public static Model.AUser CurAdmin
        {
            get
            {
                HttpContext httpContext = HttpContext.Current;
                HttpSessionState session = httpContext.Session;

                if (session[_AdminUser] == null)
                {
                    if (httpContext.User.Identity.Name != string.Empty && httpContext.User.IsInRole("Admin"))
                    {
                        int id = int.Parse(httpContext.User.Identity.Name);
                        Model.AUser model = new Model.AUser() { Id = id };
                        session[_AdminUser] = BLL.AUser.GetModelWithFunCode(model);
                    }
                }
                return (Model.AUser)session[_AdminUser];
            }
        }
        #endregion


        #region 当前税率集合
        /// <summary>
        /// 当前税率集合
        /// </summary>
        public static Model.Accounting Enginee
        {
            get
            {
                HttpContext httpContext = HttpContext.Current;
                HttpSessionState session = httpContext.Session;

                //if (session[engineering] == null)
                //{

                //    int id = int.Parse(httpContext.User.Identity.Name);
                //        Model.Engineering model = new Model.Engineering() { Id = id };
                //        session[engineering] = BLL.Engineering.GetModel(model);
                  
                //}
                return (Model.Accounting)session["accounting"];
            }
        }
        #endregion

        #region 刷新当前管理员信息
        /// <summary>
        /// 刷新当前管理员信息
        /// </summary>
        public static void RefreshCurAdmin()
        {
            HttpContext httpContext = HttpContext.Current;
            HttpSessionState session = httpContext.Session;
            if (session[_AdminUser] != null)
            {
                session.Remove(_AdminUser);
            }
        }
        #endregion




        #region 在线用户
        public static bool AddMemberToOnline(string loginname)
        {
            if (_memberList == null)
            {
                _memberList = new List<Model.OnlineMemberModel>();
            }

            Model.OnlineMemberModel temp = _memberList.Find(el => el.loginName.ToLower() == loginname.ToLower());
            if (temp != null)
            {
                temp.sessionId = HttpContext.Current.Session.SessionID;
                temp.refreshTime = DateTime.Now;
            }
            else
            {
                Model.OnlineMemberModel model = new Model.OnlineMemberModel();
                model.loginName = loginname;
                model.refreshTime = DateTime.Now;
                model.sessionId = HttpContext.Current.Session.SessionID;
                _memberList.Add(model);
            }
            return true;
        }

        /*
        /// <summary>
        /// 当前用户是否在线
        /// </summary>
        public static bool IsUserOnline
        {
            get
            {
                if (!IsLogin) return false;
                if (_memberList == null)
                {
                    //_memberList = new List<Model.OnlineMemberModel>();
                    AddMemberToOnline(Current.LoginName);
                    return true;
                }
                else
                {
                    Model.OnlineMemberModel temp = _memberList.Find(el => el.loginName.ToLower() == Current.LoginName.ToLower());
                    if (temp != null)
                    {
                        if (temp.sessionId == HttpContext.Current.Session.SessionID)
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        */






        /// <summary>
        /// 当前用户是否在线
        /// </summary>
        public static bool IsUserOnline
        {
            get
            {
                if (!IsLogin) return false;
                
                return HttpContext.Current.Session.SessionID.ToLower() == BLL.User.GetSessionId(Current.Id);
                
            }
        }
        #endregion
    }
}