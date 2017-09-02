using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Maticsoft.Common;

namespace NH.Web.adm.Company
{
    public partial class CompanyLogo : WebBase.Edit
    {
        string folder = "/Upload/CompanyLogo/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show();
            }
        }
        private void Show()
        {
            Model.Company model = BLL.Company.GetModel(Id);
            if (File.Exists(Server.MapPath(folder) + model.Logo))
            {
                img.ImageUrl = folder + model.Logo;
            }
            else
            {
                phImg.Visible = false;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string filename = null;
            HttpPostedFile hpf = fileLogo.PostedFile;
            if (!fileLogo.HasFile)
            {
                Maticsoft.Common.Ajax.WriteError("请选择要上传的图片");
            }
            if (!ImageHelper.IsWebImage(hpf.ContentType))
            {
                Maticsoft.Common.Ajax.WriteError("请上传正确的图片格式");
            }
            else
            {
                filename = Id + "_" + DateTime.Now.ToString("yyMMddHHmmss") + Path.GetExtension(hpf.FileName);
            }
            Model.Company model = new Model.Company();
            model.Id = Id;
            model.Logo = filename;

            if (BLL.Company.Update(model))
            {
                if (!Directory.Exists(Server.MapPath(folder)))
                {
                    Directory.CreateDirectory(Server.MapPath(folder));
                }
                fileLogo.SaveAs(Server.MapPath(folder) + filename);
            }

            Maticsoft.Common.Ajax.WriteOk("上传成功");
        }
    }
}