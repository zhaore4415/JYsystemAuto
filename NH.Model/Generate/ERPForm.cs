using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// ERPForm
    /// </summary>
    public partial class ERPForm
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

        private string _formname;

        /// <summary>
        /// FormName
        /// </summary>
        public string FormName
        {
            get { return _formname; }
            set { _formname = value; }
        }

        private string _formtype;

        /// <summary>
        /// FormType
        /// </summary>
        public string FormType
        {
            get { return _formtype; }
            set { _formtype = value; }
        }

        private string _shiyonguserlist;

        /// <summary>
        /// ShiYongUserList
        /// </summary>
        public string ShiYongUserList
        {
            get { return _shiyonguserlist; }
            set { _shiyonguserlist = value; }
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

        private string _username;

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _tiaojianlist;

        /// <summary>
        /// TiaoJianList
        /// </summary>
        public string TiaoJianList
        {
            get { return _tiaojianlist; }
            set { _tiaojianlist = value; }
        }

        private string _contentstr;

        /// <summary>
        /// ContentStr
        /// </summary>
        public string ContentStr
        {
            get { return _contentstr; }
            set { _contentstr = value; }
        }

    }
}

