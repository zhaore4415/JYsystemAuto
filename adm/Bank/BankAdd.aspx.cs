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
    public partial class BankAdd : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string bankname = txtName.Text.Trim();
            string account = txtAccount.Text.Trim();
            string branchname = txtBranchName.Text.Trim();
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
            if (!file.HasFile)
            {
                MessageBox.Show("请选择银行图标"); return;
            }
            if (!ImageHelper.IsWebImage(hpf.ContentType))
            {
                MessageBox.Show("银行图标格式不正确"); return;
            }
            string filename = DateTime.Now.ToString("yyMMddhhmmss") + Path.GetExtension(hpf.FileName);

            Model.Bank model = new Model.Bank();
            model.BankName = bankname;
            model.Account = account;
            model.BranchName = branchname;
            model.Logo = filename;
            model.Sort = BLL.Bank.GetMaxSort();
            model.AddTime = DateTime.Now;
            model.Status = int.Parse(rblStatus.SelectedValue);

            if (BLL.Bank.Add(model) > 0)
            {
                string folder = Server.MapPath("/Upload/Bank/");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                file.SaveAs(folder + filename);
                DataCache.RemoveDependencyFile("Bank");
                MessageBox.ShowAndRedirect("添加成功", ListUrl);
            }
            else
            {
                MessageBox.Show("添加失败"); 
            }
        }
    }
}