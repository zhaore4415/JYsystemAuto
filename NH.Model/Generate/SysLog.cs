using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// SysLog
	/// </summary>
	public class SysLog
	{		
      			
		private int _id = Int32.MinValue;
        
		/// <summary>
		/// Id
        /// </summary>
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
				
		private int _userid = Int32.MinValue;
        
		/// <summary>
		/// UserID
        /// </summary>
        public int UserID
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
				
		private string _loginname;
        
		/// <summary>
		/// LoginName
        /// </summary>
        public string LoginName
        {
            get{ return _loginname; }
            set{ _loginname = value; }
        }        
				
		private int _usertype = Int32.MinValue;
        
		/// <summary>
		/// UserType
        /// </summary>
        public int UserType
        {
            get{ return _usertype; }
            set{ _usertype = value; }
        }        
				
		private int _eventno = Int32.MinValue;
        
		/// <summary>
		/// EventNo
        /// </summary>
        public int EventNo
        {
            get{ return _eventno; }
            set{ _eventno = value; }
        }        
				
		private string _eventname;
        
		/// <summary>
		/// EventName
        /// </summary>
        public string EventName
        {
            get{ return _eventname; }
            set{ _eventname = value; }
        }        
				
		private string _remark;
        
		/// <summary>
		/// Remark
        /// </summary>
        public string Remark
        {
            get{ return _remark; }
            set{ _remark = value; }
        }        
				
		private string _ip;
        
		/// <summary>
		/// IP
        /// </summary>
        public string IP
        {
            get{ return _ip; }
            set{ _ip = value; }
        }        
				
		private string _address;
        
		/// <summary>
		/// Address
        /// </summary>
        public string Address
        {
            get{ return _address; }
            set{ _address = value; }
        }        
				
		private DateTime _addtime = DateTime.MinValue;
        
		/// <summary>
		/// AddTime
        /// </summary>
        public DateTime AddTime
        {
            get{ return _addtime; }
            set{ _addtime = value; }
        }        
				
		private int? _targeobjid;
        
		/// <summary>
		/// TargeObjID
        /// </summary>
        public int? TargeObjID
        {
            get{ return _targeobjid; }
            set{ _targeobjid = value; }
        }        
		   
	}
}

