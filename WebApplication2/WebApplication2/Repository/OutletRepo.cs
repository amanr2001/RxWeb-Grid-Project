using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class OutletRepo : GenericRepo<Outlet>, Ioutlet
    {
        public OutletRepo(MiniprojectContext context) : base(context)
        {
        }
    }
}
