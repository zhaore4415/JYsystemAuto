using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// ReadResume
    /// </summary>
    public partial class ReadResume
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
        public int CompanyID
        {
            get { return _companyid; }
            set { _companyid = value; }
        }

        private int _memberid = Int32.MinValue;

        /// <summary>
        /// 个人会员ID
        /// </summary>
        public int MemberID
        {
            get { return _memberid; }
            set { _memberid = value; }
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

        private int _type = Int32.MinValue;

        /// <summary>
        /// 类型，为0是企业查看联系方式，为1是个人主动投的简历
        /// </summary>
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

    }
}

