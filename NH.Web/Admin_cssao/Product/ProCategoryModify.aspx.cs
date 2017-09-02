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
    public partial class ProCategoryModify : WebBase.Edit
    {
        //private int Pid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategory(null, "0");
                Show();
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

        private void Show()
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]) && string.IsNullOrEmpty(Request.QueryString["Depth"])) return;
  
            Model.ProCategory model = BLL.ProCategory.GetModel(int.Parse(Request.QueryString["id"]));
            if (model == null) Response.Redirect("ProCategory.aspx");
            try
            {
                //ddlCategory.SelectedValue = model.ParentID.Value.ToString();
            }
            catch { }
            txtName.Text = model.Name;
            txtRemark.Text = model.Remark;
            img.ImageUrl = "/Upload/CategoryIcon/" + model.Pic;
            if (File.Exists(Server.MapPath(img.ImageUrl)))
            {
                phImg.Visible = true;
            }
            else
            {
                phImg.Visible = false;
            }
            txtSort.Text = model.Sort.ToString();
            rblStatus.SelectedValue = model.IsShow.Value ? "1" : "0";
            
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
            string pic = null;
            if (file.HasFile)
            {
                if (!ImageHelper.IsWebImage(file.PostedFile.ContentType))
                {
                    MessageBox.Show("类别图标只能图片格式的文件"); return;
                }
                pic = DateTime.Now.ToString("yyyyMMddHHhmmssf") + Path.GetExtension(file.PostedFile.FileName);
            }

            int id = int.Parse(Request.QueryString["id"]);
            Model.ProCategory model = new Model.ProCategory();
            model.Name = txtName.Text.Trim();
            //model.ParentID = int.Parse(ddlCategory.SelectedValue);
            model.Remark = txtRemark.Text;
            //model.Pic = pic;
            model.Sort = int.Parse(txtSort.Text.Trim());
            //model.IsShow = rblStatus.SelectedValue == "1";
            //model.InHome = rblIsHome.SelectedValue == "1";

            Model.ProCategory oldModel = BLL.ProCategory.GetModel(id);
            if (model.ParentID != oldModel.ParentID)
            {
                //修改了上级类别
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
            }

            model.ID = id;
            if (BLL.ProCategory.Update(model))
            { //写系统日志
                Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
                MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
                MyRiZhi.DoSomething = "修改商品类别(" + txtName.Text.Trim() + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                BLL.ERPRiZhi.Add(MyRiZhi);
                if (file.HasFile)
                {
                    string folder = Server.MapPath("/Upload/CategoryIcon/");
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    file.SaveAs(folder + pic);
                    //File.Delete(Server.MapPath(img.ImageUrl));
                }
                //如果修改了上级，所有下级的Path都需要修改,商品表对应的分类路径也要修改

                MessageBox.ShowAndRedirect("修改成功", "ProCategory.aspx");
            }
            else
            {
                MessageBox.Show("修改失败"); return;
            }
        }
    }
}