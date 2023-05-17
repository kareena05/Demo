using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Twitter
{
    //Not directly connected with database
    //connected with original entity
    //takes the user input
    public class SaveUserModel
    {
        public int id { get; set; }

        [StringLength(100)]
        public string firstname { get; set; }
        [StringLength(100)]
        public string lastname { get; set; }
        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [StringLength(320)]
        public string email { get; set; }

        [Required]
        [PasswordPropertyText(true)]
        public string password { get; set; }
        
        [Required]
        [Compare("password")]
        public string repassword { get; set; }

        [Required]
        
        public DateTime birthdate { get; set; }
    }
}
