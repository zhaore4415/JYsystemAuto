using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// a
    /// </summary>
    public partial class a
    {

        private int _id = Int32.MinValue;

        /// <summary>
        /// id
        /// </summary>
        public int id
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

        private DateTime? _addtime;

        /// <summary>
        /// addtime
        /// </summary>
        public DateTime? addtime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

    }
}

