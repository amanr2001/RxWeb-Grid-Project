using WebApplication2.Interfaces;
using WebApplication2.Models;
//using Object = WebApplication2.Models.Object;

namespace WebApplication2.Repository
{
    public class ObjectRepo : GenericRepo<Models.Object>, Iobject
    {
        public ObjectRepo(MiniprojectContext context) : base(context)
        {
        }
    }
}
