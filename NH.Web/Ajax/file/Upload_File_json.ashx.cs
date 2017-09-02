using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ECP.Web.Ajax.file
{
    /// <summary>
    /// Upload_File_json 的摘要说明：传入上传目录路径   上传文件  参考物料List界面 EXCEL上载功能界面 Excel_Handle.aspx
    /// 请注意提交表单时 form表单不能嵌套  否则将无法拿到提交的数据
    /// </summary>
    public class Upload_File_json : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string result = "0";
            try
            {

                if (context.User.IsInRole("Admin"))
                {
                    string uploadFilePath = "/" + context.Request.Params["uploadFilePath"];

                    string guid = Guid.NewGuid().ToString();
                    HttpPostedFile file = context.Request.Files[0];


                    string currfile = context.Server.MapPath(uploadFilePath);
                    //获取文件目录
                    string directoryPath = currfile + "/" + System.DateTime.Now.ToString("yyyy-MM-dd");
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    string path = Path.Combine(directoryPath, guid + Path.GetExtension(file.FileName));
                    //上传头像 
                    file.SaveAs(path);

                    result = path;

                }

            }
            catch (System.Exception ex)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(typeof(Upload_File_json));
                log.Error("上传文件Error：", ex);
            }

            ResponseWriteEnd(context, result); //上传成功   
        }

        private void ResponseWriteEnd(HttpContext context, string msg)
        {
            context.Response.Write(msg);
            context.Response.End();
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