using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.Data;
using Newtonsoft.Json;
using System.Text;


namespace NH.Web.adm.Authority.Bill
{
    public partial class BillManage : WebBase.List
    {
        protected string _pager;
        protected string _type;
        public string filename = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindList();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["class"]))
            {
                _type = Request.QueryString["class"];
            }
        }

        private void BindList()
        {

            int pagesize = 10;
            int page = RequestHelper.GetPageIndex();
            string strWhere = ""; //" and U_ID=" + UserBase.CurAdmin.Id + " and Status<>2 ";

            if (!string.IsNullOrEmpty(Request.QueryString["key"]))
            {
                strWhere += " and fb.OrderNumber like '%" + Request.QueryString["key"].Trim().Replace("'", "''") + "%'";
                //txtKey.Text = Request.QueryString["key"].ToString();
            }

            //if (!string.IsNullOrEmpty(Request.QueryString["pid"]) && PageValidate.IsNumber(Request.QueryString["pid"]))
            //{
            //    strWhere += " and fb.Pid=" + Request.QueryString["pid"];
            //}
            DataSet ds = DataUtility.GetList("Bill fb", "fb.*", pagesize, page, "fb.Id", strWhere, "order by fb.Id desc", true); //BLL.Product.GetList(pagesize, page, strWhere, "order by a.Id desc");
            //rptList.DataSource = ds.Tables[0];
            //rptList.DataBind();
            string dd = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dd += ds.Tables[0].Rows[i]["Buyers"].ToString();
            }
            int count = (int)ds.Tables[1].Rows[0][0];

            _pager = new Pager(pagesize, count).Create();

            //txtKey.Text = Request.QueryString["key"].ToString();
        }

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("Bill.aspx?key=" + txtKey.Text.Trim());
        //}

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    string strids = Request.Form["chkItem"];
        //    if (!string.IsNullOrEmpty(strids))
        //    {
        //        string[] ids = strids.Split(',');
        //        for (int i = 0; i < ids.Length; i++)
        //        {
        //            BLL.Bill.Delete(int.Parse(ids[i]));
        //        }
        //    }
        //    Response.Redirect(Request.RawUrl);

        //}


    }

}