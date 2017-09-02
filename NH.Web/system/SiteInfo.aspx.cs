using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Maticsoft.Common;

namespace NH.Web.adm.system
{
    public partial class SiteInfo : WebBase.Edit
    {
        //string watermarkfolder = "/Upload/WaterMark/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Show();
                Label1.Text = "服务器名称：" + Server.MachineName;//服务器名称  
                Label2.Text = "服务器IP地址：" + Request.ServerVariables["LOCAL_ADDR"];//服务器IP地址  
                Label3.Text = "服务器域名：" + Request.ServerVariables["SERVER_NAME"];//服务器域名  
                Label4.Text = ".NET解释引擎版本：" + ".NET CLR" + Environment.Version.Major + "." + Environment.Version.Minor + "." + Environment.Version.Build + "." + Environment.Version.Revision;//.NET解释引擎版本  
                Label5.Text = "服务器操作系统版本：" + Environment.OSVersion.ToString();//服务器操作系统版本  
                Label6.Text = "服务器IIS版本：" + Request.ServerVariables["SERVER_SOFTWARE"];//服务器IIS版本  
                Label7.Text = "HTTP访问端口：" + Request.ServerVariables["SERVER_PORT"];//HTTP访问端口  
                Label8.Text = "虚拟目录的绝对路径：" + Request.ServerVariables["APPL_RHYSICAL_PATH"];//虚拟目录的绝对路径  
                Label9.Text = "执行文件的绝对路径：" + Request.ServerVariables["PATH_TRANSLATED"];//执行文件的绝对路径  
                Label10.Text = "虚拟目录Session总数：" + Session.Contents.Count.ToString();//虚拟目录Session总数  
                Label11.Text = "虚拟目录Application总数：" + Application.Contents.Count.ToString();//虚拟目录Application总数  
                Label12.Text = "域名主机：" + Request.ServerVariables["HTTP_HOST"];//域名主机  
                Label13.Text = "服务器区域语言：" + Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];//服务器区域语言  
                Label14.Text = "用户信息：" + Request.ServerVariables["HTTP_USER_AGENT"];
                Label14.Text = "CPU个数：" + Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");//CPU个数  
                Label15.Text = "CPU类型：" + Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");//CPU类型  
                //Label16.Text = "进程开始时间：" + GetPrStart();//进程开始时间  
                //Label17.Text = "AspNet 内存占用：" + GetAspNetN();//AspNet 内存占用  
                //Label18.Text = "AspNet CPU时间：" + GetAspNetCpu();//AspNet CPU时间  
                //Label19.Text = "FSO 文本文件读写：" + Check("Scripting.FileSystemObject");//FSO 文本文件读写  
                //Label20.Text = "应用程序占用内存" + GetServerAppN();//应用程序占用内存 
            }
        }

        private void Show()
        {
            //Model.Config model = BLL.Config.GetModel(1);
            //txtSiteName.Text = model.SiteName;
            //txtSiteTitle.Text = model.SiteTitle;
            //txtSiteKeyword.Text = model.SiteKeyword;
            //txtSiteDescription.Text = model.SiteDescription;
            //txtServiceTel1.Text = model.ServiceTel1;
            //txtServiceTel2.Text = model.ServiceTel2;
            //txtFriendLinkContact.Text = model.FriendLinkContact;
            //ckFoot.Text = model.Foot;
            //rblIsMobileValidate.SelectedValue = model.IsMobileValidate.Value ? "1" : "0";

            //if (File.Exists(Server.MapPath(watermarkfolder + model.WaterMarkPic)))
            //{
            //    imgWaterMarkPic.Visible = true;
            //    imgWaterMarkPic.ImageUrl = watermarkfolder + model.WaterMarkPic;
            //}
            //else
            //{
            //    imgWaterMarkPic.Visible = false;
            //}
        }
    }
}