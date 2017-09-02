using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Data;

namespace NH.Web
{
    public class MailSender
    {
        #region
        /*
        public class SmtpSetting
        {
            private string _server;

            public string Server
            {
                get { return _server; }
                set { _server = value; }
            }
            private bool _authentication;

            public bool Authentication
            {
                get { return _authentication; }
                set { _authentication = value; }
            }

            private bool _enableSsl;
            public bool EnableSsl
            {
                get { return _enableSsl; }
                set { _enableSsl = value; }
            }

            private string _user;

            public string User
            {
                get { return _user; }
                set { _user = value; }
            }
            private string _sender;

            public string Sender
            {
                get { return _sender; }
                set { _sender = value; }
            }
            private string _password;

            public string Password
            {
                get { return _password; }
                set { _password = value; }
            }
        }
        */
        #endregion

        //public static List<Model.EmailConfig> _emailList = null;
        public static DataTable _emailList = null;
        public static Model.EmailConfig _emailConfig = new Model.EmailConfig();

        public static void SetCurrentEmail()
        {
            lock (_emailConfig)
            {
                if (_emailList == null || _emailList.Rows.Count == 0)
                {
                    _emailList = BLL.EmailConfig.GetListByCache();
                    _emailList.Columns.Add("LastTime", typeof(DateTime));
                    for (int i = 0; i < _emailList.Rows.Count; i++)
                    {
                        _emailList.Rows[i]["Password"] = Maticsoft.Common.DESEncrypt.Decrypt(_emailList.Rows[i]["Password"].ToString());
                        _emailList.Rows[i]["LastTime"] = DateTime.Now;
                    }

                    if (_emailList.Rows.Count == 0)
                    {
                        throw new Exception("未设置发件邮箱");
                    }
                }
                DataRow row = _emailList.Select("1=1","LastTime asc")[0];

                _emailConfig.Server = row["Server"].ToString();
                _emailConfig.Account = row["Account"].ToString();
                _emailConfig.Password = row["Password"].ToString();
                _emailConfig.Sender = row["Sender"].ToString();
                _emailConfig.Authentication = (row["Authentication"].ToString() == "1" || row["Authentication"].ToString() == "True");
                _emailConfig.EnableSsl = (row["EnableSsl"].ToString() == "1" || row["EnableSsl"].ToString() == "True");
                _emailConfig.Port = row["Port"].ToString();

                row["LastTime"] = DateTime.Now;

            }
        }

        public static void Send(
            string server,
            string from,
            string fromname,
            string password,
            string to,
            string subject,
            string body,
            bool isBodyHtml,
            Encoding encoding,
            bool isAuthentication,
            bool isSSL,
            string port,
            params string[] files
            )
        {
            SmtpClient smtpClient = new SmtpClient(server);
            //MailMessage message = new MailMessage(from, to);
            MailMessage message = new MailMessage();

            if (!string.IsNullOrEmpty(fromname))
            {
                message.From = new MailAddress(from, fromname, encoding);
            }
            else
            {
                message.From = new MailAddress(from);
            }
            message.To.Add(new MailAddress(to));

            message.IsBodyHtml = isBodyHtml;

            message.SubjectEncoding = encoding;
            message.BodyEncoding = encoding;

            message.Subject = subject;
            message.Body = body;

            //test
            //message.Sender = new MailAddress(from, "风头电子人才网简历_张三", System.Text.Encoding.Default);


            message.Attachments.Clear();
            if (files != null && files.Length != 0)
            {
                for (int i = 0; i < files.Length; ++i)
                {
                    Attachment attach = new Attachment(files[i]);
                    message.Attachments.Add(attach);
                }
            }

            if (isAuthentication == true)
            {
                smtpClient.Credentials = new NetworkCredential(from,password);
            }
            smtpClient.EnableSsl = isSSL;
            if (!string.IsNullOrEmpty(port))
            {
                smtpClient.Port = int.Parse(port);
            }
            smtpClient.Send(message);


        }

        //public static void Send(string recipient, string subject, string body)
        //{
        //    SetCurrentEmail();
        //    Send(_emailConfig.Server, _emailConfig.Account,null,_emailConfig.Password, recipient, subject, body, true, Encoding.Default, _emailConfig.Authentication.Value,_emailConfig.EnableSsl.Value, null);
        //}

        public static void Send(string sendername, string recipient, string subject, string body)
        {
            SetCurrentEmail();
            Send(_emailConfig.Server, _emailConfig.Account,sendername, _emailConfig.Password, recipient, subject, body, true, Encoding.Default, _emailConfig.Authentication.Value, _emailConfig.EnableSsl.Value, null);
        }

        public static void ClearEmailList()
        {
            if (_emailList != null) _emailList.Clear();
        }
    }


    public class SMS
    {
        private string _id = NH.Web.Site.Config.Sms_ID;//"67303";
        private string _account = NH.Web.Site.Config.Sms_Account;//"admin";
        private string _password = NH.Web.Site.Config.Sms_Password;//"84807932";
        private string _sendmobile = NH.Web.Site.Config.Sms_SendMobile;//"13045891551";

        adm.net.iems.ws.SmsInterfaceService sms = new adm.net.iems.ws.SmsInterfaceService();

        public bool Send(string to,string msg)
        {
            try
            {
                string str = sms.clusterSend(_id + ":" + _account, _password, _sendmobile, to, msg + "【风头电子人才网】", "", "0");
                //string str = sms.clusterSend("67303:admin", "84807932", "13045891551", "18123940624", "短信内容", "", "0");
                return GetText(str, "code") == "1000";
            }
            catch(Exception ex)
            {
                Maticsoft.Common.Log.Write(ex);
                return false;
            }
        }

        public SMS_Model GetUserInfo()
        {
            string str = sms.getUserInfo(_id + ":" + _account, _password);
            SMS_Model model = new SMS_Model();
            model.Code= GetText(str, "code");
            if (model.Code == "1000")
            {
                model.Balance = GetText(str, "balance");
                model.SmsPrice = GetText(str, "smsPrice");
                model.SignZH = GetText(str, "signZH");
            }
            return model;
        }

        private string GetText(string returnStr,string tagname)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(returnStr);
            return doc.GetElementsByTagName(tagname).Item(0).InnerText;
        }


    }

    public class SMS_Model
    {
        /// <summary>
        /// 状态码1000表示操作成功,其它状态码参考
        /// </summary>
        public string Code{get;set;}

        /// <summary>
        /// 余额:单位为元
        /// </summary>
        public string Balance { get; set; }

        /// <summary>
        /// 短信产品单价(单位元)
        /// </summary>
        public string SmsPrice { get; set; }

        /// <summary>
        /// 中文签名
        /// </summary>
        public string SignZH { get;set; }
    }

}