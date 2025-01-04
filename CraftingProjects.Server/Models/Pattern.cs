using System;
using System.Collections.Generic;

namespace CraftingProjects.Server.Models;

public partial class Pattern
{
    public int PatternsId { get; set; }

    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Craft { get; set; } = null!;

    public decimal? Cost { get; set; }

    public string? Url { get; set; }

    public byte Rating { get; set; }
}
