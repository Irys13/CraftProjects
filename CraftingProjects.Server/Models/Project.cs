using System;
using System.Collections.Generic;

namespace CraftingProjects.Server.Models;

public partial class Project
{
    public int ProjectsId { get; set; }

    public string Name { get; set; } = null!;

    public string Craft { get; set; } = null!;

    public byte Resources { get; set; }

    public byte Pattern { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string Receiver { get; set; } = null!;

    public virtual ICollection<Resource> ResourcesNavigation { get; set; } = new List<Resource>();
}
