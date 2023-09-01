namespace WebApplication2.Interfaces
{
    public interface Iservice
    {
        public void sendmail(string recipient, string subject, string body);
        //public void SendEmailWithAttachment(byte[] attachmentData, string recipientEmail, string subject);
    }
}
