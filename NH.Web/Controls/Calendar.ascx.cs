using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Maticsoft.Common;

namespace NH.Web.Controls
{
    public partial class Calendar : System.Web.UI.UserControl
    {

        private int pagesize = 5;
        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int PageSize
        {
            set { pagesize = value; }
            get { return pagesize; }
        }

        private int pageindex = 1;

        public int PageIndex
        {
            get { return pageindex; }
            set { pageindex = value; }
        }


        DataTable dtReceives = null;
        DataTable dtJobs = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindList();
        }

        private void BindList()
        {
            DataSet ds = BLL.ReceiveRecord.GetCalendarJobs(pageindex,pagesize);

            dtReceives = ds.Tables[1];
            dtJobs = ds.Tables[2];


            dtReceives.Columns.Add("JobId",typeof(Int32));
            dtReceives.Columns.Add("SalaryName");

            foreach (DataRow row in dtReceives.Rows)
            {
                DataRow jobRow = GetJob(row["CompanyId"].ToString());
                if (jobRow != null)
                {
                    row["JobId"] = jobRow["Id"];
                    row["SalaryName"] = jobRow["SalaryName"];
                }
            }

            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
        }

        protected DataTable GetReceives(string date)
        {
            DataTable dtNew = dtReceives.Clone();

            DataRow[] rows = dtReceives.Select("EndDate='" + date + "'","Id");
            foreach (DataRow row in rows)
            {
                dtNew.Rows.Add(row.ItemArray);
            }

            return dtNew;
        }

        private DataRow GetJob(string cid)
        {
            DataRow[] rows = dtJobs.Select("CompanyId=" + cid);
            if (rows.Length > 0)
            {
                return rows[0];
            }
            else
            {
                return null;
            }
        }

        //protected string GetSalary(string cid)
        //{
        //    DataRow[] rows = dtJobs.Select("CompanyId=" + cid);
        //    if (rows.Length > 0)
        //    {
        //        return rows[0]["SalaryName"].ToString();
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}
    }
}