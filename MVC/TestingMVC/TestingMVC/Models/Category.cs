using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestingMVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        [DisplayName("Display Order")]
        //client side custom error
        [Range(1,100,ErrorMessage ="Display order must be between 1 to 100 only")]
        public int display_order { get; set; }

        public DateTime created_on { get; set; } = DateTime.Now;
    }
}
