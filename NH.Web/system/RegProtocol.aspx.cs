using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NH.Web.adm.system
{
    public partial class RegProtocol : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ckContent.Text = BLL.Config.GetModel(1).RegProtocol;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.Config model = new Model.Config();
            model.Id = 1;
            model.RegProtocol = ckContent.Text;

            if (BLL.Config.Update(model))
            {
                Maticsoft.Common.MessageBox.Show("保存成功");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show("保存失败");
            }
        }


    }
}