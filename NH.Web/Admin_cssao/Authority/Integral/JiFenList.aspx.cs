using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.Data;
using Newtonsoft.Json;
using System.Text;


namespace NH.Web.adm.Authority.Integral
{
    public partial class JiFenList : WebBase.List
    {
        //private string UserOpenId = ""; //微信用户openid；
        protected int id, QdId;
        protected string otherSN;
        //private string code = "";
        protected string _pager;
        public string filename = "";
        WeiPay.PayModel mod=null;
        protected Model.AUser model;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["OrderSN"] != null)
                { lbotherSN.Text = otherSN = Request.QueryString["OrderSN"]; }
                else
                {
                    //lbotherSN.Text = otherSN = DateTime.Now.ToString("yyMMddHHmmssff");
                    lbotherSN.Text = otherSN = BLL.Queryorderfx.GetMaxSort().ToString();
                }
                //lbotherSN.Text = BLL.Accounting.GetMaxSort().ToString();
                //BindCategory(null, "0");
                BindList();
             
            }
            model = BLL.AUser.GetModel(UserBase.CurAdmin.Id);
        }

        private void BindList()
        {
            int pagesize = 15;
            int page = RequestHelper.GetPageIndex();
            string strWhere = "";
            if (!string.IsNullOrEmpty(Request.QueryString["key"]))
            {
                strWhere += " and p.Name like '%" + Request.QueryString["key"].Trim().Replace("'", "''") + "%'";
            }


            strWhere += " and p.VerifyStatus=0";


            DataSet ds = DataUtility.GetList("Product p left join ProCategory c on p.CategoryID=c.Id", "p.*,c.Name as CategoryName", pagesize, page, "p.Id", strWhere, "order by p.Id desc", true); //BLL.Product.GetList(pagesize, page, strWhere, "order by a.Id desc");
            rptList.DataSource = ds.Tables[0];
            rptList.DataBind();
            int count = (int)ds.Tables[1].Rows[0][0];

            _pager = new Pager(pagesize, count).Create();

            txtKey.Text = Request.QueryString["key"];

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            Response.Redirect("JiFenList.aspx?key=" + txtKey.Text.Trim() + "&sid=0&OrderSN=" + lbotherSN.Text);
            BindList();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.Product model=null;

            string strids = Request.Form["chkItem"];
            if (!string.IsNullOrEmpty(strids))
            {
                string[] ids = strids.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    //Model.Product model = new Model.Product();lo
                    model = BLL.Product.GetModel(int.Parse(ids[i]));


                    //model.Name=
                    if (Request.Form["quantity" + int.Parse(ids[i]) + ""] != null && Request.Form["totalPrice" + int.Parse(ids[i]) + ""] != null)
                    {
                        //string dfd = Request.Form["totalPrice" + int.Parse(ids[i]) + ""];
                        model.Order = int.Parse(Request.Form["quantity" + int.Parse(ids[i]) + ""]);
                        model.JiFenPrice = int.Parse(Request["totalPrice" + int.Parse(ids[i]) + ""]);


                        if (BLL.Carfx.Exists(new Model.Carfx { PId = int.Parse(ids[i]), OrderNumber = lbotherSN.Text, UId = UserBase.CurAdmin.Id }))
                        {
                            Model.Carfx modCarfx = BLL.Carfx.GetModel(new Model.Carfx { PId = int.Parse(ids[i]), OrderNumber = lbotherSN.Text, UId = UserBase.CurAdmin.Id });
                            BLL.Carfx.Update(new Model.Carfx { Id = modCarfx.Id, Num = modCarfx.Num + model.Order, JiFenPrice = modCarfx.JiFenPrice + model.JiFenPrice });
                        }
                        else
                        {
                            //添加到购物表Carfx
                            BLL.Carfx.Add(new Model.Carfx { PId = int.Parse(ids[i]), PName = model.Name, Num = model.Order, UId = UserBase.CurAdmin.Id, JiFenPrice = model.JiFenPrice, CategoryID = model.CategoryID, OrderNumber = lbotherSN.Text });
                        }

                    }

                }

            }
            else
            {
                MessageBox.Show("请至少选择一项"); return;
            }
            //设置支付数据
             mod = new WeiPay.PayModel();
             mod.OrderSN = lbotherSN.Text;//订单号
            //mod.Code = this.lblCode.Text;//授权码

            //mod.Body = model.Name;
            //mod.Attach = "buccker"; //不能有中文
            //mod.OpenId = this.lblOpenId.Text;//获取支付用户 OpenID

            //跳转到 WeiPay.aspx 页面，请设置函数中WeiPay.aspx的页面地址
             this.Response.Redirect("JiFenDetail.aspx?&OrderSN=" + mod.OrderSN);
        }
     
    }
}