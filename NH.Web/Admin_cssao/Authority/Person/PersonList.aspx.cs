using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;
using System.Text;

namespace NH.Web.adm.Person
{
    public partial class PersonList : WebBase.List
    {
        protected string _pager;
        DataTable dtUser = null;
        DataTable dtUserRole = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //CheckPowerAndRedirect("Staff");
            if (!IsPostBack)
            {
                BindList();
            }
        }

        private void BindList()
        {
            dtUser = BLL.User.GetAllList().Tables[0];
            dtUserRole = BLL.UserRole.GetAllList().Tables[0];
            string strWhere = "";
            if (!string.IsNullOrEmpty(Request.QueryString["key"]))
            {
                strWhere += " and u.Phone like '%" + Request.QueryString["key"].Trim().Replace("'", "''") + "%'";
            }
            int pagesize = 10;
            int page = RequestHelper.GetPageIndex();
            DataSet ds = DataUtility.GetList("[User] u(nolock)", "u.*", pagesize, page, "u.Id", strWhere, "", true);
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
            int count = (int)ds.Tables[1].Rows[0][0];

            _pager = new Pager(pagesize, count).Create();

        }

        //protected string GetRoleName(int userId)
        //{
        //    string result = string.Empty;
        //    DataRow[] drUserRole = dtUserRole.Select("UserId=" + userId.ToString());
        //    foreach (DataRow row in drUserRole)
        //    {
        //        DataRow[] drUser = dtUser.Select("Id=" + row["RoleId"].ToString());
        //        foreach (DataRow rowUser in drUser)
        //        {
        //            result += rowUser["RoleName"].ToString() + ",";
        //        }
        //    }
        //    return result.TrimEnd(',');
        //}
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonList.aspx?key=" + txtKey.Text.Trim());
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
                    BLL.User.Delete(int.Parse(ids[i]));
                }
            }
            //Response.Redirect(Request.RawUrl);
            BindList();
        }


        /// <summary>
        /// 返回上级用户名
        /// </summary>
        /// <param name="parentID">上级用户ID</param>
        /// <returns></returns>
        public string getParent(int parentID)
        {
            Model.User model = BLL.User.GetModel(parentID);
            return parentID == 0 ? null : model.LoginName;
        }

        protected string getChild(int Id)
        {
            DataSet ds = BLL.User.GetList(" ParentID=" + Id);

            StringBuilder sb = new StringBuilder();
            sb.Append("<ol>");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string name = ds.Tables[0].Rows[i]["LoginName"].ToString();
                sb.Append(@"<li>" + name + "");
                //getChild(Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString()));
                DataSet ds2 = BLL.User.GetList(" ParentID=" + Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString()));
                sb.Append("<ol>");
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    string name2 = ds2.Tables[0].Rows[j]["LoginName"].ToString();
                    sb.Append("<li>" + name2 + "</li>");
                }
                sb.Append("</ol>");
                sb.Append("</li>");


            }
            sb.Append("</ol>");


            return sb.ToString();
        }
    }
}