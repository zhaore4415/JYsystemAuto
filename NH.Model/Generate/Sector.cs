using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// Sector
    /// </summary>
    public partial class Sector
    {

        private int _id = Int32.MinValue;

        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private int? _depth;

        /// <summary>
        /// Depth
        /// </summary>
        public int? Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        private int? _parentid;

        /// <summary>
        /// 父ID
        /// </summary>
        public int? ParentID
        {
            get { return _parentid; }
            set { _parentid = value; }
        }

        private string _name;

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int? _sectorid;

        /// <summary>
        /// 部门ID
        /// </summary>
        public int? SectorId
        {
            get { return _sectorid; }
            set { _sectorid = value; }
        }

        private DateTime _addtime = DateTime.MinValue;

        /// <summary>
        /// 部门创建时间
        /// </summary>
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
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

        private string _remark;

        /// <summary>
        /// Remark
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

    }
}

