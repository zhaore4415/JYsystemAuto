using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// SysNewsRecord
    /// </summary>
    public partial class SysNewsRecord
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

        private int _articleid = Int32.MinValue;

        /// <summary>
        /// ArticleId
        /// </summary>
        public int ArticleId
        {
            get { return _articleid; }
            set { _articleid = value; }
        }

        private int _userid = Int32.MinValue;

        /// <summary>
        /// UserId
        /// </summary>
        public int UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }

        private int _usertype = Int32.MinValue;

        /// <summary>
        /// UserType
        /// </summary>
        public int UserType
        {
            get { return _usertype; }
            set { _usertype = value; }
        }

        private bool? _readstatus;

        /// <summary>
        /// 阅读状态:0未读，1已读
        /// </summary>
        public bool? ReadStatus
        {
            get { return _readstatus; }
            set { _readstatus = value; }
        }

    }
}

