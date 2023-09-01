using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Type
{
    public int Typeid { get; set; }

    public string? Name { get; set; }

    public int? Parentid { get; set; }

    public virtual ICollection<Type> InverseParent { get; set; } = new List<Type>();

    public virtual ICollection<Object> Objects { get; set; } = new List<Object>();

    public virtual Type? Parent { get; set; }
}
