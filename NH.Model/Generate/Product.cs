using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// Product
    /// </summary>
    public partial class Product
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

        private string _content;

        /// <summary>
        /// content
        /// </summary>
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        private string _name;

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int? _order;

        /// <summary>
        /// 数量
        /// </summary>
        public int? Order
        {
            get { return _order; }
            set { _order = value; }
        }

        private string _pic;

        /// <summary>
        /// Pic
        /// </summary>
        public string Pic
        {
            get { return _pic; }
            set { _pic = value; }
        }

        private string _smallpic;

        /// <summary>
        /// SmallPic
        /// </summary>
        public string SmallPic
        {
            get { return _smallpic; }
            set { _smallpic = value; }
        }

        private int? _categoryid;

        /// <summary>
        /// CategoryID
        /// </summary>
        public int? CategoryID
        {
            get { return _categoryid; }
            set { _categoryid = value; }
        }

        private string _categorypath;

        /// <summary>
        /// CategoryPath
        /// </summary>
        public string CategoryPath
        {
            get { return _categorypath; }
            set { _categorypath = value; }
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

        private string _model;

        /// <summary>
        /// Model
        /// </summary>
        public string Model
        {
            get { return _model; }
            set { _model = value; }
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

        private string _imgs;

        /// <summary>
        /// Imgs
        /// </summary>
        public string Imgs
        {
            get { return _imgs; }
            set { _imgs = value; }
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
        /// 是否删除:0未删除，1已删除，-1
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

        private string _barcode;

        /// <summary>
        /// 条形码
        /// </summary>
        public string Barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }

        private decimal? _chengben;

        /// <summary>
        /// 成本价
        /// </summary>
        public decimal? ChengBen
        {
            get { return _chengben; }
            set { _chengben = value; }
        }

        private decimal? _chushou;

        /// <summary>
        /// 出售价
        /// </summary>
        public decimal? ChuShou
        {
            get { return _chushou; }
            set { _chushou = value; }
        }

        private int? _rukusum;

        /// <summary>
        /// 入库总量
        /// </summary>
        public int? RuKuSum
        {
            get { return _rukusum; }
            set { _rukusum = value; }
        }

        private int? _chukusum;

        /// <summary>
        /// 出库总量
        /// </summary>
        public int? ChuKuSum
        {
            get { return _chukusum; }
            set { _chukusum = value; }
        }

        private int? _nowkucun;

        /// <summary>
        /// 当前库存
        /// </summary>
        public int? NowKuCun
        {
            get { return _nowkucun; }
            set { _nowkucun = value; }
        }

        private int? _kucunbaojing;

        /// <summary>
        /// 库存报警量
        /// </summary>
        public int? KuCunBaoJing
        {
            get { return _kucunbaojing; }
            set { _kucunbaojing = value; }
        }

        private string _cunchuweizhi;

        /// <summary>
        /// 存储位置
        /// </summary>
        public string CunChuWeiZhi
        {
            get { return _cunchuweizhi; }
            set { _cunchuweizhi = value; }
        }

        private int? _jifenprice;

        /// <summary>
        /// JiFenPrice
        /// </summary>
        public int? JiFenPrice
        {
            get { return _jifenprice; }
            set { _jifenprice = value; }
        }

        private int? _kejifen;

        /// <summary>
        /// 用于购买的产品可得的积分
        /// </summary>
        public int? KeJiFen
        {
            get { return _kejifen; }
            set { _kejifen = value; }
        }

    }
}

