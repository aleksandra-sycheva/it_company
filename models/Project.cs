using System;
using System.Collections.Generic;

namespace it_company.models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? Description { get; set; }

    public int StatusId { get; set; }

    public DateOnly StartDate { get; set; }

    public int ManagerId { get; set; }

    public virtual User Manager { get; set; } = null!;

    public virtual ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();

    public virtual ProjectStatus Status { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
