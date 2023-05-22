namespace Twitter.Models
{
    public class TweetsOfMyFollowers
    {

            
            public string Username { get; set; }
            public string firstname { get; set; }
            public string tweet_text { get; set; }
            public DateTime posted_on { get; set; }
            public int likes { get; set; }
            public IEnumerable<Comments_and_Users> comments { get; set; }
            public int comments_count { get;  set; }
        
    }
}
