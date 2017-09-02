using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// Bill
    /// </summary>
    public partial class Bill
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

        private string _buyers;

        /// <summary>
        /// 买家会员名/商品ID
        /// </summary>
        public string Buyers
        {
            get { return _buyers; }
            set { _buyers = value; }
        }

        private string _buyerpayspoints;

        /// <summary>
        /// 买家支付积分
        /// </summary>
        public string Buyerpayspoints
        {
            get { return _buyerpayspoints; }
            set { _buyerpayspoints = value; }
        }

        private int? _paymentmethod;

        /// <summary>
        /// 0为微信，1为支付宝支付
        /// </summary>
        public int? PaymentMethod
        {
            get { return _paymentmethod; }
            set { _paymentmethod = value; }
        }

        private decimal? _amount;

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal? Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private decimal? _oneamount;

        /// <summary>
        /// 一级会员提成
        /// </summary>
        public decimal? OneAmount
        {
            get { return _oneamount; }
            set { _oneamount = value; }
        }

        private decimal? _towamount;

        /// <summary>
        /// 二级会员提成
        /// </summary>
        public decimal? TowAmount
        {
            get { return _towamount; }
            set { _towamount = value; }
        }
        private long? _ordernumber;

        /// <summary>
        /// 订单号
        /// </summary>
        public long? OrderNumber
        {
            get { return _ordernumber; }
            set { _ordernumber = value; }
        }

        private string _expressorder;

        /// <summary>
        /// 物流单号
        /// </summary>
        public string ExpressOrder
        {
            get { return _expressorder; }
            set { _expressorder = value; }
        }

        private string _couriercompanies;

        /// <summary>
        /// 物流公司
        /// </summary>
        public string Couriercompanies
        {
            get { return _couriercompanies; }
            set { _couriercompanies = value; }
        }

        private string _realname;

        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string Realname
        {
            get { return _realname; }
            set { _realname = value; }
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

        private string _tel;

        /// <summary>
        /// 联系电话 
        /// </summary>
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        private string _phone;

        /// <summary>
        /// 联系手机
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _companyname;

        /// <summary>
        /// 公司名
        /// </summary>
        public string CompanyName
        {
            get { return _companyname; }
            set { _companyname = value; }
        }

        private string _address;

        /// <summary>
        /// 收货地址
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _description;

        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private DateTime? _addtime;

        /// <summary>
        /// AddTime
        /// </summary>
        public DateTime? AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        private DateTime? _deliverytime;

        /// <summary>
        /// 订单付款时间
        /// </summary>
        public DateTime? DeliveryTime
        {
            get { return _deliverytime; }
            set { _deliverytime = value; }
        }

        private DateTime? _arrivaltime;

        /// <summary>
        /// ArrivalTime
        /// </summary>
        public DateTime? ArrivalTime
        {
            get { return _arrivaltime; }
            set { _arrivaltime = value; }
        }

        private string _status;

        /// <summary>
        /// 订单状态，0为未支付，1为支付
        /// </summary>
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _remark;

        /// <summary>
        /// 订单备注
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private int? _babynumber;

        /// <summary>
        /// 宝贝总数量
        /// </summary>
        public int? Babynumber
        {
            get { return _babynumber; }
            set { _babynumber = value; }
        }

        private string _pid;

        /// <summary>
        /// 包含的产品ID
        /// </summary>
        public string Pid
        {
            get { return _pid; }
            set { _pid = value; }
        }

        private int? _type;

        /// <summary>
        /// 0为京东，1为天猫，2为1号店，10为其它...
        /// </summary>
        public int? Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _barcode;

        /// <summary>
        /// 产品服务编号
        /// </summary>
        public string Barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }

        private long? _qdid;

        /// <summary>
        /// QdId
        /// </summary>
        public long? QdId
        {
            get { return _qdid; }
            set { _qdid = value; }
        }

        private int? _u_id;

        /// <summary>
        /// 用户名ID
        /// </summary>
        public int? U_ID
        {
            get { return _u_id; }
            set { _u_id = value; }
        }

        private int? _province;

        /// <summary>
        /// 省
        /// </summary>
        public int? province
        {
            get { return _province; }
            set { _province = value; }
        }

        private int? _city;

        /// <summary>
        /// 市
        /// </summary>
        public int? city
        {
            get { return _city; }
            set { _city = value; }
        }

        private int? _area;

        /// <summary>
        /// 区
        /// </summary>
        public int? area
        {
            get { return _area; }
            set { _area = value; }
        }

    }
}

