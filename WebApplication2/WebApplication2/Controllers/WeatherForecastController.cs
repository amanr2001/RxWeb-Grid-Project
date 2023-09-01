using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using WebApplication2.Interfaces;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Iservice _serv;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,Iservice iservice)
        {
            _logger = logger;
            _serv= iservice;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            _serv.sendmail("amanactually98@gmail.com", "333", "434");
            return Ok();
          
        }



        //private const string SmtpHost = "mail.mailtest.radixweb.net"; // e.g., smtp.gmail.com
        //private const int SmtpPort = 465; // e.g., 587 for Gmail
        //private const string SmtpUsername = "testdotnet@mailtest.radixweb.net";
        //private const string SmtpPassword = "Radix@web#8";

        //[HttpPost]
        //public void SendEmail(string recipient, string subject, string body)
        //{
        //    var message = new MimeMessage();
        //    message.From.Add(new MailboxAddress("", SmtpUsername));
        //    message.To.Add(new MailboxAddress("", recipient));
        //    message.Subject = subject;

        //    var bodyBuilder = new BodyBuilder();
        //    bodyBuilder.TextBody = body;

        //    message.Body = bodyBuilder.ToMessageBody();

        //    using (var client = new SmtpClient())
        //    {
        //        client.Connect(SmtpHost, SmtpPort);
        //        client.Authenticate(SmtpUsername, SmtpPassword);
        //        client.Send(message);
        //        client.Disconnect(true);
        //    }
        //}



        
        private IActionResult GeneratePdf()
        {
            var url = "./Templat/WelcomeTemp.html";

            string html = FetchHtmlFromUrl(url);

            byte[] pdfBytes = GeneratePdfFromHtml(html);

            return File(pdfBytes, "application/pdf", "generated_file.pdf");
        }

        private string FetchHtmlFromUrl(string url)
        {
            using (var webClient = new System.Net.WebClient())
            {
                return webClient.DownloadString(url);
            }
        }

        private byte[] GeneratePdfFromHtml(string html)
        {
            var renderer = new HtmlToPdf();
            var pdf = renderer.RenderHtmlAsPdf(html);
            return pdf.BinaryData;
        }
    }
}