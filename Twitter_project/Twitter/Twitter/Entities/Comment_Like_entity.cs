using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Models
{
    public class Comment_Like_entity
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("comments")]
        public int comment_id { get; set; }
        public Comment_Like_entity comments;

        [ForeignKey("tweets")]
        public int tweet_id { get; set; }
        public Tweet_entity tweets;

        [ForeignKey("user")]
        public int user_id { get; set; }
        public User_entity user { get; set; }

    }
}
