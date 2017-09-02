using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// OnLineService
    /// </summary>
    public partial class OnLineService
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

        private string _title;

        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _account;

        /// <summary>
        /// Account
        /// </summary>
        public string Account
        {
            get { return _account; }
            set { _account = value; }
        }

        private int _sort = Int32.MinValue;

        /// <summary>
        /// Sort
        /// </summary>
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

        private bool? _isshow;

        /// <summary>
        /// IsShow
        /// </summary>
        public bool? IsShow
        {
            get { return _isshow; }
            set { _isshow = value; }
        }

        private int _accounttype = Int32.MinValue;

        /// <summary>
        /// 账号类型：1,QQ
        /// </summary>
        public int AccountType
        {
            get { return _accounttype; }
            set { _accounttype = value; }
        }

    }
}

