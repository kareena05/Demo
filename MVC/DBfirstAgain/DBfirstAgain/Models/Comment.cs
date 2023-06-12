using System;
using System.Collections.Generic;

namespace DBfirstAgain.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int? TweetId { get; set; }

    public int? UserId { get; set; }

    public string CommentText { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }

    public virtual Tweet? Tweet { get; set; }

    public virtual User? User { get; set; }
}
