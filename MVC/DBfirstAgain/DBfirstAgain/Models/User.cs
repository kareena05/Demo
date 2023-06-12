using System;
using System.Collections.Generic;

namespace DBfirstAgain.Models;

public partial class User
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public DateTime ModifiedOn { get; set; }

    public DateTime CreatedOn { get; set; }

    public bool? IsActive { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Draft> Drafts { get; set; } = new List<Draft>();

    public virtual ICollection<Follower> FollowerFollowerNavigations { get; set; } = new List<Follower>();

    public virtual ICollection<Follower> FollowerUsers { get; set; } = new List<Follower>();

    public virtual ICollection<LikeTweet> LikeTweets { get; set; } = new List<LikeTweet>();

    public virtual ICollection<Tweet> Tweets { get; set; } = new List<Tweet>();

    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
}
