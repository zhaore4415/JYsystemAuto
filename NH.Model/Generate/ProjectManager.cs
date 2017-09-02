using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// ProjectManager
    /// </summary>
    public partial class ProjectManager
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
        /// Name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _email;

        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _shouji;

        /// <summary>
        /// 手机
        /// </summary>
        public string ShouJi
        {
            get { return _shouji; }
            set { _shouji = value; }
        }

        private string _tel;

        /// <summary>
        /// 手机
        /// </summary>
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
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

        private int _sex = Int32.MinValue;

        /// <summary>
        /// 0为男，1为女
        /// </summary>
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        private string _fax;

        /// <summary>
        /// Fax
        /// </summary>
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        private int _status = Int32.MinValue;

        /// <summary>
        /// 状态：1正常，0禁用，-1删除
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _photo;

        /// <summary>
        /// Photo
        /// </summary>
        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        private string _workingday;

        /// <summary>
        /// 任职日期
        /// </summary>
        public string Workingday
        {
            get { return _workingday; }
            set { _workingday = value; }
        }

        private string _departuredate;

        /// <summary>
        /// 离职日期
        /// </summary>
        public string Departuredate
        {
            get { return _departuredate; }
            set { _departuredate = value; }
        }

        private decimal? _balance;

        /// <summary>
        /// 项目余额总和
        /// </summary>
        public decimal? Balance
        {
            get { return _balance; }
            set { _balance = value; }
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

    }
}

