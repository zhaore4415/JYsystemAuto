using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// RecommendCode
    /// </summary>
    public partial class RecommendCode
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

        private string _tjcode;

        /// <summary>
        /// 推荐码
        /// </summary>
        public string TJCode
        {
            get { return _tjcode; }
            set { _tjcode = value; }
        }

        private DateTime? _addtime;

        /// <summary>
        /// AddTime
        /// </summary>
        public DateTime? AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        private int _status = Int32.MinValue;

        /// <summary>
        /// 状态：1正常，0失效
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int? _u_id;

        /// <summary>
        /// U_ID
        /// </summary>
        public int? U_ID
        {
            get { return _u_id; }
            set { _u_id = value; }
        }

        private DateTime? _failuretime;

        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime? FailureTime
        {
            get { return _failuretime; }
            set { _failuretime = value; }
        }

        private decimal? _tjzhekou;

        /// <summary>
        /// 推荐的下级代理享受折扣
        /// </summary>
        public decimal? TJZheKou
        {
            get { return _tjzhekou; }
            set { _tjzhekou = value; }
        }

    }
}

