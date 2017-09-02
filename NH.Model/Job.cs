using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// Job
	/// </summary>
	public partial class Job
	{
        /// <summary>
        /// 获取性别文字描述:不限、男、女
        /// </summary>
        public string SexString
        {
            get
            {
                string result = null;
                switch(this._sex)
                {
                    case -1:
                        result ="不限";
                        break;
                    case 0:
                        result= "女";
                        break;
                    case 1:
                        result= "男";
                        break;
                    default:
                        result= "";
                        break;
                }
                return result;
            }
        }

        /// <summary>
        /// 是否报销路费：-1，面议；0不报销；1报销
        /// </summary>
        public string CarFareString
        {
            get
            {
                string result = null;
                switch (this._iscarfare)
                {
                    case -1:
                        result = "面议";
                        break;
                    case 0:
                        result = "不报销";
                        break;
                    case 1:
                        result = "报销";
                        break;
                    default:
                        result = "";
                        break;
                }
                return result;
            }
        }

        /// <summary>
        /// 是否提供食宿：-1，面议；0不提供；1提供
        /// </summary>
        public string HousingString
        {
            get
            {
                string result = null;
                switch (this._ishousing)
                {
                    case -1:
                        result = "面议";
                        break;
                    case 0:
                        result = "不提供";
                        break;
                    case 1:
                        result = "提供";
                        break;
                    default:
                        result = "";
                        break;
                }
                return result;
            }
        }

	}
}

