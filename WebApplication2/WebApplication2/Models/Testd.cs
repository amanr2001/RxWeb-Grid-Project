using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Testd
{
    public int Testdid { get; set; }

    public string? Location { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? Time { get; set; }

    public int? Carid { get; set; }

    public int? Userid { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? TestStatus { get; set; }

    public virtual Car? Car { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Object? TestStatusNavigation { get; set; }

    public virtual User? User { get; set; }
}
