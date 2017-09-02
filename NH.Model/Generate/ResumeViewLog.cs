using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// ResumeViewLog
	/// </summary>
	public partial class ResumeViewLog
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
				
		private int _companyid = Int32.MinValue;
        
		/// <summary>
		/// 企业id
        /// </summary>
        public int CompanyID
        {
            get{ return _companyid; }
            set{ _companyid = value; }
        }        
				
		private int _memberid = Int32.MinValue;
        
		/// <summary>
		/// 会员id
        /// </summary>
        public int MemberID
        {
            get{ return _memberid; }
            set{ _memberid = value; }
        }        
				
		private DateTime _addtime = DateTime.MinValue;
        
		/// <summary>
		/// 查阅时间
        /// </summary>
        public DateTime AddTime
        {
            get{ return _addtime; }
            set{ _addtime = value; }
        }        
				
		private string _ip;
        
		/// <summary>
		/// IP地址
        /// </summary>
        public string IP
        {
            get{ return _ip; }
            set{ _ip = value; }
        }        
				
		private string _address;
        
		/// <summary>
		/// 地点
        /// </summary>
        public string Address
        {
            get{ return _address; }
            set{ _address = value; }
        }        
		   
	}
}

