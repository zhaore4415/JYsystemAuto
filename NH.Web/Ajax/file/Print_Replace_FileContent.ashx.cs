using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ECP.Web.Ajax.file
{
    /// <summary>
    /// Print_Replace_FileContent  需要打印的到这里面来替换
    /// </summary>
    public class Print_Replace_FileContent : IHttpHandler
    {

        //可以考虑所有页面都用“提货函”打印方式,传入需要打印的参数，然后一次性查询出所有数据，然后进行循环添加相关脚本，最后返回，这样的话打印效率会提高很多
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";

                context.Response.ContentType = "text/plain";
                context.Response.Buffer = true;
                context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
                context.Response.AddHeader("pragma", "no-cache");
                context.Response.AddHeader("cache-control", "");
                context.Response.CacheControl = "no-cache";

                context.Response.ContentType = "text";

                string filePath = context.Request.Params["filePath"];
                if (filePath != null)
                {
                    StreamReader read = File.OpenText(context.Server.MapPath(filePath));
                    string text = read.ReadToEnd();
                    read.Close();

                    DataTable print_dt = null;
                    //当前循环到的唯一标识
                    string value = context.Request.Params["value"];
                    //打印模板种类
                    string TEMPLATE_SORT = context.Request.Params["TEMPLATE_SORT"];

                    string type = context.Request.Params["Type"];
                    

                    //面单 
                    if (TEMPLATE_SORT == "WAYBILL" || TEMPLATE_SORT == "EBS_WAYBILL")
                    {
                        #region 面单打印
                        if (TEMPLATE_SORT == "WAYBILL")
                        {
                            //通过唯一标识查询行
                            ECP.BLL.ORDER.ECS_BILL_DELIVERY sales_bll = new ECP.BLL.ORDER.ECS_BILL_DELIVERY();
                            print_dt = sales_bll.GetList_Print(value).Tables[0];
                        }
                        //EBS面单
                        else if (TEMPLATE_SORT == "EBS_WAYBILL")
                        {
                            //ECP.BLL.TRACE.ECP_EBS_DELIVERIES_V bll = new BLL.TRACE.ECP_EBS_DELIVERIES_V();
                            //print_dt = bll.GetList("DELIVERY_ID = '" + value + "'").Tables[0];
                        }


                        StringBuilder sb_result = new StringBuilder();
                        //打印头
                        if (print_dt != null)
                        {
                            if (print_dt.Rows.Count > 0)
                            {
                                sb_result.Append(onBaseHandle(print_dt, TEMPLATE_SORT, text));
                            }
                        } 
                        context.Response.Write(sb_result.ToString());

                        return;
                        #endregion
                    }
                    //交付承运面单_有明细
                    else if (TEMPLATE_SORT == "DELIVERY_TRACE_A")
                    {
                        #region
                        //先替换头   再替换行
                        //查询头
                        ECP.BLL.TRACE.ECS_DELIVERY_TRACE trace_bll = new ECP.BLL.TRACE.ECS_DELIVERY_TRACE();
                        print_dt = trace_bll.GetList_Print("ECS_DELIVERY_TRACE_ID=" + value).Tables[0];

                        StringBuilder sb_result = new StringBuilder();
                        //打印头
                        if (print_dt != null)
                        {
                            if (print_dt.Rows.Count > 0)
                            {
                                sb_result.Append(onHandLinePrint(print_dt, TEMPLATE_SORT, text, 0));
                            }
                        }

                        //打印行
                        ECP.BLL.TRACE.ECS_DELIVERY_DTL trace_dtl_bll = new ECP.BLL.TRACE.ECS_DELIVERY_DTL();
                        print_dt = trace_dtl_bll.GetList_Print("ECS_DELIVERY_TRACE_ID_DTL=" + value).Tables[0];
                        if (print_dt != null)
                        {
                            if (print_dt.Rows.Count > 0)
                            {
                                sb_result.Append(onHandLinePrint(print_dt, "DELIVERY_TRACE_LINE", text, 10));
                            }
                        }

                        ////替换条码
                        //text = text.Replace("123456789012", value);
                        ////不显示背景图
                        //text = text.Replace("true", "false");
                        context.Response.Write(sb_result.ToString());
                        return;
                        #endregion
                    }
                    //交付承运面单_无明细
                    else if (TEMPLATE_SORT == "DELIVERY_TRACE")
                    {
                        #region 
//查询头
                        ECP.BLL.TRACE.ECS_DELIVERY_TRACE trace_bll = new ECP.BLL.TRACE.ECS_DELIVERY_TRACE();
                        print_dt = trace_bll.GetList_Print("ECS_DELIVERY_TRACE_ID=" + value).Tables[0];

                        StringBuilder sb_result = new StringBuilder();
                        //打印头
                        if (print_dt != null)
                        {
                            if (print_dt.Rows.Count > 0)
                            {
                                sb_result.Append(onBaseHandle(print_dt, TEMPLATE_SORT, text));
                            }
                        }

                        context.Response.Write(sb_result.ToString());
                        return; 
#endregion
                    }
                    //出入库单
                    else if (TEMPLATE_SORT == "INV_TXN_INOUT" || TEMPLATE_SORT == "SUBINV_TRANS_BILL" || TEMPLATE_SORT == "INV_BILL_INOUT")
                    {
                        #region
                        //先替换头   再替换行
                        //查询头
                        ECP.BLL.SHOP.ECS_BILL_SHOP_INOUT inout_bll = new ECP.BLL.SHOP.ECS_BILL_SHOP_INOUT();
                        print_dt = inout_bll.GetList_Print("TRANSACTION_HEADER_ID=" + value).Tables[0];

                        StringBuilder sb_result = new StringBuilder();
                        //打印头
                        if (print_dt != null)
                        {
                            if (print_dt.Rows.Count > 0)
                            {
                                sb_result.Append(onHandLinePrint(print_dt, TEMPLATE_SORT, text, 0));
                            }
                        }


                        string TEMPLATE_SORT_DTL = "";
                        if (TEMPLATE_SORT == "INV_TXN_INOUT")
                        {
                            TEMPLATE_SORT_DTL = "INV_TXN_INOUT_DTL";
                        }
                        else if (TEMPLATE_SORT == "SUBINV_TRANS_BILL")
                        {
                            TEMPLATE_SORT_DTL = "SUBINV_TRANS_BILL_DTL";
                        }
                        else if (TEMPLATE_SORT == "INV_BILL_INOUT")
                        {
                            TEMPLATE_SORT_DTL = "INV_BILL_INOUT_DTL";
                        }
                        //打印行
                        ECP.BLL.SHOP.ECS_BILL_SHOP_INOUT_DTL inout_dtl_bll = new ECP.BLL.SHOP.ECS_BILL_SHOP_INOUT_DTL();
                        print_dt = inout_dtl_bll.GetList_Print("TRANSACTION_HEADER_ID_DTL=" + value).Tables[0];
                        if (print_dt != null)
                        {
                            if (print_dt.Rows.Count > 0)
                            {
                                sb_result.Append(onHandLinePrint(print_dt, TEMPLATE_SORT_DTL, text, 10));
                            }
                        }

                        ////替换条码
                        //text = text.Replace("123456789012", value);
                        ////不显示背景图
                        //text = text.Replace("true", "false");
                        context.Response.Write(sb_result.ToString());
                        return;
                        #endregion
                    }
                    //出入库事务记录
                    else if (TEMPLATE_SORT == "TRANSACTION_ALL")
                    { 
                        #region
                        //先替换头   再替换行
                        //查询头
                        ECP.BLL.TRANSACTION.ECS_TRANSACTION_ALL trace_bll = new ECP.BLL.TRANSACTION.ECS_TRANSACTION_ALL();
                        print_dt = trace_bll.GetList_Print("ECS_TRANSACTION_ALL_ID=" + value).Tables[0];

                        StringBuilder sb_result = new StringBuilder();
                        //打印头
                        if (print_dt != null)
                        {
                            if (print_dt.Rows.Count > 0)
                            {
                                sb_result.Append(onHandLinePrint(print_dt, TEMPLATE_SORT, text, 0));
                            }
                        }

                        //打印行 
                        ECP.BLL.Common_Hand bll_hand = new ECP.BLL.Common_Hand();
                        print_dt = bll_hand.GetRowColBySQL("SELECT * FROM ECS_TRANSACTION_V WHERE ECS_TRANSACTION_ALL_ID_DTL=" + value).Tables[0];
                        if (print_dt != null)
                        {
                            if (print_dt.Rows.Count > 0)
                            {
                                sb_result.Append(onHandLinePrint(print_dt, "TRANSACTION_DTL", text, 10));
                            }
                        }

                        ////替换条码
                        //text = text.Replace("123456789012", value);
                        ////不显示背景图
                        //text = text.Replace("true", "false");
                        context.Response.Write(sb_result.ToString());
                        return;
                        #endregion
                    }
                    //承运任务单
                    else if (TEMPLATE_SORT == "TMS_JOB_ALL_DRIVER")
                    {
                        #region
                        //先替换头   再替换行
                        //查询头
                        ECP.BLL.TRACE.ECS_TMS_JOB_ALL job_bll = new ECP.BLL.TRACE.ECS_TMS_JOB_ALL();
                        print_dt = job_bll.GetList_Print("TMS_JOB_ALL_ID=" + value).Tables[0];

                        StringBuilder sb_result = new StringBuilder();
                        //打印头
                        if (print_dt != null) 
                            if (print_dt.Rows.Count > 0) 
                                sb_result.Append(onHandLinePrint(print_dt, TEMPLATE_SORT, text, 0));  

                        //打印行  
                        ECP.BLL.TRACE.ECS_TMS_JOB_DTL job_dtl_bll = new ECP.BLL.TRACE.ECS_TMS_JOB_DTL();
                        print_dt = job_dtl_bll.GetList_Print("TMS_JOB_ALL_ID_DTL=" + value).Tables[0];
                        if (print_dt != null) 
                            if (print_dt.Rows.Count > 0) 
                                sb_result.Append(onHandLinePrint(print_dt, "TMS_JOB_DTL_DRIVER", text, 10));
                         
                        context.Response.Write(sb_result.ToString());
                        return;
                        #endregion
                    }
                    //发货单打印
                    else if (TEMPLATE_SORT == "DELIVERY_NOTE")
                    {
                        #region
                        //先替换头   再替换行
                        //查询头
                        ECP.BLL.Common_Hand bll_hand = new ECP.BLL.Common_Hand();
                        print_dt = bll_hand.GetRowColBySQL("SELECT * FROM ECS_PRT_DELIVERY_V WHERE DELIVERY_ID=" + value).Tables[0];
                        

                        StringBuilder sb_result = new StringBuilder();
                        //打印头
                        if (print_dt != null)
                            if (print_dt.Rows.Count > 0)
                                sb_result.Append(onHandLinePrint(print_dt, TEMPLATE_SORT, text, 0));

                        //打印行  
                        print_dt = bll_hand.GetRowColBySQL("SELECT * FROM ECS_PRT_DELIVERY_DETAIL_V WHERE DELIVERY_ID=" + value).Tables[0]; 
                        if (print_dt != null)
                            if (print_dt.Rows.Count > 0)
                                sb_result.Append(onHandLinePrint(print_dt, "DELIVERY_NOTE_DETAIL", text, 10));

                        context.Response.Write(sb_result.ToString());
                        return;
                        #endregion
                    }
                    //提货函
                    else if (TEMPLATE_SORT == "BILL_OF_LADING")
                    { 
                        decimal batch_id=-1;
                        decimal waybill_id=-1;
                        if (type == "single")    //单独普通面单按照提货函格式打印
                            waybill_id = Convert.ToDecimal(value);
                        else if (type == "lot")  //发运批提货函打印
                            batch_id = Convert.ToDecimal(value);  


                        #region  一次性输出多页打印脚本，不需要一页一页的查询并一条一条的返回
                        ECP.BLL.TRACE.ECS_DELIVERY_TRACE trace_bll = new ECP.BLL.TRACE.ECS_DELIVERY_TRACE();
                        print_dt = trace_bll.GetListBatch_Print(batch_id,waybill_id).Tables[0]; //返回多行、生成脚本

                         StringBuilder sb_result = new StringBuilder();

                         if (print_dt != null)
                         {
                             if (print_dt.Rows.Count > 0)
                             {
                                 DataTable copy_dt = print_dt.Copy(); 

                                 //循环替换，拿到脚本
                                 foreach (DataRow print_dr in print_dt.Rows)
                                 {
                                     copy_dt.Clear();
                                     copy_dt.Rows.Add(print_dr.ItemArray);  //因为方法中只是针对单行DataTable进行替换，直接就在文本文件text上面替换了进行返回，所以不可进行后面相关行的替换

                                     sb_result.Append("LODOP.NewPage();"); //分页脚本
                                     //替换当前页/数据信息 
                                     sb_result.Append(onBaseHandle(copy_dt, TEMPLATE_SORT, text)); 
                                 }
                             }
                         }   
                            
                         //输出所有打印脚本
                         context.Response.Write(sb_result.ToString());
                         return; 
 #endregion
                    } 
                    else if (TEMPLATE_SORT == "INSURE_BILL")
                    {
                        #region
                        //先替换头   再替换行
                        //查询头
                        ECP.BLL.TRACE.ECS_INSURE_BILL_ALL trace_bll =  new BLL.TRACE.ECS_INSURE_BILL_ALL();
                        print_dt = trace_bll.GetList_Print("INSURE_BILL_ALL_ID=" + value).Tables[0];

                        StringBuilder sb_result = new StringBuilder();
                        //打印头
                        if (print_dt != null)
                        {
                            if (print_dt.Rows.Count > 0)
                            {
                                sb_result.Append(onHandLinePrint(print_dt, TEMPLATE_SORT, text, 0));
                            }
                        }

                        //打印行
                        ECP.BLL.TRACE.ECS_INSURE_BILL_DTL trace_dtl_bll = new BLL.TRACE.ECS_INSURE_BILL_DTL();
                        print_dt = trace_dtl_bll.GetList_Print("INSURE_BILL_ALL_ID_DTL=" + value).Tables[0];
                        if (print_dt != null)
                        {
                            if (print_dt.Rows.Count > 0)
                            {
                                sb_result.Append(onHandLinePrint(print_dt, "INSURE_BILL_DTL", text, 10));
                            }
                        }

                        ////替换条码
                        //text = text.Replace("123456789012", value);
                        ////不显示背景图
                        //text = text.Replace("true", "false");
                        context.Response.Write(sb_result.ToString());
                        return;
                        #endregion
                    }
                    //项目批提货函
                    else if (TEMPLATE_SORT == "DELIVERY_NOTICE")
                    {
                        #region
                        //查询头
                        ECP.BLL.TRACE.ECS_TMS_PROJECT_LOT project_bll = new ECP.BLL.TRACE.ECS_TMS_PROJECT_LOT();
                        print_dt = project_bll.GetList_Print("A.ECS_TMS_PROJECT_LOT_ID=" + value).Tables[0];

                        StringBuilder sb_result = new StringBuilder();
                        //打印头
                        if (print_dt != null)
                        {
                            if (print_dt.Rows.Count > 0)
                            {
                                sb_result.Append(onBaseHandle(print_dt, TEMPLATE_SORT, text));
                            }
                        }

                        context.Response.Write(sb_result.ToString());
                        return;
                        #endregion

                    }
                    else if (TEMPLATE_SORT == "PICK_BILL")
                    {
                        #region
                        //先替换头   再替换行
                        //查询头
                        ECP.BLL.ORDER.ECS_PICK_LOT_ALL pick_bll = new BLL.ORDER.ECS_PICK_LOT_ALL();
                        print_dt = pick_bll.GetList_Print("PICK_LOT_ALL_ID=" + value).Tables[0];

                      
                        StringBuilder sb_result = new StringBuilder();
                        //打印头
                        if (print_dt != null)
                        {
                            if (print_dt.Rows.Count > 0)
                            {
                                sb_result.Append(onHandLinePrint(print_dt, TEMPLATE_SORT, text, 0));
                            }
                        }

                        //打印行
                        ECP.BLL.ORDER.ECS_BILL_DELIVERY_DTL trace_dtl_bll = new BLL.ORDER.ECS_BILL_DELIVERY_DTL();
                        print_dt = trace_dtl_bll.GetList_Print("PICK_LOT_ALL_ID_DTL=" + value).Tables[0];
                        if (print_dt != null)
                        {
                            if (print_dt.Rows.Count > 0)
                            {
                                sb_result.Append(onHandLinePrint(print_dt, "PICK_BILL_DTL", text, 10));
                            }
                        }
                        context.Response.Write(sb_result.ToString());
                        return;
                        #endregion
                    }
                    else if (TEMPLATE_SORT == "PACK_BILL")
                    { 
                        //装箱打印 
                        #region
                        //先替换头   再替换行
                        //查询头
                        ECP.BLL.ITEM.ECS_DELIVER_PACK_ALL trace_bll = new BLL.ITEM.ECS_DELIVER_PACK_ALL();
                        print_dt = trace_bll.GetList_Pack_Print("ECS_DELIVER_PACK_ALL_ID=" + value).Tables[0];

                        StringBuilder sb_result = new StringBuilder();
                        //打印头
                        if (print_dt != null)
                        {
                            if (print_dt.Rows.Count > 0)
                            {
                                sb_result.Append(onHandLinePrint(print_dt, TEMPLATE_SORT, text, 0));
                            }
                        }

                        //打印行
                        ECP.BLL.ITEM.ECS_DELIVER_PACK_DTL trace_dtl_bll = new BLL.ITEM.ECS_DELIVER_PACK_DTL();
                        print_dt = trace_dtl_bll.GetList_Pack_Print("ECS_DELIVER_PACK_ALL_ID_DTL=" + value).Tables[0];
                        if (print_dt != null)
                        {
                            if (print_dt.Rows.Count > 0)
                            {
                                sb_result.Append(onHandLinePrint(print_dt, "PACK_BILL_DTL", text, 10));
                            }
                        }
                        context.Response.Write(sb_result.ToString());
                        return;
                        #endregion
                    }


                    context.Response.Write(text);
                }
                else
                {
                    context.Response.Write("");
                }
            }
            catch (Exception ex)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(typeof(Print_Replace_FileContent));
                log.Error("打印一般处理程序Error：", ex);
                context.Response.Write("");
            }
        }


        /// <summary>
        /// 直接替换 模板文件相关Content
        /// 最基本的打印处理  不存在一个属性需要多个字段连接打印的情况
        /// </summary>
        private string onBaseHandle(DataTable print_dt,string TEMPLATE_SORT, string text) 
        {
            //加载当前类型可以打印的  属性
            ECP.BLL.BASE.ECS_PRINT_TEMPLATE_COL bll_col = new ECP.BLL.BASE.ECS_PRINT_TEMPLATE_COL();
            DataTable col_dt = bll_col.GetList("TEMPLATE_SORT='" + TEMPLATE_SORT + "'").Tables[0];
            foreach (DataRow print_dr in print_dt.Rows)
            {
                

                ECP.BLL.Common_Hand bll_hand = new ECP.BLL.Common_Hand();
                foreach (DataRow dr in col_dt.Rows)
                {

                    if (dr["IS_REFERENCES"].ToString() == "Y")
                    {
                        string sql = string.Format(dr["REFERENCES_CODE"].ToString(), print_dr[dr["COLUMN_NAME"].ToString()]);
                        DataTable obj = bll_hand.GetRowColBySQL(sql).Tables[0];
                        //有可能关联查询出来了多列  所以循环列名进行填充]
                        for (int i = 0; i < obj.Columns.Count; i++)
                        {
                            string colName = "\"" + obj.Columns[i].ColumnName + "\"";

                            if (text.IndexOf(colName) > -1)
                            {
                                //文件中存在该列  那么不管是否有值  都应该根据关联列名来替换
                                if (obj.Rows[0][i] != null)
                                {
                                    text = text.Replace(colName, "\"" + obj.Rows[0][i].ToString() + "\"");
                                }
                                else
                                {
                                    text = text.Replace(colName, "\"\"");

                                }
                            }
                            else
                            {
                                text = text.Replace("\"" + dr["COLUMN_NAME"].ToString() + "\"", "\"\"");
                            }

                        }
                          
                    }
                    else
                    {

                        //存在""前后加上""判断更准确
                        if (text.IndexOf("\"" + dr["COLUMN_NAME"].ToString() + "\"") > -1)
                        {
                            if (print_dr[dr["COLUMN_NAME"].ToString()] != null)
                                text = text.Replace("\"" + dr["COLUMN_NAME"].ToString() + "\"", "\"" + print_dr[dr["COLUMN_NAME"].ToString()].ToString() + "\"");
                            else
                                text = text.Replace("\"" + dr["COLUMN_NAME"].ToString() + "\"", "\"\"");
                        } 
                    }
                }
            }


            //移除相关不能存在的打印属性
            string[] tempTexts = text.Split(';');
            for (int i = 0; i < tempTexts.Length; i++)
            {
                if (!onNotExistsLine(tempTexts[i]))
                {
                    tempTexts[i] = "";  //改行属性不允许打印。
                }
            }


            string resultText = string.Join(";", tempTexts);
            return resultText;
        }

        /// <summary>
        /// 打印头行结构的  一个头  多个行
        /// 思路：不采用替换原则  使用遍历每一行追加原则
        /// </summary>
        /// <returns></returns>
        private string onHandLinePrint(DataTable print_dt, string TEMPLATE_SORT, string tempText, int lineHeigth)
        {
            //最终返回的字符串结果
            StringBuilder sb_result = new StringBuilder();
            string[] tempTexts = tempText.Split(';');

            //追加样式  看一下头几行是不是不被替换的  只针对头
            if (lineHeigth==0)
                sb_result.Append(onNextLineIsStyle(tempTexts, -1));

            //加载当前类型可以打印的  属性
            ECP.BLL.BASE.ECS_PRINT_TEMPLATE_COL bll_col = new ECP.BLL.BASE.ECS_PRINT_TEMPLATE_COL();
            DataTable col_dt = bll_col.GetList("TEMPLATE_SORT='" + TEMPLATE_SORT + "'").Tables[0];

            ECP.BLL.Common_Hand bll_hand = new ECP.BLL.Common_Hand();
            //动态改变的高度
            int newHeight = lineHeigth;
            int dataRowIndex = 0;
            foreach (DataRow print_dr in print_dt.Rows)
            {  
                foreach (DataRow dr in col_dt.Rows)
                { 
                    if (dr["IS_REFERENCES"].ToString() == "Y")
                    {
                        #region 基本已经废弃
string sql = string.Format(dr["REFERENCES_CODE"].ToString(), print_dr[dr["COLUMN_NAME"].ToString()]);
                        DataTable obj = bll_hand.GetRowColBySQL(sql).Tables[0];
                        //有可能关联查询出来了多列  所以循环列名进行填充]
                        for (int i = 0; i < obj.Columns.Count; i++)
                        {
                            
                            string colName = "\"" + obj.Columns[i].ColumnName + "\"";
                            for (int j = 0; j < tempTexts.Length;j++ )
                            {
                                if (tempTexts[j].IndexOf(colName) > -1)
                                {
                                    string replaceContent = tempTexts[j].Replace(colName, "\"" + obj.Rows[0][i].ToString() + "\"");
                                    if (newHeight == lineHeigth)
                                    {
                                        sb_result.Append(replaceContent+";");
                                    }
                                    else
                                    {  
                                        string topPrev = replaceContent.Substring(replaceContent.IndexOf(',') + 1);//去掉高度值前面一块
                                        //拿到头高度
                                        string topHeight = topPrev.Substring(0, topPrev.IndexOf(','));
                                        //加后的高度
                                        string newTopHeight = (Convert.ToInt32(topHeight) + newHeight).ToString();
                                        sb_result.Append(replaceContent.Replace(topHeight, newTopHeight) + ";");
                                    }

                                    //追加样式
                                    sb_result.Append(onNextLineIsStyle(tempTexts,j));
                                     
                                } 
                            }
                             
                        } 
#endregion
                    }
                    else
                    { 
                        //存在""前后加上""判断更准确
                        string colName = "\"" + dr["COLUMN_NAME"].ToString() + "\"";
                         
                        for (int j = 0; j < tempTexts.Length; j++)
                        {
                            if (tempTexts[j].IndexOf(colName) > -1)
                            { 
                                if (print_dr[dr["COLUMN_NAME"].ToString()] != null)
                                {
                                    string replaceContent = tempTexts[j].Replace(colName, "\"" + print_dr[dr["COLUMN_NAME"].ToString()].ToString() + "\""); 

                                    if (newHeight == lineHeigth)
                                    {
                                        sb_result.Append(replaceContent + ";"); 
                                    }
                                    else
                                    {
                                        string topPrev = replaceContent.Substring(replaceContent.IndexOf(',') + 1);//去掉高度值前面一块
                                        //拿到头高度
                                        string topHeight = topPrev.Substring(0, topPrev.IndexOf(','));
                                        //加后的高度
                                        string newTopHeight = (Convert.ToInt32(topHeight) + newHeight).ToString();
                                        sb_result.Append(replaceContent.Replace(topHeight, newTopHeight) + ";");
                                    }

                                    //追加样式
                                    sb_result.Append(onNextLineIsStyle(tempTexts, j));
                                }

                            } 
                        }
  

                    }
                }
                 
                if (dataRowIndex > 0)
                    newHeight += (lineHeigth * 2); //接下来是第三、四...行
                else
                    newHeight += lineHeigth;  //那么接下来是第二行，第一行还是当前位置，不会调节，所以这样算下来的话每一行距离Top的距离都加了 lineHeigth * 2 的高度。第二行因为默认已经等于了一个lineHeigth了，所以只需要加一个了，但第二行后面的行就需要 *2 了。或者直接写成：newHeight = lineHeigth * 2;

                dataRowIndex++;
            } 

            return sb_result.ToString(); 
        }
         
        /// <summary>
        /// 遍历的当前变量下是否存在样式 轮询
        /// </summary>
        /// <param name="tempTexts"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string onNextLineIsStyle(string[] tempTexts, int index)
        {

            StringBuilder sb_style = new StringBuilder("");
            index +=1;
            string tempText = tempTexts[index];
             
            //在打印时不能存在tempText.IndexOf(".PRINT_INITA(") > -1  不然分页打印会有问题，始终只是打印最后一页。而且预览界面的上下页图标都是禁用的。
            if (tempText.IndexOf(".PRINT_INITA(") > -1)
            {
                //虽说其不能打印，但是它后面可能还有相关设置脚本
                sb_style.Append(onNextLineIsStyle(tempTexts, index)); 
            }

            //打印出所有标题、水平线、样式SET_PRINT_STYLEA 、打印初始化、打印页面设置、背景图片、显示模式
            if (tempText.IndexOf(".ADD_PRINT_TEXT(") > -1 || tempText.IndexOf(".ADD_PRINT_LINE(") > -1 || tempText.IndexOf(".SET_PRINT_STYLEA(") > -1 ||  tempText.IndexOf(".SET_PRINT_PAGESIZE(") > -1 || tempText.IndexOf(".ADD_PRINT_SETUP_BKIMG(") > -1 || tempText.IndexOf(".SET_SHOW_MODE(") > -1)
            {
                //存在样式  那么就追加  并且轮询当前方法查看是否还有别的样式
                sb_style.Append(tempText + ";");
                sb_style.Append(onNextLineIsStyle(tempTexts,index)); 
            }
            return sb_style.ToString();
        }

        /// <summary>
        /// 不允许存在的参数 false：该行不可打印   true：该行可以打印
        /// </summary>
        /// 在打印时不能存在tempText.IndexOf(".PRINT_INITA(") > -1  不然分页打印会有问题，始终只是打印最后一页。而且预览界面的上下页图标都是禁用的。
        /// <param name="lineText">传入行文本</param>
        /// <returns>false：该行不可打印   true：该行可以打印</returns>
        private bool onNotExistsLine(string lineText) 
        {
            if (lineText.IndexOf(".PRINT_INITA(") > -1)
            {
                return false;
            }

            return true;
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}