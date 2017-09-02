using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace NH.Model
{
	/// <summary>
	/// Member
	/// </summary>
	public partial class Member
	{
        private string _residenceProvinceId;

        /// <summary>
        /// 籍贯（省，id）
        /// </summary>
        public string ResidenceProvinceId
        {
            get 
            {
                if (!string.IsNullOrEmpty(this._residenceaddrid))
                {
                    if (this._residenceaddrid.Length >= 4)
                    {
                        return this._residenceaddrid.Substring(0,4);
                    }
                    else 
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            set { _residenceProvinceId = value; }
        }

        private string _residenceCityId;
        /// <summary>
        /// 籍贯（市，id）
        /// </summary>
        public string ResidenceCityId
        {
            get 
            {
                if (!string.IsNullOrEmpty(this._residenceaddrid))
                {
                    if (this._residenceaddrid.Length > 4)
                    {
                        return _residenceaddrid;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            set { _residenceCityId = value; }
        }

        private string _currAddrProvinceId;

        /// <summary>
        /// 当前所在地区（省,id）
        /// </summary>
        public string CurrAddrProvinceId
        {
            get
            {
                if (!string.IsNullOrEmpty(this._curraddrid))
                {
                    if (this._curraddrid.Length >= 4)
                    {
                        return this._curraddrid.Substring(0, 4);
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            set { _currAddrProvinceId = value; }
        }

        private string _currAddrCityId;

        /// <summary>
        /// 当前所在地区（市，id）
        /// </summary>
        public string CurrAddrCityId
        {
            get
            {
                if (!string.IsNullOrEmpty(this._curraddrid))
                {
                    if (this._curraddrid.Length > 4)
                    {
                        return _curraddrid;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            set { _currAddrCityId = value; }
        }

        private string _marriageString;
        /// <summary>
        /// 婚姻状况
        /// </summary>
        /// <returns></returns>
        public string MarriageString
        {
            get
            {
                switch (this.Marriage)
                {
                    case -1:
                        _marriageString = "保密";
                        break;
                    case 0:
                        _marriageString = "未婚";
                        break;
                    case 1:
                        _marriageString = "已婚";
                        break;
                }
                return _marriageString;
            }
        }

        /// <summary>
        /// 获取性别文字描述:保密、男、女
        /// </summary>
        public string SexString
        {
            get
            {
                string result = null;
                switch (this._sex)
                {
                    case -1:
                        result = "保密";
                        break;
                    case 0:
                        result = "女";
                        break;
                    case 1:
                        result = "男";
                        break;
                    default:
                        result = "";
                        break;
                }
                return result;
            }
        }

        /// <summary>
        /// 食宿
        /// </summary>
        public string HousingString
        {
            get
            {
                string result = null;
                switch(this.IsHousing)
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
                }
                return result;
            }
        }

        /// <summary>
        /// 报销路费
        /// </summary>
        public string CarFareString
        {
            get
            {
                string result = null;
                switch (this.IsHousing)
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
                }
                return result;
            }
        }

        /// <summary>
        /// 基本信息是否注册完整
        /// </summary>
        public bool IsBaseInfoOk
        {
            get { return !string.IsNullOrEmpty(_realname); }
        }
	}
}

