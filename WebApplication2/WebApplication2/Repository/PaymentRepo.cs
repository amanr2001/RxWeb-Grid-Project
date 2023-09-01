using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class PaymentRepo : GenericRepo<Payment>, Ipayment
    {
        public PaymentRepo(MiniprojectContext context) : base(context)
        {
        }
    }
}
