using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class userRepo : GenericRepo<User>, Iuser
    {
        public userRepo(MiniprojectContext context) : base(context)
        {
        }
    }
}
