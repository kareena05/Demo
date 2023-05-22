using System.ComponentModel.DataAnnotations;

namespace TestingMVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        public int display_order { get; set; }

        public DateTime created_on { get; set; } = DateTime.Now;
    }
}
