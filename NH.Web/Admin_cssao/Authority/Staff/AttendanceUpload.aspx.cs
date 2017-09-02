using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Maticsoft.Common;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace NH.Web.adm.Authority.Staff
{
    public partial class ExportUpload : WebBase.List
    {
        public string message = "";
        protected string _type, name, extension,times;
        public DataTable dtCode = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HyperLink1.NavigateUrl = "/Upload/AttendanceUpload/AttendanceUpload.zip";

                times = DateTime.Now.ToString("yyyy:MM:dd");
                this.DropDownList1.SelectedValue = times.Split(':')[0];
                this.DropDownList2.SelectedValue = times.Split(':')[1];
            }
        }

        public bool IsCanUpload(out string path)
        {
            path = "";
            string fileName = null;
            if (!file.HasFile)
            {
                return false;
            }
            fileName = file.PostedFile.FileName;
            FileInfo fi = new FileInfo(fileName);
             name = fi.Name;
             extension = fi.Extension.ToLower();
            if (".xls" != extension && ".xlsx" != extension && ".csv"!=extension)
            {
                return false;
            }
            path = Server.MapPath("/Upload/AttendanceUpload/") + name;
           
            file.SaveAs(path);
            return true;
        }

        public DataSet ReadExcel(string path)
        {
            DataSet ds = new DataSet();
            string strConn = string.Format(
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", path);
            OleDbConnection connection = new OleDbConnection(strConn);
            connection.Open();
            

            DataTable datatable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string tableName = datatable.Rows[0]["TABLE_NAME"].ToString();
            OleDbDataAdapter adapter = new OleDbDataAdapter(string.Format("select * from [{0}]", tableName), connection);
            adapter.Fill(ds);

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            File.Delete(path);
            return ds;
        }
        public DataSet Readcsv(string path)
        {
            DataSet ds = new DataSet();
            string strConn = string.Format(
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"text;HDR=YES;FMT=Delimited\"", Directory.GetParent(path));//检索指定路径的父目录，包括绝对路径和相对路径。
            //Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='text;HDR=YES;FMT=Delimited;'
            ////HDR=No代表没有列名
            OleDbConnection connection = new OleDbConnection(strConn);
            connection.Open();


            DataTable datatable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string tableName = datatable.Rows[0]["TABLE_NAME"].ToString();
            OleDbDataAdapter adapter = new OleDbDataAdapter(string.Format("select * from [{0}]", tableName), connection);
            adapter.Fill(ds);

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            File.Delete(path);
            return ds;
        }
        public string AddAttendance(DataSet ds)
        {
            int i = 0, j = 0;
            //DataSet ds = ds.Tables[0];
            //产品名称	所属分类ID	产品型号	详细介绍	图片名称	多图(用英文逗号隔开)
            //DataRow[] drCode = null;
            if (ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script>alert('Excel表为空表,无数据!')</script>");   //当Excel表为空时,对用户进行提示
                return "";
            }
            else
            {

                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Model.Staff model = new Model.Staff();

                    for (j = 2; j < ds.Tables[0].Columns.Count; j++)
                    {
                        if (i % 2 == 0)
                        {
                            model.WorkNumber = ds.Tables[0].Rows[i]["工号"].ToString();
                            model.Realname = ds.Tables[0].Rows[i]["姓名"].ToString();

                            //model.Data1 = DateTime.Parse(ds.Tables[0].Rows[i][j].ToString()).ToString("hh:mm:ss");
                            //model.Data2 = DateTime.Parse(ds.Tables[0].Rows[i + 1][j].ToString()).ToString("hh:mm:ss");
                            model.Data1 = ds.Tables[0].Rows[i][j].ToString();
                            model.Data2 = ds.Tables[0].Rows[i + 1][j].ToString();//时间格式转普通格式前面加小逗号
                            model.TodayDate = this.DropDownList1.SelectedValue + "-" + this.DropDownList2.SelectedValue + "-" + (j-1).ToString().PadLeft(2, '0');
                            BLL.Staff.Add(model);
                        }
                     
                    }
                 
                }
                if (message == "")
                {
                    //写系统日志
                    Model.ERPRiZhi MyRiZhi = new Model.ERPRiZhi();
                    MyRiZhi.UserName = UserBase.CurAdmin.LoginName;
                    MyRiZhi.DoSomething = "批量上传考勤";
                    MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                    BLL.ERPRiZhi.Add(MyRiZhi);
                    MessageBox.ShowAndRedirect("上传成功", "Staff.aspx");
                }
            }
            return message;
        }
    

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (this.DropDownList1.SelectedItem.Text == "未设置" || this.DropDownList2.SelectedItem.Text == "未设置" ) { MessageBox.Show("请选择打卡年月"); return; }

            string path;
            DataSet ds = new DataSet();
            if (!IsCanUpload(out path))
            {
                MessageBox.Show("无法上传！文件出错");
                return;
            }
            if (extension == ".xls" || extension == ".xlsx")
            {
                ds = ReadExcel(path);
                dtCode = BLL.Queryorder.GetList("").Tables[0];
                //message = AddDatabaseFromDataSet(ds);
                //MessageBox.Show(message);
            }
            else if (extension == ".csv")
            {
                ds = Readcsv(path);
                dtCode = BLL.Queryorder.GetList("").Tables[0];

            }
            message = AddAttendance(ds); 
       
            MessageBox.Show(message);
        }
    }
}