using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class CityRepo:GenericRepo<City>,Icity
    {
        public CityRepo(MiniprojectContext context):base(context)
        {
            
        }
    }
}
