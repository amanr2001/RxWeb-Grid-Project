using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Wishlist
{
    public int Wishlistid { get; set; }

    public int? Carid { get; set; }

    public int? Userid { get; set; }

    public bool? Wishliststatus { get; set; }

    public virtual Car? Car { get; set; }

    public virtual User? User { get; set; }
}
