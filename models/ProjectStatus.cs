using System;
using System.Collections.Generic;

namespace it_company.models;

public partial class ProjectStatus
{
    public int ProjectStatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
