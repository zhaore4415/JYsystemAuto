using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// AUser
	/// </summary>
	public partial class AUser
	{
        private string _funCode;

        /// <summary>
        /// 权限
        /// </summary>
        public string FunCode
        {
            set { _funCode = value; }
            get { return _funCode; }
        }
	}
}

