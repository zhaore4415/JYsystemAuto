using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// SearchKey
    /// </summary>
    public partial class SearchKey
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

        private string _keyname;

        /// <summary>
        /// 关键字名称
        /// </summary>
        public string KeyName
        {
            get { return _keyname; }
            set { _keyname = value; }
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

        private int _sort = Int32.MinValue;

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

        private int _type = Int32.MinValue;

        /// <summary>
        /// 类型：1顶部按地区搜索关键词；2热门关键字
        /// </summary>
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _style = Int32.MinValue;

        /// <summary>
        /// 样式
        /// </summary>
        public int Style
        {
            get { return _style; }
            set { _style = value; }
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

