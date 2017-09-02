using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NH.Web.adm.Person
{
    public partial class PersonRefresh : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.Form["action"])
            {
                case "refresh":
                    Refresh();
                    break;
                default:
                    Show();
                    break;
            }

        }

        private void Show()
        {
            Model.User model = BLL.User.GetModel(Id);
            lbLastRefreshTime.Text = model.RefreshTime.ToString();
        }

        private void Refresh()
        {
            Model.User model = new Model.User();
            model.Id = Id;
            model.RefreshTime = DateTime.Now;

            if (BLL.User.Update(model))
            {
                Maticsoft.Common.Ajax.WriteOkAndJsonData("操作成功", "\"" + DateTime.Now.ToString() + "\"");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
        }

    }
}