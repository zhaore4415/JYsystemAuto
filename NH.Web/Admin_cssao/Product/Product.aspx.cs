using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;
using System.Collections;

namespace NH.Web.adm.Product
{
    public partial class Product : WebBase.List
    {
        protected string _pager;
       public string filename = "";
        protected void Page_Load(object sender, EventArgs e)
       {
          
            if (!IsPostBack)
            {
                BindCategory(null, "0");
                BindList();
            
            }
        }

        private void BindCategory(DataTable dt, string parentId)
        {
            if (dt == null)
            {
                dt = BLL.ProCategory.GetList("").Tables[0];
            }
            DataRow[] rows = dt.Select("ParentID=" + parentId, "Sort");
            foreach (DataRow row in rows)
            {
                ddlCategory.Items.Add(new ListItem("├".PadLeft((int)row["Depth"], '　') + "　" + row["Name"].ToString(), row["Id"].ToString()));
                BindCategory(dt, row["Id"].ToString());
            }
        }

        private void BindList()
        {
            int pagesize = 15;
            int page = RequestHelper.GetPageIndex();
            string strWhere = "";
            if (!string.IsNullOrEmpty(Request.QueryString["key"]))
            {
                strWhere += " and p.Name like '%" + Request.QueryString["key"].Trim().Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(Request.QueryString["cid"]) && PageValidate.IsNumber(Request.QueryString["cid"]))
            {
                if (Request.QueryString["cid"] != "0")
                {
                    strWhere += " and p.CategoryPath like '%," + Request.QueryString["cid"] + ",%'";
                }
            }
            //if (Request.QueryString["sid"] == "0")
            //{ strWhere += " and p.VerifyStatus=0"; }
            //else { strWhere += " and p.VerifyStatus=1"; }

            DataSet ds = DataUtility.GetList("Product p left join ProCategory c on p.CategoryID=c.Id", "p.*,c.Name as CategoryName", pagesize, page, "p.Id", strWhere, "order by p.Id desc", true); //BLL.Product.GetList(pagesize, page, strWhere, "order by a.Id desc");
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
            int count = (int)ds.Tables[1].Rows[0][0];

            _pager = new Pager(pagesize, count).Create();

            txtKey.Text = Request.QueryString["key"];
            try
            {
                ddlCategory.SelectedValue = Request.QueryString["cid"];
            }
            catch { }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product.aspx?key=" + txtKey.Text.Trim() + "&cid=" + ddlCategory.SelectedValue );
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string strids = Request.Form["chkItem"];
            if (!string.IsNullOrEmpty(strids))
            {
                string[] ids = strids.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    Model.Product model = BLL.Product.GetModel(int.Parse(ids[i]));
                    if (model != null)
                    {
                        //model.VerifyStatus = 1;
                        //BLL.Product.Update(model);
                        BLL.Product.Delete(model.Id);
                        if (!string.IsNullOrEmpty(model.Pic))
                        {
                            System.IO.File.Delete(Server.MapPath("/Upload/ProductImg/") + model.Pic);
                        }
                        if (!string.IsNullOrEmpty(model.SmallPic))
                        {
                            System.IO.File.Delete(Server.MapPath("/Upload/ProductSmallImg/") + model.SmallPic);
                        }
                    }
                }
            }
            Response.Redirect(Request.RawUrl);

        }

      
    }
}