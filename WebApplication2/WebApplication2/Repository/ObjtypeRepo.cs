using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class ObjtypeRepo : GenericRepo<Objtype>, IobjType
    {
        public ObjtypeRepo(MiniprojectContext context) : base(context)
        {
        }
    }
}
