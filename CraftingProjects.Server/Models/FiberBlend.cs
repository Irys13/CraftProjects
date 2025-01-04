using System;
using System.Collections.Generic;

namespace CraftingProjects.Server.Models;

public partial class FiberBlend
{
    public int BlendId { get; set; }

    public int? YarnId { get; set; }

    public string? FiberType { get; set; }

    public decimal? Percentage { get; set; }

    public virtual Yarn? Yarn { get; set; }
}
