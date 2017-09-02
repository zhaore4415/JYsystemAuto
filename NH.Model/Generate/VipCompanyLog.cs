using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// VipCompanyLog
    /// </summary>
    public partial class VipCompanyLog
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
        /// 企业ID
        /// </summary>
        public int CompanyId
        {
            get { return _companyid; }
            set { _companyid = value; }
        }

        private int _levelid = Int32.MinValue;

        /// <summary>
        /// 等级ID
        /// </summary>
        public int LevelID
        {
            get { return _levelid; }
            set { _levelid = value; }
        }

        private DateTime? _expiredate;

        /// <summary>
        /// 到期日期
        /// </summary>
        public DateTime? ExpireDate
        {
            get { return _expiredate; }
            set { _expiredate = value; }
        }

        private DateTime _addtime = DateTime.MinValue;

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        private int _addtype = Int32.MinValue;

        /// <summary>
        /// 操作类型：1人工操作，2在线支付自助操作
        /// </summary>
        public int AddType
        {
            get { return _addtype; }
            set { _addtype = value; }
        }

        private string _adduser;

        /// <summary>
        /// 操作人
        /// </summary>
        public string AddUser
        {
            get { return _adduser; }
            set { _adduser = value; }
        }

    }
}

