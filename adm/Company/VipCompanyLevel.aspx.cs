﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Company
{
    public partial class VipCompanyLevel : WebBase.Edit
    {
        protected string _levelinfo = null;
        protected int _levelId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            switch (Request.Form["action"])
            {
                case "modify":
                    Modify();
                    break;
                default:
                    Show();
                    break;
            }
        }

        private void Show()
        {
            Model.Company model = BLL.Company.GetModelWidthLevel(Id);
            bool a = model == null;
            bool b = model.CompanyLevel == null;
            if (model != null || model.CompanyLevel != null)
            {
                Model.CompanyLevel level = model.CompanyLevel;
                //_levelinfo = string.Format("当前等级：{0}，每日置顶机会：{1}，每日可发布职位条数：{2}，允许信息套红条数：{3}，相册可上传图片数量：{4}，到期时间：{5}", level.LevelName, level.RefreshJobCount, level.JobCount, level.FixCount, level.AlbumCount, (model.ExpireDate.HasValue ? model.ExpireDate.Value.ToString("yyyy-MM-dd") : "无"));
                _levelinfo = "当前等级：" + level.LevelName + "，每日置顶机会：" + level.RefreshJobCount + "，可发布职位条数：" + level.TotalJobCount + "，相册可上传图片数量：" + level.AlbumCount + "，到期时间：" + (model.ExpireDate.HasValue ? model.ExpireDate.Value.ToString("yyyy-MM-dd") : "无");
                _levelId = level.Id;
                rptList.DataSource = BLL.CompanyLevel.GetList(0, "", "Sort");
                rptList.DataBind();

                if (model.ExpireDate.HasValue)
                {
                    txtCompanyExpireDate.Text = model.ExpireDate.Value.ToString("yyyy-MM-dd");
                }
            }

            rptLog.DataSource = DataUtility.GetList(
                "VipCompanyLog l(nolock) left join CompanyLevel cl(nolock) on l.LevelID=cl.Id",
                "l.ExpireDate,l.AddTime,l.AddType,cl.LevelName",
                0,
                1,
                "l.Id",
                "and l.CompanyId=" + Id,
                "order by l.Id desc",
                false).Tables[0];
            rptLog.DataBind();
        }

        protected string GetExpireDate(int num, string unit)
        {
            string result = null;
            if (num > 0)
            {
                switch (unit)
                {
                    case "day":
                        result = DateTime.Now.AddDays(num).ToString("yyyy-MM-dd");
                        break;
                    case "month":
                        result = DateTime.Now.AddMonths(num).ToString("yyyy-MM-dd");
                        break;
                    case "year":
                        result = DateTime.Now.AddYears(num).ToString("yyyy-MM-dd");
                        break;
                }
            }
            return result;
        }

        private void Modify()
        {
            int levelId = int.Parse(Request.Form["LevelId"]);
            Model.CompanyLevel level = BLL.CompanyLevel.GetModel(levelId);

            Model.Company old = BLL.Company.GetModelWidthLevel(Id);


            Model.Company model = new Model.Company();
            model.Id = Id;
            model.LevelID = levelId;
            if (level.ExpireNum > 0)
            {
                try
                {
                    model.ExpireDate = DateTime.Parse(Request.Form["ExpireDate"]);
                }
                catch
                {
                    Maticsoft.Common.Ajax.WriteError("到期时间不正确！");
                }
            }
            else
            {
                model.ExpireDate = DateTime.MinValue;
            }
            if (!old.IsVipOk)
            {
                model.VipOpenType = 1;
            }


            if (BLL.Company.Update(model))
            {
                if (old.LevelID != levelId || old.ExpireDate != model.ExpireDate)
                {
                    Model.VipCompanyLog log = new Model.VipCompanyLog();
                    log.CompanyId = Id;
                    log.LevelID = levelId;
                    log.ExpireDate = model.ExpireDate;
                    log.AddTime = DateTime.Now;
                    log.AddType = 1;
                    log.AddUser = UserBase.CurAdmin.LoginName;

                    BLL.VipCompanyLog.Add(log);
                }

                Maticsoft.Common.Ajax.WriteOk("保存成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("保存失败！");
            }
        }
    }
}