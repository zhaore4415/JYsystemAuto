using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// AdType
    /// </summary>
    public partial class AdType
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

        private string _typename;

        /// <summary>
        /// 广告位名称
        /// </summary>
        public string TypeName
        {
            get { return _typename; }
            set { _typename = value; }
        }

        private string _remark;

        /// <summary>
        /// 描述
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private int _showcount = Int32.MinValue;

        /// <summary>
        /// 广告显示数量，为0表示全部显示
        /// </summary>
        public int ShowCount
        {
            get { return _showcount; }
            set { _showcount = value; }
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

    }
}

