using System;
using System.Collections.Generic;

namespace CraftingProjects.Server.Models;

public partial class YarnStash
{
    public int YarnStashId { get; set; }

    public string Status { get; set; } = null!;

    public byte YarnId { get; set; }

    public short Weight { get; set; }

    public short Metrage { get; set; }
}
