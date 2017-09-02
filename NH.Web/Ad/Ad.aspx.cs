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
    public partial class Ad : WebBase.Edit //WebBase.List
    {
        protected string folder = "/Upload/Ad/";
        protected string _pager;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckPowerAndRedirect("AdManage");
            if (!IsPostBack)
            {
                //BindCategory();
                BindList();
            }
        }
        
        /*
        private void BindCategory()
        {
            ddlCategory.DataSource = BLL.AdType.GetList(0, "IsShow=1", "Sort");
            ddlCategory.DataTextField = "TypeName";
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("选择类型", "0"));

        }
        */

        private void BindArea()
        {
        }

        private void BindList()
        {
            int pagesize = 10;
            int page = RequestHelper.GetPageIndex();
            int cid = 0;
            string area1 = Request.QueryString["area1"];
            string area2 = Request.QueryString["area2"];
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
            if (!string.IsNullOrEmpty(area2))
            {
                strWhere += " and a.AreaNo like '" + area2.Replace("'","''") + "%'";
            }
            else if (!string.IsNullOrEmpty(area1))
            {
                strWhere += " and a.AreaNo like '" + area1.Replace("'", "''") + "%'";
            }
            DataSet ds = DataUtility.GetList("Ad a(nolock) left join Area(nolock) on a.AreaNo=Area.AreaNo", "a.*,Area.FullName as AreaName", pagesize, page, "a.Id", strWhere, "order by a.Sort", true);
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
            int count = (int)ds.Tables[1].Rows[0][0];

            _pager = new Pager(pagesize, count).Create();

            try
            {
                ltrTypeName.Text = BLL.AdType.GetModelByCache2(cid).TypeName;
            }
            catch { }

            //地区 js
            this.ltrAreaJsObject.Text = BLL.Area.BuildJsObject();
            this.ltrAreaProvince.Text = BLL.Area.BuildOption("ParentNo=1", area1);
            this.ltrAreaCity.Text = BLL.Area.BuildOption("ParentNo='" + (area1 + "").Replace("'", "''") + "'", area2);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string _areaProvinceId = Request.Form["ddlAreaProvince"];
            string _areaCityId = Request.Form["ddlAreaCity"];
            string url = ListUrl + "?cid=" + Request.QueryString["cid"] + "&area1=" + _areaProvinceId + "&area2=" + _areaCityId;
            Response.Redirect(url);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string strids = Request.Form["chkItem"];
            if (!string.IsNullOrEmpty(strids))
            {
                string[] ids = strids.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    Model.Ad model = BLL.Ad.GetModel(int.Parse(ids[i]));
                    if (model != null)
                    {
                        FileHelper.DeleteFile(folder + model.Pic);
                        BLL.Ad.Delete(model.Id);
                    }
                }
            }
            BindList();
        }
    }
}