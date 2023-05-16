using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Models
{
    public class UserProfile_tbl
    {

       public int Id { get; set; }
        public string bio { get; set; } = string.Empty;
        public string user_profile_img { get; set; } = string.Empty;

        public bool account_type { get; set; } = true;

        
        //defaultValue: 0

        //The Following Property Exists in the User Entity
        [ForeignKey("User_tbl")]
        public int UserId { get; set; }
        //To Create a Foreign Key it should have the Standard Navigational Property
        public virtual User_tbl User { get; set; }
        
    }
}
