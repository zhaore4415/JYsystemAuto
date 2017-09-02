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
using Maticsoft.DBUtility;

namespace Maticsoft.Common
{
    public class MailSender2
    {

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

        public static List<SmtpSetting> _settingList = null;

        public static SmtpSetting GetSmtpSetting()
        {
            if (_settingList == null)
            {
                SmtpSetting model = new SmtpSetting();
                model.Server = "";
            }
            return new SmtpSetting();
        }

        public static void Send(
            string server, 
            string sender, 
            string recipient, 
            string subject,
            string body, 
            bool isBodyHtml, 
            Encoding encoding, 
            bool isAuthentication, 
            params string[] files
            )
        {
            SmtpClient smtpClient = new SmtpClient(server);
            MailMessage message = new MailMessage(sender, recipient);
            message.IsBodyHtml = isBodyHtml;

            message.SubjectEncoding = encoding;
            message.BodyEncoding = encoding;

            message.Subject = subject;
            message.Body = body;

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
                smtpClient.Credentials = new NetworkCredential(SmtpConfig.Create().SmtpSetting.User,
                    SmtpConfig.Create().SmtpSetting.Password);
            }
            smtpClient.Send(message);


        }

        public static void Send(string recipient, string subject, string body)
        {
            Send(SmtpConfig.Create().SmtpSetting.Server, SmtpConfig.Create().SmtpSetting.Sender, recipient, subject, body, true, Encoding.Default, true, null);
        }

        public static void Send(string Recipient, string Sender, string Subject, string Body)
        {
            Send(SmtpConfig.Create().SmtpSetting.Server, Sender, Recipient, Subject, Body, true, Encoding.UTF8, true, null);
        }
    }
}
