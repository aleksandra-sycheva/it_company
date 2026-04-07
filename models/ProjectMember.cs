using System;
using System.Collections.Generic;

namespace it_company.models;

public partial class ProjectMember
{
    public int ProjectMemberId { get; set; }

    public int ProjectId { get; set; }

    public int UserId { get; set; }

    public int ProjectRoleId { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ProjectRole ProjectRole { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
