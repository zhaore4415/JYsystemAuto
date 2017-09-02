using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// ERPBuyOrder
    /// </summary>
    public partial class ERPBuyOrder
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

        private string _ordername;

        /// <summary>
        /// OrderName
        /// </summary>
        public string OrderName
        {
            get { return _ordername; }
            set { _ordername = value; }
        }

        private string _gongyingshangname;

        /// <summary>
        /// 店铺、供应商、公司名
        /// </summary>
        public string GongYingShangName
        {
            get { return _gongyingshangname; }
            set { _gongyingshangname = value; }
        }

        private string _serils;

        /// <summary>
        /// Serils
        /// </summary>
        public string Serils
        {
            get { return _serils; }
            set { _serils = value; }
        }

        private string _dingdanleixing;

        /// <summary>
        /// DingDanLeiXing
        /// </summary>
        public string DingDanLeiXing
        {
            get { return _dingdanleixing; }
            set { _dingdanleixing = value; }
        }

        private string _dingdanmiaoshu;

        /// <summary>
        /// DingDanMiaoShu
        /// </summary>
        public string DingDanMiaoShu
        {
            get { return _dingdanmiaoshu; }
            set { _dingdanmiaoshu = value; }
        }

        private DateTime _createdate = DateTime.MinValue;

        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }

        private DateTime _laihuodate = DateTime.MinValue;

        /// <summary>
        /// LaiHuoDate
        /// </summary>
        public DateTime LaiHuoDate
        {
            get { return _laihuodate; }
            set { _laihuodate = value; }
        }

        private DateTime _tixingdate = DateTime.MinValue;

        /// <summary>
        /// TiXingDate
        /// </summary>
        public DateTime TiXingDate
        {
            get { return _tixingdate; }
            set { _tixingdate = value; }
        }

        private string _chuangjianren;

        /// <summary>
        /// ChuangJianRen
        /// </summary>
        public string ChuangJianRen
        {
            get { return _chuangjianren; }
            set { _chuangjianren = value; }
        }

        private string _fuzeren;

        /// <summary>
        /// FuZeRen
        /// </summary>
        public string FuZeRen
        {
            get { return _fuzeren; }
            set { _fuzeren = value; }
        }

        private string _fujianlist;

        /// <summary>
        /// FuJianList
        /// </summary>
        public string FuJianList
        {
            get { return _fujianlist; }
            set { _fujianlist = value; }
        }

        private string _nowstate;

        /// <summary>
        /// NowState
        /// </summary>
        public string NowState
        {
            get { return _nowstate; }
            set { _nowstate = value; }
        }

        private string _shenpitongguoren;

        /// <summary>
        /// ShenPiTongGuoRen
        /// </summary>
        public string ShenPiTongGuoRen
        {
            get { return _shenpitongguoren; }
            set { _shenpitongguoren = value; }
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

        private string _username;

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        private DateTime? _timestr;

        /// <summary>
        /// TimeStr
        /// </summary>
        public DateTime? TimeStr
        {
            get { return _timestr; }
            set { _timestr = value; }
        }

        private int? _u_id;

        /// <summary>
        /// 用户ID
        /// </summary>
        public int? U_ID
        {
            get { return _u_id; }
            set { _u_id = value; }
        }

    }
}

