using System;
using System.Collections.Generic;

namespace DBfirstAgain.Models;

public partial class Tweet
{
    public int Id { get; set; }

    public string TweetText { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int UserId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<LikeTweet> LikeTweets { get; set; } = new List<LikeTweet>();

    public virtual User User { get; set; } = null!;
}
