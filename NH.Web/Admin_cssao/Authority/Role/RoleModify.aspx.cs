using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Authority.Role
{
    public partial class RoleModify : WebBase.Edit
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
            Model.Role model = BLL.Role.GetModel(Id);
            txtName.Text = model.RoleName;


            dtCategory = BLL.FunGroup.GetList("").Tables[0];
            dtFunCode = BLL.FunCode.GetListWithRoleId(Id);

            GetSub("0");

            ltrFunCode.Text = sbFun.ToString();
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
                        sbFun.Append(string.Format("<li><input type='checkbox' id='funcode_{0}' name='funcode' value='{1}' {2} /><label for='funcode_{3}'>{4}</label></li>", fun["Id"], fun["Id"], fun["RoleId"].ToString() != "" ? "checked='checked'" : "", fun["Id"], fun["Name"]));
                    }
                    sbFun.Append("</ul>");
                }
                GetSub(row["Id"].ToString());

                sbFun.Append("</li>");
            }
            sbFun.Append("</ul>");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.Role model = new Model.Role();
            model.RoleName = txtName.Text.Trim();
            model.Status = 1;
            model.Id = Id;

            if (BLL.Role.Update(model))
            { //写系统日志
                Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
                MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
                MyRiZhi.DoSomething = "修改角色(" + txtName.Text.Trim() + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                BLL.ERPRiZhi.Add(MyRiZhi);
                //删除旧功能
                BLL.RoleFun.DeleteByRoleId(Id);

                //重新添加
                string funIds = Request.Form["funcode"];

                if (!string.IsNullOrEmpty(funIds))
                {
                    string[] ids = funIds.Split(',');
                    for (int i = 0; i < ids.Length; i++)
                    {
                        Model.RoleFun rolefun = new Model.RoleFun();
                        rolefun.RoleId = Id;
                        rolefun.FunId = int.Parse(ids[i]);
                        BLL.RoleFun.Add(rolefun);
                    }
                }
            }

            MessageBox.ShowAndRedirect("修改成功", ListUrl);
        }
    }
}