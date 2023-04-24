using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PresentationLayer.Areas.Admin.Models;

namespace PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            if (ModelState.IsValid)
            {
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Traversal", "zahirtraversal@gmail.com");
                mimeMessage.From.Add(mailboxAddressFrom);
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
                mimeMessage.To.Add(mailboxAddressTo);

                mimeMessage.Subject = mailRequest.Subject;
                
                var bodyBuilder=new BodyBuilder();
                bodyBuilder.TextBody = mailRequest.Body;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                //zahirtraversal@gmail.com  
                client.Authenticate("zahirtraversal@gmail.com", "jxrjhrjfvqpvkszu");

                client.Send(mimeMessage);
                client.Disconnect(true);
                TempData["message"] = "true";
            }
            return View();
        }
    }
}
