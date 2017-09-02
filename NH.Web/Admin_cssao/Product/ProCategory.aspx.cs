using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Maticsoft.Common;

namespace NH.Web.adm.Product
{
    public partial class ProCategory : WebBase.List
    {
        //protected string folder = "/Upload/CategoryIcon/";
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
            dtCategory = BLL.ProCategory.GetList("").Tables[0];
            dtNew = dtCategory.Clone();
            GetSubCategory("0");
            rptList.DataSource = dtNew;
            rptList.DataBind();
        }
        private void GetSubCategory(string parentId)
        {
            DataRow[] rows = dtCategory.Select("ParentID=" + parentId, "Sort");
            foreach (DataRow row in rows)
            {
                dtNew.Rows.Add(row.ItemArray);
                GetSubCategory(row["Id"].ToString());
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
                    Model.ProCategory model = BLL.ProCategory.GetModel(int.Parse(ids[i]));
                    BLL.ProCategory.Delete(model.ID);
                    if (!string.IsNullOrEmpty(model.Pic))
                    {
                        BLL.ProCategory.Delete(model.ID);
                        //删除子类
                        BLL.ProCategory.DeleteSubCategory(model.ID);
                        //更新上级Child
                        BLL.ProCategory.UpdateParentChildCount(model.ParentID.ToString());
                        if (!string.IsNullOrEmpty(model.Pic))
                        {
                            System.IO.File.Delete(Server.MapPath("/Upload/CategoryIcon/") + model.Pic);
                        }
                    }
                }
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}