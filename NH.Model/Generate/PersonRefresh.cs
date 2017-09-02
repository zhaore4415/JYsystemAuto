using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// PersonRefresh
	/// </summary>
	public partial class PersonRefresh
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
				
		private int _memberid = Int32.MinValue;
        
		/// <summary>
		/// MemberID
        /// </summary>
        public int MemberID
        {
            get{ return _memberid; }
            set{ _memberid = value; }
        }        
				
		private DateTime _refreshtime = DateTime.MinValue;
        
		/// <summary>
		/// RefreshTime
        /// </summary>
        public DateTime RefreshTime
        {
            get{ return _refreshtime; }
            set{ _refreshtime = value; }
        }        
		   
	}
}

