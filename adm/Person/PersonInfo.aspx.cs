using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NH.Web.adm.Person
{
    public partial class PersonInfo : WebBase.Edit
    {
        #region 基本信息
        protected string _errormsg = null;
        protected string _realname;
        protected string _marrage;
        protected string _sex;
        protected string _degree;
        protected string _age;
        protected string _experience;
        protected string _birthday;
        protected string _residence;
        protected string _height;
        protected string _curaddr;
        #endregion
        #region 联系方式
        protected string _mobile;
        protected string _qq;
        protected string _phone;
        protected string _email;
        protected string _zipcode;
        protected string _homepage;
        protected string _address;
        #endregion
        #region 个人简历
        protected string _housing;
        protected string _carfare;
        protected string _jobcategory;
        protected string _jobaddr;
        protected string _salary;
        protected string _jobtype;
        protected string _resume;
        protected string _education;
        protected string _hobby;
        protected string _selfEvaluation;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show();
            }
        }

        private void Show()
        {
            #region 状态判断
            int mid = 0;
            if (!int.TryParse(Request.QueryString["mid"], out mid))
            {
                return;
            }
            if (mid <= 0)
            {
                return;
            }
            DataSet ds = BLL.Member.GetPersonInfo(mid);
            if (ds.Tables[0].Rows.Count == 0 || ds.Tables[1].Rows.Count == 0)
            {
                _errormsg = "此用户不存在";
                return;
            }
            Model.User user = BLL.User.DataTableToList(ds.Tables[0])[0];
            if (user.Status != 1)
            {
                _errormsg = "此用户已被禁用";
                return;
            }
            Model.Member member = BLL.Member.DataTableToList(ds.Tables[1])[0];
            if (member.IsShow.Value == false)
            {
                _errormsg = "此用户已隐藏简历";
                return;
            }
            #endregion

            #region 基本信息
            _realname = member.Realname;
            _marrage = member.MarriageString;
            _sex = member.SexString;
            _degree = member.DegreeName;
            if (member.Birthday.HasValue)
            {
                _age = (DateTime.Now.Year - member.Birthday.Value.Year).ToString();
                _birthday = member.Birthday.Value.ToString("yyyy-MM-dd");
            }
            _residence = member.Residence;
            if (member.Height > 0)
                _height = member.Height.ToString();
            _address = member.CurAddr;
            #endregion

            #region 联系方式
            _mobile = member.Mobile;
            _qq = member.QQ;
            _phone = member.Phone;
            _email = member.Email;
            _homepage = member.HomePage;
            _address = member.Address;
            #endregion

            #region 求职意向
            _housing = member.HousingString;
            _carfare = member.CarFareString;
            _jobcategory = member.JobCategoryName;
            _jobaddr = member.JobAddr;
            _salary = member.SalaryName + (member.Commission.Value ? "+提成" : "");
            _jobtype = member.JobTypeName;
            #endregion

            #region 简历信息
            _resume = member.Resume;
            _selfEvaluation = member.SelfEvaluation;
            #endregion

            #region 个人相册
            rptAlbums.DataSource = ds.Tables[2];
            rptAlbums.DataBind();
            #endregion

            #region 个人作品
            rptWorks.DataSource = ds.Tables[3];
            rptWorks.DataBind();
            #endregion
        }

    }
}