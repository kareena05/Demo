using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class SaveTweetModel
    {

        public int Id { get; set; }
        [Required]
        [StringLength(280)]
        public string tweet_text { get; set; }
    }
}
