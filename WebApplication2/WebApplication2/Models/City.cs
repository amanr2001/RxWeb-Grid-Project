using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class City
{
    public int Cityid { get; set; }

    public string? Cityname { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<Outlet> Outlets { get; set; } = new List<Outlet>();
}
