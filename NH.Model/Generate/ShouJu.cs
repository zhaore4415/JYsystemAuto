using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// ShouJu
    /// </summary>
    public partial class ShouJu
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

        private DateTime? _addtime;

        /// <summary>
        /// 收据开出日期
        /// </summary>
        public DateTime? AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        private string _shoujuhao;

        /// <summary>
        /// 收据号
        /// </summary>
        public string ShouJuHao
        {
            get { return _shoujuhao; }
            set { _shoujuhao = value; }
        }

        private decimal? _sjamount;

        /// <summary>
        /// 收据金额
        /// </summary>
        public decimal? SJAmount
        {
            get { return _sjamount; }
            set { _sjamount = value; }
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

        private int _fid = Int32.MinValue;

        /// <summary>
        /// 工程收费,发票,收据,外出 与总表共享ID
        /// </summary>
        public int Fid
        {
            get { return _fid; }
            set { _fid = value; }
        }

    }
}

