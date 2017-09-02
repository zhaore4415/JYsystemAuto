using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Maticsoft.Common;

namespace NH.Web.adm.Article
{
    public partial class HrAdd : WebBase.Edit //WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("InfomationManage");

            if (!IsPostBack)
            {
                BindCategory();
            }
        }


        private void BindCategory()
        {
            DataTable dt = BLL.ArticleCategory.GetList(0, "Type=5", "Sort asc").Tables[0];
            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("请选择分类", "0"));
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "0")
            {
                MessageBox.Show("请选择分类"); return;
            }
            if (!file.HasFile)
            {
                MessageBox.Show("请选择要上传的文件"); return;
            }
            string filename = DateTime.Now.ToString("yyMMddhhmmssf") + Path.GetExtension(file.FileName);
            Model.Article model = new Model.Article();
            model.CategoryID = int.Parse(ddlCategory.SelectedValue);
            model.Title = txtTitle.Text;
            model.Description = ckContent.Text;
            model.Status = int.Parse(rblStatus.SelectedValue);
            model.IsHilight = false;
            model.AddUserId = UserBase.CurAdmin.Id;
            model.UpdateTime = DateTime.Now;
            model.Files = filename;

            if (BLL.Article.Add(model) > 0)
            {
                string folder = Server.MapPath("/Upload/HrTools/");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                file.SaveAs(folder + filename);
                MessageBox.ShowAndRedirect("保存成功", "HrList.aspx");
                return;
            }
            else
            {
                MessageBox.Show("保存失败"); return;
            }
        }
    }
}