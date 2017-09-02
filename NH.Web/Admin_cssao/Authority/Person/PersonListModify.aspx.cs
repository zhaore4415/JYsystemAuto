using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;

namespace NH.Web.adm.Person
{
    public partial class PersonModify : WebBase.Edit
    {
        DataTable dtCategory = null;
        DataTable dtNew = null;
        #region 基本信息
        protected string _errormsg = null;
        protected string _residence_provinceId;
        protected string _residence_cityId;
        protected string _currAddr_ProvinceId;
        protected string _currAddr_CityId;

        protected int _verifyStatus = 0;
        protected int _loginStatus = 0;
        protected int _resumeStatus = 0;
        protected int _newinfoVerifyStatus = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Show();
        }

        private void Show()
        {
            dtCategory = BLL.User.GetList(" ").Tables[0];
            Model.User user = BLL.User.GetModel(Id);

            #region 联系方式
            txtLoginName.Text = user.LoginName;

            txtQQ.Text = user.QQ;
            txtMobile.Text = user.Phone;
            txtEmail.Text = user.Email;
            rblSex.SelectedValue = user.Sex.ToString();
            txtAddress.Text = user.Address;
            #endregion



            TreeNode no = new TreeNode();
            no.Expanded = true;
            TreeView1.Nodes.Add(no);

            no.Text = "该经营者下级";
            CreateTree(Id.ToString(), no);
            arr.Sort();
            if (arr.Count > 0)
            {
                lbDepth.Text = arr[arr.Count - 1].ToString();//最大值得即是 有多少层级
            }
            else { lbDepth.Text = "0"; }
            lbCount.Text = count.ToString();
        }
        List<int> arr = new List<int>();
        int count = 0;
        private void CreateTree(string id1, TreeNode rootnode)
        {
            DataRow[] rows = dtCategory.Select("ParentID=" + id1, "Id");
            foreach (DataRow dr in rows)
            {
                TreeNode treenode = new TreeNode();
                treenode.Text = dr["LoginName"].ToString().Trim();
                treenode.Expanded = false;
                rootnode.ChildNodes.Add(treenode);
                string id = dr["Id"].ToString().Trim();
                arr.Add(treenode.Depth);
                count++;
                //treenode.NavigateUrl = "Bjmti_ArticleShow_List.aspx?ID=" + dr["W_ID"].ToString() + "";
                CreateTree(id, treenode);
            }

        }
        //private void GetSubCategory(string parentId)
        //{
        //    DataRow[] rows = dtCategory.Select("ParentID=" + parentId, "Sort");
        //    foreach (DataRow row in rows)
        //    {
        //        dtNew.Rows.Add(row.ItemArray);
        //        GetSubCategory(row["Id"].ToString());
        //    }
        //}
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string LoginName = txtLoginName.Text.Trim();

            //string Password = txtPassword.Text.Trim();
            //string Password2 = txtPassword2.Text.Trim();
            if (LoginName == "")
            {
                Maticsoft.Common.Ajax.WriteError("请填写联系人！");
            }
            //if (Password == "")
            //{
            //    Maticsoft.Common.Ajax.WriteError("请填写密码！");
            //}
            //if (Password2 != Password)
            //{
            //    Maticsoft.Common.Ajax.WriteError("两次输入的密码不一致！");
            //}

            //手机
            string phone = txtMobile.Text.Trim();
            if (phone == "")
            {
                Maticsoft.Common.Ajax.WriteError("请填写手机号！");
            }

            //if (phone != "")
            //{
            //    Model.User tempMember = new Model.User();
            //    tempMember.Phone = phone;
            //    if (BLL.User.Exists(tempMember))
            //    {
            //        Maticsoft.Common.Ajax.WriteError("此手机号已被使用！");
            //    }
            //}
            //性别
            int sex = int.Parse(rblSex.SelectedValue);

            //qq
            string qq = Request.Form["txtQQ"].Trim();
            //if (qq == "") { Maticsoft.Common.Ajax.WriteError("请填写QQ"); }
            //email
            string email = Request.Form["txtEmail"].Trim();
            //if (email == "") { Maticsoft.Common.Ajax.WriteError("请填写邮箱"); }
            //if (!PageValidate.IsEmail(email)) { Maticsoft.Common.Ajax.WriteError("邮箱格式不正确"); }
            //联系地址
            string address = Request.Form["txtAddress"].Trim();

            Model.User user = new Model.User();
            user.LoginName = LoginName;

            //user.Password = DESEncrypt.Encrypt(Password);

            user.UserType = 1;
            user.Sex = sex;
            user.Address = address;
            user.Phone = phone;
            user.QQ = qq;
            user.Email = email;


            user.Id = int.Parse(Request.QueryString["id"]);
            if (BLL.User.Update(user))
            {
                //写系统日志
                Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
                MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
                MyRiZhi.DoSomething = "修改客户(" + LoginName + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                BLL.ERPRiZhi.Add(MyRiZhi);
                MessageBox.ShowAndRedirect("修改成功", ListUrl);
                Show();
                //Maticsoft.Common.Ajax.WriteOk("保存成功");
                //MessageBox.ShowAndRedirect("保存成功",Urls.BaseInfo());
            }
            //else
            //{
            //    Maticsoft.Common.Ajax.WriteError("修改失败");
            //    //MessageBox.Show("修改失败");
            //}
        }

    }
}