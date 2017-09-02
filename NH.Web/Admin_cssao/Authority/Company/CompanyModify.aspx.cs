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
    public partial class CompanyModify : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindShen();

            }
        }

        private void BindShen()
        {
            Model.Shen model = new Model.Shen();
      
            model.fk_id = int.Parse(Request.QueryString["fk_id"]);
            ddlBranchOne.DataSource = BLL.Shen.GetList("");
            ddlBranchOne.DataTextField = "first_kind_name";
            ddlBranchOne.DataValueField = "fk_id";
            ddlBranchOne.DataBind();
            ddlBranchOne.SelectedValue = model.fk_id.ToString();
          
            BindShi(ddlBranchOne.SelectedValue);
        }
        private void BindShi(string fk_id)
        {
            Model.Shi model = new Model.Shi();
            model.sk_id = int.Parse(Request.QueryString["sk_id"]);
            ddlBranchTwo.DataSource = BLL.Shi.GetList("fk_id=" + fk_id);
            ddlBranchTwo.DataTextField = "second_kind_name";
            ddlBranchTwo.DataValueField = "sk_id";
            ddlBranchTwo.DataBind();
            ddlBranchTwo.SelectedValue = model.sk_id.ToString();
            BindXian(ddlBranchTwo.SelectedValue);
        }
        private void BindXian(string sk_id)
        {
            Model.Xian model = new Model.Xian();
            model.tk_id = int.Parse(Request.QueryString["tk_id"]);
            ddlBranchThird.DataSource = BLL.Xian.GetList("sk_id=" + sk_id);
            ddlBranchThird.DataTextField = "third_kind_name";
            ddlBranchThird.DataValueField = "tk_id";
            ddlBranchThird.DataBind();
            ddlBranchThird.SelectedValue = model.tk_id.ToString();
        }


        protected void ddlBranchOne_TextChanged(object sender, EventArgs e)
        {
            BindShen();
            BindShi(ddlBranchOne.SelectedValue);
        }

        protected void ddlBranchTwo_TextChanged(object sender, EventArgs e)
        {
            BindXian(ddlBranchTwo.SelectedValue);
        }

        protected void btnshen_Click(object sender, EventArgs e)
        {
            Model.Shen model = new Model.Shen();
            model.first_kind_name = txtshen.Text.Trim();
            model.fk_id = int.Parse(ddlBranchOne.SelectedValue);
            if (txtshen.Text.Trim() == "") { MessageBox.Show("请填写省名称！"); return; }
            if (BLL.Shen.Exists(model)) { MessageBox.Show("该省已存在！"); return; }
            if (BLL.Shen.Update(model))
            {
                MessageBox.Alert_HoldingPage("修改成功", Page);//刷新父页面
                //Response.Write("<script language='javascript'>alert('资料保存成功！');window.close();</script>");
                BindShen();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        protected void btnshi_Click(object sender, EventArgs e)
        {
            Model.Shi model = new Model.Shi();
            model.fk_id = int.Parse(ddlBranchOne.SelectedValue);
            model.sk_id = int.Parse(ddlBranchTwo.SelectedValue);
            model.second_kind_name = txtshi.Text.Trim();
            if (txtshi.Text.Trim() == "") { MessageBox.Show("请填写市名称！"); return; }
            if (BLL.Shi.Exists(model)) { MessageBox.Show("该市已存在！"); return; }
            if (BLL.Shi.Update(model))
            {

                MessageBox.Alert_HoldingPage("修改成功", Page);//刷新父页面
                BindShi(ddlBranchOne.SelectedValue);
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        protected void btnxian_Click(object sender, EventArgs e)
        {
            Model.Xian model = new Model.Xian();
            model.sk_id = int.Parse(ddlBranchTwo.SelectedValue);
            model.tk_id = int.Parse(ddlBranchThird.SelectedValue);
            model.third_kind_name = txtxian.Text.Trim();
            if (txtxian.Text.Trim() == "") { MessageBox.Show("请填写县或区名称！"); return; }
            if (BLL.Xian.Exists(model)) { MessageBox.Show("该县或区已存在！"); return; }
            if (BLL.Xian.Update(model))
            {

                MessageBox.Alert_HoldingPage("修改成功", Page);//刷新父页面
                BindXian(ddlBranchTwo.SelectedValue);
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

    }
}