using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// Engineering
    /// </summary>
    public partial class Engineering
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

        private DateTime? _addtime;

        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime? AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
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

        private decimal? _importamount;

        /// <summary>
        /// 汇入金额
        /// </summary>
        public decimal? ImportAmount
        {
            get { return _importamount; }
            set { _importamount = value; }
        }

        private decimal? _importamountconfirm;

        /// <summary>
        /// ImportAmountConfirm
        /// </summary>
        public decimal? ImportAmountConfirm
        {
            get { return _importamountconfirm; }
            set { _importamountconfirm = value; }
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

        private decimal? _exportamountconfirm;

        /// <summary>
        /// ExportAmountConfirm
        /// </summary>
        public decimal? ExportAmountConfirm
        {
            get { return _exportamountconfirm; }
            set { _exportamountconfirm = value; }
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

        private decimal? _baozhenjin;

        /// <summary>
        /// 扣保证金=扣质保金
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

        private decimal? _grsuodeshui;

        /// <summary>
        /// 扣个人所得税
        /// </summary>
        public decimal? GrSuoDeShui
        {
            get { return _grsuodeshui; }
            set { _grsuodeshui = value; }
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

        private decimal? _qtkuan;

        /// <summary>
        /// 扣其他款
        /// </summary>
        public decimal? QTKuan
        {
            get { return _qtkuan; }
            set { _qtkuan = value; }
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

        private int _fid = Int32.MinValue;

        /// <summary>
        /// 工程收费,发票,收据,外出 与总表共享ID
        /// </summary>
        public int Fid
        {
            get { return _fid; }
            set { _fid = value; }
        }

        private bool? _jisuan;

        /// <summary>
        /// 是否自动计算
        /// </summary>
        public bool? JiSuan
        {
            get { return _jisuan; }
            set { _jisuan = value; }
        }

    }
}

