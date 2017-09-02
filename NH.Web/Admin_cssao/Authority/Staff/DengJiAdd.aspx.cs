using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace NH.Web.adm.Authority.Staff
{
    public partial class DengJiAdd : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindBuMen(); Bindauser(); 
            }
           
        }
        private void BindBuMen()
        {
            bumen.DataSource = BLL.ERPBuMen.GetAllList().Tables[0];
            //bumen.DataValueField = "ID";
            bumen.DataTextField = "BuMenName";
            bumen.DataBind();
        }
        private void Bindauser()
        {
            auser.DataSource = BLL.AUser.GetAllList().Tables[0];
            auser.DataValueField = "LoginName";
            auser.DataTextField = "LoginName";
            auser.DataBind();
            this.auser.Attributes["onclick"] = "document.getElementById('" + this.TextBox1.ClientID + "').value=this.value;";
        }
        protected void bumen_SelectedIndexChanged(object sender, EventArgs e)
        {
            auser.DataSource = BLL.AUser.GetList(" Department='" + bumen.SelectedValue + "'").Tables[0];
            //auser.DataValueField = "LoginName";
            auser.DataTextField = "LoginName";
            auser.DataBind();
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Model.ERPDengJi Model = new Model.ERPDengJi();
            //BLL.ERPDengJi Model = new BLL.ERPDengJi();
            Model.UserName = UserBase.CurAdmin.LoginName;
            Model.ShenPiRen = this.TextBox1.Text;
            Model.ShenQingTime = DateTime.Now;
            Model.BackInfo = this.TextBox2.Text;
            Model.StartTime = DateTime.Parse(this.Request.Form["Wdate"].Trim() + " " + this.DropDownList1.SelectedItem.Text + ":" + this.DropDownList2.SelectedItem.Text + ":00");
            Model.EndTime = DateTime.Parse(this.Request.Form["Wdate2"].Trim() + " " + this.DropDownList3.SelectedItem.Text + ":" + this.DropDownList4.SelectedItem.Text + ":00");
            Model.StateNow = "待批";
            Model.TypeName = Request.QueryString["TypeName"].ToString();

            BLL.ERPDengJi.Add(Model);

            //写系统日志
            Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
            MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
            MyRiZhi.DoSomething = "用户添加考勤登记信息(" + this.TextBox2.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            BLL.ERPRiZhi.Add(MyRiZhi);

           MessageBox.ShowAndRedirect("考勤登记信息添加成功！", "DengJi.aspx?TypeName=" + Request.QueryString["TypeName"].ToString());
        }

       
    }
}