using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// ArticleCategory
	/// </summary>
	public partial class ArticleCategory
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
		/// 文章分类名称
        /// </summary>
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }        
				
		private int _status = Int32.MinValue;
        
		/// <summary>
		/// 状态：1显示，0关闭
        /// </summary>
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
        }        
				
		private int _type = Int32.MinValue;
        
		/// <summary>
		/// 文章类型:1 会员系统消息，2 企业系统消息，3 招聘帮助，4 求职帮助，5 Hr工具
        /// </summary>
        public int Type
        {
            get{ return _type; }
            set{ _type = value; }
        }        
				
		private bool? _candelete;
        
		/// <summary>
		/// 是否可以删除
        /// </summary>
        public bool? CanDelete
        {
            get{ return _candelete; }
            set{ _candelete = value; }
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

