using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class OrderItemRepo : GenericRepo<Orderitem>, Iorderitem
    {
        public OrderItemRepo(MiniprojectContext context) : base(context)
        {
        }
    }
}
