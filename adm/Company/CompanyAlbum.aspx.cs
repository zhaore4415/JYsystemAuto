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
    public partial class CompanyAlbum : WebBase.Edit
    {
        protected string originalfolder = "/Upload/CompanyAlbum/Original/";
        protected string smallfolder = "/Upload/CompanyAlbum/Small/";
        protected string bigfolder = "/Upload/CompanyAlbum/Big/";
        protected int maxCount = 0;
        protected int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.Form["action"])
            {
                case "verify":
                    Verify();
                    break;
                case "delete":
                    Delete();
                    break;
                default:
                    BindList();
                    break;
            }
        }

        private void Verify()
        {
            Model.CompanyAlbum model = BLL.CompanyAlbum.GetModel(Id);
            if (model == null) Maticsoft.Common.Ajax.WriteError("此记录已删除");

            model.Status = int.Parse(Request.Form["status"]);

            if (BLL.CompanyAlbum.Update(model))
            {
                BLL.Company.UpdateComplete(model.CompanyID);
                Maticsoft.Common.Ajax.WriteOk("操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
        }

        private void BindList()
        {
            rptList.DataSource = BLL.CompanyAlbum.GetList(0, "CompanyID=" + Id.ToString(), "Sort asc");
            rptList.DataBind();
        }
        protected string GetStatus(int status)
        {
            string result = null;
            switch (status)
            {
                case 0:
                    result = "未审核";
                    break;
                case 1:
                    result = "<font color='blue'>已通过</font>";
                    break;
                case -1:
                    result = "<font color='red'>不通过</font>";
                    break;
            }
            return result;
        }

        private void Delete()
        {
            Model.CompanyAlbum model = BLL.CompanyAlbum.GetModel(int.Parse(Request.Form["id"]));
            if (model == null)
            {
                Maticsoft.Common.Ajax.WriteOk("已删除");
            }
            else
            {
                FileHelper.DeleteFile(originalfolder + model.ImgOriginal);
                FileHelper.DeleteFile(smallfolder + model.ImgSmall);
                FileHelper.DeleteFile(bigfolder + model.ImgBig);
                BLL.CompanyAlbum.Delete(model.Id);

                BLL.Company.UpdateComplete(model.CompanyID);

                Maticsoft.Common.Ajax.WriteOk("删除成功");
            }
        }
    }
}