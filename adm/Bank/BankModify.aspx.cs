using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Maticsoft.Common;

namespace NH.Web.adm.Bank
{
    public partial class BankModify : WebBase.Edit
    {
        string folder = "/Upload/Bank/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show();
            }
        }

        private void Show()
        {
            Model.Bank model = BLL.Bank.GetModel(Id);
            if (model == null) Response.Redirect(ListUrl);
            txtName.Text = model.BankName;
            txtAccount.Text = model.Account;
            txtBranchName.Text = model.BranchName;
            txtSort.Text = model.Sort.ToString();
            img.ImageUrl = folder + model.Logo;
            rblStatus.SelectedValue = model.Status.ToString();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string bankname = txtName.Text.Trim();
            string account = txtAccount.Text.Trim();
            string branchname = txtBranchName.Text.Trim();
            string filename = null;
            int sort = 0;
            HttpPostedFile hpf = file.PostedFile;

            if (bankname == "")
            {
                MessageBox.Show("请填写银行名称"); return;
            }
            if (account == "")
            {
                MessageBox.Show("请填写账号"); return;
            }
            if (branchname == "")
            {
                MessageBox.Show("请填写支行名称"); return;
            }
            try
            {
                sort = int.Parse(txtSort.Text.Trim());
            }
            catch
            {
                MessageBox.Show("排序值不正确"); return;
            }
            if (file.HasFile)
            {
                if (!ImageHelper.IsWebImage(hpf.ContentType))
                {
                    MessageBox.Show("银行图标格式不正确"); return;
                }
                else
                {
                    filename = DateTime.Now.ToString("yyMMddhhmmss") + Path.GetExtension(hpf.FileName);
                }
            }

            Model.Bank model = new Model.Bank();
            model.BankName = bankname;
            model.Account = account;
            model.BranchName = branchname;
            model.Logo = filename;
            model.Sort = sort;
            model.AddTime = DateTime.Now;
            model.Status = int.Parse(rblStatus.SelectedValue);

            model.Id = Id;
            if (BLL.Bank.Update(model))
            {
                if (file.HasFile)
                {
                    if (!Directory.Exists(Server.MapPath(folder)))
                    {
                        Directory.CreateDirectory(Server.MapPath(folder));
                    }
                    file.SaveAs(Server.MapPath(folder) + filename);

                    FileHelper.DeleteFile(img.ImageUrl);
                }
                DataCache.RemoveDependencyFile("Bank");
                MessageBox.ShowAndRedirect("修改成功", ListUrl);
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }
    }
}