using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// UserSuggest
	/// </summary>
	public partial class UserSuggest
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
				
		private int _usertype = Int32.MinValue;
        
		/// <summary>
		/// UserType
        /// </summary>
        public int UserType
        {
            get{ return _usertype; }
            set{ _usertype = value; }
        }        
				
		private string _title;
        
		/// <summary>
		/// Title
        /// </summary>
        public string Title
        {
            get{ return _title; }
            set{ _title = value; }
        }        
				
		private string _description;
        
		/// <summary>
		/// Description
        /// </summary>
        public string Description
        {
            get{ return _description; }
            set{ _description = value; }
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
				
		private DateTime _addtime = DateTime.MinValue;
        
		/// <summary>
		/// AddTime
        /// </summary>
        public DateTime AddTime
        {
            get{ return _addtime; }
            set{ _addtime = value; }
        }        
				
		private bool? _isread;
        
		/// <summary>
		/// IsRead
        /// </summary>
        public bool? IsRead
        {
            get{ return _isread; }
            set{ _isread = value; }
        }        
				
		private int _status = Int32.MinValue;
        
		/// <summary>
		/// Status
        /// </summary>
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
        }        
		   
	}
}

