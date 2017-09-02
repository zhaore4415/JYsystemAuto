using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Maticsoft.Common;

namespace NH.Web.adm.Product
{
    public partial class ProductModify : WebBase.Edit
    {
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Request.QueryString["id"]);

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["delimg"]))
                {
                    DeleteImg();

                    Response.Redirect("ProductModify.aspx?id=" + id);
                }

                BindCategory(null, "0");
                Show();

            }
        }
        private void DeleteImg()
        {

            string name = Request.QueryString["delimg"];
            string path = Server.MapPath("/upload/productimg/" + name);
            string[] imgs = BLL.Product.GetModel(id).Imgs.Split(',');
            List<string> newImgs = new List<string>();
            for (int i = 0; i < imgs.Length; i++)
            {
                if (name.ToLower() != imgs[i].ToLower())
                {
                    newImgs.Add(imgs[i]);
                }
            }
            Model.Product model = new Model.Product();
            model.Id = id;
            model.Imgs = string.Join(",", newImgs.ToArray());
            BLL.Product.Update(model);

            if (File.Exists(path))
            {
                File.Delete(path);
            }

        }

        private void BindCategory(DataTable dt, string parentId)
        {
            if (dt == null)
            {
                dt = BLL.ProCategory.GetList("").Tables[0];
            }
            DataRow[] rows = dt.Select("ParentID=" + parentId, "Sort");
            foreach (DataRow row in rows)
            {
                ddlCategory.Items.Add(new ListItem("├".PadLeft((int)row["Depth"], '　') + "　" + row["Name"].ToString(), row["Id"].ToString()));
                BindCategory(dt, row["Id"].ToString());
            }
        }

        private void Show()
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"])) return;
            Model.Product model = BLL.Product.GetModel(int.Parse(Request.QueryString["id"]));
            if (model == null) return;
            try
            {
                ddlCategory.SelectedValue = model.CategoryID.ToString();
            }
            catch { }
            txtName.Text = model.Name;
            txtBarcode.Text = model.Barcode;
            txtModel.Text = model.Model;
            txtChengBen.Text = model.ChengBen.Value.ToString("#0.00");
            txtChuShou.Text = model.ChuShou.Value.ToString("#0.00");
            txtJiFenPrice.Text = model.JiFenPrice.ToString();
            txtKeJiFen.Text = model.KeJiFen.ToString();
            txtRuKuSum.Text = model.RuKuSum.ToString();
            txtChuKuSum.Text = model.ChuKuSum.ToString();
            txtNowKuCun.Text = model.NowKuCun.ToString();
            //if (lbpid.Text == "")
            //{ lbpid.Text = DateTime.Now.ToString("yyyyMMddHHhmmssf"); }
            //else
            //{  }
            //txtPrice.Text = model.Price.Value.ToString();
            ckContent.Text = model.Description;
            img.ImageUrl = "/Upload/ProductImg/" + model.Pic;

           


            //txtSpace.Text = model.Space;


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "0")
            {
                MessageBox.Show("请选择商品分类"); return;
            }
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请填写商品名称"); return;
            }
            if (!PageValidate.IsNumber(txtRuKuSum.Text.Trim()) || !PageValidate.IsNumber(txtChuKuSum.Text.Trim()) || !PageValidate.IsNumber(txtNowKuCun.Text.Trim()))
            { MessageBox.Show("数量格式不正确"); return; }
            if (!PageValidate.IsDecimal(txtChengBen.Text.Trim()) || !PageValidate.IsDecimal(txtChuShou.Text.Trim()))
            {
                MessageBox.Show("商品价格格式不正确"); return;
            }
            string filename = null;
            if (file.HasFile)
            {
                if (!ImageHelper.IsWebImage(file.PostedFile.ContentType))
                {
                    MessageBox.Show("商品图片格式错误"); return;
                }
                filename = DateTime.Now.ToString("yyyyMMddHHhmmssf") + Path.GetExtension(file.PostedFile.FileName);
            }
         


            //string filenamesmall = "hwchen_" + DateTime.Now.ToString("yyyyMMddHHhmmssf") + Path.GetExtension(file.PostedFile.FileName);
            Model.Product model = new Model.Product();
            model.Name = txtName.Text;
            model.Barcode = txtBarcode.Text.Trim();
            model.Model = txtModel.Text;
            model.ChengBen = decimal.Parse(txtChengBen.Text.Trim());
            model.ChuShou = decimal.Parse(txtChuShou.Text.Trim());
            model.JiFenPrice = int.Parse(txtJiFenPrice.Text.Trim());
            model.KeJiFen = int.Parse(txtKeJiFen.Text.Trim());
            model.RuKuSum = int.Parse(txtRuKuSum.Text.Trim());
            model.ChuKuSum = int.Parse(txtChuKuSum.Text.Trim());
            model.NowKuCun = int.Parse(txtNowKuCun.Text.Trim());
            model.Pic = filename;
            //model.SmallPic = lbsmalimg.Text;
            Model.ProCategory category = BLL.ProCategory.GetModel(int.Parse(ddlCategory.SelectedValue));
            model.CategoryID = category.ID;
            model.CategoryPath = category.Path + category.ID + ",";
            //model.Price = decimal.Parse(txtPrice.Text.Trim());
            model.Description = ckContent.Text;

        

            //model.Space = txtSpace.Text.Trim();


            model.Id = int.Parse(Request.QueryString["id"]);
            if (BLL.Product.Update(model))
            { 
                //写系统日志
                Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
                MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
                MyRiZhi.DoSomething = "修改商品(" + txtName.Text.Trim() + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                BLL.ERPRiZhi.Add(MyRiZhi);
                string folder = Server.MapPath("/Upload/ProductImg/");
                if (file.HasFile)
                {
                    //string folder_s = Server.MapPath("/Upload/ProductSmallImg/");　　// 服务器端缩略图路径
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    file.SaveAs(folder + filename);

                    //if (!Directory.Exists(folder_s))
                    //{
                    //    Directory.CreateDirectory(folder_s);
                    //}
                    //Maticsoft.Common.ImageHelper.ZoomAuto(folder + filename, folder_s + filenamesmall, 110, 90, "", "");//创建小图

                }
             

                MessageBox.ShowAndRedirect("修改成功", "Product.aspx?sid=0"); return;
            }
            else
            {
                MessageBox.Show("修改失败"); return;
            }
        }
        protected void bnBarcode_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = DateTime.Now.ToString("MddHHhmsff");
        }
    }
}