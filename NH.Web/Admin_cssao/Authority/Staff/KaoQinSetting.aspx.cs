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
    public partial class KaoQinSetting : WebBase.List
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Model.ERPKaoQinSetting MyModel = new Model.ERPKaoQinSetting();

                //BLL.ERPKaoQinSetting.GetModel(1);
                Model.ERPKaoQinSetting MyModel = BLL.ERPKaoQinSetting.GetModel(1);
                string GuiDingTime1 = MyModel.GuiDingTime1;
                this.DropDownList1.SelectedValue = GuiDingTime1.Split(':')[0];
                this.DropDownList2.SelectedValue = GuiDingTime1.Split(':')[1];
                string GuiDingTime2 = MyModel.GuiDingTime2;
                this.DropDownList3.SelectedValue = GuiDingTime2.Split(':')[0];
                this.DropDownList4.SelectedValue = GuiDingTime2.Split(':')[1];

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.ERPKaoQinSetting Model = BLL.ERPKaoQinSetting.GetModel(1);
            //Model.ID = int.Parse(ZWL.DBUtility.DbHelperSQL.GetSHSLInt("select top 1 [ID] FROM ERPKaoQinSetting"));
           
            Model.GuiDingTime1 = this.DropDownList1.SelectedItem.Text + ":" + this.DropDownList2.SelectedItem.Text + ":00";
            Model.GuiDingTime2 = this.DropDownList3.SelectedItem.Text + ":" + this.DropDownList4.SelectedItem.Text + ":00";
            if (this.DropDownList1.SelectedItem.Text == "未设置" || this.DropDownList2.SelectedItem.Text == "未设置" || this.DropDownList3.SelectedItem.Text == "未设置" || this.DropDownList4.SelectedItem.Text == "未设置") { MessageBox.Show("请选择时间"); return; }

            BLL.ERPKaoQinSetting.Update(Model);
            //Model.Update();
            //写系统日志
            Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
            MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
            MyRiZhi.DoSomething = "设置考勤（保存）";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            BLL.ERPRiZhi.Add(MyRiZhi);
            MessageBox.ShowAndRedirect("考勤时间设置成功", ListUrl);
            //ZWL.Common.MessageBox.ShowAndRedirect(this, "考勤时间设置成功！", "KaoQinSetting.aspx");
        }
    }
}