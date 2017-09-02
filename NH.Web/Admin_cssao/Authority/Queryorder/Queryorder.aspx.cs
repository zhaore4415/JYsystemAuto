using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;
using System.Collections;
using System.Text;

namespace NH.Web.adm.Authority.Queryorder
{
    public partial class Queryorder : WebBase.List
    {
        protected string _pager;
        protected string _type;

        public string filename = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindList();
                if (!string.IsNullOrEmpty(Request.QueryString["u_id"]))
                {
                    hid_U_ID.Value= Request.QueryString["u_id"];
                
                    NH.Model.User mod = new NH.Model.User();
                 
                    mod= BLL.User.GetModel(Convert.ToInt32(hid_U_ID.Value));
                    lb_Name.Text = mod.LoginName;
                    //txt_Name.Value = Request.QueryString["u_name"];
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["class"]))
            {
                _type = Request.QueryString["class"];
            }


        }

        //private void BindList()
        //{

        //    int pagesize = 10;
        //    int page = RequestHelper.GetPageIndex();
       
        //    StringBuilder strWhere = new StringBuilder();
        //    string START_DATE = txtSTART_DATE.Value;
        //    string END_DATE = txtEND_DATE.Value;
        //    string status = selStatus.Value;
        //    if (!string.IsNullOrEmpty(Request.QueryString["u_id"]) && PageValidate.IsNumber(Request.QueryString["u_id"]))
        //    {
        //        strWhere.AppendFormat(" and fb.U_ID={0} ", Request.QueryString["u_id"]);
        //    }
           
        //    if (!string.IsNullOrEmpty(Request.QueryString["key"]))
        //    {
        //        strWhere.AppendFormat(" and fb.OrderNumber like '%{0}%'", Request.QueryString["key"].Trim().Replace("'", "''"));
        //        //strWhere += " and fb.OrderNumber like '%" + Request.QueryString["key"].Trim().Replace("'", "''") + "%'";
        //        //txtKey.Text = Request.QueryString["key"].ToString();
        //    }

        //    if (!string.IsNullOrEmpty(START_DATE))
        //    {
        //        strWhere.AppendFormat(" AND fb.DeliveryTime >= '{0}' ", START_DATE);
        //    }
        //    if (!string.IsNullOrEmpty(END_DATE))
        //    {
        //        strWhere.AppendFormat(" AND fb.DeliveryTime <= '{0}' ", END_DATE);
        //    }

       
        //    DataSet ds = DataUtility.GetList("Queryorder fb", "fb.*", pagesize, page, "fb.Id", strWhere.ToString(), "order by fb.Id desc", true); //BLL.Product.GetList(pagesize, page, strWhere, "order by a.Id desc");
        //    //rptList.DataSource = ds.Tables[0];
        //    //rptList.DataBind();
        //    int count = (int)ds.Tables[1].Rows[0][0];

        //    _pager = new Pager(pagesize, count).Create();

        //    //txtKey.Text = Request.QueryString["key"].ToString();
        //}

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("Queryorder.aspx?key=" + txtKey.Text.Trim());
        //}

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    string strids = Request.Form["chkItem"];
        //    if (!string.IsNullOrEmpty(strids))
        //    {
        //        string[] ids = strids.Split(',');
        //        for (int i = 0; i < ids.Length; i++)
        //        {
        //            BLL.Queryorder.Delete(int.Parse(ids[i]));
        //        }
        //    }
        //    Response.Redirect(Request.RawUrl);

        //}


    }

}