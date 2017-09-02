using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Article
{
    public partial class SysNews : WebBase.Free //WebBase.List
    {
        protected string _type = null;
        protected string _pager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("InfomationManage");
            if (!IsPostBack)
            {
                BindList();
            }
        }

        private void BindList()
        {
            string strWhere = "";
            switch (Request.QueryString["type"])
            {
                case "1":
                    strWhere = " and ac.Type=1";
                    _type = "个人";
                    break;
                case "2":
                    _type = "企业";
                    strWhere = " and ac.Type=2";
                    break;
            }
            if (txtKey.Text.Trim() != "")
            {
                strWhere += " and Title like '%" + txtKey.Text.Trim().Replace("'","''") + "%'";
            }

            int pagesize = 10;
            int page = RequestHelper.GetPageIndex();

            DataSet ds = BLL.Article.GetList(pagesize, page, strWhere, "order by a.Id desc");
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
            int count = (int)ds.Tables[1].Rows[0][0];

            _pager = new Pager(pagesize, count).Create();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = "SysNews.aspx?key=" + txtKey.Text.Trim() + "&" + Request.QueryString.ToString();
            Response.Redirect(url);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //if (!IsDeletePower)
            //{
            //    MessageBox.Show("没有删除权限"); return;
            //}
            string strids = Request.Form["chkItem"];
            if (!string.IsNullOrEmpty(strids))
            {
                BLL.Article.DeleteList(strids);
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}