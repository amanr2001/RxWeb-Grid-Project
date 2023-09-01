using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class MainPage
{
    public int MainId { get; set; }

    public string? ImageUrl { get; set; }

    public string? ImageTitle { get; set; }

    public string? ImageText { get; set; }

    public int? MainPageType { get; set; }

    public int? PageStatus { get; set; }
}
