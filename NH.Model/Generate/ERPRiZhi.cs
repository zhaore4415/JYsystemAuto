using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// ERPRiZhi
    /// </summary>
    public partial class ERPRiZhi
    {

        private int _id = Int32.MinValue;

        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _username;

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        private DateTime? _timestr;

        /// <summary>
        /// TimeStr
        /// </summary>
        public DateTime? TimeStr
        {
            get { return _timestr; }
            set { _timestr = value; }
        }

        private string _dosomething;

        /// <summary>
        /// DoSomething
        /// </summary>
        public string DoSomething
        {
            get { return _dosomething; }
            set { _dosomething = value; }
        }

        private string _ipstr;

        /// <summary>
        /// IpStr
        /// </summary>
        public string IpStr
        {
            get { return _ipstr; }
            set { _ipstr = value; }
        }

    }
}

