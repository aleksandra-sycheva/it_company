using System;
using System.Collections.Generic;

namespace it_company.models;

public partial class TaskStatus
{
    public int TaskStatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
