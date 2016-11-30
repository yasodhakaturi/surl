using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Analytics.Helpers.Utility
{
    public class EmailUtil
    {
        public static void SendMail(string from, string To, string cc, string bcc, string subject, string body, params string[] attachments)
        {

            // from = System.Configuration.ConfigurationManager.AppSettings["SMTPUsername"];
            MailMessage objMail = new MailMessage(from, To);
            if ((cc != ""))
                objMail.CC.Add(cc);
            if ((bcc != ""))
                objMail.Bcc.Add(bcc);
            objMail.Subject = subject;
            objMail.Body = body;
            objMail.IsBodyHtml = true;

            foreach (string attachment in attachments)
                if (!string.IsNullOrEmpty(attachment))
                    objMail.Attachments.Add(new Attachment(attachment));

            string smtpServer = System.Configuration.ConfigurationManager.AppSettings["SMTPServer1"];
            string smtpPassword = System.Configuration.ConfigurationManager.AppSettings["SMTPPassword1"];
            string smtpUsername = System.Configuration.ConfigurationManager.AppSettings["SMTPUsername1"];
            string smtpPortNumber = System.Configuration.ConfigurationManager.AppSettings["SMTPPortNumber1"];
            if (string.IsNullOrEmpty(smtpServer))
                throw new ApplicationException("SMTP Server settings are not provided in Web.config");
            SmtpClient objSmtpClient = new SmtpClient(smtpServer);
            objSmtpClient.Port = int.Parse(smtpPortNumber);
            //if (!String.IsNullOrEmpty(smtpUsername))
            //{
            //    objSmtpClient.UseDefaultCredentials = false;
            //    NetworkCredential credential = new NetworkCredential(smtpUsername, smtpPassword);
            //    objSmtpClient.Credentials = credential;
            //}
            //else
            //    objSmtpClient.UseDefaultCredentials = true;
            //SmtpClient objSmtpClient = new SmtpClient();

            objSmtpClient.Host = "smtp.gmail.com";
            objSmtpClient.Port = 587;// int.Parse(smtpPortNumber);

            objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            objSmtpClient.EnableSsl = true;

            if (!String.IsNullOrEmpty(smtpUsername))
            {
                objSmtpClient.UseDefaultCredentials = false;
                NetworkCredential credential = new NetworkCredential(smtpUsername, smtpPassword);
                objSmtpClient.Credentials = credential;
            }
            else
                objSmtpClient.UseDefaultCredentials = true;
            try
            {
                objSmtpClient.Send(objMail);
            }
            catch (Exception ex)
            {
            }
        }
    }
}