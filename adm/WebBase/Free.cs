using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NH.Web.adm.WebBase
{
    public class Free : AdminBase
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);


            //样式表和js
            CssAndScript =
@"<link href=""/adm/Style/Admin.css"" rel=""stylesheet"" type=""text/css"" />
<script src=""/adm/Script/jquery-1.7.2.min.js"" type=""text/javascript""></script>
<script type=""text/javascript"">var isDeletePower=true;</script>
<script src=""/adm/Script/list.js"" type=""text/javascript""></script>
<script type=""text/javascript"">$(document).ready(function () { $('input[type=text],input[type=password],textarea').addClass('txtCls'); });$.ajaxSetup({ error:function(){alert('发生错误!')} });</script>";
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
    }
}