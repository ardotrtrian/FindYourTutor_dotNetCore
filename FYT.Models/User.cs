using FYT.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FYT.Models
{
    public class User : EntityBase
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public virtual Role Role { get; set; }

        [Required]
        public virtual Image Image { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
