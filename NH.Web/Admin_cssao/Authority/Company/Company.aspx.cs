using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Maticsoft.Common;

namespace NH.Web.adm.Authority.Company
{
    public partial class Company : WebBase.List
    {
        //DataTable dtCategory = null;
        //DataTable dtNew = null;
        protected string _pager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList(); 
            }
        }
     
        private void BindList()
        {
            string strWhere = "and [Shen].fk_id=[Shi].fk_id and [Shi].sk_id=[Xian].sk_id ";
            string key = Request.QueryString["key"];
            string shen = Request.QueryString["shen"];
            string shi = Request.QueryString["shi"];
            if (!string.IsNullOrEmpty(key))
            {
                strWhere += " and third_kind_name like '%" + key.Trim().Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(shen) && PageValidate.IsNumber(shen) && shen != "0")
            {
                strWhere += " and Shen.fk_id=" + shen;
            }
            if (!string.IsNullOrEmpty(shi) && PageValidate.IsNumber(shi) && shi != "0")
            {
                strWhere += " and Shi.sk_id=" + shi;
            }
            int pagesize = 20;
            int page = RequestHelper.GetPageIndex();

            //DataSet ds = BLL.Xian.GetList(pagesize, page, " ", "order by Xian.tk_id desc");
            DataSet ds = DataUtility.GetList("[Shen],[Shi],[Xian] ", "Shen.fk_id,Shi.sk_id,Xian.tk_id,Xian.third_kind_name,Shi.second_kind_name,Shen.first_kind_name", pagesize, page, "Xian.sk_id", strWhere, "order by Xian.sk_id desc", true); //BLL.Product.GetList(pagesize, page, strWhere, "order by a.Id desc");
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
            int count = (int)ds.Tables[1].Rows[0][0];

            _pager = new Pager(pagesize, count).Create();

            txtKey.Text = Request.QueryString["key"];
        }
        protected string GetSubShi(string sk_id)
        {
          DataSet ds =  BLL.Shi.GetList("sk_id=" + sk_id);
          if (ds.Tables[0].Rows.Count > 0)
          {
              return ds.Tables[0].Rows[0]["second_kind_name"].ToString();
          }
          else { return null; }
          
        }
        protected string GetSubShen(string sk_id)
        {
            DataSet ds = BLL.Shi.GetList("sk_id=" + sk_id);
            DataSet dsshen;
            if (ds.Tables[0].Rows.Count > 0)
            {
                dsshen = BLL.Shen.GetList("fk_id=" + ds.Tables[0].Rows[0]["fk_id"].ToString());
                if (dsshen.Tables[0].Rows.Count > 0)
                {
                    return dsshen.Tables[0].Rows[0]["first_kind_name"].ToString();
                }
                else { return null; }
            }
            else
            {
                { return null; }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = ListUrl + "?key=" + txtKey.Text.Trim() + "&shen=" + Request.Form.Get("ddlBranchOne") + "&shi=" + Request.Form.Get("ddlBranchTwo");
            Response.Redirect(url);
            //BindList();
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
                    Model.Xian model = BLL.Xian.GetModel(int.Parse(ids[i]));
                    if (model != null)
                    {
                        //FileHelper.DeleteFile(folder + model.Logo);
                        BLL.Xian.Delete(int.Parse(ids[i]));
                    }
                }
                //DataCache.RemoveDependencyFile("Bank");
            }
            BindList();
        }
    }
}