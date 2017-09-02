using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using System.Collections;

namespace NH.Web.Controls
{
    public partial class OnlineUsers : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //刷新当前用户的激活时间
            DbHelperSQL.ExecuteSql("update AUser set AddTime=getdate() where LoginName='" + UserBase.CurAdmin.LoginName + "'");
            this.HyperLink1.Text = DbHelperSQL.GetSHSL("select count(*) from AUser where datediff(minute,AddTime,getdate())<10");
        }
    }
}