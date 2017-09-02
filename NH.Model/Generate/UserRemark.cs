using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// UserRemark
    /// </summary>
    public partial class UserRemark
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

        private int _memberid = Int32.MinValue;

        /// <summary>
        /// MemberId
        /// </summary>
        public int MemberId
        {
            get { return _memberid; }
            set { _memberid = value; }
        }

        private int _remarktypeid = Int32.MinValue;

        /// <summary>
        /// RemarkTypeId
        /// </summary>
        public int RemarkTypeId
        {
            get { return _remarktypeid; }
            set { _remarktypeid = value; }
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

    }
}

