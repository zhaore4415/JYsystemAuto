using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NH.Web.WebBase;
using System.Collections;

namespace NH.Web.memcached
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList al = new ArrayList();

            al.Add("115.28.1.223:11211");
            al.Add("219.234.6.97:11211");
            MemberHelper.CreateServer(al, "mc");


            MemberHelper.SetCache(al, "mc", "test", "hello word!",1);
            if (MemberHelper.CacheIsExists(al, "mc", "test"))
            {
                Response.Write("test的缓存内容为：" + MemberHelper.GetCache(al, "mc", "test").ToString());
            }
            else {
                Response.Write("无缓存");
            }
        }
    }
}