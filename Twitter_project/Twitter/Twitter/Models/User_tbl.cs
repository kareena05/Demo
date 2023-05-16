using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Models
{
    public class User_tbl
    {
        [Key]

        public int id { get; set; }

        [StringLength(100)]
        public string firstname { get; set; }
        [StringLength(100)]
        public string lastname { get; set; }
        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [StringLength(320)]
        public string email { get;set; }

        [Required]
        [StringLength(120)]
        public string password { get; set; }
        [Required]
        public DateTime birthdate { get; set; }
        
        public DateTime created_on { get; set; }

        public DateTime modified_on { get; set;}

        public bool is_active { get; set; } = true;

    }
}
