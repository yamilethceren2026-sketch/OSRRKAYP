using System;
using System.Collections.Generic;

namespace OSRRKAYP.Entities;

public partial class User
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public string Alias { get; set; } = null!;

    public string? EncryptedPassword { get; set; }

    public virtual Role Role { get; set; } = null!;
}
