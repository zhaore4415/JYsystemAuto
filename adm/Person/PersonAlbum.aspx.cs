using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Person
{
    public partial class PersonAlbum : WebBase.Edit
    {
        protected string originalfolder = "/Upload/PersonAlbum/Original/";
        protected string smallfolder = "/Upload/PersonAlbum/Small/";
        protected string bigfolder = "/Upload/PersonAlbum/Big/";

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
            Model.MemberAlbum model = BLL.MemberAlbum.GetModel(Id);
            if (model == null) Maticsoft.Common.Ajax.WriteError("此记录不存在");

            model.Status = int.Parse(Request.Form["status"]);

            if (BLL.MemberAlbum.Update(model))
            {
                BLL.Member.UpdateComplete(model.MemberID);
                Maticsoft.Common.Ajax.WriteOk("操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败"); 
            }
        }

        private void Delete()
        {
            Model.MemberAlbum model = BLL.MemberAlbum.GetModel(int.Parse(Request.Form["id"]));
            if (model == null)
            {
                Maticsoft.Common.Ajax.WriteOk("已删除");
            }
            else
            {
                FileHelper.DeleteFile(originalfolder + model.ImgOriginal);
                FileHelper.DeleteFile(smallfolder + model.ImgSmall);
                FileHelper.DeleteFile(bigfolder + model.ImgBig);
                BLL.MemberAlbum.Delete(model.Id);

                BLL.Member.UpdateComplete(model.MemberID);

                Maticsoft.Common.Ajax.WriteOk("删除成功");
            }
        }

        private void BindList()
        {
            rptList.DataSource = BLL.MemberAlbum.GetList(0, "MemberID=" + Id, "Sort asc").Tables[0];
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
    }
}