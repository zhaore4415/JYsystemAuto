using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// Config
    /// </summary>
    public partial class Config
    {

        private int _id = Int32.MinValue;

        /// <summary>
        /// Id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _sitename;

        /// <summary>
        /// 网站名称
        /// </summary>
        public string SiteName
        {
            get { return _sitename; }
            set { _sitename = value; }
        }

        private string _sitetitle;

        /// <summary>
        /// 网页标题
        /// </summary>
        public string SiteTitle
        {
            get { return _sitetitle; }
            set { _sitetitle = value; }
        }

        private string _sitekeyword;

        /// <summary>
        /// 网页关键字
        /// </summary>
        public string SiteKeyword
        {
            get { return _sitekeyword; }
            set { _sitekeyword = value; }
        }

        private string _sitedescription;

        /// <summary>
        /// 网页描述
        /// </summary>
        public string SiteDescription
        {
            get { return _sitedescription; }
            set { _sitedescription = value; }
        }

        private string _logo;

        /// <summary>
        /// Logo
        /// </summary>
        public string Logo
        {
            get { return _logo; }
            set { _logo = value; }
        }

        private bool? _ismobilevalidate;

        /// <summary>
        /// 注册时是否需要手机验证
        /// </summary>
        public bool? IsMobileValidate
        {
            get { return _ismobilevalidate; }
            set { _ismobilevalidate = value; }
        }

        private string _servicetel1;

        /// <summary>
        /// 400客服电话
        /// </summary>
        public string ServiceTel1
        {
            get { return _servicetel1; }
            set { _servicetel1 = value; }
        }

        private string _servicetel2;

        /// <summary>
        /// 非400客服电话
        /// </summary>
        public string ServiceTel2
        {
            get { return _servicetel2; }
            set { _servicetel2 = value; }
        }

        private string _friendlinkcontact;

        /// <summary>
        /// FriendLinkContact
        /// </summary>
        public string FriendLinkContact
        {
            get { return _friendlinkcontact; }
            set { _friendlinkcontact = value; }
        }

        private string _contactdesc;

        /// <summary>
        /// 联系方式描述信息
        /// </summary>
        public string ContactDesc
        {
            get { return _contactdesc; }
            set { _contactdesc = value; }
        }

        private string _foot;

        /// <summary>
        /// 底部信息
        /// </summary>
        public string Foot
        {
            get { return _foot; }
            set { _foot = value; }
        }

        private string _regprotocol;

        /// <summary>
        /// 注册协议
        /// </summary>
        public string RegProtocol
        {
            get { return _regprotocol; }
            set { _regprotocol = value; }
        }

        private string _watermarkpic;

        /// <summary>
        /// 水印图片
        /// </summary>
        public string WaterMarkPic
        {
            get { return _watermarkpic; }
            set { _watermarkpic = value; }
        }

        private string _sms_id;

        /// <summary>
        /// Sms_ID
        /// </summary>
        public string Sms_ID
        {
            get { return _sms_id; }
            set { _sms_id = value; }
        }

        private string _sms_account;

        /// <summary>
        /// Sms_Account
        /// </summary>
        public string Sms_Account
        {
            get { return _sms_account; }
            set { _sms_account = value; }
        }

        private string _sms_password;

        /// <summary>
        /// Sms_Password
        /// </summary>
        public string Sms_Password
        {
            get { return _sms_password; }
            set { _sms_password = value; }
        }

        private string _sms_sendmobile;

        /// <summary>
        /// Sms_SendMobile
        /// </summary>
        public string Sms_SendMobile
        {
            get { return _sms_sendmobile; }
            set { _sms_sendmobile = value; }
        }

    }
}

