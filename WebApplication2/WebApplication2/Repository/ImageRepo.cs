using WebApplication2.Interfaces;
using WebApplication2.Models;
using Image = WebApplication2.Models.Image;

namespace WebApplication2.Repository
{
    public class ImageRepo:GenericRepo<Image>,Iimage
    {
        public ImageRepo(MiniprojectContext context):base(context) 
        {
            
        }
    }
}
