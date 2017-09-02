using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using System.Collections;

namespace NH.Web.adm.Authority.BuMen
{
    public partial class BuMenInfoModify : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindRoles();
                //Model.ERPBuMen MyBuMen = new Model.ERPBuMen();
                //BLL.ERPBuMen.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
                Model.ERPBuMen MyBuMen = BLL.ERPBuMen.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
                this.TextBox1.Text = MyBuMen.BuMenName;
                this.TextBox2.Text = MyBuMen.ChargeMan;
                this.TextBox3.Text = MyBuMen.TelStr;
                this.TextBox4.Text = MyBuMen.ChuanZhen;
                this.TextBox5.Text = MyBuMen.BackInfo;
            }
            this.auser.Attributes["onclick"] = "document.getElementById('" + this.TextBox2.ClientID + "').value=this.value;";
        }
        private void BindRoles()
        {
            auser.DataSource = BLL.AUser.GetAllList().Tables[0];
            //auser.DataValueField = "Id";
            auser.DataTextField = "LoginName";
            auser.DataBind();
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (PublicMethod.IFExists("BuMenName", "ERPBuMen", 0, this.TextBox1.Text) == true)
            {
                Model.ERPBuMen MyBuMen = new Model.ERPBuMen();
                MyBuMen.ID = int.Parse(Request.QueryString["ID"].ToString());
                MyBuMen.BuMenName = this.TextBox1.Text;
                MyBuMen.ChargeMan = this.TextBox2.Text;
                MyBuMen.TelStr = this.TextBox3.Text;
                MyBuMen.ChuanZhen = this.TextBox4.Text;
                MyBuMen.BackInfo = this.TextBox5.Text;
                MyBuMen.DirID = int.Parse(Request.QueryString["DirID"].ToString());
                BLL.ERPBuMen.Update(MyBuMen);

                //写系统日志
                Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
                MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
                MyRiZhi.DoSomething = "用户修改部门信息(" + this.TextBox1.Text + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                BLL.ERPRiZhi.Add(MyRiZhi);

                MessageBox.ShowAndRedirect("部门信息修改成功！", "BuMenInfo.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=" + Request.QueryString["DirID"].ToString());
            }
            else
            {
                MessageBox.Show("该部门已经存在，请更换名称！");
            }
        }
    }
}