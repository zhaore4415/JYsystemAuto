using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// Carfx
    /// </summary>
    public partial class Carfx
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

        private string _pname;

        /// <summary>
        /// PName
        /// </summary>
        public string PName
        {
            get { return _pname; }
            set { _pname = value; }
        }

        private int? _num;

        /// <summary>
        /// Num
        /// </summary>
        public int? Num
        {
            get { return _num; }
            set { _num = value; }
        }

        private int? _jifenprice;

        /// <summary>
        /// 积分单价
        /// </summary>
        public int? JiFenPrice
        {
            get { return _jifenprice; }
            set { _jifenprice = value; }
        }

        private int? _categoryid;

        /// <summary>
        /// CategoryID
        /// </summary>
        public int? CategoryID
        {
            get { return _categoryid; }
            set { _categoryid = value; }
        }

        private string _categorypath;

        /// <summary>
        /// CategoryPath
        /// </summary>
        public string CategoryPath
        {
            get { return _categorypath; }
            set { _categorypath = value; }
        }

        private int? _uid;

        /// <summary>
        /// 会员ID
        /// </summary>
        public int? UId
        {
            get { return _uid; }
            set { _uid = value; }
        }

        private int? _pid;

        /// <summary>
        /// PId
        /// </summary>
        public int? PId
        {
            get { return _pid; }
            set { _pid = value; }
        }

        private string _ordernumber;

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber
        {
            get { return _ordernumber; }
            set { _ordernumber = value; }
        }

        private string _status;

        /// <summary>
        /// 状态，0下单前，1下单后，2为完成订单
        /// </summary>
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}

