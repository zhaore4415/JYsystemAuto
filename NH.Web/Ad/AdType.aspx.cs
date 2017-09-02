using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Ad
{
    public partial class AdType : WebBase.Edit //WebBase.List
    {
        protected string _pager;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("AdManage");
            if (!IsPostBack)
            {
                BindList();
            }
        }

        private void BindList()
        {
            int pagesize = 10;
            int page = RequestHelper.GetPageIndex();
            DataSet ds = DataUtility.GetList("AdType", "*", pagesize, page, "Id", "and IsShow=1", "order by Sort,Id", true);
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
            int count = (int)ds.Tables[1].Rows[0][0];

            _pager = new Pager(pagesize, count).Create();

        }
    }
}