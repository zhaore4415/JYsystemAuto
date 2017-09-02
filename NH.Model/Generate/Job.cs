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

        private int _id = Int32.MinValue;

        /// <summary>
        /// Id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _jobtitle;

        /// <summary>
        /// 招聘信息标题
        /// </summary>
        public string JobTitle
        {
            get { return _jobtitle; }
            set { _jobtitle = value; }
        }

        private int _companyid = Int32.MinValue;

        /// <summary>
        /// 企业id
        /// </summary>
        public int CompanyID
        {
            get { return _companyid; }
            set { _companyid = value; }
        }

        private string _categoryno;

        /// <summary>
        /// CategoryNo
        /// </summary>
        public string CategoryNo
        {
            get { return _categoryno; }
            set { _categoryno = value; }
        }

        private int _salaryid = Int32.MinValue;

        /// <summary>
        /// 薪酬
        /// </summary>
        public int SalaryID
        {
            get { return _salaryid; }
            set { _salaryid = value; }
        }

        private bool? _commission;

        /// <summary>
        /// 是否需要提成
        /// </summary>
        public bool? Commission
        {
            get { return _commission; }
            set { _commission = value; }
        }

        private string _jobtypeid;

        /// <summary>
        /// 工作方式(存id，多个用逗号分隔)
        /// </summary>
        public string JobTypeID
        {
            get { return _jobtypeid; }
            set { _jobtypeid = value; }
        }

        private string _jobtypename;

        /// <summary>
        /// 工作方式(文字，多个用逗号分隔)
        /// </summary>
        public string JobTypeName
        {
            get { return _jobtypename; }
            set { _jobtypename = value; }
        }

        private string _degreeid;

        /// <summary>
        /// 教育程度(存ID,多个用逗号分隔)
        /// </summary>
        public string DegreeID
        {
            get { return _degreeid; }
            set { _degreeid = value; }
        }

        private string _degreename;

        /// <summary>
        /// 教育程度(学历名称,多个用逗号分隔)
        /// </summary>
        public string DegreeName
        {
            get { return _degreename; }
            set { _degreename = value; }
        }

        private int _experienceid = Int32.MinValue;

        /// <summary>
        /// 工作经验：-1不限，0实习期，1一年，2两年....
        /// </summary>
        public int ExperienceID
        {
            get { return _experienceid; }
            set { _experienceid = value; }
        }

        private int _sex = Int32.MinValue;

        /// <summary>
        /// 性别：-1不限，0女，1男
        /// </summary>
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        private int _iscarfare = Int32.MinValue;

        /// <summary>
        /// 是否报销路费：-1，面议；0不需要；1需要
        /// </summary>
        public int IsCarFare
        {
            get { return _iscarfare; }
            set { _iscarfare = value; }
        }

        private int _ishousing = Int32.MinValue;

        /// <summary>
        /// 是否提供食宿：-1面议，0不需要，1需要
        /// </summary>
        public int IsHousing
        {
            get { return _ishousing; }
            set { _ishousing = value; }
        }

        private string _worktime;

        /// <summary>
        /// 工作时间
        /// </summary>
        public string WorkTime
        {
            get { return _worktime; }
            set { _worktime = value; }
        }

        private int _quantity = Int32.MinValue;

        /// <summary>
        /// 招聘人数，0为不限
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        private DateTime? _expiredate;

        /// <summary>
        /// 有效期，为null则不限
        /// </summary>
        public DateTime? ExpireDate
        {
            get { return _expiredate; }
            set { _expiredate = value; }
        }

        private string _description;

        /// <summary>
        /// 内容
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private int _status = Int32.MinValue;

        /// <summary>
        /// 状态：1显示，0隐藏，-1逻辑删除
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int _verified = Int32.MinValue;

        /// <summary>
        /// 审核状态：0未审核，1审核通过，-1审核不通过
        /// </summary>
        public int Verified
        {
            get { return _verified; }
            set { _verified = value; }
        }

        private DateTime _addtime = DateTime.MinValue;

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        private int _viewcount = Int32.MinValue;

        /// <summary>
        /// 浏览量
        /// </summary>
        public int ViewCount
        {
            get { return _viewcount; }
            set { _viewcount = value; }
        }

        private DateTime _updatetime = DateTime.MinValue;

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }

        private DateTime _refreshtime = DateTime.MinValue;

        /// <summary>
        /// 置顶时间
        /// </summary>
        public DateTime RefreshTime
        {
            get { return _refreshtime; }
            set { _refreshtime = value; }
        }

        private bool? _isfix;

        /// <summary>
        /// 信息套红
        /// </summary>
        public bool? IsFix
        {
            get { return _isfix; }
            set { _isfix = value; }
        }

        private string _description_new;

        /// <summary>
        /// Description_New
        /// </summary>
        public string Description_New
        {
            get { return _description_new; }
            set { _description_new = value; }
        }

        private string _salarydesc;

        /// <summary>
        /// SalaryDesc
        /// </summary>
        public string SalaryDesc
        {
            get { return _salarydesc; }
            set { _salarydesc = value; }
        }

        private string _workcontent;

        /// <summary>
        /// WorkContent
        /// </summary>
        public string WorkContent
        {
            get { return _workcontent; }
            set { _workcontent = value; }
        }

        private string _requirements;

        /// <summary>
        /// Requirements
        /// </summary>
        public string Requirements
        {
            get { return _requirements; }
            set { _requirements = value; }
        }

        private string _roomandfood;

        /// <summary>
        /// RoomAndFood
        /// </summary>
        public string RoomAndFood
        {
            get { return _roomandfood; }
            set { _roomandfood = value; }
        }

        private string _welfare;

        /// <summary>
        /// Welfare
        /// </summary>
        public string Welfare
        {
            get { return _welfare; }
            set { _welfare = value; }
        }

        private string _jobtitle_new;

        /// <summary>
        /// Jobtitle_New
        /// </summary>
        public string Jobtitle_New
        {
            get { return _jobtitle_new; }
            set { _jobtitle_new = value; }
        }

        private string _salarydesc_new;

        /// <summary>
        /// SalaryDesc_New
        /// </summary>
        public string SalaryDesc_New
        {
            get { return _salarydesc_new; }
            set { _salarydesc_new = value; }
        }

        private string _workcontent_new;

        /// <summary>
        /// WorkContent_New
        /// </summary>
        public string WorkContent_New
        {
            get { return _workcontent_new; }
            set { _workcontent_new = value; }
        }

        private string _requirements_new;

        /// <summary>
        /// Requirements_New
        /// </summary>
        public string Requirements_New
        {
            get { return _requirements_new; }
            set { _requirements_new = value; }
        }

        private string _roomandfood_new;

        /// <summary>
        /// RoomAndFood_New
        /// </summary>
        public string RoomAndFood_New
        {
            get { return _roomandfood_new; }
            set { _roomandfood_new = value; }
        }

        private string _welfare_new;

        /// <summary>
        /// Welfare_New
        /// </summary>
        public string Welfare_New
        {
            get { return _welfare_new; }
            set { _welfare_new = value; }
        }

        private string _workaddress;

        /// <summary>
        /// WorkAddress
        /// </summary>
        public string WorkAddress
        {
            get { return _workaddress; }
            set { _workaddress = value; }
        }

    }
}

