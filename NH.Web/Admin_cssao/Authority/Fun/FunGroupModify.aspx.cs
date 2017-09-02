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
    public partial class FunGroupModify : WebBase.Edit
    {
        DataTable dtAll = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindParent();
                Show();
            }
        }

        private void BindParent()
        {
            dtAll = BLL.FunGroup.GetList("").Tables[0];
            ddlParent.Items.Add(new ListItem("选择上级", "0"));
            GetSub("0");
        }

        private void GetSub(string pid)
        {
            DataRow[] rows = dtAll.Select("ParentID=" + pid);
            foreach (DataRow row in rows)
            {
                if ((int)row["Id"] == Id) return;
                ddlParent.Items.Add(new ListItem("├".PadLeft((int)row["Depth"] + 1, '　') + "　" + row["GroupName"].ToString(), row["Id"].ToString()));
                GetSub(row["Id"].ToString());
            }
        }

        private void Show()
        {
            Model.FunGroup model = BLL.FunGroup.GetModel(Id);
            if (model == null) Response.Redirect(ListUrl);
            txtName.Text = model.GroupName;
            try
            {
                ddlParent.SelectedValue = model.ParentID.ToString();
            }
            catch
            { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请填写名称"); return;
            }
            Model.FunGroup model = new Model.FunGroup();
            model.Id = Id;
            model.GroupName = txtName.Text.Trim();
            model.IsShow = true;
            model.ParentID = int.Parse(ddlParent.SelectedValue);
            if (model.ParentID == 0)
            {
                model.Depth = 1;
            }
            else
            {
                model.Depth = BLL.FunGroup.GetModel(model.ParentID).Depth + 1;
            }
            if (BLL.FunGroup.Update(model))
            {//写系统日志
                Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
                MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
                MyRiZhi.DoSomething = "修改功能码名称(" + txtName.Text.Trim() + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                BLL.ERPRiZhi.Add(MyRiZhi);
                MessageBox.ShowAndRedirect("修改成功", ListUrl);
            }
        }
    }
}