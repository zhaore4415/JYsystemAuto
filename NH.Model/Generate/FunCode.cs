using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// FunCode
    /// </summary>
    public partial class FunCode
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

        private string _name;

        /// <summary>
        /// 功能名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _code;

        /// <summary>
        /// 功能码(页面名称或编码)
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private int _funtype = Int32.MinValue;

        /// <summary>
        /// 功能操作类型：1查询，2编辑，3删除，4方法控制
        /// </summary>
        public int FunType
        {
            get { return _funtype; }
            set { _funtype = value; }
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

        private int _groupid = Int32.MinValue;

        /// <summary>
        /// 所属功能组Id
        /// </summary>
        public int GroupId
        {
            get { return _groupid; }
            set { _groupid = value; }
        }

    }
}

