using System;
using System.Collections.Generic;

namespace CraftingProjects.Server.Models;

public partial class Fabric
{
    public int FabricId { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public decimal Width { get; set; }

    public decimal Height { get; set; }

    public string Colour { get; set; } = null!;

    public string ColourDescription { get; set; } = null!;

    public string? Url { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<FabricCost> FabricCosts { get; set; } = new List<FabricCost>();
}
