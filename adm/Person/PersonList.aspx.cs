using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm
{
    public partial class PersonList : WebBase.List
    {
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
                case "refresh":
                    Refresh();
                    break;
                case "Refresh2":
                    Refresh2();
                    break;
                default:
                    break;
            }
        }

        private void GetList()
        {
            #region
            int pagesize = EasyUI.GetPageSize();//每页显示数量
            int pageindex = EasyUI.GetPageIndex();//页码
            #endregion
            string strWhere = "and u.Status<>-1 and VerifyStatus=1 and IsVerify=0";
            string loginname = Request.Form["loginname"];
            string realname = Request.Form["realname"];
            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];

            if (!string.IsNullOrEmpty(loginname))
            {
                strWhere += " and u.LoginName like '%" + loginname.Trim().Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(realname))
            {
                strWhere += " and m.Realname like '%" + realname.Trim().Replace("'", "''") + "%'";
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


            Response.Write(DataUtility.GetListToJson(
                //"Member m(nolock) left join [User] u(nolock) on m.Id=u.Id left join Experience ex on m.ExperienceID=ex.Id left join MemberNewInfo n(nolock) on n.Id=m.Id and n.Status=0"
                "Member m(nolock) left join [User] u(nolock) on m.Id=u.Id left join Experience ex on m.ExperienceID=ex.Id"
                , "u.Id,u.LoginName,u.AddTime,u.RefreshTime,u.Status,m.Realname,m.Mobile,m.Phone,m.Email,m.JobCategoryName,m.JobAddr,ex.Name as Experience"
                , pagesize
                , pageindex
                , "u.Id"
                , strWhere
                , "order by u.Id desc"
                , true)
                );
            Response.End();
        }

        private void Refresh()
        {
            CheckPowerAndRedirect("PersonRefresh");
            Model.User model = new Model.User();
            model.Id = Id;
            model.RefreshTime = DateTime.Now;

            if (BLL.User.Update(model))
            {
                //Maticsoft.Common.Ajax.WriteOkAndJsonData("操作成功", "\"" + DateTime.Now.ToString() + "\"");
                Maticsoft.Common.Ajax.WriteOk("操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
        }

        private void Refresh2()
        {
            CheckPowerAndRedirect("PersonRefresh");
            string strWhere = "and u.Status<>-1 and VerifyStatus=1 and IsVerify=0";
            string loginname = Request.Form["loginname"];
            string realname = Request.Form["realname"];
            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];

            if (!string.IsNullOrEmpty(loginname))
            {
                strWhere += " and u.LoginName like '%" + loginname.Trim().Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(realname))
            {
                strWhere += " and m.Realname like '%" + realname.Trim().Replace("'", "''") + "%'";
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

            BLL.User.Refresh(strWhere);
            Maticsoft.Common.Ajax.WriteOk("操作成功");
        }

        private void Delete()
        {
            CheckDeletePower();
            //头像
            Model.User user = BLL.User.GetModel(Id);
            //相册图片
            List<Model.MemberAlbum> albumList = BLL.MemberAlbum.GetModelList("MemberID=" + Id);
            //作品图片
            List<Model.MemberWorks> workList = BLL.MemberWorks.GetModelList("MemberID=" + Id);
            //实名认证
            List<Model.IdentityVerify> verfiyList = BLL.IdentityVerify.GetModelList("MemberID=" + Id);

            BLL.User.Delete(Id);
            BLL.Member.Delete(Id);

            //删除头像
            FileHelper.DeleteFile("/Upload/PersonFace/Original/" + user.PhotoOriginal);
            FileHelper.DeleteFile("/Upload/PersonFace/Small/" + user.Photo);
            FileHelper.DeleteFile("/Upload/PersonFace/Small/" + user.PhotoNew);

            //删除相册
            foreach (Model.MemberAlbum album in albumList)
            {
                FileHelper.DeleteFile("/Upload/PersonAlbum/Original/" + album.ImgOriginal);
                FileHelper.DeleteFile("/Upload/PersonAlbum/Small/" + album.ImgSmall);
                FileHelper.DeleteFile("/Upload/PersonAlbum/Big/" + album.ImgBig);
            }

            //删除作品
            foreach (Model.MemberWorks work in workList)
            {
                FileHelper.DeleteFile("/Upload/PersonWorks/Original/" + work.ImgOriginal);
                FileHelper.DeleteFile("/Upload/PersonWorks/Small/" + work.ImgSmall);
                FileHelper.DeleteFile("/Upload/PersonWorks/Big/" + work.ImgBig);
            }

            //实名认证营业执照附件
            foreach (Model.IdentityVerify verify in verfiyList)
            {
                FileHelper.DeleteFile("/Upload/IdentityFile/" + verify.IdentityImg);
            }


            Maticsoft.Common.Ajax.WriteOk("删除成功");

            //级联删除其它记录
        }
    }
}