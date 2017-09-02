using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.Data;

namespace NH.Web.adm.Company
{
    public partial class CompanyReg : WebBase.Edit
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ImageButton1.Attributes.Add("onclick", "return confirm('确定要删除选择的项吗，其子项也会一起删除，谨慎操作?');");
                ImageButton2.Attributes.Add("onclick", "return confirm('确定要删除选择的项吗，其子项也会一起删除，谨慎操作?');");
                ImageButton3.Attributes.Add("onclick", "return confirm('确定要删除选择的项吗?');");
                BindShen(); 

            }
        }
        private void BindShen() {

            ddlBranchOne.DataSource = BLL.Shen.GetList("");
            ddlBranchOne.DataTextField = "first_kind_name";
            ddlBranchOne.DataValueField = "fk_id";
            ddlBranchOne.DataBind();
            //ddlBranchOne.SelectedValue = "-1";
            //string aaa = ddlBranchOne.DataValueField.ToString(); Response.Write(aaa);
            BindShi(ddlBranchOne.SelectedValue);
        }
        private void BindShi(string fk_id)
        {
            ddlBranchTwo.DataSource = BLL.Shi.GetList("fk_id=" + fk_id);
            ddlBranchTwo.DataTextField = "second_kind_name";
            ddlBranchTwo.DataValueField = "sk_id";
            ddlBranchTwo.DataBind();
            //ddlBranchTwo.SelectedValue = "-1";
            if (ddlBranchTwo.SelectedValue == "") { ddlBranchTwo.Items.Insert(0, new ListItem("请选择", "0")); ; return; }
            BindXian(ddlBranchTwo.SelectedValue);
        }
        private void BindXian(string sk_id)
        {
            ddlBranchThird.DataSource = BLL.Xian.GetList("sk_id=" + sk_id);
            ddlBranchThird.DataTextField = "third_kind_name";
            ddlBranchThird.DataValueField = "tk_id";
            ddlBranchThird.DataBind();
            if (ddlBranchThird.SelectedValue == "") { ddlBranchThird.Items.Insert(0, new ListItem("请选择", "0")); ; return; }
        }
       

        protected void ddlBranchOne_TextChanged(object sender, EventArgs e)
        {
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
            if (txtshen.Text.Trim() == "") { MessageBox.Show("请填写省名称！"); return; }
            if (BLL.Shen.Exists(model)) { MessageBox.Show("该省已存在！"); return; }
            if (BLL.Shen.Add(model) > 0)
            {

                MessageBox.Alert_HoldingPage("添加成功", Page);//刷新父页面
                //Response.Write("<script language='javascript'>alert('资料保存成功！');window.close();</script>");
                BindShen();
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        protected void btnshi_Click(object sender, EventArgs e)
        {
            Model.Shi model = new Model.Shi();
            model.fk_id = int.Parse(ddlBranchOne.SelectedValue);
            model.second_kind_name = txtshi.Text.Trim();
            if (txtshi.Text.Trim() == "") { MessageBox.Show("请填写市名称！"); return; }
            if (BLL.Shi.Exists(model)) { MessageBox.Show("该市已存在！"); return; }
            if (BLL.Shi.Add(model) > 0)
            {

                MessageBox.Alert_HoldingPage("添加成功", Page);//刷新父页面
                BindShi(ddlBranchOne.SelectedValue);
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        protected void btnxian_Click(object sender, EventArgs e)
        {
            Model.Xian model = new Model.Xian();
            model.sk_id = int.Parse(ddlBranchTwo.SelectedValue);
            model.third_kind_name = txtxian.Text.Trim();
            if (txtxian.Text.Trim() == "") { MessageBox.Show("请填写县或区名称！"); return; }
            if (BLL.Xian.Exists(model)) { MessageBox.Show("该县或区已存在！"); return; }
            if (BLL.Xian.Add(model) > 0)
            {

                MessageBox.Alert_HoldingPage("添加成功", Page);//刷新父页面
                BindXian(ddlBranchTwo.SelectedValue);
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            CheckDeletePower();
            string strids = ddlBranchOne.SelectedValue;
            if (!string.IsNullOrEmpty(strids))
            {

                Model.Shen model = BLL.Shen.GetModel(int.Parse(strids));
                if (model != null)
                {
                    //先删除县，再市，再省
                  
                    DataSet ds = BLL.Shi.GetList("fk_id=" + strids);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string a = ds.Tables[0].Rows[i]["sk_id"].ToString();
                        BLL.Xian.DeleteList(ds.Tables[0].Rows[i]["sk_id"].ToString());//删除县
                    }
                    BLL.Shi.DeleteList(strids);//删除市
                    BLL.Shen.Delete(int.Parse(strids));//删除省
                
                }

            }
            BindShen();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            CheckDeletePower();
            string strids = ddlBranchTwo.SelectedValue;
            if (!string.IsNullOrEmpty(strids))
            {

                Model.Shi model = BLL.Shi.GetModel(int.Parse(strids));
                if (model != null)
                {
                    //FileHelper.DeleteFile(folder + model.Logo);
                    BLL.Shi.Delete(int.Parse(strids));
                    BLL.Xian.DeleteList(strids);
                }

            }
            BindShi(ddlBranchOne.SelectedValue);
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            CheckDeletePower();
          
            string strids = ddlBranchThird.SelectedValue;
            if (!string.IsNullOrEmpty(strids))
            {

                Model.Xian model = BLL.Xian.GetModel(int.Parse(strids));
                    if (model != null)
                    {
                        //FileHelper.DeleteFile(folder + model.Logo);
                        BLL.Xian.Delete(int.Parse(strids));
                    }
               
            }
            BindXian(ddlBranchTwo.SelectedValue);
        }

    }
}