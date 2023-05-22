
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Twitter.Models;

namespace Twitter.Entities
{
    public class Comment_entity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("tweets")]
        public int tweet_id { get;set; }
        public Tweet_entity tweets { get; set; }

        [ForeignKey("user")]
        public int user_id { get; set; }
        public User_entity user { get; set; }

        public string comment_text { get; set; }

        public DateTime created_on { get; set; }
        public DateTime modified_on { get; set;}


    }
}
