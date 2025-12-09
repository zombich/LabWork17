using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaWeb.Models;

public partial class CinemaUser
{
    public int UserId { get; set; }

    public string Login { get; set; } = null!;
    [DataType(DataType.Password)]
    public string PasswordHash { get; set; } = null!;

    public int FailedLoginAttempts { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime? LockedUntil { get; set; }

    public int RoleId { get; set; }

    public virtual CinemaUserRole Role { get; set; } = null!;
}
