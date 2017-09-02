using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Authority.Fun
{
    public partial class FunGroup : WebBase.List
    {
        DataTable dtAll = null;
        DataTable dtNew = null;
        protected string _pager;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        private void BindList()
        {
            dtAll = BLL.FunGroup.GetList("").Tables[0];
            dtNew = dtAll.Clone();
            GetSub("0");
            rptList.DataSource = dtNew;
            rptList.DataBind();
        }

        private void GetSub(string pid)
        {
            DataRow[] rows = dtAll.Select("ParentID=" + pid);
            foreach (DataRow row in rows)
            {
                dtNew.Rows.Add(row.ItemArray);
                GetSub(row["Id"].ToString());
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!IsDeletePower)
            {
                MessageBox.Show("没有删除权限"); return;
            }
            string strids = Request.Form["chkItem"];
            if (!string.IsNullOrEmpty(strids))
            {
                string[] ids = strids.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    BLL.FunGroup.Delete(int.Parse(ids[i]));
                }
            }
            BindList();
        }
    }
}