using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// Salary
	/// </summary>
	public class Salary
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
				
		private string _salaryname;
        
		/// <summary>
		/// SalaryName
        /// </summary>
        public string SalaryName
        {
            get{ return _salaryname; }
            set{ _salaryname = value; }
        }        
				
		private int _status = Int32.MinValue;
        
		/// <summary>
		/// 状态：1显示，0不显示
        /// </summary>
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
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
				
		private int? _salary1;
        
		/// <summary>
		/// Salary1
        /// </summary>
        public int? Salary1
        {
            get{ return _salary1; }
            set{ _salary1 = value; }
        }        
				
		private int? _salary2;
        
		/// <summary>
		/// Salary2
        /// </summary>
        public int? Salary2
        {
            get{ return _salary2; }
            set{ _salary2 = value; }
        }        
		   
	}
}

