using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Authority.Staff
{
    public partial class Staff : WebBase.List
    {
        protected string _pager;
        //DataTable dtRoles = null;
        //DataTable dtUserRole = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        private void BindList()
        {
            string strWhere = " ";
            string key = Request.QueryString["key"];
            string wdate = Request.QueryString["Wdate"];
            //model.TodayDate = Request.Form["Wdate"].Trim();
            if (!string.IsNullOrEmpty(key))
            {
                strWhere += " and Realname like '%" + key.Trim().Replace("'", "''") + "%' or  WorkNumber like '%" + key.Trim().Replace("'", "''") + "%'";
            }
            if (!string.IsNullOrEmpty(wdate))
            {
                strWhere += " and TodayDate='" + wdate + "'";
            }

            int pagesize = 20;
            int page = RequestHelper.GetPageIndex();
            DataSet ds = DataUtility.GetList("Staff u(nolock)", "u.*", pagesize, page, "u.Id", strWhere, "", true);
            //DataSet ds = BLL.Article.GetList(pagesize, page, strWhere, "order by a.Id desc");
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
            int count = (int)ds.Tables[1].Rows[0][0];

            _pager = new Pager(pagesize, count).Create();
            txtKey.Text = Request.QueryString["key"];
            Wdate.Value = Request.QueryString["Wdate"];
        }

        //protected string GetRoleName(int userId)
        //{
        //    string result = string.Empty;
        //    DataRow[] drUserRole = dtUserRole.Select("UserId=" + userId.ToString());
        //    foreach (DataRow row in drUserRole)
        //    {
        //        DataRow[] drRoles = dtRoles.Select("Id=" + row["RoleId"].ToString());
        //        foreach (DataRow rowRole in drRoles)
        //        {
        //            result += rowRole["RoleName"].ToString() + ",";
        //        }
        //    }
        //    return result.TrimEnd(',');
        //}
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = ListUrl + "?key=" + txtKey.Text.Trim() + "&Wdate=" + Wdate.Value;
            Response.Redirect(url);
            //BindList();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!IsDeletePower)
            {
                MessageBox.Show("没有删除权限"); return;
            }
            string strids = Request.Form["chkItem"];
            if (!string.IsNullOrEmpty(strids))
            {
                string[] ids = strids.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    if (int.Parse(ids[i]) == UserBase.CurAdmin.Id) return;
                    BLL.Staff.Delete(int.Parse(ids[i]));
                }
            }
            //Response.Redirect(Request.RawUrl);
            BindList();
        }
    }
}