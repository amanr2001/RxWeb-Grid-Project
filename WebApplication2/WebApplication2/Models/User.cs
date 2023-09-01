using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class User
{
    public int Userid { get; set; }

    public string? Username { get; set; }

    public string? Useremail { get; set; }

    public string? UserpassSalt { get; set; }

    public string? UserpassHashed { get; set; }

    public int? Roleid { get; set; }

    public int? Otp { get; set; }

    public DateTime? OtpExpDate { get; set; }

    public virtual ICollection<Car> CarCreatedByNavigations { get; set; } = new List<Car>();

    public virtual ICollection<Car> CarModifiedByNavigations { get; set; } = new List<Car>();

    public virtual ICollection<Car> CarUsers { get; set; } = new List<Car>();

    public virtual ICollection<Order> OrderCreatedByNavigations { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderModifiedByNavigations { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderUsers { get; set; } = new List<Order>();

    public virtual ICollection<Payment> PaymentCreatedByNavigations { get; set; } = new List<Payment>();

    public virtual ICollection<Payment> PaymentModifiedByNavigations { get; set; } = new List<Payment>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Testd> TestdCreatedByNavigations { get; set; } = new List<Testd>();

    public virtual ICollection<Testd> TestdModifiedByNavigations { get; set; } = new List<Testd>();

    public virtual ICollection<Testd> TestdUsers { get; set; } = new List<Testd>();

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}
