using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;
using Maticsoft.Common;
using System.Net;
using System.Text;
using System.IO;

namespace NH.Web.adm.Authority.Integral
{
    public partial class JiFenDetail : WebBase.List
    {
        public static int uid = 0;
        public static long order = 0;
        //支付相关参数 ，以下参数请从需要支付的页面通过get方式传递过来
        protected long OrderSN = 0; //商户自己订单号
        //protected string Code = "";     //微信端传来的code
        protected string goodstag = "";
        protected string Attach = "buccker"; //用户自定义参数，原样返回
        protected string UserOpenId = "";//微信用户openid

        protected int nums;
        protected string Pid, Names;
        protected int sums;
        protected Model.AUser model;
        public Model.Queryorderfx mod;
        protected int aaa;
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageBox.ShowConfirm(btnSelect, "确认兑换吗？");
            //form1.Target = "_blank";
            if (!IsPostBack)
            {
                if (Request.QueryString["OrderSN"] != null)
                {
                    this.OrderSN = long.Parse(Request.QueryString["OrderSN"]);
                    order = this.OrderSN;
                }

                BindList();

                Bindxinxi();
            }
            BindSSQ();
        }

        //调用购物表信息
        private void BindList()
        {
            int pagesize = 50;
            int page = RequestHelper.GetPageIndex();
            string strWhere = " and c.UId=" + UserBase.CurAdmin.Id + "";
            if (Request.QueryString["OrderSN"] != null)
            {
                strWhere += " and c.OrderNumber=" + Request.QueryString["OrderSN"];
            }
            //DataSet ds = BLL.Carfx.GetList(strWhere);

            //rptList.DataSource = ds.Tables[0];
            //rptList.DataBind();
            DataSet ds = DataUtility.GetList(" Carfx c left join Product p on p.Id=c.PId", "p.Name,p.JiFenPrice,p.KeJiFen,c.ID,c.PId,c.CategoryID,c.Num", pagesize, page, "c.ID", strWhere, "order by c.ID desc", true); //BLL.Product.GetList(pagesize, page, strWhere, "order by a.Id desc");
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();

            if (rptList.Items.Count > 0)
            {
                nums = BLL.Carfx.GetNums(UserBase.CurAdmin.Id.ToString(), order);
                sums = BLL.Carfx.GetSums(UserBase.CurAdmin.Id.ToString(), order);
            }
            else
            {
                nums = 0; sums = 0;
                if (rptList.Items.Count <= 0)
                {
                    MessageBox.ShowAndRedirect("购物车不能为空", "JiFenList.aspx?OrderSN=" + Request.QueryString["OrderSN"]);
                    //Response.Redirect("Product.aspx?sid=0");
                }
            }


        }
        private void Bindxinxi()
        {
            mod = BLL.Queryorderfx.GetModel(new Model.Queryorderfx { OrderNumber = order });
            if (mod != null)
            {
                txtName.Text = mod.Realname;
                txtPhone.Text = mod.Tel;
                txtJiaTingAddress.Text = mod.Address;
                txtDetail.Text = mod.Remark;
            }
        }
        //调用订单表的省市区
        private void BindSSQ()
        {
            //Model.Queryorderfx mod = new Model.Queryorderfx();
            mod = BLL.Queryorderfx.GetModel(new Model.Queryorderfx { OrderNumber = order });
            model = BLL.AUser.GetModel(UserBase.CurAdmin.Id);
            if (mod != null)
            {
                ddlBranchOne.SelectedValue = mod.province.ToString();
                ddlBranchTwo.SelectedValue = mod.city.ToString();
                ddlBranchThird.SelectedValue = mod.area.ToString();

            }
            else
            {
                if (model != null)
                {
                    //当为空就调用 用户 的信息
                    mod = new Model.Queryorderfx();
                    mod.province = model.fk_id;
                    aaa = model.fk_id.Value;
                    mod.city = model.sk_id;
                    mod.area = model.tk_id;
                    if (!IsPostBack)
                    {
                        txtName.Text = model.LoginName;
                        txtPhone.Text = model.ShouJi;
                        txtJiaTingAddress.Text = model.JiaTingAddress;
                    }
                    //txtDetail.Text = model.Remark;
                }
            }
            uid = model.Id;
        }
        protected string CategoryName(int CategoryID)
        {
            Model.ProCategory model = BLL.ProCategory.GetModel(CategoryID);
            return model.Name;
        }


