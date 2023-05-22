using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Twitter.Models;

namespace Twitter.Entities
{
    public class Like_Tweet_entity
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("tweet_tbl")]
        public int tweet_id { get; set; }
        public  Tweet_entity tweet_tbl { get; set; }

        [ForeignKey("User")]
        public int user_id { get; set; } 
        public  User_entity User { get; set; }

        public DateTime created_on { get; set; }    

    }
}
