using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// OnlinePayOrder
    /// </summary>
    public partial class OnlinePayOrder
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

        private string _orderno;

        /// <summary>
        /// 支付订单号
        /// </summary>
        public string OrderNo
        {
            get { return _orderno; }
            set { _orderno = value; }
        }

        private int _companyid = Int32.MinValue;

        /// <summary>
        /// 企业ID
        /// </summary>
        public int CompanyID
        {
            get { return _companyid; }
            set { _companyid = value; }
        }

        private string _companyname;

        /// <summary>
        /// 企业名称
        /// </summary>
        public string CompanyName
        {
            get { return _companyname; }
            set { _companyname = value; }
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

        private int _levelid = Int32.MinValue;

        /// <summary>
        /// 等级ID
        /// </summary>
        public int LevelId
        {
            get { return _levelid; }
            set { _levelid = value; }
        }

        private decimal _totalprice = Decimal.MinValue;

        /// <summary>
        /// 付款金额
        /// </summary>
        public decimal TotalPrice
        {
            get { return _totalprice; }
            set { _totalprice = value; }
        }

        private DateTime _addtime = DateTime.MinValue;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        private string _tradeno;

        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public string TradeNo
        {
            get { return _tradeno; }
            set { _tradeno = value; }
        }

        private DateTime? _tradetime;

        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime? TradeTime
        {
            get { return _tradetime; }
            set { _tradetime = value; }
        }

        private string _orderdesc;

        /// <summary>
        /// OrderDesc
        /// </summary>
        public string OrderDesc
        {
            get { return _orderdesc; }
            set { _orderdesc = value; }
        }

        private string _buyeremail;

        /// <summary>
        /// 付款人Email
        /// </summary>
        public string BuyerEmail
        {
            get { return _buyeremail; }
            set { _buyeremail = value; }
        }

        private string _contact;

        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }

        private int _status = Int32.MinValue;

        /// <summary>
        /// 状态：0未支付，1已支付
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private DateTime? _startdate;

        /// <summary>
        /// 会员开始日期
        /// </summary>
        public DateTime? StartDate
        {
            get { return _startdate; }
            set { _startdate = value; }
        }

        private DateTime? _enddate;

        /// <summary>
        /// 会员结束日期
        /// </summary>
        public DateTime? EndDate
        {
            get { return _enddate; }
            set { _enddate = value; }
        }

    }
}

