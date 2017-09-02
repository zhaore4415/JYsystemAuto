using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NH.Web.adm.Company
{
    public partial class CompanyHelpmate : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show();
            }
        }

        private void Show()
        {
            Model.CompanyHelpmate model = BLL.CompanyHelpmate.GetModel(Id);
            if (model == null)
            {
                phContent.Visible = false;
                phEmpty.Visible = true;
            }
            else
            {
                phContent.Visible = true;
                phEmpty.Visible = false;

                Model.JobCategory category = BLL.JobCategory.GetModel(new Model.JobCategory() { CategoryNo=model.CategoryID.ToString()});
                if (category != null)
                {
                    lbJobCategory.Text = category.Name;
                }

                Model.Area area = BLL.Area.GetModel(new Model.Area() { AreaNo=model.AreaID});
                if (area != null)
                {
                    lbArea.Text = area.FullName;
                }

                lbEmail.Text = model.Email;
            }
        }

    }
}