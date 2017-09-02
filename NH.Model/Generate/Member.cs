using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// Member
    /// </summary>
    public partial class Member
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

        private string _realname;

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Realname
        {
            get { return _realname; }
            set { _realname = value; }
        }

        private int _sex = Int32.MinValue;

        /// <summary>
        /// 性别：-1保密，0女，1男
        /// </summary>
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        private DateTime? _birthday;

        /// <summary>
        /// Birthday
        /// </summary>
        public DateTime? Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        private int _height = Int32.MinValue;

        /// <summary>
        /// 身高(厘米)
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private int _marriage = Int32.MinValue;

        /// <summary>
        /// 婚姻状况：-1保密，0未婚，1已婚，2离异，3丧偶
        /// </summary>
        public int Marriage
        {
            get { return _marriage; }
            set { _marriage = value; }
        }

        private string _residenceaddrid;

        /// <summary>
        /// 户口所在地(存地区编号)
        /// </summary>
        public string ResidenceAddrID
        {
            get { return _residenceaddrid; }
            set { _residenceaddrid = value; }
        }

        private string _residence;

        /// <summary>
        /// 户口所在地(存地区名称)
        /// </summary>
        public string Residence
        {
            get { return _residence; }
            set { _residence = value; }
        }

        private string _curraddrid;

        /// <summary>
        /// 当前所在地(地区id)
        /// </summary>
        public string CurrAddrID
        {
            get { return _curraddrid; }
            set { _curraddrid = value; }
        }

        private string _curaddr;

        /// <summary>
        /// 现所在地(存地区名称，文本)
        /// </summary>
        public string CurAddr
        {
            get { return _curaddr; }
            set { _curaddr = value; }
        }

        private int _experienceid = Int32.MinValue;

        /// <summary>
        /// 工作年限id：-1未填写
        /// </summary>
        public int ExperienceID
        {
            get { return _experienceid; }
            set { _experienceid = value; }
        }

        private int _degreeid = Int32.MinValue;

        /// <summary>
        /// 学历ID
        /// </summary>
        public int DegreeID
        {
            get { return _degreeid; }
            set { _degreeid = value; }
        }

        private string _degreename;

        /// <summary>
        /// DegreeName
        /// </summary>
        public string DegreeName
        {
            get { return _degreename; }
            set { _degreename = value; }
        }

        private string _mobile;

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        private bool? _mobileverified;

        /// <summary>
        /// 手机是否已验证
        /// </summary>
        public bool? MobileVerified
        {
            get { return _mobileverified; }
            set { _mobileverified = value; }
        }

        private string _phone;

        /// <summary>
        /// 座机号码
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
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

        private string _email;

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _address;

        /// <summary>
        /// Address
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _homepage;

        /// <summary>
        /// 个人主页
        /// </summary>
        public string HomePage
        {
            get { return _homepage; }
            set { _homepage = value; }
        }

        private int _ishousing = Int32.MinValue;

        /// <summary>
        /// 是否提供食宿：-1面议，0不需要，1需要
        /// </summary>
        public int IsHousing
        {
            get { return _ishousing; }
            set { _ishousing = value; }
        }

        private int _iscarfare = Int32.MinValue;

        /// <summary>
        /// 是否报销路费：-1，面议；0不需要；1需要
        /// </summary>
        public int IsCarFare
        {
            get { return _iscarfare; }
            set { _iscarfare = value; }
        }

        private string _jobcategoryids;

        /// <summary>
        /// 希望职责(类别id,多个用逗号分隔)
        /// </summary>
        public string JobCategoryIDs
        {
            get { return _jobcategoryids; }
            set { _jobcategoryids = value; }
        }

        private string _jobcategoryname;

        /// <summary>
        /// 希望的工作岗位类别(存名称)
        /// </summary>
        public string JobCategoryName
        {
            get { return _jobcategoryname; }
            set { _jobcategoryname = value; }
        }

        private int _salaryid = Int32.MinValue;

        /// <summary>
        /// 薪酬
        /// </summary>
        public int SalaryID
        {
            get { return _salaryid; }
            set { _salaryid = value; }
        }

        private string _salaryname;

        /// <summary>
        /// SalaryName
        /// </summary>
        public string SalaryName
        {
            get { return _salaryname; }
            set { _salaryname = value; }
        }

        private bool? _commission;

        /// <summary>
        /// 薪水是否要提成
        /// </summary>
        public bool? Commission
        {
            get { return _commission; }
            set { _commission = value; }
        }

        private string _jobtypeid;

        /// <summary>
        /// 工作类型，存id,多个用逗号分隔
        /// </summary>
        public string JobTypeID
        {
            get { return _jobtypeid; }
            set { _jobtypeid = value; }
        }

        private string _jobtypename;

        /// <summary>
        /// 工作类型(文字)
        /// </summary>
        public string JobTypeName
        {
            get { return _jobtypename; }
            set { _jobtypename = value; }
        }

        private string _jobaddrid;

        /// <summary>
        /// 期望的工作地区
        /// </summary>
        public string JobAddrID
        {
            get { return _jobaddrid; }
            set { _jobaddrid = value; }
        }

        private string _jobaddr;

        /// <summary>
        /// 期望的工作地区(文字)
        /// </summary>
        public string JobAddr
        {
            get { return _jobaddr; }
            set { _jobaddr = value; }
        }

        private string _resume;

        /// <summary>
        /// 个人简历
        /// </summary>
        public string Resume
        {
            get { return _resume; }
            set { _resume = value; }
        }

        private string _selfevaluation;

        /// <summary>
        /// 自我评价
        /// </summary>
        public string SelfEvaluation
        {
            get { return _selfevaluation; }
            set { _selfevaluation = value; }
        }

        private string _identityno;

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdentityNo
        {
            get { return _identityno; }
            set { _identityno = value; }
        }

        private bool? _identityverified;

        /// <summary>
        /// 是否已进行身份验证
        /// </summary>
        public bool? IdentityVerified
        {
            get { return _identityverified; }
            set { _identityverified = value; }
        }

        private bool? _isshow;

        /// <summary>
        /// 是否显示，1显示，0不显示
        /// </summary>
        public bool? IsShow
        {
            get { return _isshow; }
            set { _isshow = value; }
        }

        private int _viewcount = Int32.MinValue;

        /// <summary>
        /// 被查阅次数
        /// </summary>
        public int ViewCount
        {
            get { return _viewcount; }
            set { _viewcount = value; }
        }

        private int _workscount = Int32.MinValue;

        /// <summary>
        /// 作品数量
        /// </summary>
        public int WorksCount
        {
            get { return _workscount; }
            set { _workscount = value; }
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

        private bool? _isgood;

        /// <summary>
        /// 是否精英
        /// </summary>
        public bool? IsGood
        {
            get { return _isgood; }
            set { _isgood = value; }
        }

        private int _cometimeid = Int32.MinValue;

        /// <summary>
        /// 到岗时间
        /// </summary>
        public int ComeTimeID
        {
            get { return _cometimeid; }
            set { _cometimeid = value; }
        }

        private string _cometimedesc;

        /// <summary>
        /// 到岗时间
        /// </summary>
        public string ComeTimeDesc
        {
            get { return _cometimedesc; }
            set { _cometimedesc = value; }
        }

        private bool? _isverify;

        /// <summary>
        /// 是否有新资料需要审核
        /// </summary>
        public bool? IsVerify
        {
            get { return _isverify; }
            set { _isverify = value; }
        }

        private string _weixin;

        /// <summary>
        /// Weixin
        /// </summary>
        public string Weixin
        {
            get { return _weixin; }
            set { _weixin = value; }
        }

    }
}

