using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// Degree
	/// </summary>
	public class Degree
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
				
		private string _degreename;
        
		/// <summary>
		/// 学历名称
        /// </summary>
        public string DegreeName
        {
            get{ return _degreename; }
            set{ _degreename = value; }
        }        
				
		private int _sort = Int32.MinValue;
        
		/// <summary>
		/// 排序
        /// </summary>
        public int Sort
        {
            get{ return _sort; }
            set{ _sort = value; }
        }        
		   
	}
}

