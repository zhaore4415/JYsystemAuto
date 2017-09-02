using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// WaiChuZhen
    /// </summary>
    public partial class WaiChuZhen
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

        private string _haoma;

        /// <summary>
        /// 外出证号码
        /// </summary>
        public string Haoma
        {
            get { return _haoma; }
            set { _haoma = value; }
        }

        private string _yqhaoma;

        /// <summary>
        /// 外出证延期后号码
        /// </summary>
        public string YQhaoma
        {
            get { return _yqhaoma; }
            set { _yqhaoma = value; }
        }

        private decimal? _outmoney;

        /// <summary>
        /// 外出证金额
        /// </summary>
        public decimal? OutMoney
        {
            get { return _outmoney; }
            set { _outmoney = value; }
        }

        private string _outdate;

        /// <summary>
        /// 外出证开出日期
        /// </summary>
        public string OutDate
        {
            get { return _outdate; }
            set { _outdate = value; }
        }

        private string _maturitydate;

        /// <summary>
        /// 外出证到期日期
        /// </summary>
        public string MaturityDate
        {
            get { return _maturitydate; }
            set { _maturitydate = value; }
        }

        private int _fid = Int32.MinValue;

        /// <summary>
        /// 工程收费,发票,收据,外出 与总表共享ID
        /// </summary>
        public int Fid
        {
            get { return _fid; }
            set { _fid = value; }
        }

        private string _outyqdate;

        /// <summary>
        /// 外出证延期日期
        /// </summary>
        public string OutYQDate
        {
            get { return _outyqdate; }
            set { _outyqdate = value; }
        }

        private string _maturitytydate;

        /// <summary>
        /// 外出证延期后到期日期
        /// </summary>
        public string MaturityTYDate
        {
            get { return _maturitytydate; }
            set { _maturitytydate = value; }
        }

        private decimal? _outyqmoney;

        /// <summary>
        /// 延期后外出证金额
        /// </summary>
        public decimal? OutYQMoney
        {
            get { return _outyqmoney; }
            set { _outyqmoney = value; }
        }

        private string _remark;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

    }
}

