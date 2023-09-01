using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class MainPageRepo : GenericRepo<MainPage>, ImainPage
    {
        public MainPageRepo(MiniprojectContext context) : base(context)
        {
        }
    }
}
