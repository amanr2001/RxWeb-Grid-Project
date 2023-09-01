using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Orderitem
{
    public int Orderitem1 { get; set; }

    public int? Carid { get; set; }

    public int? Orderid { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
