using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// Company
    /// </summary>
    public partial class Company
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

        private string _companyname;

        /// <summary>
        /// CompanyName
        /// </summary>
        public string CompanyName
        {
            get { return _companyname; }
            set { _companyname = value; }
        }

        private string _contact;

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }

        private string _areaid;

        /// <summary>
        /// 地区编号
        /// </summary>
        public string AreaID
        {
            get { return _areaid; }
            set { _areaid = value; }
        }

        private string _area;

        /// <summary>
        /// 地区名称
        /// </summary>
        public string Area
        {
            get { return _area; }
            set { _area = value; }
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

        private string _qq;

        /// <summary>
        /// QQ
        /// </summary>
        public string QQ
        {
            get { return _qq; }
            set { _qq = value; }
        }

        private string _phone;

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _otherphone;

        /// <summary>
        /// OtherPhone
        /// </summary>
        public string OtherPhone
        {
            get { return _otherphone; }
            set { _otherphone = value; }
        }

        private string _address;

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _homepage;

        /// <summary>
        /// 企业网址
        /// </summary>
        public string HomePage
        {
            get { return _homepage; }
            set { _homepage = value; }
        }

        private string _space;

        /// <summary>
        /// 营业面积
        /// </summary>
        public string Space
        {
            get { return _space; }
            set { _space = value; }
        }

        private string _employeeqty;

        /// <summary>
        /// EmployeeQty
        /// </summary>
        public string EmployeeQty
        {
            get { return _employeeqty; }
            set { _employeeqty = value; }
        }

        private string _camera;

        /// <summary>
        /// 相机型号及数量
        /// </summary>
        public string Camera
        {
            get { return _camera; }
            set { _camera = value; }
        }

        private string _studio;

        /// <summary>
        /// 影棚数量
        /// </summary>
        public string Studio
        {
            get { return _studio; }
            set { _studio = value; }
        }

        private string _description;

        /// <summary>
        /// 企业简介
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private bool? _identityverified;

        /// <summary>
        /// 是否实名认证
        /// </summary>
        public bool? IdentityVerified
        {
            get { return _identityverified; }
            set { _identityverified = value; }
        }

        private int _levelid = Int32.MinValue;

        /// <summary>
        /// 等级
        /// </summary>
        public int LevelID
        {
            get { return _levelid; }
            set { _levelid = value; }
        }

        private int _verifystatus = Int32.MinValue;

        /// <summary>
        /// 新注册是否已审核:0未审核，1审核通过，-1审核不通过
        /// </summary>
        public int VerifyStatus
        {
            get { return _verifystatus; }
            set { _verifystatus = value; }
        }

        private DateTime? _expiredate;

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime? ExpireDate
        {
            get { return _expiredate; }
            set { _expiredate = value; }
        }

        private int _viewcount = Int32.MinValue;

        /// <summary>
        /// 浏览量
        /// </summary>
        public int ViewCount
        {
            get { return _viewcount; }
            set { _viewcount = value; }
        }

        private bool? _isverify;

        /// <summary>
        /// 是否需要审核
        /// </summary>
        public bool? IsVerify
        {
            get { return _isverify; }
            set { _isverify = value; }
        }

        private int _vipopentype = Int32.MinValue;

        /// <summary>
        /// VIP开通方式：1人工操作，2在线支付自助开通
        /// </summary>
        public int VipOpenType
        {
            get { return _vipopentype; }
            set { _vipopentype = value; }
        }

        private DateTime? _jobrefreshtime;

        /// <summary>
        /// 最后置顶职位的时间
        /// </summary>
        public DateTime? JobRefreshTime
        {
            get { return _jobrefreshtime; }
            set { _jobrefreshtime = value; }
        }

        private bool? _isstandard;

        /// <summary>
        /// 正规企业认证
        /// </summary>
        public bool? IsStandard
        {
            get { return _isstandard; }
            set { _isstandard = value; }
        }

        private bool? _isfoodadd;

        /// <summary>
        /// 餐补
        /// </summary>
        public bool? IsFoodAdd
        {
            get { return _isfoodadd; }
            set { _isfoodadd = value; }
        }

        private bool? _isofferroom;

        /// <summary>
        /// 包住
        /// </summary>
        public bool? IsOfferRoom
        {
            get { return _isofferroom; }
            set { _isofferroom = value; }
        }

        private bool? _isofferfood;

        /// <summary>
        /// 包吃
        /// </summary>
        public bool? IsOfferFood
        {
            get { return _isofferfood; }
            set { _isofferfood = value; }
        }

        private bool? _isfiveinsurance;

        /// <summary>
        /// 五险
        /// </summary>
        public bool? IsFiveInsurance
        {
            get { return _isfiveinsurance; }
            set { _isfiveinsurance = value; }
        }

        private bool? _isfund;

        /// <summary>
        /// 一金
        /// </summary>
        public bool? IsFund
        {
            get { return _isfund; }
            set { _isfund = value; }
        }

        private bool? _iscarfare;

        /// <summary>
        /// 车费报销
        /// </summary>
        public bool? IsCarFare
        {
            get { return _iscarfare; }
            set { _iscarfare = value; }
        }

        private bool? _isyearguarantee;

        /// <summary>
        /// 年度保障优质企业
        /// </summary>
        public bool? IsYearGuarantee
        {
            get { return _isyearguarantee; }
            set { _isyearguarantee = value; }
        }

        private decimal _balance = Decimal.MinValue;

        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        private bool? _isreceive;

        /// <summary>
        /// 是否接站
        /// </summary>
        public bool? IsReceive
        {
            get { return _isreceive; }
            set { _isreceive = value; }
        }

        private DateTime? _receiveendtime;

        /// <summary>
        /// 最后接站日期
        /// </summary>
        public DateTime? ReceiveEndTime
        {
            get { return _receiveendtime; }
            set { _receiveendtime = value; }
        }

        private string _receiveaddress;

        /// <summary>
        /// 接站地点
        /// </summary>
        public string ReceiveAddress
        {
            get { return _receiveaddress; }
            set { _receiveaddress = value; }
        }

        private int _totalsignup = Int32.MinValue;

        /// <summary>
        /// 总报名数
        /// </summary>
        public int TotalSignUp
        {
            get { return _totalsignup; }
            set { _totalsignup = value; }
        }

        private int _cursignup = Int32.MinValue;

        /// <summary>
        /// 本批报名数
        /// </summary>
        public int CurSignUp
        {
            get { return _cursignup; }
            set { _cursignup = value; }
        }

        private int _receivetimes = Int32.MinValue;

        /// <summary>
        /// 已接站次数
        /// </summary>
        public int ReceiveTimes
        {
            get { return _receivetimes; }
            set { _receivetimes = value; }
        }

        private string _logo;

        /// <summary>
        /// Logo
        /// </summary>
        public string Logo
        {
            get { return _logo; }
            set { _logo = value; }
        }

    }
}

