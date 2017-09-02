using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// Suppliers
    /// </summary>
    public partial class Suppliers
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

        private string _ordernumber;

        /// <summary>
        /// OrderNumber
        /// </summary>
        public string OrderNumber
        {
            get { return _ordernumber; }
            set { _ordernumber = value; }
        }

        private string _expressorder;

        /// <summary>
        /// ExpressOrder
        /// </summary>
        public string ExpressOrder
        {
            get { return _expressorder; }
            set { _expressorder = value; }
        }

        private string _couriercompanies;

        /// <summary>
        /// Couriercompanies
        /// </summary>
        public string Couriercompanies
        {
            get { return _couriercompanies; }
            set { _couriercompanies = value; }
        }

        private string _realname;

        /// <summary>
        /// Realname
        /// </summary>
        public string Realname
        {
            get { return _realname; }
            set { _realname = value; }
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

        private string _tel;

        /// <summary>
        /// Tel
        /// </summary>
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        private string _phone;

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _companyname;

        /// <summary>
        /// CompanyName
        /// </summary>
        public string CompanyName
        {
            get { return _companyname; }
            set { _companyname = value; }
        }

        private string _address;

        /// <summary>
        /// Address
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _description;

        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
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

        private DateTime _deliverytime = DateTime.MinValue;

        /// <summary>
        /// DeliveryTime
        /// </summary>
        public DateTime DeliveryTime
        {
            get { return _deliverytime; }
            set { _deliverytime = value; }
        }

        private DateTime _arrivaltime = DateTime.MinValue;

        /// <summary>
        /// ArrivalTime
        /// </summary>
        public DateTime ArrivalTime
        {
            get { return _arrivaltime; }
            set { _arrivaltime = value; }
        }

        private int _status = Int32.MinValue;

        /// <summary>
        /// Status
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
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

        private int _pid = Int32.MinValue;

        /// <summary>
        /// Pid
        /// </summary>
        public int Pid
        {
            get { return _pid; }
            set { _pid = value; }
        }

        private string _username;

        /// <summary>
        /// 记录人
        /// </summary>
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

    }
}

