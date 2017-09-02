using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Company
{
    public partial class CompanyJobs : WebBase.List
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            switch (Request.QueryString["action"])
            {
                case "GetList":
                    GetList();
                    break;
                case "SetTop":
                    SetTop();
                    break;
                case "Delete":
                    Delete();
                    break;
                default:
                    Show();
                    break;
            }
        }

        private void Show()
        {
            lbTotalRefreshCount.Text = BLL.Company.GetModelWidthLevel(Id).CompanyLevel.RefreshJobCount.ToString();
            lbTodayRefreshCount.Text = BLL.JobRefreshLog.GetRefreshCount(Id).ToString();
        }

        private void GetList()
        {
            #region
            int pagesize = EasyUI.GetPageSize();//每页显示数量
            int pageindex = EasyUI.GetPageIndex();//页码
            #endregion
            string strWhere = "and j.Status<>-1 and CompanyID=" + Id.ToString();

            Response.Write(DataUtility.GetListToJson("Job j(nolock) left join JobCategory jc(nolock) on j.CategoryNo=jc.CategoryNo", "j.Id,j.CategoryNo,j.Status,j.ViewCount,j.UpdateTime,j.RefreshTime,j.AddTime,j.Verified,jc.Name JobCategoryName", pagesize, pageindex, "j.Id", strWhere, "order by j.Status desc, j.RefreshTime desc", true));
            Response.End();
        }

        private void SetTop()
        {
            int _dayTotalCount = BLL.Company.GetModelWidthLevel(Id).CompanyLevel.RefreshJobCount;// UserBase.CurCompany.CompanyLevel.RefreshJobCount;


            //查询当天已置顶的次数
            int _todayCount = BLL.JobRefreshLog.GetRefreshCount(Id);
            if (_todayCount >= _dayTotalCount)
            {
                Maticsoft.Common.Ajax.WriteError("今天的置顶功能已使用完毕");
            }

            Model.Job model = new Model.Job();
            model.Id = int.Parse(Request.Form["jobid"]);
            model.RefreshTime = DateTime.Now;
            if (BLL.Job.Update(model))
            {
                Model.JobRefreshLog refreshLog = new Model.JobRefreshLog();
                refreshLog.CompanyID = Id;
                refreshLog.JobID = model.Id;
                refreshLog.RefreshTime = DateTime.Now;
                BLL.JobRefreshLog.Add(refreshLog);

                Maticsoft.Common.Ajax.WriteOkAndJsonData("置顶成功", "\"" + (_todayCount + 1) + "\"");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("置顶失败");
            }
        }

        private void Delete()
        {
            int id = int.Parse(Request.Form["jobid"]);
            BLL.Job.Delete(id);
            Maticsoft.Common.Ajax.WriteOk("删除成功");
        }
    }
}