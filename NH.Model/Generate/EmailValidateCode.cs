using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// EmailValidateCode
    /// </summary>
    public partial class EmailValidateCode
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

        private int _userid = Int32.MinValue;

        /// <summary>
        /// UserId
        /// </summary>
        public int UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }

        private string _loginname;

        /// <summary>
        /// Loginname
        /// </summary>
        public string Loginname
        {
            get { return _loginname; }
            set { _loginname = value; }
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

        private string _code;

        /// <summary>
        /// Code
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private DateTime _addtime = DateTime.MinValue;

        /// <summary>
        /// AddTime
        /// </summary>
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        private bool? _status;

        /// <summary>
        /// Status
        /// </summary>
        public bool? Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int _codetype = Int32.MinValue;

        /// <summary>
        /// CodeType
        /// </summary>
        public int CodeType
        {
            get { return _codetype; }
            set { _codetype = value; }
        }

    }
}

