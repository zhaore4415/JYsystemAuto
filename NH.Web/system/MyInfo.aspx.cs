using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;


namespace NH.Web.adm.system
{
    public partial class MyInfo : WebBase.List
    {
        string folder = "/Upload/AUserFile/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show();
            }
        }

        private void Show()
        {
            Model.AUser model = BLL.AUser.GetModel(UserBase.CurAdmin.Id);
            if (model == null) Response.Redirect(ListUrl);
            txtLoginName.Text = model.LoginName;
            //txtLoginName.AutoCompleteType
            //txtLoginName.Enabled = false;
            //txtLoginName.ReadOnly = true;
            txtRealname.Text = model.Realname;
            try
            {
                rblRoleType.SelectedValue = model.RoleType.ToString();
            }
            catch { }
            BindBuMen();
            BindRoles();

            bumen.SelectedValue = model.Department;
            zhiwei.SelectedValue = model.ZhiWei == 0 ? "员工" : "部门主管";
            ZaiGang.SelectedValue = model.ZaiGang == 0 ? "在岗" : "离职";
            Sex.SelectedValue = model.Sex == 0 ? "男" : "女";
            Wdate.Text = model.Born;
            txtMingZu.Text = model.MingZu;
            txtShenFengZheng.Text = model.ShenFengZheng;
            txtMarital.Text = model.Marital;
            txtZhenZhi.Text = model.ZhenZhi;
            txtGuanJi.Text = model.GuanJi;
            txtHuKou.Text = model.HuKou;
            txtXueLi.Text = model.XueLi;
            txtZhiCheng.Text = model.ZhiCheng;
            txtBiYeXueXiao.Text = model.BiYeXueXiao;
            txtZhuanYe.Text = model.ZhuanYe;
            GongZuoTime.Text = model.GongZuoTime;
            JiaRuTime.Text = model.JiaRuTime;
            txtEmail.Text = model.Email;
            txtShouJi.Text = model.ShouJi;
            txtJiaTingAddress.Text = model.JiaTingAddress;
            txtJiaoYu.Text = model.JiaoYu;
            txtHeTong.Text = model.HeTong;
            txtSheBao.Text = model.SheBao;
            txtNotes.Text = model.Notes;
            HyperLink1.NavigateUrl = folder + model.FuJian;
            HyperLink1.Text = model.FuJian;

            List<Model.UserRole> userRoleList = BLL.UserRole.GetModelList("UserId=" + UserBase.CurAdmin.Id.ToString());
            foreach (Model.UserRole userRole in userRoleList)
            {
                foreach (ListItem item in chkRoles.Items)
                {
                    if (item.Value == userRole.RoleId.ToString())
                    {
                        item.Selected = true;
                    }
                }
            }

          
        }
        private void BindBuMen()
        {
            bumen.DataSource = BLL.ERPBuMen.GetAllList().Tables[0];
            //bumen.DataValueField = "ID";
            bumen.DataTextField = "BuMenName";
            bumen.DataBind();
        }

        private void BindRoles()
        {
            chkRoles.DataSource = BLL.Role.GetAllList().Tables[0];
            chkRoles.DataValueField = "Id";
            chkRoles.DataTextField = "RoleName";
            chkRoles.DataBind();
        }
    }
}