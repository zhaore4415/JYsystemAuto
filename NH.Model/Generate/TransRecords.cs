using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// TransRecords
    /// </summary>
    public partial class TransRecords
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

        private int _companyid = Int32.MinValue;

        /// <summary>
        /// CompanyId
        /// </summary>
        public int CompanyId
        {
            get { return _companyid; }
            set { _companyid = value; }
        }

        private int _transtype = Int32.MinValue;

        /// <summary>
        /// 交易类型
        /// </summary>
        public int TransType
        {
            get { return _transtype; }
            set { _transtype = value; }
        }

        private decimal _changeamount = Decimal.MinValue;

        /// <summary>
        /// 变化金额
        /// </summary>
        public decimal ChangeAmount
        {
            get { return _changeamount; }
            set { _changeamount = value; }
        }

        private decimal _balance = Decimal.MinValue;

        /// <summary>
        /// 变化后帐户余额
        /// </summary>
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        private string _remark;

        /// <summary>
        /// Remark
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
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

        private int _addusertype = Int32.MinValue;

        /// <summary>
        /// 操作人类型 1：企业，2客服
        /// </summary>
        public int AddUserType
        {
            get { return _addusertype; }
            set { _addusertype = value; }
        }

        private int _adduserid = Int32.MinValue;

        /// <summary>
        /// 操作人ID
        /// </summary>
        public int AddUserId
        {
            get { return _adduserid; }
            set { _adduserid = value; }
        }

    }
}

