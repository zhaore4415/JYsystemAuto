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
    public partial class FunModify : WebBase.Edit
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

        private void Show()
        {
            Model.FunCode model = BLL.FunCode.GetModel(Id);
            txtName.Text = model.Name;
            txtCode.Text = model.Code;
            rblFunType.SelectedValue = model.FunType.ToString();
            try
            {
                ddlParent.SelectedValue = model.GroupId.ToString();
            }
            catch
            { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.FunCode model = new Model.FunCode();
            model.Name = txtName.Text.Trim();
            model.Code = txtCode.Text.Trim();
            model.FunType = int.Parse(rblFunType.SelectedValue);
            model.GroupId = int.Parse(ddlParent.SelectedValue);

            model.Id = Id;
            if (BLL.FunCode.Update(model))
            {
                MessageBox.ShowAndRedirect("修改成功", ListUrl);
            }
        }
    }
}