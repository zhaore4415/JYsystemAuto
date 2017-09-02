using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// RoleFun
	/// </summary>
	public partial class RoleFun
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
				
		private int _roleid = Int32.MinValue;
        
		/// <summary>
		/// 角色Id
        /// </summary>
        public int RoleId
        {
            get{ return _roleid; }
            set{ _roleid = value; }
        }        
				
		private int _funid = Int32.MinValue;
        
		/// <summary>
		/// FunId
        /// </summary>
        public int FunId
        {
            get{ return _funid; }
            set{ _funid = value; }
        }        
		   
	}
}

