using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Car
{
    public int Carid { get; set; }

    public string? Carbrand { get; set; }

    public string? Carmodel { get; set; }

    public long? Price { get; set; }

    public DateTime? Modelyear { get; set; }

    public int? Fueltype { get; set; }

    public int? Owner { get; set; }

    public int? Seats { get; set; }

    public string? Cartype { get; set; }

    public int? Status { get; set; }

    public int? Cityid { get; set; }

    public long? Kmdriven { get; set; }

    public int? Sellerprice { get; set; }

    public int? Userid { get; set; }

    public int? Outletid { get; set; }

    public int? Isapproved { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual City? City { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Object? FueltypeNavigation { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual Object? IsapprovedNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    public virtual Outlet? Outlet { get; set; }

    public virtual Object? OwnerNavigation { get; set; }

    public virtual Object? SeatsNavigation { get; set; }

    public virtual Object? StatusNavigation { get; set; }

    public virtual ICollection<Testd> Testds { get; set; } = new List<Testd>();

    public virtual User? User { get; set; }

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}
