using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// Orderdetails
    /// </summary>
    public partial class Orderdetails
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

        private int _q_id = Int32.MinValue;

        /// <summary>
        /// Q_ID
        /// </summary>
        public int Q_ID
        {
            get { return _q_id; }
            set { _q_id = value; }
        }

        private string _buyers;

        /// <summary>
        /// 买家会员名/商品ID
        /// </summary>
        public string Buyers
        {
            get { return _buyers; }
            set { _buyers = value; }
        }

        private string _name;

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _colors;

        /// <summary>
        /// Colors
        /// </summary>
        public string Colors
        {
            get { return _colors; }
            set { _colors = value; }
        }

        private int _babynumber = Int32.MinValue;

        /// <summary>
        /// 订购数量
        /// </summary>
        public int Babynumber
        {
            get { return _babynumber; }
            set { _babynumber = value; }
        }

        private decimal _prices = Decimal.MinValue;

        /// <summary>
        /// 商品金额
        /// </summary>
        public decimal Prices
        {
            get { return _prices; }
            set { _prices = value; }
        }

        private decimal _amount = Decimal.MinValue;

        /// <summary>
        /// 商品金额
        /// </summary>
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private string _remark;

        /// <summary>
        /// 商品备注
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private string _barcode;

        /// <summary>
        /// 产品服务编号
        /// </summary>
        public string Barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }

        private DateTime _addtime = DateTime.MinValue;

        /// <summary>
        /// AddTime
        /// </summary>
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        //private int _babynumber = Int32.MinValue;
        private long _qdid = long.MinValue;

        /// <summary>
        /// QdId
        /// </summary>
        public long QdId
        {
            get { return _qdid; }
            set { _qdid = value; }
        }

    }
}

