using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Payment
{
    public int Paymentid { get; set; }

    public string? Paymentstatus { get; set; }

    public string? Paymentmethod { get; set; }

    public long? Paymentamount { get; set; }

    public DateTime? Paymentdatetime { get; set; }

    public int? Orderitem { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? ModifiedByNavigation { get; set; }

    public virtual Orderitem? OrderitemNavigation { get; set; }
}
