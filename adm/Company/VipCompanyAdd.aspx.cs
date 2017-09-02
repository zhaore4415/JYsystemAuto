using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Company
{
    public partial class VipCompanyAdd : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request["action"])
            {
                case "query":
                    Query();
                    break;
                case "add":
                    Add();
                    break;
                default:
                    Show();
                    break;
            }
        }

        private void Show()
        {
            rptList.DataSource = BLL.CompanyLevel.GetList(0, "Id>1", "Sort");
            rptList.DataBind();
        }

        protected string GetExpireDate(int num, string unit)
        {
            string result = null;
            if (num > 0)
            {
                switch (unit)
                {
                    case "day":
                        result = DateTime.Now.AddDays(num).ToString("yyyy-MM-dd");
                        break;
                    case "month":
                        result = DateTime.Now.AddMonths(num).ToString("yyyy-MM-dd");
                        break;
                    case "year":
                        result = DateTime.Now.AddYears(num).ToString("yyyy-MM-dd");
                        break;
                }
            }
            return result;
        }
        private void Query()
        {
            string key = Request.Form["key"].Trim();
            string keytype = Request.Form["keytype"];

            string strWhere = null;
            switch (keytype)
            { 
                case "1":
                    strWhere = "and u.Id = " + int.Parse(key);
                    break;
                case "2":
                    strWhere = "and CompanyName='" + key.Replace("'","''") + "'";
                    break;
                case "3":
                    strWhere = "and u.LoginName='" + key.Replace("'","''") + "'";
                    break;
            }
            DataTable dt = DataUtility.GetList(
                "[User] u(nolock) join Company c(nolock) on c.Id=u.Id",
                //"u.Id,u.LoginName,c.CompanyName,c.LevelID,c.ExpireDate",
                "u.LoginName,c.*",//"u.*,c.*",
                1,
                1,
                "u.Id",
                strWhere,
                "",
                false).Tables[0];

            string fmt = "{{\"CompanyId\":\"{0}\",\"cname\":\"{1}\",\"loginname\":\"{2}\",\"lname\":\"{3}\",\"isvipok\":\"{4}\"}}";
            string result = null;
            if (dt.Rows.Count > 0)
            {
                Model.Company company = BLL.Company.DataTableToList(dt)[0];
                //Model.User user = BLL.User.DataTableToList(dt)[0];
                //string cid = dt.Rows[0]["Id"].ToString();
                //string cname = dt.Rows[0]["CompanyName"].ToString();
                string loginname = dt.Rows[0]["LoginName"].ToString();
                Model.CompanyLevel level = BLL.CompanyLevel.GetModel(company.LevelID);
                company.CompanyLevel = level;
                result = string.Format(fmt,company.Id, company.CompanyName, loginname, level.LevelName, company.IsVipOk);

                Maticsoft.Common.Ajax.WriteOkAndJsonData("",result);
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("未查询到企业");
                //result = string.Format(fmt,"","","","");
            }
            //string resul = DataToJson.Obj2Json<Model.Company>(UserBase.CurCompany);

            //Maticsoft.Common.Ajax.WriteOkAndJsonData("", result);
        }

        private void Add()
        {
            int companyId = int.Parse(Request.Form["CompanyId"]);
            int levelId = int.Parse(Request.Form["LevelId"]);
            bool IsFix = Request.Form["IsFix"] == "true";

            Model.CompanyLevel level = BLL.CompanyLevel.GetModel(levelId);


            Model.Company model = new Model.Company();
            model.Id = companyId;
            model.LevelID = levelId;
            if (level.ExpireNum > 0)
            {
                try
                {
                    model.ExpireDate = DateTime.Parse(Request.Form["ExpireDate"]);
                }
                catch
                {
                    Maticsoft.Common.Ajax.WriteError("到期时间不正确！");
                }
            }
            else
            {
                model.ExpireDate = DateTime.MinValue;
            }
            model.VipOpenType = 1;

            if (BLL.Company.Update(model))
            {
                Maticsoft.Common.Ajax.WriteOk("保存成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("保存失败！");
            }
        }

    }
}