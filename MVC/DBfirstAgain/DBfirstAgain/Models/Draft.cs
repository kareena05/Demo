using System;
using System.Collections.Generic;

namespace DBfirstAgain.Models;

public partial class Draft
{
    public int Id { get; set; }

    public string TweetText { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
