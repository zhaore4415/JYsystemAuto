
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ECP.Web.Ajax.excel
{
    public class Common
    {
        public Common(string directory) 
        {
            this.directory = directory;
        }

        #region
        //显示标题
        string[] showColsName = new string[] { };
        //内容列
        string[] showColsCode = new string[] { };
        //列宽度
        int[] columnWidths = new int[] { }; 
        //更新列
        string resetColsName = ""; //物料编码,物料名称  
        #endregion

        /// <summary>
        /// 创建相关路径文件夹与文件
        /// </summary>
        /// <param name="saveAllDirectoryPath">完整服务器目录路径</param>
        /// <param name="fileName">文件路径</param>
        /// <returns></returns>
        public static string CreateDirectory_Or_File(string saveAllDirectoryPath, string fileName)
        {
            try
            {
                saveAllDirectoryPath = HttpContext.Current.Server.MapPath(saveAllDirectoryPath);

                string[] dics = saveAllDirectoryPath.Split('\\');
                string path = "";
                for (int i = 1; i < dics.Length; i++)
                {
                    path = "";
                    for (int j = 0; j < i; j++)
                    {
                        path += dics[j] + "\\";
                    }
                    path += dics[i];

                    //判断文件夹是否存在
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                }

                if (!System.IO.File.Exists(saveAllDirectoryPath + "\\" + fileName))
                {
                    System.IO.File.Create(saveAllDirectoryPath + "\\" + fileName).Dispose();
                }

                return saveAllDirectoryPath + "\\" + fileName;
            }
            catch 
            {
                return "";
            }
        }


        //保存文件目录
        string directory = "";

        public Common(string[] showColsName, string[] showColsCode, int[] columnWidths, string resetColsName, string directory)
        {

            this.showColsName = showColsName;
            this.showColsCode = showColsCode;
            this.columnWidths = columnWidths;
            this.resetColsName = resetColsName;

            this.directory = directory;
        }
        public string OutputExcel(HttpContext context, System.Data.DataTable dv, string fileName)
        {
            string xlfile = "";
            if (string.IsNullOrEmpty(fileName))
            {
                xlfile = Guid.NewGuid().ToString();
            }
            else {
                xlfile = fileName;
            }
            try
            {

                
                //dv为要输出到Excel的数据 
                GC.Collect();

                //创建工作薄
                HSSFWorkbook wk = new HSSFWorkbook();
                //XSSFWorkbook wk = new XSSFWorkbook();
                //创建一个名称为mySheet的表
                ISheet tb = wk.CreateSheet("mySheet");
                tb.CreateFreezePane(0, 1); //冻结  这个不是指索引，而是从1开始的   该段代码是指：不冻结列，冻结第一行

                //设置工作表密码
                //tb.ProtectSheet("szebs");

                //创建一行，此行为第二行
                IRow row = tb.CreateRow(0);

                //样式一定要单独定义 然后引用

                //可修改列样式
                ICellStyle currentTitleColStyle = wk.CreateCellStyle();
                //设置单元格背景颜色需要同时设置1，2   背景颜色是FillForegroundColor  而不是FillBackgroundColor
                currentTitleColStyle.FillPattern = FillPattern.SolidForeground; //1
                currentTitleColStyle.FillForegroundColor = HSSFColor.Tan.Index; //2  
                //currentTitleColStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Red.Index; 
                //currentTitleColStyle.IsLocked = true;
                currentTitleColStyle.Alignment = HorizontalAlignment.Center;//设置标题格式为居中对齐 

                //定义几种字体  
                //也可以一种字体，写一些公共属性，然后在下面需要时加特殊的  
                NPOI.SS.UserModel.IFont font12 = wk.CreateFont();
                font12.FontHeightInPoints = 10;
                font12.FontName = "微软雅黑";
                currentTitleColStyle.SetFont(font12);

                //不可修改列样式
                ICellStyle notCurrentTitleColStyle = wk.CreateCellStyle();
                notCurrentTitleColStyle.Alignment = HorizontalAlignment.Center;//设置标题格式为居中对齐 
                //notCurrentTitleColStyle.IsLocked = true;
                notCurrentTitleColStyle.SetFont(font12);

                for (int i = 1; i <= showColsName.Length; i++)
                {
                    ICell cell = row.CreateCell(i - 1);  //在第二行中创建单元格
                    cell.SetCellValue(showColsName[i - 1]);//循环往第二行的单元格中添加数据


                    //自适应列宽  以数据最多最宽列长度为准
                    //tb.AutoSizeColumn(i);  
                    if (resetColsName.IndexOf(showColsName[i - 1].Trim()) >= 0)
                    {
                        cell.CellStyle = currentTitleColStyle;

                    }
                    else
                    {
                        cell.CellStyle = notCurrentTitleColStyle;
                    }

                    tb.SetColumnWidth(i - 1, columnWidths[i - 1]);
                }

                //可修改内容样式
                ICellStyle currentColContentStyle = wk.CreateCellStyle();
                //设置单元格背景颜色需要同时设置1，2   背景颜色是FillForegroundColor  而不是FillBackgroundColor
                currentColContentStyle.FillPattern = FillPattern.SolidForeground; //1
                currentColContentStyle.FillForegroundColor = HSSFColor.Tan.Index; //2  
                currentColContentStyle.Alignment = HorizontalAlignment.Center;//设置标题格式为居中对齐
                //currentColContentStyle.IsLocked = false;

                //不可修改（不会进行保存）内容样式
                ICellStyle notCurrentColContentStyle = wk.CreateCellStyle();
                notCurrentColContentStyle.Alignment = HorizontalAlignment.Center;//设置标题格式为居中对齐 
                //notCurrentColContentStyle.IsLocked = true;

                // 
                //取得表格中的数据 
                // 
                int paymentRowIndex = 1;
                foreach (DataRow dv_row in dv.Rows)
                {
                    IRow newRow = tb.CreateRow(paymentRowIndex);
                    for (int i = 1; i <= showColsCode.Length; i++)
                    {
                        ICell cell = newRow.CreateCell(i - 1);
                        cell.SetCellValue(dv_row[showColsCode[i - 1]].ToString().Replace("0:00:00", ""));
                        //tb.AutoSizeColumn(i);

                        //设置可更新字段背景颜色
                        if (resetColsName.IndexOf(showColsName[i - 1].Trim()) >= 0)
                        {
                            cell.CellStyle = currentColContentStyle;
                        }
                        else
                        {
                            cell.CellStyle = notCurrentColContentStyle;
                        }

                    }
                    paymentRowIndex++;
                }

                string uploadPath = "/Upload/excel_import_export/" + directory + "/xls/" + DateTime.Now.ToString("yyyy-MM-dd");
                string savePath = ECP.Web.Ajax.excel.Common.CreateDirectory_Or_File(uploadPath, xlfile + ".xls");  // xls xlsx

                using (FileStream fs = File.OpenWrite(savePath)) //打开一个xls文件，如果没有则自行创建，如果存在myxls.xls文件则在创建是不要打开该文件！
                {
                    wk.Write(fs);   //向打开的这个xls文件中写入mySheet表并保存。  
                }

                GC.Collect();

                return uploadPath + "/" + xlfile + ".xls";  //返回保存路径 
            }
            catch (Exception ex)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(typeof(Common));
                log.Error("生成Excel—Common方法错误：Error：", ex);
                throw ex;
            }
        }
        public string OutputExcel(HttpContext context, System.Data.DataTable dv)
        {
            string xlfile = Guid.NewGuid().ToString();
            return OutputExcel(context, dv, xlfile);
        }


        /// <summary>
        /// Excel某sheet中内容导入到DataTable中
        /// 区分xsl和xslx分别处理
        /// </summary>
        /// <param name="filePath">Excel文件路径,含文件全名</param>
        /// <param name="sheetName">此Excel中sheet名</param>
        /// <returns></returns>
        public System.Data.DataTable ExcelSheetImportToDataTable(string filePath, string sheetName)
        {

            System.Data.DataTable dt = new System.Data.DataTable();

            if (Path.GetExtension(filePath).ToLower() == ".xls".ToLower())
            {//.xls
                #region .xls文件处理:HSSFWorkbook
                HSSFWorkbook hssfworkbook;
                try
                {
                    using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {

                        hssfworkbook = new HSSFWorkbook(file);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                ISheet sheet = hssfworkbook.GetSheet(sheetName);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                HSSFRow headerRow = (HSSFRow)sheet.GetRow(0);

                //一行最后一个方格的编号 即总的列数 
                for (int j = 0; j < (sheet.GetRow(0).LastCellNum); j++)
                {
                    //SET EVERY COLUMN NAME
                    HSSFCell cell = (HSSFCell)headerRow.GetCell(j);

                    dt.Columns.Add(cell.ToString());
                }

                while (rows.MoveNext())
                {
                    IRow row = (HSSFRow)rows.Current;
                    DataRow dr = dt.NewRow();

                    if (row.RowNum == 0) continue;//The firt row is title,no need import

                    for (int i = 0; i < row.LastCellNum; i++)
                    {
                        if (i >= dt.Columns.Count)//cell count>column count,then break //每条记录的单元格数量不能大于表格栏位数量 20140213
                        {
                            break;
                        }

                        ICell cell = row.GetCell(i);

                        if ((i == 0) && (string.IsNullOrEmpty(cell.ToString()) == true))//每行第一个cell为空,break
                        {
                            break;
                        }

                        if (cell == null)
                        {
                            dr[i] = null;
                        }
                        else
                        {
                            dr[i] = cell.ToString();
                        }
                    }

                    dt.Rows.Add(dr);
                }
                #endregion
            }
            else
            {//.xlsx
                #region .xlsx文件处理:XSSFWorkbook
                XSSFWorkbook hssfworkbook;
                try
                {
                    using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {

                        hssfworkbook = new XSSFWorkbook(file);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                ISheet sheet = hssfworkbook.GetSheet(sheetName);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                XSSFRow headerRow = (XSSFRow)sheet.GetRow(0);



                //一行最后一个方格的编号 即总的列数 
                for (int j = 0; j < (sheet.GetRow(0).LastCellNum); j++)
                {
                    //SET EVERY COLUMN NAME
                    XSSFCell cell = (XSSFCell)headerRow.GetCell(j);

                    dt.Columns.Add(cell.ToString());

                }

                while (rows.MoveNext())
                {
                    IRow row = (XSSFRow)rows.Current;
                    DataRow dr = dt.NewRow();

                    if (row.RowNum == 0) continue;//The firt row is title,no need import

                    for (int i = 0; i < row.LastCellNum; i++)
                    {
                        if (i >= dt.Columns.Count)//cell count>column count,then break //每条记录的单元格数量不能大于表格栏位数量 20140213
                        {
                            break;
                        }

                        ICell cell = row.GetCell(i);

                        if ((i == 0) && (string.IsNullOrEmpty(cell.ToString()) == true))//每行第一个cell为空,break
                        {
                            break;
                        }

                        if (cell == null)
                        {
                            dr[i] = null;
                        }
                        else
                        {
                            dr[i] = cell.ToString();
                        }
                    }
                    dt.Rows.Add(dr);
                }
                #endregion
            }
            return dt;
        }

        /// <summary>
        /// 是否是整型
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool IsDouble(string val)
        {
            try
            {
                decimal result = Convert.ToDecimal(val);

                return true;
            }
            catch
            {
                return false;
            }

        }


        /// <summary>
        /// 写入Log日志文件
        /// </summary>
        /// <param name="content"></param>
        public string ReadLog(HttpContext context, string content)
        {
            string guid = Guid.NewGuid().ToString();
            string uploadPath = "/Upload/excel_import_export/" + directory + "/log/" + DateTime.Now.ToString("yyyy-MM-dd");
            string savePath = ECP.Web.Ajax.excel.Common.CreateDirectory_Or_File(uploadPath, guid + ".txt");

            File.WriteAllText(savePath, content, Encoding.UTF8); 
            return  uploadPath +"/"+ guid + ".txt";
        }

        /// <summary>
        /// 读取Excel  并返回数据集，设置了第一行为标题行，将不会进行读取
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public DataSet ExcelOpenDS(string filepath)
        {
            //string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + filepath + ";Extended Properties='Excel 8.0; HDR=Yes; IMEX=1'"; //此连接只能操作Excel2007之前(.xlsx)文件
            string strConn = string.Format(ConfigurationManager.AppSettings.Get("ExcelConnectionString"), filepath); //此连接可以操作.xls与.xlsx文件 (支持Excel2003 和 Excel2007 的连接字符串)
            //备注： "HDR=yes;"是说Excel文件的第一行是列名而不是数据，"HDR=No;"正好与前面的相反。
            //       "IMEX=1 "如果列中的数据类型不一致，使用"IMEX=1"可必免数据类型冲突。  
            OleDbConnection conn = new OleDbConnection(strConn);

            conn.Open();
            OleDbDataAdapter adp = new OleDbDataAdapter("Select * from [mySheet$]", conn);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Book1");
            conn.Close(); 
            return ds; 
        }


    }
}
