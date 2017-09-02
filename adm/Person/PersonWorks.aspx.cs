using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Person
{
    public partial class PersonWorks : WebBase.Edit
    {
        protected string originalfolder = "/Upload/PersonWorks/Original/";
        protected string smallfolder = "/Upload/PersonWorks/Small/";
        protected string bigfolder = "/Upload/PersonWorks/Big/";
        protected int count = 0;
        protected int maxCount = 0;
        protected bool _isGood = false;

        DataTable dtAll = null;

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
                case "SetCommend":
                    SetCommend();
                    break;
                case "SetGood":
                    SetGood();
                    break;
                default:
                    BindCategory();
                    break;
            }
        }

        /// <summary>
        /// 将人才推荐到精英摄区
        /// </summary>
        private void SetGood()
        {
            Model.Member model = new Model.Member();
            model.Id = Id;
            model.IsGood = Request.Form["commend"] == "1";

            if (BLL.Member.Update(model))
            {
                Maticsoft.Common.Ajax.WriteOk("操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
        }

        /// <summary>
        /// 推荐作品
        /// </summary>
        private void SetCommend()
        {
            Model.MemberWorks model = new Model.MemberWorks();
            model.Id = int.Parse(Request.Form["id"]);
            model.IsCommend = Request.Form["commend"] == "1";

            if (BLL.MemberWorks.Update(model))
            {
                Maticsoft.Common.Ajax.WriteOk("操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
        }

        /// <summary>
        /// 审核作品
        /// </summary>
        private void Verify()
        {
            Model.MemberWorks model = BLL.MemberWorks.GetModel(Id);
            if (model == null) Maticsoft.Common.Ajax.WriteError("此记录已不存在");

            model.Id = Id;
            model.Status = int.Parse(Request.Form["status"]);

            if (BLL.MemberWorks.Update(model))
            {
                BLL.Member.UpdateComplete(model.MemberID);
                Maticsoft.Common.Ajax.WriteOk("操作成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("操作失败");
            }
        }

        /// <summary>
        /// 删除作品
        /// </summary>
        private void Delete()
        {
            if(BLL.MemberWorks.DeleteRecordAndImgs(int.Parse(Request.Form["id"])))
            {
                Maticsoft.Common.Ajax.WriteOk("删除成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("删除失败");
            }
        }

        private void BindCategory()
        {
            dtAll = BLL.MemberWorks.GetList(0, "MemberID=" + Id.ToString(), "Sort asc").Tables[0];

            rptCategory.DataSource = BLL.MemberWorksCategory.GetList("MemberID=" + Id.ToString()).Tables[0];
            rptCategory.DataBind();


            //数量判断
            count = dtAll.Rows.Count;
            maxCount = Config.PersonWorksCount * Config.PersonWorksCategoryCount;

            //用户信息
            _isGood = BLL.Member.GetModel(Id).IsGood.Value;

            //if (count == 0)
            //{
            //    plNoResult.Visible = true;
            //}
            //else
            //{
            //    plNoResult.Visible = false;
            //}
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
        protected DataTable GetWorks(string categoryId)
        {
            DataTable dt = dtAll.Clone();
            foreach (DataRow row in dtAll.Rows)
            {
                if (row["CategoryID"].ToString() == categoryId)
                {
                    dt.Rows.Add(row.ItemArray);
                }
            }
            return dt;
        }
    }
}