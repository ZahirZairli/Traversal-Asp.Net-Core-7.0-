namespace PresentationLayer.Areas.Admin.Models
{
    public class MailRequest
    {
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
