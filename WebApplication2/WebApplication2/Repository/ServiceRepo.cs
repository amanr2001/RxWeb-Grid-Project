using MimeKit;
using iTextSharp.text;
using iTextSharp.text.pdf;
using WebApplication2.Interfaces;

namespace WebApplication2.Repository
{
    public class ServiceRepo : Iservice
    {
        private readonly IConfiguration _config;

        public ServiceRepo(IConfiguration configuration)
        {
            _config = configuration;    
        }
        public void sendmail(string recipient, string subject, string body)
        {



            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("", _config.GetSection("Smtp:SmtpUsername").Value));
            message.To.Add(new MailboxAddress("", recipient));
            message.Subject = subject;
            message.Body = new TextPart("html") { Text = body };

           


            //var bodybuilder = new BodyBuilder();
            //bodybuilder.TextBody = body;
          

            using (var client = new MailKit.Net.Smtp.SmtpClient())

            {

                client.Connect(_config.GetSection("Smtp:SmtpHost").Value,Convert.ToInt16( _config.GetSection("Smtp:SmtpPort").Value));

                client.Authenticate(_config.GetSection("Smtp:SmtpUsername").Value, _config.GetSection("Smtp:SmtpPassword").Value);

                client.Send(message);

                client.Disconnect(true);

            }
        }

        

        
    }
}
