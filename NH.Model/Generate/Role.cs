using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// Role
	/// </summary>
	public partial class Role
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
				
		private string _rolename;
        
		/// <summary>
		/// 角色名称
        /// </summary>
        public string RoleName
        {
            get{ return _rolename; }
            set{ _rolename = value; }
        }        
				
		private int _status = Int32.MinValue;
        
		/// <summary>
		/// 状态：1正常，0停用
        /// </summary>
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
        }        
		   
	}
}

