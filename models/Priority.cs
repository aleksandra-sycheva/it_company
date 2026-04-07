using System;
using System.Collections.Generic;

namespace it_company.models;

public partial class Priority
{
    public int PriorityId { get; set; }

    public string PriorityName { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
