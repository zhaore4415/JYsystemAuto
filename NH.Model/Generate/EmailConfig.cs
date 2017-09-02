using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// EmailConfig
    /// </summary>
    public partial class EmailConfig
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

        private string _server;

        /// <summary>
        /// smtp服务器
        /// </summary>
        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }

        private string _account;

        /// <summary>
        /// 发送账号
        /// </summary>
        public string Account
        {
            get { return _account; }
            set { _account = value; }
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

        private string _sender;

        /// <summary>
        /// Sender
        /// </summary>
        public string Sender
        {
            get { return _sender; }
            set { _sender = value; }
        }

        private bool? _authentication;

        /// <summary>
        /// 是否验证
        /// </summary>
        public bool? Authentication
        {
            get { return _authentication; }
            set { _authentication = value; }
        }

        private bool? _enablessl;

        /// <summary>
        /// 是否使用SSL
        /// </summary>
        public bool? EnableSsl
        {
            get { return _enablessl; }
            set { _enablessl = value; }
        }

        private string _port;

        /// <summary>
        /// 端口号
        /// </summary>
        public string Port
        {
            get { return _port; }
            set { _port = value; }
        }

        private bool? _isshow;

        /// <summary>
        /// 1开启，0关闭
        /// </summary>
        public bool? IsShow
        {
            get { return _isshow; }
            set { _isshow = value; }
        }

    }
}

