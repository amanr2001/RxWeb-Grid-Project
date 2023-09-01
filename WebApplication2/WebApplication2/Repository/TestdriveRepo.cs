using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class TestdriveRepo : GenericRepo<Testd>, Itestdrive
    {
        public TestdriveRepo(MiniprojectContext context) : base(context)
        {
        }
    }
}
