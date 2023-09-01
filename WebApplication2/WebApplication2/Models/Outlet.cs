using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Outlet
{
    public int Outletid { get; set; }

    public string? Outletlocation { get; set; }

    public int? Cityid { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual City? City { get; set; }
}
