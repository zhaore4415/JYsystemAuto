using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// ReceiveRecord
    /// </summary>
    public partial class ReceiveRecord
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

        private int _companyid = Int32.MinValue;

        /// <summary>
        /// CompanyId
        /// </summary>
        public int CompanyId
        {
            get { return _companyid; }
            set { _companyid = value; }
        }

        private int _signupcount = Int32.MinValue;

        /// <summary>
        /// 本批报名人数
        /// </summary>
        public int SignUpCount
        {
            get { return _signupcount; }
            set { _signupcount = value; }
        }

        private DateTime _starttime = DateTime.MinValue;

        /// <summary>
        /// 开始报名时间
        /// </summary>
        public DateTime StartTime
        {
            get { return _starttime; }
            set { _starttime = value; }
        }

        private DateTime _enddate = DateTime.MinValue;

        /// <summary>
        /// 最后接站时间
        /// </summary>
        public DateTime EndDate
        {
            get { return _enddate; }
            set { _enddate = value; }
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

        private DateTime _addtime = DateTime.MinValue;

        /// <summary>
        /// AddTime
        /// </summary>
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        private int _addtype = Int32.MinValue;

        /// <summary>
        /// 此记录添加方式：1为管理员添加，2为前台求职者选择下一批报名时自动添加
        /// </summary>
        public int AddType
        {
            get { return _addtype; }
            set { _addtype = value; }
        }

        private int _status = Int32.MinValue;

        /// <summary>
        /// 状态：1正常；-1删除
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int _times = Int32.MinValue;

        /// <summary>
        /// 第几批
        /// </summary>
        public int Times
        {
            get { return _times; }
            set { _times = value; }
        }

    }
}

