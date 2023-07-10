using MeraKhata.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeraKhata.Models
{
    public class BackUpEntity : BaseEntity
    {


        [ForeignKey("userid")]
        [Required]
        public int userid { get; set; }
        public virtual UserEntity user { get; set; }
        [Required]
        public DateTime lastbackup { get; set; }
        [Required]
        public string filename { get; set; }
    }
}
