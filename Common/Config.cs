using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Common
{
    public class Config
    {
        //public static string vcodeKey = "xxyy";
        #region 企业每日可置顶次数
        /*
        private static int _companyJobRefreshLimit = Int32.MinValue;
        /// <summary>
        /// 企业每日可置顶次数
        /// </summary>
        public static int CompanyJobRefreshLimit
        {
            get
            {
                if (_companyJobRefreshLimit == Int32.MinValue)
                {
                    _companyJobRefreshLimit = ConfigHelper.GetConfigInt("CompanyJobRefreshLimit");
                }
                return _companyJobRefreshLimit;
            }
            set { _companyJobRefreshLimit = value; }
        }
        */
        #endregion

        #region 个人每日可置顶次数
        private static int _personRefreshCount = Int32.MinValue;
        /// <summary>
        /// 个人每日可置顶次数
        /// </summary>
        public static int PersonRefreshCount
        {
            get
            {
                if (_personRefreshCount == Int32.MinValue)
                {
                    _personRefreshCount = ConfigHelper.GetConfigInt("PersonRefreshCount");
                }
                return _personRefreshCount;
            }
            set { _personRefreshCount = value; }
        }
        #endregion

        private static int _PersonWorksCount = Int32.MinValue;

        /// <summary>
        /// 个人会员每个分类上传作品数量限制
        /// </summary>
        public static int PersonWorksCount
        {
            get
            {
                if (_PersonWorksCount == Int32.MinValue)
                {
                    _PersonWorksCount = ConfigHelper.GetConfigInt("PersonWorksCount");
                }
                return _PersonWorksCount;
            }
            set { _PersonWorksCount = value; }
        }


        private static int _PersonWorksCategoryCount = Int32.MinValue;
        /// <summary>
        /// 个人会员作品分类数量限制
        /// </summary>
        public static int PersonWorksCategoryCount
        {
            get
            {
                if (_PersonWorksCategoryCount == Int32.MinValue)
                {
                    _PersonWorksCategoryCount = ConfigHelper.GetConfigInt("PersonWorksCategoryCount");
                }
                return _PersonWorksCategoryCount;
            }
            set { _PersonWorksCategoryCount = value; }
        }

        #region 调用CorpToken值
        /// <summary>
        /// 调用CorpToken值
        /// </summary>
        public static string CorpToken
        {
            get
            {
                return ConfigHelper.GetConfigString("CorpToken");
            }
        }
        #endregion

    }
}
