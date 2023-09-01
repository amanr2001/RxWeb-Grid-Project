using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Role
{
    public int Roleid { get; set; }

    public string? Role1 { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
