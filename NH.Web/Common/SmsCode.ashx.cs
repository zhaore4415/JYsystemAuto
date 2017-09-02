using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data;
using Maticsoft.Common;

namespace NH.Web
{
    /// <summary>
    /// Summary description for SmsCode
    /// </summary>
    public class SmsCode : IHttpHandler,IReadOnlySessionState
    {
        HttpRequest Request = HttpContext.Current.Request;
        HttpResponse Response = HttpContext.Current.Response;
        public void ProcessRequest(HttpContext context)
        {
            if (!string.IsNullOrEmpty(Request.Form["type"]))
            {
                SendSms();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void SendSms()
        {
            //类型：1,个人用户注册时手机验证;2,个人用户更换手机时验证
            int codeType = int.Parse(Request.Form["type"]);
            string mobile = Request.Form["mobile"];

            //检测上次发送时间，判断是否可以发送
            Model.SmsCode sms = new Model.SmsCode();
            sms.Mobile = mobile;
            sms.CodeType = codeType;
            sms.Status = 1;

            sms = BLL.SmsCode.GetModel(sms);

            DataTable dt = BLL.SmsCode.GetList(1, "Mobile='" + mobile.Replace("'", "''") + "' and CodeType=" + codeType + " and Status=1", "Id desc").Tables[0];

            if (dt.Rows.Count > 0)
            {
                int second = (int)(DateTime.Now - DateTime.Parse(dt.Rows[0]["AddTime"].ToString())).TotalSeconds;
                int delay = ConfigHelper.GetConfigInt("SmsCodeDelay");
                if (second < delay)
                {
                    Maticsoft.Common.Ajax.WriteError("您获取短信验证码间隔时间过短,请稍后再试！");
                }
            }


            string code = GetRandom(5);
            //添加到数据库
            Model.SmsCode model = new Model.SmsCode();
            if (UserBase.IsLogin)
            {
                model.UserId = UserBase.Current.Id;
                model.UserType = UserBase.Current.UserType;
            }
            else
            {
                model.UserId = 0;
                model.UserType = 0;
            }
            model.Code = code;
            model.CodeType = codeType;
            model.AddTime = DateTime.Now;
            model.Status = 1;
            model.IP = RequestHelper.GetIP();
            model.Mobile = mobile;

            //发送短信....
            bool sendresult = new NH.Web.SMS().Send(mobile, string.Format("手机短信验证码:{0}", code));
            //bool sendresult = true;
            if (sendresult && BLL.SmsCode.Add(model) > 0)
            {
                Maticsoft.Common.Ajax.WriteOk("发送成功");
            }
            else
            {
                Maticsoft.Common.Ajax.WriteError("短信发送失败");
            }

            
        }


        private static string GetRandom(int len)
        {
            string formatString = "0,1,2,3,4,5,6,7,8,9";

            string codeString = string.Empty;
            string[] strArray = formatString.Split(new char[] { ',' });
            Random random = new Random();
            for (int i = 0; i < len; i++)
            {
                int index = random.Next(0x186a0) % strArray.Length;
                codeString = codeString + strArray[index].ToString();
            }
            return codeString;
        }










    }
}