        //删除勾选购物表
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            string strids = Request.Form["chkItem"];
            if (!string.IsNullOrEmpty(strids))
            {
                string[] ids = strids.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    Model.Carfx model = BLL.Carfx.GetModel(int.Parse(ids[i]));
                    if (model != null)
                    {

                        BLL.Carfx.Delete(model.Id);


                    }
                }
            }
            BindList();
            if (rptList.Items.Count <= 0)
            {
                MessageBox.ShowAndRedirect("购物车为空", "JiFenList.aspx?OrderSN=" + Request.QueryString["OrderSN"]);
                //Response.Redirect("Product.aspx?sid=0&OrderSN=" + Request.QueryString["OrderSN"]);
            }
            Response.Redirect(Request.RawUrl);

        }
        //private void JiFenDH()
        //{ }
        //添加到订单表
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            if (UserBase.CurAdmin.VerifyStatus != 1)
            {
                MessageBox.Show("请先提交审核资料，等待通过！");
            }
            if (rptList.Items.Count <= 0)
            {

                //MessageBox.Show("请先选购商品"); 
                Response.Redirect("JiFenList.aspx");
            }
            BindList();
            BindSSQ();

            int sum = 0;
            Model.AUser mod = BLL.AUser.GetModel(UserBase.CurAdmin.Id);
            if ((mod.JeFen - sums) < 0)
            {
                MessageBox.Show("积分不够！"); return;
            }

            sum = mod.JeFen.Value - sums;

            //调用刷卡支付,如果内部出现异常则在页面上显示异常原因
            if (Request.QueryString["OrderSN"] != null)
            {
                this.OrderSN = long.Parse(Request.QueryString["OrderSN"]);
            }
            Model.Queryorderfx model = new Model.Queryorderfx();
            model.OrderNumber = this.OrderSN;
            model.Realname = this.txtName.Text;
            model.Tel = this.txtPhone.Text;
            Attach = "buccker";
            model.Remark = txtDetail.Text;
            model.province = int.Parse(Request.Form.Get("ddlBranchOne"));
            model.city = int.Parse(Request.Form.Get("ddlBranchTwo"));
            model.area = int.Parse(Request.Form.Get("ddlBranchThird"));
            model.Address = this.txtJiaTingAddress.Text;//发货地址

            //model.QdId = long.Parse(this.qdid);//订单表与订单的多个对应产品的共有id
            //model.TypeO2O = "在线兑换";

            //model.Couriercompanies = this.pname;//产品名称

            model.Babynumber = this.nums;//订购数量

            model.Amount = decimal.Parse(this.sums.ToString());//支付积分

            //model.Status = "0";
            model.U_ID = UserBase.CurAdmin.Id;
            //string sss=  model.Pid.Split(',').ToString();
            string strids = Request.Form["chkItem"];
            string account = "";
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                account += ((Label)rptList.Items[i].FindControl("lbID")).Text + ",";

            }
            if (strids != account.TrimEnd(',')) { MessageBox.Show("请全选或者移除不需要的项"); return; }
            if (!string.IsNullOrEmpty(strids))
            {
                string[] ids = strids.Split(',');

                for (int i = 0; i < ids.Length; i++)
                {
                    Model.Carfx modCarfx = BLL.Carfx.GetModel(int.Parse(ids[i]));
                    if (model != null)
                    {

                        Pid += modCarfx.PId + ",";
                        Names += modCarfx.PName + ",";
                        goodstag += modCarfx.PId;
                    }
                }
            }
            else
            {
                MessageBox.Show("请至少选择一项"); return;
            }
            model.Pid = Pid.TrimEnd(',');
            model.AddTime = DateTime.Now;
            model.Status = "1";

            //判断是否存在该订单
            if (!BLL.Queryorderfx.ExistsOrder(model.OrderNumber.Value))
            {
                //添加到订单表，状态为1
                BLL.Queryorderfx.Add(model);

                //当形成订单时购物车该订单号的状态更新为2，默认为0
                BLL.Carfx.UpdateOrder(new Model.Carfx { OrderNumber = model.OrderNumber.ToString(), Status = "2" });

                //更新用户积分
                BLL.AUser.Update(new Model.AUser { Id = UserBase.CurAdmin.Id, JeFen = sum });

                MessageBox.ShowAndRedirect("积分兑换成功！", "Queryorderfx.aspx");
            }
            else
            {
                MessageBox.Show("订单已存在，不要重复下单！"); return;
            }
            //else
            //{
            //    BLL.Queryorderfx.UpdateOrder(new Model.Queryorderfx { OrderNumber = model.OrderNumber, Realname = model.Realname, Tel = model.Tel, province = model.province, city = model.city, area = model.area, Address = model.Address, Remark = model.Remark });
            //}



        }
    }

}