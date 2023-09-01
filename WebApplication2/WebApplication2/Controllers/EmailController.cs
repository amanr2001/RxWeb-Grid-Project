//using Microsoft.AspNetCore.Mvc;
//using MimeKit;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace WebApplication2.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmailController : ControllerBase
//    {
//        private const string SmtpHost = "mail.mailtest.radixweb.net"; // e.g., smtp.gmail.com

//        private const int SmtpPort = 465; // e.g., 587 for Gmail

//        private const string SmtpUsername = "testphp@mailtest.radixweb.net";

//        private const string SmtpPassword = "Radix@web#8";
//        [HttpPost("mail")]
//        public IActionResult sendmail(string recipient, string subject, string body)
//        {
//            var message = new MimeMessage();
//            message.From.Add(new MailboxAddress("", SmtpUsername));
//            message.To.Add(new MailboxAddress("", recipient));
//            message.Subject = subject;


//            var bodybuilder = new BodyBuilder();
//            bodybuilder.TextBody = body;
//            message.Body = bodybuilder.ToMessageBody();


//            using (var client = new MailKit.Net.Smtp.SmtpClient())

//            {

//                client.Connect(SmtpHost, SmtpPort);

//                client.Authenticate(SmtpUsername, SmtpPassword);

//                client.Send(message);

//                client.Disconnect(true);

//            }
//            return NoContent();

//        }
//    }
//}
