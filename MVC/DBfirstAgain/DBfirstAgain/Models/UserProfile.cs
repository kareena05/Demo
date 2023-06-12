using System;
using System.Collections.Generic;

namespace DBfirstAgain.Models;

public partial class UserProfile
{
    public int Id { get; set; }

    public string Bio { get; set; } = null!;

    public string UserProfileImg { get; set; } = null!;

    public int UserId { get; set; }

    public bool? AccountType { get; set; }

    public virtual User User { get; set; } = null!;
}
