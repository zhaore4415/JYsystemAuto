using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// Staff
    /// </summary>
    public partial class Staff
    {

        private int _id = Int32.MinValue;

        /// <summary>
        /// Id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _loginname;

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName
        {
            get { return _loginname; }
            set { _loginname = value; }
        }

        private string _password;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _realname;

        /// <summary>
        /// Realname
        /// </summary>
        public string Realname
        {
            get { return _realname; }
            set { _realname = value; }
        }

        private DateTime _addtime = DateTime.MinValue;

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        private int _status = Int32.MinValue;

        /// <summary>
        /// 状态：1正常，0禁用，-1删除
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private DateTime _logintime = DateTime.MinValue;

        /// <summary>
        /// 本次登录时间
        /// </summary>
        public DateTime LoginTime
        {
            get { return _logintime; }
            set { _logintime = value; }
        }

        private string _loginip;

        /// <summary>
        /// 本次登录IP
        /// </summary>
        public string LoginIP
        {
            get { return _loginip; }
            set { _loginip = value; }
        }

        private string _loginaddress;

        /// <summary>
        /// 本次登录地点
        /// </summary>
        public string LoginAddress
        {
            get { return _loginaddress; }
            set { _loginaddress = value; }
        }

        private DateTime _lastlogintime = DateTime.MinValue;

        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime LastLoginTime
        {
            get { return _lastlogintime; }
            set { _lastlogintime = value; }
        }

        private string _lastip;

        /// <summary>
        /// 上次登录IP
        /// </summary>
        public string LastIP
        {
            get { return _lastip; }
            set { _lastip = value; }
        }

        private string _lastaddress;

        /// <summary>
        /// 上次登录地点
        /// </summary>
        public string LastAddress
        {
            get { return _lastaddress; }
            set { _lastaddress = value; }
        }

        private int _logincount = Int32.MinValue;

        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginCount
        {
            get { return _logincount; }
            set { _logincount = value; }
        }

        private DateTime _updatetime = DateTime.MinValue;

        /// <summary>
        /// UpdateTime
        /// </summary>
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }

        private int? _roletype;

        /// <summary>
        /// 角色类型：0普通角色，1超级管理员
        /// </summary>
        public int? RoleType
        {
            get { return _roletype; }
            set { _roletype = value; }
        }

        private string _phone;

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _email;

        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _address;

        /// <summary>
        /// Address
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _data1;

        /// <summary>
        /// 上班时间
        /// </summary>
        public string Data1
        {
            get { return _data1; }
            set { _data1 = value; }
        }

        private string _data2;

        /// <summary>
        /// 下班时间
        /// </summary>
        public string Data2
        {
            get { return _data2; }
            set { _data2 = value; }
        }

        private int? _datatype1;

        /// <summary>
        /// 0为正常，1为迟到
        /// </summary>
        public int? DataType1
        {
            get { return _datatype1; }
            set { _datatype1 = value; }
        }

        private int? _datatype2;

        /// <summary>
        /// 0为正常，1为早退
        /// </summary>
        public int? DataType2
        {
            get { return _datatype2; }
            set { _datatype2 = value; }
        }

        private string _worknumber;

        /// <summary>
        /// 工号
        /// </summary>
        public string WorkNumber
        {
            get { return _worknumber; }
            set { _worknumber = value; }
        }

        private string _todaydate;

        /// <summary>
        /// 当前日期
        /// </summary>
        public string TodayDate
        {
            get { return _todaydate; }
            set { _todaydate = value; }
        }

    }
}

