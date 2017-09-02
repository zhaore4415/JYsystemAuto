
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using NH.Web.adm.WebBase;
using Maticsoft.Common;

namespace ECP.Web.Ajax.excel
{
    /// <summary>
    /// Upload_Electronic_sheet_json 的摘要说明
    /// </summary>
    public class Upload_Electronic_sheet_json : BaseOperHttpHandler
    {

        Common com = new Common("excel_import_temporary");

        //string LoginName = "";
        //decimal CARRIER_PARTY_ID = 0;
        protected override AjaxJsonModel HandlerMethod(HttpContext context)
        {
            base.logInitType = typeof(Upload_Electronic_sheet_json);
            //LoginName = context.Request.Params["LoginName"];
            //CARRIER_PARTY_ID = decimal.Parse(context.Request.Params["CARRIER_PARTY_ID"]);
            string filepath = context.Request.Params["filepath"];
            try
            {
                AjaxJsonModel result = ExcelSheetName(context, filepath);
                return result;
            }
            finally
            {
                try
                {
                    //删除服务器临时文件
                    File.Delete(filepath);
                }
                catch { }
            }
        }


        /// <summary>
        /// 针对于上载新数据
        /// 1、“会员、订单号、商品内容、商品数量、商品金额”列为必需；“付款时间”列可选，如果为空时默认不当前时间；注意“商品内容、商品数量、商品金额”列的格式分别为“手机,电脑,充电器”、“1,2,5”、“10.20,100,51.50”；
        ///2、会员必须存在，可先在推荐库管理增加会员；
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>导入结束时，弹窗提示“导入结果：总计A个订单，成功导入X个，失败导入Y个，重复未导入Z个！”</returns>
        public AjaxJsonModel ExcelSheetName(HttpContext context, string filepath)
        {
            AjaxJsonModel ajaxJson = null;
            try
            {
                System.Data.DataTable excel_dt = com.ExcelOpenDS(filepath).Tables[0];
                //检测模板列数是否符合要求
                if (excel_dt.Columns.Count != 7)
                {
                    //订单Excel数据格式有误，请下载最新模板进行上传！
                    return new AjaxJsonModel(ResSataus.Error, "3420");
                }

                //检测是否存在行   第一行为标题
                if (excel_dt.Rows.Count <= 1)
                {
                    //上传文件中不存在任何数据行！
                    return new AjaxJsonModel(ResSataus.Error, "3421");
                }
                excel_dt.Rows.RemoveAt(0);
                //上传订单数据
                orderList = excel_dt.AsEnumerable().Select(o => new ExcelOrderModel()
                {
                    NO = o[0].DBToString(),   //序号
                    LoginName = o[1].DBToString(),   // 会员名
                    OrderNumber = o[2].DBToString(),   //订单号
                    Products = o[3].DBToString(),    //商品内容
                    Babynumbers = o[4].DBToString(),    //商品数量
                    Amounts = o[5].DBToString(),//商品金额
                    DeliveryTime = o[6].DBToString()//付款时间

                }).Where(o => !string.IsNullOrEmpty(o.NO)).ToList();  //必须有序号值

                #region //所有行的 “序号、会员、订单号、商品内容、商品数量、商品金额”列为必需
                List<ExcelOrderModel> validOrderList = orderList.Where(o => string.IsNullOrEmpty(o.LoginName) || string.IsNullOrEmpty(o.Products) || string.IsNullOrEmpty(o.OrderNumber) || string.IsNullOrEmpty(o.Babynumbers) || string.IsNullOrEmpty(o.Amounts)).ToList();
                validOrderList.ForEach(o =>
                {
                    log_strs.AppendFormat("序号{0}：\n", o.NO);
                    if (string.IsNullOrEmpty(o.LoginName))
                    {
                        log_strs.AppendFormat("-------会员 不能为空！\n");
                    }
                    if (string.IsNullOrEmpty(o.OrderNumber))
                    {
                        log_strs.AppendFormat("-------订单号 不能为空！\n");
                    }
                    if (string.IsNullOrEmpty(o.Products))
                    {
                        log_strs.AppendFormat("-------商品内容 不能为空！\n");
                    }
                    if (string.IsNullOrEmpty(o.Babynumbers))
                    {
                        log_strs.AppendFormat("-------商品数量 不能为空！\n");
                    }
                    if (string.IsNullOrEmpty(o.Amounts))
                    {
                        log_strs.AppendFormat("-------商品金额 不能为空！\n");
                    }

                    log_strs.Append("\n");
                });
                #endregion


                #region   //会员必须存在，可先在推荐库管理增加会员
                List<ExcelOrderModel> validOrderList2 = orderList.ToList();
                bool isName = true;
                validOrderList2.ForEach(o =>
                {
                    log_strs.AppendFormat("序号{0}：\n", o.NO);
               
                    if (!NH.BLL.User.Exists(new NH.Model.User() { LoginName = o.LoginName }))
                    {
                        log_strs.AppendFormat("-------会员必须存在，可先在推荐库管理增加会员！\n");
                        isName = false;
                    }
                    log_strs.Append("\n");


                });

                #endregion

                #region 当前 用户 之下，订单号必须唯一；
                DataTable sourceNoDt = NH.BLL.Queryorder.GetList(" fb.OrderNumber IN(" + string.Join(",", orderList.Select(o => "'" + o.OrderNumber + "'").ToArray()) + ")").Tables[0];
                if (sourceNoDt.Rows.Count > 0)
                {
                    string[] existOrders = sourceNoDt.AsEnumerable().Select(s => s[1].DBToString()).ToArray();
                    orderList.Where(o => existOrders.Contains(o.OrderNumber)).ToList().ForEach(o =>
                    {
                        log_strs.AppendFormat("序号{0}：\n", o.NO);
                        log_strs.AppendFormat("-------订单号 已经存在！\n");

                        log_strs.Append("\n");
                    });
                }
                #endregion
                string resStr = "";
                string logPath = "";
                if (validOrderList.Count == 0 && isName == true && sourceNoDt.Rows.Count == 0)
                {
                    
                    //模板正确
                    this.OrderSaveHandle();
                    resStr = string.Format("导入结果：共处理{0}个订单，成功导入{1}个，失败导入{2}个！", totalCount, successCount, errorCount);
                    logPath = com.ReadLog(context, log_strs.ToString() + "\n\n" + resStr);

                    //返回格式应该是 “导入结果：总计A个订单，成功导入X个，失败导入Y个，重复未导入Z个！”；   
                    ajaxJson = new AjaxJsonModel(ResSataus.Success, "3423");
                    ajaxJson.Attribute1 = totalCount.ToString();
                    ajaxJson.Attribute2 = successCount.ToString();
                    ajaxJson.Attribute3 = errorCount.ToString();
                    ajaxJson.Attribute4 = logPath;
                }
                else
                {
                    logPath = com.ReadLog(context, log_strs.ToString() + "\n\n" + resStr);

                    //返回格式应该是 “导入失败，是否查看错误日志？”；   
                    ajaxJson = new AjaxJsonModel(ResSataus.Success, "3531");

                    ajaxJson.Attribute4 = logPath;
                }


                //调用方法  写入日志文件



            }
            catch (Exception ex)
            {
                base.log_.Error("订单导入错误：", ex);
                return new AjaxJsonModel(ResSataus.Error, "3036");
            }

            return ajaxJson;
        }

