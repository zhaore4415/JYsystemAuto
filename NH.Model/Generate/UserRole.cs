using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// UserRole
	/// </summary>
	public partial class UserRole
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
		/// UserId
        /// </summary>
        public int UserId
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
				
		private int _roleid = Int32.MinValue;
        
		/// <summary>
		/// RoleId
        /// </summary>
        public int RoleId
        {
            get{ return _roleid; }
            set{ _roleid = value; }
        }        
		   
	}
}

