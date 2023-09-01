using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Objtype
{
    public int Typeid { get; set; }

    public string? Name { get; set; }

    public int? Parentid { get; set; }

    public virtual ICollection<Objtype> InverseParent { get; set; } = new List<Objtype>();

    public virtual ICollection<Object> Objects { get; set; } = new List<Object>();

    public virtual Objtype? Parent { get; set; }
}
