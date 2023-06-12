using System;
using System.Collections.Generic;

namespace DBfirstAgain.Models;

public partial class LikeTweet
{
    public int Id { get; set; }

    public int? TweetId { get; set; }

    public int? UserId { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual Tweet? Tweet { get; set; }

    public virtual User? User { get; set; }
}
