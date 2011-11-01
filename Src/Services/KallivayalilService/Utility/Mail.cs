using System.Collections.Specialized;
using System.Configuration;
using System.Net.Mail;

namespace Kallivayalil.Utility
{
    public class Mail : IMail
    {
        private readonly SmtpClient smtpClient;
        private readonly NameValueCollection appSettings;

        public Mail(SmtpClient smtpClient)
        {
            appSettings = ConfigurationManager.AppSettings;

            smtpClient.Credentials = new System.Net.NetworkCredential(appSettings["Email.UserName"], appSettings["Email.Password"]);
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;

            this.smtpClient = smtpClient;
        }


        public void Send(string to, string subject, string mailBody)
        {
            smtpClient.Send(CreateEmailMsg(to, subject, mailBody));
        }

        private MailMessage CreateEmailMsg(string to, string subject, string mailBody)
        {
            var msg = new MailMessage();
            msg.To.Add(to);
            msg.From = new MailAddress(appSettings["Email.UserName"], "Kallivayalil_Family_Website - Admin Team", System.Text.Encoding.UTF8);
            msg.Subject = subject;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = mailBody;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;
            msg.Priority = MailPriority.High;
            return msg;
        }
    }
}
