namespace WebApplication2.Dto
{
    public class CreateOrderRequestDTO
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Receipt { get; set; }
    }
}