        int successCount = 0;
        int errorCount = 0;
        int totalCount = 0;

        StringBuilder log_strs = new StringBuilder("");
        NH.Model.Queryorder sales_model;
        //NH.BLL.Queryorder sales_bll = new NH.BLL.Queryorder();
        
        List<ExcelOrderModel> orderList;
        
        /// <summary>
        /// 单个订单方法递归处理
        /// </summary>
        /// <param name="orderList"></param>
        private void OrderSaveHandle()
        {

            if (orderList.Count > 0)
            {

                totalCount++;
                StringBuilder log_str = new StringBuilder("");

                //查找同一个电子面单号下的数据
                //List<ExcelOrderModel> currExcelModels = orderList.OrderBy(l => l.OrderNumber).ToList();
                List<ExcelOrderModel> currExcelModels = orderList.Where(o => o.OrderNumber == orderList[0].OrderNumber).OrderBy(l => l.OrderNumber).ToList();
                ExcelOrderModel currExcelModel = currExcelModels[0];
                try
                {
                    sales_model = new NH.Model.Queryorder();

                    if (log_str.ToString() == "")
                    {

                        log_strs.AppendFormat("序号 {0} ， 订单号 {1} ", currExcelModel.NO, currExcelModel.OrderNumber + "：正在处理......\n");

                        if (log_str.ToString() == "")
                        {
                            #region 订单头信息
                            /*网店默认数据 begin*/
                            NH.Model.User modUser = NH.BLL.User.GetModel(new NH.Model.User() { LoginName = currExcelModel.LoginName });

                            sales_model.U_ID = modUser.Id;

                            sales_model.Status = "1";

                            sales_model.LoginName = currExcelModel.LoginName;

                            sales_model.OrderNumber = long.Parse(currExcelModel.OrderNumber);
                            sales_model.Products = currExcelModel.Products;

                            sales_model.Babynumbers = currExcelModel.Babynumbers;
                            string[] babynumbers = StringPlus.ToDBC(sales_model.Babynumbers).Split(',');
                            int number = 0;
                            for (int i = 0; i < babynumbers.Length; i++)
                            {
                                number += Convert.ToInt32(babynumbers[i]);
                            }
                            sales_model.Babynumber = number;

                            sales_model.Amounts = currExcelModel.Amounts;
                            string[] amounts = StringPlus.ToDBC(sales_model.Amounts).Split(',');
                            decimal amount = 0M;
                            for (int i = 0; i < amounts.Length; i++)
                            {
                                amount += Convert.ToDecimal(amounts[i]);
                            }
                            sales_model.Amount = amount;

                            sales_model.DeliveryTime = !string.IsNullOrEmpty(currExcelModel.DeliveryTime) ? DateTime.Parse(currExcelModel.DeliveryTime) : DateTime.Now;

                            sales_model.AddTime = DateTime.Now;

                            #endregion
                        }
                    }

                    //没有错误  可以保存  
                    if (log_str.ToString() == "")
                    {
                        if (NH.BLL.Queryorder.Add(sales_model) > 0)
                        {
                            successCount++;
                            log_strs.AppendFormat(" 成功！");
                        }
                        else
                        {
                            errorCount++;
                            log_strs.AppendFormat(" 保存失败！内部错误！");
                        }
                    }
                    else
                    {
                        errorCount++;
                        //数据格式有错误，校验错误
                        log_strs.AppendFormat("初始化时发生错误！错误详细信息：  \n");
                        log_strs.AppendFormat(log_str.ToString());
                    }
                }
                catch (Exception ex)
                {
                    base.log_.Error("电子面单_Excel当前递归数据导入错误：", ex);

                    //数据格式有错误
                    errorCount++;
                    log_strs.AppendFormat("初始化时发生错误！");
                }

                log_strs.AppendFormat("\n\n");

                //从订单集合中删除已处理数据
                currExcelModels.ForEach(o =>
                {
                    orderList.Remove(o);
                });
                //递归调用
                this.OrderSaveHandle();
            }
        }


        public class ExcelOrderModel
        {
            public string NO { get; set; }  //序号

            public string LoginName { get; set; }  //会员名
            public string OrderNumber { get; set; }   //订单号
            public string Products { get; set; }   //商品内容
            public string Babynumbers { get; set; }  //商品数量
            public string Amounts { get; set; }  //商品金额

            public string DeliveryTime { get; set; }//付款时间
        }
    }
}