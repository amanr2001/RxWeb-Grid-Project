using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class CarRepo:GenericRepo<Car>, Icar
    {
        public CarRepo(MiniprojectContext context):base(context) 
        {
            
        }
    }
}
