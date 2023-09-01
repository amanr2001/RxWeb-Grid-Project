using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class WishlistRepo : GenericRepo<Wishlist>, Iwishlist
    {
        public WishlistRepo(MiniprojectContext context) : base(context)
        {
        }
    }
}
