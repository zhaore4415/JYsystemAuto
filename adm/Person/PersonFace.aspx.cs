using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace NH.Web.adm.Person
{
    public partial class PersonFace : WebBase.Edit
    {
        protected string originalfolder = "/Upload/PersonFace/Original/";
        protected string smallfolder = "/Upload/PersonFace/Small/";
        protected int _verifyStatus = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.Form["action"])
            {
                case "verify":
                    Verify();
                    break;
                default:
                    Show();
                    break;
            }
        }

        private void Verify()
        {
            Model.User user = BLL.User.GetModel(Id);
            int status = int.Parse(Request.Form["status"]);
            user.PhotoVerifyStatus = status;
            if (status == 1)
            {
                //当前头像
                string currentFacePath = smallfolder + user.Photo;
                if (File.Exists(Server.MapPath(currentFacePath)) && user.Photo != user.PhotoNew)
                {
                    File.Delete(Server.MapPath(currentFacePath));
                }
                user.Photo = user.PhotoNew;
                user.PhotoVerifyStatus = 1;
                user.PhotoNew = "";
            }
            if (BLL.User.Update(user))
            {
                BLL.Member.UpdateComplete(Id);
                Maticsoft.Common.Ajax.WriteOk("审核成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("审核失败"); 
            }
        }

        private void Show()
        {
            Model.User user = BLL.User.GetModel(Id);
            _verifyStatus = user.PhotoVerifyStatus;
            //当前头像
            string currentFacePath = smallfolder + user.Photo;
            if (File.Exists(Server.MapPath(currentFacePath)))
            {
                imgCurrentFace.ImageUrl = currentFacePath;
                imgCurrentFace.Visible = true;
            }
            else
            {
                imgCurrentFace.Visible = false;
            }

            //新上传的头像
            //原图
            string originalFacePath = originalfolder + user.PhotoOriginal;
            if (File.Exists(Server.MapPath(originalFacePath)))
            {
                imgOriginalFace.ImageUrl = originalFacePath;
                imgOriginalFace.Visible = true;
            }
            else
            {
                imgOriginalFace.Visible = false;
            }

            //新图裁剪后的图片
            string newSmallPath = smallfolder + user.PhotoNew;
            if (File.Exists(Server.MapPath(newSmallPath)))
            {
                imgNewSmallFace.ImageUrl = newSmallPath;
                imgNewSmallFace.Visible = true;
            }
            else
            {
                imgNewSmallFace.Visible = false;
            }

            if (_verifyStatus == 0 || _verifyStatus == -1)
            {
                phNewFace.Visible = true;
            }
            else
            {
                phNewFace.Visible = false;
            }
        }
    }
}