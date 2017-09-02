using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.SearchKey
{
    public partial class SearchKeyModify : WebBase.Free
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("InfomationManage");
            if (!IsPostBack)
            {
                Show();
            }
        }

        private void Show()
        {
            Model.SearchKey model = BLL.SearchKey.GetModel(Id);
            if (model == null) Response.Redirect(ListUrl);

            txtKeyName.Text = model.KeyName;
            txtUrl.Text = model.Url;
            txtSort.Text = model.Sort.ToString();
            rblStatus.SelectedValue = model.IsShow.Value ? "1" : "0";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string keyname = txtKeyName.Text.Trim();
            string url = txtUrl.Text.Trim();
            int sort = 0;
            bool isShow = rblStatus.SelectedValue == "1";
            int type = 1;

            if (keyname == "")
            {
                MessageBox.Show("请填写关键字"); return;
            }
            if (url == "")
            {
                MessageBox.Show("请填写搜索地址"); return;
            }
            try
            {
                sort = int.Parse(txtSort.Text.Trim());
            }
            catch
            {
                MessageBox.Show("排序值不正确"); return;
            }
            Model.SearchKey model = new Model.SearchKey();
            model.KeyName = keyname;
            model.Url = url;
            model.Sort = sort;
            model.Type = type;
            model.IsShow = isShow;

            model.Id = Id;
            if (BLL.SearchKey.Update(model))
            {
                MessageBox.ShowAndRedirect("修改成功", ListUrl);
                DataCache.RemoveDependencyFile("TopSearchKey");
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }
    }
}