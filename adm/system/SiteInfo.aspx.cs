using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Maticsoft.Common;

namespace NH.Web.adm
{
    public partial class SiteInfo : WebBase.Edit
    {
        string watermarkfolder = "/Upload/WaterMark/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show();
            }
        }

        private void Show()
        {
            Model.Config model = BLL.Config.GetModel(1);
            txtSiteName.Text = model.SiteName;
            txtSiteTitle.Text = model.SiteTitle;
            txtSiteKeyword.Text = model.SiteKeyword;
            txtSiteDescription.Text = model.SiteDescription;
            txtServiceTel1.Text = model.ServiceTel1;
            txtServiceTel2.Text = model.ServiceTel2;
            txtFriendLinkContact.Text = model.FriendLinkContact;
            ckFoot.Text = model.Foot;
            rblIsMobileValidate.SelectedValue = model.IsMobileValidate.Value ? "1" : "0";

            if (File.Exists(Server.MapPath(watermarkfolder + model.WaterMarkPic)))
            {
                imgWaterMarkPic.Visible = true;
                imgWaterMarkPic.ImageUrl = watermarkfolder + model.WaterMarkPic;
            }
            else
            {
                imgWaterMarkPic.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.Config model = new Model.Config();
            model.Id = 1;

            model.SiteName = txtSiteName.Text.Trim();
            model.SiteTitle = txtSiteTitle.Text;
            model.SiteKeyword = txtSiteKeyword.Text;
            model.SiteDescription = txtSiteDescription.Text;
            model.ServiceTel1 = txtServiceTel1.Text;
            model.ServiceTel2 = txtServiceTel2.Text;
            model.FriendLinkContact = txtFriendLinkContact.Text;
            model.Foot = ckFoot.Text;
            model.IsMobileValidate = rblIsMobileValidate.SelectedValue == "1";

            HttpPostedFile hpfWM = fileWaterMarkPic.PostedFile;
            string watermark = null;
            if (fileWaterMarkPic.HasFile)
            {
                if (!ImageHelper.IsWebImage(hpfWM.ContentType))
                {
                    MessageBox.Show("请上传正确的图片格式"); return;
                }
                else
                {
                    watermark = DateTime.Now.ToString("yyMMddhhmmss") + Path.GetExtension(hpfWM.FileName);
                } 
            }
            model.WaterMarkPic = watermark;

            if (BLL.Config.Update(model))
            {
                if (fileWaterMarkPic.HasFile)
                {
                    if (!Directory.Exists(Server.MapPath(watermarkfolder)))
                    {
                        Directory.CreateDirectory(Server.MapPath(watermarkfolder));
                    }
                    fileWaterMarkPic.SaveAs(Server.MapPath(watermarkfolder) + watermark);

                    FileHelper.DeleteFile(imgWaterMarkPic.ImageUrl);
                }

                DataCache.RemoveDependencyFile("Config");
                Maticsoft.Common.MessageBox.ShowAndRedirect("保存成功",Request.RawUrl);
            }
            else
            {
                Maticsoft.Common.MessageBox.Show("保存失败"); 
            }
        }
    }
}