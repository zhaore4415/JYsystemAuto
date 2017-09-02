using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.WebBase
{
    public class List : AdminBase
    {
        public bool IsDeletePower = false;
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            //判断权限
            CheckPower();

            //样式表和js
            CssAndScript =
@"<link href=""/adm/Style/Admin.css"" rel=""stylesheet"" type=""text/css"" />
<script src=""/adm/Script/jquery-1.7.2.min.js"" type=""text/javascript""></script>
<script type=""text/javascript"">var isDeletePower=" + IsDeletePower.ToString().ToLower() + @";</script>
<script src=""/adm/Script/list.js"" type=""text/javascript""></script>
<script type=""text/javascript"">$(document).ready(function () { $('input[type=text],input[type=password],textarea').addClass('txtCls'); }); $.ajaxSetup({ error:function(){alert('发生错误!')} });</script>";
        }

        /// <summary>
        /// 列表页名称
        /// </summary>
        protected string PagePreFix
        {
            get
            {
                //return System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Path).Replace("Add.aspx","").Replace("Modify.aspx","").Replace();
                return System.IO.Path.GetFileNameWithoutExtension(System.Web.HttpContext.Current.Request.Path);
            }
        }

        /// <summary>
        /// 检测权限
        /// </summary>
        private void CheckPower()
        {
            if (UserBase.CurAdmin.RoleType == 1)
            {
                IsDeletePower = true;
                return;
            }
            bool IsRead = false;
            DataTable dtUserFunCode = BLL.AUser.GetUserFunCode(UserBase.CurAdmin.Id);
            foreach (DataRow row in dtUserFunCode.Rows)
            {
                if (row["Code"].ToString().ToLower() == PageName.ToLower() && (int)row["FunType"] == (int)ModelEnum.FunType.Query)
                {
                    IsRead = true;
                }

                if (row["Code"].ToString().ToLower() == PageName.ToLower() && (int)row["FunType"] == (int)ModelEnum.FunType.Delete)
                {
                    IsDeletePower = true;
                }
            }
            if (!IsRead)
            {
                if (Request.QueryString["ajax"] == "1")
                {
                    Maticsoft.Common.Ajax.WriteNologin("没有此页面的访问权限");
                }
                else
                {
                    //Response.Redirect("/adm/template/NoPower.aspx");
                    Server.Transfer("/adm/template/NoPower.aspx?pn=" + PageName);
                }
            }
        }

        protected void CheckDeletePower()
        {
            if (!IsDeletePower)
            {
                Maticsoft.Common.Ajax.WriteError("没有此操作权限"); 
            }
        }

    }
}