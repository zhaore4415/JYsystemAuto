using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.IO;
using System.Data;

namespace NH.Web.adm.Company
{
    public partial class CompanyList : WebBase.List
    {
        protected string _levels = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["action"])
            {
                case "GetList":
                    GetList();
                    break;
                case "Delete":
                    Delete();
                    break;
                case "SetTop":
                    SetTop();
                    break;
                default:
                    Show();
                    break;
            }
        }

        private void Show()
        {
            _levels = BLL.CompanyLevel.BuildLevelOption();
            //地区 js
            //this.ltrAreaJsObject.Text = BLL.Area.BuildJsObject();
        }

        private void GetList()
        {
            #region
            int pagesize = EasyUI.GetPageSize();//每页显示数量
            int pageindex = EasyUI.GetPageIndex();//页码
            #endregion
            string strWhere = "and u.Status<>-1";
            string loginname = Request.Form["loginname"];
            string companyname = Request.Form["companyname"];
            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];
            string expiredate1 = Request.Form["expiredate1"];
            string expiredate2 = Request.Form["expiredate2"];
            string level = Request.Form["level"];
            string area = Request.Form["area"];

            #region
            if (!string.IsNullOrEmpty(loginname))
            {
                strWhere += " and u.LoginName like '%" + loginname.Trim().Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(companyname))
            {
                strWhere += " and c.CompanyName like '%" + companyname.Trim().Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(starttime))
            {
                try
                {
                    strWhere += " and u.AddTime >= '" + DateTime.Parse(starttime) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(endtime))
            {
                try
                {
                    strWhere += " and u.AddTime < '" + DateTime.Parse(endtime).AddDays(1) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(expiredate1))
            {
                try
                {
                    strWhere += " and c.ExpireDate >= '" + DateTime.Parse(expiredate1) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(expiredate2))
            {
                try
                {
                    strWhere += " and c.ExpireDate < '" + DateTime.Parse(expiredate2).AddDays(1) + "'";
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(level) && PageValidate.IsNumber(level) && level != "0")
            {
                if (level == "1")
                {
                    strWhere += " and (c.LevelID=" + level + " or datediff(day,getdate(),ExpireDate)< 0)";
                }
                else
                {
                    strWhere += " and c.LevelID=" + level + " and datediff(day,getdate(),ExpireDate)>=0";
                }

            }

            if (!string.IsNullOrEmpty(area) && area != "0")
            {
                strWhere += "and c.AreaID like '" + area.Replace("'","''") + "%'";
            }
            #endregion
            #region
            /*
            Response.Write(
                DataUtility.GetListToJson(
                "Company c(nolock) join [User] u(nolock) on c.Id=u.Id left join CompanyLevel cl(nolock) on c.LevelID=cl.Id left join CompanyTag ct1(nolock) on ct1.CompanyId=c.Id and ct1.TypeId=1 and ct1.Status=1 left join CompanyTag ct2(nolock) on ct2.CompanyId=c.Id and ct2.TypeId=2 and ct2.Status=1 left join CompanyTag ct3(nolock) on ct3.CompanyId=c.Id and ct3.TypeId=3 and ct3.Status=1 left join CompanyNewInfo n(nolock) on n.Id=c.Id and n.Status=0"
                , "u.Id,u.LoginName,u.AddTime,u.Status,c.CompanyName,c.Contact,c.Area,c.Phone,c.ExpireDate,cl.LevelName,c.VerifyStatus,ct1.Id JinJi,ct2.Id VIP,ct3.Id PinPai,n.Id as nid"
                , pagesize
                , pageindex
                , "u.Id"
                , strWhere
                , "order by u.Id desc"
                , true)
                );
            */
            #endregion
            Response.Write(
                DataUtility.GetListToJson(
                "Company c(nolock) join [User] u(nolock) on c.Id=u.Id left join CompanyLevel cl(nolock) on c.LevelID=cl.Id"
                , "u.Id,u.LoginName,u.AddTime,u.Status,c.CompanyName,c.Contact,c.Area,c.Phone,c.Email,c.ExpireDate,cl.LevelName,c.VerifyStatus,c.IsVerify"
                , pagesize
                , pageindex
                , "u.Id"
                , strWhere
                , "order by u.Id desc"
                , true)
                );
            Response.End();
        }

        private void Delete()
        {
            CheckDeletePower();
            //头像
            Model.User user = BLL.User.GetModel(Id);
            //相册图片
            List<Model.CompanyAlbum> albumList = BLL.CompanyAlbum.GetModelList("CompanyID=" + Id);
            //推荐LOGO
            List<Model.CompanyTag> tagList = BLL.CompanyTag.GetModelList("CompanyID=" + Id);
            //实名认证
            List<Model.CompanyVerify> verfiyList = BLL.CompanyVerify.GetModelList("CompanyID=" + Id);


            BLL.User.Delete(Id);
            BLL.Company.Delete(Id);

            //删除头像
            FileHelper.DeleteFile("/Upload/CompanyFace/Original/" + user.PhotoOriginal);
            FileHelper.DeleteFile("/Upload/CompanyFace/Small/" + user.Photo);
            FileHelper.DeleteFile("/Upload/CompanyFace/Small/" + user.PhotoNew);

            //删除相册
            foreach (Model.CompanyAlbum album in albumList)
            {
                FileHelper.DeleteFile("/Upload/CompanyAlbum/Original/" + album.ImgOriginal);
                FileHelper.DeleteFile("/Upload/CompanyAlbum/Small/" + album.ImgSmall);
                FileHelper.DeleteFile("/Upload/CompanyAlbum/Big/" + album.ImgBig);
            }

            //推荐LOGO
            foreach (Model.CompanyTag tag in tagList)
            {
                FileHelper.DeleteFile("/Upload/TagImg/" + tag.Logo);
            }

            //实名认证营业执照附件
            foreach (Model.CompanyVerify verify in verfiyList)
            {
                FileHelper.DeleteFile("/Upload/CompanyLicence/" + verify.LicenceImg);
            }

            Maticsoft.Common.Ajax.WriteOk("删除成功");
            //会级联删除的记录
            //CompanyAlbum
            //CompanyFavorite
            //CompanyNewInfo
            //CompanyTag
            //CompanyVerify
            //Interview
            //Job   --> JobApply、JobRefreshLog、MemberFavorite
            //ResumeViewLog
            //SysNewsRecord
        }

        private void SetTop()
        {
            CheckPowerAndRedirect("JobRefresh");

            DataTable dt = BLL.Job.GetList("CompanyID=" + Id).Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Model.Job model = new Model.Job();
                model.Id = (int)row["Id"];
                model.RefreshTime = DateTime.Now;

                BLL.Job.Update(model);


                //Model.JobRefreshLog refreshLog = new Model.JobRefreshLog();
                //refreshLog.CompanyID = UserBase.CurCompany.Id;
                //refreshLog.JobID = model.Id;
                //refreshLog.RefreshTime = DateTime.Now;
                //BLL.JobRefreshLog.Add(refreshLog);
            }
            Maticsoft.Common.Ajax.WriteOk("操作成功");
        }
    }
}