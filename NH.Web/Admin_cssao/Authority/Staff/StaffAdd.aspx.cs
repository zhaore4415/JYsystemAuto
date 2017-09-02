using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Authority.Staff
{
    public partial class StaffAdd : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.DropDownList1.SelectedItem.Text == "未设置" || this.DropDownList2.SelectedItem.Text == "未设置" || this.DropDownList3.SelectedItem.Text == "未设置" || this.DropDownList4.SelectedItem.Text == "未设置") { MessageBox.Show("请选择打卡时间"); return; }

            string loginame = txtLoginName.Text.Trim();
      
            string realname = txtRealname.Text.Trim();
            string worknumber = txtWorkNumber.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();

            Model.Staff model = new Model.Staff();
            model.LoginName = loginame;
            //model.Password = DESEncrypt.Encrypt(password1);
            model.Realname = realname;
            model.WorkNumber = worknumber;
            model.TodayDate = Request.Form["Wdate"].Trim();
            model.Phone =phone;
            model.Email = email;
            model.Address = address;
            //model.RoleType = int.Parse(rblRoleType.SelectedValue);

            model.Data1 = this.DropDownList1.SelectedItem.Text + ":" + this.DropDownList2.SelectedItem.Text + ":00";
            model.Data2 = this.DropDownList3.SelectedItem.Text + ":" + this.DropDownList4.SelectedItem.Text + ":00";


            Model.ERPKaoQinSetting MyModel = BLL.ERPKaoQinSetting.GetModel(1);
            string GuiDingTime1 = MyModel.GuiDingTime1;
            string GuiDingTime2 = MyModel.GuiDingTime2;
            int data1 =int.Parse(this.DropDownList1.SelectedItem.Text + this.DropDownList2.SelectedItem.Text);//打卡时间
            int guidingdata1 =int.Parse(GuiDingTime1.Split(':')[0] + GuiDingTime1.Split(':')[1]);//规定时间

            int data2 = int.Parse(this.DropDownList3.SelectedItem.Text + this.DropDownList4.SelectedItem.Text);//打卡时间
            int guidingdata2 = int.Parse(GuiDingTime2.Split(':')[0] + GuiDingTime2.Split(':')[1]);//规定时间
            if (data1 > guidingdata1 )
            {
                model.DataType1 = 1;//迟到
            }
            else
            {
                model.DataType1 = 0;//正常
            }
            if (data2 < guidingdata2)
            {
                model.DataType2 = 1;//早退
            }
            else
            {
                model.DataType2 = 0;//正常
            }

            int userId = BLL.Staff.Add(model);
            //写系统日志
            Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
            MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
            MyRiZhi.DoSomething = "添加考勤(" + loginame + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            BLL.ERPRiZhi.Add(MyRiZhi);
            //if (userId > 0 && model.RoleType == 0)
            //{
            //    //添加用户角色
            //    for (int i = 0; i < chkRoles.Items.Count; i++)
            //    {
            //        if (chkRoles.Items[i].Selected)
            //        {
            //            Model.UserRole userRole = new Model.UserRole();
            //            userRole.UserId = userId;
            //            userRole.RoleId = int.Parse(chkRoles.Items[i].Value);

            //            BLL.UserRole.Add(userRole);
            //        }
            //    }

            //}
            MessageBox.ShowAndRedirect("添加成功", ListUrl);
        }
      
    }
}