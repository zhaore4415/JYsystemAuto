using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// FaPiao
    /// </summary>
    public partial class FaPiao
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
        /// 发票开出日期
        /// </summary>
        public DateTime? AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        private string _zihao;

        /// <summary>
        /// 发票字号
        /// </summary>
        public string ZiHao
        {
            get { return _zihao; }
            set { _zihao = value; }
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

        private string _sphao;

        /// <summary>
        /// 税票号码
        /// </summary>
        public string SPHao
        {
            get { return _sphao; }
            set { _sphao = value; }
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

        private string _lsaddress;

        /// <summary>
        /// 发票纳税地点
        /// </summary>
        public string LSAddress
        {
            get { return _lsaddress; }
            set { _lsaddress = value; }
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

        private string _remark;

        /// <summary>
        /// 描述
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private decimal? _yinyeer;

        /// <summary>
        /// 营业额
        /// </summary>
        public decimal? YinYeEr
        {
            get { return _yinyeer; }
            set { _yinyeer = value; }
        }

        private decimal? _chenjianer;

        /// <summary>
        /// 城建额
        /// </summary>
        public decimal? ChenJianEr
        {
            get { return _chenjianer; }
            set { _chenjianer = value; }
        }

        private decimal? _jyffujia;

        /// <summary>
        /// 教育费附加
        /// </summary>
        public decimal? JYFFuJia
        {
            get { return _jyffujia; }
            set { _jyffujia = value; }
        }

        private decimal? _dfjyffujia;

        /// <summary>
        /// 地方教育费附加
        /// </summary>
        public decimal? DFJYFFuJia
        {
            get { return _dfjyffujia; }
            set { _dfjyffujia = value; }
        }

        private decimal? _qysuodeshui;

        /// <summary>
        /// 企业所得税
        /// </summary>
        public decimal? QYSuoDeShui
        {
            get { return _qysuodeshui; }
            set { _qysuodeshui = value; }
        }

        private decimal? _grsuodeshui;

        /// <summary>
        /// 个人所得税
        /// </summary>
        public decimal? GRSuoDeShui
        {
            get { return _grsuodeshui; }
            set { _grsuodeshui = value; }
        }

        private decimal? _yinhuashui;

        /// <summary>
        /// 印花税
        /// </summary>
        public decimal? YinHuaShui
        {
            get { return _yinhuashui; }
            set { _yinhuashui = value; }
        }

        private decimal? _qita;

        /// <summary>
        /// 其它
        /// </summary>
        public decimal? QiTa
        {
            get { return _qita; }
            set { _qita = value; }
        }

    }
}

