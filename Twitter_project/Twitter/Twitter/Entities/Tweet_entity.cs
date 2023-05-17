using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace Twitter.Models
{
    public class Tweet_entity
    {

        [Key]
        public int Id { get; set; }
        [ForeignKey("User_entity")]
        public int UserId { get; set; }
        public virtual User_entity User { get; set; }

        [Required]
        [StringLength(280)]
        public string tweet_text { get; set; }


        public DateTime created_on { get; set; }

        public DateTime modified_on { get; set; }

        [DefaultValue(false)]
        public bool is_deleted { get; set; }




    }
}
