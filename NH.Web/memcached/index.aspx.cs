using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace NH.Web.memcached
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList al = new ArrayList();

            al.Add("115.28.1.223:11211");
            MemberHelper.CreateServer(al, "mc");


            MemberHelper.AddCache(al, "mc", "test", "hello word!", 1);
            Response.Write("test的缓存内容为：" + MemberHelper.GetCache(al, "mc", "test").ToString());
        }
    }
}