using Microsoft.AspNetCore.Mvc;
using IronPdf;
using System.IO;
using MimeKit;

namespace WebApplication2.Service
{
    public class Invoiceservice:ControllerBase
    {
        private readonly IConfiguration _config;

        public Invoiceservice(IConfiguration configuration)
        {
            _config = configuration;
            
        }
        [HttpGet("gen")]
        public IActionResult GeneratePdf(string html)
        {
            //var url = "./Templat/WelcomeTemp.html";

            //string html = FetchHtmlFromUrl(url);

            byte[] pdfBytes = GeneratePdfFromHtml(html);
            
            var fileName = "generated_file.pdf";
            //sendmail(pdfBytes, "amanactually98@gmail.com", "Spinny Car", "hi");
            // Return the PDF file as a downloadable attachment
            return File(pdfBytes, "application/pdf", fileName);
        }

        private string FetchHtmlFromUrl(string url)
        {
            using (var webClient = new System.Net.WebClient())
            {
                return webClient.DownloadString(url);
            }
        }

        public byte[] GeneratePdfFromHtml(string html)
        {
            var renderer = new HtmlToPdf();
            var pdf = renderer.RenderHtmlAsPdf(html);
            return pdf.BinaryData;
        }


        public void sendmail(byte[] attachmentData,string recipient, string subject, string body)
        {



            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("", _config.GetSection("Smtp:SmtpUsername").Value));
            message.To.Add(new MailboxAddress("", recipient));
            message.Subject = subject;
            //message.Body = new TextPart("invoiceEmailTemphtml") { Text = body };



            var bodybuilder = new BodyBuilder();
            bodybuilder.TextBody = body;
            var attachment = bodybuilder.Attachments.Add("Invoice.pdf", attachmentData);
            message.Body = bodybuilder.ToMessageBody();

            //var multipart = new Multipart("mixed");

            //// Add the PDF attachment
            //var attachment = new MimePart("application", "pdf")
            //{
            //    Content = new MimeContent(new MemoryStream(attachmentData)),
            //    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
            //    ContentTransferEncoding = ContentEncoding.Base64,
            //    FileName = "Invoice.pdf"
            //};
            //multipart.Add(attachment);

            //// Add the HTML body
            //var htmlBody = new TextPart("invoiceEmailTemphtml")
            //{
            //    Text = body
            //};
            //multipart.Add(htmlBody);

            //message.Body = multipart;

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(_config.GetSection("Smtp:SmtpHost").Value, Convert.ToInt16(_config.GetSection("Smtp:SmtpPort").Value));
                client.Authenticate(_config.GetSection("Smtp:SmtpUsername").Value, _config.GetSection("Smtp:SmtpPassword").Value);
                client.Send(message);

                client.Disconnect(true);

            }
        }
    }
}
