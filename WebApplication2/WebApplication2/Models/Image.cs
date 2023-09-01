using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Image
{
    public int Imageid { get; set; }

    public string? Frontview { get; set; }

    public string? Leftside { get; set; }

    public string? Rightside { get; set; }

    public string? Backview { get; set; }

    public int? Carid { get; set; }

    public virtual Car? Car { get; set; }
}
