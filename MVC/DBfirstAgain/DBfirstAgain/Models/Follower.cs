using System;
using System.Collections.Generic;

namespace DBfirstAgain.Models;

public partial class Follower
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? FollowerId { get; set; }

    public bool IsApproved { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual User? FollowerNavigation { get; set; }

    public virtual User? User { get; set; }
}
