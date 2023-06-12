using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace oncAgainMVC.Models
{
    public class demoModel
    {
        [DisplayFormat(NullDisplayText ="id cannot be null")]
        public int id { get; set; }

      [DisplayNameAttribute("Employee Name")]
        public string name { get; set; }

        [DataType(DataType.Date)]
        public DateTime dob { get; set; }

        [DataType(DataType.Password)]
        public int password { get; set; }

        [DataType(DataType.Url)]
        public string url { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }
    }
}
