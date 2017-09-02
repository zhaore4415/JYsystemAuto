using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.SearchKey
{
    public partial class SearchKeyAdd : WebBase.Free
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CheckPowerAndRedirect("InfomationManage");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string keyname = txtKeyName.Text.Trim();
            string url = txtUrl.Text.Trim();
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
            Model.SearchKey model = new Model.SearchKey();
            model.KeyName = keyname;
            model.Url = url;
            model.Sort = BLL.SearchKey.GetMaxSort(type);
            model.Type = type;
            model.IsShow = isShow;

            if (BLL.SearchKey.Add(model) > 0)
            {
                MessageBox.ShowAndRedirect("添加成功", ListUrl);

                DataCache.RemoveDependencyFile("TopSearchKey");
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }
    }
}