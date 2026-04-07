using System;
using System.Collections.Generic;

namespace it_company.models;

public partial class Task
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public string? Description { get; set; }

    public int StatusId { get; set; }

    public int PriorityId { get; set; }

    public int ProjectId { get; set; }

    public int? AssigneeId { get; set; }

    public DateOnly CreatedDate { get; set; }

    public DateOnly DueDate { get; set; }

    public virtual User? Assignee { get; set; }

    public virtual Priority Priority { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual TaskStatus Status { get; set; } = null!;
}
