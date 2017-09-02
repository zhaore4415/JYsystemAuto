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
    public partial class Fun : WebBase.List
    {
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
            int pagesize = 20;
            int page = RequestHelper.GetPageIndex();
            DataSet ds = DataUtility.GetList("FunCode fc(nolock) left join FunGroup fg(nolock) on fc.GroupID=fg.Id", "fc.*,fg.GroupName", pagesize, page, "fc.Id", "", "order by GroupId", true);
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
            int count = (int)ds.Tables[1].Rows[0][0];

            _pager = new Pager(pagesize, count).Create();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string strids = Request.Form["chkItem"];
            if (!string.IsNullOrEmpty(strids))
            {
                string[] ids = strids.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    BLL.FunCode.Delete(int.Parse(ids[i]));
                }
            }
            //Response.Redirect(Request.RawUrl);
            BindList();
        }
    }
}