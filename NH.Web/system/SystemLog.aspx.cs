using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.Collections;
using Maticsoft.DBUtility;

namespace NH.Web.adm.system
{
    public partial class SystemLog : WebBase.List
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //PublicMethod.CheckSession();
                DataBindToGridview();

                ////设定按钮权限
                //ImageButton3.Visible = PublicMethod.StrIFIn("|072d|", PublicMethod.GetSessionValue("QuanXian"));
                //ImageButton2.Visible = PublicMethod.StrIFIn("|072e|", PublicMethod.GetSessionValue("QuanXian"));
            }
        }
        public void DataBindToGridview()
        {
       
            Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
            GVData.DataSource = BLL.ERPRiZhi.GetList("UserName like '%" + this.TextBox2.Text.Trim() + "%' and DoSomething like '%" + this.TextBox1.Text.Trim() + "%' order by ID desc");
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
                    //if (int.Parse(ids[i]) == UserBase.CurAdmin.Id) return;
                    BLL.ERPRiZhi.Delete(int.Parse(ids[i]));
                 
                }
            }
            DataBindToGridview();
            //string IDlist = PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
            //if (DbHelperSQL.ExecuteSql("delete from ERPRiZhi where ID in (" + IDlist + ")") == -1)
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
            MyTable.Add("UserName", "用户名");
            MyTable.Add("TimeStr", "日志时间");
            MyTable.Add("DoSomething", "日志内容");
            MyTable.Add("IpStr", "IP地址");
            DataToExcel.GridViewToExcel(DbHelperSQL.Query("select UserName,TimeStr,DoSomething,IpStr from ERPRiZhi where ID in (" + IDList + ") order by ID desc"), MyTable, "Excel报表");
        }
    }
}