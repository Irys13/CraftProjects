using System;
using System.Collections.Generic;

namespace CraftingProjects.Server.Models;

public partial class YarnCost
{
    public int YarnCostId { get; set; }

    public int YarnId { get; set; }

    public byte Skeins { get; set; }

    public decimal Price { get; set; }

    public decimal? YarnTotalCost { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public string Shop { get; set; } = null!;

    public virtual Yarn Yarn { get; set; } = null!;
}
