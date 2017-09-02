using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    //Aftersales
    public partial class Aftersales
    {

        /// <summary>
        /// Id
        /// </summary>		
        private int _id = Int32.MinValue;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// OrderNumber
        /// </summary>		
        private string _ordernumber;
        public string OrderNumber
        {
            get { return _ordernumber; }
            set { _ordernumber = value; }
        }
        /// <summary>
        /// ExpressOrder
        /// </summary>		
        private string _expressorder;
        public string ExpressOrder
        {
            get { return _expressorder; }
            set { _expressorder = value; }
        }
        /// <summary>
        /// Couriercompanies
        /// </summary>		
        private string _couriercompanies;
        public string Couriercompanies
        {
            get { return _couriercompanies; }
            set { _couriercompanies = value; }
        }
        /// <summary>
        /// Realname
        /// </summary>		
        private string _realname;
        public string Realname
        {
            get { return _realname; }
            set { _realname = value; }
        }
        /// <summary>
        /// Email
        /// </summary>		
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// Tel
        /// </summary>		
        private string _tel;
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        /// <summary>
        /// Phone
        /// </summary>		
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        /// <summary>
        /// CompanyName
        /// </summary>		
        private string _companyname;
        public string CompanyName
        {
            get { return _companyname; }
            set { _companyname = value; }
        }
        /// <summary>
        /// Address
        /// </summary>		
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// Description
        /// </summary>		
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// AddTime
        /// </summary>		
        private DateTime _addtime = DateTime.MinValue;
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        /// <summary>
        /// DeliveryTime
        /// </summary>		
        private DateTime _deliverytime = DateTime.MinValue;
        public DateTime DeliveryTime
        {
            get { return _deliverytime; }
            set { _deliverytime = value; }
        }
        /// <summary>
        /// ArrivalTime
        /// </summary>		
        private DateTime _arrivaltime = DateTime.MinValue;
        public DateTime ArrivalTime
        {
            get { return _arrivaltime; }
            set { _arrivaltime = value; }
        }
        /// <summary>
        /// Status
        /// </summary>		
        private int _status = Int32.MinValue;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
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
        /// Pid
        /// </summary>		
        private int _pid = Int32.MinValue;
        public int Pid
        {
            get { return _pid; }
            set { _pid = value; }
        }
        private bool? _isverify;
        /// <summary>
        /// 是否发回
        /// </summary>
        public bool? IsVerify
        {
            get { return _isverify; }
            set { _isverify = value; }
        }        
    }
}

