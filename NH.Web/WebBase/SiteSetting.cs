using System;
 using System.Configuration;
 using System.Collections.Generic;
 using System.Text;
 
 /// <summary>
 /// SiteSetting 的摘要说明
 /// </summary>
 namespace JJoobb.Web
 {
     public class SiteSetting
     {
 //        //数据库连接字符串
 //        public static string ConnectionString =
 
 //ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
 
         //从excel读数据
         public static string ExToDB = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";Data Source=";
                                        //Provider=Microsoft.Ace.OleDb.12.0;data source = { 0 }; Extended Properties = 'Excel 12.0; HDR=Yes; IMEX=1
     }
 }