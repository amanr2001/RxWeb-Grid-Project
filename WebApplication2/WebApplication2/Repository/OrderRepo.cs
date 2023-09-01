using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class OrderRepo : GenericRepo<Order>, Iorder
    {
        public OrderRepo(MiniprojectContext context) : base(context)
        {
        }
    }
}
