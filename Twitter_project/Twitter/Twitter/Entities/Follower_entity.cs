using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Twitter.Models;

namespace Twitter.Entities
{
    public class Follower_entity
    {

        [Key]
        public int Id { get; set; }


        [ForeignKey("User_entity")]
        public int? user_id { get; set; }
        public User_entity User { get; set; }

        [ForeignKey("User_entity")]
        public int? follower_Id { get; set; }
        public User_entity followed_by { get; set; }


        public bool is_approved { get; set; }

        public DateTime created_on { get; set; }

    }
}
