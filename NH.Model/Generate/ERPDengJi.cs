using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// ERPDengJi
    /// </summary>
    public partial class ERPDengJi
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

        private string _shenpiren;

        /// <summary>
        /// ShenPiRen
        /// </summary>
        public string ShenPiRen
        {
            get { return _shenpiren; }
            set { _shenpiren = value; }
        }

        private DateTime? _shenqingtime;

        /// <summary>
        /// ShenQingTime
        /// </summary>
        public DateTime? ShenQingTime
        {
            get { return _shenqingtime; }
            set { _shenqingtime = value; }
        }

        private string _backinfo;

        /// <summary>
        /// BackInfo
        /// </summary>
        public string BackInfo
        {
            get { return _backinfo; }
            set { _backinfo = value; }
        }

        private DateTime? _starttime;

        /// <summary>
        /// StartTime
        /// </summary>
        public DateTime? StartTime
        {
            get { return _starttime; }
            set { _starttime = value; }
        }

        private DateTime? _endtime;

        /// <summary>
        /// EndTime
        /// </summary>
        public DateTime? EndTime
        {
            get { return _endtime; }
            set { _endtime = value; }
        }

        private string _statenow;

        /// <summary>
        /// StateNow
        /// </summary>
        public string StateNow
        {
            get { return _statenow; }
            set { _statenow = value; }
        }

        private string _typename;

        /// <summary>
        /// TypeName
        /// </summary>
        public string TypeName
        {
            get { return _typename; }
            set { _typename = value; }
        }

    }
}

