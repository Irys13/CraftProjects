using System;
using System.Collections.Generic;

namespace CraftingProjects.Server.Models;

public partial class Resource
{
    public int ResourceId { get; set; }

    public int ProjectId { get; set; }

    public string ResourceType { get; set; } = null!;

    public int ResourceReferenceId { get; set; }

    public decimal? Quantity { get; set; }

    public virtual Project Project { get; set; } = null!;
}
