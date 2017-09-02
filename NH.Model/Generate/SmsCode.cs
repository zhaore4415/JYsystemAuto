using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// SmsCode
	/// </summary>
	public class SmsCode
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
		/// 如果是已登录用户，记录用户id，未登录为0
        /// </summary>
        public int UserId
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
				
		private int _usertype = Int32.MinValue;
        
		/// <summary>
		/// 用户类型
        /// </summary>
        public int UserType
        {
            get{ return _usertype; }
            set{ _usertype = value; }
        }        
				
		private string _code;
        
		/// <summary>
		/// 验证码
        /// </summary>
        public string Code
        {
            get{ return _code; }
            set{ _code = value; }
        }        
				
		private int _codetype = Int32.MinValue;
        
		/// <summary>
		/// 验证码类型：1个人用户注册时手机验证，2个人用户更换手机时验证
        /// </summary>
        public int CodeType
        {
            get{ return _codetype; }
            set{ _codetype = value; }
        }        
				
		private DateTime _addtime = DateTime.MinValue;
        
		/// <summary>
		/// 创建时间
        /// </summary>
        public DateTime AddTime
        {
            get{ return _addtime; }
            set{ _addtime = value; }
        }        
				
		private int _status = Int32.MinValue;
        
		/// <summary>
		/// 状态：1未使用，0已使用
        /// </summary>
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
        }        
				
		private string _ip;
        
		/// <summary>
		/// IP
        /// </summary>
        public string IP
        {
            get{ return _ip; }
            set{ _ip = value; }
        }        
				
		private string _mobile;
        
		/// <summary>
		/// Mobile
        /// </summary>
        public string Mobile
        {
            get{ return _mobile; }
            set{ _mobile = value; }
        }        
		   
	}
}

