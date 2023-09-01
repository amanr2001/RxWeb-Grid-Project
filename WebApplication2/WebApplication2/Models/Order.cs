using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Order
{
    public int Orderid { get; set; }

    public int? Orderstatus { get; set; }

    public int? Userid { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    public virtual Object? OrderstatusNavigation { get; set; }

    public virtual User? User { get; set; }
}
