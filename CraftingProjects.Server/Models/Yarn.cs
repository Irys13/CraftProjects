using System;
using System.Collections.Generic;

namespace CraftingProjects.Server.Models;

public partial class Yarn
{
    public int YarnId { get; set; }

    public string Name { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public byte ThreadWeight { get; set; }

    public short Weight { get; set; }

    public short Metrage { get; set; }

    public string Colour { get; set; } = null!;

    public string? Url { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<FiberBlend> FiberBlends { get; set; } = new List<FiberBlend>();

    public virtual ICollection<YarnCost> YarnCosts { get; set; } = new List<YarnCost>();
}
