using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class RoleRepo : GenericRepo<Role>, Irole
    {
        public RoleRepo(MiniprojectContext context) : base(context)
        {
        }
    }
}
