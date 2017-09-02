using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// Accounting
    /// </summary>
    public partial class Accounting
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

        private string _projectname;

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName
        {
            get { return _projectname; }
            set { _projectname = value; }
        }

        private string _projectnumber;

        /// <summary>
        /// 项目编号
        /// </summary>
        public string ProjectNumber
        {
            get { return _projectnumber; }
            set { _projectnumber = value; }
        }

        private string _projectmanager;

        /// <summary>
        /// 项目经理
        /// </summary>
        public string ProjectManager
        {
            get { return _projectmanager; }
            set { _projectmanager = value; }
        }

        private string _tel;

        /// <summary>
        /// Tel
        /// </summary>
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        private bool? _ifcompleted;

        /// <summary>
        /// 是否完工,0否，1是
        /// </summary>
        public bool? IfCompleted
        {
            get { return _ifcompleted; }
            set { _ifcompleted = value; }
        }

        private string _projectcategory;

        /// <summary>
        /// 工程类别
        /// </summary>
        public string ProjectCategory
        {
            get { return _projectcategory; }
            set { _projectcategory = value; }
        }

        private string _signingdate;

        /// <summary>
        /// 签订日期
        /// </summary>
        public string SigningDate
        {
            get { return _signingdate; }
            set { _signingdate = value; }
        }

        private decimal? _contractamount;

        /// <summary>
        /// 合同金额
        /// </summary>
        public decimal? ContractAmount
        {
            get { return _contractamount; }
            set { _contractamount = value; }
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

        private string _outno;

        /// <summary>
        /// 外出证号
        /// </summary>
        public string OutNo
        {
            get { return _outno; }
            set { _outno = value; }
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

        private bool? _isissuing;

        /// <summary>
        /// 是否开具外出证,0否，1是
        /// </summary>
        public bool? IsIssuing
        {
            get { return _isissuing; }
            set { _isissuing = value; }
        }

        private string _partyname;

        /// <summary>
        /// 甲方名称
        /// </summary>
        public string PartyName
        {
            get { return _partyname; }
            set { _partyname = value; }
        }

        private string _projectaddress;

        /// <summary>
        /// 工程地址
        /// </summary>
        public string ProjectAddress
        {
            get { return _projectaddress; }
            set { _projectaddress = value; }
        }

        private string _authorize;

        /// <summary>
        /// 授权
        /// </summary>
        public string Authorize
        {
            get { return _authorize; }
            set { _authorize = value; }
        }

        private string _authorizetel;

        /// <summary>
        /// AuthorizeTel
        /// </summary>
        public string AuthorizeTel
        {
            get { return _authorizetel; }
            set { _authorizetel = value; }
        }

        private string _authorizedate;

        /// <summary>
        /// 授权时间
        /// </summary>
        public string AuthorizeDate
        {
            get { return _authorizedate; }
            set { _authorizedate = value; }
        }

        private string _authorizematuritydate;

        /// <summary>
        /// 有效期
        /// </summary>
        public string AuthorizeMaturityDate
        {
            get { return _authorizematuritydate; }
            set { _authorizematuritydate = value; }
        }

        private string _remark;

        /// <summary>
        /// 描述
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private string _remark2;

        /// <summary>
        /// 描述2
        /// </summary>
        public string Remark2
        {
            get { return _remark2; }
            set { _remark2 = value; }
        }

        private decimal? _rates1;

        /// <summary>
        /// 管理费
        /// </summary>
        public decimal? Rates1
        {
            get { return _rates1; }
            set { _rates1 = value; }
        }

        private decimal? _rates2;

        /// <summary>
        /// 质保金率
        /// </summary>
        public decimal? Rates2
        {
            get { return _rates2; }
            set { _rates2 = value; }
        }

        private decimal? _rates3;

        /// <summary>
        /// 营业税及附加
        /// </summary>
        public decimal? Rates3
        {
            get { return _rates3; }
            set { _rates3 = value; }
        }

        private decimal? _rates4;

        /// <summary>
        /// 企业所得税
        /// </summary>
        public decimal? Rates4
        {
            get { return _rates4; }
            set { _rates4 = value; }
        }

        private decimal? _rates5;

        /// <summary>
        /// 个人所得税
        /// </summary>
        public decimal? Rates5
        {
            get { return _rates5; }
            set { _rates5 = value; }
        }

        private decimal? _rates6;

        /// <summary>
        /// 印花税税率
        /// </summary>
        public decimal? Rates6
        {
            get { return _rates6; }
            set { _rates6 = value; }
        }

        private decimal? _rates7;

        /// <summary>
        /// 利息利率
        /// </summary>
        public decimal? Rates7
        {
            get { return _rates7; }
            set { _rates7 = value; }
        }

        private decimal? _rates8;

        /// <summary>
        /// 退回的税率
        /// </summary>
        public decimal? Rates8
        {
            get { return _rates8; }
            set { _rates8 = value; }
        }

        private decimal? _balancemanager;

        /// <summary>
        /// 经理余额
        /// </summary>
        public decimal? BalanceManager
        {
            get { return _balancemanager; }
            set { _balancemanager = value; }
        }

        private decimal? _balance;

        /// <summary>
        /// 余额
        /// </summary>
        public decimal? Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        private decimal? _clearingmoney;

        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal? ClearingMoney
        {
            get { return _clearingmoney; }
            set { _clearingmoney = value; }
        }

        private decimal? _importamount;

        /// <summary>
        /// 汇入金额
        /// </summary>
        public decimal? ImportAmount
        {
            get { return _importamount; }
            set { _importamount = value; }
        }

        private decimal? _exportamount;

        /// <summary>
        /// 汇出金额
        /// </summary>
        public decimal? ExportAmount
        {
            get { return _exportamount; }
            set { _exportamount = value; }
        }

        private decimal? _fujiashui;

        /// <summary>
        /// 扣营业税及附加税
        /// </summary>
        public decimal? FuJiaShui
        {
            get { return _fujiashui; }
            set { _fujiashui = value; }
        }

        private decimal? _qysuodeshui;

        /// <summary>
        /// 扣企业所得税
        /// </summary>
        public decimal? QySuoDeShui
        {
            get { return _qysuodeshui; }
            set { _qysuodeshui = value; }
        }

        private decimal? _yinhuashui;

        /// <summary>
        /// 扣印花税
        /// </summary>
        public decimal? YinHuaShui
        {
            get { return _yinhuashui; }
            set { _yinhuashui = value; }
        }

        private decimal? _grsuodeshui;

        /// <summary>
        /// 扣个人所得税
        /// </summary>
        public decimal? GrSuoDeShui
        {
            get { return _grsuodeshui; }
            set { _grsuodeshui = value; }
        }

        private decimal? _baozhenjin;

        /// <summary>
        /// 扣保证金
        /// </summary>
        public decimal? BaoZhenJin
        {
            get { return _baozhenjin; }
            set { _baozhenjin = value; }
        }

        private decimal? _zhibaojin;

        /// <summary>
        /// 已退质保金
        /// </summary>
        public decimal? ZhiBaoJin
        {
            get { return _zhibaojin; }
            set { _zhibaojin = value; }
        }

        private decimal? _guanglifei;

        /// <summary>
        /// 扣管理费
        /// </summary>
        public decimal? GuangLiFei
        {
            get { return _guanglifei; }
            set { _guanglifei = value; }
        }

        private decimal? _lixi;

        /// <summary>
        /// 扣利息
        /// </summary>
        public decimal? LiXi
        {
            get { return _lixi; }
            set { _lixi = value; }
        }

        private decimal? _qtkuan;

        /// <summary>
        /// 扣其他款
        /// </summary>
        public decimal? QTKuan
        {
            get { return _qtkuan; }
            set { _qtkuan = value; }
        }

        private decimal? _fpamount;

        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal? FPAmount
        {
            get { return _fpamount; }
            set { _fpamount = value; }
        }

        private decimal? _fpshuikuan;

        /// <summary>
        /// 发票税款
        /// </summary>
        public decimal? FPShuiKuan
        {
            get { return _fpshuikuan; }
            set { _fpshuikuan = value; }
        }

        private decimal? _sjamount;

        /// <summary>
        /// 收据金额
        /// </summary>
        public decimal? SJAmount
        {
            get { return _sjamount; }
            set { _sjamount = value; }
        }

        private decimal? _hgskuan;

        /// <summary>
        /// 汇回公司款
        /// </summary>
        public decimal? HGSKuan
        {
            get { return _hgskuan; }
            set { _hgskuan = value; }
        }

        private decimal? _ddyhcunkuan;

        /// <summary>
        /// 当地银行存款
        /// </summary>
        public decimal? DDYHCunKuan
        {
            get { return _ddyhcunkuan; }
            set { _ddyhcunkuan = value; }
        }

        private int? _type;

        /// <summary>
        /// 0工程收费,1发票,2收据,3外出证
        /// </summary>
        public int? Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _bankname;

        /// <summary>
        /// 银行名
        /// </summary>
        public string BankName
        {
            get { return _bankname; }
            set { _bankname = value; }
        }

        private string _account;

        /// <summary>
        /// 银行账号
        /// </summary>
        public string Account
        {
            get { return _account; }
            set { _account = value; }
        }

        private int? _fk_id;

        /// <summary>
        /// fk_id
        /// </summary>
        public int? fk_id
        {
            get { return _fk_id; }
            set { _fk_id = value; }
        }

        private int? _sk_id;

        /// <summary>
        /// sk_id
        /// </summary>
        public int? sk_id
        {
            get { return _sk_id; }
            set { _sk_id = value; }
        }

        private int? _tk_id;

        /// <summary>
        /// tk_id
        /// </summary>
        public int? tk_id
        {
            get { return _tk_id; }
            set { _tk_id = value; }
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

        private DateTime _addtime = DateTime.MinValue;

        /// <summary>
        /// AddTime
        /// </summary>
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

    }
}

