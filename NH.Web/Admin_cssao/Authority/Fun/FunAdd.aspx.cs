using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Authority.Fun
{
    public partial class FunAdd : WebBase.Edit
    {
        DataTable dtAll = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindParent();
            }
        }

        private void BindParent()
        {
            dtAll = BLL.FunGroup.GetList("").Tables[0];
            ddlParent.Items.Add(new ListItem("选择所属组", "0"));
            GetSub("0");
        }

        private void GetSub(string pid)
        {
            DataRow[] rows = dtAll.Select("ParentID=" + pid);
            foreach (DataRow row in rows)
            {
                ddlParent.Items.Add(new ListItem("├".PadLeft((int)row["Depth"] + 1, '　') + "　" + row["GroupName"].ToString(), row["Id"].ToString()));
                GetSub(row["Id"].ToString());
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.FunCode model = new Model.FunCode();
            model.Name = txtName.Text.Trim();
            model.Code = txtCode.Text.Trim();
            model.FunType = int.Parse(rblFunType.SelectedValue);
            model.GroupId = int.Parse(ddlParent.SelectedValue);

            if (BLL.FunCode.Add(model) > 0)
            {  //写系统日志
                Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
                MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
                MyRiZhi.DoSomething = "添加功能名称(" + txtName.Text.Trim() + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                BLL.ERPRiZhi.Add(MyRiZhi);
                MessageBox.ShowAndRedirect("添加成功", ListUrl);
            }
        }
    }
}