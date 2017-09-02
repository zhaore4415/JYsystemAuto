using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// Experience
	/// </summary>
	public class Experience
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
				
		private string _name;
        
		/// <summary>
		/// Name
        /// </summary>
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }        
				
		private int? _year1;
        
		/// <summary>
		/// Year1
        /// </summary>
        public int? Year1
        {
            get{ return _year1; }
            set{ _year1 = value; }
        }        
				
		private int? _year2;
        
		/// <summary>
		/// Year2
        /// </summary>
        public int? Year2
        {
            get{ return _year2; }
            set{ _year2 = value; }
        }        
				
		private int _sort = Int32.MinValue;
        
		/// <summary>
		/// Sort
        /// </summary>
        public int Sort
        {
            get{ return _sort; }
            set{ _sort = value; }
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

