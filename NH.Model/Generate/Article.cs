using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// Article
	/// </summary>
	public partial class Article
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
				
		private int _categoryid = Int32.MinValue;
        
		/// <summary>
		/// CategoryID
        /// </summary>
        public int CategoryID
        {
            get{ return _categoryid; }
            set{ _categoryid = value; }
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
				
		private string _url;
        
		/// <summary>
		/// 链接地址(如果填写了链接，点击标题将直接跳转到指定的url)
        /// </summary>
        public string Url
        {
            get{ return _url; }
            set{ _url = value; }
        }        
				
		private DateTime _addtime = DateTime.MinValue;
        
		/// <summary>
		/// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            get{ return _addtime; }
            set{ _addtime = value; }
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
				
		private int _hits = Int32.MinValue;
        
		/// <summary>
		/// 浏览次数
        /// </summary>
        public int Hits
        {
            get{ return _hits; }
            set{ _hits = value; }
        }        
				
		private bool? _istop;
        
		/// <summary>
		/// 是否置顶
        /// </summary>
        public bool? IsTop
        {
            get{ return _istop; }
            set{ _istop = value; }
        }        
				
		private bool? _ishilight;
        
		/// <summary>
		/// 是否高亮显示
        /// </summary>
        public bool? IsHilight
        {
            get{ return _ishilight; }
            set{ _ishilight = value; }
        }        
				
		private int _adduserid = Int32.MinValue;
        
		/// <summary>
		/// 添加人id
        /// </summary>
        public int AddUserId
        {
            get{ return _adduserid; }
            set{ _adduserid = value; }
        }        
				
		private DateTime? _updatetime;
        
		/// <summary>
		/// 更新时间
        /// </summary>
        public DateTime? UpdateTime
        {
            get{ return _updatetime; }
            set{ _updatetime = value; }
        }        
				
		private string _files;
        
		/// <summary>
		/// 附件文件名
        /// </summary>
        public string Files
        {
            get{ return _files; }
            set{ _files = value; }
        }        
		   
	}
}

