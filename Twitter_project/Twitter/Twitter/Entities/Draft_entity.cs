using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Twitter.Models;

namespace Twitter.Entities
{
    public class Draft_entity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(280)]
        public string Tweet_text { get; set; }

        [ForeignKey("Tweet_entity")]
        public int UserId { get; set;}
        public virtual User_entity User { get; set; }
    }
}
