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
    public partial class BuMenInfo : WebBase.Edit
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
         
                DataBindToGridview();
                GetDaoHang(int.Parse(Request.QueryString["DirID"].ToString()));

                //设定按钮权限
                //ImageButton1.Visible = PublicMethod.StrIFIn("|069a|", PublicMethod.GetSessionValue("QuanXian"));
                //ImageButton5.Visible = PublicMethod.StrIFIn("|069m|", PublicMethod.GetSessionValue("QuanXian"));
                //ImageButton3.Visible = PublicMethod.StrIFIn("|069d|", PublicMethod.GetSessionValue("QuanXian"));
                //ImageButton2.Visible = PublicMethod.StrIFIn("|069e|", PublicMethod.GetSessionValue("QuanXian"));

                //判断是否属于查询模块
                try
                {
                    string SerchTypeStr = Request.QueryString["Type"].ToString();
                    if (SerchTypeStr.Trim().Length > 0)
                    {
                        this.ImageButton1.Visible = false;
                        this.ImageButton2.Visible = false;
                        //this.ImageButton3.Visible = false;
                        //this.ImageButton5.Visible = false;
                    }
                }
                catch
                { }
            }
        }

        public void GetDaoHang(int DirID)
        {
            if (DirID == 0)
            {
                if (this.Label1.Text.Trim() == "")
                {
                    this.Label1.Text = "<a href=\"BuMenInfo.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=0\" >部门信息管理</a>";
                }
                else
                {
                    this.Label1.Text = "<a href=\"BuMenInfo.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=0\" >部门信息管理</a>" + "\\" + this.Label1.Text;
                }
            }
            else
            {
                if (this.Label1.Text.Trim() == "")
                {
                    this.Label1.Text = "<a href=\"BuMenInfo.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=" + DirID.ToString() + "\" >" + DbHelperSQL.Query("select BuMenName from ERPBuMen where ID=" + DirID.ToString()) + "</a>";
                }
                else
                {
                    this.Label1.Text = "<a href=\"BuMenInfo.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=" + DirID.ToString() + "\" >" + DbHelperSQL.Query("select BuMenName from ERPBuMen where ID=" + DirID.ToString()) + "</a>" + "\\" + this.Label1.Text;
                }
                int FatherID = DbHelperSQL.ExecuteSql("select DirID from ERPBuMen where ID=" + DirID.ToString());
                if (FatherID == 0)
                {
                    this.Label1.Text = this.Label1.Text = "<a href=\"BuMenInfo.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=0\" >部门信息管理</a>" + "\\" + this.Label1.Text;
                }
                else
                {
                    GetDaoHang(FatherID);
                }
            }
        }
        public void DataBindToGridview()
        {
            //ZWL.BLL.ERPBuMen MyERPBuMen = new ZWL.BLL.ERPBuMen();
            //Model.ERPBuMen MyERPBuMen = new Model.ERPBuMen();
            string DirID = "0";
            try
            {
                DirID = Request.QueryString["DirID"].ToString();
            }
            catch { }


            GVData.DataSource = BLL.ERPBuMen.GetList("DirID=" + DirID + " and BuMenName Like '%" + this.TextBox1.Text + "%' order by ID desc");
            GVData.DataBind();
            LabPageSum.Text = Convert.ToString(GVData.PageCount);
            LabCurrentPage.Text = Convert.ToString(((int)GVData.PageIndex + 1));
            this.GoPage.Text = LabCurrentPage.Text.ToString();
        }
        #region  分页方法
        protected void ButtonGo_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (GoPage.Text.Trim().ToString() == "")
                {
                    Response.Write("<script language='javascript'>alert('页码不可以为空!');</script>");
                }
                else if (GoPage.Text.Trim().ToString() == "0" || Convert.ToInt32(GoPage.Text.Trim().ToString()) > GVData.PageCount)
                {
                    Response.Write("<script language='javascript'>alert('页码不是一个有效值!');</script>");
                }
                else if (GoPage.Text.Trim() != "")
                {
                    int PageI = Int32.Parse(GoPage.Text.Trim()) - 1;
                    if (PageI >= 0 && PageI < (GVData.PageCount))
                    {
                        GVData.PageIndex = PageI;
                    }
                }

                if (TxtPageSize.Text.Trim().ToString() == "")
                {
                    Response.Write("<script language='javascript'>alert('每页显示行数不可以为空!');</script>");
                }
                else if (TxtPageSize.Text.Trim().ToString() == "0")
                {
                    Response.Write("<script language='javascript'>alert('每页显示行数不是一个有效值!');</script>");
                }
                else if (TxtPageSize.Text.Trim() != "")
                {
                    try
                    {
                        int MyPageSize = int.Parse(TxtPageSize.Text.ToString().Trim());
                        this.GVData.PageSize = MyPageSize;
                    }
                    catch
                    {
                        Response.Write("<script language='javascript'>alert('每页显示行数不是一个有效值!');</script>");
                    }
                }

                DataBindToGridview();
            }
            catch
            {
                DataBindToGridview();
                Response.Write("<script language='javascript'>alert('请输入有效数字！');</script>");
            }
        }
        protected void PagerButtonClick(object sender, ImageClickEventArgs e)
        {
            //获得Button的参数值
            string arg = ((ImageButton)sender).CommandName.ToString();
            switch (arg)
            {
                case ("Next"):
                    if (this.GVData.PageIndex < (GVData.PageCount - 1))
                        GVData.PageIndex++;
                    break;
                case ("Pre"):
                    if (GVData.PageIndex > 0)
                        GVData.PageIndex--;
                    break;
                case ("Last"):
                    try
                    {
                        GVData.PageIndex = (GVData.PageCount - 1);
                    }
                    catch
                    {
                        GVData.PageIndex = 0;
                    }

                    break;
                default:
                    //本页值
                    GVData.PageIndex = 0;
                    break;
            }
            DataBindToGridview();
        }
        #endregion
        protected void GVData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            PublicMethod.GridViewRowDataBound(e);
        }
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            DataBindToGridview();
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("BuMenInfoAdd.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=" + Request.QueryString["DirID"].ToString());
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!IsDeletePower)
            {
                MessageBox.Show("没有删除权限"); return;
            }
            string strids = Request.Form["chkItem"];
            if (!string.IsNullOrEmpty(strids))
            {
                string[] ids = strids.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    BLL.ERPBuMen.Delete(int.Parse(ids[i]));
               
                }
            }
            //Response.Redirect(Request.RawUrl);
            DataBindToGridview();
            //写系统日志
            Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
            MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
            MyRiZhi.DoSomething = "用户删除部门信息";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            BLL.ERPRiZhi.Add(MyRiZhi);
            //string IDlist = PublicMethod.CheckCbx(this.GVData, "chkItem", "LabVisible");
            //if (DbHelperSQL.ExecuteSql("delete from ERPBuMen where ID in (" + IDlist + ")") == -1)
            //{
            //    Response.Write("<script>alert('删除选中记录时发生错误！请重新登陆后重试！');</script>");
            //}
            //else
            //{
            //    DataBindToGridview();
        
            //}
        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            string IDList = "0";
            for (int i = 0; i < GVData.Rows.Count; i++)
            {
                Label LabVis = (Label)GVData.Rows[i].FindControl("LabVisible");
                IDList = IDList + "," + LabVis.Text.ToString();
            }
            Hashtable MyTable = new Hashtable();
            MyTable.Add("BuMenName", "部门名称");
            MyTable.Add("ChargeMan", "部门主管");
            MyTable.Add("TelStr", "联系电话");
            MyTable.Add("ChuanZhen", "传真号码");
            MyTable.Add("BackInfo", "备注信息");
            DataToExcel.GridViewToExcel(DbHelperSQL.Query("select BuMenName,ChargeMan,TelStr,ChuanZhen,BackInfo from ERPBuMen where ID in (" + IDList + ") order by ID desc"), MyTable, "Excel报表");
        }
        //protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        //{
        //    string CheckStr = PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        //    string[] CheckStrArray = CheckStr.Split(',');
        //    Response.Redirect("BuMenInfoModify.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=" + Request.QueryString["DirID"].ToString() + "&ID=" + CheckStrArray[0].ToString());
        //}
    }
}