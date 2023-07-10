using System.ComponentModel.DataAnnotations;

namespace MeraKhata.Models
{
    public class BackUpModel
    {
        public int Userid { get; set; }
       
        [Required]
        public DateTime Lastbackup { get; set; }
        [Required]
        public string Filename { get; set; }
    }
}
