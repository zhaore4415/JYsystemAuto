using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Authority.AUser
{
    public partial class AUser : WebBase.List
    {
        protected string folder = "/Upload/AUserFile/";
        protected string _pager;
        DataTable dtRoles = null;
        DataTable dtUserRole = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        private void BindList()
        {
            string strWhere = "  ";
            string key = Request.QueryString["key"];
            if (!string.IsNullOrEmpty(key))
            {
                strWhere += " and u.LoginName like '%" + key.Trim().Replace("'", "''") + "%' or u.Realname like '%" + key.Trim().Replace("'", "''") + "%' or u.Department like '%" + key.Trim().Replace("'", "''") + "%' or u.SerialNumber like '%" + key.Trim().Replace("'", "''") + "%'";
            }
            dtRoles = BLL.Role.GetAllList().Tables[0];
            dtUserRole = BLL.UserRole.GetAllList().Tables[0];

            int pagesize = 10;
            int page = RequestHelper.GetPageIndex();
            DataSet ds = DataUtility.GetList("AUser u(nolock)", "u.*", pagesize, page, "u.Id", strWhere, "", true);
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
            int count = (int)ds.Tables[1].Rows[0][0];

            _pager = new Pager(pagesize, count).Create();

        }
        //protected string GetVipName(int RoleType)
        //{
        //    //string result = string.Empty;
        //    if (RoleType == 1) 
        //    { return "超级管理员"; }
        //    else if (RoleType == 2)
        //    { return "一级会员"; }
        //    else if (RoleType == 3)
        //    { return "二级会员"; }
        //    else
        //    {
        //        return "无";
        //    }
        //}
        protected string GetRoleName(int userId)
        {
            string result = string.Empty;
            DataRow[] drUserRole = dtUserRole.Select("UserId=" + userId.ToString());
            foreach (DataRow row in drUserRole)
            {
                DataRow[] drRoles = dtRoles.Select("Id=" + row["RoleId"].ToString());
                foreach (DataRow rowRole in drRoles)
                {
                    result += rowRole["RoleName"].ToString() + ",";
                }
            }
            return result.TrimEnd(',');
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //string url = ListUrl + "?key=" + txtKey.Text.Trim();
            //Response.Redirect(url);
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
                    if (int.Parse(ids[i]) == UserBase.CurAdmin.Id) { MessageBox.Show("没有删除权限"); return; }


                    Model.AUser model = BLL.AUser.GetModel(int.Parse(ids[i]));
                    if (model != null)
                    {
                      

                        BLL.AUser.Delete(model.Id);
                    }
                }
            }
            //Response.Redirect(Request.RawUrl);
            BindList();
        }
    }
}