using System.Net;
using System.Net.Mail;

namespace MailSenderApi.Infra.Services
{
    public class MailService: IMailService
    {
        private string smtpAdress => "smtp.office365.com";
        private int portNumer => 587;
        private string emailFrom => "cpiconsultoria23@hotmail.com";
        private string password => "cpiconsultoria2023";

        public void SendMail(string[] emails, string subject, string body, bool ishtml=false)
        {
            using(MailMessage mailmessage = new MailMessage())
            {
                mailmessage.From= new MailAddress(emailFrom);
                AddEmailToMailMessage(mailmessage, emails);
                mailmessage.Subject = subject;
                mailmessage.Body = body;
                mailmessage.IsBodyHtml= ishtml;
                using(SmtpClient smtp= new SmtpClient(smtpAdress, portNumer))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials= new NetworkCredential(emailFrom, password);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(mailmessage);
                }
            }
        }

        public void AddEmailToMailMessage (MailMessage mailMessage, string[] emails)
        {
            foreach (var email in emails)
            {
                mailMessage.To.Add(email);
            }
        }
    }
}
