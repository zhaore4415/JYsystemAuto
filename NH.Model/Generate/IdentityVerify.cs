using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// IdentityVerify
	/// </summary>
	public class IdentityVerify
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
				
		private int _memberid = Int32.MinValue;
        
		/// <summary>
		/// MemberID
        /// </summary>
        public int MemberID
        {
            get{ return _memberid; }
            set{ _memberid = value; }
        }        
				
		private string _identityimg;
        
		/// <summary>
		/// 身份证附件(图片)路径
        /// </summary>
        public string IdentityImg
        {
            get{ return _identityimg; }
            set{ _identityimg = value; }
        }        
				
		private string _identityno;
        
		/// <summary>
		/// 身份证号码
        /// </summary>
        public string IdentityNo
        {
            get{ return _identityno; }
            set{ _identityno = value; }
        }        
				
		private DateTime _expiredate = DateTime.MinValue;
        
		/// <summary>
		/// 到期时间
        /// </summary>
        public DateTime ExpireDate
        {
            get{ return _expiredate; }
            set{ _expiredate = value; }
        }        
				
		private bool? _sex;
        
		/// <summary>
		/// 性别
        /// </summary>
        public bool? Sex
        {
            get{ return _sex; }
            set{ _sex = value; }
        }        
				
		private string _tel;
        
		/// <summary>
		/// 联系电话
        /// </summary>
        public string Tel
        {
            get{ return _tel; }
            set{ _tel = value; }
        }        
				
		private string _qq;
        
		/// <summary>
		/// QQ号
        /// </summary>
        public string QQ
        {
            get{ return _qq; }
            set{ _qq = value; }
        }        
				
		private int _status = Int32.MinValue;
        
		/// <summary>
		/// 状态：-1审核不通过，0未审核，1审核通过
        /// </summary>
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
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
		   
	}
}

