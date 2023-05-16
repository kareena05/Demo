﻿using System.ComponentModel.DataAnnotations;

namespace Twitter
{
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
        [StringLength(120)]
        public string password { get; set; }
        [Required]
        public DateTime birthdate { get; set; }
    }
}
