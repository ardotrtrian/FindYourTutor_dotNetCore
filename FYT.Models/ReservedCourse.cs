using FYT.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FYT.Models
{
    public class ReservedCourse : EntityBase
    {
        [Required]
        public virtual Course Course { get; set; }

        [Required]
        public virtual ICollection<User> Users { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}
