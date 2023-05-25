namespace MailSenderApi.ViewModels
{
    public class SendEmailViewModel
    {
        public string[] Emails { get; set; } 
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; }=string.Empty;
        public bool IsHtml { get; set; }
    }
}
