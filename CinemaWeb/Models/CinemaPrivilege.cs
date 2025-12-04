using System;
using System.Collections.Generic;

namespace CinemaWeb.Models;

public partial class CinemaPrivilege
{
    public int PrivilegeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CinemaUserRole> Roles { get; set; } = new List<CinemaUserRole>();
}
