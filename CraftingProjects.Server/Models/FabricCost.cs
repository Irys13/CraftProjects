using System;
using System.Collections.Generic;

namespace CraftingProjects.Server.Models;

public partial class FabricCost
{
    public int FabricCostId { get; set; }

    public int FabricId { get; set; }

    public decimal Width { get; set; }

    public decimal Height { get; set; }

    public decimal Price { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public decimal? FabricTotalCost { get; set; }

    public string Shop { get; set; } = null!;

    public virtual Fabric Fabric { get; set; } = null!;
}
