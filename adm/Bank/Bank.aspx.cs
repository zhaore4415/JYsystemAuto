using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Bank
{
    public partial class Bank : WebBase.List
    {
        protected string folder = "/Upload/Bank/";
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
            int pagesize = 10;
            int page = RequestHelper.GetPageIndex();
            DataSet ds = DataUtility.GetList("Bank", "*", pagesize, page, "Id", "", "order by Sort,Id", true);
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
            int count = (int)ds.Tables[1].Rows[0][0];

            _pager = new Pager(pagesize, count).Create();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CheckDeletePower();
            string strids = Request.Form["chkItem"];
            if (!string.IsNullOrEmpty(strids))
            {
                string[] ids = strids.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    Model.Bank model = BLL.Bank.GetModel(int.Parse(ids[i]));
                    if (model != null)
                    {
                        FileHelper.DeleteFile(folder + model.Logo);
                        BLL.Bank.Delete(int.Parse(ids[i]));
                    }
                }
                DataCache.RemoveDependencyFile("Bank");
            }
            BindList();
        }
    }
}