using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.JobCategory
{
    public partial class JobCategory : WebBase.List
    {
        DataTable dtCategory = null;
        DataTable dtNew = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        private void BindList()
        {
            dtCategory = BLL.JobCategory.GetAllList().Tables[0];
            dtNew = dtCategory.Clone();
            GetSubCategory("1");
            rptList.DataSource = dtNew;
            rptList.DataBind();
        }
        private void GetSubCategory(string parentNo)
        {
            DataRow[] rows = dtCategory.Select("ParentNo=" + parentNo, "Sort");
            foreach (DataRow row in rows)
            {
                dtNew.Rows.Add(row.ItemArray);
                GetSubCategory(row["CategoryNo"].ToString());
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string strids = Request.Form["chkItem"];
            if (!string.IsNullOrEmpty(strids))
            {
                string[] ids = strids.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    Model.JobCategory model = BLL.JobCategory.GetModel(int.Parse(ids[i]));
                    if (model != null)
                    {
                        BLL.JobCategory.Delete(model.Id);
                        BLL.JobCategory.DeleteByParentID(model.ParentNo);

                        //if (model.ParentNo == "1")
                        //{
                        //    //删除下级
                        //    BLL.JobCategory.DeleteByParentID(model.ParentNo);
                        //}
                    }

                }
            }
            DataCache.RemoveDependencyFile("JobCategory");
            Response.Redirect(Request.RawUrl);
        }
    }
}