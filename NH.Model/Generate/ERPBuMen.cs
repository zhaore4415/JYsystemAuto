using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// ERPBuMen
    /// </summary>
    public partial class ERPBuMen
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

        private string _bumenname;

        /// <summary>
        /// BuMenName
        /// </summary>
        public string BuMenName
        {
            get { return _bumenname; }
            set { _bumenname = value; }
        }

        private string _chargeman;

        /// <summary>
        /// ChargeMan
        /// </summary>
        public string ChargeMan
        {
            get { return _chargeman; }
            set { _chargeman = value; }
        }

        private string _telstr;

        /// <summary>
        /// TelStr
        /// </summary>
        public string TelStr
        {
            get { return _telstr; }
            set { _telstr = value; }
        }

        private string _chuanzhen;

        /// <summary>
        /// ChuanZhen
        /// </summary>
        public string ChuanZhen
        {
            get { return _chuanzhen; }
            set { _chuanzhen = value; }
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

        private int? _dirid;

        /// <summary>
        /// DirID
        /// </summary>
        public int? DirID
        {
            get { return _dirid; }
            set { _dirid = value; }
        }

    }
}

