using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.system
{
    public partial class MyQuanXian : WebBase.List
    {
        private DataTable dtCategory = null;
        private DataTable dtFunCode = null;
  
        StringBuilder sbFun = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show();
            }
        }

        private void Show()
        {
            //超级管理员
            if (UserBase.CurAdmin.RoleType == 1)
            {
                Label1.Text = "你是超级管理员，拥有最高权限";
                Label1.Visible = true;
                ltrFunCode.Visible = false;
            }
            else
            {
                Model.UserRole modeluser = new Model.UserRole();
                modeluser.UserId = UserBase.CurAdmin.Id;
                modeluser = BLL.UserRole.GetModel(modeluser);

                //int a = modeluser.RoleId;
                Model.Role model = BLL.Role.GetModel(modeluser.RoleId);



                dtCategory = BLL.FunGroup.GetList("").Tables[0];
                dtFunCode = BLL.FunCode.GetListWithRoleId(modeluser.RoleId);

                GetSub("0");

                ltrFunCode.Text = sbFun.ToString();
                Label1.Visible = false; ltrFunCode.Visible = true;
            }
        }

        private void GetSub(string pid)
        {
            DataRow[] rows = dtCategory.Select("ParentID=" + pid);
            if (rows.Length == 0) return;

            sbFun.Append("<ul class='FunGroup'>");
            foreach (DataRow row in rows)
            {
                if (UserBase.CurAdmin.RoleType == 1)
                {
                    //UserBase.CurAdmin.RoleType == 1 ? <input type='checkbox' id='fungroup_{0}' /><label for='fungroup_{1}'>{2}</label> : "<input type='checkbox' id='fungroup_{0}' /><label for='fungroup_{1}'>{2}</label>"
                }
                sbFun.Append("<li class='FunGroupItem'>");
                //sbFun.Append(string.Format("<span>{0}</span>",row["GroupName"].ToString()));
                sbFun.Append(string.Format("<input type='checkbox' id='fungroup_{0}' /><label for='fungroup_{1}'>{2}</label>", row["Id"], row["Id"], row["GroupName"]));

                DataRow[] funRows = dtFunCode.Select("GroupId=" + row["Id"].ToString());
                if (funRows.Length > 0)
                {
                    sbFun.Append("<ul class='FunCode'>");
                    foreach (DataRow fun in funRows)
                    {
                        sbFun.Append(string.Format("<li><input type='checkbox' id='funcode_{0}' name='funcode' disabled='disabled' value='{1}' {2} /><label for='funcode_{3}'>{4}</label></li>", fun["Id"], fun["Id"], fun["RoleId"].ToString() != "" ? "checked='checked'" : "", fun["Id"], fun["Name"]));
                    }
                    sbFun.Append("</ul>");
                }
                GetSub(row["Id"].ToString());

                sbFun.Append("</li>");
            }
            sbFun.Append("</ul>");
        }

     
    }
}