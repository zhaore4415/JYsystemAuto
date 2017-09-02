using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace NH.Web.adm.WebBase
{
    public class Edit:AdminBase
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            //判断权限
            CheckPower();

            //样式表和js
            CssAndScript =
@"<link href=""/adm/Style/Admin.css"" rel=""stylesheet"" type=""text/css"" />
<script src=""/adm/Script/jquery-1.7.2.min.js"" type=""text/javascript""></script>
<script type=""text/javascript"">$(document).ready(function () { $('input[type=text],input[type=password],textarea').addClass('txtCls'); }); $.ajaxSetup({ error:function(){alert('发生错误!')} });</script>";
        }

        /// <summary>
        /// 检测权限
        /// </summary>
        private void CheckPower()
        {
            if (UserBase.CurAdmin.RoleType == 1)
            {
                return;
            }
            bool IsRead = false;

            DataTable dtUserFunCode = BLL.AUser.GetUserFunCode(UserBase.CurAdmin.Id);
            foreach (DataRow row in dtUserFunCode.Rows)
            {
                if (row["Code"].ToString().ToLower() == PageName.ToLower() && (int)row["FunType"] == (int)ModelEnum.FunType.Edit)
                {
                    IsRead = true;
                }
            }

            if (!IsRead)
            {
                if (Request.QueryString["ajax"] == "1")
                {
                    Maticsoft.Common.Ajax.WriteNoPower("没有此页面的访问权限");
                }
                else
                {
                    Response.Redirect("/adm/template/NoPower.aspx?pn=" + PageName);
                }
            }
        }

    }
}