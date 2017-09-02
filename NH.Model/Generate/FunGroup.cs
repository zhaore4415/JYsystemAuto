using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// FunGroup
    /// </summary>
    public partial class FunGroup
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

        private string _groupname;

        /// <summary>
        /// 功能组名称
        /// </summary>
        public string GroupName
        {
            get { return _groupname; }
            set { _groupname = value; }
        }

        private int _parentid = Int32.MinValue;

        /// <summary>
        /// 上级ID
        /// </summary>
        public int ParentID
        {
            get { return _parentid; }
            set { _parentid = value; }
        }

        private bool? _isshow;

        /// <summary>
        /// 是否开放显示
        /// </summary>
        public bool? IsShow
        {
            get { return _isshow; }
            set { _isshow = value; }
        }

        private int _depth = Int32.MinValue;

        /// <summary>
        /// Depth
        /// </summary>
        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

    }
}

