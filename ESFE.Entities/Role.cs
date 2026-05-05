using System;
using System.Collections.Generic;

namespace ESFE.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string? LevelName { get; set; }

    public bool? IsAvailable { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
