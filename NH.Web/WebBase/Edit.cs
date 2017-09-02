using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.WebBase
{
    public class Edit:AdminBase
    {
        public bool IsDeletePower = false;
        public bool isRecoveryPower = false;
        public bool isExportPower = false;
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            //判断权限
            CheckPower();

            //样式表和js
            CssAndScript =
@"<meta charset=""UTF-8""/>
<script type=""text/javascript"">var isDeletePower=" + IsDeletePower.ToString().ToLower() + @";</script>
<script type=""text/javascript"">var isRecoveryPower=" + isRecoveryPower.ToString().ToLower() + @";</script>
<script type=""text/javascript"">var isExportPower=" + isExportPower.ToString().ToLower() + @";</script>
             <script src=""/JS/jquery-1.7-vsdoc.js"" type =""text/javascript"" ></script>
             <script src = ""/JS/jquery-1.10.2.js"" type = ""text/javascript""></script >
             <meta name=""viewport"" content=""width =device-width, initial-scale=1.0"" />
             <link rel=""stylesheet"" href = ""/css/bootstrap.min.css"" />
            <script src=""/JS/jquery.min.js""></script>
             <script src=""/JS/bootstrap.min.js""></script>
<script src=""/Script/list.js"" type=""text/javascript""></script>
              < link rel=""stylesheet"" href=""/css/bootstrap-responsive.min.css""/>
             <link rel=""stylesheet"" href=""/css/uniform.css""/>
             <link rel=""stylesheet"" href=""/css/select2.css""/>
             <link rel=""stylesheet"" href=""/css/matrix-style.css""/>
             <link rel=""stylesheet"" href=""/css/matrix-media.css""/>
             <link href=""/font-awesome/css/font-awesome.css"" rel =""stylesheet""/>
";
//            //样式表和js
//            CssAndScript =
//@"<link href=""/Style/Admin.css"" rel=""stylesheet"" type=""text/css"" />
//<script src=""/Script/jquery-1.7.2.min.js"" type=""text/javascript""></script>
//<script type=""text/javascript"">$(document).ready(function () { $('input[type=text],input[type=password],textarea').addClass('txtCls'); }); $.ajaxSetup({ error:function(){alert('发生错误!')} });</script>";
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
                if (row["Code"].ToString().ToLower() == PageName.ToLower() && (int)row["FunType"] == (int)ModelEnum.FunType.Edit)
                {
                    IsRead = true;
                }
            }

            if (!IsRead)
            {
                //if (Request.QueryString["ajax"] == "1")
                //{
                //    Maticsoft.Common.Ajax.WriteNoPower("没有此页面的访问权限");
                //}
                //else
                //{
                //    Response.Redirect("/template/NoPower.aspx?pn=" + PageName);
                //}
            }
        }
        protected void CheckDeletePower()
        {
            //if (!IsDeletePower)
            //{
            //    Maticsoft.Common.Ajax.WriteError("没有此操作权限");
            //}
        }
       
    }
}