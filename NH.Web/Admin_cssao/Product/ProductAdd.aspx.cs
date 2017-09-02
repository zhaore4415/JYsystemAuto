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
    public partial class ProductAdd : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategory(null, "0");
                
                lbpid.Text = DateTime.Now.ToString("yyyyMMddHHhmmssf");
                //this.ckContent.ImageGalleryPath = "~/Upload/";
                txtBarcode.Text = DateTime.Now.ToString("MddHHhmsff");
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
            //if (txtPrice.Text.Trim() == "")
            //{
            //    MessageBox.Show("请填写商品价格"); return;
            //}
            if (!PageValidate.IsNumber(txtRuKuSum.Text.Trim()) || !PageValidate.IsNumber(txtChuKuSum.Text.Trim()) || !PageValidate.IsNumber(txtNowKuCun.Text.Trim())) 
            { MessageBox.Show("数量格式不正确"); return; }
            if (!PageValidate.IsDecimal(txtChengBen.Text.Trim()) || !PageValidate.IsDecimal(txtChuShou.Text.Trim()))
            {
                MessageBox.Show("商品价格格式不正确"); return;
            }
            //if (!file.HasFile)
            //{
            //    MessageBox.Show("请上传产品缩略图片"); return;
            //}
            //if (!ImageHelper.IsWebImage(file.PostedFile.ContentType))
            //{
            //    MessageBox.Show("商品图片格式错误"); return;
            //}
          

         
            string filename = DateTime.Now.ToString("yyyyMMddHHhmmssf") + Path.GetExtension(file.PostedFile.FileName);
            //string filenamesmall = "hwchen_" + DateTime.Now.ToString("yyyyMMddHHhmmssf") + Path.GetExtension(file.PostedFile.FileName);
            Model.Product model = new Model.Product();
            model.Name = txtName.Text;
            model.Barcode = txtBarcode.Text.Trim();
            model.Model = txtModel.Text;
            model.ChengBen =decimal.Parse(txtChengBen.Text.Trim());
            model.ChuShou = decimal.Parse(txtChuShou.Text.Trim());
            model.JiFenPrice = int.Parse(txtJiFenPrice.Text.Trim());
            model.KeJiFen = int.Parse(txtKeJiFen.Text.Trim());
            model.RuKuSum = int.Parse(txtRuKuSum.Text.Trim());
            model.ChuKuSum = int.Parse(txtChuKuSum.Text.Trim());
            model.NowKuCun = int.Parse(txtNowKuCun.Text.Trim());
            model.Pic = filename;
            //model.SmallPic = filenamesmall;
            Model.ProCategory category = BLL.ProCategory.GetModel(int.Parse(ddlCategory.SelectedValue));
            model.CategoryID = category.ID;
            model.CategoryPath = category.Path + category.ID + ",";
           
            model.Description = ckContent.Text;
          
            model.ViewCount = 0;
            model.AddTime = DateTime.Now;
        

            if (BLL.Product.Add(model)>0)
            { //写系统日志
                Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
                MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
                MyRiZhi.DoSomething = "添加商品(" + txtName.Text.Trim() + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                BLL.ERPRiZhi.Add(MyRiZhi);
                string folder = Server.MapPath("/Upload/ProductImg/");
                if (file.HasFile)
                {
                  
                    //string fileName_s = "avatus_" + DateTime.Now.ToString("yyyyMMddHHmmsss") + Path.GetExtension(FileUpload1.FileName);                                // 缩略图文件名称
                    //string folder_s = Server.MapPath("/Upload/ProductSmallImg/");　　// 服务器端缩略图路径

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    file.SaveAs(folder + filename);

                    //if (!Directory.Exists(folder_s)) {
                    //    Directory.CreateDirectory(folder_s);
                    //}
                    //Maticsoft.Common.ImageHelper.ZoomAuto(folder + filename, folder_s + filenamesmall, 110, 90, "", "");//创建小图
                }
            
          
                MessageBox.ShowAndRedirect("添加成功", "Product.aspx?sid=0"); return;
            }
            else
            {
                MessageBox.Show("添加失败"); return;
            }
        }

        protected void bnBarcode_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = DateTime.Now.ToString("MddHHhmsff");
        }
       
    }
}