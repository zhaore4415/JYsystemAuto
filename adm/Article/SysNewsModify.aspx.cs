using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Article
{
    public partial class SysNewsModify : WebBase.Free //AdminBase
    {
        //protected int _userType = 1;//1个人，2企业
        protected string _type = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("InfomationManage");
            switch (Request.QueryString["type"])
            {
                case "1":
                    //_userType = 1;
                    _type = "个人";
                    break;
                case "2":
                    //_userType = 2;
                    _type = "企业";
                    break;
            }
            if (!IsPostBack)
            {
                Show();
            }
        }
        private void Show()
        {
            Model.Article model = BLL.Article.GetModel(int.Parse(Request.QueryString["id"]));
            if (model == null)
            {
                Response.Redirect("SysNews.aspx?type=" + Request.QueryString["type"]);
            }
            txtTitle.Text = model.Title;
            txtUrl.Text = model.Url;
            ckContent.Text = model.Description;
            chkHilight.Checked = model.IsHilight.Value;
            try
            {
                rblStatus.SelectedValue = model.Status.ToString();
            }
            catch { }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.Article model = new Model.Article();
            model.Title = txtTitle.Text;
            model.Description = ckContent.Text;
            if (txtUrl.Text.Trim() != "")
            {
                model.Url = txtUrl.Text.Trim();
            }
            model.Status = int.Parse(rblStatus.SelectedValue);
            model.IsHilight = chkHilight.Checked;
            model.UpdateTime = DateTime.Now;

            model.Id = int.Parse(Request.QueryString["id"]);
            if (BLL.Article.Update(model))
            {
                MessageBox.ShowAndRedirect("保存成功", "SysNews.aspx?type=" + Request.QueryString["type"]);
                return;
            }
            else
            {
                MessageBox.Show("保存失败"); return;
            }
        }
    }
}