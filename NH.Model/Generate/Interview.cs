using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// Interview
	/// </summary>
	public partial class Interview
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
				
		private string _title;
        
		/// <summary>
		/// 面试通知标题
        /// </summary>
        public string Title
        {
            get{ return _title; }
            set{ _title = value; }
        }        
				
		private string _description;
        
		/// <summary>
		/// 面试通知描述内容
        /// </summary>
        public string Description
        {
            get{ return _description; }
            set{ _description = value; }
        }        
				
		private DateTime _addtime = DateTime.MinValue;
        
		/// <summary>
		/// 通知时间
        /// </summary>
        public DateTime AddTime
        {
            get{ return _addtime; }
            set{ _addtime = value; }
        }        
				
		private bool? _readstatus;
        
		/// <summary>
		/// 0未阅，1已阅
        /// </summary>
        public bool? ReadStatus
        {
            get{ return _readstatus; }
            set{ _readstatus = value; }
        }        
				
		private DateTime? _readtime;
        
		/// <summary>
		/// 阅读时间
        /// </summary>
        public DateTime? ReadTime
        {
            get{ return _readtime; }
            set{ _readtime = value; }
        }        
				
		private bool? _isaccept;
        
		/// <summary>
		/// 是否接受面试
        /// </summary>
        public bool? IsAccept
        {
            get{ return _isaccept; }
            set{ _isaccept = value; }
        }        
		   
	}
}

