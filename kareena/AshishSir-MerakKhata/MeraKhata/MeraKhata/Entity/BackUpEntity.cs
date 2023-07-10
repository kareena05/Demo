using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeraKhata.Models
{
    public class BackUpEntity
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Userid")]
        [Required]
        public int Userid { get; set; }
        public virtual UserEntity User { get; set; }
        [Required]
        public DateTime Lastbackup { get; set; }
        [Required]
        public string Filename { get; set; }
    }
}
