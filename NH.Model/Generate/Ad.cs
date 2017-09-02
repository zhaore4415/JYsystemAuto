using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// Ad
    /// </summary>
    public partial class Ad
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

        private int _adtype = Int32.MinValue;

        /// <summary>
        /// 广告类型ID
        /// </summary>
        public int AdType
        {
            get { return _adtype; }
            set { _adtype = value; }
        }

        private string _title;

        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _description;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _pic;

        /// <summary>
        /// 图片
        /// </summary>
        public string Pic
        {
            get { return _pic; }
            set { _pic = value; }
        }

        private string _url;

        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private DateTime? _startdate;

        /// <summary>
        /// 开始开放日期
        /// </summary>
        public DateTime? StartDate
        {
            get { return _startdate; }
            set { _startdate = value; }
        }

        private DateTime? _enddate;

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndDate
        {
            get { return _enddate; }
            set { _enddate = value; }
        }

        private string _adduser;

        /// <summary>
        /// 添加人
        /// </summary>
        public string AddUser
        {
            get { return _adduser; }
            set { _adduser = value; }
        }

        private DateTime _addtime = DateTime.MinValue;

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        private DateTime _updatetime = DateTime.MinValue;

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }

        private int _sort = Int32.MinValue;

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

        private bool? _isshow;

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool? IsShow
        {
            get { return _isshow; }
            set { _isshow = value; }
        }

        private int _companyid = Int32.MinValue;

        /// <summary>
        /// 对应的企业ID，为0则不对应企业
        /// </summary>
        public int CompanyID
        {
            get { return _companyid; }
            set { _companyid = value; }
        }

        private string _areano;

        /// <summary>
        /// 地区编号
        /// </summary>
        public string AreaNo
        {
            get { return _areano; }
            set { _areano = value; }
        }

        private int _icon = Int32.MinValue;

        /// <summary>
        /// 显示图标：1首页滚动文字【NEW】，2【VIP】
        /// </summary>
        public int Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        private int _jobid = Int32.MinValue;

        /// <summary>
        /// 招聘职位ID
        /// </summary>
        public int JobId
        {
            get { return _jobid; }
            set { _jobid = value; }
        }

    }
}

