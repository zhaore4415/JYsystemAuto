using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// Service2Company
	/// </summary>
	public partial class Service2Company
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
		/// CompanyId
        /// </summary>
        public int CompanyId
        {
            get{ return _companyid; }
            set{ _companyid = value; }
        }        
				
		private int _serviceid = Int32.MinValue;
        
		/// <summary>
		/// ServiceId
        /// </summary>
        public int ServiceId
        {
            get{ return _serviceid; }
            set{ _serviceid = value; }
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
		   
	}
}

