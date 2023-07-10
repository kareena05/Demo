using MeraKhata.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeraKhata.Models
{
    public class UserEntity: BaseEntity
    {
       
        [Required]
        public string fullname { get; set; }

        [Required]
        public string email { get; set; }

        [DataType(DataType.PhoneNumber)]

        public string mobile { get; set; }

       


    }
}
