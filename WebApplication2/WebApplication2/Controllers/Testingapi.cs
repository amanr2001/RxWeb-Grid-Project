using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using iTextSharp.tool.xml;
using Microsoft.AspNetCore.Routing.Template;
using WebApplication2.Interfaces;
using MimeKit;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using RazorEngine;
using WebApplication2.Dto;
using DinkToPdf.Contracts;
using System.Threading.Tasks;
using PuppeteerSharp;
//using static Org.BouncyCastle.Math.EC.ECCurve;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Testingapi : ControllerBase
    {
   

        public Testingapi()
        {
           
        }

        [HttpGet("testingapi")]
        public IActionResult test()
        {
            return Ok();
        }


        //public IActionResult GeneratePdf()
        //{
        //    // Create a new MemoryStream to store the generated PDF
        //    using (MemoryStream memoryStream = new MemoryStream())
        //    {
        //        // Create a new PDF document
        //        using (Document document = new Document())
        //        {
        //            // Set up the PDF writer to write to the MemoryStream
        //            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

        //            // Open the document to start writing
        //            document.Open();

        //            // Load the template PDF
        //            PdfReader templateReader = new PdfReader("./Templat/WelcomeTemp.html");
        //            PdfImportedPage templatePage = writer.GetImportedPage(templateReader, 1); // Use the first page of the template

        //            // Add the template page to the new document
        //            PdfContentByte contentByte = writer.DirectContent;
        //            contentByte.AddTemplate(templatePage, 0, 0);

        //            // Add dynamic content to the PDF here (e.g., paragraphs, images, tables, etc.)
        //            // For example:
        //            ColumnText ct = new ColumnText(contentByte);
        //            ct.SetSimpleColumn(new Rectangle(100, 500, 500, 800));
        //            ct.AddElement(new Paragraph("Hello, this is your generated PDF!"));
        //            ct.Go();

        //            // Close the document
        //            document.Close();
        //        }

        //        // Return the byte array representing the generated PDF
        //        return File(memoryStream.ToArray(), "application/pdf", "generated_pdf.pdf");
        //    }
        //}







        //email

        //private async Task SendEmailWithAttachment(byte[] attachmentData, string recipientEmail, string subject)
        //{
        //    var message = new MimeMessage();
        //    message.From.Add(new MailboxAddress("Your Name", "amanactually98@example.com"));
        //    message.To.Add(new MailboxAddress("", recipientEmail));
        //    message.Subject = subject;

        //    var builder = new BodyBuilder();
        //    builder.TextBody = "Please find the attached PDF.";

        //    // Attach the PDF
        //    builder.Attachments.Add("Report.pdf", attachmentData, ContentType.Parse("application/pdf"));

        //    message.Body = builder.ToMessageBody();

        //    using (var client = new MailKit.Net.Smtp.SmtpClient())
        //    {
        //        client.Connect(_config.GetSection("Smtp:SmtpHost").Value, Convert.ToInt16(_config.GetSection("Smtp:SmtpPort").Value));
        //        client.Authenticate(_config.GetSection("Smtp:SmtpUsername").Value, _config.GetSection("Smtp:SmtpPassword").Value);
        //        client.Send(message);

        //        client.Disconnect(true);
        //    }
        //}








    }
}
