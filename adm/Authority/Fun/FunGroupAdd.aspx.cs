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
    public partial class FunGroupAdd : WebBase.Edit
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
            ddlParent.Items.Add(new ListItem("选择上级","0"));
            GetSub("0");
        }

        private void GetSub(string pid)
        {
            DataRow[] rows = dtAll.Select("ParentID=" + pid);
            foreach (DataRow row in rows)
            {
                ddlParent.Items.Add(new ListItem("├".PadLeft((int)row["Depth"]+1, '　') + "　" + row["GroupName"].ToString(), row["Id"].ToString()));
                GetSub(row["Id"].ToString());
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请填写名称"); return;
            }
            Model.FunGroup model = new Model.FunGroup();
            model.GroupName = txtName.Text.Trim();
            model.IsShow = true;
            model.ParentID = int.Parse(ddlParent.SelectedValue);
            if (model.ParentID == 0)
            {
                model.Depth = 0;
            }
            else
            {
                model.Depth = BLL.FunGroup.GetModel(model.ParentID).Depth + 1;
            }

            if (BLL.FunGroup.Add(model) > 0)
            {
                MessageBox.ShowAndRedirect("添加成功",ListUrl);
            }
        }
    }
}