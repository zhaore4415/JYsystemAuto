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
    public partial class TextAd : WebBase.Edit //WebBase.List
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
            int cid = 0;
            string strWhere = "";

            if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
            {
                try
                {
                    cid = int.Parse(Request.QueryString["cid"]);
                }
                catch
                { }
            }
            if (cid > 0)
            {
                strWhere += " and a.AdType=" + cid;
            }
            //DataSet ds = DataUtility.GetList("Ad a(nolock) left join AdType t(nolock) on a.AdType=t.Id", "a.*,t.TypeName", pagesize, page, "a.Id", strWhere, "order by t.Id,a.StartDate,a.Sort,Id", true);
            DataSet ds = DataUtility.GetList("Ad a(nolock)", "a.*", pagesize, page, "a.Id", strWhere, "order by a.Sort", true);
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
            int count = (int)ds.Tables[1].Rows[0][0];

            _pager = new Pager(pagesize, count).Create();

            try
            {
                ltrTypeName.Text = BLL.AdType.GetModelByCache2(cid).TypeName;
            }
            catch { }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string strids = Request.Form["chkItem"];
            if (!string.IsNullOrEmpty(strids))
            {
                string[] ids = strids.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    BLL.Ad.Delete(int.Parse(ids[i]));
                }
            }
            BindList();
        }
    }
}