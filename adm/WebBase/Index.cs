using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NH.Web.adm.WebBase
{
    public class Index:AdminBase
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);


            //样式表和js
            CssAndScript =
@"<link href=""/adm/Style/Admin.css"" rel=""stylesheet"" type=""text/css"" />
<script src=""/adm/Script/jquery-1.7.2.min.js"" type=""text/javascript""></script>";
        }
    }
}