using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace NH.Model
{
    /// <summary>
    /// User
    /// </summary>
    public partial class User
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

        private string _loginname;

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName
        {
            get { return _loginname; }
            set { _loginname = value; }
        }

        private string _password;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _photo;

        /// <summary>
        /// Photo
        /// </summary>
        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        private DateTime _addtime = DateTime.MinValue;

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        private int _status = Int32.MinValue;

        /// <summary>
        /// 状态：-1删除，0禁用，1正常
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private DateTime _logintime = DateTime.MinValue;

        /// <summary>
        /// 本次登录时间
        /// </summary>
        public DateTime LoginTime
        {
            get { return _logintime; }
            set { _logintime = value; }
        }

        private string _loginip;

        /// <summary>
        /// 本次登录IP
        /// </summary>
        public string LoginIP
        {
            get { return _loginip; }
            set { _loginip = value; }
        }

        private string _loginaddress;

        /// <summary>
        /// 本次登录地点
        /// </summary>
        public string LoginAddress
        {
            get { return _loginaddress; }
            set { _loginaddress = value; }
        }

        private DateTime _lastlogintime = DateTime.MinValue;

        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime LastLoginTime
        {
            get { return _lastlogintime; }
            set { _lastlogintime = value; }
        }

        private string _lastip;

        /// <summary>
        /// 上次登录IP
        /// </summary>
        public string LastIP
        {
            get { return _lastip; }
            set { _lastip = value; }
        }

        private string _lastaddress;

        /// <summary>
        /// 上次登录地点
        /// </summary>
        public string LastAddress
        {
            get { return _lastaddress; }
            set { _lastaddress = value; }
        }

        private int? _logincount;

        /// <summary>
        /// 登录次数
        /// </summary>
        public int? LoginCount
        {
            get { return _logincount; }
            set { _logincount = value; }
        }

        private decimal? _completed;

        /// <summary>
        /// 信息完善程度
        /// </summary>
        public decimal? Completed
        {
            get { return _completed; }
            set { _completed = value; }
        }

        private DateTime _updatetime = DateTime.MinValue;

        /// <summary>
        /// 资料更新时间
        /// </summary>
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }

        private DateTime _refreshtime = DateTime.MinValue;

        /// <summary>
        /// 刷新时间
        /// </summary>
        public DateTime RefreshTime
        {
            get { return _refreshtime; }
            set { _refreshtime = value; }
        }

        private int _usertype = Int32.MinValue;

        /// <summary>
        /// 用户类型：1个人，2企业
        /// </summary>
        public int UserType
        {
            get { return _usertype; }
            set { _usertype = value; }
        }

        private string _photooriginal;

        /// <summary>
        /// 原始图片
        /// </summary>
        public string PhotoOriginal
        {
            get { return _photooriginal; }
            set { _photooriginal = value; }
        }

        private string _photocoording;

        /// <summary>
        /// 头像截取坐标(x1,y1,x2,y2)
        /// </summary>
        public string PhotoCoording
        {
            get { return _photocoording; }
            set { _photocoording = value; }
        }

        private int? _photoverifystatus;

        /// <summary>
        /// 头像审核状态：0未审核，1审核通过，-1审核不通过
        /// </summary>
        public int? PhotoVerifyStatus
        {
            get { return _photoverifystatus; }
            set { _photoverifystatus = value; }
        }

        private string _photonew;

        /// <summary>
        /// 新截取的头像(临时存放)
        /// </summary>
        public string PhotoNew
        {
            get { return _photonew; }
            set { _photonew = value; }
        }

        private string _sessionid;

        /// <summary>
        /// SessionId
        /// </summary>
        public string SessionId
        {
            get { return _sessionid; }
            set { _sessionid = value; }
        }

        private string _phone;

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _email;

        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _address;

        /// <summary>
        /// Address
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _qq;

        /// <summary>
        /// QQ
        /// </summary>
        public string QQ
        {
            get { return _qq; }
            set { _qq = value; }
        }

        private int _sex = Int32.MinValue;

        /// <summary>
        /// Sex
        /// </summary>
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        private string _source;

        /// <summary>
        /// Source
        /// </summary>
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }

        private string _environment;

        /// <summary>
        /// 居住环境
        /// </summary>
        public string Environment
        {
            get { return _environment; }
            set { _environment = value; }
        }

        private string _text1;

        /// <summary>
        /// 城市
        /// </summary>
        public string Text1
        {
            get { return _text1; }
            set { _text1 = value; }
        }

        private string _text2;

        /// <summary>
        /// 省
        /// </summary>
        public string Text2
        {
            get { return _text2; }
            set { _text2 = value; }
        }

        private int? _text3;

        /// <summary>
        /// 是否有小孩
        /// </summary>
        public int? Text3
        {
            get { return _text3; }
            set { _text3 = value; }
        }

        private int? _text4;

        /// <summary>
        /// 家中是否有老人
        /// </summary>
        public int? Text4
        {
            get { return _text4; }
            set { _text4 = value; }
        }

        private int? _text5;

        /// <summary>
        /// 家中是否有宠物
        /// </summary>
        public int? Text5
        {
            get { return _text5; }
            set { _text5 = value; }
        }

        private int? _text6;

        /// <summary>
        /// 是否易过敏
        /// </summary>
        public int? Text6
        {
            get { return _text6; }
            set { _text6 = value; }
        }

        private string _text7;

        /// <summary>
        /// 产品使用场所
        /// </summary>
        public string Text7
        {
            get { return _text7; }
            set { _text7 = value; }
        }

        private string _text9;

        /// <summary>
        /// 产品香味爱好
        /// </summary>
        public string Text9
        {
            get { return _text9; }
            set { _text9 = value; }
        }

        private string _text10;

        /// <summary>
        /// 信息推送方式
        /// </summary>
        public string Text10
        {
            get { return _text10; }
            set { _text10 = value; }
        }

        private string _text11;

        /// <summary>
        /// 信息推送频率
        /// </summary>
        public string Text11
        {
            get { return _text11; }
            set { _text11 = value; }
        }

        private string _age;

        /// <summary>
        /// 年龄
        /// </summary>
        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }
        /// <summary>
        /// Depth
        /// </summary>		
        private int _depth = Int32.MinValue;
        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }
        /// <summary>
        /// ParentID
        /// </summary>		
        private int _parentid = Int32.MinValue;
        public int ParentID
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// Path
        /// </summary>		
        private string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        private int? _ordernumber;

        /// <summary>
        /// 0为京东，1为天猫，2为1号店，10为其它...
        /// </summary>
        public int? Ordernumber
        {
            get { return _ordernumber; }
            set { _ordernumber = value; }
        }

        private decimal? _orderAmount;

        /// <summary>
        /// 信息完善程度
        /// </summary>
        public decimal? OrderAmount
        {
            get { return _orderAmount; }
            set { _orderAmount = value; }
        }
        public string IdNumber { get; set; }
        public string Openbank { get; set; }
        public string OpenbankCard { get; set; }
        public string OpenCity { get; set; }
        public string Pic2 { get; set; }
        public string Pic4 { get; set; }
    }
}

