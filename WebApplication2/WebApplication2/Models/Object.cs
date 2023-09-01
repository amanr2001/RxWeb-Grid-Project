using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Object
{
    public int ObjId { get; set; }

    public string? Name { get; set; }

    public int? Typeid { get; set; }

    public virtual ICollection<Car> CarFueltypeNavigations { get; set; } = new List<Car>();

    public virtual ICollection<Car> CarIsapprovedNavigations { get; set; } = new List<Car>();

    public virtual ICollection<Car> CarOwnerNavigations { get; set; } = new List<Car>();

    public virtual ICollection<Car> CarSeatsNavigations { get; set; } = new List<Car>();

    public virtual ICollection<Car> CarStatusNavigations { get; set; } = new List<Car>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Testd> Testds { get; set; } = new List<Testd>();

    public virtual Objtype? Type { get; set; }
}
