using System.ComponentModel.DataAnnotations;

namespace MeraKhata.Model
{
    public class UserModel
    {
        [Required]
        public string Fullname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Mobile { get; set; }
    }
}
