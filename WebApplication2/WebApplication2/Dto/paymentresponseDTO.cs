namespace WebApplication2.Dto
{
    public class paymentresponseDTO
    {
        public string paymentId { get; set; }
        public string Status { get; set; }

        public string paymentmethod { get; set; }
        public DateTime time { get; set; }

        public long amount { get; set; }
    }
}
