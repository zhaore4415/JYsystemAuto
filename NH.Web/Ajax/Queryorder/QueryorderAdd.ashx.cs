using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
namespace NH.Web.Ajax.Queryorder
{
    /// <summary>
    /// QueryorderAdd 的摘要说明
    /// </summary>
    public class QueryorderAdd : IHttpHandler
    {

        JavaScriptSerializer serializer = new JavaScriptSerializer();
        public static string str0 = "";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";

            context.Response.Write(GetQuarter(context));
        }
        private string GetQuarter(HttpContext context)
        {
            string action = context.Request["action"];
            string type = context.Request["type"];

            string re = "";
            //json 反序列化


            if (!context.User.IsInRole("Admin"))
            {
                if (context.Request.QueryString["ajax"] == "1")
                {
                    Maticsoft.Common.Ajax.WriteNologin("请登录");
                }
                else
                {
                    context.Response.Redirect("/template/Loginredirect.aspx?ReturnUrl=" + context.Request.RawUrl);
                    //Server.Transfer("/template/Loginredirect.aspx?ReturnUrl=" + Request.RawUrl);
                }
            }
            else
            {


            }
            try
            {
                //BLL.Queryorder bll = new BLL.Queryorder();
                if (action == "search")
                {
                    string LoginName = context.Request.Params["LoginName"];
                    if (BLL.User.Exists(new Model.User() { LoginName = LoginName }))
                    {
                        re = "1";
                    }
                    else
                    {
                        re = "0";
                    }


                }
                else if (action == "delete")
                {
                    string ids = context.Request.Params["ids"].TrimEnd(',');
                    if (BLL.Queryorder.DeleteList(ids))
                    {
                        re = "1";
                    }
                    else
                    {
                        re = "0";
                    }
                }
                else if (action == "update")
                {
                    var jsonstring = context.Request.Params["myjson"];

                    Model.Queryorder model = serializer.Deserialize(jsonstring, typeof(Model.Queryorder)) as Model.Queryorder;

                    Model.User modUser = BLL.User.GetModel(new Model.User() { LoginName = model.LoginName });

                    model.U_ID = modUser.Id;

                    model.Status = "1";

                    string[] babynumbers = StringPlus.ToDBC(model.Babynumbers).Split(',');
                    int number = 0;
                    for (int i = 0; i < babynumbers.Length; i++)
                    {
                        number += Convert.ToInt32(babynumbers[i]);
                    }
                    model.Babynumber = number;

                    string[] amounts = StringPlus.ToDBC(model.Amounts).Split(',');
                    decimal amount = 0M;
                    for (int i = 0; i < amounts.Length; i++)
                    {
                        amount += Convert.ToDecimal(amounts[i]);
                    }
                    model.Amount = amount;
                    model.AddTime = DateTime.Now;

                    if (BLL.Queryorder.Update(model))
                        re = "1";
                    else
                        re = "0";

                }
                else if (action == "add")
                {
                    var jsonstring = context.Request.Params["myjson"];

                    Model.Queryorder model = serializer.Deserialize(jsonstring, typeof(Model.Queryorder)) as Model.Queryorder;

                    Model.User modUser = BLL.User.GetModel(new Model.User() { LoginName = model.LoginName });

                    model.U_ID = modUser.Id;

                    model.Status = "1";

                    string[] babynumbers = StringPlus.ToDBC(model.Babynumbers).Split(',');
                    int number = 0;
                    for (int i = 0; i < babynumbers.Length; i++)
                    {
                        number += Convert.ToInt32(babynumbers[i]);
                    }
                    model.Babynumber = number;

                    string[] amounts = StringPlus.ToDBC(model.Amounts).Split(',');
                    decimal amount = 0M;
                    for (int i = 0; i < amounts.Length; i++)
                    {
                        amount += Convert.ToDecimal(amounts[i]);
                    }
                    model.Amount = amount;



                    model.AddTime = DateTime.Now;


                    if (BLL.Queryorder.Add(model) > 0)
                    {
                        re = "1";

                    }
                    else
                        re = "0";



                }
            }
            catch (Exception exp_)
            {

                re = "0";
                //throw exp_;
            }
            return re;

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