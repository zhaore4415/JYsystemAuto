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
    public partial class HrModify : WebBase.Edit //WebBase.Edit
    {
        protected string folder = "/Upload/HrTools/";
        
        protected void Page_Load(object sender, EventArgs e)
        {

            CheckPowerAndRedirect("InfomationManage");
            if (!IsPostBack)
            {
                BindCategory();
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    Show();
                }
            }
        }

        private void Show()
        {
            Model.Article model = BLL.Article.GetModel(int.Parse(Request.QueryString["id"]));
            if (model == null)
            {
                return;
            }
            txtTitle.Text = model.Title;
            ckContent.Text = model.Description;
            try
            {
                rblStatus.SelectedValue = model.Status.ToString();
            }
            catch { }
            try
            {
                ddlCategory.SelectedValue = model.CategoryID.ToString();
            }
            catch { }
            lbFilename.Text = "<a href=\"" + folder + model.Files + "\">" + model.Files + "</a>";
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
            
            Model.Article model = new Model.Article();
            model.Id = int.Parse(Request.QueryString["id"]);
            model.CategoryID = int.Parse(ddlCategory.SelectedValue);
            model.Title = txtTitle.Text;
            model.Description = ckContent.Text;
            model.Status = int.Parse(rblStatus.SelectedValue);
            model.IsHilight = false;
            model.AddUserId = UserBase.CurAdmin.Id;
            model.UpdateTime = DateTime.Now;

            string oldfile = null;
            string filename = null;
            if (file.HasFile)
            {
                filename = DateTime.Now.ToString("yyMMddhhmmssf") + Path.GetExtension(file.FileName);
                model.Files = filename;

                oldfile = BLL.Article.GetModel(model.Id).Files;
            }

            if (BLL.Article.Update(model))
            {
                if (file.HasFile)
                {
                    string path = Server.MapPath(folder);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(path + filename);
                    File.Delete(path + oldfile);
                }
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