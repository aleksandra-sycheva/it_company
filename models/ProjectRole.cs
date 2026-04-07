using System;
using System.Collections.Generic;

namespace it_company.models;

public partial class ProjectRole
{
    public int ProjectRoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
}
