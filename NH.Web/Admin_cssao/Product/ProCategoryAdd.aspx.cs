using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Maticsoft.Common;

namespace NH.Web.adm.Product
{
    public partial class ProCategoryAdd : WebBase.Edit
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategory(null, "0");
                txtSort.Text = BLL.ProCategory.GetMaxSort().ToString();
            }
        }

        private void BindCategory(DataTable dt, string parentId)
        {
            if (dt == null)
            {
                dt = BLL.ProCategory.GetList("").Tables[0];
            }
            DataRow[] rows = dt.Select("ParentID=" + parentId, "Sort");
            foreach (DataRow row in rows)
            {
                ddlCategory.Items.Add(new ListItem("├".PadLeft((int)row["Depth"], '　') + "　" + row["Name"].ToString(), row["Id"].ToString()));
                BindCategory(dt, row["Id"].ToString());
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请填写分类名称"); return;
            }
            if (!PageValidate.IsNumber(txtSort.Text.Trim()))
            {
                MessageBox.Show("显示顺序只能为数字"); return;
            }
           

            Model.ProCategory model = new Model.ProCategory();
            model.Name = txtName.Text.Trim();
            model.ParentID = int.Parse(ddlCategory.SelectedValue);
            model.Remark = txtRemark.Text;
           
            model.Sort = int.Parse(txtSort.Text.Trim());
          
            model.AddTime = DateTime.Now;
            model.Child = 0;
            

            if (ddlCategory.SelectedValue == "0")
            {
                model.Depth = 1;
                model.Path = ",0,";
            }
            else
            {
                Model.ProCategory pmodel = BLL.ProCategory.GetModel(model.ParentID);
                model.Depth = pmodel.Depth + 1;
                model.Path = pmodel.Path + model.ParentID + ",";
            }

            if (BLL.ProCategory.Add(model)>0)
            {
                //写系统日志
                Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
                MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
                MyRiZhi.DoSomething = "添加商品类别(" + txtName.Text.Trim() + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                BLL.ERPRiZhi.Add(MyRiZhi);
                MessageBox.ShowAndRedirect("添加成功", "ProCategory.aspx");
            }
            else
            {
                MessageBox.Show("添加失败"); return;
            }
        }

    }
}