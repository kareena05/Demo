using System.ComponentModel.DataAnnotations;

namespace SchoolMVC.Models
{
    public class EmployeeEntity
    {
        
        public int id { get; set; }
        [StringLength(30,ErrorMessage ="Please enter the name upto 30 characters")]
        public string name { get; set; }
        public string address { get; set; }
        public decimal salary { get; set; }   
        public string city { get; set; }    
        public string gender { get; set; }
        public DateTime dob { get; set; } 
    }
}
