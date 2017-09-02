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

        private int _id = Int32.MinValue;

        /// <summary>
        /// Id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int? _serialnumber;

        /// <summary>
        /// 代理商编号
        /// </summary>
        public int? SerialNumber
        {
            get { return _serialnumber; }
            set { _serialnumber = value; }
        }

        private string _loginname;

        /// <summary>
        /// LoginName
        /// </summary>
        public string LoginName
        {
            get { return _loginname; }
            set { _loginname = value; }
        }

        private string _password;

        /// <summary>
        /// Password
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _realname;

        /// <summary>
        /// Realname
        /// </summary>
        public string Realname
        {
            get { return _realname; }
            set { _realname = value; }
        }

        private int _sex = Int32.MinValue;

        /// <summary>
        /// 0为男，1为女
        /// </summary>
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
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

        private string _pic;

        /// <summary>
        /// 头像
        /// </summary>
        public string Pic
        {
            get { return _pic; }
            set { _pic = value; }
        }

        private string _height;

        /// <summary>
        /// Height
        /// </summary>
        public string Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private DateTime _addtime = DateTime.MinValue;

        /// <summary>
        /// AddTime
        /// </summary>
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        private int _status = Int32.MinValue;

        /// <summary>
        /// 状态：1正常，0禁用，-1删除
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private DateTime _logintime = DateTime.MinValue;

        /// <summary>
        /// LoginTime
        /// </summary>
        public DateTime LoginTime
        {
            get { return _logintime; }
            set { _logintime = value; }
        }

        private string _loginip;

        /// <summary>
        /// LoginIP
        /// </summary>
        public string LoginIP
        {
            get { return _loginip; }
            set { _loginip = value; }
        }

        private string _loginaddress;

        /// <summary>
        /// LoginAddress
        /// </summary>
        public string LoginAddress
        {
            get { return _loginaddress; }
            set { _loginaddress = value; }
        }

        private DateTime _lastlogintime = DateTime.MinValue;

        /// <summary>
        /// LastLoginTime
        /// </summary>
        public DateTime LastLoginTime
        {
            get { return _lastlogintime; }
            set { _lastlogintime = value; }
        }

        private string _lastip;

        /// <summary>
        /// LastIP
        /// </summary>
        public string LastIP
        {
            get { return _lastip; }
            set { _lastip = value; }
        }

        private string _lastaddress;

        /// <summary>
        /// LastAddress
        /// </summary>
        public string LastAddress
        {
            get { return _lastaddress; }
            set { _lastaddress = value; }
        }

        private int _logincount = Int32.MinValue;

        /// <summary>
        /// LoginCount
        /// </summary>
        public int LoginCount
        {
            get { return _logincount; }
            set { _logincount = value; }
        }

        private DateTime _updatetime = DateTime.MinValue;

        /// <summary>
        /// UpdateTime
        /// </summary>
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }

        private int _roletype = Int32.MinValue;

        /// <summary>
        /// 角色类型：0普通角色，1超级管理员
        /// </summary>
        public int RoleType
        {
            get { return _roletype; }
            set { _roletype = value; }
        }

        private int _zhiwei = Int32.MinValue;

        /// <summary>
        /// 0为员工，1为管理
        /// </summary>
        public int ZhiWei
        {
            get { return _zhiwei; }
            set { _zhiwei = value; }
        }

        private int _zaigang = Int32.MinValue;

        /// <summary>
        /// 在岗状态，0为在岗，1为离职
        /// </summary>
        public int ZaiGang
        {
            get { return _zaigang; }
            set { _zaigang = value; }
        }

        private string _gangwei;

        /// <summary>
        /// GangWei
        /// </summary>
        public string GangWei
        {
            get { return _gangwei; }
            set { _gangwei = value; }
        }

        private string _department;

        /// <summary>
        /// 部门
        /// </summary>
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        private string _born;

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Born
        {
            get { return _born; }
            set { _born = value; }
        }

        private string _mingzu;

        /// <summary>
        /// 民族
        /// </summary>
        public string MingZu
        {
            get { return _mingzu; }
            set { _mingzu = value; }
        }

        private string _shenfengzheng;

        /// <summary>
        /// 身份证
        /// </summary>
        public string ShenFengZheng
        {
            get { return _shenfengzheng; }
            set { _shenfengzheng = value; }
        }

        private string _marital;

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string Marital
        {
            get { return _marital; }
            set { _marital = value; }
        }

        private string _zhenzhi;

        /// <summary>
        /// 政治面貌
        /// </summary>
        public string ZhenZhi
        {
            get { return _zhenzhi; }
            set { _zhenzhi = value; }
        }

        private string _guanji;

        /// <summary>
        /// 籍贯
        /// </summary>
        public string GuanJi
        {
            get { return _guanji; }
            set { _guanji = value; }
        }

        private string _hukou;

        /// <summary>
        /// 户口所在地
        /// </summary>
        public string HuKou
        {
            get { return _hukou; }
            set { _hukou = value; }
        }

        private string _xueli;

        /// <summary>
        /// 学历
        /// </summary>
        public string XueLi
        {
            get { return _xueli; }
            set { _xueli = value; }
        }

        private string _zhicheng;

        /// <summary>
        /// 职称
        /// </summary>
        public string ZhiCheng
        {
            get { return _zhicheng; }
            set { _zhicheng = value; }
        }

        private string _biyexuexiao;

        /// <summary>
        /// 毕业院校
        /// </summary>
        public string BiYeXueXiao
        {
            get { return _biyexuexiao; }
            set { _biyexuexiao = value; }
        }

        private string _zhuanye;

        /// <summary>
        /// 专业
        /// </summary>
        public string ZhuanYe
        {
            get { return _zhuanye; }
            set { _zhuanye = value; }
        }

        private string _gongzuotime;

        /// <summary>
        /// 参加工作时间
        /// </summary>
        public string GongZuoTime
        {
            get { return _gongzuotime; }
            set { _gongzuotime = value; }
        }

        private string _jiarutime;

        /// <summary>
        /// 加入公司时间
        /// </summary>
        public string JiaRuTime
        {
            get { return _jiarutime; }
            set { _jiarutime = value; }
        }

        private string _graduationtime;

        /// <summary>
        /// 毕业时间
        /// </summary>
        public string GraduationTime
        {
            get { return _graduationtime; }
            set { _graduationtime = value; }
        }

        private string _shouji;

        /// <summary>
        /// 手机
        /// </summary>
        public string ShouJi
        {
            get { return _shouji; }
            set { _shouji = value; }
        }

        private string _jiatingaddress;

        /// <summary>
        /// 家庭详细住址
        /// </summary>
        public string JiaTingAddress
        {
            get { return _jiatingaddress; }
            set { _jiatingaddress = value; }
        }

        private string _jiaoyu;

        /// <summary>
        /// 教育背景
        /// </summary>
        public string JiaoYu
        {
            get { return _jiaoyu; }
            set { _jiaoyu = value; }
        }

        private string _hetong;

        /// <summary>
        /// 劳动合同签订情况
        /// </summary>
        public string HeTong
        {
            get { return _hetong; }
            set { _hetong = value; }
        }

        private string _shebao;

        /// <summary>
        /// 社保缴纳情况
        /// </summary>
        public string SheBao
        {
            get { return _shebao; }
            set { _shebao = value; }
        }

        private string _notes;

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        private string _fujian;

        /// <summary>
        /// 附件
        /// </summary>
        public string FuJian
        {
            get { return _fujian; }
            set { _fujian = value; }
        }

        private string _code;

        /// <summary>
        /// 邮编
        /// </summary>
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private int? _fk_id;

        /// <summary>
        /// fk_id
        /// </summary>
        public int? fk_id
        {
            get { return _fk_id; }
            set { _fk_id = value; }
        }

        private int? _sk_id;

        /// <summary>
        /// sk_id
        /// </summary>
        public int? sk_id
        {
            get { return _sk_id; }
            set { _sk_id = value; }
        }

        private int? _tk_id;

        /// <summary>
        /// tk_id
        /// </summary>
        public int? tk_id
        {
            get { return _tk_id; }
            set { _tk_id = value; }
        }

        private string _waiyu1;

        /// <summary>
        /// WaiYu1
        /// </summary>
        public string WaiYu1
        {
            get { return _waiyu1; }
            set { _waiyu1 = value; }
        }

        private string _waiyu2;

        /// <summary>
        /// WaiYu2
        /// </summary>
        public string WaiYu2
        {
            get { return _waiyu2; }
            set { _waiyu2 = value; }
        }

        private string _dengji1;

        /// <summary>
        /// DengJi1
        /// </summary>
        public string DengJi1
        {
            get { return _dengji1; }
            set { _dengji1 = value; }
        }

        private string _dengji2;

        /// <summary>
        /// DengJi2
        /// </summary>
        public string DengJi2
        {
            get { return _dengji2; }
            set { _dengji2 = value; }
        }

        private int? _d_id;

        /// <summary>
        /// 代理所属上级ID
        /// </summary>
        public int? D_Id
        {
            get { return _d_id; }
            set { _d_id = value; }
        }

        private string _source;

        /// <summary>
        /// 来源
        /// </summary>
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }

        private string _companyname;

        /// <summary>
        /// CompanyName
        /// </summary>
        public string CompanyName
        {
            get { return _companyname; }
            set { _companyname = value; }
        }

        private string _qqweixin;

        /// <summary>
        /// QQWeiXin
        /// </summary>
        public string QQWeiXin
        {
            get { return _qqweixin; }
            set { _qqweixin = value; }
        }

        private int? _jefen;

        /// <summary>
        /// JeFen
        /// </summary>
        public int? JeFen
        {
            get { return _jefen; }
            set { _jefen = value; }
        }

        private int? _t_id;

        /// <summary>
        /// 推荐码ID
        /// </summary>
        public int? T_ID
        {
            get { return _t_id; }
            set { _t_id = value; }
        }

        private decimal? _zhekou;

        /// <summary>
        /// 折扣
        /// </summary>
        public decimal? ZheKou
        {
            get { return _zhekou; }
            set { _zhekou = value; }
        }

        private decimal? _tjzhekou;

        /// <summary>
        /// 推荐的下级代理享受折扣
        /// </summary>
        public decimal? TJZheKou
        {
            get { return _tjzhekou; }
            set { _tjzhekou = value; }
        }

        private string _openbank;

        /// <summary>
        /// 开户银行
        /// </summary>
        public string Openbank
        {
            get { return _openbank; }
            set { _openbank = value; }
        }

        private string _openbankcard;

        /// <summary>
        /// 开户银行号
        /// </summary>
        public string OpenbankCard
        {
            get { return _openbankcard; }
            set { _openbankcard = value; }
        }

        private string _opencity;

        /// <summary>
        /// 开户城市
        /// </summary>
        public string OpenCity
        {
            get { return _opencity; }
            set { _opencity = value; }
        }

        private int _ispayment = Int32.MinValue;

        /// <summary>
        /// 0为未付定金，1为已付定金
        /// </summary>
        public int IsPayment
        {
            get { return _ispayment; }
            set { _ispayment = value; }
        }

        private int _verifystatus = Int32.MinValue;

        /// <summary>
        /// 新注册是否已审核:0未审核，1审核通过，-1审核不通过
        /// </summary>
        public int VerifyStatus
        {
            get { return _verifystatus; }
            set { _verifystatus = value; }
        }

        private string _pic2;

        /// <summary>
        /// 身份证图片（正面）
        /// </summary>
        public string Pic2
        {
            get { return _pic2; }
            set { _pic2 = value; }
        }

        private string _pic4;

        /// <summary>
        /// 反面
        /// </summary>
        public string Pic4
        {
            get { return _pic4; }
            set { _pic4 = value; }
        }

        private string _pic3;

        /// <summary>
        /// 营业执照
        /// </summary>
        public string Pic3
        {
            get { return _pic3; }
            set { _pic3 = value; }
        }

        private int? _ischeck;

        /// <summary>
        /// 0为未提交审核，1为已提交审核，2为审核已通过
        /// </summary>
        public int? IsCheck
        {
            get { return _ischeck; }
            set { _ischeck = value; }
        }

        private int? _ischecktype;

        /// <summary>
        /// 审核类型，1为 微商  2 淘宝  3商户 4个体 
        /// </summary>
        public int? IsCheckType
        {
            get { return _ischecktype; }
            set { _ischecktype = value; }
        }
       
    }
}

