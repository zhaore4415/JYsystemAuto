using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    //ProCategory
    public partial class ProCategory
    {
   
        /// <summary>
        /// ID
        /// </summary>		
        private int _id= Int32.MinValue;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 文章分类名称
        /// </summary>		
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// Depth
        /// </summary>		
        private int _depth = Int32.MinValue;
        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }
        /// <summary>
        /// ParentID
        /// </summary>		
        private int _parentid = Int32.MinValue;
        public int ParentID
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// Path
        /// </summary>		
        private string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        /// <summary>
        /// Pic
        /// </summary>		
        private string _pic;
        public string Pic
        {
            get { return _pic; }
            set { _pic = value; }
        }
        /// <summary>
        /// Child
        /// </summary>		
        private int _child= Int32.MinValue;
        public int Child
        {
            get { return _child; }
            set { _child = value; }
        }
        /// <summary>
        /// Remark
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// 状态：1显示，0关闭
        /// </summary>		
        private bool? _isshow;
        public bool? IsShow
        {
            get { return _isshow; }
            set { _isshow = value; }
        }
        /// <summary>
        /// 文章类型:1 会员系统消息，2 企业系统消息，3 招聘帮助，4 求职帮助，5 Hr工具
        /// </summary>		
        private DateTime _addtime= DateTime.MinValue;
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>		
        private int _sort = Int32.MinValue;
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

    }
}

